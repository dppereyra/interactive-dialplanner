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
    class SwitchCaseActivity : AbstractActivity, IActivity
    {
        public SwitchCaseActivity()
            : base()
        {

        }

        public bool compile()
        {
            base.compile();
            bool ret = false;
            lpInstruction = new ArrayList();
            ArrayList strResult = null;
            string strVar = "";

            if (attribute.ContainsKey("var"))
            {
                strVar = attribute["var"];

                if (strVar.Trim().Length > 0)
                {
                    if (VariableExist(strVar, true))
                    {
                        strVar = "${" + strVar + "}";
                    }
                    else
                    {
                        Compiler.PrintError("Activity '" + strDesc + "' in '" + this.FindFlow(strDocID) + "' - variable not be defined.", "");
                        return ret;
                    }
                }
                else
                {
                    Compiler.PrintError("Activity '" + strDesc + "' in '" + this.FindFlow(strDocID) + "' - variable not be defined.", "");
                    return ret;
                }
            }
            else
            {
                Compiler.PrintError("Activity '" + strDesc + "' in '" + this.FindFlow(strDocID) + "' - variable not be defined.", "");
                return ret;
            }


            strCurrentExt = FindExtension(this);
            if (strCurrentExt.Trim().Length <= 0)
            {
                Compiler.PrintError("Disconnected link", "");
                return false;
            }

            strResult = ConcatResult();

            InstructionSet set = new InstructionSet();
            set.ExtNumber = strCurrentExt;
            set.Label = strDesc.Replace(' ', '_');
            set.Instruction = "NoOp(Switch Case: " + set.Label + ")";
            lpInstruction.Add(set);

            foreach (string strItem in strResult)
            {
                Node valueNode = FindNodeByResult(strItem);
                Node nodeEntry = Compiler.mapLink[valueNode];
                IActivity farActivity = FindActivityByEntry(nodeEntry);

                mapNodeValue["[%" + strItem.Trim() + "%]"] = farActivity;

                set = new InstructionSet();
                set.ExtNumber = strCurrentExt;
                set.Label = "";
                set.Instruction = string.Format("Gotoif($[\"{0}\"=\"{1}\"]?{2})", new object[] { strVar, strItem.Trim(), farActivity.Description.Replace(' ', '_') });
                lpInstruction.Add(set);
                
            }

            priorityOffset = lpInstruction.Count - 1;

            ret = true;
            return ret;
        }
    }
}
