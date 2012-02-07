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
    partial class frmTaskList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTaskList));
            this.lstTaskList = new System.Windows.Forms.ListView();
            this.colDesc = new System.Windows.Forms.ColumnHeader();
            this.colFlow = new System.Windows.Forms.ColumnHeader();
            this.colActivity = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lstTaskList
            // 
            this.lstTaskList.AllowColumnReorder = true;
            this.lstTaskList.AutoArrange = false;
            this.lstTaskList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDesc,
            this.colFlow,
            this.colActivity});
            this.lstTaskList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstTaskList.FullRowSelect = true;
            this.lstTaskList.HideSelection = false;
            this.lstTaskList.Location = new System.Drawing.Point(0, 3);
            this.lstTaskList.MultiSelect = false;
            this.lstTaskList.Name = "lstTaskList";
            this.lstTaskList.Size = new System.Drawing.Size(628, 370);
            this.lstTaskList.TabIndex = 0;
            this.lstTaskList.UseCompatibleStateImageBehavior = false;
            this.lstTaskList.View = System.Windows.Forms.View.Details;
            this.lstTaskList.DoubleClick += new System.EventHandler(this.lstTaskList_DoubleClick);
            // 
            // colDesc
            // 
            this.colDesc.Text = "Description";
            this.colDesc.Width = 337;
            // 
            // colFlow
            // 
            this.colFlow.Text = "Flow";
            this.colFlow.Width = 150;
            // 
            // colActivity
            // 
            this.colActivity.Text = "Activity";
            // 
            // frmTaskList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(628, 376);
            this.Controls.Add(this.lstTaskList);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTaskList";
            this.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockTopAutoHide;
            this.TabText = "Task List";
            this.Text = "Task List";
            this.ResumeLayout(false);

		}
		#endregion

        private System.Windows.Forms.ListView lstTaskList;
		private System.Windows.Forms.ColumnHeader colDesc;
        private System.Windows.Forms.ColumnHeader colFlow;
        private System.Windows.Forms.ColumnHeader colActivity;
    }
}