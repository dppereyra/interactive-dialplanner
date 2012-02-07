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
    public class BridgeCallActivity: AbstractActivity, IActivity
    {
        public BridgeCallActivity() : base()
        {

        }

        public bool compile()
        {
            base.compile();

            bool ret = false;
            lpInstruction = new ArrayList();
            string strWait = "";
            string strDialTo = "";
            string strOption = "";

            strCurrentExt = FindExtension(this);
            if (strCurrentExt.Trim().Length <= 0)
            {
                Compiler.PrintError("Disconnected link", "");
                return false;
            }

            if (attribute.ContainsKey("wait"))
            {
                strWait = attribute["wait"];
            }
            if (attribute.ContainsKey("dialto"))
            {
                strDialTo = attribute["dialto"];

                if (strDialTo.Trim().Length <= 0)
                {
                    Compiler.PrintError("Activity '" + strDesc + "' in '" + this.FindFlow(strDocID) + "' - variable " + strDialTo + " not be defined.", "");
                    return ret;
                }
                else if (!VariableExist(strDialTo, true))
                {
                    //none
                }
                else
                {
                    strDialTo = "${" + strDialTo + "}";
                }
            }
            if (attribute.ContainsKey("options"))
            {
                strOption = attribute["options"];
            }

            string strDesc2 = "";
            string strDesc3 = "";
            string strDesc4 = "";
            string strDesc5 = "";
            string strDesc6 = "";
            string strDesc7 = "";
            string strDesc8 = "";
            string strDesc9 = "";

            string strDesc22 = "";
            string strDesc33 = "";
            string strDesc44 = "";
            string strDesc55 = "";
            string strDesc66 = "";
            string strDesc77 = "";
            string strDesc88 = "";
            string strDesc99 = "";


            InstructionSet set = new InstructionSet();
            set.ExtNumber = strCurrentExt;
            set.Label = strDesc.Replace(' ', '_');
            set.Instruction = string.Format("Dial({0},{1},{2})", new object[] { strDialTo, strWait, strOption });
            lpInstruction.Add(set);

            Node valueNode = FindNodeByResult("CHANUNAVAIL");
            Node nodeEntry = Compiler.mapLink[valueNode];
            IActivity farActivity = FindActivityByEntry(nodeEntry);
            mapNodeValue["[%CHANUNAVAIL%]"] = farActivity;
            strDesc2 = farActivity.Description.Replace(' ', '_');
            strDesc22 = farActivity.Description.Replace(' ', '_') + System.Guid.NewGuid().ToString().Substring(0, 5);
            set = new InstructionSet();
            set.ExtNumber = strCurrentExt;
            set.Label = strDesc.Replace(' ', '_');
            set.Instruction = string.Format("Gotoif($[\"${{DIALSTATUS}}\"=\"CHANUNAVAIL\"]?{0})", new object[] { strDesc22 });
            lpInstruction.Add(set);

            valueNode = FindNodeByResult("BUSY");
            nodeEntry = Compiler.mapLink[valueNode];
            farActivity = FindActivityByEntry(nodeEntry);
            mapNodeValue["[%BUSY%]"] = farActivity;
            strDesc3 = farActivity.Description.Replace(' ', '_');
            strDesc33 = farActivity.Description.Replace(' ', '_') + System.Guid.NewGuid().ToString().Substring(0, 5);
            set = new InstructionSet();
            set.ExtNumber = strCurrentExt;
            set.Label = strDesc.Replace(' ', '_');
            set.Instruction = string.Format("Gotoif($[\"${{DIALSTATUS}}\"=\"BUSY\"]?{0})", new object[] { strDesc33 });
            lpInstruction.Add(set);

            valueNode = FindNodeByResult("NOANSWER");
            nodeEntry = Compiler.mapLink[valueNode];
            farActivity = FindActivityByEntry(nodeEntry);
            mapNodeValue["[%NOANSWER%]"] = farActivity;
            strDesc4 = farActivity.Description.Replace(' ', '_');
            strDesc44 = farActivity.Description.Replace(' ', '_') + System.Guid.NewGuid().ToString().Substring(0, 5);
            set = new InstructionSet();
            set.ExtNumber = strCurrentExt;
            set.Label = strDesc.Replace(' ', '_');
            set.Instruction = string.Format("Gotoif($[\"${{DIALSTATUS}}\"=\"NOANSWER\"]?{0})", new object[] { strDesc44 });
            lpInstruction.Add(set);

            valueNode = FindNodeByResult("ANSWER");
            nodeEntry = Compiler.mapLink[valueNode];
            farActivity = FindActivityByEntry(nodeEntry);
            mapNodeValue["[%ANSWER%]"] = farActivity;
            strDesc5 = farActivity.Description.Replace(' ', '_');
            strDesc55 = farActivity.Description.Replace(' ', '_') + System.Guid.NewGuid().ToString().Substring(0, 5);
            set = new InstructionSet();
            set.ExtNumber = strCurrentExt;
            set.Label = strDesc.Replace(' ', '_');
            set.Instruction = string.Format("Gotoif($[\"${{DIALSTATUS}}\"=\"ANSWER\"]?{0})", new object[] { strDesc55 });
            lpInstruction.Add(set);

            valueNode = FindNodeByResult("CANCEL");
            nodeEntry = Compiler.mapLink[valueNode];
            farActivity = FindActivityByEntry(nodeEntry);
            mapNodeValue["[%CANCEL%]"] = farActivity;
            strDesc6 = farActivity.Description.Replace(' ', '_');
            strDesc66 = farActivity.Description.Replace(' ', '_') + System.Guid.NewGuid().ToString().Substring(0, 5);
            set = new InstructionSet();
            set.ExtNumber = strCurrentExt;
            set.Label = strDesc.Replace(' ', '_');
            set.Instruction = string.Format("Gotoif($[\"${{DIALSTATUS}}\"=\"CANCEL\"]?{0})", new object[] { strDesc66 });
            lpInstruction.Add(set);

            valueNode = FindNodeByResult("DONTCALL");
            nodeEntry = Compiler.mapLink[valueNode];
            farActivity = FindActivityByEntry(nodeEntry);
            mapNodeValue["[%DONTCALL%]"] = farActivity;
            strDesc7 = farActivity.Description.Replace(' ', '_');
            strDesc77 = farActivity.Description.Replace(' ', '_') + System.Guid.NewGuid().ToString().Substring(0, 5);
            set = new InstructionSet();
            set.ExtNumber = strCurrentExt;
            set.Label = strDesc.Replace(' ', '_');
            set.Instruction = string.Format("Gotoif($[\"${{DIALSTATUS}}\"=\"DONTCALL\"]?{0})", new object[] { strDesc77 });
            lpInstruction.Add(set);

            valueNode = FindNodeByResult("TORTURE");
            nodeEntry = Compiler.mapLink[valueNode];
            farActivity = FindActivityByEntry(nodeEntry);
            mapNodeValue["[%TORTURE%]"] = farActivity;
            strDesc8 = farActivity.Description.Replace(' ', '_');
            strDesc88 = farActivity.Description.Replace(' ', '_') + System.Guid.NewGuid().ToString().Substring(0, 5);
            set = new InstructionSet();
            set.ExtNumber = strCurrentExt;
            set.Label = strDesc.Replace(' ', '_');
            set.Instruction = string.Format("Gotoif($[\"${{DIALSTATUS}}\"=\"TORTURE\"]?{0})", new object[] { strDesc88 });
            lpInstruction.Add(set);

            valueNode = FindNodeByResult("CONGESTION");
            nodeEntry = Compiler.mapLink[valueNode];
            farActivity = FindActivityByEntry(nodeEntry);
            mapNodeValue["[%CONGESTION%]"] = farActivity;
            strDesc9 = farActivity.Description.Replace(' ', '_');
            strDesc99 = farActivity.Description.Replace(' ', '_') + System.Guid.NewGuid().ToString().Substring(0, 5);
            set = new InstructionSet();
            set.ExtNumber = strCurrentExt;
            set.Label = strDesc.Replace(' ', '_');
            set.Instruction = string.Format("Gotoif($[\"${{DIALSTATUS}}\"=\"CONGESTION\"]?{0})", new object[] { strDesc99 });
            lpInstruction.Add(set);



            set = new InstructionSet();
            set.ExtNumber = strCurrentExt;
            set.Label = strDesc22;
            set.Instruction = string.Format("Goto({0})", new object[] { strDesc2 });
            lpInstruction.Add(set);

            set = new InstructionSet();
            set.ExtNumber = strCurrentExt;
            set.Label = strDesc33;
            set.Instruction = string.Format("Goto({0})", new object[] { strDesc3 });
            lpInstruction.Add(set);

            set = new InstructionSet();
            set.ExtNumber = strCurrentExt;
            set.Label = strDesc44;
            set.Instruction = string.Format("Goto({0})", new object[] { strDesc4 });
            lpInstruction.Add(set);

            set = new InstructionSet();
            set.ExtNumber = strCurrentExt;
            set.Label = strDesc55;
            set.Instruction = string.Format("Goto({0})", new object[] { strDesc5 });
            lpInstruction.Add(set);

            set = new InstructionSet();
            set.ExtNumber = strCurrentExt;
            set.Label = strDesc66;
            set.Instruction = string.Format("Goto({0})", new object[] { strDesc6 });
            lpInstruction.Add(set);

            set = new InstructionSet();
            set.ExtNumber = strCurrentExt;
            set.Label = strDesc77;
            set.Instruction = string.Format("Goto({0})", new object[] { strDesc7 });
            lpInstruction.Add(set);

            set = new InstructionSet();
            set.ExtNumber = strCurrentExt;
            set.Label = strDesc88;
            set.Instruction = string.Format("Goto({0})", new object[] { strDesc8 });
            lpInstruction.Add(set);

            set = new InstructionSet();
            set.ExtNumber = strCurrentExt;
            set.Label = strDesc99;
            set.Instruction = string.Format("Goto({0})", new object[] { strDesc9 });
            lpInstruction.Add(set);










            priorityOffset = lpInstruction.Count - 1;

            ret = true;

            return ret;
        }
    }
}
