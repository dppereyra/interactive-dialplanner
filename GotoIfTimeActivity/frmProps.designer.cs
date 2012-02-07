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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProps));
            this.lblLabel = new System.Windows.Forms.Label();
            this.txtLabel = new System.Windows.Forms.TextBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.lblTime = new System.Windows.Forms.Label();
            this.txtTimeRange = new System.Windows.Forms.TextBox();
            this.cmdVar = new System.Windows.Forms.Button();
            this.lbldow = new System.Windows.Forms.Label();
            this.txtDow = new System.Windows.Forms.TextBox();
            this.lbldom = new System.Windows.Forms.Label();
            this.txtDom = new System.Windows.Forms.TextBox();
            this.lblMonth = new System.Windows.Forms.Label();
            this.txtMonth = new System.Windows.Forms.TextBox();
            this.cmdTimeRange = new System.Windows.Forms.Button();
            this.cmdDow = new System.Windows.Forms.Button();
            this.cmdDom = new System.Windows.Forms.Button();
            this.cmdMonth = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblLabel
            // 
            this.lblLabel.AutoSize = true;
            this.lblLabel.Location = new System.Drawing.Point(7, 16);
            this.lblLabel.Name = "lblLabel";
            this.lblLabel.Size = new System.Drawing.Size(42, 13);
            this.lblLabel.TabIndex = 0;
            this.lblLabel.Text = "Label : ";
            // 
            // txtLabel
            // 
            this.txtLabel.Location = new System.Drawing.Point(84, 13);
            this.txtLabel.Name = "txtLabel";
            this.txtLabel.Size = new System.Drawing.Size(333, 20);
            this.txtLabel.TabIndex = 1;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(342, 118);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 15;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(261, 118);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 23);
            this.cmdOK.TabIndex = 14;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(7, 47);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(71, 13);
            this.lblTime.TabIndex = 2;
            this.lblTime.Text = "Time Range :";
            // 
            // txtTimeRange
            // 
            this.txtTimeRange.AllowDrop = true;
            this.txtTimeRange.Location = new System.Drawing.Point(84, 44);
            this.txtTimeRange.Name = "txtTimeRange";
            this.txtTimeRange.Size = new System.Drawing.Size(100, 20);
            this.txtTimeRange.TabIndex = 3;
            this.txtTimeRange.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtFileName_DragDrop);
            this.txtTimeRange.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtFileName_DragEnter);
            // 
            // cmdVar
            // 
            this.cmdVar.Location = new System.Drawing.Point(8, 118);
            this.cmdVar.Name = "cmdVar";
            this.cmdVar.Size = new System.Drawing.Size(75, 23);
            this.cmdVar.TabIndex = 16;
            this.cmdVar.Text = "Variables";
            this.cmdVar.UseVisualStyleBackColor = true;
            this.cmdVar.Click += new System.EventHandler(this.cmdVar_Click);
            // 
            // lbldow
            // 
            this.lbldow.AutoSize = true;
            this.lbldow.Location = new System.Drawing.Point(228, 47);
            this.lbldow.Name = "lbldow";
            this.lbldow.Size = new System.Drawing.Size(76, 13);
            this.lbldow.TabIndex = 17;
            this.lbldow.Text = "Day of Week :";
            // 
            // txtDow
            // 
            this.txtDow.AllowDrop = true;
            this.txtDow.Location = new System.Drawing.Point(305, 44);
            this.txtDow.Name = "txtDow";
            this.txtDow.Size = new System.Drawing.Size(112, 20);
            this.txtDow.TabIndex = 18;
            this.txtDow.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtDow_DragDrop);
            this.txtDow.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtDow_DragEnter);
            // 
            // lbldom
            // 
            this.lbldom.AutoSize = true;
            this.lbldom.Location = new System.Drawing.Point(7, 83);
            this.lbldom.Name = "lbldom";
            this.lbldom.Size = new System.Drawing.Size(77, 13);
            this.lbldom.TabIndex = 19;
            this.lbldom.Text = "Day of Month :";
            // 
            // txtDom
            // 
            this.txtDom.AllowDrop = true;
            this.txtDom.Location = new System.Drawing.Point(84, 80);
            this.txtDom.Name = "txtDom";
            this.txtDom.Size = new System.Drawing.Size(100, 20);
            this.txtDom.TabIndex = 20;
            this.txtDom.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtDom_DragDrop);
            this.txtDom.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtDom_DragEnter);
            // 
            // lblMonth
            // 
            this.lblMonth.AutoSize = true;
            this.lblMonth.Location = new System.Drawing.Point(228, 83);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(48, 13);
            this.lblMonth.TabIndex = 21;
            this.lblMonth.Text = "Months :";
            // 
            // txtMonth
            // 
            this.txtMonth.AllowDrop = true;
            this.txtMonth.Location = new System.Drawing.Point(305, 80);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.Size = new System.Drawing.Size(112, 20);
            this.txtMonth.TabIndex = 22;
            this.txtMonth.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtMonth_DragDrop);
            this.txtMonth.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtMonth_DragEnter);
            // 
            // cmdTimeRange
            // 
            this.cmdTimeRange.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdTimeRange.Image = ((System.Drawing.Image)(resources.GetObject("cmdTimeRange.Image")));
            this.cmdTimeRange.Location = new System.Drawing.Point(184, 43);
            this.cmdTimeRange.Name = "cmdTimeRange";
            this.cmdTimeRange.Size = new System.Drawing.Size(22, 22);
            this.cmdTimeRange.TabIndex = 24;
            this.cmdTimeRange.UseVisualStyleBackColor = true;
            this.cmdTimeRange.Click += new System.EventHandler(this.cmdTimeRange_Click);
            // 
            // cmdDow
            // 
            this.cmdDow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdDow.Image = ((System.Drawing.Image)(resources.GetObject("cmdDow.Image")));
            this.cmdDow.Location = new System.Drawing.Point(417, 44);
            this.cmdDow.Name = "cmdDow";
            this.cmdDow.Size = new System.Drawing.Size(22, 22);
            this.cmdDow.TabIndex = 25;
            this.cmdDow.UseVisualStyleBackColor = true;
            this.cmdDow.Click += new System.EventHandler(this.cmdDow_Click);
            // 
            // cmdDom
            // 
            this.cmdDom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdDom.Image = ((System.Drawing.Image)(resources.GetObject("cmdDom.Image")));
            this.cmdDom.Location = new System.Drawing.Point(184, 78);
            this.cmdDom.Name = "cmdDom";
            this.cmdDom.Size = new System.Drawing.Size(22, 22);
            this.cmdDom.TabIndex = 26;
            this.cmdDom.UseVisualStyleBackColor = true;
            this.cmdDom.Click += new System.EventHandler(this.cmdDom_Click);
            // 
            // cmdMonth
            // 
            this.cmdMonth.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdMonth.Image = ((System.Drawing.Image)(resources.GetObject("cmdMonth.Image")));
            this.cmdMonth.Location = new System.Drawing.Point(417, 80);
            this.cmdMonth.Name = "cmdMonth";
            this.cmdMonth.Size = new System.Drawing.Size(22, 22);
            this.cmdMonth.TabIndex = 27;
            this.cmdMonth.UseVisualStyleBackColor = true;
            this.cmdMonth.Click += new System.EventHandler(this.cmdMonth_Click);
            // 
            // frmProps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 155);
            this.Controls.Add(this.cmdMonth);
            this.Controls.Add(this.cmdDom);
            this.Controls.Add(this.cmdDow);
            this.Controls.Add(this.cmdTimeRange);
            this.Controls.Add(this.lblMonth);
            this.Controls.Add(this.txtMonth);
            this.Controls.Add(this.lbldom);
            this.Controls.Add(this.txtDom);
            this.Controls.Add(this.lbldow);
            this.Controls.Add(this.txtDow);
            this.Controls.Add(this.cmdVar);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.txtTimeRange);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLabel;
        private System.Windows.Forms.TextBox txtLabel;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.TextBox txtTimeRange;
        private System.Windows.Forms.Button cmdVar;
        private System.Windows.Forms.Label lbldow;
        private System.Windows.Forms.TextBox txtDow;
        private System.Windows.Forms.Label lbldom;
        private System.Windows.Forms.TextBox txtDom;
        private System.Windows.Forms.Label lblMonth;
        private System.Windows.Forms.TextBox txtMonth;
        private System.Windows.Forms.Button cmdTimeRange;
        private System.Windows.Forms.Button cmdDow;
        private System.Windows.Forms.Button cmdDom;
        private System.Windows.Forms.Button cmdMonth;
    }
}