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


namespace Interaction.Graph
{
    [DefaultPropertyAttribute("Name")]
    public class CutActivity : AbstractActivity, IActivity
    {
        public CutActivity():base()
        {
            logo = Properties.Resources.block;
            this.strActivityName = Properties.Resources.ActivityName;
            existToolBox = true;
        }

        ~CutActivity()
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
            this.mapValue["var"] = Convert.ToString(((frmProps)props).Variable);
            this.mapValue["result"] = Convert.ToString(((frmProps)props).Result);
            this.mapValue["offset"] = Convert.ToString(((frmProps)props).Offset);
            this.mapValue["length"] = Convert.ToString(((frmProps)props).Length);
        }

        [CategoryAttribute("Settings"), DescriptionAttribute("Source variable to cut")]
        public string SourceString
        {
            get
            {
                try
                {
                    return this.mapValue["var"];
                }
                catch (Exception ex)
                {
                }

                return "";
            }
            set
            {
                this.mapValue["var"] = value;
            }
        }

        [CategoryAttribute("Settings"), DescriptionAttribute("Variable to store the result")]
        public string ToVariable
        {
            get
            {
                try
                {
                    return this.mapValue["result"];
                }
                catch (Exception ex)
                {
                }

                return "";
            }
            set
            {
                this.mapValue["result"] = value;
            }
        }

        [System.ComponentModel.CategoryAttribute("Offset"), System.ComponentModel.DescriptionAttribute("Offset of the string")]
        public int Offset
        {
            get
            {
                try
                {
                    return Convert.ToInt32(this.mapValue["offset"]);
                }
                catch (Exception ex)
                {
                }

                return 0;
            }
            set
            {
                this.mapValue["offset"] = Convert.ToString(value);
            }
        }

        [System.ComponentModel.CategoryAttribute("Length"), System.ComponentModel.DescriptionAttribute("Length of the selected string")]
        public int Length
        {
            get
            {
                try
                {
                    return Convert.ToInt32(this.mapValue["length"]);
                }
                catch (Exception ex)
                {
                }

                return 0;
            }
            set
            {
                this.mapValue["length"] = Convert.ToString(value);
            }
        }

        public void ShowProperty(System.Windows.Forms.PropertyGrid grid)
        {
            grid.SelectedObject = this;
        }

    }
}
