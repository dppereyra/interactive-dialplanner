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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Interaction.Graph
{
    public partial class frmProps : Form
    {
        private IActivity icon = null;

        public frmProps()
        {
            InitializeComponent();

        }


        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (GraphContainer.Instance.FindDuplicateActivityDescription(icon.ActivityID, txtLabel.Text))
            {
                MessageBox.Show("Duplicated activity name");
                return;
            }

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }



        private void frmProps_Load(object sender, EventArgs e)
        {
            this.Text = Properties.Resources.ActivityName + " Properties";

            if (icon != null)
            {
                txtLabel.Text = icon.Description;

                if (icon.Values().ContainsKey("timerange"))
                {
                    txtTimeRange.Text = icon.Values()["timerange"];
                }
                else
                {
                    txtTimeRange.Text = "*";
                }

                if (icon.Values().ContainsKey("dow"))
                {
                    txtDow.Text = icon.Values()["dow"];
                }
                else
                {
                    txtDow.Text = "*";
                }

                if (icon.Values().ContainsKey("dom"))
                {
                    txtDom.Text = icon.Values()["dom"];
                }
                else
                {
                    txtDom.Text = "*";
                }

                if (icon.Values().ContainsKey("month"))
                {
                    txtMonth.Text = icon.Values()["month"];
                }
                else
                {
                    txtMonth.Text = "*";
                }
            }

        }

        public IActivity Activities
        {
            get
            {
                return icon;
            }
            set
            {
                icon = value;
            }
        }

        public string Description
        {
            get
            {
                return txtLabel.Text;
            }

            set
            {
                txtLabel.Text = value;
            }
        }

        public string TimeRange
        {
            get
            {
                return txtTimeRange.Text;
            }

            set
            {
                txtTimeRange.Text = value;
            }
        }

        public string DateOfWeek
        {
            get
            {
                return txtDow.Text;
            }

            set
            {
                txtDow.Text = value;
            }
        }

        public string DateOfMonth
        {
            get
            {
                return txtDom.Text;
            }

            set
            {
                txtDom.Text = value;
            }
        }

        public string Months
        {
            get
            {
                return txtMonth.Text;
            }

            set
            {
                txtMonth.Text = value;
            }
        }

        private void cmdVar_Click(object sender, EventArgs e)
        {
            GraphContainer.Instance.MaintainVariable();

        }

        private void txtFileName_DragDrop(object sender, DragEventArgs e)
        {
            string strVar = e.Data.GetData(DataFormats.Text).ToString();
            txtTimeRange.Text = strVar;
            GraphContainer.Instance.VariableMouseDown = false;

        }

        private void txtFileName_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
                e.Effect = DragDropEffects.None;

        }

        private void txtDow_DragDrop(object sender, DragEventArgs e)
        {
            string strVar = e.Data.GetData(DataFormats.Text).ToString();
            txtDow.Text = strVar;
            GraphContainer.Instance.VariableMouseDown = false;

        }

        private void txtDow_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
                e.Effect = DragDropEffects.None;

        }

        private void txtDom_DragDrop(object sender, DragEventArgs e)
        {
            string strVar = e.Data.GetData(DataFormats.Text).ToString();
            txtDom.Text = strVar;
            GraphContainer.Instance.VariableMouseDown = false;

        }

        private void txtDom_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
                e.Effect = DragDropEffects.None;

        }

        private void txtMonth_DragDrop(object sender, DragEventArgs e)
        {
            string strVar = e.Data.GetData(DataFormats.Text).ToString();
            txtMonth.Text = strVar;
            GraphContainer.Instance.VariableMouseDown = false;

        }

        private void txtMonth_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
                e.Effect = DragDropEffects.None;

        }


        private void cmdTimeRange_Click(object sender, EventArgs e)
        {
            frmWizard wizard = new frmWizard();
            string[] str1 = null;
            string[] str2 = null;

            wizard.ChangeType = 1;

            if (txtTimeRange.Text.Trim().Length > 0)
            {
                if (txtTimeRange.Text.Trim() == "*")
                {
                    wizard.Hour1 = -1;
                    wizard.Hour2 = -1;
                    wizard.Minute1 = -1;
                    wizard.Minute2 = -1;
                }
                else
                {
                    try
                    {
                        str1 = txtTimeRange.Text.Trim().Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                        if (str1.Length > 0)
                        {
                            if (str1.Length == 1)
                            {
                                str2 = str1[0].Trim().Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                                if (str2.Length == 2)
                                {
                                    wizard.Hour1 = Convert.ToInt32(str2[0]);
                                    wizard.Minute1 = Convert.ToInt32(str2[1]);
                                }
                                wizard.Hour2 = -1;
                                wizard.Minute2 = -1;
                            }
                            else if (str1.Length == 2)
                            {
                                str2 = str1[0].Trim().Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                                if (str2.Length == 2)
                                {
                                    wizard.Hour1 = Convert.ToInt32(str2[0]);
                                    wizard.Minute1 = Convert.ToInt32(str2[1]);
                                }

                                str2 = str1[1].Trim().Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                                if (str2.Length == 2)
                                {
                                    wizard.Hour2 = Convert.ToInt32(str2[0]);
                                    wizard.Minute2 = Convert.ToInt32(str2[1]);
                                }

                            }
                            else
                            {
                                wizard.Hour1 = -1;
                                wizard.Minute1 = -1;
                                wizard.Hour2 = -1;
                                wizard.Minute2 = -1;
                            }
                        }
                        else
                        {
                            wizard.Hour1 = -1;
                            wizard.Hour2 = -1;
                            wizard.Minute1 = -1;
                            wizard.Minute2 = -1;
                        }
                    }
                    catch (Exception ex)
                    {
                        wizard.Hour1 = -1;
                        wizard.Hour2 = -1;
                        wizard.Minute1 = -1;
                        wizard.Minute2 = -1;
                    }
                }
            }
            else
            {
                wizard.Hour1 = -1;
                wizard.Hour2 = -1;
                wizard.Minute1 = -1;
                wizard.Minute2 = -1;
            }


            if (wizard.ShowDialog() == DialogResult.OK)
            {
                string strTime1 = "";
                string strTime2 = "";

                if (wizard.Hour1 >= 0 && wizard.Minute1 >= 0)
                {
                    strTime1 = string.Format("{0:00}:{1:00}", new object[] { wizard.Hour1, wizard.Minute1 });
                }
                else
                {
                    strTime1 = "*";
                }

                if (wizard.Hour2 >= 0 && wizard.Minute2 >= 0)
                {
                    strTime2 = string.Format("{0:00}:{1:00}", new object[] { wizard.Hour2, wizard.Minute2 });
                }
                else
                {
                    strTime2 = "*";
                }

                if (strTime2 == "*" && strTime1 == "*")
                {
                    txtTimeRange.Text = "*";
                }
                else if (strTime1 != "*" && strTime2 == "*")
                {
                    txtTimeRange.Text = strTime1;
                }
                else if (strTime2 != "*" && strTime1 == "*")
                {
                    txtTimeRange.Text = strTime2;
                }
                else
                {
                    txtTimeRange.Text = strTime1 + "-" + strTime2;
                }
            }
        }

        private void cmdDow_Click(object sender, EventArgs e)
        {
            frmWizard wizard = new frmWizard();
            string[] str1 = null;
            string[] str2 = null;

            wizard.ChangeType = 2;

            if (txtDow.Text.Trim().Length > 0)
            {
                if (txtDow.Text.Trim() == "*")
                {
                    wizard.Week1 = "*";
                    wizard.Week2 = "*";
                }
                else
                {
                    try
                    {
                        str1 = txtDow.Text.Trim().Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                        if (str1.Length > 0)
                        {
                            if (str1.Length == 1)
                            {
                                wizard.Week1 = str1[0].Trim();
                                wizard.Week2 = "*";
                            }
                            else if (str1.Length == 2)
                            {
                                wizard.Week1 = str1[0].Trim();
                                wizard.Week2 = str1[1].Trim();
                            }
                            else
                            {
                                wizard.Week1 = "*";
                                wizard.Week2 = "*";
                            }
                        }
                        else
                        {
                            wizard.Week1 = "*";
                            wizard.Week2 = "*";
                        }
                    }
                    catch (Exception ex)
                    {
                        wizard.Week1 = "*";
                        wizard.Week2 = "*";
                    }
                }
            }
            else
            {
                wizard.Week1 = "*";
                wizard.Week2 = "*";
            }

            if (wizard.ShowDialog() == DialogResult.OK)
            {
                string strTime1 = "";
                string strTime2 = "";

                strTime1 = wizard.Week1.Trim();
                strTime2 = wizard.Week2.Trim();

                if (strTime1 == "" && strTime2 == "")
                {
                    txtDow.Text = "*";
                }
                else if (strTime1 == "" && strTime2.Length > 0)
                {
                    txtDow.Text = strTime2;
                }
                else if (strTime2 == "" && strTime1.Length > 0)
                {
                    txtDow.Text = strTime1;
                }
                else
                {
                    txtDow.Text = strTime1 + "-" + strTime2;

                }
            }

        }

        private void cmdDom_Click(object sender, EventArgs e)
        {
            frmWizard wizard = new frmWizard();
            string[] str1 = null;
            string[] str2 = null;

            wizard.ChangeType = 3;

            if (txtDom.Text.Trim().Length > 0)
            {
                if (txtDom.Text.Trim() == "*")
                {
                    wizard.DateOfMonth1 = 0;
                    wizard.DateOfMonth2 = 0;
                }
                else
                {
                    try
                    {
                        str1 = txtDom.Text.Trim().Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                        if (str1.Length > 0)
                        {
                            if (str1.Length == 1)
                            {
                                if (str1[0].Trim() == "*")
                                {
                                    wizard.DateOfMonth1 = 0;
                                }
                                else
                                {
                                    wizard.DateOfMonth1 = Convert.ToInt32(str1[0]);
                                }

                                wizard.DateOfMonth2 = 0;
                            }
                            else if (str1.Length == 2)
                            {
                                if (str1[0].Trim() == "*")
                                {
                                    wizard.DateOfMonth1 = 0;
                                }
                                else
                                {
                                    wizard.DateOfMonth1 = Convert.ToInt32(str1[0]);
                                }

                                if (str1[1].Trim() == "*")
                                {
                                    wizard.DateOfMonth2 = 0;
                                }
                                else
                                {
                                    wizard.DateOfMonth2 = Convert.ToInt32(str1[1]);
                                }
                            }
                            else
                            {
                                wizard.DateOfMonth1 = 0;
                                wizard.DateOfMonth2 = 0;
                            }
                        }
                        else
                        {
                            wizard.DateOfMonth1 = 0;
                            wizard.DateOfMonth2 = 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        wizard.DateOfMonth1 = 0;
                        wizard.DateOfMonth2 = 0;
                    }
                }
            }
            else
            {
                wizard.DateOfMonth1 = 0;
                wizard.DateOfMonth2 = 0;
            }


            if (wizard.ShowDialog() == DialogResult.OK)
            {

                if (wizard.DateOfMonth1 > 0 && wizard.DateOfMonth2 > 0)
                {
                    txtDom.Text = string.Format("{0}-{1}", new object[] { wizard.DateOfMonth1, wizard.DateOfMonth2 });
                }
                else if (wizard.DateOfMonth1 > 0)
                {
                    txtDom.Text = string.Format("{0}", new object[] { wizard.DateOfMonth1 });
                }
                else if (wizard.DateOfMonth2 > 0)
                {
                    txtDom.Text = string.Format("{0}", new object[] { wizard.DateOfMonth2 });
                }
                else
                {
                    txtDom.Text = "*";

                }
            }
        }

        private void cmdMonth_Click(object sender, EventArgs e)
        {
            frmWizard wizard = new frmWizard();
            string[] str1 = null;
            string[] str2 = null;

            wizard.ChangeType = 4;

            if (txtMonth.Text.Trim().Length > 0)
            {
                if (txtMonth.Text.Trim() == "*")
                {
                    wizard.Month1 = "*";
                    wizard.Month2 = "*";
                }
                else
                {
                    try
                    {
                        str1 = txtMonth.Text.Trim().Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                        if (str1.Length > 0)
                        {
                            if (str1.Length == 1)
                            {
                                wizard.Month1 = str1[0].Trim();
                                wizard.Month2 = "*";
                            }
                            else if (str1.Length == 2)
                            {
                                wizard.Month1 = str1[0].Trim();
                                wizard.Month2 = str1[1].Trim();
                            }
                            else
                            {
                                wizard.Month1 = "*";
                                wizard.Month2 = "*";
                            }
                        }
                        else
                        {
                            wizard.Month1 = "*";
                            wizard.Month2 = "*";
                        }
                    }
                    catch (Exception ex)
                    {
                        wizard.Month1 = "*";
                        wizard.Month2 = "*";
                    }
                }
            }
            else
            {
                wizard.Month1 = "*";
                wizard.Month2 = "*";
            }

            if (wizard.ShowDialog() == DialogResult.OK)
            {
                string strTime1 = "";
                string strTime2 = "";

                strTime1 = wizard.Month1.Trim();
                strTime2 = wizard.Month2.Trim();

                if (strTime1 == "" && strTime2 == "")
                {
                    txtMonth.Text = "*";
                }
                else if (strTime1 == "" && strTime2.Length > 0)
                {
                    txtMonth.Text = strTime2;
                }
                else if (strTime2 == "" && strTime1.Length > 0)
                {
                    txtMonth.Text = strTime1;
                }
                else
                {
                    txtMonth.Text = strTime1 + "-" + strTime2;

                }
            }

        }


    }
}
