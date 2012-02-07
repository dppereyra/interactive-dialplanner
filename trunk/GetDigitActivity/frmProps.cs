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
        private Dictionary<string, TempNode> mapTmpNode = new Dictionary<string, TempNode>();
        private Dictionary<int, string> mapKey = new Dictionary<int, string>();

        private Dictionary<string, int> mapKeyGlobalTimeout = new Dictionary<string, int>();
        private Dictionary<string, string> mapGlobalTimeoutFlowName = new Dictionary<string, string>();
        private Dictionary<string, int> mapKeyGlobalInvalid = new Dictionary<string, int>();
        private Dictionary<string, string> mapGlobalInvalidFlowName = new Dictionary<string, string>();

        private Node nodeGlobalTimeout = null;
        private Node nodeGlobalInvalid = null;

        public frmProps()
        {
            InitializeComponent();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            frmRouting routing = new frmRouting();
            routing.ShowDialog();

            if (routing.DigitMask.Trim().Length > 0)
            {
                string strKey = System.Guid.NewGuid().ToString();
                TempNode tt = new TempNode();
                tt.NodeName = strKey;
                tt.NodeText = routing.Description.Trim();
                tt.NodeValue = routing.DigitMask.Trim();
                tt.Status = 1;
                mapTmpNode[strKey] = tt;

                string strTmpVal = String.Format("{0}\t{1}", new object[] { tt.NodeText, tt.NodeValue });
                int j = lstRoute.Items.Add(strTmpVal);
                mapKey[j] = tt.NodeName;

            }

        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            for (int i = lstRoute.SelectedItems.Count - 1; i >= 0; i--)
            {
                TempNode tn = FindNode(lstRoute.SelectedItems[i].ToString());
                if (tn != null)
                {
                    tn.Status = 3;
                }
                lstRoute.Items.Remove(lstRoute.SelectedItems[i]);
            }

        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (GraphContainer.Instance.FindDuplicateActivityDescription(icon.ActivityID, txtLabel.Text))
            {
                MessageBox.Show("Duplicated activity name");
                return;
            }

            DialogResult = DialogResult.OK;

            if (this.lstGlobalTimeout.SelectedItems.Count > 0)
            {
                string strSelected = lstGlobalTimeout.SelectedItems[0].ToString();
                string strKey = mapGlobalTimeoutFlowName[strSelected];

                Page p = GraphContainer.Instance.GetPage(strKey);
                if (p != null)
                {
                    nodeGlobalTimeout = p.Entry.EntryNode;
                }
            }


            if (this.lstGlobalInvalid.SelectedItems.Count > 0)
            {
                string strSelected = lstGlobalInvalid.SelectedItems[0].ToString();
                string strKey = mapGlobalInvalidFlowName[strSelected];

                Page p = GraphContainer.Instance.GetPage(strKey);
                if (p != null)
                {
                    nodeGlobalInvalid = p.Entry.EntryNode;
                }
            }

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
            this.Text = Properties.Resources.ActivityName + " Properties";

            try
            {
                if (icon != null)
                {
                    ArrayList lst = icon.Nodes;
                    foreach (Node n in lst)
                    {
                        TempNode tt = new TempNode();
                        tt.NodeName = n.NodeName;
                        tt.NodeText = n.Text;
                        tt.NodeValue = n.NodeValue;

                        mapTmpNode[n.NodeName] = tt;
                        string strTmpVal = String.Format("{0}\t{1}", new object[] { tt.NodeText, tt.NodeValue });
                        int j = lstRoute.Items.Add(strTmpVal);

                        mapKey[j] = tt.NodeName;
                    }
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

                    if (icon.Values().ContainsKey("invalidmsg"))
                    {
                        txtInvalidMsg.Text = icon.Values()["invalidmsg"];
                    }
                    else
                    {
                        txtInvalidMsg.Text = "";
                    }

                    if (icon.Values().ContainsKey("noinputmsg"))
                    {
                        txtNoInput.Text = icon.Values()["noinputmsg"];
                    }
                    else
                    {
                        txtNoInput.Text = "";
                    }

                    if (icon.Values().ContainsKey("globaltimeout"))
                    {
                        if (icon.Values()["globaltimeout"].Length > 0)
                        {
                            nodeGlobalTimeout = GraphContainer.Instance.Nodes[icon.Values()["globaltimeout"]];
                        }
                        else
                        {
                            nodeGlobalTimeout = null;
                        }
                    }
                    else
                    {
                        nodeGlobalTimeout = null;
                    }

                    if (icon.Values().ContainsKey("globalinvalid"))
                    {
                        if (icon.Values()["globalinvalid"].Length > 0)
                        {
                            nodeGlobalInvalid = GraphContainer.Instance.Nodes[icon.Values()["globalinvalid"]];
                        }
                        else
                        {
                            nodeGlobalInvalid = null;
                        }
                    }
                    else
                    {
                        nodeGlobalInvalid = null;
                    }

                    Dictionary<string, Page> mapPage = GraphContainer.Instance.Pages;
                    Dictionary<string, Page>.Enumerator ee = mapPage.GetEnumerator();

                    while (ee.MoveNext())
                    {
                        KeyValuePair<string, Page> item = ee.Current;
                        if (icon.DocID != item.Value.DocID)
                        {
                            int j = lstGlobalTimeout.Items.Add(item.Value.FlowName);
                            mapKeyGlobalTimeout[item.Value.Entry.EntryNode.NodeName] = j;
                            mapGlobalTimeoutFlowName[item.Value.FlowName] = item.Key;

                            int k = lstGlobalInvalid.Items.Add(item.Value.FlowName);
                            mapKeyGlobalInvalid[item.Value.Entry.EntryNode.NodeName] = k;
                            mapGlobalInvalidFlowName[item.Value.FlowName] = item.Key;
                        }
                    }


                    if (nodeGlobalTimeout != null)
                    {
                        lstGlobalTimeout.SelectedIndex = mapKeyGlobalTimeout[nodeGlobalTimeout.NodeName];
                    }

                    if (nodeGlobalInvalid != null)
                    {
                        lstGlobalInvalid.SelectedIndex = mapKeyGlobalInvalid[nodeGlobalInvalid.NodeName];
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

        public Dictionary<string, TempNode> Result
        {
            get
            {
                return mapTmpNode;
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

        public string InvalidMessage
        {
            get
            {
                return txtInvalidMsg.Text;
            }

            set
            {
                txtInvalidMsg.Text = value;
            }
        }

        public string NoInputMessage
        {
            get
            {
                return txtNoInput.Text;
            }

            set
            {
                txtNoInput.Text = value;
            }
        }

        public string GlobalTimeout
        {
            get
            {
                string ret = "";

                if (nodeGlobalTimeout != null)
                {
                    ret = nodeGlobalTimeout.NodeName;
                }
                return ret;
            }
        }

        public string GlobalInvalid
        {
            get
            {
                string ret = "";

                if (nodeGlobalInvalid != null)
                {
                    ret = nodeGlobalInvalid.NodeName;
                }
                return ret;
            }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (lstRoute.SelectedIndices.Count > 0)
            {
                int k = lstRoute.SelectedIndices[0];
                string strKey = mapKey[k];
                TempNode tt = mapTmpNode[strKey];

                frmRouting routing = new frmRouting();
                routing.ID = strKey;
                routing.DigitMask = tt.NodeValue;
                routing.Description = tt.NodeText;
                routing.ShowDialog();

                if (routing.DigitMask.Trim().Length > 0)
                {
                    tt.NodeText = routing.Description.Trim();
                    tt.NodeValue = routing.DigitMask.Trim();
                    tt.Status = 2;
                    mapTmpNode[strKey] = tt;

                    string strTmpVal = String.Format("{0}\t{1}", new object[] { tt.NodeText, tt.NodeValue });
                    lstRoute.Items[k] = strTmpVal;
                }
            }

        }

        private void cmdRemoveGT_Click(object sender, EventArgs e)
        {
            lstGlobalTimeout.SelectedItems.Clear();
        }

        private void cmdRemoveGI_Click(object sender, EventArgs e)
        {
            lstGlobalInvalid.SelectedItems.Clear();
        }

        private void cmdVar_Click(object sender, EventArgs e)
        {
            GraphContainer.Instance.MaintainVariable();
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

        private void txtInvalidMsg_DragDrop(object sender, DragEventArgs e)
        {
            string strVar = e.Data.GetData(DataFormats.Text).ToString();
            txtInvalidMsg.Text = strVar;
            GraphContainer.Instance.VariableMouseDown = false;

        }

        private void txtInvalidMsg_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
                e.Effect = DragDropEffects.None; 

        }

        private void txtNoInput_DragDrop(object sender, DragEventArgs e)
        {
            string strVar = e.Data.GetData(DataFormats.Text).ToString();
            txtNoInput.Text = strVar;
            GraphContainer.Instance.VariableMouseDown = false;

        }

        private void txtNoInput_DragEnter(object sender, DragEventArgs e)
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
