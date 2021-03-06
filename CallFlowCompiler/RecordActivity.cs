﻿/******************************************************************************************
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
    public class RecordActivity : AbstractActivity, IActivity
    {
        public RecordActivity() : base()
        {

        }

        public bool compile()
        {
            base.compile();

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
            IActivity farActivity = FindActivityByEntry(nodeEntry);
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

            InstructionSet set = new InstructionSet();
            set.ExtNumber = strCurrentExt;
            set.Label = strDesc.Replace(' ', '_');
            set.Instruction = string.Format("Record({0}.{1},{2},{3},{4}) ",
                new object[] { strFile, strFormat, strSilent, strDuration, strOptions });
            lpInstruction.Add(set);


            priorityOffset = lpInstruction.Count - 1;

            ret = true;

            return ret;
        }
    }
}
