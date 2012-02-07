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
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Resources;

namespace Interaction.Graph
{
    public abstract class AbstractActivity : IActivity
    {
        protected string strActivityID = "";
        protected string strActivityName = "dummy";
        protected string strActivityValue = "";
        protected Point position = new Point(0, 0);
        protected int width = 0;
        protected int height = 0;
        protected string strDocID;
        protected Node entryNode = null;
        protected ArrayList _listNodes = new ArrayList();

        protected int gap = 2;
        protected bool canDelete = true;
        protected Image logo;
        protected Form props = null;

        protected Label lblDescription;
        private System.Windows.Forms.Label lblFakeLabel = null;

        protected Dictionary<string, string> mapValue = new Dictionary<string, string>();

        protected bool existToolBox = false;

        public AbstractActivity()
        {
        }

        ~AbstractActivity()
        {
            _listNodes.Clear();
        }

        public void Clear()
        {
        }

        [System.ComponentModel.ReadOnlyAttribute(true), System.ComponentModel.Browsable(false)]
        public Label DescriptionLabel
        {
            get
            {
                return lblDescription;
            }
        }

        [System.ComponentModel.ReadOnlyAttribute(true), System.ComponentModel.Browsable(false)]
        public bool CanDelete
        {
            get
            {
                return canDelete;
            }
        }

        [System.ComponentModel.ReadOnlyAttribute(true), System.ComponentModel.Browsable(false)]
        public Image Icon
        {
            get
            {
                return logo;
            }
        }

        public Dictionary<string, string> Values()
        {
            return mapValue;
        }

        public void PreLoadIcon(IDrawingBoard board, IGraphEvent graphEvt, Point pos)
        {
            this.Position = board.PointToClient(pos.X, pos.Y);
            this.Width = 50;
            this.Height = 50;

            Node node = GraphContainer.Instance.CreateNode(board, graphEvt, System.Guid.NewGuid().ToString(), strActivityName, true, false);
            //board.AddControl(node.Label);
            this.AddEntryNode(node);
            node.Activity = this as object;

            //mapNodes[lblEntry.Tag.ToString()] = node;
            //_points.Add(s);

            //Create description
            lblDescription = new Label();
            lblDescription.Tag = "";
            lblDescription.Text = strActivityName;
            lblDescription.Size = new Size(80, 14);
            //board.AddControl(lblDescription);
            //lblDescription.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            //lblDescription.AutoSize = true;
            //lblDescription.Show();



            if (lblFakeLabel == null)
            {
                lblFakeLabel = new System.Windows.Forms.Label();

                lblFakeLabel.Visible = false;
                lblFakeLabel.AutoSize = false;
                lblFakeLabel.BorderStyle = BorderStyle.None;
                lblFakeLabel.Size = new Size(1, 1);
                lblFakeLabel.Text = "FakeFakeFake";
                board.AddControl(lblFakeLabel);
                lblFakeLabel.Show();
            }

        }

        [System.ComponentModel.CategoryAttribute("Settings"), System.ComponentModel.DescriptionAttribute("Label"), System.ComponentModel.DisplayName("Label")]
        public string Description
        {
            get
            {
                return lblDescription.Text;
            }

            set
            {
                if (CheckDescription(value))
                {
                    lblDescription.Text = value;
                }
            }
        }

        [System.ComponentModel.ReadOnlyAttribute(true), System.ComponentModel.Browsable(false)]
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

        public DialogResult ShowProperties()
        {
            throw new NotImplementedException();
        }

        [System.ComponentModel.ReadOnlyAttribute(true), System.ComponentModel.Browsable(false)]
        public Dictionary<string, TempNode> PropertyResult
        {
            get { throw new NotImplementedException(); }
        }

        public void AddEntryNode(Node l)
        {
            if (entryNode == null)
            {
                entryNode = l;
                entryNode.Show();
                entryNode.Activity = this as object;
            }
        }

