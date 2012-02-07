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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DennisWuWorks.InteractiveBuilder
{
    public partial class frmCreateProject : Form
    {
        public frmCreateProject()
        {
            InitializeComponent();
        }

        public string Project
        {
            get
            {
                return txtProject.Text.Trim();
            }

            set
            {
                txtProject.Text = value;
            }
        }

        public string Description
        {
            get
            {
                return txtDesc.Text.Trim();
            }

            set
            {
                txtDesc.Text = value;
            }
        }

        public string Version
        {
            get
            {
                return txtVersion.Text.Trim();
            }

            set
            {
                txtVersion.Text = value;
            }
        }

        public string Extension
        {
            get
            {
                return txtExt.Text.Trim();
            }

            set
            {
                txtExt.Text = value;
            }
        }

        public string Host
        {
            get
            {
                return txtHost.Text.Trim();
            }

            set
            {
                txtHost.Text = value;
            }
        }

        public int Port
        {
            get
            {
                return Convert.ToInt32(txtPort.Value);
            }

            set
            {
                txtPort.Value = value;
            }
        }

        public string Path
        {
            get
            {
                return txtPath.Text.Trim();
            }

            set
            {
                txtPath.Text = value;
            }
        }

        public string Command
        {
            get
            {
                return txtCmd.Text.Trim();
            }

            set
            {
                txtCmd.Text = value;
            }
        }

        public bool RemoteConnection
        {
            get
            {
                return ckbRemoteUpdate.Checked;
            }

            set
            {
                ckbRemoteUpdate.Checked = value;
            }

        }

        private void frmCreateProject_Load(object sender, EventArgs e)
        {
            if (ckbRemoteUpdate.Checked)
            {
                grpRemote.Enabled = true;
            }
            else
            {
                grpRemote.Enabled = false;
            }
            
        }

        public string UserName
        {
            get
            {
                return txtUserName.Text;
            }

            set
            {
                txtUserName.Text = value;
            }
        }

        public string Password
        {
            get
            {
                return txtPass.Text;
            }

            set
            {
                txtPass.Text = value;
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (txtProject.Text.Trim().Length > 0)
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {

            }
        }

        private void ckbRemoteUpdate_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbRemoteUpdate.Checked)
            {
                grpRemote.Enabled = true;
            }
            else
            {
                grpRemote.Enabled = false;
            }
        }
    }
}
