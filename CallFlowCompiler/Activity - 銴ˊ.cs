using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

/*
 * 
Answer(${wait})

Set(CHANNEL(language)={$lang}) 

Playback(${msg})
Read(${digitto},${msg},1,,0,1)


Dial(${dialto},${timeout},${option})
${DIALSTATUS}


AGI("getdigits.php",${msg},${waitrime-millisecond},${maxdigits},${condition},${pattern-or-waitdigits},${retrycount},${noinputmsg},${invalidmsg});
${keys}
 * 
 
 */

namespace Interaction.Compiler
{
    public class Activity
    {
        private string strID = "";
        private string strName = "";
        private string strValue = "";
        private string strDesc = "";
        private string strDocID = "";
        private Node entryActivity = null;
        private Node primaryNode = null;
        private Dictionary<string, Node> resultNode = new Dictionary<string, Node>();
        private Dictionary<string, string> attribute = new Dictionary<string, string>();

        private Dictionary<string, Activity> mapNodeValue = new Dictionary<string, Activity>();
        private ArrayList lpInstruction;

        private int startPriority = -1;
        private int endPriority = -1;

        private string strCurrentExt = "";

        public int StartPriority
        {
            get
            {
                return startPriority;
            }

            set
            {
                startPriority = value;
            }
        }

        public int EndPriority
        {
            get
            {
                return endPriority;
            }

            set
            {
                endPriority = value;
            }
        }

        public ArrayList Instructions
        {
            get
            {
                return lpInstruction;
            }
        }

        public Dictionary<string, Node> ResultNode
        {
            get
            {
                return resultNode;
            }

            set
            {
                resultNode = value;
            }
        }

        public Dictionary<string, string> Attribute
        {
            get
            {
                return attribute;
            }

            set
            {
                attribute = value;
            }
        }
        public Node PrimaryNode
        {
            get
            {
                return primaryNode;
            }

            set
            {
                primaryNode = value;
            }
        }

        public Node Entry
        {
            get
            {
                return entryActivity;
            }

            set
            {
                entryActivity = value;
            }
        }

        public string ActivityID
        {
            get
            {
                return strID;
            }

            set
            {
                strID = value;
            }
        }

        public string ActivityName
        {
            get
            {
                return strName;
            }

            set
            {
                strName = value;
            }
        }
        public string Value
        {
            get
            {
                return strValue;
            }

            set
            {
                strValue = value;
            }
        }
        public string Description
        {
            get
            {
                return strDesc;
            }

            set
            {
                strDesc = value;
            }
        }
        public string DocID
        {
            get
            {
                return strDocID;
            }

            set
            {
                strDocID = value;
            }
        }

        public bool compile()
        {
            bool ret = false;

            if (this.ActivityName.ToUpper() == "START")
            {
                ret = this.compileStart();
            }
            else if (this.ActivityName.ToUpper() == "ANSWER")
            {
                ret = compileAnswer();
            }
            else if (this.ActivityName.ToUpper() == "HANGUP")
            {
                ret = this.compileHangup();
            }
            else if (this.ActivityName.ToUpper() == "SETLANGUAGE")
            {
                ret = this.compileSetLang();
            }
            else if (this.ActivityName.ToUpper() == "PLAYMSG")
            {
                ret = this.compilePlayMsg();
            }
            else if (this.ActivityName.ToUpper() == "GETDIGITS")
            {
                ret = this.compileGetDigits();
            }
            else if (this.ActivityName.ToUpper() == "BRIDGECALL")
            {
                ret = this.compileBridgeCall();
            }
            else if (this.ActivityName.ToUpper() == "RECORD")
            {
                ret = this.compileRecord();
            }
            else if (this.ActivityName.ToUpper() == "AGI")
            {
                ret = this.compileAGI();
            }
            else if (this.ActivityName.ToUpper() == "AUTHENTICATE")
            {
                ret = this.compileAuth();
            }
            else if (this.ActivityName.ToUpper() == "GOTO")
            {
                ret = compileGoto();
            }
            else if (this.ActivityName.ToUpper() == "SUBPROC")
            {
                ret = compileSubProc();
            }
            else if (this.ActivityName.ToUpper() == "SUBPROCEND")
            {
                ret = compileSubProcEnd();
            }
            else if (this.ActivityName.ToUpper() == "READ")
            {
                ret = compileRead();
            }
            else if (this.ActivityName.ToUpper() == "SET")
            {
                ret = compileSet();
            }
            else if (this.ActivityName.ToUpper() == "COMPARE")
            {
                ret = compileCompare();
            }
            else if (this.ActivityName.ToUpper() == "CALCULATION")
            {
                ret = compileCalculation();
            }
            else if (this.ActivityName.ToUpper() == "SAY")
            {
                ret = compileSay();
            }
            else if (this.ActivityName.ToUpper() == "CUT")
            {
                ret = compileCut();
            }
            else if (this.ActivityName.ToUpper() == "LENGTH")
            {
                ret = compileLength();
            }
            else if (this.ActivityName.ToUpper() == "MERGE")
            {
                ret = compileMerge();
            }

            return ret;
        }

