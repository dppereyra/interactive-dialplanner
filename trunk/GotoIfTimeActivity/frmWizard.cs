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
    public partial class frmWizard : Form
    {
        private Dictionary<string, int> mapWeek = new Dictionary<string, int>();
        private Dictionary<string, int> mapMonth = new Dictionary<string, int>();

        public frmWizard()
        {
            InitializeComponent();

            mapWeek["*"] = 0;
            mapWeek["sun"] = 1;
            mapWeek["mon"] = 2;
            mapWeek["tue"] = 3;
            mapWeek["wed"] = 4;
            mapWeek["thu"] = 5;
            mapWeek["fri"] = 6;
            mapWeek["sat"] = 7;

            mapMonth["*"] = 0;
            mapMonth["jan"] = 1;
            mapMonth["feb"] = 2;
            mapMonth["mar"] = 3;
            mapMonth["apr"] = 4;
            mapMonth["may"] = 5;
            mapMonth["jun"] = 6;
            mapMonth["jul"] = 7;
            mapMonth["aug"] = 8;
            mapMonth["sep"] = 9;
            mapMonth["oct"] = 10;
            mapMonth["nov"] = 11;
            mapMonth["dec"] = 12;

        }

        private void frmWizard_Load(object sender, EventArgs e)
        {

        }

        public int ChangeType
        {
            set
            {
                switch (value)
                {
                    case 1:
                        txtHour1.Enabled = true;
                        txtHour2.Enabled = true;
                        txtMin1.Enabled = true;
                        txtMin2.Enabled = true;
                        break;
                    case 2:
                        cboWeek2.Enabled = true;
                        cboWeek1.Enabled = true;
                        break;
                    case 3:
                        txtMon1.Enabled = true;
                        txtMon2.Enabled = true;
                        break;
                    case 4:
                        cboMon1.Enabled = true;
                        cboMon2.Enabled = true;
                        break;

                }
            }

            get
            {
                return -1;
            }
        }


        public int Hour1
        {
            get
            {
                return Convert.ToInt32(txtHour1.Value);
            }

            set
            {
                txtHour1.Value = value;
            }
        }

        public int Hour2
        {
            get
            {
                return Convert.ToInt32(txtHour2.Value);
            }

            set
            {
                txtHour2.Value = value;
            }
        }
        public int Minute1
        {
            get
            {
                return Convert.ToInt32(txtMin1.Value);
            }

            set
            {
                txtMin1.Value = value;
            }
        }
        public int Minute2
        {
            get
            {
                return Convert.ToInt32(txtMin2.Value);
            }

            set
            {
                txtMin2.Value = value;
            }
        }

        public int DateOfMonth1
        {
            get
            {
                return Convert.ToInt32(txtMon1.Value);
            }

            set
            {
                txtMon1.Value = value;
            }
        }

        public int DateOfMonth2
        {
            get
            {
                return Convert.ToInt32(txtMon2.Value);
            }

            set
            {
                txtMon2.Value = value;
            }
        }

        public string Week1
        {
            get
            {
                return cboWeek1.Text;
            }

            set
            {
                try
                {

                    if (mapWeek.ContainsKey(value))
                    {
                        cboWeek1.SelectedIndex = mapWeek[value];
                    }
                    else
                    {
                        cboWeek1.SelectedIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                }

            }
        }

        public string Week2
        {
            get
            {
                return cboWeek2.Text;
            }

            set
            {
                try
                {

                    if (mapWeek.ContainsKey(value))
                    {
                        cboWeek2.SelectedIndex = mapWeek[value];
                    }
                    else
                    {
                        cboWeek2.SelectedIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                }

            }
        }

        public string Month1
        {
            get
            {
                return cboMon1.Text;
            }

            set
            {
                try
                {

                    if (mapMonth.ContainsKey(value))
                    {
                        cboMon1.SelectedIndex = mapMonth[value];
                    }
                    else
                    {
                        cboMon1.SelectedIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                }

            }
        }

        public string Month2
        {
            get
            {
                return cboMon2.Text;
            }

            set
            {
                try
                {
                    if (mapMonth.ContainsKey(value))
                    {
                        cboMon2.SelectedIndex = mapMonth[value];
                    }
                    else
                    {
                        cboMon2.SelectedIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                }

            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();

        }
    }
}
