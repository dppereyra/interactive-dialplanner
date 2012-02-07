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
            this.txtWait = new System.Windows.Forms.NumericUpDown();
            this.lblSec = new System.Windows.Forms.Label();
            this.lblWait = new System.Windows.Forms.Label();
            this.lblLabel = new System.Windows.Forms.Label();
            this.txtLabel = new System.Windows.Forms.TextBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.lblOpt = new System.Windows.Forms.Label();
            this.txtOptions = new System.Windows.Forms.TextBox();
            this.lblDial = new System.Windows.Forms.Label();
            this.txtDial = new System.Windows.Forms.TextBox();
            this.cmdVar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txtWait)).BeginInit();
            this.SuspendLayout();
            // 
            // txtWait
            // 
            this.txtWait.Location = new System.Drawing.Point(53, 68);
            this.txtWait.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.txtWait.Name = "txtWait";
            this.txtWait.Size = new System.Drawing.Size(61, 22);
            this.txtWait.TabIndex = 5;
            // 
            // lblSec
            // 
            this.lblSec.AutoSize = true;
            this.lblSec.Location = new System.Drawing.Point(120, 72);
            this.lblSec.Name = "lblSec";
            this.lblSec.Size = new System.Drawing.Size(41, 12);
            this.lblSec.TabIndex = 6;
            this.lblSec.Text = "seconds";
            // 
            // lblWait
            // 
            this.lblWait.AutoSize = true;
            this.lblWait.Location = new System.Drawing.Point(5, 72);
            this.lblWait.Name = "lblWait";
            this.lblWait.Size = new System.Drawing.Size(36, 12);
            this.lblWait.TabIndex = 4;
            this.lblWait.Text = "Wait : ";
            // 
            // lblLabel
            // 
            this.lblLabel.AutoSize = true;
            this.lblLabel.Location = new System.Drawing.Point(5, 15);
            this.lblLabel.Name = "lblLabel";
            this.lblLabel.Size = new System.Drawing.Size(40, 12);
            this.lblLabel.TabIndex = 0;
            this.lblLabel.Text = "Label : ";
            // 
            // txtLabel
            // 
            this.txtLabel.Location = new System.Drawing.Point(53, 12);
            this.txtLabel.Name = "txtLabel";
            this.txtLabel.Size = new System.Drawing.Size(269, 22);
            this.txtLabel.TabIndex = 1;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(247, 123);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 21);
            this.cmdCancel.TabIndex = 10;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(166, 122);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 21);
            this.cmdOK.TabIndex = 9;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // lblOpt
            // 
            this.lblOpt.AutoSize = true;
            this.lblOpt.Location = new System.Drawing.Point(4, 98);
            this.lblOpt.Name = "lblOpt";
            this.lblOpt.Size = new System.Drawing.Size(47, 12);
            this.lblOpt.TabIndex = 7;
            this.lblOpt.Text = "Options :";
            // 
            // txtOptions
            // 
            this.txtOptions.Location = new System.Drawing.Point(53, 95);
            this.txtOptions.Name = "txtOptions";
            this.txtOptions.Size = new System.Drawing.Size(269, 22);
            this.txtOptions.TabIndex = 8;
            // 
            // lblDial
            // 
            this.lblDial.AutoSize = true;
            this.lblDial.Location = new System.Drawing.Point(4, 43);
            this.lblDial.Name = "lblDial";
            this.lblDial.Size = new System.Drawing.Size(39, 12);
            this.lblDial.TabIndex = 2;
            this.lblDial.Text = "Dial to:";
            // 
            // txtDial
            // 
            this.txtDial.AllowDrop = true;
            this.txtDial.Location = new System.Drawing.Point(53, 40);
            this.txtDial.Name = "txtDial";
            this.txtDial.Size = new System.Drawing.Size(269, 22);
            this.txtDial.TabIndex = 3;
            this.txtDial.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtDial_DragDrop);
            this.txtDial.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtDial_DragEnter);
            // 
            // cmdVar
            // 
            this.cmdVar.Location = new System.Drawing.Point(6, 123);
            this.cmdVar.Name = "cmdVar";
            this.cmdVar.Size = new System.Drawing.Size(75, 21);
            this.cmdVar.TabIndex = 11;
            this.cmdVar.Text = "Variables";
            this.cmdVar.UseVisualStyleBackColor = true;
            this.cmdVar.Click += new System.EventHandler(this.cmdVar_Click);
            // 
            // frmProps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 150);
            this.Controls.Add(this.cmdVar);
            this.Controls.Add(this.lblOpt);
            this.Controls.Add(this.txtOptions);
            this.Controls.Add(this.lblDial);
            this.Controls.Add(this.txtDial);
            this.Controls.Add(this.txtWait);
            this.Controls.Add(this.lblSec);
            this.Controls.Add(this.lblWait);
            this.Controls.Add(this.lblLabel);
            this.Controls.Add(this.txtLabel);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmProps";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmProps";
            this.Load += new System.EventHandler(this.frmProps_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtWait)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown txtWait;
        private System.Windows.Forms.Label lblSec;
        private System.Windows.Forms.Label lblWait;
        private System.Windows.Forms.Label lblLabel;
        private System.Windows.Forms.TextBox txtLabel;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Label lblOpt;
        private System.Windows.Forms.TextBox txtOptions;
        private System.Windows.Forms.Label lblDial;
        private System.Windows.Forms.TextBox txtDial;
        private System.Windows.Forms.Button cmdVar;
    }
}