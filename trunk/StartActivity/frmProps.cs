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
        private Dictionary<string, IActivity> mapTmpActivity = new Dictionary<string, IActivity>();
        private Dictionary<string, string> mapFlowName = new Dictionary<string, string>();
        private Dictionary<string, int> mapKey = new Dictionary<string, int>();

        private string strSelected = "";
        private bool isDeleteRelationship = false;

        public frmProps()
        {
            InitializeComponent();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (txtResult.Text.Trim().Length > 0)
            {
                string strKey = System.Guid.NewGuid().ToString();
                TempNode tt = new TempNode();
                tt.NodeName = strKey;
                tt.NodeText = txtResult.Text.Trim();
                tt.Status = 1;
                mapTmpNode[strKey] = tt;
                lstNodes.Items.Add(tt.NodeText);

                txtResult.Text = "";
            }

        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (lstNodes.Items.Count > 1)
            {

                for (int i = lstNodes.SelectedItems.Count - 1; i >= 0; i--)
                {
                    TempNode tn = FindNode(lstNodes.SelectedItems[i].ToString());
                    if (tn != null)
                    {
                        tn.Status = 3;
                    }
                    lstNodes.Items.Remove(lstNodes.SelectedItems[i]);
                }
            }
            else
            {
                MessageBox.Show("At least one node presented for the Start.");
            }

        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            this.Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

        }

        private TempNode FindNode(string strText)
        {
            TempNode tn = null;

            Dictionary<string, TempNode>.Enumerator en = mapTmpNode.GetEnumerator();

            while (en.MoveNext())
            {
                KeyValuePair<string, TempNode> val = en.Current;

                if (val.Value.NodeText == strText)
                {
                    tn = val.Value;
                    break;
                }
            }

            return tn;
        }

        private void frmProps_Load(object sender, EventArgs e)
        {
            if (icon != null)
            {
                this.Text = Properties.Resources.ActivityName + " Properties";

                ArrayList lst = icon.Nodes;
                foreach (Node n in lst)
                {
                    TempNode tt = new TempNode();
                    tt.NodeName = n.NodeName;
                    tt.NodeText = n.Text;
                    tt.NodeValue = n.NodeValue;

                    mapTmpNode[n.NodeName] = tt;
                    lstNodes.Items.Add(n.Text);
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

        public Dictionary<string, TempNode> NodeResult
        {
            get
            {
                return mapTmpNode;
            }
        }

        public Dictionary<string, IActivity> ActivityResult
        {
            get
            {
                return mapTmpActivity;
            }
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
                return "Start";
            }

            set
            {
            }
        }

    }
}
