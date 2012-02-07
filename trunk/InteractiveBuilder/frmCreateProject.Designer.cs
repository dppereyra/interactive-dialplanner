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
namespace DennisWuWorks.InteractiveBuilder
{
    partial class frmCreateProject
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
            this.txtProject = new System.Windows.Forms.TextBox();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.lblProject = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtExt = new System.Windows.Forms.TextBox();
            this.ckbRemoteUpdate = new System.Windows.Forms.CheckBox();
            this.grpRemote = new System.Windows.Forms.GroupBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCmd = new System.Windows.Forms.TextBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.NumericUpDown();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblHost = new System.Windows.Forms.Label();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.grpRemote.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPort)).BeginInit();
            this.SuspendLayout();
            // 
            // txtProject
            // 
            this.txtProject.Location = new System.Drawing.Point(102, 11);
            this.txtProject.Name = "txtProject";
            this.txtProject.Size = new System.Drawing.Size(250, 22);
            this.txtProject.TabIndex = 1;
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(196, 295);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(75, 21);
            this.cmdOK.TabIndex = 21;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(277, 295);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 21);
            this.cmdCancel.TabIndex = 22;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // lblProject
            // 
            this.lblProject.AutoSize = true;
            this.lblProject.Location = new System.Drawing.Point(2, 14);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(43, 12);
            this.lblProject.TabIndex = 0;
            this.lblProject.Text = "Project :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Description :";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(102, 35);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(250, 22);
            this.txtDesc.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Version :";
            // 
            // txtVersion
            // 
            this.txtVersion.Location = new System.Drawing.Point(102, 59);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(250, 22);
            this.txtVersion.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "Default Extension :";
            // 
            // txtExt
            // 
            this.txtExt.Location = new System.Drawing.Point(102, 83);
            this.txtExt.Name = "txtExt";
            this.txtExt.Size = new System.Drawing.Size(250, 22);
            this.txtExt.TabIndex = 7;
            this.txtExt.Text = "s";
            // 
            // ckbRemoteUpdate
            // 
            this.ckbRemoteUpdate.AutoSize = true;
            this.ckbRemoteUpdate.Location = new System.Drawing.Point(12, 107);
            this.ckbRemoteUpdate.Name = "ckbRemoteUpdate";
            this.ckbRemoteUpdate.Size = new System.Drawing.Size(165, 16);
            this.ckbRemoteUpdate.TabIndex = 8;
            this.ckbRemoteUpdate.Text = "Using SSL for Remote Update";
            this.ckbRemoteUpdate.UseVisualStyleBackColor = true;
            this.ckbRemoteUpdate.CheckedChanged += new System.EventHandler(this.ckbRemoteUpdate_CheckedChanged);
            // 
            // grpRemote
            // 
            this.grpRemote.Controls.Add(this.txtPass);
            this.grpRemote.Controls.Add(this.lblPass);
            this.grpRemote.Controls.Add(this.txtUserName);
            this.grpRemote.Controls.Add(this.lblUser);
            this.grpRemote.Controls.Add(this.label5);
            this.grpRemote.Controls.Add(this.txtCmd);
            this.grpRemote.Controls.Add(this.lblPath);
            this.grpRemote.Controls.Add(this.txtPath);
            this.grpRemote.Controls.Add(this.txtPort);
            this.grpRemote.Controls.Add(this.lblPort);
            this.grpRemote.Controls.Add(this.lblHost);
            this.grpRemote.Controls.Add(this.txtHost);
            this.grpRemote.Location = new System.Drawing.Point(12, 122);
            this.grpRemote.Name = "grpRemote";
            this.grpRemote.Size = new System.Drawing.Size(340, 168);
            this.grpRemote.TabIndex = 11;
            this.grpRemote.TabStop = false;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(70, 86);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(264, 22);
            this.txtPass.TabIndex = 16;
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(10, 89);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(54, 12);
            this.lblPass.TabIndex = 15;
            this.lblPass.Text = "Password: ";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(70, 62);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(264, 22);
            this.txtUserName.TabIndex = 14;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(10, 65);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(54, 12);
            this.lblUser.TabIndex = 13;
            this.lblUser.Text = "Username:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 12);
            this.label5.TabIndex = 19;
            this.label5.Text = "Command :";
            // 
            // txtCmd
            // 
            this.txtCmd.Location = new System.Drawing.Point(70, 134);
            this.txtCmd.Name = "txtCmd";
            this.txtCmd.Size = new System.Drawing.Size(264, 22);
            this.txtCmd.TabIndex = 20;
            this.txtCmd.Text = "/usr/sbin/asterisk -rx \"reload\"";
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(10, 113);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(51, 12);
            this.lblPath.TabIndex = 17;
            this.lblPath.Text = "File Path :";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(70, 110);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(264, 22);
            this.txtPath.TabIndex = 18;
            this.txtPath.Text = "/etc/asterisk";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(70, 40);
            this.txtPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(55, 22);
            this.txtPort.TabIndex = 12;
            this.txtPort.Value = new decimal(new int[] {
            22,
            0,
            0,
            0});
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(10, 42);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(30, 12);
            this.lblPort.TabIndex = 11;
            this.lblPort.Text = "Port :";
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.Location = new System.Drawing.Point(10, 16);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(32, 12);
            this.lblHost.TabIndex = 9;
            this.lblHost.Text = "Host :";
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(70, 13);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(264, 22);
            this.txtHost.TabIndex = 10;
            // 
            // frmCreateProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 326);
            this.Controls.Add(this.grpRemote);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtExt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtVersion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.lblProject);
            this.Controls.Add(this.ckbRemoteUpdate);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.txtProject);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCreateProject";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project";
            this.Load += new System.EventHandler(this.frmCreateProject_Load);
            this.grpRemote.ResumeLayout(false);
            this.grpRemote.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtProject;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Label lblProject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtExt;
        private System.Windows.Forms.CheckBox ckbRemoteUpdate;
        private System.Windows.Forms.GroupBox grpRemote;
        private System.Windows.Forms.Label lblHost;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.NumericUpDown txtPort;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCmd;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox txtUserName;
    }
}