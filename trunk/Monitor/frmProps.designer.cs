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
            this.txtSpokeVolume = new System.Windows.Forms.NumericUpDown();
            this.lblSilent = new System.Windows.Forms.Label();
            this.lblLabel = new System.Windows.Forms.Label();
            this.txtLabel = new System.Windows.Forms.TextBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.lblOpt = new System.Windows.Forms.Label();
            this.txtCmd = new System.Windows.Forms.TextBox();
            this.lblFileName = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.lblFormat = new System.Windows.Forms.Label();
            this.cboFormat = new System.Windows.Forms.ComboBox();
            this.txtHeardVolume = new System.Windows.Forms.NumericUpDown();
            this.lblDuration = new System.Windows.Forms.Label();
            this.cmdVar = new System.Windows.Forms.Button();
            this.ckbBridgeOnly = new System.Windows.Forms.CheckBox();
            this.ckbAppend = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOverallVolume = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.txtSpokeVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeardVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOverallVolume)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSpokeVolume
            // 
            this.txtSpokeVolume.Location = new System.Drawing.Point(201, 141);
            this.txtSpokeVolume.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.txtSpokeVolume.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            -2147483648});
            this.txtSpokeVolume.Name = "txtSpokeVolume";
            this.txtSpokeVolume.Size = new System.Drawing.Size(39, 22);
            this.txtSpokeVolume.TabIndex = 7;
            // 
            // lblSilent
            // 
            this.lblSilent.AutoSize = true;
            this.lblSilent.Location = new System.Drawing.Point(7, 144);
            this.lblSilent.Name = "lblSilent";
            this.lblSilent.Size = new System.Drawing.Size(192, 12);
            this.lblSilent.TabIndex = 6;
            this.lblSilent.Text = "Adjust the spoken volume by a factor of";
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
            this.txtLabel.Size = new System.Drawing.Size(333, 22);
            this.txtLabel.TabIndex = 1;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(342, 234);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 21);
            this.cmdCancel.TabIndex = 15;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(261, 234);
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
            this.lblOpt.Location = new System.Drawing.Point(7, 200);
            this.lblOpt.Name = "lblOpt";
            this.lblOpt.Size = new System.Drawing.Size(60, 12);
            this.lblOpt.TabIndex = 12;
            this.lblOpt.Text = "Command :";
            // 
            // txtCmd
            // 
            this.txtCmd.Location = new System.Drawing.Point(84, 197);
            this.txtCmd.Name = "txtCmd";
            this.txtCmd.Size = new System.Drawing.Size(333, 22);
            this.txtCmd.TabIndex = 13;
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
            this.txtFileName.Size = new System.Drawing.Size(333, 22);
            this.txtFileName.TabIndex = 3;
            this.txtFileName.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtFileName_DragDrop);
            this.txtFileName.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtFileName_DragEnter);
            // 
            // lblFormat
            // 
            this.lblFormat.AutoSize = true;
            this.lblFormat.Location = new System.Drawing.Point(6, 83);
            this.lblFormat.Name = "lblFormat";
            this.lblFormat.Size = new System.Drawing.Size(57, 12);
            this.lblFormat.TabIndex = 4;
            this.lblFormat.Text = "Extension :";
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
            this.cboFormat.Location = new System.Drawing.Point(84, 80);
            this.cboFormat.Name = "cboFormat";
            this.cboFormat.Size = new System.Drawing.Size(58, 20);
            this.cboFormat.TabIndex = 5;
            // 
            // txtHeardVolume
            // 
            this.txtHeardVolume.Location = new System.Drawing.Point(201, 113);
            this.txtHeardVolume.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.txtHeardVolume.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            -2147483648});
            this.txtHeardVolume.Name = "txtHeardVolume";
            this.txtHeardVolume.Size = new System.Drawing.Size(39, 22);
            this.txtHeardVolume.TabIndex = 10;
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(7, 115);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(188, 12);
            this.lblDuration.TabIndex = 9;
            this.lblDuration.Text = "Adjust the heard volume by a factor of ";
            // 
            // cmdVar
            // 
            this.cmdVar.Location = new System.Drawing.Point(8, 234);
            this.cmdVar.Name = "cmdVar";
            this.cmdVar.Size = new System.Drawing.Size(75, 21);
            this.cmdVar.TabIndex = 16;
            this.cmdVar.Text = "Variables";
            this.cmdVar.UseVisualStyleBackColor = true;
            this.cmdVar.Click += new System.EventHandler(this.cmdVar_Click);
            // 
            // ckbBridgeOnly
            // 
            this.ckbBridgeOnly.AutoSize = true;
            this.ckbBridgeOnly.Location = new System.Drawing.Point(148, 71);
            this.ckbBridgeOnly.Name = "ckbBridgeOnly";
            this.ckbBridgeOnly.Size = new System.Drawing.Size(279, 16);
            this.ckbBridgeOnly.TabIndex = 17;
            this.ckbBridgeOnly.Text = "Only save audio to the file while the channel is bridged";
            this.ckbBridgeOnly.UseVisualStyleBackColor = true;
            // 
            // ckbAppend
            // 
            this.ckbAppend.AutoSize = true;
            this.ckbAppend.Location = new System.Drawing.Point(148, 93);
            this.ckbAppend.Name = "ckbAppend";
            this.ckbAppend.Size = new System.Drawing.Size(222, 16);
            this.ckbAppend.TabIndex = 18;
            this.ckbAppend.Text = "Append to the file instead of overwriting it";
            this.ckbAppend.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 12);
            this.label1.TabIndex = 19;
            this.label1.Text = "Adjust the overall volume by a factor of";
            // 
            // txtOverallVolume
            // 
            this.txtOverallVolume.Location = new System.Drawing.Point(201, 169);
            this.txtOverallVolume.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.txtOverallVolume.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            -2147483648});
            this.txtOverallVolume.Name = "txtOverallVolume";
            this.txtOverallVolume.Size = new System.Drawing.Size(39, 22);
            this.txtOverallVolume.TabIndex = 20;
            // 
            // frmProps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 267);
            this.Controls.Add(this.txtOverallVolume);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ckbAppend);
            this.Controls.Add(this.ckbBridgeOnly);
            this.Controls.Add(this.cmdVar);
            this.Controls.Add(this.txtHeardVolume);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.cboFormat);
            this.Controls.Add(this.lblFormat);
            this.Controls.Add(this.lblOpt);
            this.Controls.Add(this.txtCmd);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.txtSpokeVolume);
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
            ((System.ComponentModel.ISupportInitialize)(this.txtSpokeVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeardVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOverallVolume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown txtSpokeVolume;
        private System.Windows.Forms.Label lblSilent;
        private System.Windows.Forms.Label lblLabel;
        private System.Windows.Forms.TextBox txtLabel;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Label lblOpt;
        private System.Windows.Forms.TextBox txtCmd;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label lblFormat;
        private System.Windows.Forms.ComboBox cboFormat;
        private System.Windows.Forms.NumericUpDown txtHeardVolume;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Button cmdVar;
        private System.Windows.Forms.CheckBox ckbBridgeOnly;
        private System.Windows.Forms.CheckBox ckbAppend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown txtOverallVolume;
    }
}