        public void Add(Node node)
        {
            node.Align(System.Drawing.ContentAlignment.MiddleRight);
            node.Show();

            node.Activity = this as object;
            _listNodes.Add(node);
        }

        public Node Remove(string strName)
        {
            Node ret = null;
            foreach (Node n in _listNodes)
            {
                if (n.NodeName == strName)
                {
                    ret = n;
                    _listNodes.Remove(n);
                    break;
                }
            }

            return ret;
        }

        public Node Find(string strName)
        {
            Node ret = null;
            foreach (Node n in _listNodes)
            {
                if (n.NodeName == strName)
                {
                    ret = n;
                    break;
                }
            }

            return ret;
        }

        [System.ComponentModel.ReadOnlyAttribute(true), System.ComponentModel.Browsable(false)]
        public ArrayList Nodes
        {
            get
            {
                return _listNodes;
            }
        }

        [System.ComponentModel.ReadOnlyAttribute(true), System.ComponentModel.Browsable(false)]
        public Node EntryNode
        {
            get
            {
                return entryNode;
            }
        }

        [System.ComponentModel.ReadOnlyAttribute(true), System.ComponentModel.Browsable(false)]
        public Node PrimaryNode
        {
            get
            {
                return null;
            }

            set
            {

            }
        }

        [System.ComponentModel.ReadOnlyAttribute(true), System.ComponentModel.Browsable(false)]
        public System.Windows.Forms.Label FakeLabel
        {
            get
            {
                return lblFakeLabel;
            }
        }
        /*
         * 
        public void AdjustNodePosition(Point diffpos, System.Drawing.Graphics gfx)
        {
            int cnt = _listNodes.Count;
            int tx = position.X + width + gap + diffpos.X;
            int ty = 0;
            int origtx = position.X + width + gap;
            int origty = 0;
            Font font = new Font("Arial", 9);

            //Adjust entry node
            if (entryNode != null)
            {
                SizeF sizeText = gfx.MeasureString(entryNode.Label.Text, font);
                //entryNode.Label.Size = new Size((int)sizeText.Width, (int)sizeText.Height);
                //entryNode.NodeHeight = (int)sizeText.Height;
                //entryNode.NodeWidth = (int)sizeText.Width;
                entryNode.Label.Size = new Size(entryNode.DefaultNodeWidth, entryNode.DefaultNodeHeight);
                entryNode.NodeHeight = (int)entryNode.DefaultNodeHeight;
                entryNode.NodeWidth = (int)entryNode.DefaultNodeWidth;

                int ex = position.X - entryNode.NodeWidth - gap + diffpos.X;
                int ey = position.Y + (height / 2) - (entryNode.Label.Size.Height / 2) + diffpos.Y;
                int trueex = position.X - entryNode.NodeWidth - gap;
                int trueey = position.Y + (height / 2) - (entryNode.Label.Size.Height / 2);

                Point entryNodePos = new Point(ex, ey);
                Point entryNodePos2 = new Point(trueex, trueey);
                entryNode.Label.Location = entryNodePos;
                entryNode.LineNode = new Point(entryNodePos2.X, entryNodePos2.Y + (entryNode.Label.Size.Height / 2));

                //Draw Text
                StringFormat strFormat = new StringFormat();
                strFormat.Alignment = StringAlignment.Center;
                strFormat.LineAlignment = StringAlignment.Center;

                gfx.DrawString(entryNode.Text, font, Brushes.Black, new RectangleF(entryNode.Label.Location.X, entryNode.Label.Location.Y, entryNode.NodeWidth, entryNode.NodeHeight), strFormat);

                //Draw rectangle
                Pen pRect = new Pen(Color.Black);
                Point p1 = new Point(entryNode.Label.Location.X, entryNode.Label.Location.Y);
                Point p2 = new Point(entryNode.Label.Location.X, entryNode.Label.Location.Y + entryNode.Label.Height);
                Point p3 = new Point(entryNode.Label.Location.X + entryNode.Label.Width, entryNode.Label.Location.Y + entryNode.Label.Height);
                Point p4 = new Point(entryNode.Label.Location.X + entryNode.Label.Width, entryNode.Label.Location.Y);

                gfx.DrawLine(pRect, p1, p2);
                gfx.DrawLine(pRect, p2, p3);
                gfx.DrawLine(pRect, p3, p4);
                gfx.DrawLine(pRect, p4, p1);

                if (lblFakeLabel != null)
                {
                    lblFakeLabel.Location = new Point(p1.X + 250, p1.Y);
                }
            }


            //Adjust result node
            if (cnt > 0)
            {
                int cntDelta = (cnt - 1);

                //Get starting point of ty
                foreach (Node l in _listNodes)
                {
                    ty = position.Y + (height / 2) - (l.Label.Size.Height / 2) - ((l.Label.Size.Height / 2) * cntDelta) + diffpos.Y;
                    origty = position.Y + (height / 2) - (l.Label.Size.Height / 2) - ((l.Label.Size.Height / 2) * cntDelta);
                    break;
                }

                foreach (Node l in _listNodes)
                {
                    l.Label.Size = new Size(entryNode.DefaultNodeWidth, entryNode.DefaultNodeHeight);
                    l.NodeHeight = (int)entryNode.DefaultNodeHeight;
                    l.NodeWidth = (int)entryNode.DefaultNodeWidth;

                    Point tmpNodePos = new Point(tx, ty);
                    Point tmpNodePos2 = new Point(origtx, origty);
                    l.Label.Location = tmpNodePos;

                    //l.LineNode = new Point(tmpNodePos.X + l.NodeWidth, tmpNodePos.Y + (l.NodeHeight / 2));
                    l.LineNode = new Point(tmpNodePos2.X + l.NodeWidth, tmpNodePos2.Y + (l.NodeHeight / 2));


                    //Draw Text
                    StringFormat strFormat = new StringFormat();
                    strFormat.Alignment = StringAlignment.Center;
                    strFormat.LineAlignment = StringAlignment.Center;

                    gfx.DrawString(l.Text, font, Brushes.Black, new RectangleF(l.Label.Location.X, l.Label.Location.Y, l.NodeWidth, l.NodeHeight), strFormat);

                    //Draw rectangle
                    Pen pRect = new Pen(Color.Black);
                    Point p1 = new Point(l.Label.Location.X, l.Label.Location.Y);
                    Point p2 = new Point(l.Label.Location.X, l.Label.Location.Y + l.Label.Height);
                    Point p3 = new Point(l.Label.Location.X + l.Label.Width, l.Label.Location.Y + l.Label.Height);
                    Point p4 = new Point(l.Label.Location.X + l.Label.Width, l.Label.Location.Y);

                    gfx.DrawLine(pRect, p1, p2);
                    gfx.DrawLine(pRect, p2, p3);
                    gfx.DrawLine(pRect, p3, p4);
                    gfx.DrawLine(pRect, p4, p1);


                    ty += l.NodeHeight;
                    origty += l.NodeHeight;
                }
            }

            AdjustDescriptionPos(diffpos, gfx);
        }

        public void AdjustDescriptionPos(Point diffpos, System.Drawing.Graphics gfx)
        {
            int dx = 0;
            int dy = 0;

            if (lblDescription != null)
            {
                Font font = new Font("Arial", 9);
                SizeF sizeText = gfx.MeasureString(lblDescription.Text, font);
                lblDescription.Size = new Size((int)sizeText.Width + 10, (int)sizeText.Height);

                dx = this.position.X + (this.width / 2) - (lblDescription.Size.Width / 2) + diffpos.X;
                dy = this.position.Y + this.height + this.gap + diffpos.Y;

                lblDescription.Location = new Point(dx, dy);

                //Draw Description
                StringFormat strFormat = new StringFormat();
                strFormat.Alignment = StringAlignment.Center;
                strFormat.LineAlignment = StringAlignment.Center;

                gfx.DrawString(lblDescription.Text, font, Brushes.Black, new RectangleF(lblDescription.Location.X, lblDescription.Location.Y, lblDescription.Size.Width, lblDescription.Size.Height), strFormat);

                //Draw rectangle
                Pen pRect = new Pen(Color.Black);
                Point p1 = new Point(lblDescription.Location.X, lblDescription.Location.Y);
                Point p2 = new Point(lblDescription.Location.X, lblDescription.Location.Y + lblDescription.Height);
                Point p3 = new Point(lblDescription.Location.X + lblDescription.Width, lblDescription.Location.Y + lblDescription.Height);
                Point p4 = new Point(lblDescription.Location.X + lblDescription.Width, lblDescription.Location.Y);

                gfx.DrawLine(pRect, p1, p2);
                gfx.DrawLine(pRect, p2, p3);
                gfx.DrawLine(pRect, p3, p4);
                gfx.DrawLine(pRect, p4, p1);

            }
        }

*/
        private void AdjustFakeNodePosition(Point diffpos, System.Drawing.Graphics gfx)
        {
            int cnt = _listNodes.Count;
            int tx = position.X + width + gap + diffpos.X;
            int origtx = position.X + width + gap;

            //Adjust fake node
            if (lblFakeLabel != null)
            {
                int ex = position.X - entryNode.NodeWidth - gap + diffpos.X;
                int ey = position.Y + (height / 2) - (entryNode.Label.Size.Height / 2) + diffpos.Y;
                int trueex = position.X - entryNode.NodeWidth - gap;
                int trueey = position.Y + (height / 2) - (entryNode.Label.Size.Height / 2);

                Point entryNodePos = new Point(ex, ey);
                Point entryNodePos2 = new Point(trueex, trueey);
                lblFakeLabel.Location = new Point(entryNodePos.X + 200, entryNodePos.Y + 100);
            }

        }

