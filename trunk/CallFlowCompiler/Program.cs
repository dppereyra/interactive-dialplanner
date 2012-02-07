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
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Security.Cryptography;

namespace Interaction.Compiler
{
    class Compiler
    {
        public static Dictionary<string, Node> mapNode = new Dictionary<string, Node>();
        public static Dictionary<string, IActivity> mapActivity = new Dictionary<string, IActivity>();
        public static Dictionary<string, Page> mapPage = new Dictionary<string, Page>();
        public static Dictionary<Node, Node> mapLink = new Dictionary<Node, Node>();
        public static Dictionary<string, string> mapVar = new Dictionary<string, string>();

        string strProject = "";
        string strStartActivityID = "";
        public static string strExt = "";

        int j = 0;

        static int Main(string[] args)
        {
            string strIn = "";
            string strOut = "";
            int ret = -1;

            try
            {
                if (args.Length > 0)
                {
                    foreach (string _stRInfo in args)
                    {
                        PrintInfo("", _stRInfo);
                    }
                }


                if (args.Length == 1)
                {
                    strIn = args[0];
                    strOut = System.Environment.CurrentDirectory + "\\out.conf";
                }
                else if (args.Length == 2)
                {
                    strIn = args[0];
                    strOut = args[1];
                }
                else
                {
                    PrintError("Invalid arguments using ", "");
                    PrintError("CallFlowCompiler infile outfile", "");
                    PrintError("CompileEnd", "");
                    return ret;
                }

                Compiler compiler = new Compiler();
                if (compiler.compile(strIn, strOut))
                {
                    ret = 0;
                }
            }
            catch (Exception ex)
            {
            }

            PrintInfo("CompileEnd", "");
            return ret;
        }

