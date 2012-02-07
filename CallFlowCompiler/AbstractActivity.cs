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
using System.Resources;
using System.Diagnostics;

namespace Interaction.Compiler
{
    public abstract class AbstractActivity : IActivity
    {
        protected string strID = "";
        protected string strName = "";
        protected string strValue = "";
        protected string strDesc = "";
        protected string strDocID = "";
        protected string strCurrentExt = "";
        protected int startPriority = -1;
        protected int priorityOffset = 0;
        protected Node entryActivity = null;
        protected Node primaryNode = null;
        protected Dictionary<string, Node> resultNode = new Dictionary<string, Node>();
        protected Dictionary<string, string> attribute = new Dictionary<string, string>();

        protected Dictionary<string, IActivity> mapNodeValue = new Dictionary<string, IActivity>();
        protected ArrayList lpInstruction;
        protected string strContext = "";

        //private static int overallPriority = 0;

        public AbstractActivity()
        {
        }

        public string Context
        {
            get
            {
                return strContext;
            }

            set
            {
                strContext = value;
            }
        }

        public int StartPriority
        {
            get
            {
                return startPriority;
            }

            set
            {
                startPriority = value;

                int cnt = 0;
                if (lpInstruction != null)
                {
                    foreach (InstructionSet set in lpInstruction)
                    {
                        if (this.ActivityName.ToLower() != "start")
                        {
                            set.Priority = startPriority + cnt;
                            cnt++;
                        }
                        else
                        {
                            set.Priority = 1;
                        }
                    }
                }
            }
        }

        public int PriorityOffset
        {
            get
            {
                return priorityOffset;
            }
            set
            {
                priorityOffset = value;
            }
        }

        public int EndPriority
        {
            get
            {
                return startPriority + priorityOffset;
            }
        }

        public ArrayList Instructions
        {
            get
            {
                return lpInstruction;
            }
        }

