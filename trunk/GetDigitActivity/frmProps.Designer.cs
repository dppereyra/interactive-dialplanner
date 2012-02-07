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
            this.tabProps = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.numSilent = new System.Windows.Forms.NumericUpDown();
            this.lblSilent = new System.Windows.Forms.Label();
            this.numRetry = new System.Windows.Forms.NumericUpDown();
            this.lblRetry = new System.Windows.Forms.Label();
            this.numDigits = new System.Windows.Forms.NumericUpDown();
            this.lblMaxDigit = new System.Windows.Forms.Label();
            this.lblLabel = new System.Windows.Forms.Label();
            this.txtLabel = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.lstRoute = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lblMsg = new System.Windows.Forms.Label();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.lblNoInput = new System.Windows.Forms.Label();
            this.txtNoInput = new System.Windows.Forms.TextBox();
            this.lblInvalid = new System.Windows.Forms.Label();
            this.txtInvalidMsg = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.cmdRemoveGT = new System.Windows.Forms.Button();
            this.lstGlobalTimeout = new System.Windows.Forms.ListBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.cmdRemoveGI = new System.Windows.Forms.Button();
            this.lstGlobalInvalid = new System.Windows.Forms.ListBox();
            this.cmdVar = new System.Windows.Forms.Button();
            this.tabProps.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSilent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRetry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDigits)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(283, 191);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 21);
            this.cmdCancel.TabIndex = 23;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(202, 190);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 21);
            this.cmdOK.TabIndex = 22;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // tabProps
            // 
            this.tabProps.Controls.Add(this.tabPage1);
            this.tabProps.Controls.Add(this.tabPage2);
            this.tabProps.Controls.Add(this.tabPage3);
            this.tabProps.Controls.Add(this.tabPage4);
            this.tabProps.Controls.Add(this.tabPage5);
            this.tabProps.Location = new System.Drawing.Point(2, 2);
            this.tabProps.Name = "tabProps";
            this.tabProps.SelectedIndex = 0;
            this.tabProps.Size = new System.Drawing.Size(360, 184);
            this.tabProps.TabIndex = 15;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.numSilent);
            this.tabPage1.Controls.Add(this.lblSilent);
            this.tabPage1.Controls.Add(this.numRetry);
            this.tabPage1.Controls.Add(this.lblRetry);
            this.tabPage1.Controls.Add(this.numDigits);
            this.tabPage1.Controls.Add(this.lblMaxDigit);
            this.tabPage1.Controls.Add(this.lblLabel);
            this.tabPage1.Controls.Add(this.txtLabel);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(352, 158);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // numSilent
            // 
            this.numSilent.Location = new System.Drawing.Point(307, 77);
            this.numSilent.Name = "numSilent";
            this.numSilent.Size = new System.Drawing.Size(39, 22);
            this.numSilent.TabIndex = 7;
            // 
            // lblSilent
            // 
            this.lblSilent.AutoSize = true;
            this.lblSilent.Location = new System.Drawing.Point(159, 78);
            this.lblSilent.Name = "lblSilent";
            this.lblSilent.Size = new System.Drawing.Size(143, 12);
            this.lblSilent.TabIndex = 6;
            this.lblSilent.Text = "Maximum silence (seconds)  :";
            // 
            // numRetry
            // 
            this.numRetry.Location = new System.Drawing.Point(307, 53);
            this.numRetry.Name = "numRetry";
            this.numRetry.Size = new System.Drawing.Size(39, 22);
            this.numRetry.TabIndex = 5;
            // 
            // lblRetry
            // 
            this.lblRetry.AutoSize = true;
            this.lblRetry.Location = new System.Drawing.Point(172, 54);
            this.lblRetry.Name = "lblRetry";
            this.lblRetry.Size = new System.Drawing.Size(134, 12);
            this.lblRetry.TabIndex = 4;
            this.lblRetry.Text = "Number of retries on error :";
            // 
            // numDigits
            // 
            this.numDigits.Location = new System.Drawing.Point(307, 30);
            this.numDigits.Name = "numDigits";
            this.numDigits.Size = new System.Drawing.Size(39, 22);
            this.numDigits.TabIndex = 3;
            // 
            // lblMaxDigit
            // 
            this.lblMaxDigit.AutoSize = true;
            this.lblMaxDigit.Location = new System.Drawing.Point(242, 31);
            this.lblMaxDigit.Name = "lblMaxDigit";
            this.lblMaxDigit.Size = new System.Drawing.Size(62, 12);
            this.lblMaxDigit.TabIndex = 2;
            this.lblMaxDigit.Text = "Max Digits :";
            // 
            // lblLabel
            // 
            this.lblLabel.AutoSize = true;
            this.lblLabel.Location = new System.Drawing.Point(6, 8);
            this.lblLabel.Name = "lblLabel";
            this.lblLabel.Size = new System.Drawing.Size(40, 12);
            this.lblLabel.TabIndex = 0;
            this.lblLabel.Text = "Label : ";
            // 
            // txtLabel
            // 
            this.txtLabel.Location = new System.Drawing.Point(72, 6);
            this.txtLabel.Name = "txtLabel";
            this.txtLabel.Size = new System.Drawing.Size(274, 22);
            this.txtLabel.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cmdEdit);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.cmdAdd);
            this.tabPage2.Controls.Add(this.cmdDelete);
            this.tabPage2.Controls.Add(this.lstRoute);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(352, 158);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Routing";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cmdEdit
            // 
            this.cmdEdit.Location = new System.Drawing.Point(92, 132);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(75, 21);
            this.cmdEdit.TabIndex = 10;
            this.cmdEdit.Text = "Edit";
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(100, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Digit Mask";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(7, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Description";
            // 
            // cmdAdd
            // 
            this.cmdAdd.Location = new System.Drawing.Point(6, 132);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(75, 21);
            this.cmdAdd.TabIndex = 9;
            this.cmdAdd.Text = "Add";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Location = new System.Drawing.Point(174, 132);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(75, 21);
            this.cmdDelete.TabIndex = 11;
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // lstRoute
            // 
            this.lstRoute.FormattingEnabled = true;
            this.lstRoute.ItemHeight = 12;
            this.lstRoute.Location = new System.Drawing.Point(3, 27);
            this.lstRoute.Name = "lstRoute";
            this.lstRoute.Size = new System.Drawing.Size(345, 100);
            this.lstRoute.TabIndex = 8;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lblMsg);
            this.tabPage3.Controls.Add(this.txtMsg);
            this.tabPage3.Controls.Add(this.lblNoInput);
            this.tabPage3.Controls.Add(this.txtNoInput);
            this.tabPage3.Controls.Add(this.lblInvalid);
            this.tabPage3.Controls.Add(this.txtInvalidMsg);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(352, 158);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Greeting";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(8, 8);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(79, 12);
            this.lblMsg.TabIndex = 12;
            this.lblMsg.Text = "Entry Message :";
            // 
            // txtMsg
            // 
            this.txtMsg.AllowDrop = true;
            this.txtMsg.Location = new System.Drawing.Point(133, 6);
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(198, 22);
            this.txtMsg.TabIndex = 13;
            this.txtMsg.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtMsg_DragDrop);
            this.txtMsg.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtMsg_DragEnter);
            // 
            // lblNoInput
            // 
            this.lblNoInput.AutoSize = true;
            this.lblNoInput.Location = new System.Drawing.Point(8, 56);
            this.lblNoInput.Name = "lblNoInput";
            this.lblNoInput.Size = new System.Drawing.Size(95, 12);
            this.lblNoInput.TabIndex = 16;
            this.lblNoInput.Text = "No Input Message :";
            // 
            // txtNoInput
            // 
            this.txtNoInput.AllowDrop = true;
            this.txtNoInput.Location = new System.Drawing.Point(133, 54);
            this.txtNoInput.Name = "txtNoInput";
            this.txtNoInput.Size = new System.Drawing.Size(198, 22);
            this.txtNoInput.TabIndex = 17;
            this.txtNoInput.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtNoInput_DragDrop);
            this.txtNoInput.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtNoInput_DragEnter);
            // 
            // lblInvalid
            // 
            this.lblInvalid.AutoSize = true;
            this.lblInvalid.Location = new System.Drawing.Point(8, 32);
            this.lblInvalid.Name = "lblInvalid";
            this.lblInvalid.Size = new System.Drawing.Size(116, 12);
            this.lblInvalid.TabIndex = 14;
            this.lblInvalid.Text = "Invalid Digits Message :";
            // 
            // txtInvalidMsg
            // 
            this.txtInvalidMsg.AllowDrop = true;
            this.txtInvalidMsg.Location = new System.Drawing.Point(133, 30);
            this.txtInvalidMsg.Name = "txtInvalidMsg";
            this.txtInvalidMsg.Size = new System.Drawing.Size(198, 22);
            this.txtInvalidMsg.TabIndex = 15;
            this.txtInvalidMsg.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtInvalidMsg_DragDrop);
            this.txtInvalidMsg.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtInvalidMsg_DragEnter);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.cmdRemoveGT);
            this.tabPage4.Controls.Add(this.lstGlobalTimeout);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(352, 158);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Global Timeout";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // cmdRemoveGT
            // 
            this.cmdRemoveGT.Location = new System.Drawing.Point(6, 133);
            this.cmdRemoveGT.Name = "cmdRemoveGT";
            this.cmdRemoveGT.Size = new System.Drawing.Size(75, 21);
            this.cmdRemoveGT.TabIndex = 19;
            this.cmdRemoveGT.Text = "Remove";
            this.cmdRemoveGT.UseVisualStyleBackColor = true;
            this.cmdRemoveGT.Click += new System.EventHandler(this.cmdRemoveGT_Click);
            // 
            // lstGlobalTimeout
            // 
            this.lstGlobalTimeout.FormattingEnabled = true;
            this.lstGlobalTimeout.ItemHeight = 12;
            this.lstGlobalTimeout.Location = new System.Drawing.Point(4, 3);
            this.lstGlobalTimeout.Name = "lstGlobalTimeout";
            this.lstGlobalTimeout.Size = new System.Drawing.Size(343, 124);
            this.lstGlobalTimeout.TabIndex = 18;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.cmdRemoveGI);
            this.tabPage5.Controls.Add(this.lstGlobalInvalid);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(352, 158);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Global Invalid";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // cmdRemoveGI
            // 
            this.cmdRemoveGI.Location = new System.Drawing.Point(6, 133);
            this.cmdRemoveGI.Name = "cmdRemoveGI";
            this.cmdRemoveGI.Size = new System.Drawing.Size(75, 21);
            this.cmdRemoveGI.TabIndex = 21;
            this.cmdRemoveGI.Text = "Remove";
            this.cmdRemoveGI.UseVisualStyleBackColor = true;
            this.cmdRemoveGI.Click += new System.EventHandler(this.cmdRemoveGI_Click);
            // 
            // lstGlobalInvalid
            // 
            this.lstGlobalInvalid.FormattingEnabled = true;
            this.lstGlobalInvalid.ItemHeight = 12;
            this.lstGlobalInvalid.Location = new System.Drawing.Point(4, 3);
            this.lstGlobalInvalid.Name = "lstGlobalInvalid";
            this.lstGlobalInvalid.Size = new System.Drawing.Size(343, 124);
            this.lstGlobalInvalid.TabIndex = 20;
            // 
            // cmdVar
            // 
            this.cmdVar.Location = new System.Drawing.Point(6, 191);
            this.cmdVar.Name = "cmdVar";
            this.cmdVar.Size = new System.Drawing.Size(75, 21);
            this.cmdVar.TabIndex = 24;
            this.cmdVar.Text = "Variables";
            this.cmdVar.UseVisualStyleBackColor = true;
            this.cmdVar.Click += new System.EventHandler(this.cmdVar_Click);
            // 
            // frmProps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 216);
            this.Controls.Add(this.cmdVar);
            this.Controls.Add(this.tabProps);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmProps";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmProps";
            this.Load += new System.EventHandler(this.frmProps_Load);
            this.tabProps.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSilent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRetry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDigits)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.TabControl tabProps;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblLabel;
        private System.Windows.Forms.TextBox txtLabel;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.ListBox lstRoute;
        private System.Windows.Forms.Label lblMaxDigit;
        private System.Windows.Forms.NumericUpDown numDigits;
        private System.Windows.Forms.NumericUpDown numRetry;
        private System.Windows.Forms.Label lblRetry;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label lblNoInput;
        private System.Windows.Forms.TextBox txtNoInput;
        private System.Windows.Forms.Label lblInvalid;
        private System.Windows.Forms.TextBox txtInvalidMsg;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.NumericUpDown numSilent;
        private System.Windows.Forms.Label lblSilent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdEdit;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ListBox lstGlobalTimeout;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.ListBox lstGlobalInvalid;
        private System.Windows.Forms.Button cmdRemoveGT;
        private System.Windows.Forms.Button cmdRemoveGI;
        private System.Windows.Forms.Button cmdVar;
    }
}