        public void AdjustNodePosition(Point diffpos, System.Drawing.Graphics gfx)
        {
            int cnt = _listNodes.Count;
            int tx = position.X + width + gap;
            int ty = 0;
            int origtx = position.X + width + gap;
            int origty = 0;
            Font font = new Font("Arial", 9);

            //Adjust entry node
            if (entryNode != null)
            {
                SizeF sizeText = gfx.MeasureString(entryNode.Label.Text, font);
                entryNode.Label.Size = new Size(entryNode.DefaultNodeWidth, entryNode.DefaultNodeHeight);
                entryNode.NodeHeight = (int)entryNode.DefaultNodeHeight;
                entryNode.NodeWidth = (int)entryNode.DefaultNodeWidth;

                int ex = position.X - entryNode.NodeWidth - gap;
                int ey = position.Y + (height / 2) - (entryNode.Label.Size.Height / 2);
                int trueex = position.X - entryNode.NodeWidth - gap;
                int trueey = position.Y + (height / 2) - (entryNode.Label.Size.Height / 2);

                //Point entryNodePos = new Point(ex, ey);
                Point entryNodePos2 = new Point(trueex, trueey);
                entryNode.Label.Location = entryNodePos2;
                entryNode.LineNode = new Point(entryNodePos2.X, entryNodePos2.Y + (entryNode.Label.Size.Height / 2));

                //Draw Text
                StringFormat strFormat = new StringFormat();
                strFormat.Alignment = StringAlignment.Center;
                strFormat.LineAlignment = StringAlignment.Center;

                gfx.DrawString(entryNode.Text, font, Brushes.Black, new RectangleF(entryNode.Label.Location.X, entryNode.Label.Location.Y, entryNode.NodeWidth, entryNode.NodeHeight), strFormat);

                //Draw rectangle
                Pen pRect = new Pen(Color.Black);
                Point p1 = new Point(entryNode.Label.Location.X, entryNode.Label.Location.Y);
                Point p2 = new Point(entryNode.Label.Location.X, entryNode.Label.Location.Y + entryNode.Label.Height);
                Point p3 = new Point(entryNode.Label.Location.X + entryNode.Label.Width, entryNode.Label.Location.Y + entryNode.Label.Height);
                Point p4 = new Point(entryNode.Label.Location.X + entryNode.Label.Width, entryNode.Label.Location.Y);

                gfx.DrawLine(pRect, p1, p2);
                gfx.DrawLine(pRect, p2, p3);
                gfx.DrawLine(pRect, p3, p4);
                gfx.DrawLine(pRect, p4, p1);

                if (lblFakeLabel != null)
                {
                    AdjustFakeNodePosition(diffpos, gfx);
                }
            }


            //Adjust result node
            if (cnt > 0)
            {
                int cntDelta = (cnt - 1);

                //Get starting point of ty
                foreach (Node l in _listNodes)
                {
                    ty = position.Y + (height / 2) - (l.Label.Size.Height / 2) - ((l.Label.Size.Height / 2) * cntDelta);
                    origty = position.Y + (height / 2) - (l.Label.Size.Height / 2) - ((l.Label.Size.Height / 2) * cntDelta);
                    break;
                }

                foreach (Node l in _listNodes)
                {
                    l.Label.Size = new Size(entryNode.DefaultNodeWidth, entryNode.DefaultNodeHeight);
                    l.NodeHeight = (int)entryNode.DefaultNodeHeight;
                    l.NodeWidth = (int)entryNode.DefaultNodeWidth;

                    Point tmpNodePos = new Point(tx, ty);
                    Point tmpNodePos2 = new Point(origtx, origty);
                    l.Label.Location = tmpNodePos;

                    //l.LineNode = new Point(tmpNodePos.X + l.NodeWidth, tmpNodePos.Y + (l.NodeHeight / 2));
                    l.LineNode = new Point(tmpNodePos2.X + l.NodeWidth, tmpNodePos2.Y + (l.NodeHeight / 2));


                    //Draw Text
                    StringFormat strFormat = new StringFormat();
                    strFormat.Alignment = StringAlignment.Center;
                    strFormat.LineAlignment = StringAlignment.Center;

                    gfx.DrawString(l.Text, font, Brushes.Black, new RectangleF(l.Label.Location.X, l.Label.Location.Y, l.NodeWidth, l.NodeHeight), strFormat);

                    //Draw rectangle
                    Pen pRect = new Pen(Color.Black);
                    Point p1 = new Point(l.Label.Location.X, l.Label.Location.Y);
                    Point p2 = new Point(l.Label.Location.X, l.Label.Location.Y + l.Label.Height);
                    Point p3 = new Point(l.Label.Location.X + l.Label.Width, l.Label.Location.Y + l.Label.Height);
                    Point p4 = new Point(l.Label.Location.X + l.Label.Width, l.Label.Location.Y);

                    gfx.DrawLine(pRect, p1, p2);
                    gfx.DrawLine(pRect, p2, p3);
                    gfx.DrawLine(pRect, p3, p4);
                    gfx.DrawLine(pRect, p4, p1);


                    ty += l.NodeHeight;
                    origty += l.NodeHeight;
                }
            }

            AdjustDescriptionPos(diffpos, gfx);
        }

