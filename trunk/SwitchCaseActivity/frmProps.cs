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
        private Dictionary<int, string> mapKey = new Dictionary<int, string>();

        public frmProps()
        {
            InitializeComponent();
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
                string[] strTmp = lstRoute.SelectedItems[i].ToString().Split(new string[]{"\t"}, StringSplitOptions.None);
                TempNode tn = FindNode(strTmp[0]);
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

        public string Var
        {
            get
            {
                return txtVar.Text;
            }

            set
            {
                txtVar.Text = value;
            }
        }

        private void frmProps_Load(object sender, EventArgs e)
        {
            this.Text = Properties.Resources.ActivityName + " Properties";

            try
            {
                if (icon != null)
                {
                    if (icon.Values().ContainsKey("var"))
                    {
                        txtVar.Text = icon.Values()["var"];
                    }
                    else
                    {
                        txtVar.Text = "";
                    }

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

        private void cmdVar_Click(object sender, EventArgs e)
        {
            GraphContainer.Instance.MaintainVariable();
        }

        private void txtVar_DragDrop(object sender, DragEventArgs e)
        {
            string strVar = e.Data.GetData(DataFormats.Text).ToString();
            txtVar.Text = strVar;
            GraphContainer.Instance.VariableMouseDown = false;
        }

        private void txtVar_DragEnter(object sender, DragEventArgs e)
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
