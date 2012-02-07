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
    public class CompareActivity : AbstractActivity, IActivity
    {
        public CompareActivity() : base()
        {
        }

        public bool compile()
        {
            base.compile();

            string strVal1 = "";
            string strVal2 = "";
            string strOp = "";
            bool ret = false;

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
                else if (!VariableExist(strVal1, true))
                {
                    //none
                }
                else
                {
                    strVal1 = "${" + strVal1 + "}";
                }

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
                else if (!VariableExist(strVal2, true))
                {
                    //none
                }
                else
                {
                    strVal2 = "${" + strVal2 + "}";
                }

            }
            if (attribute.ContainsKey("operator"))
            {
                strOp = attribute["operator"];
            }

            strCurrentExt = FindExtension(this);
            if (strCurrentExt.Trim().Length <= 0)
            {
                Compiler.PrintError("Disconnected link", "");
                return false;
            }

            Node valueNode1 = FindNodeByResult("Yes");
            Node nodeEntry1 = Compiler.mapLink[valueNode1];
            IActivity farActivity1 = FindActivityByEntry(nodeEntry1);
            mapNodeValue["[%YES%]"] = farActivity1;

            Node valueNode2 = FindNodeByResult("No");
            Node nodeEntry2 = Compiler.mapLink[valueNode2];
            IActivity farActivity2 = FindActivityByEntry(nodeEntry2);
            mapNodeValue["[%NO%]"] = farActivity2;


            string strDesc1 = farActivity1.Description.Replace(' ', '_');
            string strDesc11 = farActivity1.Description.Replace(' ', '_') + System.Guid.NewGuid().ToString().Substring(0, 5);

            string strDesc2 = farActivity2.Description.Replace(' ', '_');
            string strDesc22 = farActivity2.Description.Replace(' ', '_') + System.Guid.NewGuid().ToString().Substring(0, 5);

            lpInstruction = new ArrayList();
            InstructionSet set = new InstructionSet();
            set.ExtNumber = strCurrentExt;
            set.Label = strDesc.Replace(' ', '_');
            set.Instruction = string.Format("Gotoif($[\"{0}\" {1} \"{2}\"]?{3}:{4})", new object[] { strVal1, strOp, strVal2, strDesc11, strDesc22 });
            lpInstruction.Add(set);

            set = new InstructionSet();
            set.ExtNumber = strCurrentExt;
            set.Label = strDesc11;
            set.Instruction = string.Format("Goto({0})", new object[] { strDesc1 });
            lpInstruction.Add(set);

            set = new InstructionSet();
            set.ExtNumber = strCurrentExt;
            set.Label = strDesc22;
            set.Instruction = string.Format("Goto({0})", new object[] { strDesc2 });
            lpInstruction.Add(set);


            priorityOffset = lpInstruction.Count - 1;

            ret = true;

            return ret;
        }
    }
}
