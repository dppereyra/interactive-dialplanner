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
using System.Resources;
using System.ComponentModel;
using DennisWuWorks.InteractiveBuilder;
using DennisWuWorks.InteractiveBuilder.Data;

namespace Interaction.Graph
{
    public class PlayMsgActivity: AbstractActivity, IActivity
    {
        public PlayMsgActivity():base() 
        {
            logo = Properties.Resources.block;
            this.strActivityName = Properties.Resources.ActivityName;
            existToolBox = true;

        }

        ~PlayMsgActivity()
        {
            _listNodes.Clear();
        }

        public void PreLoadIcon(IDrawingBoard board, IGraphEvent graphEvt, Point pos)
        {
            Node node = GraphContainer.Instance.CreateNode(board, graphEvt, System.Guid.NewGuid().ToString(), "Done", false, true);
            //board.AddControl(node.Label);
            node.NodeValue = "Done";
            this.Add(node);

            node = GraphContainer.Instance.CreateNode(board, graphEvt, System.Guid.NewGuid().ToString(), "DTMF", false, true);
            //board.AddControl(node.Label);
            node.NodeValue = "DTMF";
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
            this.mapValue["msgs"] = Convert.ToString(((frmProps)props).Messages);
            this.mapValue["dtmf"] = Convert.ToString(((frmProps)props).DTMF);
        }

        public void ShowProperty(System.Windows.Forms.PropertyGrid grid)
        {
            grid.SelectedObject = this;
        }


        private void OnAddedEventHandler(object sender, ObjectCreatedEventArgs arg)
        {
        }

        [System.ComponentModel.CategoryAttribute("Settings"), System.ComponentModel.DescriptionAttribute("Messages")]
        public string Messages
        {
            get
            {
                try
                {
                    return Convert.ToString(this.mapValue["msgs"]);
                }
                catch (Exception ex)
                {
                }

                return "";
            }
            set
            {
                this.mapValue["msgs"] = Convert.ToString(value);
            }
        }

        [System.ComponentModel.CategoryAttribute("Settings"), System.ComponentModel.DescriptionAttribute("DTMF received")]
        public bool DTMF
        {
            get
            {
                try
                {
                    if (this.mapValue["dtmf"] == "1")
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                }

                return false;
            }
            set
            {
                if (value == true)
                {
                    this.mapValue["dtmf"] = "1";
                }
                else
                {
                    this.mapValue["dtmf"] = "0";
                }
            }
        }


    }
}
