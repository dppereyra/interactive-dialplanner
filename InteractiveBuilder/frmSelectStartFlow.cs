﻿/******************************************************************************************
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
    public partial class frmSelectStartFlow : Form
    {
        private Dictionary<string, string> mapFlowName = new Dictionary<string, string>();
        private Dictionary<string, int> mapKey = new Dictionary<string, int>();
        private string strSelected = "";
        private IActivity act = null;
        private int fromType = 0;
        private Page selectPage = null;

        public frmSelectStartFlow()
        {
            InitializeComponent();
        }

        public int FromType
        {
            set
            {
                fromType = value;
            }
            get
            {
                return fromType;
            }
        }

        public Page SelectedPage
        {
            get
            {
                return selectPage;
            }
        }

        public IActivity StartActivity
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

        private void frmSelectStartFlow_Load(object sender, EventArgs e)
        {
            if (fromType == 0)
            {
                this.Text = "Select Start of Call Flow";
            }
            else
            {
                this.Text = "Find Sub Call Flow";
            }

            Dictionary<string, Page> mapPage = GraphContainer.Instance.Pages;
            Dictionary<string, Page>.Enumerator ee = mapPage.GetEnumerator();

            while (ee.MoveNext())
            {
                KeyValuePair<string, Page> item = ee.Current;

                int j = lstGoTo.Items.Add(item.Value.FlowName);
                mapKey[item.Value.Entry.ActivityID] = j;
                mapFlowName[item.Value.FlowName] = item.Key;
            }

            if (fromType == 0)
            {
                if (act != null)
                {
                    if (mapKey.ContainsKey(act.ActivityID))
                    {
                        lstGoTo.SelectedIndex = mapKey[act.ActivityID];
                    }
                }
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (lstGoTo.SelectedItems.Count > 0)
            {
                string strSelected = lstGoTo.SelectedItems[0].ToString();
                string strKey = mapFlowName[strSelected];

                Page p = GraphContainer.Instance.GetPage(strKey);
                if (p != null)
                {
                    selectPage = p;
                    act = p.Entry;
                }
                else
                {
                    MessageBox.Show("Error", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }


    }
}
