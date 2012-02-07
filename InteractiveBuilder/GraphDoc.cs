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
using System.IO;
using System.Xml;
using System.Xml.XPath;
using Interaction.Graph;

namespace DennisWuWorks.InteractiveBuilder
{
    public partial class GraphDoc : DockContent
    {
        private string strDocID = "";
        private string strFlowName = "";
        private string strTmpFile = "";
        private bool isClose = false;

        public GraphDoc()
        {
            InitializeComponent();
        }

        public bool IsClose
        {
            get
            {
                return isClose;
            }

            set
            {
                isClose = value;
            }
        }

        public string TmpFile
        {
            set
            {
                strTmpFile = value;
            }

            get
            {
                return strTmpFile;
            }
        }

        public string DocID
        {
            set
            {
                strDocID = value;
            }

            get
            {
                return strDocID;
            }
        }

        public string FlowName
        {
            set
            {
                strFlowName = value;
                this.Text = strFlowName;
            }

            get
            {
                return strFlowName;
            }
        }

        public void ResetPrint()
        {
            drawingBoard.ResetPrint();
        }

        public void ClearBackground()
        {
            drawingBoard.ClearBackground();
        }

        public void RestoreBackground()
        {
            drawingBoard.RestoreBackground();
        }

        public bool Print(System.Drawing.Printing.PrintPageEventArgs e)
        {
            return drawingBoard.PrintDrawing(e);
        }

        private void GraphDoc_Load(object sender, EventArgs e)
        {
            isClose = false;
            if (strDocID == "")
            {
                strDocID = System.Guid.NewGuid().ToString();
                this.drawingBoard.DocID = strDocID;
                this.drawingBoard.FlowName = strFlowName;
                this.drawingBoard.CreateEntry();
            }
            else
            {
                this.drawingBoard.DocID = strDocID;
                this.drawingBoard.FlowName = strFlowName;
                drawingBoard.LoadDocument(strTmpFile);
                strTmpFile = "";
            }

            GraphContainer.Instance.Pages[strDocID].Document = this;
        }

        private void GraphDoc_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void GraphDoc_DragDrop(object sender, DragEventArgs e)
        {

        }

        public void Redraw()
        {
            drawingBoard.Invalidate();
            this.Invalidate();
        }

        private void GraphDoc_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((e.CloseReason == CloseReason.UserClosing) && !isClose)
            {
                e.Cancel = true;
            }
            else
            {
                GraphContainer.Instance.RemovePage(this.strDocID);
            }
        }

        private void GraphDoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F4)
            {
            }
        }

        private void drawingBoard_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void GraphDoc_Activated(object sender, EventArgs e)
        {
            GraphContainer.Instance.PropertyGridObject.SelectedObject = null;
            ResizeDrawing();
            MainForm.Instance.SelectNode(this.strDocID);
        }

        public void HighlightActivity(IActivity act)
        {
            drawingBoard.HighLightActivity(act);
        }
        private void ResizeDrawing()
        {
            drawingBoard.Location = new Point(5, 5);
            drawingBoard.Width = this.Width - 10;
            drawingBoard.Height = this.Height - 20;
        }

        private void GraphDoc_ClientSizeChanged(object sender, EventArgs e)
        {
            ResizeDrawing();
        }

        public Control DrawingBoard
        {
            get
            {
                return drawingBoard as Control;
            }
        }
    }
}
