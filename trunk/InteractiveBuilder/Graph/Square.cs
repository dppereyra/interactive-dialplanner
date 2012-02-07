using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Interaction.Graph
{
    public class Square
    {
        private Point position = new Point(0, 0);
        private int width = 0;
        private int height = 0;
        private ArrayList _listNodes = new ArrayList();
        private int gap = 2;
        private Node entryNode = null;

        public Square()
        {
        }

        ~Square()
        {
            _listNodes.Clear();
        }

        public void AddEntryNode(Node l)
        {
            if (entryNode == null)
            {
                entryNode = l;
                entryNode.Show();
            }
        }

        public void Add(Node node)
        {
            node.Align(System.Drawing.ContentAlignment.MiddleRight);
            node.Show();

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

        public ArrayList Nodes
        {
            get
            {
                return _listNodes;
            }
        }

        public Node EntryNode
        {
            get
            {
                return entryNode;
            }
        }

        public void AdjustNodePosition()
        {
            int cnt = _listNodes.Count;
            int tx = position.X + width + gap;
            int ty = 0;

            //Adjust entry node
            if (entryNode != null)
            {
                int ex = position.X - entryNode.NodeWidth - gap;
                int ey = position.Y + (height / 2) - (entryNode.Label.Size.Height / 2);

                Point entryNodePos = new Point(ex, ey);
                entryNode.Label.Location = entryNodePos;
                entryNode.LineNode = new Point(entryNodePos.X, entryNodePos.Y + (entryNode.Label.Size.Height / 2));
            }


            //Adjust result node
            if (cnt > 0)
            {
                int cntDelta = (cnt - 1);

                //Get starting point of ty
                foreach (Node l in _listNodes)
                {
                    ty = position.Y + (height / 2) - (l.Label.Size.Height / 2) - ((l.Label.Size.Height / 2) * cntDelta);
                    break;
                }

                foreach (Node l in _listNodes)
                {
                    Point tmpNodePos = new Point(tx, ty);
                    l.Label.Location = tmpNodePos;
                    l.LineNode = new Point(tmpNodePos.X + l.NodeWidth, tmpNodePos.Y + (l.NodeHeight / 2));

                    ty += l.NodeHeight;
                }
            }
        }

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

    }
}
