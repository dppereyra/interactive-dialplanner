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
using System.ComponentModel;
using DennisWuWorks.InteractiveBuilder;
using DennisWuWorks.InteractiveBuilder.Data;

namespace Interaction.Graph
{
    public class GotoActivity : AbstractActivity, IActivity
    {
        public GotoActivity() : base()
        {
            logo = Properties.Resources.block;
            this.strActivityName = Properties.Resources.ActivityName;
            existToolBox = true;

        }

        ~GotoActivity()
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
            if (mapValue.ContainsKey("extension"))
            {
                ((frmProps)props).Extension = this.mapValue["extension"];
            }
            if (mapValue.ContainsKey("gotolabel"))
            {
                ((frmProps)props).GotoLabel = this.mapValue["gotolabel"];
            }

            result = props.ShowDialog();

            return result;
        }

        public void PreLoadIcon(IDrawingBoard board, IGraphEvent graphEvt, Point pos)
        {
            Node node = GraphContainer.Instance.CreateNode(board, graphEvt, System.Guid.NewGuid().ToString(), "", false, false);
            node.NodeValue = System.Guid.NewGuid().ToString();
            this.Add(node);

            node = GraphContainer.Instance.CreateNode(board, graphEvt, System.Guid.NewGuid().ToString(), "", false, false);
            node.NodeValue = System.Guid.NewGuid().ToString();
            this.Add(node);

            base.PreLoadIcon(board, graphEvt, pos);
        }


        public Dictionary<string, TempNode> PropertyResult
        {
            get
            {
                return null;
            }
        }

        public void DoAction(IDrawingBoard board, IGraphEvent graphEvt)
        {
            frmProps frm = this.props as frmProps;
            IActivity dest = null;

            if (!frm.RemoveRelationship)
            {
                Dictionary<string, IActivity>.Enumerator ee = frm.Result.GetEnumerator();
                while (ee.MoveNext())
                {
                    KeyValuePair<string, IActivity> pair = ee.Current;
                    dest = pair.Value;
                    break;
                }

                if (dest != null)
                {
                    Node n1 = this.Nodes[0] as Node;
                    Node n2 = dest.EntryNode;
                    Node n3 = this.Nodes[1] as Node;

                    n1.LineNode = new Point(0, 0);
                    n2.LineNode = new Point(0, 0);

                    GraphContainer.Instance.NodeRelationship[n1] = n2;

                    n1.Text = n2.Text;

                    this.mapValue["extension"] = Convert.ToString(((frmProps)props).Extension);
                    this.mapValue["gotolabel"] = Convert.ToString(((frmProps)props).GotoLabel);

                    n3.Text = this.mapValue["gotolabel"];
                }
            }
            else
            {
                Node n1 = this.Nodes[0] as Node;
                Node n3 = this.Nodes[1] as Node;
                GraphContainer.Instance.NodeRelationship.Remove(n1);
                n1.Text = "";
                n3.Text = "";
                this.mapValue["gotolabel"] = "";
            }

            lblDescription.Text = ((frmProps)props).Description;
        }

        public void ShowProperty(System.Windows.Forms.PropertyGrid grid)
        {
            grid.SelectedObject = this;
        }


        private void OnAddedEventHandler(object sender, ObjectCreatedEventArgs arg)
        {
        }

        [System.ComponentModel.CategoryAttribute("Settings"), System.ComponentModel.DescriptionAttribute("Destination of the sub flow."), System.ComponentModel.ReadOnlyAttribute(true)]
        public string GotoFlow
        {
            get
            {
                try
                {
                    Node node1 = this.Nodes[0] as Node;
                    Node node2 = GraphContainer.Instance.NodeRelationship[node1];

                    Dictionary<string, Page> mapPage = GraphContainer.Instance.Pages;
                    Dictionary<string, Page>.Enumerator ee = mapPage.GetEnumerator();

                    while (ee.MoveNext())
                    {
                        KeyValuePair<string, Page> item = ee.Current;
                        if (item.Value.Entry.EntryNode.NodeName == node2.NodeName)
                        {
                            return item.Value.FlowName;
                        }
                    }
                }
                catch (Exception ex)
                {
                }

                return "";
            }
        }

        [CategoryAttribute("Settings"), DescriptionAttribute("Extension for the following context")]
        public string Extension
        {
            get
            {
                try
                {
                    return this.mapValue["extension"];
                }
                catch (Exception ex)
                {
                }

                return "";
            }
            set
            {
                this.mapValue["extension"] = value;
            }
        }

    }

}
