using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FixBXFAsRun
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            tbSourceDirectory.Text = Properties.Settings.Default.SourceDir;
            tbDestinationDirectory.Text = Properties.Settings.Default.DestinationDir;
            tbRejected.Text = Properties.Settings.Default.RejectedDir;
            tbMilliseconds.Text = Properties.Settings.Default.Milliseconds.ToString();
 
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.SourceDir = tbSourceDirectory.Text;
            Properties.Settings.Default.DestinationDir = tbDestinationDirectory.Text;
            Properties.Settings.Default.RejectedDir = tbRejected.Text;
            Properties.Settings.Default.Milliseconds = int.Parse(tbMilliseconds.Text);
            Properties.Settings.Default.Save();
        }
    }
}
