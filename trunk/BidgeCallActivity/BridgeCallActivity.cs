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
    public class BridgeCallActivity : AbstractActivity, IActivity
    {
        public BridgeCallActivity(): base()
        {
            logo = Properties.Resources.block;
            this.strActivityName = Properties.Resources.ActivityName;
            existToolBox = true;

        }

        ~ BridgeCallActivity()
        {
            _listNodes.Clear();
        }

        public void PreLoadIcon(IDrawingBoard board, IGraphEvent graphEvt, Point pos)
        {
            Node node = GraphContainer.Instance.CreateNode(board, graphEvt, System.Guid.NewGuid().ToString(), "ANSWER", false, true);
            //board.AddControl(node.Label);
            node.NodeValue = "ANSWER";
            this.Add(node);

            node = GraphContainer.Instance.CreateNode(board, graphEvt, System.Guid.NewGuid().ToString(), "NOANSWER", false, true);
            //board.AddControl(node.Label);
            node.NodeValue = "NOANSWER";
            this.Add(node);

            node = GraphContainer.Instance.CreateNode(board, graphEvt, System.Guid.NewGuid().ToString(), "BUSY", false, true);
            //board.AddControl(node.Label);
            node.NodeValue = "BUSY";
            this.Add(node);

            node = GraphContainer.Instance.CreateNode(board, graphEvt, System.Guid.NewGuid().ToString(), "CANCEL", false, true);
            //board.AddControl(node.Label);
            node.NodeValue = "CANCEL";
            this.Add(node);

            node = GraphContainer.Instance.CreateNode(board, graphEvt, System.Guid.NewGuid().ToString(), "DONTCALL", false, true);
            //board.AddControl(node.Label);
            node.NodeValue = "DONTCALL";
            this.Add(node);

            node = GraphContainer.Instance.CreateNode(board, graphEvt, System.Guid.NewGuid().ToString(), "TORTURE", false, true);
            //board.AddControl(node.Label);
            node.NodeValue = "TORTURE";
            this.Add(node);

            node = GraphContainer.Instance.CreateNode(board, graphEvt, System.Guid.NewGuid().ToString(), "CONGESTION", false, true);
            //board.AddControl(node.Label);
            node.NodeValue = "CONGESTION";
            this.Add(node);

            node = GraphContainer.Instance.CreateNode(board, graphEvt, System.Guid.NewGuid().ToString(), "CHANUNAVAIL", false, true);
            //board.AddControl(node.Label);
            node.NodeValue = "CHANUNAVAIL";
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

        public void DoAction(IDrawingBoard board, IGraphEvent graphEvt)
        {
            lblDescription.Text = ((frmProps)props).Description;
            this.mapValue["wait"] = Convert.ToString(((frmProps)props).Wait);
            this.mapValue["dialto"] = ((frmProps)props).DialTo;
            this.mapValue["options"] = ((frmProps)props).Options;
        }

        [System.ComponentModel.CategoryAttribute("Settings"), System.ComponentModel.DescriptionAttribute("Time of wait in second.")]
        public int Wait
        {
            get
            {
                try
                {
                    return Convert.ToInt32(this.mapValue["wait"]);
                }
                catch (Exception ex)
                {
                }

                return 0;
            }
            set
            {
                this.mapValue["wait"] = Convert.ToString(value);
            }
        }

        [System.ComponentModel.CategoryAttribute("Settings"), System.ComponentModel.DescriptionAttribute("Destionation for bridging.")]
        public string DialTo
        {
            get
            {
                try
                {
                    return this.mapValue["dialto"];
                }
                catch (Exception ex)
                {
                }

                return "";
            }
            set
            {
                this.mapValue["dialto"] = Convert.ToString(value);
            }
        }

        [System.ComponentModel.CategoryAttribute("Settings"), System.ComponentModel.DescriptionAttribute("Options")]
        public string Options
        {
            get
            {
                try
                {
                    return this.mapValue["options"];
                }
                catch (Exception ex)
                {
                }

                return "";
            }
            set
            {
                this.mapValue["options"] = Convert.ToString(value);
            }
        }

        public void ShowProperty(System.Windows.Forms.PropertyGrid grid)
        {
            grid.SelectedObject = this;
        }
    }
}