        private bool compileStart()
        {
            bool ret = false;
            Page p = Compiler.mapPage[this.DocID];
            lpInstruction = new ArrayList();
            string strInstruct = "";

            //Result nodes
            if (resultNode.Count < 0)
            {
                Compiler.PrintError("Activity '" + strDesc + "' result node not be defined.", "");
                return ret;
            }
            else
            {
                Dictionary<string, Node>.Enumerator lpNode = resultNode.GetEnumerator();
                startPriority = 1;
                endPriority = 1;

                while (lpNode.MoveNext())
                {

                    KeyValuePair<string, Node> item = lpNode.Current;
                    string strItem = item.Value.Value;
                    Node valueNode2 = item.Value; //current result node for this activity
                    Node nodeEntry2 = Compiler.mapLink[valueNode2]; //Entry node of the following activity
                    Activity farActivity2 = FindActivityByEntry(nodeEntry2);

                    mapNodeValue["[%" + strItem.Trim() + "%]"] = farActivity2;

                    strInstruct = string.Format("exten => {0},{3}({1}),NoOp(Start context {2})", new object[] { item.Value.Value, strDesc.Replace(' ', '_'), p.FlowName.Replace(' ', '_'), endPriority });
                    lpInstruction.Add(strInstruct);


                    //Goto label
                    //strInstruct = string.Format("exten => {0},n,Goto({1})", new object[] { item.Value.Value, farActivity2.Description.Replace(' ', '_') });
                    //lpInstruction.Add(strInstruct);

                }

                Compiler.mapContext[p.FlowName.Replace(' ', '_')] = new Dictionary<string, InstructionSet>();
                
                ret = true;
            }

            return ret;

        }

        private bool compileAnswer()
        {
            bool ret = true;

            string strTimeout = "";
            if (attribute.ContainsKey("wait"))
            {
                strTimeout = attribute["wait"];
                if (Convert.ToInt32(strTimeout) <= 0)
                {
                    strTimeout = "";
                }
            }

            Node valueNode = FindNodeByResult("Done");
            Node nodeEntry = Compiler.mapLink[valueNode];
            Activity farActivity = FindActivityByEntry(nodeEntry);
            mapNodeValue["[%DONE%]"] = farActivity;

            Activity prevAct = FindPreviousActivity(this.Entry);
            if (prevAct == null)
            {
                Compiler.PrintError("Disconnected link", "");
                return false;
            }

            strCurrentExt = FindExtension(this);
            if (strCurrentExt.Trim().Length <= 0)
            {
                Compiler.PrintError("Disconnected link", "");
                return false;
            }

            lpInstruction = new ArrayList();
            string strInstruct = string.Format("exten => {0},{1},Answer({2})", new object[] { strCurrentExt, prevAct.EndPriority, strTimeout });
            lpInstruction.Add(strInstruct);

            //Goto label
            //strInstruct = string.Format("exten => {0},n,Goto({1})", new object[] { strCurrentExt, farActivity.Description.Replace(' ', '_') });
            //lpInstruction.Add(strInstruct);

            return ret;
        }

        private bool compileHangup()
        {
            bool ret = false;
            string strVal = "";
            if (attribute.ContainsKey("hangupcode"))
            {
                strVal = attribute["hangupcode"];
                if (VariableExist(strVal, true))
                {
                    strVal = "${" + strVal + "}";
                }
            }

            strCurrentExt = FindExtension(this);
            if (strCurrentExt.Trim().Length <= 0)
            {
                Compiler.PrintError("Disconnected link", "");
                return false;
            }

            lpInstruction = new ArrayList();
            string strInstruct = string.Format("exten => {0},n({1}),Hangup({2}) ", new object[] { strCurrentExt, strDesc.Replace(' ', '_'), strVal });
            lpInstruction.Add(strInstruct);

            ret = true;

            return ret;
        }

        private bool compileMerge()
        {
            string strVal1 = "";
            string strVal2 = "";
            string strResult = "";
            string strCurrentExt = "";

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

            if (attribute.ContainsKey("var1"))
            {
                strVal1 = attribute["var1"];

                if (VariableExist(strVal1, false))
                {
                    strVal1 = "${" + strVal1 + "}";
                }
            }
            if (attribute.ContainsKey("var2"))
            {
                strVal2 = attribute["var2"];

                if (VariableExist(strVal2, false))
                {
                    strVal2 = "${" + strVal2 + "}";
                }
            }

            Node backResultNode = FindPreviousNodeByEntryNode(this.Entry);
            Node valueNode = FindNodeByResult("Done");
            Node nodeEntry = Compiler.mapLink[valueNode];
            Activity farActivity = FindActivityByEntry(nodeEntry);
            mapNodeValue["[%DONE%]"] = farActivity;

            strCurrentExt = FindExtension(this);
            if (strCurrentExt.Trim().Length <= 0)
            {
                Compiler.PrintError("Disconnected link", "");
                return false;
            }


            lpInstruction = new ArrayList();
            string strInstruct = string.Format("exten => {0},n({1}),Set({2}={3}{4}) ", new object[] { strCurrentExt, strDesc.Replace(' ', '_'), strResult, strVal1, strVal2 });
            lpInstruction.Add(strInstruct);

            //Goto label
            strInstruct = string.Format("exten => {0},n,Goto({1})", new object[] { strCurrentExt, farActivity.Description.Replace(' ', '_') });
            lpInstruction.Add(strInstruct);

            //valueNode.CurrentExtension = strCurrentExt;

            ret = true;

            return ret;
        }

        private bool compileLength()
        {
            string strVal = "";
            string strResult = "";

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

                if (VariableExist(strVal, false))
                {
                    strVal = "${LEN(${" + strVal + "})}";
                }
                else
                {
                    strVal = "${LEN(" + strVal + ")}";
                }
            }

