namespace FixBXFAsRun
{
    partial class Form1
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
            this.label7 = new System.Windows.Forms.Label();
            this.tbMilliseconds = new System.Windows.Forms.TextBox();
            this.tbDestinationDirectory = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSourceDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbRejected = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tbHour = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbHourFromFile = new System.Windows.Forms.CheckBox();
            this.cbWriteStart = new System.Windows.Forms.CheckBox();
            this.cbSchedStart = new System.Windows.Forms.CheckBox();
            this.cbSchedEnd = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Sleep Millisconds next restart";
            // 
            // tbMilliseconds
            // 
            this.tbMilliseconds.Location = new System.Drawing.Point(15, 171);
            this.tbMilliseconds.Name = "tbMilliseconds";
            this.tbMilliseconds.Size = new System.Drawing.Size(131, 20);
            this.tbMilliseconds.TabIndex = 14;
            // 
            // tbDestinationDirectory
            // 
            this.tbDestinationDirectory.Location = new System.Drawing.Point(15, 68);
            this.tbDestinationDirectory.Name = "tbDestinationDirectory";
            this.tbDestinationDirectory.Size = new System.Drawing.Size(395, 20);
            this.tbDestinationDirectory.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Destination Directory";
            // 
            // tbSourceDirectory
            // 
            this.tbSourceDirectory.Location = new System.Drawing.Point(15, 25);
            this.tbSourceDirectory.Name = "tbSourceDirectory";
            this.tbSourceDirectory.Size = new System.Drawing.Size(395, 20);
            this.tbSourceDirectory.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Soure Directory";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Rejection Directory";
            // 
            // tbRejected
            // 
            this.tbRejected.Location = new System.Drawing.Point(15, 117);
            this.tbRejected.Name = "tbRejected";
            this.tbRejected.Size = new System.Drawing.Size(395, 20);
            this.tbRejected.TabIndex = 12;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(17, 241);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(393, 94);
            this.richTextBox1.TabIndex = 17;
            this.richTextBox1.Text = "";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tbHour
            // 
            this.tbHour.Location = new System.Drawing.Point(173, 171);
            this.tbHour.MaxLength = 2;
            this.tbHour.Name = "tbHour";
            this.tbHour.Size = new System.Drawing.Size(54, 20);
            this.tbHour.TabIndex = 14;
            this.tbHour.Text = "8";
            this.tbHour.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(172, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Start Hour";
            // 
            // cbHourFromFile
            // 
            this.cbHourFromFile.AutoSize = true;
            this.cbHourFromFile.Location = new System.Drawing.Point(257, 160);
            this.cbHourFromFile.Name = "cbHourFromFile";
            this.cbHourFromFile.Size = new System.Drawing.Size(153, 17);
            this.cbHourFromFile.TabIndex = 18;
            this.cbHourFromFile.Text = "compute start hour from file";
            this.cbHourFromFile.UseVisualStyleBackColor = true;
            // 
            // cbWriteStart
            // 
            this.cbWriteStart.AutoSize = true;
            this.cbWriteStart.Location = new System.Drawing.Point(17, 209);
            this.cbWriteStart.Name = "cbWriteStart";
            this.cbWriteStart.Size = new System.Drawing.Size(154, 17);
            this.cbWriteStart.TabIndex = 19;
            this.cbWriteStart.Text = "Write BXF Msg  Date/Time";
            this.cbWriteStart.UseVisualStyleBackColor = true;
            // 
            // cbSchedStart
            // 
            this.cbSchedStart.AutoSize = true;
            this.cbSchedStart.Location = new System.Drawing.Point(174, 209);
            this.cbSchedStart.Name = "cbSchedStart";
            this.cbSchedStart.Size = new System.Drawing.Size(115, 17);
            this.cbSchedStart.TabIndex = 19;
            this.cbSchedStart.Text = "Set Schedule Start";
            this.cbSchedStart.UseVisualStyleBackColor = true;
            // 
            // cbSchedEnd
            // 
            this.cbSchedEnd.AutoSize = true;
            this.cbSchedEnd.Location = new System.Drawing.Point(295, 209);
            this.cbSchedEnd.Name = "cbSchedEnd";
            this.cbSchedEnd.Size = new System.Drawing.Size(112, 17);
            this.cbSchedEnd.TabIndex = 19;
            this.cbSchedEnd.Text = "Set Schedule End";
            this.cbSchedEnd.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(274, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Not always accurate";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(274, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "hour is from first event.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 347);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbSchedEnd);
            this.Controls.Add(this.cbSchedStart);
            this.Controls.Add(this.cbWriteStart);
            this.Controls.Add(this.cbHourFromFile);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbHour);
            this.Controls.Add(this.tbMilliseconds);
            this.Controls.Add(this.tbRejected);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbDestinationDirectory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbSourceDirectory);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "FixBXFAsRun";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbMilliseconds;
        private System.Windows.Forms.TextBox tbDestinationDirectory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSourceDirectory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbRejected;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox tbHour;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbHourFromFile;
        private System.Windows.Forms.CheckBox cbWriteStart;
        private System.Windows.Forms.CheckBox cbSchedStart;
        private System.Windows.Forms.CheckBox cbSchedEnd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

