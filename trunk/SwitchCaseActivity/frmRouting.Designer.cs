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
    partial class frmRouting
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
            this.lblLabelDesc = new System.Windows.Forms.Label();
            this.txtLabelDesc = new System.Windows.Forms.TextBox();
            this.lblDigiMask = new System.Windows.Forms.Label();
            this.txtDigitMask = new System.Windows.Forms.TextBox();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblLabelDesc
            // 
            this.lblLabelDesc.AutoSize = true;
            this.lblLabelDesc.Location = new System.Drawing.Point(3, 7);
            this.lblLabelDesc.Name = "lblLabelDesc";
            this.lblLabelDesc.Size = new System.Drawing.Size(64, 12);
            this.lblLabelDesc.TabIndex = 0;
            this.lblLabelDesc.Text = "Description :";
            // 
            // txtLabelDesc
            // 
            this.txtLabelDesc.Location = new System.Drawing.Point(82, 5);
            this.txtLabelDesc.Name = "txtLabelDesc";
            this.txtLabelDesc.Size = new System.Drawing.Size(135, 22);
            this.txtLabelDesc.TabIndex = 1;
            // 
            // lblDigiMask
            // 
            this.lblDigiMask.AutoSize = true;
            this.lblDigiMask.Location = new System.Drawing.Point(3, 35);
            this.lblDigiMask.Name = "lblDigiMask";
            this.lblDigiMask.Size = new System.Drawing.Size(40, 12);
            this.lblDigiMask.TabIndex = 2;
            this.lblDigiMask.Text = "Result :";
            // 
            // txtDigitMask
            // 
            this.txtDigitMask.Location = new System.Drawing.Point(82, 32);
            this.txtDigitMask.Name = "txtDigitMask";
            this.txtDigitMask.Size = new System.Drawing.Size(135, 22);
            this.txtDigitMask.TabIndex = 3;
            // 
            // cmdOK
            // 
            this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOK.Location = new System.Drawing.Point(29, 66);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 21);
            this.cmdOK.TabIndex = 4;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(142, 66);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 21);
            this.cmdCancel.TabIndex = 5;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // frmRouting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 103);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.txtDigitMask);
            this.Controls.Add(this.lblDigiMask);
            this.Controls.Add(this.txtLabelDesc);
            this.Controls.Add(this.lblLabelDesc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmRouting";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Routing Properties";
            this.Load += new System.EventHandler(this.frmRouting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLabelDesc;
        private System.Windows.Forms.TextBox txtLabelDesc;
        private System.Windows.Forms.Label lblDigiMask;
        private System.Windows.Forms.TextBox txtDigitMask;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
    }
}