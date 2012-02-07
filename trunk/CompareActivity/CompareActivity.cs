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
using System.Drawing.Design;
using DennisWuWorks.InteractiveBuilder;
using DennisWuWorks.InteractiveBuilder.Data;

namespace Interaction.Graph
{
    public class CompareActivity : AbstractActivity, IActivity
    {
        public CompareActivity():base()
        {
            logo = Properties.Resources.block;
            this.strActivityName = Properties.Resources.ActivityName;
            existToolBox = true;
        }

        ~CompareActivity()
        {
            _listNodes.Clear();
        }

        public void PreLoadIcon(IDrawingBoard board, IGraphEvent graphEvt, Point pos)
        {
            Node node = GraphContainer.Instance.CreateNode(board, graphEvt, System.Guid.NewGuid().ToString(), "Yes", false, true);
            //board.AddControl(node.Label);
            node.NodeValue = "Yes";
            this.Add(node);

            node = GraphContainer.Instance.CreateNode(board, graphEvt, System.Guid.NewGuid().ToString(), "No", false, true);
            //board.AddControl(node.Label);
            node.NodeValue = "No";
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
            this.mapValue["variable1"] = Convert.ToString(((frmProps)props).Variable1);
            this.mapValue["operator"] = Convert.ToString(((frmProps)props).Operator);
            this.mapValue["variable2"] = Convert.ToString(((frmProps)props).Variable2);
        }
        [System.ComponentModel.CategoryAttribute("Settings"), System.ComponentModel.DescriptionAttribute("Variable1")]
        public string Variable1
        {
            get
            {
                try
                {
                    return Convert.ToString(this.mapValue["variable1"]);
                }
                catch (Exception ex)
                {
                }

                return "";
            }
            set
            {
                this.mapValue["variable1"] = Convert.ToString(value);
            }
        }
        [System.ComponentModel.CategoryAttribute("Settings"), System.ComponentModel.DescriptionAttribute("Variable2")]
        public string Variable2
        {
            get
            {
                try
                {
                    return Convert.ToString(this.mapValue["variable2"]);
                }
                catch (Exception ex)
                {
                }

                return "";
            }
            set
            {
                this.mapValue["variable2"] = Convert.ToString(value);
            }
        }

        [Editor(typeof(DennisWuWorks.InteractiveBuilder.ComboBox.ListGridComboBox), typeof(UITypeEditor))]
        [DataList("CompareActivity", "Interaction.Graph.SupplyStore", "Instance.OperatorType", false, "OnAddedEventHandler")]
        [CategoryAttribute("Settings"), DescriptionAttribute("Operator"), DisplayName("Operator")]
        public string Operator
        {
            get
            {
                try
                {
                    return this.mapValue["operator"];
                }
                catch (Exception ex)
                {
                }

                return "";
            }
            set
            {
                this.mapValue["operator"] = Convert.ToString(value);
            }
        }

        public void ShowProperty(System.Windows.Forms.PropertyGrid grid)
        {
            grid.SelectedObject = this;
        }


        private void OnAddedEventHandler(object sender, ObjectCreatedEventArgs arg)
        {
        }
    }
}
