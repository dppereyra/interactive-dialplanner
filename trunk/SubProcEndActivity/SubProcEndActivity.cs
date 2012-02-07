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

namespace Interaction.Graph
{
    public class SubProcEndActivity : AbstractActivity, IActivity
    {
        public SubProcEndActivity() : base()
        {
            logo = Properties.Resources.block;
            this.strActivityName = Properties.Resources.ActivityName;
            existToolBox = true;
        }

        ~SubProcEndActivity()
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
            ((frmProps)props).Description = lblDescription.Text;
            ((frmProps)props).PropertyResult = this.ActivityValue;
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
            frmProps frm = this.props as frmProps;
            this.ActivityValue = frm.PropertyResult;
            lblDescription.Text = frm.Description;

        }
        public void ShowProperty(System.Windows.Forms.PropertyGrid grid)
        {
            grid.SelectedObject = this;
        }

        [System.ComponentModel.CategoryAttribute("Settings"), System.ComponentModel.DescriptionAttribute("Return value for the sub procedure flow.")]
        public string ReturnValue
        {
            get
            {
                try
                {
                    return Convert.ToString(this.ActivityValue);
                }
                catch (Exception ex)
                {
                }

                return "";
            }
            set
            {
                this.ActivityValue = Convert.ToString(value);
            }
        }
    }
}
