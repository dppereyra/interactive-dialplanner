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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Interaction.Graph
{
    public partial class frmProps : Form
    {
        private IActivity icon = null;
        private Dictionary<string, TempNode> mapTmpNode = new Dictionary<string, TempNode>();

        public frmProps()
        {
            InitializeComponent();
        }

        private void frmProps_Load(object sender, EventArgs e)
        {
            this.Text = Properties.Resources.ActivityName + " Properties";

            if (icon != null)
            {
                txtLabel.Text = icon.Description;

                if (icon.Values().ContainsKey("msgs"))
                {
                    txtMsg.Text = icon.Values()["msgs"];
                }
                if (icon.Values().ContainsKey("dtmf"))
                {
                    if (icon.Values()["dtmf"] == "1")
                    {
                        ckbDTMF.Checked = true;
                    }
                }
            }

        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (GraphContainer.Instance.FindDuplicateActivityDescription(icon.ActivityID, txtLabel.Text))
            {
                MessageBox.Show("Duplicated activity name");
                return;
            }

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        public IActivity Activities
        {
            get
            {
                return icon;
            }
            set
            {
                icon = value;
            }
        }

        public string Description
        {
            get
            {
                return txtLabel.Text;
            }

            set
            {
                txtLabel.Text = value;
            }
        }

        public int DTMF
        {
            get
            {
                if (ckbDTMF.Checked == true)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

            set
            {
                if (value == 1)
                {
                    ckbDTMF.Checked = true;
                }
                else
                {
                    ckbDTMF.Checked = false;
                }
            }
        }

        public string Messages
        {
            get
            {
                return txtMsg.Text;
            }

            set
            {
                txtMsg.Text = value;
            }
        }

        private void cmdVar_Click(object sender, EventArgs e)
        {
            GraphContainer.Instance.MaintainVariable();

        }

        private void txtMsg_DragDrop(object sender, DragEventArgs e)
        {
            string strVar = e.Data.GetData(DataFormats.Text).ToString();
            txtMsg.Text = strVar;
            GraphContainer.Instance.VariableMouseDown = false;

        }

        private void txtMsg_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
                e.Effect = DragDropEffects.None; 

        }

    }
}
