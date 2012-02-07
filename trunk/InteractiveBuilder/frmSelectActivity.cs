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
    public partial class frmSelectActivity : Form
    {
        private Dictionary<string, IActivity> mapActivity = new Dictionary<string, IActivity>();
        private Dictionary<string, int> mapKey = new Dictionary<string, int>();
       
        private IActivity act = null;

        public frmSelectActivity()
        {
            InitializeComponent();
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

        private void frmSelectActivity_Load(object sender, EventArgs e)
        {
            this.Text = "Find Activity";

            foreach (IActivity activity in GraphContainer.Instance.Activities)
            {
                mapActivity[activity.Description] = activity;
                int j = lstGoTo.Items.Add(activity.Description);
                mapKey[activity.Description] = j;
            }

        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (lstGoTo.SelectedItems.Count > 0)
            {
                string strSelected = lstGoTo.SelectedItems[0].ToString();
                if(mapActivity.ContainsKey(strSelected))
                {
                    act = mapActivity[strSelected];
                }
                else
                {
                    MessageBox.Show("Error", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }
    }
}
