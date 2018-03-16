namespace Dex
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.triggerLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.soundInputBox = new System.Windows.Forms.ComboBox();
            this.deckBox = new System.Windows.Forms.Panel();
            this.signalBox = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.reverseCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.refreshRateTrackBar = new System.Windows.Forms.TrackBar();
            this.label8 = new System.Windows.Forms.Label();
            this.sensitivityTrackBar = new System.Windows.Forms.TrackBar();
            this.filterTrackBar = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.midiCommandInputBox = new System.Windows.Forms.ComboBox();
            this.midiCommandLabel = new System.Windows.Forms.Label();
            this.midiChannelInput = new System.Windows.Forms.NumericUpDown();
            this.midiChannelLabel = new System.Windows.Forms.Label();
            this.outputDeviceComboBox = new System.Windows.Forms.ComboBox();
            this.outputDeviceLabel = new System.Windows.Forms.Label();
            this.outputModeComboBox = new System.Windows.Forms.ComboBox();
            this.outputModeLabel = new System.Windows.Forms.Label();
            this.renderTimer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refreshRateTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sensitivityTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterTrackBar)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.midiChannelInput)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Dex";
            this.notifyIcon.Visible = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(315, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.triggerLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 448);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(315, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // triggerLabel
            // 
            this.triggerLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.triggerLabel.Name = "triggerLabel";
            this.triggerLabel.Size = new System.Drawing.Size(34, 17);
            this.triggerLabel.Text = "MIDI";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Sound Input:";
            // 
            // soundInputBox
            // 
            this.soundInputBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.soundInputBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.soundInputBox.FormattingEnabled = true;
            this.soundInputBox.Location = new System.Drawing.Point(76, 26);
            this.soundInputBox.Name = "soundInputBox";
            this.soundInputBox.Size = new System.Drawing.Size(235, 21);
            this.soundInputBox.TabIndex = 4;
            this.soundInputBox.SelectedIndexChanged += new System.EventHandler(this.soundInputBox_SelectedIndexChanged);
            // 
            // deckBox
            // 
            this.deckBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.deckBox.Location = new System.Drawing.Point(5, 53);
            this.deckBox.Name = "deckBox";
            this.deckBox.Size = new System.Drawing.Size(150, 150);
            this.deckBox.TabIndex = 5;
            // 
            // signalBox
            // 
            this.signalBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.signalBox.Location = new System.Drawing.Point(161, 53);
            this.signalBox.Name = "signalBox";
            this.signalBox.Size = new System.Drawing.Size(150, 150);
            this.signalBox.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Sensitivity:";
            // 
            // reverseCheckBox
            // 
            this.reverseCheckBox.AutoSize = true;
            this.reverseCheckBox.Location = new System.Drawing.Point(232, 90);
            this.reverseCheckBox.Name = "reverseCheckBox";
            this.reverseCheckBox.Size = new System.Drawing.Size(66, 17);
            this.reverseCheckBox.TabIndex = 8;
            this.reverseCheckBox.Text = "Reverse";
            this.reverseCheckBox.UseVisualStyleBackColor = true;
            this.reverseCheckBox.CheckedChanged += new System.EventHandler(this.reverseCheckBox_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.refreshRateTrackBar);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.sensitivityTrackBar);
            this.groupBox1.Controls.Add(this.filterTrackBar);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.reverseCheckBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(5, 206);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(306, 111);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Processing";
            // 
            // refreshRateTrackBar
            // 
            this.refreshRateTrackBar.AutoSize = false;
            this.refreshRateTrackBar.Location = new System.Drawing.Point(79, 61);
            this.refreshRateTrackBar.Maximum = 1000;
            this.refreshRateTrackBar.Minimum = 1;
            this.refreshRateTrackBar.Name = "refreshRateTrackBar";
            this.refreshRateTrackBar.Size = new System.Drawing.Size(219, 13);
            this.refreshRateTrackBar.TabIndex = 13;
            this.refreshRateTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.refreshRateTrackBar.Value = 100;
            this.refreshRateTrackBar.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Refresh Rate:";
            // 
            // sensitivityTrackBar
            // 
            this.sensitivityTrackBar.AutoSize = false;
            this.sensitivityTrackBar.Location = new System.Drawing.Point(79, 39);
            this.sensitivityTrackBar.Minimum = 1;
            this.sensitivityTrackBar.Name = "sensitivityTrackBar";
            this.sensitivityTrackBar.Size = new System.Drawing.Size(219, 13);
            this.sensitivityTrackBar.TabIndex = 11;
            this.sensitivityTrackBar.Value = 5;
            this.sensitivityTrackBar.Scroll += new System.EventHandler(this.sensitivityTrackBar_Scroll);
            // 
            // filterTrackBar
            // 
            this.filterTrackBar.AutoSize = false;
            this.filterTrackBar.Location = new System.Drawing.Point(79, 18);
            this.filterTrackBar.Maximum = 30;
            this.filterTrackBar.Minimum = 1;
            this.filterTrackBar.Name = "filterTrackBar";
            this.filterTrackBar.Size = new System.Drawing.Size(219, 13);
            this.filterTrackBar.TabIndex = 10;
            this.filterTrackBar.Value = 10;
            this.filterTrackBar.Scroll += new System.EventHandler(this.filterTrackBar_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Filter:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.midiCommandInputBox);
            this.groupBox2.Controls.Add(this.midiCommandLabel);
            this.groupBox2.Controls.Add(this.midiChannelInput);
            this.groupBox2.Controls.Add(this.midiChannelLabel);
            this.groupBox2.Controls.Add(this.outputDeviceComboBox);
            this.groupBox2.Controls.Add(this.outputDeviceLabel);
            this.groupBox2.Controls.Add(this.outputModeComboBox);
            this.groupBox2.Controls.Add(this.outputModeLabel);
            this.groupBox2.Location = new System.Drawing.Point(5, 323);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(306, 122);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output";
            // 
            // midiCommandInputBox
            // 
            this.midiCommandInputBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.midiCommandInputBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.midiCommandInputBox.FormattingEnabled = true;
            this.midiCommandInputBox.Items.AddRange(new object[] {
            "Channel Pressure",
            "Pitch Bend"});
            this.midiCommandInputBox.Location = new System.Drawing.Point(87, 87);
            this.midiCommandInputBox.Name = "midiCommandInputBox";
            this.midiCommandInputBox.Size = new System.Drawing.Size(213, 21);
            this.midiCommandInputBox.TabIndex = 11;
            this.midiCommandInputBox.SelectedIndexChanged += new System.EventHandler(this.midiCommandInputBox_SelectedIndexChanged);
            // 
            // midiCommandLabel
            // 
            this.midiCommandLabel.AutoSize = true;
            this.midiCommandLabel.Location = new System.Drawing.Point(6, 91);
            this.midiCommandLabel.Name = "midiCommandLabel";
            this.midiCommandLabel.Size = new System.Drawing.Size(83, 13);
            this.midiCommandLabel.TabIndex = 10;
            this.midiCommandLabel.Text = "MIDI Command:";
            // 
            // midiChannelInput
            // 
            this.midiChannelInput.Location = new System.Drawing.Point(87, 64);
            this.midiChannelInput.Name = "midiChannelInput";
            this.midiChannelInput.Size = new System.Drawing.Size(50, 20);
            this.midiChannelInput.TabIndex = 9;
            this.midiChannelInput.ValueChanged += new System.EventHandler(this.midiChannelInput_ValueChanged);
            // 
            // midiChannelLabel
            // 
            this.midiChannelLabel.AutoSize = true;
            this.midiChannelLabel.Location = new System.Drawing.Point(13, 67);
            this.midiChannelLabel.Name = "midiChannelLabel";
            this.midiChannelLabel.Size = new System.Drawing.Size(75, 13);
            this.midiChannelLabel.TabIndex = 8;
            this.midiChannelLabel.Text = "MIDI Channel:";
            // 
            // outputDeviceComboBox
            // 
            this.outputDeviceComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.outputDeviceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.outputDeviceComboBox.FormattingEnabled = true;
            this.outputDeviceComboBox.Location = new System.Drawing.Point(87, 41);
            this.outputDeviceComboBox.Name = "outputDeviceComboBox";
            this.outputDeviceComboBox.Size = new System.Drawing.Size(213, 21);
            this.outputDeviceComboBox.TabIndex = 7;
            this.outputDeviceComboBox.SelectedIndexChanged += new System.EventHandler(this.outputDeviceComboBox_SelectedIndexChanged);
            // 
            // outputDeviceLabel
            // 
            this.outputDeviceLabel.AutoSize = true;
            this.outputDeviceLabel.Location = new System.Drawing.Point(9, 44);
            this.outputDeviceLabel.Name = "outputDeviceLabel";
            this.outputDeviceLabel.Size = new System.Drawing.Size(79, 13);
            this.outputDeviceLabel.TabIndex = 6;
            this.outputDeviceLabel.Text = "Output Device:";
            // 
            // outputModeComboBox
            // 
            this.outputModeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.outputModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.outputModeComboBox.FormattingEnabled = true;
            this.outputModeComboBox.Items.AddRange(new object[] {
            "None",
            "Mouse Left-Right",
            "Mouse Up-Down",
            "MIDI",
            "Sound Device Volume"});
            this.outputModeComboBox.Location = new System.Drawing.Point(87, 17);
            this.outputModeComboBox.Name = "outputModeComboBox";
            this.outputModeComboBox.Size = new System.Drawing.Size(213, 21);
            this.outputModeComboBox.TabIndex = 5;
            this.outputModeComboBox.SelectedIndexChanged += new System.EventHandler(this.outputModeComboBox_SelectedIndexChanged);
            // 
            // outputModeLabel
            // 
            this.outputModeLabel.AutoSize = true;
            this.outputModeLabel.Location = new System.Drawing.Point(14, 20);
            this.outputModeLabel.Name = "outputModeLabel";
            this.outputModeLabel.Size = new System.Drawing.Size(72, 13);
            this.outputModeLabel.TabIndex = 0;
            this.outputModeLabel.Text = "Output Mode:";
            // 
            // renderTimer
            // 
            this.renderTimer.Enabled = true;
            this.renderTimer.Interval = 1;
            this.renderTimer.Tick += new System.EventHandler(this.renderTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 470);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.signalBox);
            this.Controls.Add(this.deckBox);
            this.Controls.Add(this.soundInputBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Dex";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.refreshRateTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sensitivityTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterTrackBar)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.midiChannelInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel triggerLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox soundInputBox;
        private System.Windows.Forms.Panel deckBox;
        private System.Windows.Forms.Panel signalBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox reverseCheckBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TrackBar sensitivityTrackBar;
        private System.Windows.Forms.TrackBar filterTrackBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox outputModeComboBox;
        private System.Windows.Forms.Label outputModeLabel;
        private System.Windows.Forms.ComboBox midiCommandInputBox;
        private System.Windows.Forms.Label midiCommandLabel;
        private System.Windows.Forms.NumericUpDown midiChannelInput;
        private System.Windows.Forms.Label midiChannelLabel;
        private System.Windows.Forms.ComboBox outputDeviceComboBox;
        private System.Windows.Forms.Label outputDeviceLabel;
        private System.Windows.Forms.Timer renderTimer;
        private System.Windows.Forms.TrackBar refreshRateTrackBar;
        private System.Windows.Forms.Label label8;
    }
}

