﻿/******************************************************************************************
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

namespace Interaction.Graph
{
    public class SupplyStore
    {
        private static SupplyStore _instance;
        private List<string> op = new List<string>();
        private List<string> optype = new List<string>();

        private SupplyStore()
        {
            LoadSupplies();
        }

        public static SupplyStore Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SupplyStore();
                }

                return (_instance);
            }
        }

        public List<string> Operator
        {
            get { return (_instance.op as List<string>); }
        }

        public List<string> OperatorType
        {
            get { return (_instance.optype as List<string>); }
        }

        private void LoadSupplies()
        {
            optype.Add("i");
            optype.Add("f");
            optype.Add("h");
            optype.Add("c");

            op.Add("+");
            op.Add("-");
            op.Add("*");
            op.Add("/");
            op.Add("%");
            op.Add("<");
            op.Add(">");
            op.Add("<=");
            op.Add(">=");
            op.Add("==");
        }

    }
}