        public bool compile(string strSource, string strDest)
        {
            bool successCompile = true;

            if(LoadDocument(strSource))
            {
                //Step one: compiling
                Dictionary<string, IActivity>.Enumerator lpAct = mapActivity.GetEnumerator();
                while (lpAct.MoveNext())
                {
                    KeyValuePair<string, IActivity> item = lpAct.Current;
                    if (!item.Value.compile())
                    {
                        successCompile = false;
                    }
                }

                //Step two: sequencing
                if (successCompile)
                {
                    Dictionary<string, Page>.Enumerator lpPage = mapPage.GetEnumerator();
                    while (lpPage.MoveNext())
                    {
                        KeyValuePair<string, Page> itemPage = lpPage.Current;

                        Dictionary<string, IActivity>.Enumerator lpActivity = itemPage.Value.Activities.GetEnumerator();
                        while (lpActivity.MoveNext())
                        {
                            KeyValuePair<string, IActivity> itemActivity = lpActivity.Current;

                            if (itemActivity.Value.ActivityID == itemPage.Value.EntryActivity.ActivityID)
                            {
                                itemActivity.Value.StartPriority = 1;
                                if (itemActivity.Value.sequence(0) == false)
                                {
                                    successCompile = false;
                                }
                                break;
                            }
                        }
                    }
                }

                //Step three: write to file
                if (successCompile)
                {

                    FileStream fs = null;
                    TextWriter w = null;


                    try
                    {
                        if (File.Exists(strDest))
                        {
                            fs = new FileStream(strDest, FileMode.Truncate);
                        }
                        else
                        {
                            fs = new FileStream(strDest, FileMode.Create);
                        }

                        w = new StreamWriter(fs);

                        Dictionary<string, Page>.Enumerator lpContext = mapPage.GetEnumerator();
                        while (lpContext.MoveNext())
                        {
                            KeyValuePair<string, Page> contextItem = lpContext.Current;

                            w.WriteLine("[" + contextItem.Value.FlowName.Replace(' ', '_') + "]");

                            Dictionary<string, IActivity>.Enumerator lpActivity = contextItem.Value.Activities.GetEnumerator();
                            while (lpActivity.MoveNext())
                            {
                                KeyValuePair<string, IActivity> itemActivity = lpActivity.Current;

                                //Find Start Activity for the page
                                if (itemActivity.Value.ActivityID == contextItem.Value.EntryActivity.ActivityID)
                                {
                                    foreach (InstructionSet set in itemActivity.Value.Instructions)
                                    {
                                        //Start activity with specific extension
                                        w.WriteLine(set.BuildInstruction());


                                        //find the same extension of the start activity and print the instruction
                                        ArrayList arrayInstructions = new ArrayList();
                                        Dictionary<string, IActivity>.Enumerator lpActivity2 = contextItem.Value.Activities.GetEnumerator();
                                        while (lpActivity2.MoveNext())
                                        {
                                            KeyValuePair<string, IActivity> itemActivity2 = lpActivity2.Current;

                                            if (itemActivity2.Value.ActivityID != contextItem.Value.EntryActivity.ActivityID)
                                            {
                                                foreach (InstructionSet set2 in itemActivity2.Value.Instructions)
                                                {
                                                    if(set2.ExtNumber == set.ExtNumber)
                                                    {
                                                        arrayInstructions.Add(set2);
                                                    }
                                                }
                                            }
                                        }

                                        if (arrayInstructions.Count > 0)
                                        {
                                            InstructionSet[] instructs = (InstructionSet[])arrayInstructions.ToArray(typeof(InstructionSet));

                                            Sort(instructs);

                                            foreach (InstructionSet set3 in instructs)
                                            {
                                                string strTmpInstruct = set3.BuildInstruction();
                                                if(strTmpInstruct.Trim().Length > 0)
                                                    w.WriteLine(strTmpInstruct);
                                                w.Flush();
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        w.Flush();
                        w.Close();
                        fs.Close();

                        w = null;
                        fs = null;

                    }
                    catch (Exception ex)
                    {
                        PrintError("Fatal error: " + ex.ToString() + " - Cannot compile", "");
                    }
                    finally
                    {
                        if (w != null)
                        {
                            w.Close();
                        }
                        if (fs != null)
                        {
                            fs.Close();
                        }
                    }

                    successCompile = true;
                }
                else
                {
                    PrintError("Cannot compile", "");
                    successCompile = false;
                }

            }

            return successCompile;
        }

        private void Sort(InstructionSet[] instr)
        {

            QuickSort(instr, 0, instr.Length - 1);

        }

        private void QuickSort(InstructionSet[] act, int left, int right)
        {
            if(left < right)
            {
                int i = left;
                int j = right + 1;

                while(true)
                {
                    while (i + 1 < act.Length && act[++i].Priority < act[left].Priority) ;
                    while (j - 1 > -1 && act[--j].Priority > act[left].Priority) ;  
                    if(i >= j) 
                        break; 
                    SWAP(act, i, j); 
                }
                SWAP(act, left, j); 

                QuickSort(act, left, j-1);
                QuickSort(act, j+1, right);
            }
        }

        private void SWAP(InstructionSet[] act, int i, int j)
        {
            InstructionSet t = act[i];
            act[i] = act[j];
            act[j] = t;
        }

        private static byte[] Decrypt(byte[] cipherData, byte[] Key, byte[] IV)
        {
            MemoryStream ms = new MemoryStream();

            Rijndael alg = Rijndael.Create();
            alg.Key = Key;
            alg.IV = IV;

            CryptoStream cs = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write);

            cs.Write(cipherData, 0, cipherData.Length);
            cs.Close();

            byte[] decryptedData = ms.ToArray();

            return decryptedData;
        }

        private static string Decrypt(string cipherText, string Password)
        {
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            byte[] bytSalt = System.Text.Encoding.ASCII.GetBytes("salt_denniswu");

            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, bytSalt);

            byte[] decryptedData = Decrypt(cipherBytes, pdb.GetBytes(32), pdb.GetBytes(16));

            return System.Text.Encoding.Unicode.GetString(decryptedData);
        }
 
        private IActivity FindActivityByEntry(Node entry)
        {
            IActivity lpRet = null;

            Dictionary<string, IActivity>.Enumerator lpAct = mapActivity.GetEnumerator();
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


        public bool LoadDocument(string strFile)
        {
            bool ret = false;

            try
            {

                XmlDocument doc = new XmlDocument();
                doc.Load(strFile);
                XPathNavigator nav = doc.CreateNavigator();

                XPathNodeIterator iterProject = nav.Select("/CallFlow");
                while (iterProject.MoveNext())
                {
                    strExt = iterProject.Current.GetAttribute("Extension", string.Empty);
                }

                XPathNodeIterator iterCallFlow = nav.Select("/CallFlow");
                while (iterCallFlow.MoveNext())
                {
                    strProject = iterCallFlow.Current.GetAttribute("Project", string.Empty);
                    strStartActivityID = iterCallFlow.Current.GetAttribute("Start", string.Empty);
                }

                XPathNodeIterator iterVar = nav.Select("/CallFlow/Variable");
                while (iterVar.MoveNext())
                {
                    string strVar = iterVar.Current.GetAttribute("val", string.Empty);
                    mapVar[strVar] = strVar;
                }

                XPathNodeIterator iterNode = nav.Select("/CallFlow/Node");
                while (iterNode.MoveNext())
                {
                    Node node = new Node();
                    node.NodeID = iterNode.Current.GetAttribute("id", string.Empty);
                    node.DocID = iterNode.Current.GetAttribute("docID", string.Empty);
                    node.Text = iterNode.Current.GetAttribute("LabelText", string.Empty);
                    node.Value = iterNode.Current.GetAttribute("NodeValue", string.Empty);

                    mapNode[node.NodeID] = node;
                }

                XPathNodeIterator iterLink = nav.Select("/CallFlow/Link");
                while (iterLink.MoveNext())
                {
                    string strKey = iterLink.Current.GetAttribute("key", string.Empty);
                    string strVal = iterLink.Current.GetAttribute("val", string.Empty);

                    mapLink[mapNode[strKey]] = mapNode[strVal];
                }

                XPathNodeIterator iterActivity = nav.Select("/CallFlow/Activity");
                while (iterActivity.MoveNext())
                {
                    IActivity activity = ActivityCreator.Instance.CreateInstance(iterActivity.Current.GetAttribute("activityName", string.Empty));

                    if (activity != null)
                    {
                        activity.ActivityID = iterActivity.Current.GetAttribute("activityID", string.Empty);
                        activity.ActivityName = iterActivity.Current.GetAttribute("activityName", string.Empty);
                        activity.Value = iterActivity.Current.GetAttribute("activityValue", string.Empty);
                        activity.Description = iterActivity.Current.GetAttribute("activityDesc", string.Empty);
                        activity.DocID = iterActivity.Current.GetAttribute("docID", string.Empty);

                        XPathNodeIterator subNodes = nav.Select("/CallFlow/Activity[@activityID='" + activity.ActivityID + "']/EntryNode");
                        while (subNodes.MoveNext())
                        {
                            string strTmpNodeID = subNodes.Current.GetAttribute("id", string.Empty);
                            activity.Entry = mapNode[strTmpNodeID];
                        }

                        subNodes = nav.Select("/CallFlow/Activity[@activityID='" + activity.ActivityID + "']/Node");
                        while (subNodes.MoveNext())
                        {
                            string strTmpNodeID = subNodes.Current.GetAttribute("id", string.Empty);
                            activity.ResultNode.Add(mapNode[strTmpNodeID].NodeID, mapNode[strTmpNodeID]);
                        }

                        subNodes = nav.Select("/CallFlow/Activity[@activityID='" + activity.ActivityID + "']/PrimaryNode");
                        while (subNodes.MoveNext())
                        {
                            string strTmpNodeID = subNodes.Current.GetAttribute("id", string.Empty);
                            activity.PrimaryNode = mapNode[strTmpNodeID];
                        }

                        subNodes = nav.Select("/CallFlow/Activity[@activityID='" + activity.ActivityID + "']/Attrs");
                        while (subNodes.MoveNext())
                        {
                            string strAttrKey = subNodes.Current.GetAttribute("key", string.Empty);
                            activity.Attribute[strAttrKey] = subNodes.Current.GetAttribute("val", string.Empty);
                        }

                        mapActivity[activity.ActivityID] = activity;
                    }
                    else
                    {
                        ret = false;
                        return ret;
                    }
                }

                XPathNodeIterator iterPage = nav.Select("/CallFlow/Page");
                while (iterPage.MoveNext())
                {
                    Page page = new Page();

                    page.FlowName = iterPage.Current.GetAttribute("flowName", string.Empty);
                    page.DocID = iterPage.Current.GetAttribute("docID", string.Empty);
                    page.EntryActivity = mapActivity[iterPage.Current.GetAttribute("entry", string.Empty)];

                    Dictionary<string, IActivity>.Enumerator lpActivity = mapActivity.GetEnumerator();
                    while (lpActivity.MoveNext())
                    {
                        KeyValuePair<string, IActivity> itemActivity = lpActivity.Current;

                        if (itemActivity.Value.DocID == page.DocID)
                        {
                            page.Activities.Add(itemActivity.Key, itemActivity.Value);
                        }
                    }
                    mapPage[page.DocID] = page;
                }

                ret = true;
            }
            catch (Exception ex)
            {
                ret = false;
            }

            return ret;
        }

        public static void PrintInfo(string str, string num)
        {
            Console.Out.WriteLine("Info: " + num + " " + str);
        }

        public static void PrintWarn(string str, string num)
        {
            Console.Out.WriteLine("Warning: " + num + " " + str);
        }
        
        public static void PrintError(string str, string num)
        {
            Console.Out.WriteLine("Error: " + num + " " + str);
        }
    }
}
