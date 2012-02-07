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
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.numSilent = new System.Windows.Forms.NumericUpDown();
            this.lblSilent = new System.Windows.Forms.Label();
            this.numDigits = new System.Windows.Forms.NumericUpDown();
            this.lblMaxDigit = new System.Windows.Forms.Label();
            this.lblLabel = new System.Windows.Forms.Label();
            this.txtLabel = new System.Windows.Forms.TextBox();
            this.lblMsg = new System.Windows.Forms.Label();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOptions = new System.Windows.Forms.TextBox();
            this.numRetry = new System.Windows.Forms.NumericUpDown();
            this.lblRetry = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVariable = new System.Windows.Forms.TextBox();
            this.cmdVar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numSilent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDigits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRetry)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(261, 156);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 21);
            this.cmdCancel.TabIndex = 15;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(180, 155);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 21);
            this.cmdOK.TabIndex = 14;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // numSilent
            // 
            this.numSilent.Location = new System.Drawing.Point(297, 108);
            this.numSilent.Name = "numSilent";
            this.numSilent.Size = new System.Drawing.Size(39, 22);
            this.numSilent.TabIndex = 11;
            // 
            // lblSilent
            // 
            this.lblSilent.AutoSize = true;
            this.lblSilent.Location = new System.Drawing.Point(149, 110);
            this.lblSilent.Name = "lblSilent";
            this.lblSilent.Size = new System.Drawing.Size(143, 12);
            this.lblSilent.TabIndex = 10;
            this.lblSilent.Text = "Maximum silence (seconds)  :";
            // 
            // numDigits
            // 
            this.numDigits.Location = new System.Drawing.Point(97, 107);
            this.numDigits.Name = "numDigits";
            this.numDigits.Size = new System.Drawing.Size(39, 22);
            this.numDigits.TabIndex = 9;
            // 
            // lblMaxDigit
            // 
            this.lblMaxDigit.AutoSize = true;
            this.lblMaxDigit.Location = new System.Drawing.Point(8, 108);
            this.lblMaxDigit.Name = "lblMaxDigit";
            this.lblMaxDigit.Size = new System.Drawing.Size(62, 12);
            this.lblMaxDigit.TabIndex = 8;
            this.lblMaxDigit.Text = "Max Digits :";
            // 
            // lblLabel
            // 
            this.lblLabel.AutoSize = true;
            this.lblLabel.Location = new System.Drawing.Point(8, 7);
            this.lblLabel.Name = "lblLabel";
            this.lblLabel.Size = new System.Drawing.Size(40, 12);
            this.lblLabel.TabIndex = 0;
            this.lblLabel.Text = "Label : ";
            // 
            // txtLabel
            // 
            this.txtLabel.Location = new System.Drawing.Point(97, 5);
            this.txtLabel.Name = "txtLabel";
            this.txtLabel.Size = new System.Drawing.Size(251, 22);
            this.txtLabel.TabIndex = 1;
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(8, 60);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(79, 12);
            this.lblMsg.TabIndex = 4;
            this.lblMsg.Text = "Entry Message :";
            // 
            // txtMsg
            // 
            this.txtMsg.AllowDrop = true;
            this.txtMsg.Location = new System.Drawing.Point(97, 58);
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(251, 22);
            this.txtMsg.TabIndex = 5;
            this.txtMsg.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtMsg_DragDrop);
            this.txtMsg.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtMsg_DragEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "Options :";
            // 
            // txtOptions
            // 
            this.txtOptions.Location = new System.Drawing.Point(97, 82);
            this.txtOptions.Name = "txtOptions";
            this.txtOptions.Size = new System.Drawing.Size(251, 22);
            this.txtOptions.TabIndex = 7;
            // 
            // numRetry
            // 
            this.numRetry.Location = new System.Drawing.Point(297, 132);
            this.numRetry.Name = "numRetry";
            this.numRetry.Size = new System.Drawing.Size(39, 22);
            this.numRetry.TabIndex = 13;
            // 
            // lblRetry
            // 
            this.lblRetry.AutoSize = true;
            this.lblRetry.Location = new System.Drawing.Point(162, 134);
            this.lblRetry.Name = "lblRetry";
            this.lblRetry.Size = new System.Drawing.Size(134, 12);
            this.lblRetry.TabIndex = 12;
            this.lblRetry.Text = "Number of retries on error :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Result : ";
            // 
            // txtVariable
            // 
            this.txtVariable.AllowDrop = true;
            this.txtVariable.Location = new System.Drawing.Point(97, 33);
            this.txtVariable.Name = "txtVariable";
            this.txtVariable.Size = new System.Drawing.Size(251, 22);
            this.txtVariable.TabIndex = 3;
            this.txtVariable.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtVariable_DragDrop);
            this.txtVariable.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtVariable_DragEnter);
            // 
            // cmdVar
            // 
            this.cmdVar.Location = new System.Drawing.Point(11, 155);
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
            this.ClientSize = new System.Drawing.Size(353, 183);
            this.Controls.Add(this.cmdVar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtVariable);
            this.Controls.Add(this.numRetry);
            this.Controls.Add(this.lblRetry);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtOptions);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.numSilent);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.lblSilent);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.numDigits);
            this.Controls.Add(this.txtLabel);
            this.Controls.Add(this.lblMaxDigit);
            this.Controls.Add(this.lblLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmProps";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmProps";
            this.Load += new System.EventHandler(this.frmProps_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numSilent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDigits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRetry)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Label lblLabel;
        private System.Windows.Forms.TextBox txtLabel;
        private System.Windows.Forms.Label lblMaxDigit;
        private System.Windows.Forms.NumericUpDown numDigits;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.NumericUpDown numSilent;
        private System.Windows.Forms.Label lblSilent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOptions;
        private System.Windows.Forms.NumericUpDown numRetry;
        private System.Windows.Forms.Label lblRetry;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVariable;
        private System.Windows.Forms.Button cmdVar;
    }
}