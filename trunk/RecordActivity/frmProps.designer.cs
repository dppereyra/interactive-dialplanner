/******************************************************************************************
 * The MIT License (MIT)
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
    partial class frmProps
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
            this.txtSilent = new System.Windows.Forms.NumericUpDown();
            this.lblSec = new System.Windows.Forms.Label();
            this.lblSilent = new System.Windows.Forms.Label();
            this.lblLabel = new System.Windows.Forms.Label();
            this.txtLabel = new System.Windows.Forms.TextBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.lblOpt = new System.Windows.Forms.Label();
            this.txtOptions = new System.Windows.Forms.TextBox();
            this.lblFileName = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.lblFormat = new System.Windows.Forms.Label();
            this.cboFormat = new System.Windows.Forms.ComboBox();
            this.txtDuration = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.cmdVar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txtSilent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDuration)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSilent
            // 
            this.txtSilent.Location = new System.Drawing.Point(179, 68);
            this.txtSilent.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.txtSilent.Name = "txtSilent";
            this.txtSilent.Size = new System.Drawing.Size(38, 22);
            this.txtSilent.TabIndex = 7;
            // 
            // lblSec
            // 
            this.lblSec.AutoSize = true;
            this.lblSec.Location = new System.Drawing.Point(215, 72);
            this.lblSec.Name = "lblSec";
            this.lblSec.Size = new System.Drawing.Size(41, 12);
            this.lblSec.TabIndex = 8;
            this.lblSec.Text = "seconds";
            // 
            // lblSilent
            // 
            this.lblSilent.AutoSize = true;
            this.lblSilent.Location = new System.Drawing.Point(142, 72);
            this.lblSilent.Name = "lblSilent";
            this.lblSilent.Size = new System.Drawing.Size(37, 12);
            this.lblSilent.TabIndex = 6;
            this.lblSilent.Text = "Silent :";
            // 
            // lblLabel
            // 
            this.lblLabel.AutoSize = true;
            this.lblLabel.Location = new System.Drawing.Point(7, 15);
            this.lblLabel.Name = "lblLabel";
            this.lblLabel.Size = new System.Drawing.Size(40, 12);
            this.lblLabel.TabIndex = 0;
            this.lblLabel.Text = "Label : ";
            // 
            // txtLabel
            // 
            this.txtLabel.Location = new System.Drawing.Point(84, 12);
            this.txtLabel.Name = "txtLabel";
            this.txtLabel.Size = new System.Drawing.Size(269, 22);
            this.txtLabel.TabIndex = 1;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(273, 149);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 21);
            this.cmdCancel.TabIndex = 15;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(192, 149);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 21);
            this.cmdOK.TabIndex = 14;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // lblOpt
            // 
            this.lblOpt.AutoSize = true;
            this.lblOpt.Location = new System.Drawing.Point(7, 120);
            this.lblOpt.Name = "lblOpt";
            this.lblOpt.Size = new System.Drawing.Size(47, 12);
            this.lblOpt.TabIndex = 12;
            this.lblOpt.Text = "Options :";
            // 
            // txtOptions
            // 
            this.txtOptions.Location = new System.Drawing.Point(84, 117);
            this.txtOptions.Name = "txtOptions";
            this.txtOptions.Size = new System.Drawing.Size(269, 22);
            this.txtOptions.TabIndex = 13;
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(7, 43);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(58, 12);
            this.lblFileName.TabIndex = 2;
            this.lblFileName.Text = "File Name :";
            // 
            // txtFileName
            // 
            this.txtFileName.AllowDrop = true;
            this.txtFileName.Location = new System.Drawing.Point(84, 41);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(269, 22);
            this.txtFileName.TabIndex = 3;
            this.txtFileName.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtFileName_DragDrop);
            this.txtFileName.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtFileName_DragEnter);
            // 
            // lblFormat
            // 
            this.lblFormat.AutoSize = true;
            this.lblFormat.Location = new System.Drawing.Point(6, 70);
            this.lblFormat.Name = "lblFormat";
            this.lblFormat.Size = new System.Drawing.Size(44, 12);
            this.lblFormat.TabIndex = 4;
            this.lblFormat.Text = "Format :";
            // 
            // cboFormat
            // 
            this.cboFormat.FormattingEnabled = true;
            this.cboFormat.Items.AddRange(new object[] {
            "wav",
            "WAV",
            "gsm",
            "ulaw",
            "alaw",
            "g729"});
            this.cboFormat.Location = new System.Drawing.Point(84, 67);
            this.cboFormat.Name = "cboFormat";
            this.cboFormat.Size = new System.Drawing.Size(58, 20);
            this.cboFormat.TabIndex = 5;
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(84, 93);
            this.txtDuration.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(69, 22);
            this.txtDuration.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(159, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "seconds";
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(7, 95);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(76, 12);
            this.lblDuration.TabIndex = 9;
            this.lblDuration.Text = "Max Duration :";
            // 
            // cmdVar
            // 
            this.cmdVar.Location = new System.Drawing.Point(8, 149);
            this.cmdVar.Name = "cmdVar";
            this.cmdVar.Size = new System.Drawing.Size(75, 21);
            this.cmdVar.TabIndex = 16;
            this.cmdVar.Text = "Variables";
            this.cmdVar.UseVisualStyleBackColor = true;
            this.cmdVar.Click += new System.EventHandler(this.cmdVar_Click);
            // 
            // frmProps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 181);
            this.Controls.Add(this.cmdVar);
            this.Controls.Add(this.txtDuration);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.cboFormat);
            this.Controls.Add(this.lblFormat);
            this.Controls.Add(this.lblOpt);
            this.Controls.Add(this.txtOptions);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.txtSilent);
            this.Controls.Add(this.lblSec);
            this.Controls.Add(this.lblSilent);
            this.Controls.Add(this.lblLabel);
            this.Controls.Add(this.txtLabel);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmProps";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmProps";
            this.Load += new System.EventHandler(this.frmProps_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtSilent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDuration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown txtSilent;
        private System.Windows.Forms.Label lblSec;
        private System.Windows.Forms.Label lblSilent;
        private System.Windows.Forms.Label lblLabel;
        private System.Windows.Forms.TextBox txtLabel;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Label lblOpt;
        private System.Windows.Forms.TextBox txtOptions;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label lblFormat;
        private System.Windows.Forms.ComboBox cboFormat;
        private System.Windows.Forms.NumericUpDown txtDuration;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Button cmdVar;
    }
}