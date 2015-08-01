using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
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
            tbHour.Text = Properties.Settings.Default.Hour.ToString();
            cbHourFromFile.Checked = Properties.Settings.Default.Compute;
            cbWriteStart.Checked = Properties.Settings.Default.WriteStart;
            cbSchedStart.Checked = Properties.Settings.Default.SchedStart;
            cbSchedEnd.Checked = Properties.Settings.Default.SchedEnd;
            timer1.Interval = Properties.Settings.Default.Milliseconds;
            timer1.Start();
 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // geting list of xml files in source directory
            long lCurrentFileNum;
            DateTime dtDeDate;
            try
            {
                richTextBox1.Text = "Starting directory scan for files\r\n";
                string[] array2 = Directory.GetFiles(tbSourceDirectory.Text, "*.xml");
                lCurrentFileNum = 0;

                foreach (string strTemp in array2)
                {
                    //Read Date and Time for Compute and Modify
                    dtDeDate = getDateTimeFromXML(strTemp);
                    lCurrentFileNum++;
                }
                richTextBox1.Text += "The number of XML files in direcotry is:" + lCurrentFileNum.ToString() + "\r\n";
            }
            catch (Exception exp)
            {
                label3.Text = exp.Message;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.SourceDir = tbSourceDirectory.Text;
            Properties.Settings.Default.DestinationDir = tbDestinationDirectory.Text;
            Properties.Settings.Default.RejectedDir = tbRejected.Text;
            Properties.Settings.Default.Milliseconds = int.Parse(tbMilliseconds.Text);
            Properties.Settings.Default.Compute = cbHourFromFile.Checked;
            Properties.Settings.Default.WriteStart = cbWriteStart.Checked;
            Properties.Settings.Default.SchedStart = cbSchedStart.Checked;
            Properties.Settings.Default.SchedEnd = cbSchedEnd.Checked;
            Properties.Settings.Default.Save();
        }

        private DateTime getDateTimeFromXML(string strInFile)
        {
            DateTime dtReturn;
            // set default to 20 years in the future, if not properly reset below this fails function
            dtReturn = DateTime.Now.AddYears(20);
            XmlDocument doc = new XmlDocument();
            doc.Load(strInFile);
            try // catching null nodes
            {
                // our BXF ASRuns use a Smpte name space, has to get out on the web
                var nsmgr = new XmlNamespaceManager(doc.NameTable);
                nsmgr.AddNamespace("deBXF", "http://smpte-ra.org/schemas/2021/2008/BXF");
                XmlNode xmlNde = doc.DocumentElement.SelectSingleNode("//deBXF:SmpteDateTime",nsmgr);
                if (xmlNde != null)
                {
                    // getting date in form yyyyMMdd from broadcastDate attribute, getting hour as hh from first 2 characters of InnerText
                    string strTemp = xmlNde.Attributes["broadcastDate"].Value + " " + xmlNde.InnerText.ToString().Substring(0, 2)+":00:00";
                    richTextBox1.Text += strTemp + "\r\n";
                    dtReturn = DateTime.ParseExact(strTemp, "yyyy-MM-dd hh:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None);
                }
                else { richTextBox1.Text += "Error couldn't find node\r\n"; }
                doc.Save(strInFile);
            }
            catch (Exception e)
            {
                richTextBox1.Text += e.Message;

            }
            return dtReturn;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
