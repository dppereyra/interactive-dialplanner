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
    public class VoiceMailActivity : AbstractActivity, IActivity
    {
        public VoiceMailActivity() : base()
        {

        }

        public bool compile()
        {
            base.compile();

            string strVal = "";
            string strMailBox = "";
            string strOptions = "";

            bool ret = false;

            if (attribute.ContainsKey("mailbox"))
            {
                strMailBox = attribute["mailbox"];

                if (strMailBox.Trim().Length > 0)
                {
                    if (VariableExist(strMailBox, true))
                    {
                        strMailBox = "${" + strMailBox + "}";
                    }
                }
                else
                {
                    Compiler.PrintError("Activity '" + strDesc + "' in '" + this.FindFlow(strDocID) + "' - mailbox not be defined.", "");
                    return ret;
                }
            }
            else
            {
                Compiler.PrintError("Activity '" + strDesc + "' in '" + this.FindFlow(strDocID) + "' - mailbox not be defined.", "");
                return ret;
            }



            if (attribute.ContainsKey("option"))
            {
                strOptions = attribute["option"];
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

            if (strOptions.Trim().Length > 0)
            {
                strMailBox += "," + strOptions;
            }

            lpInstruction = new ArrayList();
            InstructionSet set = new InstructionSet();
            set.ExtNumber = strCurrentExt;
            set.Label = strDesc.Replace(' ', '_');
            set.Instruction = string.Format("VoiceMail({0}) ", new object[] { strMailBox });
            lpInstruction.Add(set);

            priorityOffset = lpInstruction.Count - 1;

            ret = true;

            return ret;
        }
    }
}
