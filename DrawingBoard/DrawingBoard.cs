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
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Runtime.InteropServices;

namespace Interaction.Graph
{
    public partial class DrawingBoard : UserControl, IGraphEvent, IDrawingBoard
    {
        private Pen blackPen = new Pen(Color.Black, 1);
        private Pen redPen = new Pen(Color.Red, 4);
        private Pen highLightSquarePen = new Pen(Color.Red, 2);
        private int mouseState;
        private IActivity tmpSquare;
        private Point delataPoint = new Point();
        private Line line = new Line();
        private string strDocID = "";
        private string strFlowName = "";
        private float _zoom = 1.0f;
        private Color backColor = Color.LightGreen;
        private Bitmap backImg = Properties.Resources.graphunit;
        private bool printGraph = false;
        private int printWaterMarkY = 0;
        private IActivity currentActivity;

        private Node highlightNode = null;

        /*
        private const int SB_HORZ = 0x0;
        private const int SB_VERT = 0x1;
        [DllImport("user32.dll")]
        static extern int SetScrollPos(IntPtr hWnd, int nBar, int nPos, bool bRedraw);

        private const int WM_VSCROLL = 0x115;
        private const int SB_THUMBPOSITION = 4;
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lparam);
        */

        public DrawingBoard()
        {
            InitializeComponent();
            //this.AutoScroll = false;
        }

        public void ResetPrint()
        {
            printGraph = false;
            printWaterMarkY = 0;
            currentActivity = null;
        }

        public void ReDraw()
        {
            this.Invalidate();
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

        public string FlowName
        {
            set
            {
                strFlowName = value;
            }

            get
            {
                return strFlowName;
            }
        }

        public void ClearBackground()
        {
            this.BackColor = Color.White;
            this.BackgroundImage = null;
        }

        public void RestoreBackground()
        {
            this.BackColor = Color.LightGreen;
            this.BackgroundImage = Properties.Resources.graphunit;
        }

        public void GraphMouseEnter(object sender, EventArgs e)
        {
            this.DrawingBoard_MouseEnter(sender, e);
        }

        public void GraphMouseLeave(object sender, EventArgs e)
        {
            this.DrawingBoard_MouseLeave(sender, e);
        }

        public void GraphMouseMove(object sender, MouseEventArgs e)
        {
            this.DrawingBoard_MouseMove(sender, e);
        }

        public void GraphMouseDown(object sender, MouseEventArgs e)
        {
            this.DrawingBoard_MouseDown(sender, e);
        }

        public void GraphMouseUp(object sender, MouseEventArgs e)
        {
            this.DrawingBoard_MouseUp(sender, e);
        }

        private void DrawingBoard_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
                e.Effect = DragDropEffects.None; 

        }

        private void DrawingBoard_DragDrop(object sender, DragEventArgs e)
        {
            string strIcon = e.Data.GetData(DataFormats.Text).ToString();
            string strActivity = "";

            if (strIcon.Contains(GraphContainer.Instance.Tick))
            {
                strActivity = strIcon.Remove(0, GraphContainer.Instance.Tick.Length);
            }
            GraphContainer.Instance.Tick = "";

            IActivity s = ActivityCreator.Instance.CreateActivity(strActivity.ToLower());
            if (s == null)
            {
                GraphContainer.Instance.ToolBoxMouseDown = false;
                return;
            }

            s.PreLoadIcon(this, this, new Point(e.X, e.Y));
            s.DocID = strDocID;

            if (s.ActivityName.ToLower() != "start")
            {
                int i = 1;
                while (true)
                {
                    string strTmpName = string.Format("{0}{1}", s.Description, i);

                    if (GraphContainer.Instance.FindDuplicateActivityDescription(s.ActivityID, strTmpName))
                    {
                        i++;
                    }
                    else
                    {
                        s.Description = strTmpName;
                        break;
                    }
                }
            }

            if (s.EntryNode != null)
            {
                GraphContainer.Instance.Nodes[s.EntryNode.NodeName] = s.EntryNode;
                GraphContainer.Instance.Nodes[s.EntryNode.NodeName].DocID = strDocID;
            }

            foreach (Node n1 in s.Nodes)
            {
                n1.DocID = strDocID;
                GraphContainer.Instance.Nodes[n1.NodeName] = n1;
            }

            GraphContainer.Instance.Activities.Add(s);
            this.Invalidate();
            GraphContainer.Instance.ToolBoxMouseDown = false;

        }

