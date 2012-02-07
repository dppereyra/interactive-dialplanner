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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Interaction.Graph
{
    public partial class frmAddVar : Form
    {
        public frmAddVar()
        {
            InitializeComponent();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (txtVar.Text.Trim().Length > 0)
            {
                if (!IsNumeric(txtVar.Text.Trim()))
                {
                    foreach (string strVar in GraphContainer.Instance.Variable)
                    {
                        if (strVar == txtVar.Text.Trim())
                        {
                            break;
                        }
                    }
                    GraphContainer.Instance.Variable.Add(txtVar.Text.Trim());
                    GraphContainer.Instance.Variable.Sort();
                    this.Close();
                }
            }
            else
            {
            }
        }

        private void frmAddVar_Load(object sender, EventArgs e)
        {
            this.Text = "Add Variable";
        }

        public string Var
        {
            get
            {
                return txtVar.Text.Trim();
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            txtVar.Text = "";
        }

        private bool IsNumeric(string str)
        {
            bool ret = false;

            try
            {
                int i = Convert.ToInt32(str);
                ret = true;
            }
            catch (Exception ex)
            {
            }

            return ret;
        }
    }
}
