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
using System.Text.RegularExpressions;
using Interaction.Graph;

namespace DennisWuWorks.InteractiveBuilder
{
    public partial class frmTaskList : ToolWindow
    {
        delegate void CompileOutputCallback(string text);

        public frmTaskList()
        {
            InitializeComponent();
        }

        public void WriteLine(string str)
        {
            CompileOutputCallback d = new CompileOutputCallback(InternalWriteLine);
            this.Invoke(d, new object[] { str });
        }

        private void InternalWriteLine(string str)
        {
            string strflow = "";
            string stractivity = "";
            try
            {
                if (str.Contains("variable"))
                {
                    Regex regex = new Regex(@"'");
                    string[] strItem = regex.Split(str);

                    strflow = strItem[3];
                    stractivity = strItem[1];
                }
            }
            catch (Exception ex)
            {
            }

            ListViewItem item = new ListViewItem(str);
            item.SubItems.Add(strflow);
            item.SubItems.Add(stractivity);
            lstTaskList.Items.Add(item);
        }

        public void Clear()
        {
            lstTaskList.Items.Clear();
        }

        private void lstTaskList_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                ListViewItem item = lstTaskList.SelectedItems[0];
                if (item != null)
                {
                    MainForm frm = ParentForm as MainForm;
                    frm.FindActivity2(item.SubItems[1].Text, item.SubItems[2].Text);
                    
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}