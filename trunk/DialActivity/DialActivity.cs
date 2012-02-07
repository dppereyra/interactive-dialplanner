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
using System.Windows.Forms;
using System.Resources;

namespace Interaction.Graph
{
    public class DialActivity : AbstractActivity, IActivity
    {
        public DialActivity():base()
        {
            logo = Properties.Resources.block;
            this.strActivityName = Properties.Resources.ActivityName;
        }

        ~DialActivity()
        {
            _listNodes.Clear();
        }

        public DialogResult ShowProperties()
        {
            DialogResult result = DialogResult.Ignore;

            if (props != null)
            {
                props.Dispose();
            }

            props = null;

            props = new frmProps();

            ((frmProps)props).Activities = this;
            result = props.ShowDialog();

            return result;
        }

        public Dictionary<string, TempNode> PropertyResult
        {

            get
            {
                return ((frmProps)props).Result;
            }
        }

        public void DoAction(IDrawingBoard board, IGraphEvent graphEvt)
        {
            Dictionary<string, TempNode> mapResult = PropertyResult;
            Dictionary<string, TempNode>.Enumerator en = mapResult.GetEnumerator();

            while (en.MoveNext())
            {
                KeyValuePair<string, TempNode> val = en.Current;

                switch (val.Value.Status)
                {
                    case 0: //unchange
                        break;

                    case 1: //new node
                        {
                            Node node = GraphContainer.Instance.CreateNode(board, graphEvt, val.Value.NodeName, val.Value.NodeText, false, true);
                            node.DocID = strDocID;
                            //board.AddControl(node.Label);
                            Add(node);

                            GraphContainer.Instance.Nodes[val.Value.NodeName] = node;
                            //AdjustNodePosition();
                        }
                        break;

                    case 2: //update node
                        break;

                    case 3: //delete node
                        Node removeNode = Remove(val.Value.NodeName);
                        if (removeNode != null)
                        {
                            //board.RemoveControl(removeNode.Label);
                            GraphContainer.Instance.Nodes.Remove(val.Value.NodeName);
                            GraphContainer.Instance.NodeRelationship.Remove(removeNode);
                            removeNode.Remove();
//                            AdjustNodePosition();
                        }
                        break;

                }
            }
            lblDescription.Text = ((frmProps)props).Description;
            graphEvt.ReDraw();
        }

    }
}
