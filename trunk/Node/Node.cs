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
using System.Text;
//using System.Windows.Forms;
using System.Drawing;


namespace Interaction.Graph
{
    public class Node
    {
        private IGraphEvent parent;
        private string nodeName;
        private int nodeWidth = 80;
        private int nodeHeight = 14;
        private int defaultNodeWidth = 85;
        private int defaultNodeHeight = 14;
        private bool allowDrop;
        private bool allowDraw;
        private Point lineNode = new Point(0, 0);
        private string strDocID = "";

        private Label lblNode;
        //private MouseEventHandler labelMouseUp;
        //private MouseEventHandler labelMouseDown;
        //private MouseEventHandler labelMouseMove;
        //private EventHandler labelMouseEnter;
        //private EventHandler labelMouseLeave;

        private object activity = null;
        private System.Windows.Forms.ToolTip labelsToolTip;
        private string strNodeValue = "";
        private bool highlight = false;

        public Node(Label l, IGraphEvent ge, bool allowDrop, bool allowDraw)
        {
            parent = ge;
            nodeName = l.Tag.ToString();
            lblNode = l;
            //lblNode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            //lblNode.AutoSize = false;
            lblNode.Size = new Size(nodeWidth, nodeHeight);

            //labelMouseUp = new MouseEventHandler(lblNode_MouseUp);
            //labelMouseDown = new MouseEventHandler(lblNode_MouseDown);
            //labelMouseMove = new MouseEventHandler(lblNode_MouseMove);
            //labelMouseEnter = new EventHandler(lblNode_MouseEnter);
            //labelMouseLeave = new EventHandler(lblNode_MouseLeave);

            //lblNode.MouseUp += labelMouseUp;
            //lblNode.MouseDown += labelMouseDown;
            //lblNode.MouseMove += labelMouseMove;
            //lblNode.MouseEnter += labelMouseEnter;
            //lblNode.MouseLeave += labelMouseLeave;

            this.allowDrop = allowDrop;
            this.allowDraw = allowDraw;

            this.labelsToolTip = new System.Windows.Forms.ToolTip();
            labelsToolTip.IsBalloon = true;

        }

        ~Node()
        {
            //labelMouseUp = null;
            //labelMouseDown = null;
            //labelMouseMove = null;
        }

        public bool HighLight
        {
            get
            {
                return highlight;
            }

            set
            {
                highlight = value;
            }
        }

        public string DocID
        {
            get
            {
                return strDocID;
            }
            set
            {
                strDocID = value;
            }
        }
        public void Remove()
        {
            labelsToolTip.RemoveAll();
            //lblNode.MouseUp -= labelMouseUp;
            //lblNode.MouseDown -= labelMouseDown;
            //lblNode.MouseMove -= labelMouseMove;
            //lblNode.MouseEnter -= labelMouseEnter;
            //lblNode.MouseLeave -= labelMouseLeave;
            //lblNode.Dispose();
        }

        public string NodeName
        {
            get
            {
                return nodeName;
            }
        }

        public string NodeValue
        {
            get
            {
                return strNodeValue;
            }

            set
            {
                strNodeValue = value;
            }
        }

        public Point LineNode
        {
            get
            {
                return lineNode;
            }

            set
            {
                lineNode = value;
            }
        }

        public bool AllowDrop
        {
            get
            {
                return allowDrop;
            }
        }

        public bool AllowDraw
        {
            get
            {
                return allowDraw;
            }
        }

        public Label Label
        {
            get
            {
                return lblNode;
            }
        }

        public string Text
        {
            get
            {
                return lblNode.Text;
            }

            set
            {
                lblNode.Text = value;
                //this.labelsToolTip.SetToolTip(this.lblNode, lblNode.Text);
            }
        }

        public int NodeWidth
        {
            get
            {
                return nodeWidth;
            }

            set
            {
                if (nodeWidth > value)
                {
                    nodeWidth = 80;
                }
                else
                {
                    nodeWidth = value;
                }
            }
        }

        public int NodeHeight
        {
            get
            {
                return nodeHeight;
            }
            set
            {
                if (nodeHeight > value)
                {
                    nodeHeight = 14;
                }
                else
                {
                    nodeHeight = value;
                }
            }
        }

        public int DefaultNodeWidth
        {
            get
            {
                return defaultNodeWidth;
            }
        }

        public int DefaultNodeHeight
        {
            get
            {
                return defaultNodeHeight;
            }
        }

        public void Align(System.Drawing.ContentAlignment align)
        {
            //lblNode.TextAlign = align;
        }

        public void Show()
        {
            //lblNode.Show();
        }

        //void lblNode_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        Label l = sender as Label;
        //        int x = l.Location.X + e.X;
        //        int y = l.Location.Y + e.Y;

        //        MouseEventArgs ee = new MouseEventArgs(e.Button, e.Clicks, x, y, e.Delta);
        //        parent.GraphMouseMove(sender, ee);
        //    }
        //}

        //void lblNode_MouseDown(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        Label l = sender as Label;
        //        int x = l.Location.X + e.X;
        //        int y = l.Location.Y + e.Y;

        //        MouseEventArgs ee = new MouseEventArgs(e.Button, e.Clicks, x, y, e.Delta);
        //        parent.GraphMouseDown(sender, ee);
        //    }

        //}

        //void lblNode_MouseUp(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        Label l = sender as Label;
        //        int x = l.Location.X + e.X;
        //        int y = l.Location.Y + e.Y;

        //        MouseEventArgs ee = new MouseEventArgs(e.Button, e.Clicks, x, y, e.Delta);
        //        parent.GraphMouseUp(sender, ee);
        //    }
        //}

        //void lblNode_MouseLeave(object sender, EventArgs e)
        //{
        //    Label l = sender as Label;

        //    parent.GraphMouseLeave(sender, e);
        //}

        //void lblNode_MouseEnter(object sender, EventArgs e)
        //{
        //    Label l = sender as Label;

        //    parent.GraphMouseEnter(sender, e);
        //}

        public object Activity
        {
            get
            {
                return activity;
            }

            set
            {
                activity = value;
            }
        }
    }

    public class Label
    {
        private string strText = "";
        private Point location = new Point();
        private object tag = "";
        private Size size = new Size();

        public int Width
        {
            get
            {
                return size.Width;
            }

            set
            {
                size.Width = value;
            }
        }

        public int Height
        {
            get
            {
                return size.Height;
            }

            set
            {
                size.Height = value;
            }
        }

        public object Tag
        {
            get
            {
                return tag;
            }

            set
            {
                tag = value;
            }
        }

        public string Text
        {
            get
            {
                return strText;
            }

            set
            {
                strText = value;
            }
        }

        public Point Location
        {
            get
            {
                return location;
            }

            set
            {
                location = value;
            }
        }

        public Size Size
        {
            get
            {
                return size;
            }

            set
            {
                size = value;
            }
        }

    }
}
