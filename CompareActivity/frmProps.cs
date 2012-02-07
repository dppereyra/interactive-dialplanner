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
            mapKey["="] = 0;
            mapKey[">"] = 1;
            mapKey["<"] = 2;
            mapKey["!="] = 3;
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

                if (icon.Values().ContainsKey("variable1"))
                {
                    txtVariable1.Text = icon.Values()["variable1"];
                }
                else
                {
                    txtVariable1.Text = "";
                }

                if (icon.Values().ContainsKey("variable2"))
                {
                    txtVariable2.Text = icon.Values()["variable2"];
                }
                else
                {
                    txtVariable2.Text = "";
                }

                if (icon.Values().ContainsKey("operator"))
                {
                    string strOperator = icon.Values()["operator"];
                    if (mapKey.ContainsKey(strOperator))
                    {
                        cboOperator.SelectedIndex = mapKey[strOperator];
                    }
                    else
                    {
                        cboOperator.SelectedIndex = 0;
                    }
                }
                else
                {
                    cboOperator.SelectedIndex = 0;
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

        public string Variable1
        {
            get
            {
                return txtVariable1.Text;
            }

            set
            {
                txtVariable1.Text = value;
            }
        }
        public string Variable2
        {
            get
            {
                return txtVariable2.Text;
            }

            set
            {
                txtVariable2.Text = value;
            }
        }

        public string Operator
        {
            get
            {
                return this.cboOperator.Text;
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

        private void cmdVar_Click(object sender, EventArgs e)
        {
            GraphContainer.Instance.MaintainVariable();

        }

        private void txtVariable1_DragDrop(object sender, DragEventArgs e)
        {
            string strVar = e.Data.GetData(DataFormats.Text).ToString();
            txtVariable1.Text = strVar;
            GraphContainer.Instance.VariableMouseDown = false;

        }

        private void txtVariable1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
                e.Effect = DragDropEffects.None; 

        }

        private void txtVariable2_DragDrop(object sender, DragEventArgs e)
        {
            string strVar = e.Data.GetData(DataFormats.Text).ToString();
            txtVariable2.Text = strVar;
            GraphContainer.Instance.VariableMouseDown = false;

        }

        private void txtVariable2_DragEnter(object sender, DragEventArgs e)
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
