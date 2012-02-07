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
    public class CutActivity: AbstractActivity, IActivity
    {
        public CutActivity() : base()
        {
        }

        public bool compile()
        {
            base.compile();
            string strVal = "";
            string strResult = "";
            string strOffset = "";
            string strLength = "";

            bool ret = false;

            if (attribute.ContainsKey("result"))
            {
                strResult = attribute["result"];

                if (strResult.Trim().Length <= 0)
                {
                    Compiler.PrintError("Activity '" + strDesc + "' in '" + this.FindFlow(strDocID) + "' - variable " + strResult + " not be defined.", "");
                    return ret;
                }
                else if (!VariableExist(strResult, true))
                {
                    Compiler.PrintError("Activity '" + strDesc + "' in '" + this.FindFlow(strDocID) + "' - variable " + strResult + " not be defined.", "");
                    return ret;
                }
            }

            if (attribute.ContainsKey("var"))
            {
                strVal = attribute["var"];
                strOffset = attribute["offset"];

                try
                {
                    int i = Convert.ToInt32(attribute["length"]);
                    if (i == 0)
                    {
                        strLength = attribute["length"];
                    }
                }
                catch (Exception ex)
                {
                }

                if (!VariableExist(strVal, false))
                {
                    Compiler.PrintError("Activity '" + strDesc + "' in '" + this.FindFlow(strDocID) + "' - variable " + strVal + " not be defined.", "");
                    return ret;
                }

                if (strLength.Length > 0)
                {
                    strVal = "${" + strVal + ":" + strOffset + ":" + strLength + "}";
                }
                else
                {
                    strVal = "${" + strVal + ":" + strOffset + "}";
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
            set.Instruction = string.Format("Set({0}={1}) ", new object[] { strResult, strVal });
            lpInstruction.Add(set);

            priorityOffset = lpInstruction.Count - 1;

            ret = true;

            return ret;
        }
    }
}