            strCurrentExt = FindExtension(this);
            if (strCurrentExt.Trim().Length <= 0)
            {
                Compiler.PrintError("Disconnected link", "");
                return false;
            }

            Node valueNode = FindNodeByResult("Done");
            Node nodeEntry = Compiler.mapLink[valueNode];
            Activity farActivity = FindActivityByEntry(nodeEntry);
            mapNodeValue["[%DONE%]"] = farActivity;

            lpInstruction = new ArrayList();
            string strInstruct = string.Format("exten => {0},n({1}),Set({2}={3}) ", new object[] { strCurrentExt, strDesc.Replace(' ', '_'), strResult, strVal });
            lpInstruction.Add(strInstruct);

            //Goto label
            strInstruct = string.Format("exten => {0},n,Goto({1})", new object[] { strCurrentExt, farActivity.Description.Replace(' ', '_') });
            lpInstruction.Add(strInstruct);

            ret = true;

            return ret;
        }

        private bool compileCut()
        {
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
            Activity farActivity = FindActivityByEntry(nodeEntry);
            mapNodeValue["[%DONE%]"] = farActivity;

            strCurrentExt = FindExtension(this);
            if (strCurrentExt.Trim().Length <= 0)
            {
                Compiler.PrintError("Disconnected link", "");
                return false;
            }

            lpInstruction = new ArrayList();
            string strInstruct = string.Format("exten => {0},n({1}),Set({2}={3}) ", new object[] { strCurrentExt, strDesc.Replace(' ', '_'), strResult, strVal });
            lpInstruction.Add(strInstruct);

            //Goto label
            strInstruct = string.Format("exten => {0},n,Goto({1})", new object[] { strCurrentExt, farActivity.Description.Replace(' ', '_') });
            lpInstruction.Add(strInstruct);

            ret = true;

            return ret;
        }

        private bool compileCalculation()
        {
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
            Activity farActivity = FindActivityByEntry(nodeEntry);
            mapNodeValue["[%DONE%]"] = farActivity;

            strCurrentExt = FindExtension(this);
            if (strCurrentExt.Trim().Length <= 0)
            {
                Compiler.PrintError("Disconnected link", "");
                return false;
            }


            lpInstruction = new ArrayList();
            string strInstruct = string.Format("exten => {0},n({1}),SET({2}=${{MATH({3}{4}{5},{6})}})",
                new object[] { strCurrentExt, strDesc.Replace(' ', '_'), strResult, strVal1, strOp, strVal2, strType});
            
            
            lpInstruction.Add(strInstruct);

            //Goto label
            strInstruct = string.Format("exten => {0},n,Goto({1})", new object[] { strCurrentExt, farActivity.Description.Replace(' ', '_') });
            lpInstruction.Add(strInstruct);

            ret = true;

            return ret;

        }

        private bool compileCompare()
        {
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
            Activity farActivity1 = FindActivityByEntry(nodeEntry1);
            mapNodeValue["[%YES%]"] = farActivity1;

            Node valueNode2 = FindNodeByResult("No");
            Node nodeEntry2 = Compiler.mapLink[valueNode2];
            Activity farActivity2 = FindActivityByEntry(nodeEntry2);
            mapNodeValue["[%NO%]"] = farActivity2;


            string strDesc1 = farActivity1.Description.Replace(' ', '_');
            string strDesc2 = farActivity2.Description.Replace(' ', '_');

            lpInstruction = new ArrayList();
            string strInstruct = string.Format("exten => {0},n({1}),Gotoif($[\"{2}\" {3} \"{4}\"]?{5}:{6})",
                new object[] { strCurrentExt, strDesc.Replace(' ', '_'), strVal1, strOp, strVal2, strDesc1, strDesc2 });
            lpInstruction.Add(strInstruct);

            ret = true;

            return ret;

        }

        private bool compileSet()
        {
            string strVal = "";
            string strEqualto = "";
            bool ret = false;

            if (attribute.ContainsKey("variable"))
            {
                strVal = attribute["variable"];
                if (!VariableExist(strVal, false))
                {
                    Compiler.PrintError("Activity '" + strDesc + "' in '" + this.FindFlow(strDocID) + "' - variable " + strVal + " not be defined.", "");
                    return ret;
                }
                
            }
            if (attribute.ContainsKey("equalto"))
            {
                strEqualto = attribute["equalto"];

                if (strEqualto.Trim().Length <= 0)
                {
                    Compiler.PrintError("Activity '" + strDesc + "' in '" + this.FindFlow(strDocID) + "' - variable " + strEqualto + " not be defined.", "");
                    return ret;
                }
                else if (!VariableExist(strEqualto, true))
                {
                    //none
                }
                else
                {
                    strEqualto = "${" + strEqualto + "}";
                }
            }

            strCurrentExt = FindExtension(this);
            if (strCurrentExt.Trim().Length <= 0)
            {
                Compiler.PrintError("Disconnected link", "");
                return false;
            }

            Node valueNode = FindNodeByResult("Done");
            Node nodeEntry = Compiler.mapLink[valueNode];
            Activity farActivity = FindActivityByEntry(nodeEntry);
            mapNodeValue["[%DONE%]"] = farActivity;

            lpInstruction = new ArrayList();
            string strInstruct = string.Format("exten => {0},n({1}),Set({2}={3}) ", new object[] { strCurrentExt, strDesc.Replace(' ', '_'), strVal, strEqualto });
            lpInstruction.Add(strInstruct);

            //Goto label
            strInstruct = string.Format("exten => {0},n,Goto({1})", new object[] { strCurrentExt, farActivity.Description.Replace(' ', '_') });
            lpInstruction.Add(strInstruct);

            ret = true;

            return ret;
        }

