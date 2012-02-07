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

namespace Interaction.Graph
{
    partial class DrawingBoard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // DrawingBoard
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(1, 1);
            this.BackColor = System.Drawing.Color.LightGreen;
            this.BackgroundImage = global::Interaction.Graph.Properties.Resources.graphunit;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DoubleBuffered = true;
            this.Name = "DrawingBoard";
            this.Size = new System.Drawing.Size(706, 450);
            this.Load += new System.EventHandler(this.DrawingBoard_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawingBoard_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawingBoard_MouseMove);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DrawingBoard_MouseDoubleClick);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.DrawingBoard_DragDrop);
            this.Scroll += new System.Windows.Forms.ScrollEventHandler(this.DrawingBoard_Scroll);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawingBoard_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DrawingBoard_MouseUp);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.DrawingBoard_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DrawingBoard_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion


    }
}
