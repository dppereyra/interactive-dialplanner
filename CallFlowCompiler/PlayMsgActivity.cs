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
    public class PlayMsgActivity: AbstractActivity, IActivity
    {
        public PlayMsgActivity() : base()
        {

        }
        public bool compile()
        {
            bool ret = false;
            base.compile();

            lpInstruction = new ArrayList();
            string strInstruct = "";
            string strMsg = "";
            string strDTMF = "";

            strCurrentExt = FindExtension(this);
            if (strCurrentExt.Trim().Length <= 0)
            {
                Compiler.PrintError("Disconnected link", "");
                return false;
            }

            if (attribute.ContainsKey("msgs"))
            {
                strMsg = attribute["msgs"];

                if (strMsg.Trim().Length <= 0)
                {
                    Compiler.PrintError("Activity '" + strDesc + "' in '" + this.FindFlow(strDocID) + "' - variable " + strMsg + " not be defined.", "");
                    return ret;
                }
                else if (!VariableExist(strMsg, true))
                {
                    //none
                }
                else
                {
                    strMsg = "${" + strMsg + "}";
                }

            }
            if (attribute.ContainsKey("dtmf"))
            {
                strDTMF = attribute["dtmf"];
            }

            if (strDTMF == "0")
            {
                InstructionSet set = new InstructionSet();
                set.ExtNumber = strCurrentExt;
                set.Label = strDesc.Replace(' ', '_');
                set.Instruction = string.Format("Playback({0})", new object[] { strMsg });
                lpInstruction.Add(set);

                Node valueNode = FindNodeByResult("DONE");
                Node nodeEntry = Compiler.mapLink[valueNode];
                IActivity farActivity1 = FindActivityByEntry(nodeEntry);
                mapNodeValue["[%DONE%]"] = farActivity1;

                set = new InstructionSet();
                set.ExtNumber = strCurrentExt;
                set.Label = strDesc.Replace(' ', '_');
                set.Instruction = string.Format("Goto({0})", new object[] { farActivity1.Description.Replace(' ', '_') });
                lpInstruction.Add(set);

                priorityOffset = lpInstruction.Count - 1;

                ret = true;
            }
            else
            {
                Node valueNode = FindNodeByResult("DONE");
                Node nodeEntry = Compiler.mapLink[valueNode];
                IActivity farActivity1 = FindActivityByEntry(nodeEntry);
                mapNodeValue["[%DONE%]"] = farActivity1;

                valueNode = FindNodeByResult("DTMF");
                nodeEntry = Compiler.mapLink[valueNode];
                IActivity farActivity2 = FindActivityByEntry(nodeEntry);
                mapNodeValue["[%DTMF%]"] = farActivity2;

                InstructionSet set = new InstructionSet();
                set.ExtNumber = strCurrentExt;
                set.Label = strDesc.Replace(' ', '_');
                set.Instruction = string.Format("Read(digitto,{0},1,,0,1)", new object[] { strMsg });
                lpInstruction.Add(set);

                string strDesc1 = farActivity1.Description.Replace(' ', '_');
                string strDesc2 = farActivity2.Description.Replace(' ', '_');
                string strDesc11 = farActivity1.Description.Replace(' ', '_') + System.Guid.NewGuid().ToString().Substring(0, 5);
                string strDesc22 = farActivity2.Description.Replace(' ', '_') + System.Guid.NewGuid().ToString().Substring(0, 5);
                
                set = new InstructionSet();
                set.ExtNumber = strCurrentExt;
                set.Label = strDesc.Replace(' ', '_');
                set.Instruction = string.Format("Gotoif($[ \"${{LEN(${{digitto}})}}\" > \"0\"]?{0}:{1})", new object[] { strDesc11, strDesc22 });
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
            }

            return ret;

        }

    }
}