        private bool compileGetDigits()
        {
            bool ret = false;
            lpInstruction = new ArrayList();
            string strInstruct = "";
            string strMaxDigit = "";
            string strRetry = "";
            string strSilent = "";
            string strEntryMsg = "";
            string strInvalidMsg = "";
            string strNoInputMsg = "";
            string strResult = "";
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

            strInstruct = string.Format("exten => {11},n({8}),AGI(\"getdigits2.php\",\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{9}\",\"{10}\")",
                new object[] { strEntryMsg, strSilent, strMaxDigit, "0", strResult, strRetry, strNoInputMsg, strInvalidMsg, strDesc.Replace(' ', '_'), strGlobalTimeout, strGlobalInvalidInput, strCurrentExt });

            lpInstruction.Add(strInstruct);

            for (int idx = 0; idx < strResult.Length; idx++)
            {
                string strItem = strResult.Substring(idx, 1);
                Node valueNode = FindNodeByResult(strItem);
                Node nodeEntry = Compiler.mapLink[valueNode];
                Activity farActivity = FindActivityByEntry(nodeEntry);

                mapNodeValue["[%" + strItem.Trim() + "%]"] = farActivity;

                strInstruct = string.Format("exten => {2},n,Gotoif($[\"${{keys}}\"=\"{0}\"]?{1})", new object[] { strItem.Trim(), farActivity.Description.Replace(' ', '_'), strCurrentExt });
                
                lpInstruction.Add(strInstruct);
            }

            ret = true;
            return ret;
        }

        private bool compileRead()
        {
            bool ret = false;
            lpInstruction = new ArrayList();
            string strInstruct = "";
            string strMaxDigit = "";
            string strRetry = "";
            string strSilent = "";
            string strEntryMsg = "";
            string strOptions= "";
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

            strInstruct = string.Format("exten => {7},n({6}),read({0},{1},{2},{3},{4},{5})",
                new object[] { strVariable, strEntryMsg, strMaxDigit,strOptions, strRetry, strSilent, strDesc.Replace(' ', '_') , strCurrentExt});
            lpInstruction.Add(strInstruct);

            Node valueNode = FindNodeByResult("Done");
            Node nodeEntry = Compiler.mapLink[valueNode];
            Activity farActivity = FindActivityByEntry(nodeEntry);
            mapNodeValue["[%DONE%]"] = farActivity;

            //Goto label
            strInstruct = string.Format("exten => {0},n,Goto({1})", new object[] { strCurrentExt, farActivity.Description.Replace(' ', '_') });
            lpInstruction.Add(strInstruct);

            ret = true;

            return ret;
        }

        private bool compileBridgeCall()
        {
            bool ret = false;
            lpInstruction = new ArrayList();
            string strInstruct = "";
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

            strInstruct = string.Format("exten => {0},n({1}),Dial({2},{3},{4})", new object[] { strCurrentExt, strDesc.Replace(' ', '_'), strDialTo, strWait, strOption });
            lpInstruction.Add(strInstruct);

            Node valueNode = FindNodeByResult("CHANUNAVAIL");
            Node nodeEntry = Compiler.mapLink[valueNode];
            Activity farActivity = FindActivityByEntry(nodeEntry);
            mapNodeValue["[%CHANUNAVAIL%]"] = farActivity;
            string strDesc2 = farActivity.Description.Replace(' ', '_');
            strInstruct = string.Format("exten => {0},n,Gotoif($[\"${{DIALSTATUS}}\"=\"CHANUNAVAIL\"]?{1})", new object[] { strCurrentExt, strDesc2 });
            lpInstruction.Add(strInstruct);

            valueNode = FindNodeByResult("BUSY");
            nodeEntry = Compiler.mapLink[valueNode];
            farActivity = FindActivityByEntry(nodeEntry);
            mapNodeValue["[%BUSY%]"] = farActivity;
            strDesc2 = farActivity.Description.Replace(' ', '_');
            strInstruct = string.Format("exten => {0},n,Gotoif($[\"${{DIALSTATUS}}\"=\"BUSY\"]?{1})", new object[] { strCurrentExt, strDesc2 });
            lpInstruction.Add(strInstruct);
            
            valueNode = FindNodeByResult("NOANSWER");
            nodeEntry = Compiler.mapLink[valueNode];
            farActivity = FindActivityByEntry(nodeEntry);
            mapNodeValue["[%NOANSWER%]"] = farActivity;
            strDesc2 = farActivity.Description.Replace(' ', '_');
            strInstruct = string.Format("exten => {0},n,Gotoif($[\"${{DIALSTATUS}}\"=\"NOANSWER\"]?{1})", new object[] { strCurrentExt, strDesc2 });
            lpInstruction.Add(strInstruct);
            
            valueNode = FindNodeByResult("ANSWER");
            nodeEntry = Compiler.mapLink[valueNode];
            farActivity = FindActivityByEntry(nodeEntry);
            mapNodeValue["[%ANSWER%]"] = farActivity;
            strDesc2 = farActivity.Description.Replace(' ', '_');
            strInstruct = string.Format("exten => {0},n,Gotoif($[\"${{DIALSTATUS}}\"=\"ANSWER\"]?{1})", new object[] { strCurrentExt, strDesc2 });
            lpInstruction.Add(strInstruct);
            
            valueNode = FindNodeByResult("CANCEL");
            nodeEntry = Compiler.mapLink[valueNode];
            farActivity = FindActivityByEntry(nodeEntry);
            mapNodeValue["[%CANCEL%]"] = farActivity;
            strDesc2 = farActivity.Description.Replace(' ', '_');
            strInstruct = string.Format("exten => {0},n,Gotoif($[\"${{DIALSTATUS}}\"=\"CANCEL\"]?{1})", new object[] { strCurrentExt, strDesc2 });
            lpInstruction.Add(strInstruct);
            
            valueNode = FindNodeByResult("DONTCALL");
            nodeEntry = Compiler.mapLink[valueNode];
            farActivity = FindActivityByEntry(nodeEntry);
            mapNodeValue["[%DONTCALL%]"] = farActivity;
            strDesc2 = farActivity.Description.Replace(' ', '_');
            strInstruct = string.Format("exten => {0},n,Gotoif($[\"${{DIALSTATUS}}\"=\"DONTCALL\"]?{1})", new object[] { strCurrentExt, strDesc2 });
            lpInstruction.Add(strInstruct);
            
            valueNode = FindNodeByResult("TORTURE");
            nodeEntry = Compiler.mapLink[valueNode];
            farActivity = FindActivityByEntry(nodeEntry);
            mapNodeValue["[%TORTURE%]"] = farActivity;
            strDesc2 = farActivity.Description.Replace(' ', '_');
            strInstruct = string.Format("exten => {0},n,Gotoif($[\"${{DIALSTATUS}}\"=\"TORTURE\"]?{1})", new object[] { strCurrentExt, strDesc2 });
            lpInstruction.Add(strInstruct);
            
            valueNode = FindNodeByResult("CONGESTION");
            nodeEntry = Compiler.mapLink[valueNode];
            farActivity = FindActivityByEntry(nodeEntry);
            mapNodeValue["[%CONGESTION%]"] = farActivity;
            strDesc2 = farActivity.Description.Replace(' ', '_');
            strInstruct = string.Format("exten => {0},n,Gotoif($[\"${{DIALSTATUS}}\"=\"CONGESTION\"]?{1})", new object[] { strCurrentExt, strDesc2 });
            lpInstruction.Add(strInstruct);

            ret = true;

            return ret;
        }

