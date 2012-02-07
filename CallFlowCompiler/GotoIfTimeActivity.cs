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
    public class GotoIfTimeActivity : AbstractActivity, IActivity
    {
        public GotoIfTimeActivity()
            : base()
        {

        }

        public bool compile()
        {
            base.compile();

            bool ret = false;
            Node valueNode = FindFirstNode();
            Node nodeEntry = Compiler.mapLink[valueNode];
            IActivity farActivity = FindActivityByEntry(nodeEntry);
            mapNodeValue["[%DONE%]"] = farActivity;


            strCurrentExt = FindExtension(this);
            if (strCurrentExt.Trim().Length <= 0)
            {
                Compiler.PrintError("Disconnected link", "");
                return false;
            }

            string strTime = "*";
            string strDow = "*";
            string strDom = "*";
            string strMonth = "*";

            if (attribute.ContainsKey("timerange"))
            {
                strTime = attribute["timerange"];
                if (strTime.Trim().Length <= 0)
                {
                    Compiler.PrintError("Activity '" + strDesc + "' in '" + this.FindFlow(strDocID) + "' - variable " + strTime + " not be defined.", "");
                    return ret;
                }
                else if (VariableExist(strTime, true))
                {
                    strTime = "${" + strTime + "}";
                }

                strDow = attribute["dow"];
                if (strDow.Trim().Length <= 0)
                {
                    Compiler.PrintError("Activity '" + strDesc + "' in '" + this.FindFlow(strDocID) + "' - variable " + strDow + " not be defined.", "");
                    return ret;
                }
                else if (VariableExist(strDow, true))
                {
                    strDow = "${" + strDow + "}";
                }

                strDom = attribute["dom"];
                if (strDom.Trim().Length <= 0)
                {
                    Compiler.PrintError("Activity '" + strDesc + "' in '" + this.FindFlow(strDocID) + "' - variable " + strDom + " not be defined.", "");
                    return ret;
                }
                else if (VariableExist(strDom, true))
                {
                    strDom = "${" + strDom + "}";
                }

                strMonth = attribute["month"];
                if (strMonth.Trim().Length <= 0)
                {
                    Compiler.PrintError("Activity '" + strDesc + "' in '" + this.FindFlow(strDocID) + "' - variable " + strMonth + " not be defined.", "");
                    return ret;
                }
                else if (VariableExist(strMonth, true))
                {
                    strMonth = "${" + strMonth + "}";
                }
           
            }

            Node valueNode1 = FindNodeByResult("Match");
            Node nodeEntry1 = Compiler.mapLink[valueNode1];
            IActivity farActivity1 = FindActivityByEntry(nodeEntry1);
            mapNodeValue["[%Match%]"] = farActivity1;

            Node valueNode2 = FindNodeByResult("Not Match");
            Node nodeEntry2 = Compiler.mapLink[valueNode2];
            IActivity farActivity2 = FindActivityByEntry(nodeEntry2);
            mapNodeValue["[%NotMatch%]"] = farActivity2;

            string strDesc1 = farActivity1.Description.Replace(' ', '_');
            string strDesc2 = farActivity2.Description.Replace(' ', '_');

            //Goto label
            lpInstruction = new ArrayList();

            InstructionSet set = new InstructionSet();
            set.ExtNumber = strCurrentExt;
            set.Label = strDesc.Replace(' ', '_');
            set.Instruction = string.Format("GotoIfTime({0},{1},{2},{3}?{4})", new object[] { strTime, strDow, strDom, strMonth, "YXYXYX" });
            lpInstruction.Add(set);


            //Not match
            set = new InstructionSet();
            set.ExtNumber = strCurrentExt;
            set.Label = "";
            set.Instruction = string.Format("Goto({0})", new object[] { strDesc2 });
            lpInstruction.Add(set);

            //Match (Priority = YXYXYX)
            set = new InstructionSet();
            set.ExtNumber = strCurrentExt;
            set.Label = "";
            set.Instruction = string.Format("Goto({0})", new object[] { strDesc1 });
            lpInstruction.Add(set);

            priorityOffset = lpInstruction.Count - 1;

            ret = true;

            return ret;
        }

        public void adjustSequence()
        {
            if (lpInstruction != null)
            {
                int idx = 0;
                InstructionSet mainSet = null;
                foreach (InstructionSet set in lpInstruction)
                {
                    if (idx == 0)
                    {
                        mainSet = set;
                    }
                    else if(idx == 2)
                    {
                        int priority = set.Priority;

                        mainSet.Instruction = mainSet.Instruction.Replace("YXYXYX", Convert.ToString(priority));
                    }
                    idx++;
                }
            }

        }
    }
}
