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

                if (icon.Values().ContainsKey("silent"))
                {
                    txtSilent.Value = Convert.ToInt32(icon.Values()["silent"]);
                }
                else
                {
                    txtSilent.Value = 0;
                }

                if (icon.Values().ContainsKey("duration"))
                {
                    txtDuration.Value = Convert.ToInt32(icon.Values()["duration"]);
                }
                else
                {
                    txtDuration.Value = 0;
                }

                if (icon.Values().ContainsKey("filename"))
                {
                    txtFileName.Text = icon.Values()["filename"];
                }
                else
                {
                    txtFileName.Text = "";
                }

                if (icon.Values().ContainsKey("options"))
                {
                    txtOptions.Text = icon.Values()["options"];
                }
                else
                {
                    txtOptions.Text = "";
                }

                if (icon.Values().ContainsKey("format"))
                {
                    string strFormat =icon.Values()["format"];
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

        public int Silent
        {
            get
            {
                return Convert.ToInt32(txtSilent.Value);
            }

            set
            {
                txtSilent.Value = value;
            }
        }

        public int Duration
        {
            get
            {
                return Convert.ToInt32(txtDuration.Value);
            }

            set
            {
                txtDuration.Value = value;
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
        public string Options
        {
            get
            {
                return txtOptions.Text;
            }

            set
            {
                txtOptions.Text = value;
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


        public string Format
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