        private bool compilePlayMsg()
        {
            bool ret = false;
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
                strInstruct = string.Format("exten => {0},n({1}),Playback({2})", new object[] { strCurrentExt, strDesc.Replace(' ', '_'), strMsg });
                lpInstruction.Add(strInstruct);

                Node valueNode = FindNodeByResult("DONE");
                Node nodeEntry = Compiler.mapLink[valueNode];
                Activity farActivity1 = FindActivityByEntry(nodeEntry);
                mapNodeValue["[%DONE%]"] = farActivity1;

                strInstruct = string.Format("exten => {0},n,Goto({1})", new object[] { strCurrentExt, farActivity1.Description.Replace(' ', '_') });
                lpInstruction.Add(strInstruct);

                ret = true;
            }
            else
            {
                Node valueNode = FindNodeByResult("DONE");
                Node nodeEntry = Compiler.mapLink[valueNode];
                Activity farActivity1 = FindActivityByEntry(nodeEntry);
                mapNodeValue["[%DONE%]"] = farActivity1;

                valueNode = FindNodeByResult("DTMF");
                nodeEntry = Compiler.mapLink[valueNode];
                Activity farActivity2 = FindActivityByEntry(nodeEntry);
                mapNodeValue["[%DTMF%]"] = farActivity2;

                strInstruct = string.Format("exten => {0},n({1}),Read(digitto,{1},1,,0,1)", new object[] { strCurrentExt, strDesc.Replace(' ', '_'), strMsg });
                lpInstruction.Add(strInstruct);

                string strDesc1 = farActivity1.Description.Replace(' ', '_');
                string strDesc2 = farActivity2.Description.Replace(' ', '_');
                strInstruct = string.Format("exten => {0},n,Gotoif($[ \"${{LEN(${{digitto}})}}\" > \"0\"]?{1}:{2})", new object[] { strCurrentExt, strDesc1, strDesc2 });
                lpInstruction.Add(strInstruct);

                ret = true;
            }

