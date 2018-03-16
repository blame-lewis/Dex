using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Dex
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void websiteButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.prolapsoft.com");
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            versionLabel.Text = "Version " + Application.ProductVersion;
            this.Text = "Dex v" + Application.ProductVersion;
        }
    }
}
