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
    partial class GraphDoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraphDoc));
            this.drawingBoard = new Interaction.Graph.DrawingBoard();
            this.SuspendLayout();
            // 
            // drawingBoard
            // 
            this.drawingBoard.AllowDrop = true;
            this.drawingBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.drawingBoard.AutoScroll = true;
            this.drawingBoard.AutoScrollMinSize = new System.Drawing.Size(1, 1);
            this.drawingBoard.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.drawingBoard.DocID = "";
            this.drawingBoard.FlowName = "";
            this.drawingBoard.Location = new System.Drawing.Point(2, 2);
            this.drawingBoard.Name = "drawingBoard";
            this.drawingBoard.Size = new System.Drawing.Size(841, 566);
            this.drawingBoard.TabIndex = 0;
            this.drawingBoard.KeyDown += new System.Windows.Forms.KeyEventHandler(this.drawingBoard_KeyDown);
            // 
            // GraphDoc
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 622);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.drawingBoard);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "GraphDoc";
            this.Text = "GraphDoc";
            this.Load += new System.EventHandler(this.GraphDoc_Load);
            this.ClientSizeChanged += new System.EventHandler(this.GraphDoc_ClientSizeChanged);
            this.Activated += new System.EventHandler(this.GraphDoc_Activated);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.GraphDoc_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.GraphDoc_DragEnter);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GraphDoc_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GraphDoc_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private Interaction.Graph.DrawingBoard drawingBoard;

    }
}