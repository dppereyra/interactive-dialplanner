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
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Interaction.Graph
{
    public class StartActivity : AbstractActivity, IActivity
    {
        public StartActivity() : base()
        {
            logo = Properties.Resources.block;
            this.strActivityName = Properties.Resources.ActivityName;

            canDelete = false;
        }

        ~StartActivity()
        {
            _listNodes.Clear();
        }

        public void PreLoadIcon(IDrawingBoard board, IGraphEvent graphEvt, Point pos)
        {
            string strExt = GraphContainer.Instance.Extension;

            //Node node = GraphContainer.Instance.CreateNode(board, graphEvt, System.Guid.NewGuid().ToString(), "Start", false, true);
            //node.NodeValue = "Done";
            Node node = GraphContainer.Instance.CreateNode(board, graphEvt, System.Guid.NewGuid().ToString(), strExt, false, true);
            node.NodeValue = strExt;

            this.Add(node);

            base.PreLoadIcon(board, graphEvt, pos);
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
                return ((frmProps)props).NodeResult;
            }
        }

        private Dictionary<string, IActivity> ActivityResult
        {

            get
            {
                return ((frmProps)props).ActivityResult;
            }
        }


        public void DoAction(IDrawingBoard board, IGraphEvent graphEvt)
        {

            frmProps frm = this.props as frmProps;
            IActivity dest = null;
            Dictionary<string, TempNode> mapResult = PropertyResult;
            Dictionary<string, IActivity> mapActivity = ActivityResult;
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
                            node.NodeValue = val.Value.NodeText;
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
                            //AdjustNodePosition();
                        }
                        break;

                }
            }

            graphEvt.ReDraw();
            return;
        }

        public void ShowProperty(System.Windows.Forms.PropertyGrid grid)
        {
            grid.SelectedObject = this;
        }

        [System.ComponentModel.CategoryAttribute("Settings"), System.ComponentModel.DescriptionAttribute("Label"), System.ComponentModel.ReadOnlyAttribute(true)]
        public string Description
        {
            get
            {
                return lblDescription.Text;
            }

            set
            {
                lblDescription.Text = value;
            }
        }

    }
}
