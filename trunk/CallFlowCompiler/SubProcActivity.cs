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
    public class SubProcActivity : AbstractActivity, IActivity
    {
        public SubProcActivity() : base()
        {

        }

        public bool compile()
        {
            base.compile();

            bool ret = false;
            Node valueNode = this.PrimaryNode;
            Node nodeEntry = Compiler.mapLink[valueNode];
            IActivity farActivity = FindActivityByEntry(nodeEntry); //Sub-proc entry activity
            mapNodeValue["[%DONE%]"] = farActivity;


            strCurrentExt = FindExtension(this);
            if (strCurrentExt.Trim().Length <= 0)
            {
                Compiler.PrintError("Disconnected link", "");
                return false;
            }

            string strVal = "";
            if (attribute.ContainsKey("arguments"))
            {
                strVal = attribute["arguments"];
            }

            if (Compiler.mapPage.ContainsKey(farActivity.DocID))
            {
                Page page = Compiler.mapPage[farActivity.DocID];

                //Goto label
                lpInstruction = new ArrayList();
                string strInstruct = "";

                if (strVal.Trim().Length > 0)
                {
                    strInstruct = string.Format("Gosub({0},{1},1({2}))",
                        new object[] { page.FlowName.Replace(' ', '_'), strCurrentExt, strVal });
                }
                else
                {
                    strInstruct = string.Format("Gosub({0},{1},1)",
                        new object[] { page.FlowName.Replace(' ', '_'), strCurrentExt });
                }

                InstructionSet set = new InstructionSet();
                set.ExtNumber = strCurrentExt;
                set.Label = strDesc.Replace(' ', '_');
                set.Instruction = strInstruct;
                lpInstruction.Add(set);

                //Result nodes
                if (resultNode.Count < 0)
                {
                    Compiler.PrintError("Activity '" + strDesc + "' result node not be defined.", "");
                    return ret;
                }
                else
                {
                    Dictionary<string, Node>.Enumerator lpNode = resultNode.GetEnumerator();
                    while (lpNode.MoveNext())
                    {
                        KeyValuePair<string, Node> item = lpNode.Current;
                        if (item.Value.NodeID != this.PrimaryNode.NodeID)
                        {
                            string strItem = item.Value.Value;
                            Node valueNode2 = item.Value;
                            Node nodeEntry2 = Compiler.mapLink[valueNode2];
                            IActivity farActivity2 = FindActivityByEntry(nodeEntry2);

                            mapNodeValue["[%" + strItem.Trim() + "%]"] = farActivity2;

                            strInstruct = string.Format("Gotoif($[\"${{RETVAL}}\"=\"{0}\"]?{1})", new object[] { strItem.Trim(), farActivity2.Description.Replace(' ', '_') });

                            set = new InstructionSet();
                            set.ExtNumber = strCurrentExt;
                            set.Label = "";
                            set.Instruction = strInstruct;
                            lpInstruction.Add(set);

                        }
                    }

                    priorityOffset = lpInstruction.Count - 1;

                    ret = true;
                }
            }

            return ret;
        }
    }
}
