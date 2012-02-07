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
    public class ReadActivity: AbstractActivity, IActivity
    {
        public ReadActivity() : base()
        {

        }

        public bool compile()
        {
            base.compile();

            bool ret = false;
            lpInstruction = new ArrayList();
            string strMaxDigit = "";
            string strRetry = "";
            string strSilent = "";
            string strEntryMsg = "";
            string strOptions = "";
            string strVariable = "";

            if (attribute.ContainsKey("maxdigit"))
            {
                strMaxDigit = attribute["maxdigit"];
            }
            if (attribute.ContainsKey("retry"))
            {
                strRetry = attribute["retry"];
            }
            if (attribute.ContainsKey("silent"))
            {
                strSilent = Convert.ToString(Convert.ToInt32(attribute["silent"]) * 1);
            }
            if (attribute.ContainsKey("variable"))
            {
                strVariable = attribute["variable"];

                if (!VariableExist(strVariable, true))
                {
                    Compiler.PrintError("Activity '" + strDesc + "' in '" + this.FindFlow(strDocID) + "' - variable " + strVariable + " not be defined.", "");
                    return ret;
                }
                else
                {
                    strVariable = "${" + strVariable + "}";
                }

            }
            if (attribute.ContainsKey("options"))
            {
                strOptions = attribute["options"];
            }
            if (attribute.ContainsKey("entrymsg"))
            {
                strEntryMsg = attribute["entrymsg"];

                if (strEntryMsg.Trim().Length <= 0)
                {
                    Compiler.PrintError("Activity '" + strDesc + "' in '" + this.FindFlow(strDocID) + "' - variable " + strEntryMsg + " not be defined.", "");
                    return ret;
                }
                else if (!VariableExist(strEntryMsg, true))
                {
                    //none
                }
                else
                {
                    strEntryMsg = "${" + strEntryMsg + "}";
                }

            }
            strCurrentExt = FindExtension(this);
            if (strCurrentExt.Trim().Length <= 0)
            {
                Compiler.PrintError("Disconnected link", "");
                return false;
            }

            InstructionSet set = new InstructionSet();
            set.ExtNumber = strCurrentExt;
            set.Label = strDesc.Replace(' ', '_');
            set.Instruction = string.Format("read({0},{1},{2},{3},{4},{5})",
                new object[] { strVariable, strEntryMsg, strMaxDigit, strOptions, strRetry, strSilent });
            lpInstruction.Add(set);

            Node valueNode = FindNodeByResult("Done");
            Node nodeEntry = Compiler.mapLink[valueNode];
            IActivity farActivity = FindActivityByEntry(nodeEntry);
            mapNodeValue["[%DONE%]"] = farActivity;

            priorityOffset = lpInstruction.Count - 1;

            ret = true;

            return ret;
        }
    }
}