        public int InstructionCount
        {
            get
            {
                if (this.ActivityName.ToLower() == "start")
                {
                    return 1;
                }

                return lpInstruction.Count;
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

        public bool compile()
        {
            System.Diagnostics.Debug.WriteLine(string.Format("Compile {0} - Label {1} - {2}", new object[]{this.ActivityName, this.Description, this.ActivityID}));

            return true;
        }

        public bool CanJumpNear()
        {
            bool ret = false;

            if (this.ActivityName.ToLower() == "compare"
                || this.ActivityName.ToLower() == "bridgecall"
                || this.ActivityName.ToLower() == "gotoiftime"
                || this.ActivityName.ToLower() == "subproc"
                || this.ActivityName.ToLower() == "goto"
                || this.ActivityName.ToLower() == "changeext"
                || this.ActivityName.ToLower() == "switchcase"
                || this.ActivityName.ToLower() == "playmsg")
            {
                ret = false;
            }
            else
            {
                ret = true;
            }

            return ret;
        }

        public bool sequence(int overall)
        {
            bool ret = false;
            int overallPriority = overall;


            if (resultNode.Count > 0)
            {
                Dictionary<string, Node>.Enumerator lpThisNodes = resultNode.GetEnumerator();

                while (lpThisNodes.MoveNext())
                {
                    if (this.ActivityName.ToLower() == "start")
                    {
                        overallPriority = 1;
                    }

                    KeyValuePair<string, Node> itemNode = lpThisNodes.Current;
                    Node thisResultNode = itemNode.Value;
                    Node nextEntryNode = Compiler.mapLink[thisResultNode];
                    IActivity nextActivity = FindActivityByEntry(nextEntryNode);

                    Debug.WriteLine("Enter Activity : " + this.ActivityID + " - " + this.Description + " - StartPriority = " + Convert.ToString(this.StartPriority) + " EndPriority = " + Convert.ToString(this.EndPriority) + " Overall = " + Convert.ToString(overallPriority));

                    if (this.ActivityName.ToLower() == "changeext")
                    {
                    }
                    else if (nextActivity.StartPriority <= 0)
                    {
                        nextActivity.StartPriority = overallPriority + this.InstructionCount;
                        overallPriority += this.InstructionCount;
                        Debug.WriteLine("Next Activity (<0) : " + nextActivity.ActivityID + " - " + nextActivity.Description + " - StartPriority = " + Convert.ToString(nextActivity.StartPriority) + " EndPriority = " + Convert.ToString(nextActivity.EndPriority));
                        nextActivity.sequence(overallPriority);
                        nextActivity.adjustSequence();
                    }
                    else
                    {
                        Debug.WriteLine("Loopback Activity : " + this.ActivityID + " - " + this.Description + " - StartPriority = " + Convert.ToString(this.StartPriority) + " EndPriority = " + Convert.ToString(this.EndPriority));

                        if (this.StartPriority > nextActivity.StartPriority)
                        {
                            if (CanJumpNear())
                            {
                                InstructionSet set = new InstructionSet();
                                set.ExtNumber = strCurrentExt;
                                set.Label = "";
                                set.Instruction = string.Format("Goto({0})", new object[] { nextActivity.StartPriority });
                                lpInstruction.Add(set);
                                int _tmpS = this.StartPriority;
                                this.StartPriority = _tmpS;
                                overallPriority++;
                            }
                        }
                        

                        Debug.WriteLine("Next Activity : " + nextActivity.ActivityID + " - " + nextActivity.Description + " - StartPriority = " + Convert.ToString(nextActivity.StartPriority) + " EndPriority = " + Convert.ToString(nextActivity.EndPriority));

                    }
                    ret = true;
                }
            }
            else
            {
                ret = true;
            }

            return ret;
        }

        public void adjustSequence()
        {
            //nothing
        }

        public bool linking()
        {
            bool ret = false;

            if (resultNode.Count > 0)
            {
            }

            return ret;
        }

        protected string FindFlow(string str)
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

        protected bool VariableExist(string strVar, bool warnonly)
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

        protected ArrayList ConcatResult()
        {
            ArrayList ret = new ArrayList();

            Dictionary<string, Node>.Enumerator lpNode = resultNode.GetEnumerator();
            while (lpNode.MoveNext())
            {
                KeyValuePair<string, Node> item = lpNode.Current;
                ret.Add(item.Value.Value);
            }

            return ret;
        }

        protected bool IsNumber(string strVar)
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

        protected Node FindNodeByResult(string strResult)
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

        protected Node FindFirstNode()
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

        protected Node[] FindPreviousNodeByEntryNode(Node entry, bool stop)
        {
            Node[] ret = null;
            ArrayList aryNodes = new ArrayList();

            Dictionary<Node, Node>.Enumerator lpNode = Compiler.mapLink.GetEnumerator();
            while (lpNode.MoveNext())
            {
                KeyValuePair<Node, Node> item = lpNode.Current;

                if (item.Value.NodeID == entry.NodeID)
                {
                    aryNodes.Add(item.Key);
                    if (stop)
                    {
                        //ret = item.Key;
                        break;
                    }
                }
            }

            if (aryNodes.Count > 0)
            {
                ret = (Node[]) aryNodes.ToArray( typeof(Node) );
            }

            return ret;
        }

        protected IActivity FindActivityByEntry(Node entry)
        {
            IActivity lpRet = null;

            Dictionary<string, IActivity>.Enumerator lpAct = Compiler.mapActivity.GetEnumerator();
            while (lpAct.MoveNext())
            {
                KeyValuePair<string, IActivity> item = lpAct.Current;
                if (item.Value.Entry.NodeID == entry.NodeID)
                {
                    lpRet = item.Value;
                    break;
                }

            }

            return lpRet;
        }

        protected IActivity[] FindPreviousActivity(Node thisEntry, bool stop)
        {
            bool foundAct = false;
            IActivity[] act = null;
            Node[] nodes = FindPreviousNodeByEntryNode(thisEntry, stop);
            ArrayList lstActivity = new ArrayList();

            if (nodes != null)
            {
                if (nodes.Length == 1)
                {
                    Node node = nodes[0];
                    Dictionary<string, IActivity>.Enumerator lpAct = Compiler.mapActivity.GetEnumerator();
                    while (lpAct.MoveNext())
                    {
                        KeyValuePair<string, IActivity> item = lpAct.Current;
                        IActivity thisAct = item.Value;
                        Dictionary<string, Node>.Enumerator lpNode = thisAct.ResultNode.GetEnumerator();
                        while (lpNode.MoveNext())
                        {
                            KeyValuePair<string, Node> nodeItem = lpNode.Current;
                            Node thisNode = nodeItem.Value;

                            if (thisNode.NodeID == node.NodeID)
                            {
                                lstActivity.Add(thisAct);
                                if (stop)
                                {
                                    foundAct = true;
                                    break;
                                }
                            }
                        }
                        if (foundAct)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    foreach (Node nn in nodes)
                    {
                        Dictionary<string, IActivity>.Enumerator lpAct = Compiler.mapActivity.GetEnumerator();
                        while (lpAct.MoveNext())
                        {
                            KeyValuePair<string, IActivity> item = lpAct.Current;
                            IActivity thisAct = item.Value;
                            Dictionary<string, Node>.Enumerator lpNode = thisAct.ResultNode.GetEnumerator();
                            while (lpNode.MoveNext())
                            {
                                KeyValuePair<string, Node> nodeItem = lpNode.Current;
                                Node thisNode = nodeItem.Value;

                                if (thisNode.NodeID == nn.NodeID)
                                {
                                    lstActivity.Add(thisAct);
                                }
                            }
                        }

                    }
                }
            }

            if (lstActivity.Count > 0)
            {
                act = (IActivity[]) lstActivity.ToArray(typeof(IActivity));
            }

            return act;
        }

        protected Page ThisPage()
        {
            Page p = null;
            Dictionary<string, Page>.Enumerator lpPage = Compiler.mapPage.GetEnumerator();

            while (lpPage.MoveNext())
            {
                KeyValuePair<string, Page> itemPage = lpPage.Current;

                if (itemPage.Value.Activities.ContainsKey(this.ActivityID))
                {
                    p = itemPage.Value;
                    break;
                }
            }

            return p;
        }

        protected string FindExtension(IActivity act)
        {
            string strRet = "";
            Node entryNode = act.Entry;
            IActivity[] aryPrevAct = FindPreviousActivity(entryNode, false);
            
            if (aryPrevAct != null)
            {
                foreach (IActivity prevAct in aryPrevAct)
                {
                    if (strRet.Length > 0)
                    {
                        break;
                    }

                    if (prevAct.ActivityID == ActivityID)
                    {
                        return "";
                    }

                    if (prevAct.ActivityName.ToLower() == "start")
                    {
                        Node[] aryNode = FindPreviousNodeByEntryNode(entryNode, true);
                        Node prevNode = null;

                        if (aryNode != null)
                        {
                            if (aryNode.Length > 0)
                            {
                                prevNode = aryNode[0];
                                strRet = prevNode.Value;
                            }
                        }

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
            }


            return strRet;
        }
    }
}