        public bool PrintDrawing(System.Drawing.Printing.PrintPageEventArgs e)
        {
            bool ret = true;
            float printWidth = 0;
            float factor = 0.9f;
            Point renderingOrgPt = new Point(0, 0);

            try
            {
                Graphics gfx = e.Graphics;

                if (printGraph == false)
                {
                    Font fontSubject = new Font("Arial", 14, FontStyle.Regular | FontStyle.Underline | FontStyle.Italic);
                    SizeF sizeText = gfx.MeasureString(this.FlowName, fontSubject);
                    gfx.DrawString(this.FlowName, fontSubject, Brushes.Black, new PointF(0.0f, 0.0f));

                    IActivity farX = GraphContainer.Instance.GetFarObjectX(this.strDocID);
                    IActivity farY = GraphContainer.Instance.GetFarObjectY(this.strDocID);

                    if (farX == null)
                    {
                        gfx.ScaleTransform(factor, factor);
                    }
                    else
                    {
                        printWidth = e.PageSettings.PrintableArea.Width;

                        if (printWidth < (farX.Position.X + 300))
                        {
                            factor = printWidth / (farX.Position.X + 300);
                            gfx.ScaleTransform(factor, factor);
                        }
                        else
                        {
                            gfx.ScaleTransform(factor, factor);
                        }
                    }

                    if (farY != null)
                    {
                        printWaterMarkY =  farY.Position.Y + 100 + (int)sizeText.Height;
                        if (e.PageSettings.PrintableArea.Height < printWaterMarkY)
                        {
                            if (MessageBox.Show("The graph printing out of bound.  Continue?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            {
                                e.Cancel = true;
                                return true;
                            }
                        }
                    }

                    Point pt = this.AutoScrollPosition;
                    this.SetScrollState(0, true);

                    renderingOrgPt.X = 0;
                    renderingOrgPt.Y = (int)sizeText.Height + 50;

                    gfx.TranslateTransform(renderingOrgPt.X, renderingOrgPt.Y);
                    foreach (IActivity s in GraphContainer.Instance.Activities)
                    {
                        if (s.DocID == strDocID)
                        {
                            gfx.DrawImage(s.Icon, s.Position);
                            s.AdjustNodePosition(pt, gfx);
                        }
                    }

                    Dictionary<Node, Node>.Enumerator ee = GraphContainer.Instance.NodeRelationship.GetEnumerator();
                    while (ee.MoveNext())
                    {
                        KeyValuePair<Node, Node> val = ee.Current;
                        if (val.Value != null)
                        {
                            Node n1 = val.Key;
                            Node n2 = val.Value;
                            Pen pen = null;
                            if (n1.DocID == strDocID)
                            {
                                if (n1.AllowDraw)
                                {
                                    if (n1.HighLight == true)
                                    {
                                        pen = redPen;
                                    }
                                    else
                                    {
                                        pen = blackPen;
                                    }
                                    DrawLineFunc(gfx, pen, n1, n2);
                                }
                            }
                        }
                    }

                    gfx.ResetTransform();
                    gfx.TranslateTransform(0, 0);

                    printWaterMarkY = (int)((float)printWaterMarkY * factor) + (int)sizeText.Height + 50;
                    gfx.DrawLine(Pens.Black, new Point((int)e.PageSettings.PrintableArea.Left, printWaterMarkY), new Point((int)e.PageSettings.PrintableArea.Right, printWaterMarkY));
                    printWaterMarkY += 20;
                    printGraph = true;

                }

                if (e.PageSettings.PrintableArea.Height < printWaterMarkY)
                {
                    ret = false;
                }
                else
                {
                    //Print contents
                    Font fontActivityName = new Font("Arial", 12, FontStyle.Bold | FontStyle.Underline);
                    Font fontActivityContent = new Font("Arial", 12, FontStyle.Regular);
                    
                    int tmpY = 0;
                    SizeF sz = gfx.MeasureString("A", fontActivityName);
                    tmpY = (int)sz.Height + 5;
                    sz = gfx.MeasureString("A", fontActivityContent);
                    tmpY = (int)sz.Height + 10;
                    
                    ArrayList lst = new ArrayList();
                    int tmpActCnt = 0;

                    foreach (IActivity s in GraphContainer.Instance.Activities)
                    {
                        if (s.DocID == strDocID)
                        {
                            lst.Add(s);
                        }
                    }

                    foreach (IActivity s in lst)
                    {
                        tmpActCnt++;

                        if (currentActivity != null)
                        {
                            if (currentActivity == s)
                            {
                                currentActivity = null;
                            }
                        }
                        else
                        {
                            if (lst.Count < tmpActCnt)
                            {
                                break;
                            }
                            else
                            {
                                if (e.PageSettings.PrintableArea.Height < printWaterMarkY + tmpY + 50)
                                {

                                    ret = false;
                                    currentActivity = s;
                                    printWaterMarkY = 0;
                                }
                                else
                                {
                                    string strContent = "";
                                    sz = gfx.MeasureString(s.Description, fontActivityName);
                                    gfx.DrawString(s.Description, fontActivityName, Brushes.Black, new PointF(0.0f, (float)printWaterMarkY));
                                    printWaterMarkY += (int)sz.Height + 5;

                                    strContent = string.Format("Activity: {0}", new object[] { s.ActivityName });
                                    sz = gfx.MeasureString(strContent, fontActivityContent);
                                    gfx.DrawString(strContent, fontActivityContent, Brushes.Black, new PointF(0.0f, (float)printWaterMarkY));
                                    printWaterMarkY += (int)sz.Height + 10;
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
            }

            return ret;

        }

        #region IDrawingBoard Members

        public Point PointToClient(int x, int y)
        {
            return this.PointToClient(new Point(x, y));
        }

        public void AddControl(Control value)
        {
            SuspendLayout();
            string strName = value.Tag as string;
            value.Name = strName;
            this.Controls.Add(value);
            ResumeLayout();
        }

        public void RemoveControl(Control value)
        {
            SuspendLayout();
            this.Controls.Remove(value);
            ResumeLayout();
        }

        public void CreateEntry()
        {
            IActivity s = ActivityCreator.Instance.CreateActivity("start");

            s.PreLoadIcon(this, this, this.PointToScreen(new Point(200, 300)));
            s.DocID = strDocID;

            if (s.EntryNode != null)
            {
                GraphContainer.Instance.Nodes[s.EntryNode.NodeName] = s.EntryNode;
                GraphContainer.Instance.Nodes[s.EntryNode.NodeName].DocID = strDocID;
                s.EntryNode.Text = this.strFlowName;
                Page p = new Page(strDocID, strFlowName, s);
                GraphContainer.Instance.AddPage(strDocID, p);

            }

            foreach (Node n1 in s.Nodes)
            {
                n1.DocID = strDocID;
                GraphContainer.Instance.Nodes[n1.NodeName] = n1;
            }

            GraphContainer.Instance.Activities.Add(s);
            this.Invalidate();
            GraphContainer.Instance.ToolBoxMouseDown = false;
        }

        #endregion

        private void DrawingBoard_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Graphics gfx = e.Graphics;
                
                Point pt = this.AutoScrollPosition;
                gfx.TranslateTransform(pt.X, pt.Y);

                this.SetScrollState(0, true);
                foreach (IActivity s in GraphContainer.Instance.Activities)
                {
                    if (s.DocID == strDocID)
                    {
                        gfx.DrawImage(s.Icon, s.Position);
                        s.AdjustNodePosition(pt, gfx);
                    }
                }

                foreach (IActivity ss in GraphContainer.Instance.ActivitySelections)
                {
                    if (ss.DocID == strDocID)
                    {
                        //high light icon
                        Point p1 = new Point(ss.Position.X, ss.Position.Y + ss.Height);
                        Point p2 = new Point(ss.Position.X + ss.Width, ss.Position.Y + ss.Height);
                        Point p3 = new Point(ss.Position.X + ss.Width, ss.Position.Y);

                        gfx.DrawLine(highLightSquarePen, ss.Position, p1);
                        gfx.DrawLine(highLightSquarePen, p1, p2);
                        gfx.DrawLine(highLightSquarePen, p2, p3);
                        gfx.DrawLine(highLightSquarePen, p3, ss.Position);
                    }
                }

                Dictionary<Node, Node>.Enumerator ee = GraphContainer.Instance.NodeRelationship.GetEnumerator();
                while (ee.MoveNext())
                {
                    KeyValuePair<Node, Node> val = ee.Current;
                    if (val.Value != null)
                    {
                        Node n1 = val.Key;
                        Node n2 = val.Value;
                        Pen pen = null;
                        if (n1.DocID == strDocID)
                        {
                            if (n1.AllowDraw)
                            {
                                if (n1.HighLight == true)
                                {
                                    pen = redPen;
                                }
                                else
                                {
                                    pen = blackPen;
                                }
                                DrawLineFunc(gfx, pen, n1, n2);
                            }
                        }
                    }
                }

                if (mouseState == 1)
                {
                    gfx.DrawLine(blackPen, line.Start, line.End);
                }

            }
            catch (Exception ex)
            {
            }

        }

        private void DrawLineFunc(Graphics g, Pen pen, Node n1, Node n2)
        {
            int delta1 = 10;
            int delta2 = 25;
            Point start = n1.LineNode;
            Point end = n2.LineNode;
            IActivity actStart = n1.Activity as IActivity;
            IActivity actEnd = n2.Activity as IActivity;
            int idx = actStart.Nodes.IndexOf(n1);

            if (idx > 0)
            {
                idx = idx * 5;
            }

            if ((end.Y == start.Y) && (start.X < end.X))
            {
                g.DrawLine(pen, start, end);
            }
            else if ((end.Y > start.Y) && (end.X > start.X))
            {
                Point p1 = start;
                Point p4 = end;
                Point p2 = new Point(p1.X + delta1 + idx, p1.Y);
                Point p3 = new Point(p2.X, end.Y);

                g.DrawLine(pen, p1, p2);
                g.DrawLine(pen, p2, p3);
                g.DrawLine(pen, p3, p4);

            }
            else if ((end.Y >= start.Y) && (end.X < start.X))
            {

                Point p1 = start;
                Point p6 = end;
                Point p2 = new Point(p1.X + delta1 + idx, p1.Y);
                //Point p3 = new Point(p2.X, p2.Y + (actStart.Height - (actStart.Position.Y - p2.Y)) + delta);
                Point p3 = new Point(p2.X, p2.Y + (actStart.Height - (p2.Y - actStart.Position.Y)) + delta2);
                Point p4 = new Point(p6.X - delta1, p3.Y);
                Point p5 = new Point(p4.X, p6.Y);

                g.DrawLine(pen, p1, p2);
                g.DrawLine(pen, p2, p3);
                g.DrawLine(pen, p3, p4);
                g.DrawLine(pen, p4, p5);
                g.DrawLine(pen, p5, p6);

            }
            else if ((end.Y < start.Y) && (end.X > start.X))
            {
                Point p1 = start;
                Point p4 = end;
                Point p2 = new Point(p1.X + delta1 + idx, p1.Y);
                Point p3 = new Point(p2.X, end.Y);

                g.DrawLine(pen, p1, p2);
                g.DrawLine(pen, p2, p3);
                g.DrawLine(pen, p3, p4);

            }
            else if ((end.Y < start.Y) && (end.X < start.X))
            {
                Point p1 = start;
                Point p6 = end;
                Point p2 = new Point(p1.X + delta1 + idx, p1.Y);

                Point p3 = new Point(p2.X, p2.Y - (actStart.Height - (actStart.Position.Y - p2.Y)) + delta2);
                Point p4 = new Point(p6.X - delta1, p3.Y);
                
                Point p5 = new Point(p4.X, p6.Y);

                g.DrawLine(pen, p1, p2);
                g.DrawLine(pen, p2, p3);
                g.DrawLine(pen, p3, p4);
                g.DrawLine(pen, p4, p5);
                g.DrawLine(pen, p5, p6);

            }
//            else if ((end.Y == start.Y) && (start.X > end.X))
//            {
//                g.DrawLine(pen, start, end);
//            }
            else
            {
                g.DrawLine(pen, start, end);
            }

        }

        private void DrawingBoard_MouseEnter(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            Node start = GraphContainer.Instance.FindNodeByLabel(lbl);

            if (start != null)
            {
                start.HighLight = true;
                this.Invalidate();
            }
        }

        private void DrawingBoard_MouseLeave(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            Node start = GraphContainer.Instance.FindNodeByLabel(lbl);

            if (start != null)
            {
                start.HighLight = false;
                this.Invalidate();
            }
        }

        public void HighLightActivity(object obj)
        {
            try
            {
                IActivity act = obj as IActivity;

                GraphContainer.Instance.ActivitySelections.Clear();
                GraphContainer.Instance.ActivitySelections.Add(act);

                Rectangle rect = new Rectangle(act.Position, new Size(act.Width, act.Height));
                Region region = new Region(rect);
                this.Invalidate(region);
                act.ShowProperty(GraphContainer.Instance.PropertyGridObject);
            }
            catch (Exception ex)
            {
            }
        }

        private void DrawingBoard_MouseDown(object sender, MouseEventArgs e)
        {
            Point p = GetVirtualMouseLocation(e);
            tmpSquare = CheckWithinImage(p);

            if (tmpSquare != null)
            {
                mouseState = 2;
                delataPoint = new Point(p.X, p.Y);

                GraphContainer.Instance.ActivitySelections.Clear();
                GraphContainer.Instance.ActivitySelections.Add(tmpSquare);

                Rectangle rect = new Rectangle(tmpSquare.Position, new Size(tmpSquare.Width, tmpSquare.Height));
                Region region = new Region(rect);
                this.Invalidate(region);

                tmpSquare.ShowProperty(GraphContainer.Instance.PropertyGridObject);
            }
            else
            {
                if (mouseState == 0)
                {
                    Point tmpStart = GetVirtualMouseLocation(e);
                    Point truePos = new Point(e.X, e.Y);
                    Node n = CheckWithinNode(tmpStart);

                    if (n != null)
                    {
                        if (!n.AllowDrop && n.AllowDraw)
                        {
                            mouseState = 1;
                            line.Start = n.LineNode;
                            line.TrueStart = tmpStart;
                        }
                    }
                }
                GraphContainer.Instance.PropertyGridObject.SelectedObject = null;
            }

        }

        private void DrawingBoard_MouseUp(object sender, MouseEventArgs e)
        {
            if (mouseState == 1)
            {
                Point p = GetVirtualMouseLocation(e);
                Point truePos = new Point(e.X, e.Y);
                Node n = CheckWithinNode(p);

                //Point tmpEnd = new Point(e.X, e.Y);

                if (n != null)
                {
                    if (n.AllowDrop)
                    {
                        line.End = p;
                        line.TrueEnd = p;

                        Line tmpLine = new Line();
                        tmpLine.Start = line.TrueStart;
                        tmpLine.End = line.TrueEnd;

                        AdjustStartEnd(tmpLine);


                    }
                }
                else
                {
                    //assume delete line
                    Node n1 = CheckWithinNode(line.TrueStart);
                    if (n1 != null)
                    {
                        GraphContainer.Instance.NodeRelationship.Remove(n1);
                    }

                }
                mouseState = 0;
            }
            else if (mouseState == 2)
            {
                int x = 0;
                int y = 0;
                Point tmpStart = GetVirtualMouseLocation(e);
                //x = e.X - (delataPoint.X - tmpSquare.Position.X);
                //y = e.Y - (delataPoint.Y - tmpSquare.Position.Y);
                x = tmpStart.X - (delataPoint.X - tmpSquare.Position.X);
                y = tmpStart.Y - (delataPoint.Y - tmpSquare.Position.Y);

                Point tp = new Point(x, y);
                UpdateImage(tmpSquare, tp);


                mouseState = 0;
            }

            this.Invalidate();
        }

        private void DrawingBoard_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseState == 1)
            {
                Point tmpStart = GetVirtualMouseLocation(e);
                line.End = new Point(tmpStart.X, tmpStart.Y);
                this.Invalidate();
            }
            else if (mouseState == 2)
            {
                int x = 0;
                int y = 0;
                Point tmpStart = GetVirtualMouseLocation(e);
                x = tmpStart.X - (delataPoint.X - tmpSquare.Position.X);
                y = tmpStart.Y - (delataPoint.Y - tmpSquare.Position.Y);

                Point tp = new Point(x, y);
                UpdateImage(tmpSquare, tp);

                //delataPoint = new Point(e.X, e.Y);
                delataPoint = new Point(tmpStart.X, tmpStart.Y);
                this.Invalidate();
            }
            else
            {
                Point tmpStart = GetVirtualMouseLocation(e);
                Point truePos = new Point(e.X, e.Y);
                Node n = CheckWithinNode(tmpStart);
                //Node n = CheckWithinNode(truePos);

                if (n != null)
                {
                    if (!n.AllowDrop && n.AllowDraw)
                    {
                        if (highlightNode != null)
                        {
                            highlightNode.HighLight = false;
                            this.Invalidate();
                        }
                        highlightNode = null;

                        n.HighLight = true;
                        highlightNode = n;
                        this.Invalidate();
                    }
                }
                else
                {
                    if (highlightNode != null)
                    {
                        highlightNode.HighLight = false;
                        this.Invalidate();
                    }
                    highlightNode = null;
                }
            }
        }

        public IActivity CheckWithinImage(Point p)
        {
            IActivity ret = null;

            foreach (IActivity s in GraphContainer.Instance.Activities)
            {
                if (s.DocID == strDocID)
                {
                    if ((p.X >= s.Position.X && p.X <= s.Position.X + s.Width)
                        && (p.Y >= s.Position.Y && p.Y <= s.Position.Y + s.Height))
                    {
                        ret = s;
                        break;
                    }
                }
            }

            return ret;
        }

        public Node CheckWithinNode(Point p)
        {
            Node ret = null;

            Dictionary<string, Node>.Enumerator ee = GraphContainer.Instance.Nodes.GetEnumerator();

            while (ee.MoveNext())
            {
                KeyValuePair<string, Node> val = ee.Current;

                if (val.Value != null)
                {
                    Node n = val.Value;

                    if (n.DocID == strDocID)
                    {
                        if ((p.X >= n.Label.Location.X && p.X <= (n.Label.Location.X + n.Label.Width))
                            && (p.Y >= n.Label.Location.Y && p.Y <= (n.Label.Location.Y + n.Label.Height)))
                        {
                            ret = val.Value;
                            break;
                        }
                    }
                }

            }
            return ret;
        }


        public Line AdjustStartEnd(Line l)
        {
            Line ret = new Line();
            Node n1 = CheckWithinNode(l.Start);
            Node n2 = CheckWithinNode(l.End);

            ret.Start = new Point(n1.Label.Location.X + n1.NodeWidth, n1.Label.Location.Y + (n1.NodeHeight / 2));
            ret.End = new Point(n2.Label.Location.X, n2.Label.Location.Y + (n1.NodeHeight / 2));

            n1.LineNode = ret.Start;
            n2.LineNode = ret.End;

            GraphContainer.Instance.NodeRelationship[n1] = n2;

            return ret;
        }

        public void UpdateImage(IActivity s, Point p)
        {
            if (p.X < 0)
            {
                p.X = 50;
            }
            if (p.Y < 0)
            {
                p.Y = 50;
            }
            s.Position = p;
        }

        protected Point GetVirtualMouseLocation(MouseEventArgs e)
        {
            string str = string.Format("Original = {0}, {1}", new object[] { e.X, e.Y});
            System.Diagnostics.Debug.WriteLine(str);

            //Creates the drawing matrix with the right zoom;
            Matrix mx = new Matrix(_zoom, 0, 0, _zoom, 0, 0);
            //pans it according to the scroll bars

            str = string.Format("AutoScroll = {0}, {1}", new object[] { this.AutoScrollPosition.X, this.AutoScrollPosition.Y });
            System.Diagnostics.Debug.WriteLine(str);

            mx.Translate(this.AutoScrollPosition.X * (1.0f / _zoom), this.AutoScrollPosition.Y * (1.0f / _zoom));
            //inverts it
            mx.Invert();

            //uses it to transform the current mouse position
            Point[] pa = new Point[] { new Point(e.X, e.Y) };
            mx.TransformPoints(pa);

            str = string.Format("Translate  = {0}, {1}", new object[] { pa[0].X, pa[0].Y });
            System.Diagnostics.Debug.WriteLine(str);

            return pa[0];
        }

        private void DrawingBoard_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mouseLocation = GetVirtualMouseLocation(e);
                IActivity tmp = CheckWithinImage(mouseLocation);

                if (tmp != null)
                {
                    try
                    {
                        GraphContainer.Instance.CloseMaintainVariable();
                        DialogResult dialogResult = tmp.ShowProperties();

                        if (dialogResult == DialogResult.OK)
                        {
                            tmp.DoAction(this, this);

                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }

        }

        private void DrawingBoard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                IActivity[] tmp = new IActivity[GraphContainer.Instance.ActivitySelections.Count];

                GraphContainer.Instance.ActivitySelections.CopyTo(tmp);

                foreach (IActivity s in tmp)
                {
                    RemoveSquare(s);
                }
            }
        }

        private void RemoveSquare(IActivity s)
        {
            bool hasNextExtry = true;

            if (s.CanDelete)
            {
                foreach (Node n in s.Nodes)
                {
                    //this.Controls.Remove(n.Label);
                    GraphContainer.Instance.Nodes.Remove(n.NodeName);
                    GraphContainer.Instance.NodeRelationship.Remove(n);
                    n.Remove();
                }

                while (hasNextExtry)
                {
                    Dictionary<Node, Node>.Enumerator en = GraphContainer.Instance.NodeRelationship.GetEnumerator();
                    hasNextExtry = false;
                    while (en.MoveNext())
                    {
                        hasNextExtry = false;

                        KeyValuePair<Node, Node> val = en.Current;
                        if (val.Value.NodeName == s.EntryNode.NodeName)
                        {
                            GraphContainer.Instance.NodeRelationship.Remove(val.Key);
                            hasNextExtry = true;
                            break;
                        }
                    }
                }

                if (s.EntryNode != null)
                {
                    //this.Controls.Remove(s.EntryNode.Label);
                    GraphContainer.Instance.Nodes.Remove(s.EntryNode.NodeName);
                    GraphContainer.Instance.NodeRelationship.Remove(s.EntryNode);

                }

                if (s.DescriptionLabel != null)
                {
                    //Controls.Remove(s.DescriptionLabel);
                }
                Controls.Remove(s.FakeLabel);

                GraphContainer.Instance.ActivitySelections.Remove(s);
                GraphContainer.Instance.Activities.Remove(s);
                this.Invalidate();

            }
        }

        private void DrawingBoard_Scroll(object sender, ScrollEventArgs e)
        {
            /*
            Dictionary<string, Node>.Enumerator lpNodes = GraphContainer.Instance.Nodes.GetEnumerator();
            while (lpNodes.MoveNext())
            {
                KeyValuePair<string, Node> item = lpNodes.Current;

                if (item.Value.DocID == this.DocID)
                {
                }
            }
             */
            this.Invalidate();
        }

        public void LoadDocument(string strFile)
        {
            Dictionary<string, IActivity> mapActivity = new Dictionary<string, IActivity>();
            XmlDocument doc = new XmlDocument();
            //doc.Load(strFile);
            doc.LoadXml(strFile);
            XPathNavigator nav = doc.CreateNavigator();
            XPathNodeIterator Iterator = nav.Select("/CallFlow/Node[@docID='" + this.strDocID + "']");
            while (Iterator.MoveNext())
            {
                string strID = Iterator.Current.GetAttribute("id", string.Empty);
                string strDocID = Iterator.Current.GetAttribute("docID", string.Empty);
                int x = Convert.ToInt32(Iterator.Current.GetAttribute("lineNodeX", string.Empty));
                int y = Convert.ToInt32(Iterator.Current.GetAttribute("lineNodeY", string.Empty));
                bool allowDrop = Convert.ToBoolean(Iterator.Current.GetAttribute("allowDrop", string.Empty));
                bool allowDraw = Convert.ToBoolean(Iterator.Current.GetAttribute("allowDraw", string.Empty));
                string strLabelText = Iterator.Current.GetAttribute("LabelText", string.Empty);
                string strNodeValue = Iterator.Current.GetAttribute("NodeValue", string.Empty);

                Node n = GraphContainer.Instance.CreateNode(this, this, strID, strLabelText, allowDrop, allowDraw);
                //this.AddControl(n.Label);

                n.DocID = strDocID;
                n.NodeValue = strNodeValue;
                GraphContainer.Instance.Nodes[strID] = n;
                
            }

            Iterator = nav.Select("/CallFlow/Activity[@docID='" + this.strDocID  + "']");
            while (Iterator.MoveNext())
            {
                string strName = Iterator.Current.GetAttribute("activityName", string.Empty);
                string strID = Iterator.Current.GetAttribute("activityID", string.Empty);
                string activityValue = Iterator.Current.GetAttribute("activityValue", string.Empty);
                string strDesc = Iterator.Current.GetAttribute("activityDesc", string.Empty);
                int x = Convert.ToInt32(Iterator.Current.GetAttribute("x", string.Empty));
                int y = Convert.ToInt32(Iterator.Current.GetAttribute("y", string.Empty));
                int width = Convert.ToInt32(Iterator.Current.GetAttribute("width", string.Empty));
                int height = Convert.ToInt32(Iterator.Current.GetAttribute("height", string.Empty));
                string strDocID = Iterator.Current.GetAttribute("docID", string.Empty);

                IActivity act = ActivityCreator.Instance.CreateActivity(strName);
                act.ActivityID = strID;
                act.ActivityValue = activityValue;
                act.Width = width;
                act.Height = height;
                act.DocID = strDocID;
                act.Position = new Point(x, y);

                XPathNodeIterator subNodes = nav.Select("/CallFlow/Activity[@activityID='" + strID + "']/EntryNode");
                while (subNodes.MoveNext())
                {
                    string strTmpNodeID = subNodes.Current.GetAttribute("id", string.Empty);
                    act.AddEntryNode(GraphContainer.Instance.Nodes[strTmpNodeID]);
                    GraphContainer.Instance.Nodes[strTmpNodeID].Activity = act as object;
                }

                subNodes = nav.Select("/CallFlow/Activity[@activityID='" + strID + "']/Node");
                while (subNodes.MoveNext())
                {
                    string strTmpNodeID = subNodes.Current.GetAttribute("id", string.Empty);
                    GraphContainer.Instance.Nodes[strTmpNodeID].Activity = act as object;
                    act.Nodes.Add(GraphContainer.Instance.Nodes[strTmpNodeID]);
                }

                subNodes = nav.Select("/CallFlow/Activity[@activityID='" + strID + "']/PrimaryNode");
                while (subNodes.MoveNext())
                {
                    string strTmpNodeID = subNodes.Current.GetAttribute("id", string.Empty);
                    act.PrimaryNode = GraphContainer.Instance.Nodes[strTmpNodeID];
                    GraphContainer.Instance.Nodes[strTmpNodeID].Activity = act as object;
                }

                subNodes = nav.Select("/CallFlow/Activity[@activityID='" + strID + "']/Attrs");
                while (subNodes.MoveNext())
                {
                    string strAttrKey = subNodes.Current.GetAttribute("key", string.Empty);
                    act.Values()[strAttrKey] = subNodes.Current.GetAttribute("val", string.Empty);
                }


                act.PreLoadDescription(this);

                GraphContainer.Instance.Activities.Add(act);
                //act.AdjustNodePosition();
                act.Description = strDesc;
                mapActivity[strID] = act;
            }

            Iterator = nav.Select("/CallFlow/Page[@docID='" + this.strDocID + "']");
            while (Iterator.MoveNext())
            {
                string strName = Iterator.Current.GetAttribute("flowName", string.Empty);
                string strActivity = Iterator.Current.GetAttribute("entry", string.Empty);

                Page p = new Page(this.strDocID, strName, mapActivity[strActivity]);
                GraphContainer.Instance.AddPage(strDocID, p);
            }

            Invalidate();
        }

        private void DrawingBoard_Load(object sender, EventArgs e)
        {

        }
    }
}
