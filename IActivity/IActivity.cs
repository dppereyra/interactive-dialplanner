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


namespace Interaction.Graph
{
    public interface IActivity
    {
        DialogResult ShowProperties();
        Dictionary<string, TempNode> PropertyResult
        {
            get;
        }
        ArrayList Nodes
        {
            get;
        }
        Node EntryNode
        {
            get;
        }
        Point Position
        {
            get;
            set;
        }
        int Width
        {
            get;
            set;
        }

        int Height
        {
            get;
            set;
        }
        string DocID
        {
            get;
            set;
        }
        Image Icon
        {
            get;
        }
        bool CanDelete
        {
            get;
        }
        Node PrimaryNode
        {
            get;
            set;
        }
        string ActivityID
        {
            get;
            set;
        }
        string ActivityName
        {
            get;
        }
        string ActivityValue
        {
            get;
            set;
        }
        string Description
        {
            get;
            set;
        }
        Label DescriptionLabel
        {
            get;
        }

        bool ExistToolBox
        {
            get;
        }

        System.Windows.Forms.Label FakeLabel
        {
            get;
        }

        void AdjustNodePosition(Point diffpos, System.Drawing.Graphics gfx);
        void AddEntryNode(Node l);
        void Add(Node node);
        Node Remove(string strName);
        Node Find(string strName);
        void PreLoadIcon(IDrawingBoard board, IGraphEvent graphEvt, Point pos);
        void DoAction(IDrawingBoard board, IGraphEvent graphEvt);
        void PreLoadDescription(IDrawingBoard board);
        Dictionary<string, string> Values();
        void Clear();
        void ShowProperty(System.Windows.Forms.PropertyGrid grid);
    }
}