        public void AdjustDescriptionPos(Point diffpos, System.Drawing.Graphics gfx)
        {
            int dx = 0;
            int dy = 0;

            if (lblDescription != null)
            {
                Font font = new Font("Arial", 9);
                SizeF sizeText = gfx.MeasureString(lblDescription.Text, font);
                lblDescription.Size = new Size((int)sizeText.Width + 10, (int)sizeText.Height);

                //dx = this.position.X + (this.width / 2) - (lblDescription.Size.Width / 2);
                dx = this.position.X + this.width - lblDescription.Size.Width - this.gap;
                dy = this.position.Y + this.height + this.gap;

                lblDescription.Location = new Point(dx, dy);

                //Draw Description
                StringFormat strFormat = new StringFormat();
                strFormat.Alignment = StringAlignment.Center;
                strFormat.LineAlignment = StringAlignment.Center;

                gfx.DrawString(lblDescription.Text, font, Brushes.Black, new RectangleF(lblDescription.Location.X, lblDescription.Location.Y, lblDescription.Size.Width, lblDescription.Size.Height), strFormat);

                //Draw rectangle
                Pen pRect = new Pen(Color.Black);
                Point p1 = new Point(lblDescription.Location.X, lblDescription.Location.Y);
                Point p2 = new Point(lblDescription.Location.X, lblDescription.Location.Y + lblDescription.Height);
                Point p3 = new Point(lblDescription.Location.X + lblDescription.Width, lblDescription.Location.Y + lblDescription.Height);
                Point p4 = new Point(lblDescription.Location.X + lblDescription.Width, lblDescription.Location.Y);

                gfx.DrawLine(pRect, p1, p2);
                gfx.DrawLine(pRect, p2, p3);
                gfx.DrawLine(pRect, p3, p4);
                gfx.DrawLine(pRect, p4, p1);

            }
        }

