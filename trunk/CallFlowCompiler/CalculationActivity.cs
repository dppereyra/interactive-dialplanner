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
    public class CalculationActivity : AbstractActivity, IActivity
    {
        public CalculationActivity() : base()
        {

        }

        public bool compile()
        {
            base.compile();
            bool ret = false;
            string strVal1 = "";
            string strOp = "";
            string strVal2 = "";
            string strResult = "";
            string strType = "";

            if (attribute.ContainsKey("variable1"))
            {
                strVal1 = attribute["variable1"];
                if (IsNumber(strVal1))
                {
                    //none
                }
                else if (strVal1.Trim().Length <= 0)
                {
                    Compiler.PrintError("Activity '" + strDesc + "' in '" + this.FindFlow(strDocID) + "' - variable " + strVal1 + " not be defined.", "");
                    return ret;
                }
                else if (VariableExist(strVal1, true))
                {
                    strVal1 = "${" + strVal1 + "}";
                }
            }
            if (attribute.ContainsKey("operator"))
            {
                strOp = attribute["operator"];
            }
            if (attribute.ContainsKey("variable2"))
            {
                strVal2 = attribute["variable2"];
                if (IsNumber(strVal2))
                {
                    //none
                }
                else if (strVal2.Trim().Length <= 0)
                {
                    Compiler.PrintError("Activity '" + strDesc + "' in '" + this.FindFlow(strDocID) + "' - variable " + strVal2 + " not be defined.", "");
                    return ret;
                }
                else if (VariableExist(strVal2, true))
                {
                    strVal2 = "${" + strVal2 + "}";
                }
            }
            if (attribute.ContainsKey("optype"))
            {
                strType = attribute["optype"];
            }
            if (attribute.ContainsKey("result"))
            {
                strResult = attribute["result"];

                if (!VariableExist(strResult, false))
                {
                    Compiler.PrintError("Activity '" + strDesc + "' in '" + this.FindFlow(strDocID) + "' - variable " + strResult + " not be defined", "");
                    return ret;
                }
            }

            Node valueNode = FindNodeByResult("Done");
            Node nodeEntry = Compiler.mapLink[valueNode];
            IActivity farActivity = FindActivityByEntry(nodeEntry);
            mapNodeValue["[%DONE%]"] = farActivity;

            strCurrentExt = FindExtension(this);
            if (strCurrentExt.Trim().Length <= 0)
            {
                Compiler.PrintError("Disconnected link", "");
                return false;
            }


            lpInstruction = new ArrayList();
            InstructionSet set = new InstructionSet();
            set.ExtNumber = strCurrentExt;
            set.Label = strDesc.Replace(' ', '_');
            set.Instruction = string.Format("SET({0}=${{MATH({1}{2}{3},{4})}})",
                new object[] { strResult, strVal1, strOp, strVal2, strType });
            lpInstruction.Add(set);

            priorityOffset = lpInstruction.Count - 1;

            ret = true;

            return ret;
        }
    }
}
