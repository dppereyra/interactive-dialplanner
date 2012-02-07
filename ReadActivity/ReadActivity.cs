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
    public class ReadActivity : AbstractActivity, IActivity
    {
        public ReadActivity()
            : base()
        {
            logo = Properties.Resources.block;
            this.strActivityName = Properties.Resources.ActivityName;
            existToolBox = true;

        }

        ~ReadActivity()
        {
            _listNodes.Clear();
        }

        public void PreLoadIcon(IDrawingBoard board, IGraphEvent graphEvt, Point pos)
        {
            Node node = GraphContainer.Instance.CreateNode(board, graphEvt, System.Guid.NewGuid().ToString(), "Done", false, true);
            //board.AddControl(node.Label);
            node.NodeValue = "Done";
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
                return null;
            }
        }

        public void DoAction(IDrawingBoard board, IGraphEvent graphEvt)
        {
            lblDescription.Text = ((frmProps)props).Description;
            this.mapValue["maxdigit"] = Convert.ToString(((frmProps)props).MaxDigit);
            this.mapValue["retry"] = Convert.ToString(((frmProps)props).MaxRetry);
            this.mapValue["silent"] = Convert.ToString(((frmProps)props).MaxSilent);
            this.mapValue["entrymsg"] = ((frmProps)props).EntryMessage;
            this.mapValue["options"] = ((frmProps)props).Options;
            this.mapValue["variable"] = ((frmProps)props).Variable;
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

        [System.ComponentModel.CategoryAttribute("Settings"), System.ComponentModel.DescriptionAttribute("Options for Read command.")]
        public string Options
        {
            get
            {
                try
                {
                    return Convert.ToString(this.mapValue["options"]);
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

        [System.ComponentModel.CategoryAttribute("Settings"), System.ComponentModel.DescriptionAttribute("Variable for receiving DTMF.")]
        public string Result
        {
            get
            {
                try
                {
                    return Convert.ToString(this.mapValue["variable"]);
                }
                catch (Exception ex)
                {
                }

                return "";
            }
            set
            {
                this.mapValue["variable"] = Convert.ToString(value);
            }
        }
    }
}
