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
using System.Threading;
using Interaction.Graph;
using System.Diagnostics;

namespace DennisWuWorks.InteractiveBuilder
{
    public partial class frmLoadActivity : Form
    {
        private ThreadStart compileJob = null;
        private Thread compileThread = null;
        private ManualResetEvent eventIn = null;
        private ActivityCreator p = ActivityCreator.Instance;
        delegate void CloseCallback();
        delegate void PrintMsgCallback(string str);
        ActivityCreator.NotifyLoadInstance func;
        private bool isClose = false;

        public frmLoadActivity()
        {
            InitializeComponent();
            eventIn = new ManualResetEvent(false);
            func = new ActivityCreator.NotifyLoadInstance(p_NotifyLoadInstanceEvent);
            p.NotifyLoadInstanceEvent += func;
        }

        void p_NotifyLoadInstanceEvent(object sender, NotifyEventArgs args)
        {
            PrintMsgCallback c = new PrintMsgCallback(InternalPrintMsg);
            this.Invoke(c, new object[]{args.m_Msg});
        }

        private void frmLoadActivity_Load(object sender, EventArgs e)
        {
            //int width = label2.Width + pictureBox2.Width + 30;
            //this.Width = width;

            label4.Text = "Version " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            Start();
        }

        private void LoadActivityJob()
        {
            ActivityCreator.Instance.LoadActivity();
            eventIn.Set();
            Stop();
        }

        public void Start()
        {
            compileJob = new ThreadStart(LoadActivityJob);
            compileThread = new Thread(compileJob);
            compileThread.Start();
        }

        public void Stop()
        {
            CloseCallback c = new CloseCallback(InternalClose);
            this.Invoke(c);
        }

        private void InternalClose()
        {
            isClose = true;
            this.Close();
        }

        private void InternalPrintMsg(string s)
        {
            lblModule.Text = s;
        }

        private void frmLoadActivity_FormClosed(object sender, FormClosedEventArgs e)
        {
            p.NotifyLoadInstanceEvent -= func;
            func = null;
        }

        private void frmLoadActivity_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((e.CloseReason == CloseReason.UserClosing) && !isClose)
            {
                e.Cancel = true;
            }
        }

        private void frmLoadActivity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F4)
            {
            }
            else if (e.Alt && e.KeyCode == Keys.F4)
            {
            }

        }

        public bool IsClose
        {
            get
            {
                return isClose;
            }

            set
            {
                isClose = value;
            }
        }
    }
}
