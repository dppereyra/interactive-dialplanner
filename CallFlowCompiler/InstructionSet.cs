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
using System.Text;

namespace Interaction.Compiler
{
    public class InstructionSet
    {
        private string strExtHeader = "exten =>";
        private string strExtNumber = "";
        private int priority = -1;
        private string strLabel;
        private string strInstruction = "";

        public string BuildInstruction()
        {
            string strRet = "";

            if (priority > 0 && strExtNumber.Length > 0 && strInstruction.Length > 0)
            {
                if (strLabel.Length > 0)
                {
                    strRet = string.Format("{0} {1},{2}({3}),{4}", new object[] { strExtHeader, strExtNumber, priority, strLabel, strInstruction });

                }
                else
                {
                    strRet = string.Format("{0} {1},{2},{3}", new object[] { strExtHeader, strExtNumber, priority, strInstruction });
                }
            }

            return strRet;
        }

        public string ExtHeader
        {
            get
            {
                return strExtHeader;
            }
        }

        public string ExtNumber
        {
            get
            {
                return strExtNumber;
            }

            set
            {
                strExtNumber = value;
            }
        }

        public int Priority
        {
            get
            {
                return priority;
            }

            set
            {
                priority = value;
            }
        }

        public string Label
        {
            get
            {
                return strLabel;
            }

            set
            {
                strLabel = value;
            }
        }

        public string Instruction
        {
            get
            {
                return strInstruction;
            }

            set
            {
                strInstruction = value;
            }
        }
    }
}
