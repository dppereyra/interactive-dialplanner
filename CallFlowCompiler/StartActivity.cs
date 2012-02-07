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

namespace Interaction.Compiler
{
    public class StartActivity : AbstractActivity, IActivity
    {
        public StartActivity() : base()
        {
        }

        public bool compile()
        {
            base.compile();
            base.compile();

            bool ret = false;
            Page p = Compiler.mapPage[this.DocID];
            lpInstruction = new ArrayList();
            string strInstruct = "";

            //Result nodes
            if (resultNode.Count < 0)
            {
                Compiler.PrintError("Activity '" + strDesc + "' result node not be defined.", "");
                return ret;
            }
            else
            {
                Dictionary<string, Node>.Enumerator lpNode = resultNode.GetEnumerator();

                while (lpNode.MoveNext())
                {

                    KeyValuePair<string, Node> item = lpNode.Current;
                    string strItem = item.Value.Value;
                    Node valueNode2 = item.Value; //current result node for this activity
                    Node nodeEntry2 = Compiler.mapLink[valueNode2]; //Entry node of the following activity
                    IActivity farActivity2 = FindActivityByEntry(nodeEntry2);

                    mapNodeValue["[%" + strItem.Trim() + "%]"] = farActivity2;

                    strInstruct = string.Format("NoOp(Start context {0})", new object[] { p.FlowName.Replace(' ', '_') });
                    InstructionSet set = new InstructionSet();
                    set.ExtNumber = item.Value.Value;
                    set.Priority = StartPriority;
                    set.Label = strDesc.Replace(' ', '_');
                    set.Instruction = strInstruct;
                    lpInstruction.Add(set);

                }

                Context = p.FlowName.Replace(' ', '_');
                
                priorityOffset = 0;

                ret = true;
            }


            return ret;

        }

    }
}
