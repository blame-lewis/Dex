using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Dex
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            this.Text = "Dex v" + Application.ProductVersion;
            deckBackBuffer = new Bitmap(deckBox.Width, deckBox.Height);
            signalBackBuffer = new Bitmap(signalBox.Width, signalBox.Height);
            
            deckGraphics = Graphics.FromImage(deckBackBuffer);
            signalGraphics = Graphics.FromImage(signalBackBuffer);

            deckGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            signalGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            
            NAudio.CoreAudioApi.MMDeviceEnumerator en = new NAudio.CoreAudioApi.MMDeviceEnumerator();
            NAudio.CoreAudioApi.MMDevice def= en.GetDefaultAudioEndpoint(NAudio.CoreAudioApi.DataFlow.Capture,    NAudio.CoreAudioApi.Role.Multimedia);
            string defname ="";
            foreach (NAudio.CoreAudioApi.MMDevice m in en.EnumerateAudioEndPoints(NAudio.CoreAudioApi.DataFlow.Capture, NAudio.CoreAudioApi.DeviceState.Active))
            {
                devices[m.DeviceFriendlyName + " " + m.FriendlyName] = m;

                if(m.DeviceFriendlyName + " " + m.FriendlyName == def.DeviceFriendlyName + " " + def.FriendlyName)
                    defname = m.DeviceFriendlyName + " " + m.FriendlyName;
            }
            foreach(string s in devices.Keys)
                soundInputBox.Items.Add(s);
            if (defname != "")
                soundInputBox.SelectedItem = defname;
            System.Threading.Thread t = new System.Threading.Thread(readLoop);
            t.Name = "Sound card read loop";
            t.IsBackground = true;
            t.Start();
            t = new System.Threading.Thread(parseLoop);
            t.Name = "Parse loop";
            t.IsBackground = true;
            t.Start();
            t = new System.Threading.Thread(refreshLoop);
            t.Name = "Refresh loop";
            t.IsBackground = true;
            t.Start();

            outputModeComboBox.SelectedIndex = 0;
        }
        List<float> outputHistory = new List<float>();
        float lastAngle = 0.0f;
        float highestOutput = 0.0f;
        float lowestOutput = float.MaxValue;
        float xcenter = 0.0f;
        float ycenter = 0.0f;
        void refreshLoop()
        {
            while (!disposed)
            {
                highestOutput = 0.0f;
                lowestOutput = float.MaxValue;
                lock (processHistoryLock)
                {
                    while (leftProcessHistory.Count > 0)
                    {
                        xcenter = (xcenter * 0.99f) + (leftProcessHistory[0] * 0.01f);
                        ycenter = (ycenter * 0.99f) + (rightProcessHistory[0] * 0.01f);
                        float[] comped = compressor.compress(leftProcessHistory[0] - xcenter, rightProcessHistory[0] - ycenter);
                        leftProcessHistory.RemoveAt(0);
                        rightProcessHistory.RemoveAt(0);


                        float angle = 0.0f;
                        if (comped[0] != 0.0f || comped[1] != 0.0f)
                            angle = (float)Math.Atan2(comped[0], comped[1]);

                        float output=0.0f;
                        
                        if(comped[1] >= 0.0f)
                            output= (angle - lastAngle)/10.0f;
                        else
                            output = -(angle - lastAngle) / 10.0f;

                        if (Math.Abs(output) < 3.14f)
                        {
                            outputHistory.Add(output/100.0f);
                            while (outputHistory.Count > filterSamples)
                                outputHistory.RemoveAt(0);
                            float sum = 0;
                            foreach (float f in outputHistory)
                                sum += f;
                            sum /= filterSamples;

                            if (reverse)
                            {
                                lastDeckPosition -= sum * sensitivity;
                                deckChange -= sum * sensitivity;
                            }
                            else
                            {
                                lastDeckPosition += sum * sensitivity;
                                deckChange += sum * sensitivity;
                            }
                            if (lastDeckPosition < 0.0f)
                                lastDeckPosition += 3.1415f * 2.0f;
                            if (lastDeckPosition < 3.1415f * 2.0f)
                                lastDeckPosition -= 3.1415f * 2.0f;

                            if (lastDeckPosition > highestOutput)
                                highestOutput = lastDeckPosition;
                            if (lastDeckPosition < lowestOutput)
                                lowestOutput = lastDeckPosition;
                        }

                        lastAngle = angle;
                    }



                }


                System.Threading.Thread.Sleep(refreshPeriod);
            }
        }
        int refreshPeriod = 16;

        void parseLoop()
        {
            while (!disposed)
            {
                parseSem.WaitOne();

                lock (toParse)
                {
                    while (toParse.Count >= 4)
                    {
                        byte[] leftVal = toParse.GetRange(0, 2).ToArray();
                        byte[] rightVal = toParse.GetRange(2,2).ToArray();
                        toParse.RemoveRange(0, 4);
                        float l = BitConverter.ToInt16(leftVal, 0) / (float)short.MaxValue;
                        float r = BitConverter.ToInt16(rightVal, 0) / (float)short.MaxValue;
                        lock (displayHistoryLock)
                        {
                            leftDisplayHistory.Add(l);
                            rightDisplayHistory.Add(r);
                        }
                        lock (processHistoryLock)
                        {
                            leftProcessHistory.Add(l);
                            rightProcessHistory.Add(r);
                        }
                    }
                }
            }
        }
        bool disposed = false;
        void readLoop()
        {
            while (!disposed)
            {
                if (currentClient != null)
                {
                Capture:
                    int len = currentClient.AudioCaptureClient.GetNextPacketSize();
                    if (len > 0)
                    {
                        int framesToRead = 0;

                        NAudio.CoreAudioApi.AudioClientBufferFlags flags = NAudio.CoreAudioApi.AudioClientBufferFlags.None;

                        IntPtr i = currentClient.AudioCaptureClient.GetBuffer(out framesToRead, out flags);

                        if (flags != NAudio.CoreAudioApi.AudioClientBufferFlags.None)
                        {

                        }
                        else
                        {
                            byte[] b = new byte[framesToRead*4];


                            System.Runtime.InteropServices.Marshal.Copy(i, b, 0, framesToRead*4);


                            lock (toParse)
                                toParse.AddRange(b);
                            try
                            {
                                parseSem.Release();
                            }
                            catch
                            {
                            }
                        }
                        currentClient.AudioCaptureClient.ReleaseBuffer(framesToRead);

                        goto Capture;
                    }
                }

                System.Threading.Thread.Sleep(1);
            }

        }
        Dictionary<string, NAudio.CoreAudioApi.MMDevice> devices = new Dictionary<string, NAudio.CoreAudioApi.MMDevice>();

        NAudio.CoreAudioApi.AudioClient currentClient = null;

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        Bitmap deckBackBuffer;
        Bitmap signalBackBuffer;
        Graphics deckGraphics;
        Graphics signalGraphics;

        float lastDeckPosition = 0.0f;
        float deckChange = 0.0f;

        Compressor compressor = new Compressor();

        List<float> leftProcessHistory = new List<float>();
        List<float> rightProcessHistory = new List<float>();
        object processHistoryLock = new object();


        List<float> leftDisplayHistory = new List<float>();
        List<float> rightDisplayHistory = new List<float>();
        object displayHistoryLock = new object();

        List<byte> toParse = new List<byte>();
        System.Threading.Semaphore parseSem = new System.Threading.Semaphore(0, int.MaxValue);

        private void renderTimer_Tick(object sender, EventArgs e)
        {
            deckGraphics.Clear(Color.Black);
            deckGraphics.FillEllipse(Brushes.DarkBlue, 0, 0, deckBackBuffer.Width, deckBackBuffer.Height);

            for (float f = lastDeckPosition; f < lastDeckPosition + 0.1f; f += 0.01f)
                deckGraphics.DrawLine(new Pen(Color.Azure,2), new Point(deckBackBuffer.Width / 2, deckBackBuffer.Height / 2), new Point((deckBackBuffer.Width / 2) + (int)(Math.Sin(f) * (deckBackBuffer.Width / 2)), (deckBackBuffer.Height / 2) - (int)(Math.Cos(f) * (deckBackBuffer.Width / 2))));

            signalGraphics.Clear(Color.Black);
            signalGraphics.DrawEllipse(new Pen(Color.Blue, 2), 0, 0, deckBackBuffer.Width, deckBackBuffer.Height);
            List<PointF> toDraw = new List<PointF>();
            lock (displayHistoryLock)
            {
                for (int i = 0; i < leftDisplayHistory.Count && i < rightDisplayHistory.Count && i < 3000; i++)
                    toDraw.Add(new PointF((deckBackBuffer.Width / 2) + (leftDisplayHistory[i] * (deckBackBuffer.Width / 2)), (deckBackBuffer.Height / 2) - (rightDisplayHistory[i] * (deckBackBuffer.Width / 2))));
                leftDisplayHistory.Clear();
                rightDisplayHistory.Clear();
            }
            if(toDraw.Count > 1)
                signalGraphics.DrawLines(new Pen(Color.Azure, 1), toDraw.ToArray());


            deckBox.CreateGraphics().DrawImage(deckBackBuffer, 0, 0);
            signalBox.CreateGraphics().DrawImage(signalBackBuffer, 0, 0);


            if (outputMode == OutputMode.mouseX)
                Cursor.Position = new Point(Cursor.Position.X + (int)(deckChange * 500.0), Cursor.Position.Y);
            if (outputMode == OutputMode.mouseY)
                Cursor.Position = new Point(Cursor.Position.X, Cursor.Position.Y + (int)(deckChange * 500.0));
            if (outputMode == OutputMode.volume)
            {
                if (currentVolumeDevice != null)
                {
                    float f = currentVolumeDevice.AudioEndpointVolume.MasterVolumeLevelScalar;
                    f += deckChange/ (float)Math.PI;
                    if (f > 1.0f)
                        f = 1.0f;
                    if (f < 0.0f)
                        f = 0.0f;
                    currentVolumeDevice.AudioEndpointVolume.MasterVolumeLevelScalar = f;
                }

            }
            if (outputMode == OutputMode.MIDI)
            {
                if (midiOutDevice != null)
                {
                    float z = lastDeckPosition;
                    while (z < 0)
                        z += (float)(Math.PI * 2.0);
                    while (z >= Math.PI * 2.0)
                        z -= (float)(Math.PI * 2.0);
                    byte f = (byte)((z / (Math.PI * 2.0)) * 127);


                    if(midiOutType == MIDIOutType.pitchBend)
                        midiOutDevice.Send(new Sanford.Multimedia.Midi.ChannelMessage(Sanford.Multimedia.Midi.ChannelCommand.PitchWheel, midiOutChannel, 0,f));


                    if (midiOutType == MIDIOutType.channelPressure)
                        midiOutDevice.Send(new Sanford.Multimedia.Midi.ChannelMessage(Sanford.Multimedia.Midi.ChannelCommand.PolyPressure, midiOutChannel, 0, f));
                }
            }
            deckChange = 0.0f;

        }
        private void soundInputBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentClient != null)
            {
                currentClient.Stop();
                currentClient = null;
            }
            if (devices.ContainsKey((string)soundInputBox.SelectedItem))
            {
                currentClient = devices[(string)soundInputBox.SelectedItem].AudioClient;
                currentClient.Initialize(NAudio.CoreAudioApi.AudioClientShareMode.Shared, NAudio.CoreAudioApi.AudioClientStreamFlags.None, 32, 1, new NAudio.Wave.WaveFormat(), System.Guid.Empty);
                currentClient.Start();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            disposed = true;
            if (currentClient != null)
                currentClient.Stop();
            currentClient = null;
            if (midiOutDevice != null)
                midiOutDevice.Dispose();
            midiOutDevice = null;
        }
        bool reverse = false;
        private void reverseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            reverse = reverseCheckBox.Checked;
        }

        int filterSamples = 10;
        private void filterTrackBar_Scroll(object sender, EventArgs e)
        {
            filterSamples = filterTrackBar.Value;
        }

        float sensitivity = 0.5f;
        private void sensitivityTrackBar_Scroll(object sender, EventArgs e)
        {
            sensitivity = sensitivityTrackBar.Value * 0.2f;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            refreshPeriod = (int)Math.Max(1,1000.0f / refreshRateTrackBar.Value);
            renderTimer.Interval = refreshPeriod;
        }

        enum OutputMode
        {
            none,
            mouseX,
            mouseY,
            MIDI,
            volume
        }
        OutputMode outputMode;
        private void outputModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (outputModeComboBox.SelectedIndex == 0)
            {
                outputMode = OutputMode.none;
                midiChannelLabel.Visible = false;
                midiChannelInput.Visible = false;
                outputDeviceComboBox.Visible = false;
                outputDeviceLabel.Visible = false;
                midiCommandInputBox.Visible = false;
                midiCommandLabel.Visible = false;

            }
            if (outputModeComboBox.SelectedIndex == 1)
            {
                outputMode = OutputMode.mouseX;
                midiChannelLabel.Visible = false;
                midiChannelInput.Visible = false;
                outputDeviceComboBox.Visible = false;
                outputDeviceLabel.Visible = false;
                midiCommandInputBox.Visible = false;
                midiCommandLabel.Visible = false;
            }
            if (outputModeComboBox.SelectedIndex == 2)
            {
                outputMode = OutputMode.mouseY;
                midiChannelLabel.Visible = false;
                midiChannelInput.Visible = false;
                outputDeviceComboBox.Visible = false;
                outputDeviceLabel.Visible = false;
                midiCommandInputBox.Visible = false;
                midiCommandLabel.Visible = false;
            }
            if (outputModeComboBox.SelectedIndex == 3)
            {
                outputMode = OutputMode.MIDI;
                midiChannelLabel.Visible = true;
                midiChannelInput.Visible = true;
                outputDeviceComboBox.Visible = true;
                outputDeviceLabel.Visible = true;
                midiCommandInputBox.Visible = true;
                midiCommandLabel.Visible = true;

                outputDeviceComboBox.Items.Clear();
                for (int i = 0; i < Sanford.Multimedia.Midi.OutputDevice.DeviceCount; i++)
                    outputDeviceComboBox.Items.Add(Sanford.Multimedia.Midi.OutputDevice.GetDeviceCapabilities(i).name);
                if(outputDeviceComboBox.Items.Count > 0)
                    outputDeviceComboBox.SelectedIndex = 0;
                midiCommandInputBox.SelectedIndex = 0;
            }
            if (outputModeComboBox.SelectedIndex == 4)
            {
                outputMode = OutputMode.volume;
                midiChannelLabel.Visible = false;
                midiChannelInput.Visible = false;
                outputDeviceComboBox.Visible = true;
                outputDeviceLabel.Visible = true;
                midiCommandInputBox.Visible = false;
                midiCommandLabel.Visible = false;
                outputDeviceComboBox.Items.Clear();

                string def = "";
                NAudio.CoreAudioApi.MMDeviceEnumerator en = new NAudio.CoreAudioApi.MMDeviceEnumerator();
                foreach (NAudio.CoreAudioApi.MMDevice m in en.EnumerateAudioEndPoints(NAudio.CoreAudioApi.DataFlow.Render, NAudio.CoreAudioApi.DeviceState.Active))
                {
                    outputDeviceComboBox.Items.Add(m.DeviceFriendlyName + " " + m.FriendlyName);
                    if (m.ID == en.GetDefaultAudioEndpoint(NAudio.CoreAudioApi.DataFlow.Render, NAudio.CoreAudioApi.Role.Multimedia).ID)
                        def = m.DeviceFriendlyName + " " + m.FriendlyName;
                }
                outputDeviceComboBox.SelectedItem = def;
            }
        }
        int midiOutChannel = 0;
        MIDIOutType midiOutType = MIDIOutType.pitchBend;
        Sanford.Multimedia.Midi.OutputDevice midiOutDevice = null;
        enum MIDIOutType
        {
            channelPressure,
            pitchBend

        }
        NAudio.CoreAudioApi.MMDevice currentVolumeDevice;
        private void outputDeviceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (outputMode == OutputMode.volume)
            {
                NAudio.CoreAudioApi.MMDeviceEnumerator en = new NAudio.CoreAudioApi.MMDeviceEnumerator();
                foreach (NAudio.CoreAudioApi.MMDevice m in en.EnumerateAudioEndPoints(NAudio.CoreAudioApi.DataFlow.Render, NAudio.CoreAudioApi.DeviceState.Active))
                    if (m.DeviceFriendlyName + " " + m.FriendlyName == outputDeviceComboBox.Text)
                        currentVolumeDevice = m;
            }
            if (outputMode == OutputMode.MIDI)
            {
                if (midiOutDevice != null)
                    midiOutDevice.Dispose();
                midiOutDevice = null;

                if (Sanford.Multimedia.Midi.OutputDevice.GetDeviceCapabilities(outputDeviceComboBox.SelectedIndex).name == (string)outputDeviceComboBox.SelectedItem)
                    midiOutDevice = new Sanford.Multimedia.Midi.OutputDevice(outputDeviceComboBox.SelectedIndex);
                else
                    for (int i = 0; i < Sanford.Multimedia.Midi.OutputDevice.DeviceCount; i++)
                        if (Sanford.Multimedia.Midi.OutputDevice.GetDeviceCapabilities(i).name == (string)outputDeviceComboBox.SelectedItem)
                        {
                            midiOutDevice = new Sanford.Multimedia.Midi.OutputDevice(i);
                            break;
                        }
            }
        }

        private void midiChannelInput_ValueChanged(object sender, EventArgs e)
        {
            midiOutChannel = (int)midiChannelInput.Value;
        }

        private void midiCommandInputBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (midiCommandInputBox.SelectedIndex == 0)
                midiOutType = MIDIOutType.channelPressure;
            if (midiCommandInputBox.SelectedIndex == 1)
                midiOutType = MIDIOutType.pitchBend;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm f = new AboutForm();
            f.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
