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
    public class GetDigitsActivity: AbstractActivity, IActivity
    {
        public GetDigitsActivity() : base()
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
            string strInvalidMsg = "";
            string strNoInputMsg = "";
            ArrayList strResult = null;
            string strGlobalTimeout = "";
            string strGlobalInvalidInput = "";

            Node nodeGlobalTimeout = Compiler.mapNode[attribute["globaltimeout"]];
            Node nodeGlobalInvalid = Compiler.mapNode[attribute["globalinvalid"]];

            if (nodeGlobalTimeout != null)
            {
                if (Compiler.mapPage.ContainsKey(nodeGlobalTimeout.DocID))
                {
                    Page page = Compiler.mapPage[nodeGlobalTimeout.DocID];
                    strGlobalTimeout = page.FlowName.Replace(' ', '_');
                }
                else
                {
                    Compiler.PrintWarn("GlobalTimeout subflow for GetDigits " + strDesc + " not be defined.", "");
                }
            }

            if (nodeGlobalInvalid != null)
            {
                if (Compiler.mapPage.ContainsKey(nodeGlobalInvalid.DocID))
                {
                    Page page = Compiler.mapPage[nodeGlobalInvalid.DocID];
                    strGlobalInvalidInput = page.FlowName.Replace(' ', '_');
                }
                else
                {
                    Compiler.PrintWarn("GlobalInvalid subflow for GetDigits " + strDesc + " not be defined.", "");
                }
            }


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
                strSilent = Convert.ToString(Convert.ToInt32(attribute["silent"]) * 1000);
            }
            if (attribute.ContainsKey("invalidmsg"))
            {
                strInvalidMsg = attribute["invalidmsg"];

                if (IsNumber(strInvalidMsg))
                {
                    //none
                }
                else if (!VariableExist(strInvalidMsg, true))
                {
                    //none
                }
                else
                {
                    strInvalidMsg = "${" + strInvalidMsg + "}";
                }

            }
            if (attribute.ContainsKey("noinputmsg"))
            {
                strNoInputMsg = attribute["noinputmsg"];
                if (IsNumber(strNoInputMsg))
                {
                    //none
                }
                else if (!VariableExist(strNoInputMsg, true))
                {
                    //none
                }
                else
                {
                    strNoInputMsg = "${" + strNoInputMsg + "}";
                }
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

            strResult = ConcatResult();

            InstructionSet set = new InstructionSet();
            set.ExtNumber = strCurrentExt;
            set.Label = strDesc.Replace(' ', '_');
            set.Instruction = string.Format("AGI(\"getdigits2.php\",\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\")",
                new object[] { strEntryMsg, strSilent, strMaxDigit, "0", strResult, strRetry, strNoInputMsg, strInvalidMsg, strGlobalTimeout, strGlobalInvalidInput });
            lpInstruction.Add(set);



            foreach(string strItem in strResult)
            {
                Node valueNode = FindNodeByResult(strItem);
                Node nodeEntry = Compiler.mapLink[valueNode];
                IActivity farActivity = FindActivityByEntry(nodeEntry);

                mapNodeValue["[%" + strItem.Trim() + "%]"] = farActivity;

                set = new InstructionSet();
                set.ExtNumber = strCurrentExt;
                set.Label = "";
                set.Instruction = string.Format("Gotoif($[\"${{keys}}\"=\"{0}\"]?{1})", new object[] { strItem.Trim(), farActivity.Description.Replace(' ', '_') });
                lpInstruction.Add(set);
            }

            priorityOffset = lpInstruction.Count - 1;

            ret = true;
            return ret;
        }
    }
}
