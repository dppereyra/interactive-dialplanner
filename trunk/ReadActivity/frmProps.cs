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

        public frmProps()
        {
            InitializeComponent();
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

            try
            {
                if (icon != null)
                {
                    txtLabel.Text = icon.Description;


                    if (icon.Values().ContainsKey("maxdigit"))
                    {
                        numDigits.Value = Convert.ToInt32(icon.Values()["maxdigit"]);
                    }
                    else
                    {
                        numDigits.Value = 1;
                    }

                    if (icon.Values().ContainsKey("retry"))
                    {
                        numRetry.Value = Convert.ToInt32(icon.Values()["retry"]);
                    }
                    else
                    {
                        numRetry.Value = 3;
                    }

                    if (icon.Values().ContainsKey("silent"))
                    {
                        numSilent.Value = Convert.ToInt32(icon.Values()["silent"]);
                    }
                    else
                    {
                        numSilent.Value = 5;
                    }

                    if (icon.Values().ContainsKey("entrymsg"))
                    {
                        txtMsg.Text = icon.Values()["entrymsg"];
                    }
                    else
                    {
                        txtMsg.Text = "";
                    }

                    if (icon.Values().ContainsKey("options"))
                    {
                        txtOptions.Text = icon.Values()["options"];
                    }
                    else
                    {
                        txtOptions.Text = "";
                    }

                    if (icon.Values().ContainsKey("variable"))
                    {
                        txtVariable.Text = icon.Values()["variable"];
                    }
                    else
                    {
                        txtVariable.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
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

        public decimal MaxDigit
        {
            get
            {
                return numDigits.Value;
            }
            set
            {
                numDigits.Value = value;
            }
        }

        public decimal MaxRetry
        {
            get
            {
                return numRetry.Value;
            }
            set
            {
                numRetry.Value = value;
            }
        }

        public decimal MaxSilent
        {
            get
            {
                return numSilent.Value;
            }
            set
            {
                numSilent.Value = value;
            }
        }

        public string EntryMessage
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

        public string Variable
        {
            get
            {
                return txtVariable.Text;
            }

            set
            {
                txtVariable.Text = value;
            }
        }

        private void cmdVar_Click(object sender, EventArgs e)
        {
            GraphContainer.Instance.MaintainVariable();
        }

        private void txtVariable_DragDrop(object sender, DragEventArgs e)
        {
            string strVar = e.Data.GetData(DataFormats.Text).ToString();
            txtVariable.Text = strVar;
            GraphContainer.Instance.VariableMouseDown = false;
        }

        private void txtVariable_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
                e.Effect = DragDropEffects.None;
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
