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
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.txtLabel = new System.Windows.Forms.TextBox();
            this.lblLabel = new System.Windows.Forms.Label();
            this.lblVar = new System.Windows.Forms.Label();
            this.txtVariable1 = new System.Windows.Forms.TextBox();
            this.lblEuqal = new System.Windows.Forms.Label();
            this.txtVariable2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboOperator = new System.Windows.Forms.ComboBox();
            this.cmdVar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(253, 122);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 21);
            this.cmdCancel.TabIndex = 9;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(172, 122);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 21);
            this.cmdOK.TabIndex = 8;
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
            // lblVar
            // 
            this.lblVar.AutoSize = true;
            this.lblVar.Location = new System.Drawing.Point(12, 42);
            this.lblVar.Name = "lblVar";
            this.lblVar.Size = new System.Drawing.Size(59, 12);
            this.lblVar.TabIndex = 2;
            this.lblVar.Text = "Variable 1 :";
            // 
            // txtVariable1
            // 
            this.txtVariable1.AllowDrop = true;
            this.txtVariable1.Location = new System.Drawing.Point(71, 40);
            this.txtVariable1.Name = "txtVariable1";
            this.txtVariable1.Size = new System.Drawing.Size(257, 22);
            this.txtVariable1.TabIndex = 3;
            this.txtVariable1.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtVariable1_DragDrop);
            this.txtVariable1.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtVariable1_DragEnter);
            // 
            // lblEuqal
            // 
            this.lblEuqal.AutoSize = true;
            this.lblEuqal.Location = new System.Drawing.Point(12, 66);
            this.lblEuqal.Name = "lblEuqal";
            this.lblEuqal.Size = new System.Drawing.Size(52, 12);
            this.lblEuqal.TabIndex = 4;
            this.lblEuqal.Text = "Operator :";
            // 
            // txtVariable2
            // 
            this.txtVariable2.AllowDrop = true;
            this.txtVariable2.Location = new System.Drawing.Point(71, 92);
            this.txtVariable2.Name = "txtVariable2";
            this.txtVariable2.Size = new System.Drawing.Size(257, 22);
            this.txtVariable2.TabIndex = 7;
            this.txtVariable2.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtVariable2_DragDrop);
            this.txtVariable2.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtVariable2_DragEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "Variable 2 :";
            // 
            // cboOperator
            // 
            this.cboOperator.FormattingEnabled = true;
            this.cboOperator.Items.AddRange(new object[] {
            "=",
            ">",
            "<",
            "!="});
            this.cboOperator.Location = new System.Drawing.Point(71, 65);
            this.cboOperator.Name = "cboOperator";
            this.cboOperator.Size = new System.Drawing.Size(71, 20);
            this.cboOperator.TabIndex = 5;
            // 
            // cmdVar
            // 
            this.cmdVar.Location = new System.Drawing.Point(14, 122);
            this.cmdVar.Name = "cmdVar";
            this.cmdVar.Size = new System.Drawing.Size(75, 21);
            this.cmdVar.TabIndex = 10;
            this.cmdVar.Text = "Variables";
            this.cmdVar.UseVisualStyleBackColor = true;
            this.cmdVar.Click += new System.EventHandler(this.cmdVar_Click);
            // 
            // frmProps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 154);
            this.Controls.Add(this.cmdVar);
            this.Controls.Add(this.cboOperator);
            this.Controls.Add(this.txtVariable2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblEuqal);
            this.Controls.Add(this.txtVariable1);
            this.Controls.Add(this.lblVar);
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
        private System.Windows.Forms.Label lblVar;
        private System.Windows.Forms.TextBox txtVariable1;
        private System.Windows.Forms.Label lblEuqal;
        private System.Windows.Forms.TextBox txtVariable2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboOperator;
        private System.Windows.Forms.Button cmdVar;
    }
}