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
    public class MixMonitorActivity : AbstractActivity, IActivity
    {
        public MixMonitorActivity() : base()
        {
        }

        public bool compile()
        {
            base.compile();

            string strVal = "";
            string strFile = "";
            string strExt = "";
            string strOptions = "";
            string strCmd = "";
            string strOthers = "";

            bool ret = false;

            if (attribute.ContainsKey("filename"))
            {
                strFile = attribute["filename"];

                if (strFile.Trim().Length > 0)
                {
                    if (VariableExist(strFile, true))
                    {
                        strFile = "${" + strFile + "}";
                    }
                }
                else
                {
                    Compiler.PrintError("Activity '" + strDesc + "' in '" + this.FindFlow(strDocID) + "' - filename not be defined.", "");
                    return ret;
                }
            }
            else
            {
                Compiler.PrintError("Activity '" + strDesc + "' in '" + this.FindFlow(strDocID) + "' - filename not be defined.", "");
                return ret;
            }

            if (attribute.ContainsKey("ext"))
            {
                strExt = attribute["ext"];

                if (strExt.Trim().Length > 0)
                {
                    if (VariableExist(strExt, true))
                    {
                        strExt = "${" + strExt + "}";
                    }
                }
                else
                {
                    Compiler.PrintError("Activity '" + strDesc + "' in '" + this.FindFlow(strDocID) + "' - file extension not be defined.", "");
                    return ret;
                }
            }
            else
            {
                Compiler.PrintError("Activity '" + strDesc + "' in '" + this.FindFlow(strDocID) + "' - file extension not be defined.", "");
                return ret;
            }

            if (attribute.ContainsKey("bridge"))
            {
                strVal = attribute["bridge"];

                if (strVal.Trim().Length > 0)
                {
                    if (strVal == "1")
                    {
                        strOptions += "b";
                    }
                }
            }

            if (attribute.ContainsKey("append"))
            {
                strVal = attribute["append"];

                if (strVal.Trim().Length > 0)
                {
                    if (strVal == "1")
                    {
                        strOptions += "a";
                    }
                }
            }

            if (attribute.ContainsKey("spokevolume"))
            {
                strVal = attribute["spokevolume"];

                if (this.IsNumber(strVal))
                {
                    strOptions += "V(" + strVal + ")";
                }
            }

            if (attribute.ContainsKey("heardvolume"))
            {
                strVal = attribute["heardvolume"];

                if (this.IsNumber(strVal))
                {
                    strOptions += "v(" + strVal + ")";
                }
            }

            if (attribute.ContainsKey("overallvolume"))
            {
                strVal = attribute["overallvolume"];

                if (this.IsNumber(strVal))
                {
                    strOptions += "W(" + strVal + ")";
                }
            }

            if (attribute.ContainsKey("cmd"))
            {
                strCmd = attribute["cmd"];
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


            if (strCmd.Trim().Length > 0 && strOptions.Trim().Length > 0)
            {
                strOthers = "," + strOptions + "," + strCmd;
            }
            else if (strCmd.Trim().Length <= 0 && strOptions.Trim().Length > 0)
            {
                strOthers = "," + strOptions;
            }
            else if (strCmd.Trim().Length > 0 && strOptions.Trim().Length <= 0)
            {
                strOthers = ",," + strCmd;
            }
            

            lpInstruction = new ArrayList();
            InstructionSet set = new InstructionSet();
            set.ExtNumber = strCurrentExt;
            set.Label = strDesc.Replace(' ', '_');
            set.Instruction = string.Format("MixMonitor({0}.{1}{2}) ", new object[] { strFile, strExt, strOthers });
            lpInstruction.Add(set);

            priorityOffset = lpInstruction.Count - 1;

            ret = true;

            return ret;
        }
    }
}
