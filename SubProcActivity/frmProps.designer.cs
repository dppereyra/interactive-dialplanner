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
            this.cmdAdd = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmdRemovePage = new System.Windows.Forms.Button();
            this.tabProps = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.txtArguments = new System.Windows.Forms.TextBox();
            this.lblLabel = new System.Windows.Forms.Label();
            this.lstPage = new System.Windows.Forms.ListBox();
            this.txtLabel = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblResult = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.lstNodes = new System.Windows.Forms.ListBox();
            this.cmdVar = new System.Windows.Forms.Button();
            this.tabProps.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(184, 259);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 21);
            this.cmdCancel.TabIndex = 7;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(3, 158);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(75, 21);
            this.cmdAdd.TabIndex = 12;
            this.cmdAdd.Text = "Add";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(103, 260);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 21);
            this.cmdOK.TabIndex = 6;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Location = new System.Drawing.Point(84, 158);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(75, 21);
            this.cmdDelete.TabIndex = 13;
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdRemovePage
            // 
            this.cmdRemovePage.Location = new System.Drawing.Point(6, 158);
            this.cmdRemovePage.Name = "cmdRemovePage";
            this.cmdRemovePage.Size = new System.Drawing.Size(84, 21);
            this.cmdRemovePage.TabIndex = 3;
            this.cmdRemovePage.Text = "RemovePage";
            this.cmdRemovePage.UseVisualStyleBackColor = true;
            this.cmdRemovePage.Click += new System.EventHandler(this.cmdRemovePage_Click);
            // 
            // tabProps
            // 
            this.tabProps.Controls.Add(this.tabPage1);
            this.tabProps.Controls.Add(this.tabPage2);
            this.tabProps.Location = new System.Drawing.Point(2, 2);
            this.tabProps.Name = "tabProps";
            this.tabProps.SelectedIndex = 0;
            this.tabProps.Size = new System.Drawing.Size(267, 252);
            this.tabProps.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtArguments);
            this.tabPage1.Controls.Add(this.lblLabel);
            this.tabPage1.Controls.Add(this.cmdRemovePage);
            this.tabPage1.Controls.Add(this.lstPage);
            this.tabPage1.Controls.Add(this.txtLabel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(259, 226);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Page";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 191);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "Arguments :";
            // 
            // txtArguments
            // 
            this.txtArguments.Location = new System.Drawing.Point(73, 185);
            this.txtArguments.Name = "txtArguments";
            this.txtArguments.Size = new System.Drawing.Size(179, 22);
            this.txtArguments.TabIndex = 5;
            // 
            // lblLabel
            // 
            this.lblLabel.AutoSize = true;
            this.lblLabel.Location = new System.Drawing.Point(6, 15);
            this.lblLabel.Name = "lblLabel";
            this.lblLabel.Size = new System.Drawing.Size(37, 12);
            this.lblLabel.TabIndex = 0;
            this.lblLabel.Text = "Label :";
            // 
            // lstPage
            // 
            this.lstPage.FormattingEnabled = true;
            this.lstPage.ItemHeight = 12;
            this.lstPage.Location = new System.Drawing.Point(6, 37);
            this.lstPage.Name = "lstPage";
            this.lstPage.Size = new System.Drawing.Size(247, 112);
            this.lstPage.TabIndex = 2;
            // 
            // txtLabel
            // 
            this.txtLabel.Location = new System.Drawing.Point(49, 9);
            this.txtLabel.Name = "txtLabel";
            this.txtLabel.Size = new System.Drawing.Size(204, 22);
            this.txtLabel.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblResult);
            this.tabPage2.Controls.Add(this.txtResult);
            this.tabPage2.Controls.Add(this.lstNodes);
            this.tabPage2.Controls.Add(this.cmdDelete);
            this.tabPage2.Controls.Add(this.cmdAdd);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(259, 226);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Result";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(3, 14);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(37, 12);
            this.lblResult.TabIndex = 9;
            this.lblResult.Text = "Label :";
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(46, 8);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(204, 22);
            this.txtResult.TabIndex = 10;
            // 
            // lstNodes
            // 
            this.lstNodes.FormattingEnabled = true;
            this.lstNodes.ItemHeight = 12;
            this.lstNodes.Location = new System.Drawing.Point(6, 39);
            this.lstNodes.Name = "lstNodes";
            this.lstNodes.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstNodes.Size = new System.Drawing.Size(247, 112);
            this.lstNodes.TabIndex = 11;
            // 
            // cmdVar
            // 
            this.cmdVar.Location = new System.Drawing.Point(9, 260);
            this.cmdVar.Name = "cmdVar";
            this.cmdVar.Size = new System.Drawing.Size(75, 21);
            this.cmdVar.TabIndex = 8;
            this.cmdVar.Text = "Variables";
            this.cmdVar.UseVisualStyleBackColor = true;
            this.cmdVar.Click += new System.EventHandler(this.cmdVar_Click);
            // 
            // frmProps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 293);
            this.Controls.Add(this.cmdVar);
            this.Controls.Add(this.tabProps);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmProps";
            this.ShowInTaskbar = false;
            this.Text = "frmProps";
            this.Load += new System.EventHandler(this.frmProps_Load);
            this.tabProps.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Button cmdRemovePage;
        private System.Windows.Forms.TabControl tabProps;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lblLabel;
        private System.Windows.Forms.ListBox lstPage;
        private System.Windows.Forms.TextBox txtLabel;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox lstNodes;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtArguments;
        private System.Windows.Forms.Button cmdVar;
    }
}