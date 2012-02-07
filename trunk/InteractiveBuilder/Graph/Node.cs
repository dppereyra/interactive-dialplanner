using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;

namespace Interaction.Graph
{
    public class Node
    {
        private string nodeName;
        private Label lblNode;
        private MouseEventHandler labelMouseUp ;
        private MouseEventHandler labelMouseDown;
        private MouseEventHandler labelMouseMove;
        private int nodeWidth = 60;
        private int nodeHeight = 14;
        private IGraphEvent parent;
        private bool allowDrop;
        private Point lineNode = new Point(0, 0);

        public Node(Label l, IGraphEvent ge, bool allowDrop)
        {
            parent = ge;
            nodeName = l.Tag.ToString();
            lblNode = l;
            lblNode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lblNode.AutoSize = false;
            lblNode.Size = new Size(nodeWidth, nodeHeight);

            labelMouseUp = new MouseEventHandler(lblNode_MouseUp);
            labelMouseDown= new MouseEventHandler(lblNode_MouseDown);
            labelMouseMove = new MouseEventHandler(lblNode_MouseMove);

            lblNode.MouseUp += labelMouseUp;
            lblNode.MouseDown += labelMouseDown;
            lblNode.MouseMove += labelMouseMove;

            this.allowDrop = allowDrop;
        }

        ~Node()
        {
            labelMouseUp = null;
            labelMouseDown = null;
            labelMouseMove = null;
        }

        public void Remove()
        {
            lblNode.MouseUp -= labelMouseUp;
            lblNode.MouseDown -= labelMouseDown;
            lblNode.MouseMove -= labelMouseMove;
            lblNode.Dispose();
        }

        public string NodeName
        {
            get
            {
                return nodeName;
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
            }
        }

        public int NodeWidth
        {
            get
            {
                return nodeWidth;
            }
        }

        public int NodeHeight
        {
            get
            {
                return nodeHeight;
            }
        }

        public void Align(System.Drawing.ContentAlignment align)
        {
            lblNode.TextAlign = align;
        }

        public void Show()
        {
            lblNode.Show();
        }

        void lblNode_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Label l = sender as Label;
                int x = l.Location.X + e.X;
                int y = l.Location.Y + e.Y;

                MouseEventArgs ee = new MouseEventArgs(e.Button, e.Clicks, x, y, e.Delta);
                parent.GraphMouseMove(sender, ee);
            }
        }

        void lblNode_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Label l = sender as Label;
                int x = l.Location.X + e.X;
                int y = l.Location.Y + e.Y;

                MouseEventArgs ee = new MouseEventArgs(e.Button, e.Clicks, x, y, e.Delta);
                parent.GraphMouseDown(sender, ee);
            }

        }

        void lblNode_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Label l = sender as Label;
                int x = l.Location.X + e.X;
                int y = l.Location.Y + e.Y;

                MouseEventArgs ee = new MouseEventArgs(e.Button, e.Clicks, x, y, e.Delta);
                parent.GraphMouseUp(sender, ee);
            }
        }

    }
}
