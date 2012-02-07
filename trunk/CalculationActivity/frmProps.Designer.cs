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
            this.txtVariable2 = new System.Windows.Forms.TextBox();
            this.cboOperator = new System.Windows.Forms.ComboBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.cmdVar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(372, 96);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 21);
            this.cmdCancel.TabIndex = 8;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(291, 96);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 21);
            this.cmdOK.TabIndex = 7;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // txtLabel
            // 
            this.txtLabel.Location = new System.Drawing.Point(71, 12);
            this.txtLabel.Name = "txtLabel";
            this.txtLabel.Size = new System.Drawing.Size(376, 22);
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
            this.lblVar.Size = new System.Drawing.Size(54, 12);
            this.lblVar.TabIndex = 2;
            this.lblVar.Text = "Calculate :";
            // 
            // txtVariable1
            // 
            this.txtVariable1.AllowDrop = true;
            this.txtVariable1.Location = new System.Drawing.Point(71, 40);
            this.txtVariable1.Name = "txtVariable1";
            this.txtVariable1.Size = new System.Drawing.Size(143, 22);
            this.txtVariable1.TabIndex = 3;
            this.txtVariable1.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtVariable1_DragDrop);
            this.txtVariable1.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtVariable1_DragEnter);
            // 
            // txtVariable2
            // 
            this.txtVariable2.AllowDrop = true;
            this.txtVariable2.Location = new System.Drawing.Point(260, 40);
            this.txtVariable2.Name = "txtVariable2";
            this.txtVariable2.Size = new System.Drawing.Size(140, 22);
            this.txtVariable2.TabIndex = 5;
            this.txtVariable2.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtVariable2_DragDrop);
            this.txtVariable2.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtVariable2_DragEnter);
            // 
            // cboOperator
            // 
            this.cboOperator.FormattingEnabled = true;
            this.cboOperator.Items.AddRange(new object[] {
            "+",
            "-",
            "*",
            "/",
            "%",
            "<",
            ">",
            "<=",
            ">=",
            "=="});
            this.cboOperator.Location = new System.Drawing.Point(220, 40);
            this.cboOperator.Name = "cboOperator";
            this.cboOperator.Size = new System.Drawing.Size(34, 20);
            this.cboOperator.TabIndex = 4;
            // 
            // txtResult
            // 
            this.txtResult.AllowDrop = true;
            this.txtResult.Location = new System.Drawing.Point(71, 64);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(376, 22);
            this.txtResult.TabIndex = 22;
            this.txtResult.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtResult_DragDrop);
            this.txtResult.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtResult_DragEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 12);
            this.label2.TabIndex = 21;
            this.label2.Text = "Result :";
            // 
            // cboType
            // 
            this.cboType.FormattingEnabled = true;
            this.cboType.Items.AddRange(new object[] {
            "i",
            "f",
            "h",
            "c"});
            this.cboType.Location = new System.Drawing.Point(406, 40);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(41, 20);
            this.cboType.TabIndex = 6;
            this.cboType.SelectedIndexChanged += new System.EventHandler(this.cboType_SelectedIndexChanged);
            // 
            // cmdVar
            // 
            this.cmdVar.Location = new System.Drawing.Point(12, 96);
            this.cmdVar.Name = "cmdVar";
            this.cmdVar.Size = new System.Drawing.Size(75, 21);
            this.cmdVar.TabIndex = 9;
            this.cmdVar.Text = "Variables";
            this.cmdVar.UseVisualStyleBackColor = true;
            this.cmdVar.Click += new System.EventHandler(this.cmdVar_Click);
            // 
            // frmProps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 128);
            this.Controls.Add(this.cmdVar);
            this.Controls.Add(this.cboType);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboOperator);
            this.Controls.Add(this.txtVariable2);
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
        private System.Windows.Forms.TextBox txtVariable2;
        private System.Windows.Forms.ComboBox cboOperator;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Button cmdVar;
    }
}