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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace DennisWuWorks.InteractiveBuilder
{
    public partial class frmSolutionExplorer : ToolWindow
    {
        public frmSolutionExplorer()
        {
            InitializeComponent();
        }

        protected override void OnRightToLeftLayoutChanged(EventArgs e)
        {
            treeView1.RightToLeftLayout = RightToLeftLayout;
        }

        public void CreateProjectNode(string str)
        {
            treeView1.Nodes.Add(str, str, 10);
        }

        public void CreateFlowNode(string str, string strDocID)
        {
            TreeNode node = new TreeNode(str, 12, 13);
            node.Tag = strDocID;
            treeView1.Nodes[0].Nodes.Add(node);
            treeView1.ExpandAll();
        }

        public void RemoveFlowNode(string strDocID)
        {
            TreeNode tmp = null;

            foreach (TreeNode node in treeView1.Nodes[0].Nodes)
            {
                if (((string)node.Tag) == strDocID)
                {
                    tmp = node;
                    break;
                }
            }

            if (tmp != null)
            {
                treeView1.Nodes[0].Nodes.Remove(tmp);
            }
        }

        public void Clear()
        {
            treeView1.Nodes[0].Nodes.Clear();
            treeView1.Nodes.Clear();

        }

        private void DummySolutionExplorer_Load(object sender, EventArgs e)
        {

        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            
            foreach (Form frm in MainForm.Instance.MdiChildren)
            {
                GraphDoc graphDoc = frm as GraphDoc;

                if (graphDoc.DocID == Convert.ToString(e.Node.Tag))
                {
                    graphDoc.BringToFront();
                    break;
                }
            }
        }

        public string ProjectName
        {
            get
            {
                return treeView1.Nodes[0].Text;
            }

            set
            {
                treeView1.Nodes[0].Text = value;
            }
        }

        public void ChangeSubFlowName(string strDocID, string str)
        {
            TreeNode tmp = null;

            foreach (TreeNode node in treeView1.Nodes[0].Nodes)
            {
                if (((string)node.Tag) == strDocID)
                {
                    tmp = node;
                    break;
                }
            }

            if (tmp != null)
            {
                tmp.Text = str;
            }

        }

        public void SelectNode(string strDocID)
        {
            try
            {
                foreach (TreeNode node in treeView1.Nodes[0].Nodes)
                {
                    if (((string)node.Tag) == strDocID)
                    {
                        node.Checked = true;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}