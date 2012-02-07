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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DennisWuWorks.InteractiveBuilder
{
    public partial class frmProductPreview : Form
    {
        public frmProductPreview()
        {
            InitializeComponent();
        }

        private void frmProductPreview_Load(object sender, EventArgs e)
        {
            lblDesc.Text = "Interactive CallFlow Builder Lite is a development tool for helping you to" + Environment.NewLine;
            lblDesc.Text += "build up IVR call flow for Asterisk PBX more easily.  It is free of charge" + Environment.NewLine;
            lblDesc.Text += "that to simplify the development life cycle of Asterisk dialplan implementation." + Environment.NewLine;
            lblDesc.Text += "Simply drag-and-drop the building blocks (Call Flow Controls) that you want as" + Environment.NewLine;
            lblDesc.Text += "you create your call flow." + Environment.NewLine;
            lblDesc.Text += Environment.NewLine;
            //lblDesc.Text += "Visit our website to see more useful information about you needs." + Environment.NewLine;


        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.denniswuworks.com");
        }
    }
}
