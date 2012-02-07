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
            this.txtLabel = new System.Windows.Forms.TextBox();
            this.lblLabel = new System.Windows.Forms.Label();
            this.lbVar = new System.Windows.Forms.Label();
            this.txtVar = new System.Windows.Forms.TextBox();
            this.cmdVar = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(253, 94);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 21);
            this.cmdCancel.TabIndex = 7;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(172, 94);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 21);
            this.cmdOK.TabIndex = 6;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // txtLabel
            // 
            this.txtLabel.Location = new System.Drawing.Point(71, 12);
            this.txtLabel.Name = "txtLabel";
            this.txtLabel.Size = new System.Drawing.Size(257, 22);
            this.txtLabel.TabIndex = 1;
            // 
            // lblLabel
            // 
            this.lblLabel.AutoSize = true;
            this.lblLabel.Location = new System.Drawing.Point(12, 15);
            this.lblLabel.Name = "lblLabel";
            this.lblLabel.Size = new System.Drawing.Size(40, 12);
            this.lblLabel.TabIndex = 0;
            this.lblLabel.Text = "Label : ";
            // 
            // lbVar
            // 
            this.lbVar.AutoSize = true;
            this.lbVar.Location = new System.Drawing.Point(12, 44);
            this.lbVar.Name = "lbVar";
            this.lbVar.Size = new System.Drawing.Size(39, 12);
            this.lbVar.TabIndex = 2;
            this.lbVar.Text = "String :";
            // 
            // txtVar
            // 
            this.txtVar.AllowDrop = true;
            this.txtVar.Location = new System.Drawing.Point(71, 40);
            this.txtVar.Name = "txtVar";
            this.txtVar.Size = new System.Drawing.Size(257, 22);
            this.txtVar.TabIndex = 3;
            this.txtVar.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtVar_DragDrop);
            this.txtVar.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtVar_DragEnter);
            // 
            // cmdVar
            // 
            this.cmdVar.Location = new System.Drawing.Point(12, 94);
            this.cmdVar.Name = "cmdVar";
            this.cmdVar.Size = new System.Drawing.Size(75, 21);
            this.cmdVar.TabIndex = 8;
            this.cmdVar.Text = "Variables";
            this.cmdVar.UseVisualStyleBackColor = true;
            this.cmdVar.Click += new System.EventHandler(this.cmdVar_Click);
            // 
            // txtResult
            // 
            this.txtResult.AllowDrop = true;
            this.txtResult.Location = new System.Drawing.Point(71, 68);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(257, 22);
            this.txtResult.TabIndex = 5;
            this.txtResult.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtResult_DragDrop);
            this.txtResult.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtResult_DragEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "Result :";
            // 
            // frmProps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 126);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdVar);
            this.Controls.Add(this.txtVar);
            this.Controls.Add(this.lbVar);
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

        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.TextBox txtLabel;
        private System.Windows.Forms.Label lblLabel;
        private System.Windows.Forms.Label lbVar;
        private System.Windows.Forms.TextBox txtVar;
        private System.Windows.Forms.Button cmdVar;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label label1;
    }
}