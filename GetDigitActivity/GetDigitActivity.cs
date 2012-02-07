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
using System.Drawing.Design;
using System.ComponentModel;
using DennisWuWorks.InteractiveBuilder;
using DennisWuWorks.InteractiveBuilder.Data;

namespace Interaction.Graph
{
    public class GetDigitActivity : AbstractActivity, IActivity
    {
        public GetDigitActivity():base()
        {
            logo = Properties.Resources.block;
            this.strActivityName = Properties.Resources.ActivityName;
            existToolBox = false;

        }

        ~GetDigitActivity()
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
                            node.NodeValue = val.Value.NodeValue;
                            node.DocID = strDocID;
                            //board.AddControl(node.Label);
                            Add(node);
                            GraphContainer.Instance.Nodes[val.Value.NodeName] = node;
                            //AdjustNodePosition();
                        }
                        break;

                    case 2: //update node
                        Node updateNode = Find(val.Value.NodeName);
                        if (updateNode != null)
                        {
                            updateNode.Text = val.Value.NodeText;
                            updateNode.NodeValue = val.Value.NodeValue;
                        }

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

            lblDescription.Text = ((frmProps)props).Description;
            this.mapValue["maxdigit"] = Convert.ToString(((frmProps)props).MaxDigit);
            this.mapValue["retry"] = Convert.ToString(((frmProps)props).MaxRetry);
            this.mapValue["silent"] = Convert.ToString(((frmProps)props).MaxSilent);
            this.mapValue["entrymsg"] = ((frmProps)props).EntryMessage;
            this.mapValue["invalidmsg"] = ((frmProps)props).InvalidMessage;
            this.mapValue["noinputmsg"] = ((frmProps)props).NoInputMessage;
            this.mapValue["globaltimeout"] = ((frmProps)props).GlobalTimeout;
            this.mapValue["globalinvalid"] = ((frmProps)props).GlobalInvalid;

            graphEvt.ReDraw();
        }


        public void ShowProperty(System.Windows.Forms.PropertyGrid grid)
        {
            grid.SelectedObject = this;
        }


        private void OnAddedEventHandler(object sender, ObjectCreatedEventArgs arg)
        {
        }

        [System.ComponentModel.CategoryAttribute("Settings"), System.ComponentModel.DescriptionAttribute("Maximum of digits received.")]
        public int MaxDigit
        {
            get
            {
                try
                {
                    return Convert.ToInt32(this.mapValue["maxdigit"]);
                }
                catch (Exception ex)
                {
                }

                return 0;
            }
            set
            {
                this.mapValue["maxdigit"] = Convert.ToString(value);
            }
        }

        [System.ComponentModel.CategoryAttribute("Settings"), System.ComponentModel.DescriptionAttribute("Number of retries on error.")]
        public int Retry
        {
            get
            {
                try
                {
                    return Convert.ToInt32(this.mapValue["retry"]);
                }
                catch (Exception ex)
                {
                }

                return 0;
            }
            set
            {
                this.mapValue["retry"] = Convert.ToString(value);
            }
        }

        [System.ComponentModel.CategoryAttribute("Settings"), System.ComponentModel.DescriptionAttribute("Silence in second.")]
        public int Silence
        {
            get
            {
                try
                {
                    return Convert.ToInt32(this.mapValue["silent"]);
                }
                catch (Exception ex)
                {
                }

                return 0;
            }
            set
            {
                this.mapValue["silent"] = Convert.ToString(value);
            }
        }

        [System.ComponentModel.CategoryAttribute("Settings"), System.ComponentModel.DescriptionAttribute("Entry message.")]
        public string EntryMessage
        {
            get
            {
                try
                {
                    return Convert.ToString(this.mapValue["entrymsg"]);
                }
                catch (Exception ex)
                {
                }

                return "";
            }
            set
            {
                this.mapValue["entrymsg"] = Convert.ToString(value);
            }
        }

        [System.ComponentModel.CategoryAttribute("Settings"), System.ComponentModel.DescriptionAttribute("Invalid input message.")]
        public string InvalidMessage
        {
            get
            {
                try
                {
                    return Convert.ToString(this.mapValue["invalidmsg"]);
                }
                catch (Exception ex)
                {
                }

                return "";
            }
            set
            {
                this.mapValue["invalidmsg"] = Convert.ToString(value);
            }
        }

        [System.ComponentModel.CategoryAttribute("Settings"), System.ComponentModel.DescriptionAttribute("No input message.")]
        public string NoInputMessage
        {
            get
            {
                try
                {
                    return Convert.ToString(this.mapValue["noinputmsg"]);
                }
                catch (Exception ex)
                {
                }

                return "";
            }
            set
            {
                this.mapValue["noinputmsg"] = Convert.ToString(value);
            }
        }

        [System.ComponentModel.CategoryAttribute("Settings"), System.ComponentModel.DescriptionAttribute("Call flow for handling timeout."), System.ComponentModel.ReadOnlyAttribute(true)]
        public string GlobalTimeoutFlow
        {
            get
            {
                try
                {
                    Node nodeGlobalTimeout = GraphContainer.Instance.Nodes[Convert.ToString(this.mapValue["globaltimeout"])];

                    Dictionary<string, Page> mapPage = GraphContainer.Instance.Pages;
                    Dictionary<string, Page>.Enumerator ee = mapPage.GetEnumerator();

                    while (ee.MoveNext())
                    {
                        KeyValuePair<string, Page> item = ee.Current;
                        if (item.Value.Entry.EntryNode.NodeName == nodeGlobalTimeout.NodeName)
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

        [System.ComponentModel.CategoryAttribute("Settings"), System.ComponentModel.DescriptionAttribute("Call flow for handling timeout."), System.ComponentModel.ReadOnlyAttribute(true)]
        public string GlobalInvalidMessageFlow
        {
            get
            {
                try
                {
                    Node nodeGlobalInvalid = GraphContainer.Instance.Nodes[Convert.ToString(this.mapValue["globalinvalid"])];

                    Dictionary<string, Page> mapPage = GraphContainer.Instance.Pages;
                    Dictionary<string, Page>.Enumerator ee = mapPage.GetEnumerator();

                    while (ee.MoveNext())
                    {
                        KeyValuePair<string, Page> item = ee.Current;
                        if (item.Value.Entry.EntryNode.NodeName == nodeGlobalInvalid.NodeName)
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
    }
}