        public void PreLoadDescription(IDrawingBoard board)
        {
            if (lblDescription == null)
            {
                lblDescription = new Label();
                lblDescription.Tag = "";
                lblDescription.Text = "";
                lblDescription.Size = new Size(60, 14);
                //board.AddControl(lblDescription);
                //lblDescription.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                //lblDescription.AutoSize = true;
                //lblDescription.Show();
            }

            if (lblFakeLabel == null)
            {
                lblFakeLabel = new System.Windows.Forms.Label();

                lblFakeLabel.Visible = false;
                lblFakeLabel.AutoSize = false;
                lblFakeLabel.BorderStyle = BorderStyle.None;
                lblFakeLabel.Size = new Size(1, 1);
                lblFakeLabel.Text = "FakeFakeFake";
                board.AddControl(lblFakeLabel);
                lblFakeLabel.Show();
            }
        }


        [System.ComponentModel.ReadOnlyAttribute(true), System.ComponentModel.Browsable(false)]
        public Point Position
        {
            get
            {
                return position;
            }

            set
            {
                position = value;
            }
        }

        [System.ComponentModel.ReadOnlyAttribute(true), System.ComponentModel.Browsable(false)]
        public int Width
        {
            get
            {
                return width;
            }

            set
            {
                width = value;
            }
        }

