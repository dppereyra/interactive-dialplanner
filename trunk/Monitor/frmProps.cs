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
        private Dictionary<string, int> mapKey = new Dictionary<string, int>();

        public frmProps()
        {
            InitializeComponent();
            mapKey["wav"] = 0;
            mapKey["WAV"] = 1;
            mapKey["gsm"] = 2;
            mapKey["ulaw"] = 3;
            mapKey["alaw"] = 4;
            mapKey["g729"] = 5;

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



        private void frmProps_Load(object sender, EventArgs e)
        {
            this.Text = Properties.Resources.ActivityName + " Properties";

            if (icon != null)
            {
                txtLabel.Text = icon.Description;

                if (icon.Values().ContainsKey("bridge"))
                {
                    if (Convert.ToInt32(icon.Values()["bridge"]) == 1)
                    {
                        ckbBridgeOnly.Checked = true;
                    }
                    else
                    {
                        ckbBridgeOnly.Checked = false;
                    }
                }
                else
                {
                    ckbBridgeOnly.Checked = false;
                }

                if (icon.Values().ContainsKey("append"))
                {
                    if (Convert.ToInt32(icon.Values()["append"]) == 1)
                    {
                        ckbAppend.Checked = true;
                    }
                    else
                    {
                        ckbAppend.Checked = false;
                    }
                }
                else
                {
                    ckbAppend.Checked = false;
                }

                if (icon.Values().ContainsKey("spokevolume"))
                {
                    txtSpokeVolume.Value = Convert.ToInt32(icon.Values()["spokevolume"]);
                }
                else
                {
                    txtSpokeVolume.Value = 0;
                }

                if (icon.Values().ContainsKey("heardvolume"))
                {
                    txtHeardVolume.Value = Convert.ToInt32(icon.Values()["heardvolume"]);
                }
                else
                {
                    txtHeardVolume.Value = 0;
                }

                if (icon.Values().ContainsKey("overallvolume"))
                {
                    txtOverallVolume.Value = Convert.ToInt32(icon.Values()["overallvolume"]);
                }
                else
                {
                    txtOverallVolume.Value = 0;
                }

                if (icon.Values().ContainsKey("filename"))
                {
                    txtFileName.Text = icon.Values()["filename"];
                }
                else
                {
                    txtFileName.Text = "";
                }

                if (icon.Values().ContainsKey("cmd"))
                {
                    txtCmd.Text = icon.Values()["cmd"];
                }
                else
                {
                    txtCmd.Text = "";
                }

                if (icon.Values().ContainsKey("ext"))
                {
                    string strFormat = icon.Values()["ext"];
                    if(mapKey.ContainsKey(strFormat))
                    {
                        cboFormat.SelectedIndex = mapKey[strFormat];
                    }
                    else
                    {
                        cboFormat.SelectedIndex = 0;
                    }
                }
                else
                {
                    cboFormat.SelectedIndex = 0;
                }
            
            }

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

        public int BridgeOnly
        {
            get
            {
                if (ckbBridgeOnly.Checked == true)
                {
                    return 1;
                }

                return 0;
            }

            set
            {
                if (value == 1)
                {
                    ckbBridgeOnly.Checked = true;
                }
                else
                {
                    ckbBridgeOnly.Checked = false;
                }
            }
        }

        public int AppendFile
        {
            get
            {
                if (ckbAppend.Checked == true)
                {
                    return 1;
                }

                return 0;
            }

            set
            {
                if (value == 1)
                {
                    ckbAppend.Checked = true;
                }
                else
                {
                    ckbAppend.Checked = false;
                }
            }
        }

        public int SpokeVolume
        {
            get
            {
                return Convert.ToInt32(txtSpokeVolume.Value);
            }

            set
            {
                txtSpokeVolume.Value = value;
            }
        }

        public int HeardVolume
        {
            get
            {
                return Convert.ToInt32(txtHeardVolume.Value);
            }

            set
            {
                txtHeardVolume.Value = value;
            }
        }

        public int OverallVolume
        {
            get
            {
                return Convert.ToInt32(txtOverallVolume.Value);
            }

            set
            {
                txtOverallVolume.Value = value;
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
        public string Command
        {
            get
            {
                return txtCmd.Text;
            }

            set
            {
                txtCmd.Text = value;
            }
        }


        public string FileName
        {
            get
            {
                return txtFileName.Text;
            }

            set
            {
                txtFileName.Text = value;
            }
        }


        public string Extension
        {
            get
            {
                return cboFormat.Text;
            }

        }

        private void cmdVar_Click(object sender, EventArgs e)
        {
            GraphContainer.Instance.MaintainVariable();

        }

        private void txtFileName_DragDrop(object sender, DragEventArgs e)
        {
            string strVar = e.Data.GetData(DataFormats.Text).ToString();
            txtFileName.Text = strVar;
            GraphContainer.Instance.VariableMouseDown = false;

        }

        private void txtFileName_DragEnter(object sender, DragEventArgs e)
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
