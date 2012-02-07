/******************************************************************************************
 * 
 * Copyright (c) 2012 WU WAI FAN DENNIS
 * 
 * 
 * Permission is hereby granted, free of charge, to any person obtaining 
 * a copy of this software and associated documentation files (the "Software"), 
 * to deal in the Software without restriction, including without limitation 
 * the rights to use, copy, modify, merge, publish, distribute, sublicense, 
 * and/or sell copies of the Software, and to permit persons to whom the Software 
 * is furnished to do so, subject to the following conditions:
 * 
 * 
 * The above copyright notice and this permission notice shall be included in 
 * all copies or substantial portions of the Software.
 * 
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS 
 * FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR 
 * COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN 
 * AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
 * WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 * 
******************************************************************************************/

namespace Interaction.Graph
{
    partial class frmWizard
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
            this.lblMonth = new System.Windows.Forms.Label();
            this.lbldom = new System.Windows.Forms.Label();
            this.lbldow = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.txtHour1 = new System.Windows.Forms.NumericUpDown();
            this.txtMin1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMin2 = new System.Windows.Forms.NumericUpDown();
            this.txtHour2 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMon2 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMon1 = new System.Windows.Forms.NumericUpDown();
            this.cboWeek1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboWeek2 = new System.Windows.Forms.ComboBox();
            this.cboMon2 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboMon1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtHour1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMin1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMin2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHour2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMon2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMon1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(6, 116);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(48, 13);
            this.lblMonth.TabIndex = 31;
            this.lblMonth.Text = "Months :";
            // 
            // lbldom
            // 
            this.lbldom.AutoSize = true;
            this.lbldom.Location = new System.Drawing.Point(6, 84);
            this.lbldom.Name = "lbldom";
            this.lbldom.Size = new System.Drawing.Size(77, 13);
            this.lbldom.TabIndex = 29;
            this.lbldom.Text = "Day of Month :";
            // 
            // lbldow
            // 
            this.lbldow.AutoSize = true;
            this.lbldow.Location = new System.Drawing.Point(6, 49);
            this.lbldow.Name = "lbldow";
            this.lbldow.Size = new System.Drawing.Size(76, 13);
            this.lbldow.TabIndex = 27;
            this.lbldow.Text = "Day of Week :";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(6, 14);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(71, 13);
            this.lblTime.TabIndex = 23;
            this.lblTime.Text = "Time Range :";
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(239, 149);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 26;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOK.Location = new System.Drawing.Point(158, 149);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 25;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // txtHour1
            // 
            this.txtHour1.Enabled = false;
            this.txtHour1.Location = new System.Drawing.Point(89, 11);
            this.txtHour1.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.txtHour1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.txtHour1.Name = "txtHour1";
            this.txtHour1.Size = new System.Drawing.Size(47, 20);
            this.txtHour1.TabIndex = 32;
            this.txtHour1.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // txtMin1
            // 
            this.txtMin1.Enabled = false;
            this.txtMin1.Location = new System.Drawing.Point(147, 11);
            this.txtMin1.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.txtMin1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.txtMin1.Name = "txtMin1";
            this.txtMin1.Size = new System.Drawing.Size(47, 20);
            this.txtMin1.TabIndex = 33;
            this.txtMin1.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(135, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = ":";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(195, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "-";
            // 
            // txtMin2
            // 
            this.txtMin2.Enabled = false;
            this.txtMin2.Location = new System.Drawing.Point(267, 12);
            this.txtMin2.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.txtMin2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.txtMin2.Name = "txtMin2";
            this.txtMin2.Size = new System.Drawing.Size(47, 20);
            this.txtMin2.TabIndex = 37;
            this.txtMin2.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // txtHour2
            // 
            this.txtHour2.Enabled = false;
            this.txtHour2.Location = new System.Drawing.Point(207, 12);
            this.txtHour2.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.txtHour2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.txtHour2.Name = "txtHour2";
            this.txtHour2.Size = new System.Drawing.Size(47, 20);
            this.txtHour2.TabIndex = 36;
            this.txtHour2.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(255, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = ":";
            // 
            // txtMon2
            // 
            this.txtMon2.Enabled = false;
            this.txtMon2.Location = new System.Drawing.Point(149, 83);
            this.txtMon2.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.txtMon2.Name = "txtMon2";
            this.txtMon2.Size = new System.Drawing.Size(47, 20);
            this.txtMon2.TabIndex = 41;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(135, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "-";
            // 
            // txtMon1
            // 
            this.txtMon1.Enabled = false;
            this.txtMon1.Location = new System.Drawing.Point(89, 82);
            this.txtMon1.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.txtMon1.Name = "txtMon1";
            this.txtMon1.Size = new System.Drawing.Size(47, 20);
            this.txtMon1.TabIndex = 39;
            // 
            // cboWeek1
            // 
            this.cboWeek1.Enabled = false;
            this.cboWeek1.FormattingEnabled = true;
            this.cboWeek1.Items.AddRange(new object[] {
            "",
            "sun",
            "mon",
            "tue",
            "wed",
            "thu",
            "fri",
            "sat"});
            this.cboWeek1.Location = new System.Drawing.Point(89, 46);
            this.cboWeek1.Name = "cboWeek1";
            this.cboWeek1.Size = new System.Drawing.Size(56, 21);
            this.cboWeek1.TabIndex = 42;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(146, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 13);
            this.label5.TabIndex = 43;
            this.label5.Text = "-";
            // 
            // cboWeek2
            // 
            this.cboWeek2.Enabled = false;
            this.cboWeek2.FormattingEnabled = true;
            this.cboWeek2.Items.AddRange(new object[] {
            "",
            "sun",
            "mon",
            "tue",
            "wed",
            "thu",
            "fri",
            "sat"});
            this.cboWeek2.Location = new System.Drawing.Point(159, 46);
            this.cboWeek2.Name = "cboWeek2";
            this.cboWeek2.Size = new System.Drawing.Size(56, 21);
            this.cboWeek2.TabIndex = 44;
            // 
            // cboMon2
            // 
            this.cboMon2.Enabled = false;
            this.cboMon2.FormattingEnabled = true;
            this.cboMon2.Items.AddRange(new object[] {
            "",
            "jan",
            "feb",
            "mar",
            "apr",
            "may",
            "jun",
            "jul",
            "aug",
            "sep",
            "oct",
            "nov",
            "dec"});
            this.cboMon2.Location = new System.Drawing.Point(159, 113);
            this.cboMon2.Name = "cboMon2";
            this.cboMon2.Size = new System.Drawing.Size(56, 21);
            this.cboMon2.TabIndex = 47;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(146, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(10, 13);
            this.label6.TabIndex = 46;
            this.label6.Text = "-";
            // 
            // cboMon1
            // 
            this.cboMon1.Enabled = false;
            this.cboMon1.FormattingEnabled = true;
            this.cboMon1.Items.AddRange(new object[] {
            "",
            "jan",
            "feb",
            "mar",
            "apr",
            "may",
            "jun",
            "jul",
            "aug",
            "sep",
            "oct",
            "nov",
            "dec"});
            this.cboMon1.Location = new System.Drawing.Point(89, 113);
            this.cboMon1.Name = "cboMon1";
            this.cboMon1.Size = new System.Drawing.Size(56, 21);
            this.cboMon1.TabIndex = 45;
            // 
            // frmWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 181);
            this.Controls.Add(this.cboMon2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboMon1);
            this.Controls.Add(this.cboWeek2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboWeek1);
            this.Controls.Add(this.txtMon2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMon1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMin2);
            this.Controls.Add(this.txtHour2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMin1);
            this.Controls.Add(this.txtHour1);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.lbldom);
            this.Controls.Add(this.lbldow);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmWizard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wizard";
            this.Load += new System.EventHandler(this.frmWizard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtHour1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMin1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMin2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHour2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMon2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMon1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.Label lbldom;
        private System.Windows.Forms.Label lbldow;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.NumericUpDown txtHour1;
        private System.Windows.Forms.NumericUpDown txtMin1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown txtMin2;
        private System.Windows.Forms.NumericUpDown txtHour2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown txtMon2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown txtMon1;
        private System.Windows.Forms.ComboBox cboWeek1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboWeek2;
        private System.Windows.Forms.ComboBox cboMon2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboMon1;
    }
}