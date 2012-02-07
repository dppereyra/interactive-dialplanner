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
using System.Collections;
using Interaction.Graph;
using System.Threading;

namespace DennisWuWorks.InteractiveBuilder
{
    public partial class frmToolbox : ToolWindow
    {
        private ThreadStart loadingJob = null;
        private Thread loadingThread = null;

        delegate void ShowIconCallback(ListViewItem item);

        public frmToolbox()
        {
            InitializeComponent();
        }

        private void DummyToolbox_Load(object sender, EventArgs e)
        {
            loadingJob = new ThreadStart(LoadingActivityJob);
            loadingThread = new Thread(loadingJob);
            loadingThread.Start();
        }

        private void lvToolBox_MouseDown(object sender, MouseEventArgs e)
        {
            GraphContainer.Instance.ToolBoxMouseDown = true;
        }

        private void lvToolBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (!GraphContainer.Instance.ToolBoxMouseDown)
                return;

            if (e.Button == MouseButtons.Right)
                return;

            string str = GetItemText(lvToolBox);
            if (str == "")
                return;

            string strTick = String.Format("{0}", new object[] { DateTime.Now.Ticks });

            GraphContainer.Instance.Tick = strTick;

            lvToolBox.DoDragDrop(strTick + str, DragDropEffects.Copy | DragDropEffects.Move);

        }

        public string GetItemText(ListView LVIEW)
        {
            int nTotalSelected = LVIEW.SelectedIndices.Count;
            if (nTotalSelected <= 0) return "";
            IEnumerator selCol = LVIEW.SelectedItems.GetEnumerator();
            selCol.MoveNext();
            ListViewItem lvi = (ListViewItem)selCol.Current;
            string mDir = "";
            for (int i = 0; i < lvi.SubItems.Count; i++)
                mDir += lvi.SubItems[i].Text + ",";

            mDir = mDir.Substring(0, mDir.Length - 1);
            return mDir;
        }

        private void lvToolBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvToolBox_MouseUp(object sender, MouseEventArgs e)
        {
            GraphContainer.Instance.ToolBoxMouseDown = false;
        }

        private void LoadingActivityJob()
        {
            ArrayList lst = ActivityCreator.Instance.Bitmaps();

            foreach (ActivityCreator.ActivityIcon icon in lst)
            {
                imageList1.Images.Add(icon.icon);
            }

            for (int i = 0; i < imageList1.Images.Count; i++)
            {
                ActivityCreator.ActivityIcon aicon = (ActivityCreator.ActivityIcon)lst[i];

                ListViewItem item = new ListViewItem();
                item.Text = aicon.strName;
                item.ToolTipText = aicon.strName;
                item.ImageIndex = i;

                ShowIconCallback d = new ShowIconCallback(InternalShowIcon);
                this.Invoke(d, new object[] { item });


            }

        }

        private void InternalShowIcon(ListViewItem item)
        {
            lvToolBox.Items.Add(item);
        }

    }
}