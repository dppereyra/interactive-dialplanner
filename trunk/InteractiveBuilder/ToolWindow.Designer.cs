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
namespace DennisWuWorks.InteractiveBuilder
{
    partial class ToolWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            //this.option1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            //this.option2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            //this.option3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            //// 
            //// contextMenuStrip1
            //// 
            //this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            //this.option1ToolStripMenuItem,
            //this.option2ToolStripMenuItem,
            //this.option3ToolStripMenuItem});
            //this.contextMenuStrip1.Name = "contextMenuStrip1";
            //this.contextMenuStrip1.Size = new System.Drawing.Size(113, 70);
            //// 
            //// option1ToolStripMenuItem
            //// 
            //this.option1ToolStripMenuItem.Name = "option1ToolStripMenuItem";
            //this.option1ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            //this.option1ToolStripMenuItem.Text = "Option&1";
            //// 
            //// option2ToolStripMenuItem
            //// 
            //this.option2ToolStripMenuItem.Name = "option2ToolStripMenuItem";
            //this.option2ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            //this.option2ToolStripMenuItem.Text = "Option&2";
            //// 
            //// option3ToolStripMenuItem
            //// 
            //this.option3ToolStripMenuItem.Name = "option3ToolStripMenuItem";
            //this.option3ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            //this.option3ToolStripMenuItem.Text = "Option&3";
            // 
            // ToolWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft)
                        | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight)
                        | WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop)
                        | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom)));
            this.Name = "ToolWindow";
            this.TabPageContextMenuStrip = this.contextMenuStrip1;
            this.TabText = "ToolWindow";
            this.Text = "ToolWindow";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        //private System.Windows.Forms.ToolStripMenuItem option1ToolStripMenuItem;
        //private System.Windows.Forms.ToolStripMenuItem option2ToolStripMenuItem;
        //private System.Windows.Forms.ToolStripMenuItem option3ToolStripMenuItem;
    }
}