            return ret;

        }


        private bool compileSetLang()
        {
            bool ret = false;

            strCurrentExt = FindExtension(this);
            if (strCurrentExt.Trim().Length <= 0)
            {
                Compiler.PrintError("Disconnected link", "");
                return false;
            }

            string strLang = "";
            if (attribute.ContainsKey("language"))
            {
                strLang = attribute["language"];

                if (strLang.Trim().Length <= 0)
                {
                    Compiler.PrintError("Activity '" + strDesc + "' in '" + this.FindFlow(strDocID) + "' - variable " + strLang + " not be defined.", "");
                    return ret;
                }
                else if (!VariableExist(strLang, true))
                {
                    strLang = "${" + strLang + "}";
                }
            }

            Node valueNode = FindNodeByResult("Done");
            Node nodeEntry = Compiler.mapLink[valueNode];
            Activity farActivity = FindActivityByEntry(nodeEntry);
            mapNodeValue["[%DONE%]"] = farActivity;

            lpInstruction = new ArrayList();
            string strInstruct = string.Format("exten => {0},n({1}),Set(CHANNEL(language)={2}) ", new object[] { strCurrentExt, strDesc.Replace(' ', '_'), strLang });
            lpInstruction.Add(strInstruct);

            //Goto label
            strInstruct = string.Format("exten => {0},n,Goto({1})", new object[] { strCurrentExt, farActivity.Description.Replace(' ', '_') });
            lpInstruction.Add(strInstruct);

            ret = true;
            return ret;
        }

        private bool compileAGI()
        {
            bool ret = false;
            string strVal = "";

            strCurrentExt = FindExtension(this);
            if (strCurrentExt.Trim().Length <= 0)
            {
                Compiler.PrintError("Disconnected link", "");
                return false;
            }
            if (attribute.ContainsKey("agi"))
            {
                strVal = attribute["agi"];

                if (strVal.Trim().Length <= 0)
                {
                    Compiler.PrintError("Activity '" + strDesc + "' in '" + this.FindFlow(strDocID) + "' - variable " + strVal + " not be defined.", "");
                    return ret;
                }
                else if (VariableExist(strVal, true))
                {
                    strVal = "${" + strVal + "}";
                }
            }

            Node valueNode = FindNodeByResult("Done");
            Node nodeEntry = Compiler.mapLink[valueNode];
            Activity farActivity = FindActivityByEntry(nodeEntry);
            mapNodeValue["[%DONE%]"] = farActivity;

            lpInstruction = new ArrayList();
            string strInstruct = string.Format("exten => {0},n({1}),AGI({2}) ", new object[] { strCurrentExt, strDesc.Replace(' ', '_'), strVal });
            lpInstruction.Add(strInstruct);

            //Goto label
            strInstruct = string.Format("exten => {0},n,Goto({1})", new object[] { strCurrentExt, farActivity.Description.Replace(' ', '_') });
            lpInstruction.Add(strInstruct);

            ret = true;

            return ret;
        }

        private bool compileAuth()
        {
            bool ret = false;


            strCurrentExt = FindExtension(this);
            if (strCurrentExt.Trim().Length <= 0)
            {
                Compiler.PrintError("Disconnected link", "");
                return false;
            }

            string strVal = "";
            if (attribute.ContainsKey("password"))
            {
                strVal = attribute["password"];
                if (strVal.Trim().Length <= 0)
                {
                    Compiler.PrintError("Activity '" + strDesc + "' in '" + this.FindFlow(strDocID) + "' - variable " + strVal + " not be defined.", "");
                    return ret;
                }
                else if (VariableExist(strVal, true))
                {
                    strVal = "${" + strVal + "}";
                }
            }
            Node valueNode = FindNodeByResult("Done");
            Node nodeEntry = Compiler.mapLink[valueNode];
            Activity farActivity = FindActivityByEntry(nodeEntry);
            mapNodeValue["[%DONE%]"] = farActivity;

            lpInstruction = new ArrayList();
            string strInstruct = string.Format("exten => {0},n({1}),Authenticate({2}) ", new object[] { strCurrentExt, strDesc.Replace(' ', '_'), strVal });
            lpInstruction.Add(strInstruct);

            //Goto label
            strInstruct = string.Format("exten => {0},n,Goto({1})", new object[] { strCurrentExt, farActivity.Description.Replace(' ', '_') });
            lpInstruction.Add(strInstruct);

            ret = true;

            return ret;
        }

        private bool compileRecord()
        {
            bool ret = false;
            string strSilent = "";
            string strDuration = "";
            string strFile = "";
            string strFormat = "";
            string strOptions = "";


            strCurrentExt = FindExtension(this);
            if (strCurrentExt.Trim().Length <= 0)
            {
                Compiler.PrintError("Disconnected link", "");
                return false;
            }

            Node valueNode = FindNodeByResult("Done");
            Node nodeEntry = Compiler.mapLink[valueNode];
            Activity farActivity = FindActivityByEntry(nodeEntry);
            mapNodeValue["[%DONE%]"] = farActivity;

            if (attribute.ContainsKey("silent"))
            {
                strSilent = attribute["silent"];
            }
            if (attribute.ContainsKey("duration"))
            {
                strDuration = attribute["duration"];
            }
            if (attribute.ContainsKey("filename"))
            {
                strFile = attribute["filename"];

                if (strFile.Trim().Length <= 0)
                {
                    Compiler.PrintError("Activity '" + strDesc + "' in '" + this.FindFlow(strDocID) + "' - variable " + strFile + " not be defined.", "");
                    return ret;
                }
                else if (VariableExist(strFile, true))
                {
                    strFile = "${" + strFile + "}";
                }

            }
            if (attribute.ContainsKey("format"))
            {
                strFormat = attribute["format"];
            }
            if (attribute.ContainsKey("options"))
            {
                strOptions = attribute["options"];
            }

            lpInstruction = new ArrayList();
            string strInstruct = string.Format("exten => {6},n({0}),Record({1}.{2},{3},{4},{5}) ", 
                new object[] { strDesc.Replace(' ', '_'), strFile, strFormat, strSilent, strDuration, strOptions, strCurrentExt });
            lpInstruction.Add(strInstruct);

            //Goto label
            strInstruct = string.Format("exten => {0},n,Goto({1})", new object[] { strCurrentExt, farActivity.Description.Replace(' ', '_') });
            lpInstruction.Add(strInstruct);

            ret = true;

            return ret;
        }

        private bool compileGoto()
        {
            bool ret = false;
            Node valueNode = FindFirstNode();
            Node nodeEntry = Compiler.mapLink[valueNode];
            Activity farActivity = FindActivityByEntry(nodeEntry);
            mapNodeValue["[%DONE%]"] = farActivity;


            strCurrentExt = FindExtension(this);
            if (strCurrentExt.Trim().Length <= 0)
            {
                Compiler.PrintError("Disconnected link", "");
                return false;
            }


            if (Compiler.mapPage.ContainsKey(farActivity.DocID))
            {
                Page page = Compiler.mapPage[farActivity.DocID];

                //Goto label
                lpInstruction = new ArrayList();
                string strInstruct = string.Format("exten => {0},n({1}),Goto({2},{3},{4})", new object[] { strCurrentExt, strDesc.Replace(' ', '_'), page.FlowName.Replace(' ', '_'), "${EXTEN}", 1 });
                lpInstruction.Add(strInstruct);

                ret = true;
            }
            else
            {
                Compiler.PrintError("Subflow for " + strDesc + " not be defined.", "");
            }

            return ret;
        }

        private bool compileSay()
        {
            bool ret = false;
            string strVal = "";
            string strType = "";


            strCurrentExt = FindExtension(this);
            if (strCurrentExt.Trim().Length <= 0)
            {
                Compiler.PrintError("Disconnected link", "");
                return false;
            }

            if (attribute.ContainsKey("variable"))
            {
                strVal = attribute["variable"];

                if (strVal.Trim().Length <= 0)
                {
                    Compiler.PrintError("Activity '" + strDesc + "' in '" + this.FindFlow(strDocID) + "' - variable " + strVal + " not be defined.", "");
                    return ret;
                }
                else if (VariableExist(strVal, true))
                {
                    strVal = "${" + strVal + "}";
                }
            }
            if (attribute.ContainsKey("type"))
            {
                strType = attribute["type"];
            }

            Node valueNode = FindNodeByResult("Done");
            Node nodeEntry = Compiler.mapLink[valueNode];
            Activity farActivity = FindActivityByEntry(nodeEntry);
            mapNodeValue["[%DONE%]"] = farActivity;


            lpInstruction = new ArrayList();
            if (strType.ToUpper() == "Digits".ToUpper())
            {
                string strInstruct = string.Format("exten => {2},n({0}),SayDigits(${{{1}}}) ", new object[] { strDesc.Replace(' ', '_'), strVal, strCurrentExt });
                lpInstruction.Add(strInstruct);
            }
            else if (strType.ToUpper() == "Alpha".ToUpper())
            {
                string strInstruct = string.Format("exten => {2},n({0}),SayAlpha(${{{1}}}) ", new object[] { strDesc.Replace(' ', '_'), strVal, strCurrentExt });
                lpInstruction.Add(strInstruct);
            }
            else if (strType.ToUpper() == "Number".ToUpper())
            {
                string strInstruct = string.Format("exten => {2},n({0}),SayNumber(${{{1}}}) ", new object[] { strDesc.Replace(' ', '_'), strVal, strCurrentExt });
                lpInstruction.Add(strInstruct);
            }
            else if (strType.ToUpper() == "Phonetic".ToUpper())
            {
                string strInstruct = string.Format("exten => {2},n({0}),SayPhonetic(${{{1}}}) ", new object[] { strDesc.Replace(' ', '_'), strVal, strCurrentExt });
                lpInstruction.Add(strInstruct);
            }
            else
            {
                string strInstruct = string.Format("exten => {2},n({0}),SayDigits(${{{1}}}) ", new object[] { strDesc.Replace(' ', '_'), strVal, strCurrentExt });
                lpInstruction.Add(strInstruct);
            }

            //Goto label
            string strInstruct2 = string.Format("exten => {0},n,Goto({1})", new object[] { strCurrentExt, farActivity.Description.Replace(' ', '_') });
            lpInstruction.Add(strInstruct2);

            ret = true;

            return ret;
        }

        private bool compileSubProc()
        {
            bool ret = false;
            Node valueNode = this.PrimaryNode;
            Node nodeEntry = Compiler.mapLink[valueNode];
            Activity farActivity = FindActivityByEntry(nodeEntry); //Sub-proc entry activity
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
                    strInstruct = string.Format("exten => {0},n({1}),Gosub({2},${{EXTEN}},1({3}))",
                        new object[] { strCurrentExt, strDesc.Replace(' ', '_'), page.FlowName.Replace(' ', '_'), strVal });
                }
                else
                {
                    strInstruct = string.Format("exten => {0},n({1}),Gosub({2},${{EXTEN}},1)",
                        new object[] { strCurrentExt, strDesc.Replace(' ', '_'), page.FlowName.Replace(' ', '_')});
                }

                lpInstruction.Add(strInstruct);

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
                            Activity farActivity2 = FindActivityByEntry(nodeEntry2);

                            mapNodeValue["[%" + strItem.Trim() + "%]"] = farActivity2;

                            strInstruct = string.Format("exten => {0},n,Gotoif($[\"${{RETVAL}}\"=\"{1}\"]?{2})", new object[] {strCurrentExt, strItem.Trim(), farActivity2.Description.Replace(' ', '_') });
                            lpInstruction.Add(strInstruct);
                        }
                    }
                    ret = true;
                }
            }

            return ret;
        }

        private bool compileSubProcEnd()
        {
            //SubProc End
            strCurrentExt = FindExtension(this);
            if (strCurrentExt.Trim().Length <= 0)
            {
                Compiler.PrintError("Disconnected link", "");
                return false;
            }

            lpInstruction = new ArrayList();
            string strInstruct = string.Format("exten => {0},n({1}),Set(RETVAL=\"{2}\")",
                new object[] { strCurrentExt, strDesc.Replace(' ', '_'), this.Value.Trim() });
            lpInstruction.Add(strInstruct);

            strInstruct = "exten => " + strCurrentExt + ",n,Return";
            lpInstruction.Add(strInstruct);

            return true;
        }

        private string FindExtension(Activity act)
        {
            string strRet = "";
            Node entryNode = act.Entry;
            Activity prevAct = FindPreviousActivity(entryNode);

            if (prevAct != null)
            {
                if (prevAct.ActivityName.ToLower() == "start")
                {
                    Node prevNode = FindPreviousNodeByEntryNode(entryNode);
                    strRet = prevNode.Value;
                }
                else if (prevAct.ActivityName.ToLower() == "changeext")
                {
                    if (prevAct.Attribute.ContainsKey("ext"))
                    {
                        strRet = prevAct.Attribute["ext"];
                    }
                }
                else
                {

                    if (prevAct.CurrentExtension.Trim().Length > 0)
                    {
                        strRet = prevAct.CurrentExtension;
                    }
                    else
                    {
                        strRet = FindExtension(prevAct);
                    }
                }
            }
            
            return strRet;
        }


        private Activity FindPreviousActivity(Node thisEntry)
        {
            bool foundAct = false;
            Activity act = null;
            Node node = FindPreviousNodeByEntryNode(thisEntry);

            Dictionary<string, Activity>.Enumerator lpAct = Compiler.mapActivity.GetEnumerator();
            while (lpAct.MoveNext())
            {
                KeyValuePair<string, Activity> item = lpAct.Current;
                Activity thisAct = item.Value;
                Dictionary<string, Node>.Enumerator lpNode = thisAct.ResultNode.GetEnumerator();
                while (lpNode.MoveNext())
                {
                    KeyValuePair<string, Node> nodeItem = lpNode.Current;
                    Node thisNode = nodeItem.Value;

                    if (thisNode.NodeID == node.NodeID)
                    {
                        act = thisAct;
                        foundAct = true;
                        break;
                    }
                }

                if (foundAct)
                {
                    break;
                }
            }

            return act;
        }

        private Node FindPreviousNodeByEntryNode(Node entry)
        {
            Node ret = null;

            Dictionary<Node, Node>.Enumerator lpNode = Compiler.mapLink.GetEnumerator();
            while (lpNode.MoveNext())
            {
                KeyValuePair<Node, Node> item = lpNode.Current;

                if (item.Value.NodeID == entry.NodeID)
                {
                    ret = item.Key;
                    break;
                }
            }
            
            return ret;
        }

        private Activity FindActivityByEntry(Node entry)
        {
            Activity lpRet = null;

            Dictionary<string, Activity>.Enumerator lpAct = Compiler.mapActivity.GetEnumerator();
            while (lpAct.MoveNext())
            {
                KeyValuePair<string, Activity> item = lpAct.Current;
                if (item.Value.Entry.NodeID == entry.NodeID)
                {
                    lpRet = item.Value;
                    break;
                }

            }

            return lpRet;
        }

        private Node FindNodeByResult(string strResult)
        {
            Node ret = null;

            Dictionary<string, Node>.Enumerator lpNode = resultNode.GetEnumerator();
            while (lpNode.MoveNext())
            {
                KeyValuePair<string, Node> item = lpNode.Current;

                if (item.Value.Value.Trim().ToUpper() == strResult.Trim().ToUpper())
                {
                    ret = item.Value;
                    break;
                }
            }
            return ret;
        }

        private Node FindFirstNode()
        {
            Node ret = null;

            Dictionary<string, Node>.Enumerator lpNode = resultNode.GetEnumerator();
            while (lpNode.MoveNext())
            {
                KeyValuePair<string, Node> item = lpNode.Current;
                ret = item.Value;
                break;
            }
            return ret;
        }

        private string ConcatResult()
        {
            string ret = "";

            Dictionary<string, Node>.Enumerator lpNode = resultNode.GetEnumerator();
            while (lpNode.MoveNext())
            {
                KeyValuePair<string, Node> item = lpNode.Current;
                ret += item.Value.Value;
            }
            return ret;
        }

        private bool IsNumber(string strVar)
        {
            bool ret = false;

            try
            {
                int i = Convert.ToInt32(strVar);
                ret = true;
            }
            catch (Exception ex)
            {
            }

            return ret;
        }

        private bool VariableExist(string strVar, bool warnonly)
        {
            bool ret = false;

            if (Compiler.mapVar.ContainsKey(strVar))
            {
                ret = true;
            }
            else
            {
                if (warnonly)
                {
                    string strErr = string.Format("Variable {0} not exist ", new object[] { strVar });
                    Compiler.PrintWarn(strErr, "");
                }
                else
                {
                    string strErr = string.Format("Fatal error: Variable {0} not exist ", new object[] { strVar });
                    Compiler.PrintError(strErr, "");
                }
            }

            return ret;
        }

        private string FindFlow(string str)
        {
            string ret = "";

            try
            {
                ret = Compiler.mapPage[str].FlowName;
            }
            catch (Exception ex)
            {
            }

            return ret;
        }

        public string CurrentExtension
        {
            get
            {
                return strCurrentExt;
            }

            set
            {
                strCurrentExt = value;
            }
        }
    }
}
