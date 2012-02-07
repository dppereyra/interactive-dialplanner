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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Interaction.Graph
{
    public partial class frmVariable : Form
    {
        public frmVariable()
        {
            InitializeComponent();
        }

        private void frmVariable_Load(object sender, EventArgs e)
        {
            this.Text = "Variables";
            lstVar.Sorted = true;

            foreach (string strVar in GraphContainer.Instance.Variable)
            {
                lstVar.Items.Add(strVar);
            }

            foreach (string strVar2 in GraphContainer.Instance.SysVariable)
            {
                this.lstVarSystem.Items.Add(strVar2);
            }
        }

        private void cmdRemove_Click(object sender, EventArgs e)
        {
            for (int i = lstVar.SelectedItems.Count - 1; i >= 0; i--)
            {
                foreach (string ss in GraphContainer.Instance.Variable)
                {
                    if (ss == lstVar.SelectedItems[i].ToString())
                    {
                        GraphContainer.Instance.Variable.Remove(ss);
                        lstVar.Items.Remove(lstVar.SelectedItems[i]);
                        break;
                    }
                }

            }

        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            frmAddVar frm = new frmAddVar();
            frm.TopMost = true;
            frm.ShowDialog();

            if(frm.Var.Length > 0)
                lstVar.Items.Add(frm.Var);
        }

        private void lstVar_MouseDown(object sender, MouseEventArgs e)
        {
            //GraphContainer.Instance.VariableMouseDown = true;
            string str = "";

            if (e.Button == MouseButtons.Right)
                return;

            int index = lstVar.IndexFromPoint(e.X, e.Y);
            if (index >= 0)
            {
                str = lstVar.Items[index].ToString();

                DragDropEffects dde1 = DoDragDrop(str, DragDropEffects.Copy | DragDropEffects.Move);

                if (dde1 == (DragDropEffects.Copy | DragDropEffects.Move))
                {
                    lstVar.Items.RemoveAt(lstVar.IndexFromPoint(e.X, e.Y));
                }
            }
        }

        private void lstVar_MouseUp(object sender, MouseEventArgs e)
        {
            //GraphContainer.Instance.VariableMouseDown = false;

        }

        private void lstVar_MouseMove(object sender, MouseEventArgs e)
        {
            /*
            string str = "";

            if (!GraphContainer.Instance.VariableMouseDown)
                return;

            if (e.Button == MouseButtons.Right)
                return;

            if (lstVar.SelectedIndices.Count == 1)
            {
                str = lstVar.SelectedItems[0] as string;
                lstVar.DoDragDrop(str, DragDropEffects.Copy | DragDropEffects.Move);
            }
            */
        }

        private void lstVarSystem_MouseDown(object sender, MouseEventArgs e)
        {
//            GraphContainer.Instance.VariableMouseDown = true;
            string str = "";

            if (e.Button == MouseButtons.Right)
                return;

            int index = lstVarSystem.IndexFromPoint(e.X, e.Y);
            str = lstVarSystem.Items[index].ToString();

            DragDropEffects dde1 = DoDragDrop(str, DragDropEffects.Copy | DragDropEffects.Move);

            if (dde1 == (DragDropEffects.Copy | DragDropEffects.Move))
            {
                lstVarSystem.Items.RemoveAt(lstVarSystem.IndexFromPoint(e.X, e.Y));
            }

        }

        private void lstVarSystem_MouseMove(object sender, MouseEventArgs e)
        {
            /*
            string str = "";

            if (!GraphContainer.Instance.VariableMouseDown)
                return;

            if (e.Button == MouseButtons.Right)
                return;

            if (lstVarSystem.SelectedIndices.Count == 1)
            {
                str = lstVarSystem.SelectedItems[0] as string;
                lstVarSystem.DoDragDrop(str, DragDropEffects.Copy | DragDropEffects.Move);
            }
             */
        }

        private void lstVarSystem_MouseUp(object sender, MouseEventArgs e)
        {
            //GraphContainer.Instance.VariableMouseDown = false;

        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

    }
}
