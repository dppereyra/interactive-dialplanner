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
using Interaction.Graph;


namespace DennisWuWorks.InteractiveBuilder
{
    public partial class frmDeleteFlow : Form
    {
        private Dictionary<string, string> mapFlowName = new Dictionary<string, string>();
        private Dictionary<string, int> mapKey = new Dictionary<string, int>();
        private string strSelected = "";
        private Page act = null;


        public frmDeleteFlow()
        {
            InitializeComponent();
        }


        public Page DeletePage
        {
            get
            {
                return act;
            }

            set
            {
                act = value;
            }
        }

        private void frmDeleteFlow_Load(object sender, EventArgs e)
        {
            Dictionary<string, Page> mapPage = GraphContainer.Instance.Pages;
            Dictionary<string, Page>.Enumerator ee = mapPage.GetEnumerator();

            while (ee.MoveNext())
            {
                KeyValuePair<string, Page> item = ee.Current;

                int j = lstGoTo.Items.Add(item.Value.FlowName);
                mapKey[item.Value.DocID] = j;
                mapFlowName[item.Value.FlowName] = item.Key;
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;

                if (lstGoTo.SelectedItems.Count > 0)
                {
                    string strSelected = lstGoTo.SelectedItems[0].ToString();
                    string strKey = mapFlowName[strSelected];

                    Page p = GraphContainer.Instance.GetPage(strKey);
                    if (p != null)
                    {
                        act = p;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            return;
        }
    }
}
