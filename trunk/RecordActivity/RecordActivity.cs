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
using System.Drawing.Design;

namespace Interaction.Graph
{
    public class RecordActivity : AbstractActivity, IActivity
    {
        public RecordActivity():base()
        {
            logo = Properties.Resources.block;
            this.strActivityName = Properties.Resources.ActivityName;
            existToolBox = true;
        }

        ~RecordActivity()
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

        public void DoAction(IDrawingBoard board, IGraphEvent graphEvt)
        {
            lblDescription.Text = ((frmProps)props).Description;
            this.mapValue["silent"] = Convert.ToString(((frmProps)props).Silent);
            this.mapValue["duration"] = Convert.ToString(((frmProps)props).Duration);
            this.mapValue["filename"] = ((frmProps)props).FileName;
            this.mapValue["options"] = ((frmProps)props).Options;
            this.mapValue["format"] = ((frmProps)props).Format;
        }

        public void ShowProperty(System.Windows.Forms.PropertyGrid grid)
        {
            grid.SelectedObject = this;
        }


        private void OnAddedEventHandler(object sender, ObjectCreatedEventArgs arg)
        {
        }

        [System.ComponentModel.CategoryAttribute("Settings"), System.ComponentModel.DescriptionAttribute("Seconds of silence allowed before the recording is stopped. If missing or 0, silence detection is disabled.")]
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

                return 5;
            }
            set
            {
                this.mapValue["silent"] = Convert.ToString(value);
            }
        }

        [System.ComponentModel.CategoryAttribute("Settings"), System.ComponentModel.DescriptionAttribute("Maximum recording duration in seconds. If missing or 0, there is no maximum. ")]
        public int Duration
        {
            get
            {
                try
                {
                    return Convert.ToInt32(this.mapValue["duration"]);
                }
                catch (Exception ex)
                {
                }

                return 0;
            }
            set
            {
                this.mapValue["duration"] = Convert.ToString(value);
            }
        }

        [System.ComponentModel.CategoryAttribute("Settings"), System.ComponentModel.DescriptionAttribute("May be 'skip' to return immediately if the line is not up, or 'noanswer' to record even if the line is not up.")]
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

        [System.ComponentModel.CategoryAttribute("Settings"), System.ComponentModel.DescriptionAttribute("Records  to a sound file saved with this given filename")]
        public string FileName
        {
            get
            {
                try
                {
                    return Convert.ToString(this.mapValue["filename"]);
                }
                catch (Exception ex)
                {
                }

                return "";
            }
            set
            {
                this.mapValue["filename"] = Convert.ToString(value);
            }
        }

        [Editor(typeof(DennisWuWorks.InteractiveBuilder.ComboBox.ListGridComboBox), typeof(UITypeEditor))]
        [DataList("RecordActivity", "Interaction.Graph.SupplyStore", "Instance.Operator", false, "OnAddedEventHandler")]
        [CategoryAttribute("Settings"), DescriptionAttribute("Specifies the sound format and the extension of the file."), DisplayName("Format")]
        public string Format
        {
            get
            {
                try
                {
                    return this.mapValue["format"];
                }
                catch (Exception ex)
                {
                }

                return "";
            }
            set
            {
                this.mapValue["format"] = Convert.ToString(value);
            }
        }
    }
}
