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

        public frmProps()
        {
            InitializeComponent();
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim().Length > 0)
            {
                string strKey = System.Guid.NewGuid().ToString();
                TempNode tt = new TempNode();
                tt.NodeName = strKey;
                tt.NodeText = textBox1.Text.Trim();
                tt.Status = 1;
                mapTmpNode[strKey] = tt;
                listBox1.Items.Add(tt.NodeText);

                textBox1.Text = "";
            }

        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            for (int i = listBox1.SelectedItems.Count - 1; i >= 0; i--)
            {
                TempNode tn = FindNode(listBox1.SelectedItems[i].ToString());
                if (tn != null)
                {
                    tn.Status = 3;
                }
                listBox1.Items.Remove(listBox1.SelectedItems[i]);
            }

        }

        private void cmdOK_Click(object sender, EventArgs e)
        {

        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {

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
                ArrayList lst = icon.Nodes;
                foreach (Node n in lst)
                {
                    TempNode tt = new TempNode();
                    tt.NodeName = n.NodeName;
                    tt.NodeText = n.Text;

                    mapTmpNode[n.NodeName] = tt;
                    listBox1.Items.Add(n.Text);
                }
                textBox2.Text = icon.Description;
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
                return textBox2.Text;
            }

            set
            {
                textBox2.Text = value;
            }
        }

    }
}
