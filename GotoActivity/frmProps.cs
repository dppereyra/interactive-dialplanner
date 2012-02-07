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
        private Dictionary<string, IActivity> mapTmpNode = new Dictionary<string, IActivity>();
        private Dictionary<string, int> mapKey = new Dictionary<string, int>();
        private Dictionary<string, string> mapFlowName = new Dictionary<string, string>();

        private Dictionary<string, IActivity> mapActivity = new Dictionary<string, IActivity>();
        private Dictionary<string, int> mapActivityKey = new Dictionary<string, int>();

        private string strSelected = "";
        private bool isDeleteRelationship = false;
        private string strCurrentDocID = "";

        private string strGoToLabel = "";


        public frmProps()
        {
            InitializeComponent();
        }

        public string GotoLabel
        {
            get
            {
                return strGoToLabel;
            }

            set
            {
                strGoToLabel = value;
            }
        }

        private void frmProps_Load(object sender, EventArgs e)
        {
            Node toNode = null;
            this.Text = Properties.Resources.ActivityName + " Properties";

            if (icon != null)
            {
                Dictionary<string, Page> mapPage = GraphContainer.Instance.Pages;
                Dictionary<string, Page>.Enumerator ee = mapPage.GetEnumerator();

                while (ee.MoveNext())
                {
                    KeyValuePair<string, Page> item = ee.Current;
                    int j = lstGoTo.Items.Add(item.Value.FlowName);
                    mapKey[item.Value.Entry.EntryNode.NodeName] = j;
                    mapFlowName[item.Value.FlowName] = item.Key;
                }

                txtLabel.Text = icon.Description;

                if (GraphContainer.Instance.NodeRelationship.ContainsKey(icon.Nodes[0] as Node))
                {
                    toNode = GraphContainer.Instance.NodeRelationship[icon.Nodes[0] as Node];
                    if (mapKey.ContainsKey(toNode.NodeName))
                    {
                        lstGoTo.SelectedIndex = mapKey[toNode.NodeName];
                    }
                }
                if (toNode != null)
                {
                    strCurrentDocID = toNode.DocID;
                }

                RefreshActivity();

                if (lstActivity.Items.Count > 0)
                {
                    if (mapActivity.ContainsKey(strGoToLabel))
                    {
                        int idx = mapActivityKey[strGoToLabel];
                        lstActivity.SelectedIndex = idx;
                    }

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

        public Dictionary<string, IActivity> Result
        {
            get
            {
                return mapTmpNode;
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (GraphContainer.Instance.FindDuplicateActivityDescription(icon.ActivityID, txtLabel.Text))
            {
                MessageBox.Show("Duplicated activity name");
                return;
            }

            if (lstActivity.SelectedItems.Count > 0)
            {
                string strActName = lstActivity.SelectedItems[0].ToString();
                IActivity lpAct = mapActivity[strActName];
                if (lpAct != null)
                {
                    strGoToLabel = lpAct.Description;
                }
                else
                {
                    MessageBox.Show("Please select activity.");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please select activity.");
                return;
            }

            if (lstGoTo.SelectedItems.Count > 0)
            {
                strSelected = lstGoTo.SelectedItems[0].ToString();
                string strKey = mapFlowName[strSelected];

                Page p = GraphContainer.Instance.GetPage(strKey);
                if (p != null)
                {
                    mapTmpNode[p.Entry.EntryNode.NodeName] = p.Entry;
                    isDeleteRelationship = false;
                }
            }
            else
            {
                MessageBox.Show("Please select flow.");
                return;
            }

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

        }

        private void cmdRemove_Click(object sender, EventArgs e)
        {
            isDeleteRelationship = true;
        }

        public bool RemoveRelationship
        {
            get
            {
                return isDeleteRelationship;
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

        private void lstGoTo_Click(object sender, EventArgs e)
        {

            if (lstGoTo.SelectedItems.Count > 0)
            {
                strSelected = lstGoTo.SelectedItems[0].ToString();
                string strKey = mapFlowName[strSelected];

                Page p = GraphContainer.Instance.GetPage(strKey);
                if (p != null)
                {
                    strCurrentDocID = p.DocID;
                }
            }

            RefreshActivity();
        }

        private void RefreshActivity()
        {
            lstActivity.Items.Clear();

            ArrayList lstAct = GraphContainer.Instance.Activities;
            foreach (IActivity act in lstAct)
            {
                if (act.DocID == strCurrentDocID)
                {
                    mapActivity[act.Description] = act;
                    int j = lstActivity.Items.Add(act.Description);
                    mapActivityKey[act.Description] = j;
                }
            }

        }

        private void lstActivity_Click(object sender, EventArgs e)
        {

        }
    }
}