        [System.ComponentModel.ReadOnlyAttribute(true), System.ComponentModel.Browsable(false)]
        public int Height
        {
            get
            {
                return height;
            }

            set
            {
                height = value;
            }
        }

        [System.ComponentModel.ReadOnlyAttribute(true), System.ComponentModel.Browsable(false)]
        public string ActivityID
        {
            get
            {
                return strActivityID;
            }

            set
            {
                strActivityID = value;
            }
        }

        [System.ComponentModel.ReadOnlyAttribute(true), System.ComponentModel.Browsable(false)]
        public string ActivityName
        {
            get
            {
                return strActivityName;
            }
        }

        [System.ComponentModel.ReadOnlyAttribute(true), System.ComponentModel.Browsable(false)]
        public string ActivityValue
        {
            get
            {
                return strActivityValue;
            }

            set
            {
                strActivityValue = value;
            }
        }

        public void DoAction(IDrawingBoard board, IGraphEvent graphEvt)
        {
            throw new NotImplementedException();
        }

        [System.ComponentModel.ReadOnlyAttribute(true), System.ComponentModel.Browsable(false)]
        public bool ExistToolBox
        {
            get
            {
                return existToolBox;
            }
        }

        public void ShowProperty(System.Windows.Forms.PropertyGrid grid)
        {
            //throw new NotImplementedException();
        }

        protected bool CheckDescription(string strDesc)
        {
            bool ret = false;
            if (GraphContainer.Instance.FindDuplicateActivityDescription(this.strActivityID, strDesc))
            {
                MessageBox.Show("Duplicate naming of activity", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ret = true;
            }

            return ret;
        }
    }
}
