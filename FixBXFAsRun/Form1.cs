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
                // make sure Source path does end in /
                if (!tbSourceDirectory.Text.EndsWith(@"\")) tbSourceDirectory.Text += @"\";

                richTextBox1.Text = "Starting directory scan for files\r\n";
                string[] array2 = Directory.GetFiles(tbSourceDirectory.Text, "*.xml");
                lCurrentFileNum = 0;

                foreach (string strTemp in array2)
                {
                    //Read Date and Time for Compute and Modify
                    dtDeDate = getDateTimeFromXML(strTemp);
                    // if the dtDeDate returned a good value it would be less than now
                    if (dtDeDate<DateTime.Now)
                    {
                        richTextBox1.Text += "Date time" + dtDeDate.ToString("yyyy-MM-ddThhmmssZ") + "for file" + strTemp + "\r\n";
                        if (!moveFile2Rejected(strTemp))
                        {
                            richTextBox1.Text += "Error: moving file\r\n";
                            continue;
                        }
                        // file is fixed in rejection folder
                        if(fixDateTime(dtDeDate,strTemp)){
                            // if fix is good move from the rejection folder to destination folder
                            string strRejection;
                            strRejection = tbRejected.Text + Path.GetFileName(strTemp);
                            if (!moveFile2Destination(strRejection))
                            {
                                richTextBox1.Text += "Error: Problem moving to destination\r\n";
                                continue;
                            }                    
                        } else {
                            richTextBox1.Text += "Error: Problem fixing date \r\n";
                            continue;
                        }
                    }
                    else
                    {
                        richTextBox1.Text += "Error: Reading Date in file \r\n";
                        continue;
                    }
                    lCurrentFileNum++;
                }
                richTextBox1.Text += "The number of XML files in direcotry is:" + lCurrentFileNum.ToString() + "\r\n";
            }
            catch (Exception exp)
            {
                label3.Text = exp.Message;
            }
        }

        private bool fixDateTime(DateTime dtIncoming,string strIncoming)
        { 
            // remember the strIncoming is after moving file to rejected folder
            string strNewPath = tbRejected.Text + Path.GetFileName(strIncoming);
            XmlDocument doc = new XmlDocument();
            try // catching null nodes
            {
                doc.Load(strNewPath);
                // our BXF ASRuns use a Smpte name space, has to get out on the web
                var nsmgr = new XmlNamespaceManager(doc.NameTable);
                nsmgr.AddNamespace("deBXF", "http://smpte-ra.org/schemas/2021/2008/BXF");
                XmlNode xmlNde = doc.DocumentElement.SelectSingleNode("//deBXF:Schedule", nsmgr);
                if (xmlNde != null)
                {
                    // writing start if checked
                    if(cbSchedStart.Checked) xmlNde.Attributes["scheduleStart"].Value = dtIncoming.ToString("yyyy-MM-ddThhmmssZ");
                    DateTime dtEnd =  dtIncoming.AddDays(1.0);
                    // writing end if checked
                    if (cbSchedEnd.Checked) xmlNde.Attributes["scheduleEnd"].Value = dtEnd.ToString("yyyy-MM-ddThhmmssZ");
                }
                if (cbWriteStart.Checked)
                {
                    XmlNode xmlNdeBXF = doc.DocumentElement.SelectSingleNode("//deBXF:BxfMessage", nsmgr);
                    if(xmlNdeBXF!= null)
                    {
                        DateTime dtEnd = dtIncoming.AddDays(1.0);
                        xmlNdeBXF.Attributes["dateTime"].Value = dtEnd.ToString("yyyy-MM-ddThhmmssZ");
                    }
                }
                doc.Save(strNewPath);
            }
            catch
            {
                return false;
            }
            return true;
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
                    if (cbHourFromFile.Checked)
                    {
                        // this is formula for get hour from node
                        string strTemp = xmlNde.Attributes["broadcastDate"].Value + " " + xmlNde.InnerText.ToString().Substring(0, 2) + ":00:00";
                        richTextBox1.Text += strTemp + "\r\n";
                        dtReturn = DateTime.ParseExact(strTemp, "yyyy-MM-dd hh:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None);
                    }
                    else
                    {
                        string strTemp;
                        // this is formula for uses hour entered in form
                        if (tbHour.ToString().Length == 2)
                        {
                            strTemp = xmlNde.Attributes["broadcastDate"].Value + " " + tbHour.ToString() + ":00:00";
                        }
                        else if (tbHour.ToString().Length == 1)
                        {
                            strTemp = xmlNde.Attributes["broadcastDate"].Value + " 0" + tbHour.ToString() + ":00:00";
                        }
                        else
                        {
                            strTemp = xmlNde.Attributes["broadcastDate"].Value + " 08:00:00";
                        }
                        richTextBox1.Text += strTemp + "\r\n";
                        dtReturn = DateTime.ParseExact(strTemp, "yyyy-MM-dd hh:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None);

                    }
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
        private bool moveFile2Rejected(string strInfile)
        {
            // make sure rejected path does end in /
            if(!tbRejected.Text.EndsWith(@"\"))tbRejected.Text+=@"\";
            // make sure file doesn't exist
            string strTempPath;
            strTempPath = tbRejected.Text + Path.GetFileName(strInfile);
            if(File.Exists(strTempPath))File.Delete(strTempPath);
            try
            {
                File.Move(strInfile, strTempPath);
            }
            catch
            {
                return false;
            }
            return true;
        }

        private bool moveFile2Destination(string strInFile)
        {
            // make sure Destination path does end in /
            if (!tbDestinationDirectory.Text.EndsWith(@"\")) tbDestinationDirectory.Text += @"\";
            // make sure file doesn't exist
            string strTempPath = tbDestinationDirectory.Text + Path.GetFileName(strInFile);
            if(File.Exists(strTempPath))File.Delete(strTempPath);
            try
            {
                File.Move(strInFile, strTempPath);
            }
            catch
            {
                return false;
            }
            return true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
