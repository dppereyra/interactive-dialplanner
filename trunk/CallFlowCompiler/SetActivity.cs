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
    public class SetActivity: AbstractActivity, IActivity
    {
        public SetActivity() : base()
        {

        }

        public bool compile()
        {
            base.compile();

            string strVal = "";
            string strEqualto = "";
            bool ret = false;

            if (attribute.ContainsKey("variable"))
            {
                strVal = attribute["variable"];
                if (!VariableExist(strVal, false))
                {
                    Compiler.PrintError("Activity '" + strDesc + "' in '" + this.FindFlow(strDocID) + "' - variable " + strVal + " not be defined.", "");
                    return ret;
                }

            }
            if (attribute.ContainsKey("equalto"))
            {
                strEqualto = attribute["equalto"];

                if (strEqualto.Trim().Length <= 0)
                {
                    Compiler.PrintError("Activity '" + strDesc + "' in '" + this.FindFlow(strDocID) + "' - variable " + strEqualto + " not be defined.", "");
                    return ret;
                }
                else if (!VariableExist(strEqualto, true))
                {
                    //none
                }
                else
                {
                    strEqualto = "${" + strEqualto + "}";
                }
            }

            strCurrentExt = FindExtension(this);
            if (strCurrentExt.Trim().Length <= 0)
            {
                Compiler.PrintError("Disconnected link", "");
                return false;
            }

            Node valueNode = FindNodeByResult("Done");
            Node nodeEntry = Compiler.mapLink[valueNode];
            IActivity farActivity = FindActivityByEntry(nodeEntry);
            mapNodeValue["[%DONE%]"] = farActivity;

            lpInstruction = new ArrayList();
            string strInstruct = string.Format("Set({0}={1}) ", new object[] { strVal, strEqualto });
            InstructionSet set = new InstructionSet();
            set.ExtNumber = strCurrentExt;
            set.Label = strDesc.Replace(' ', '_');
            set.Instruction = strInstruct;
            lpInstruction.Add(set);

            priorityOffset = lpInstruction.Count - 1;

            ret = true;

            return ret;
        }
    }
}
