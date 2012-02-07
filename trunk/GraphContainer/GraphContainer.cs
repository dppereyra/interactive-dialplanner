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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using System.Xml;
using System.Xml.XPath;
using System.IO;
using System.Security.Cryptography;
using Interaction.Graph;

namespace Interaction.Graph
{
    public class GraphContainer
    {
        private static GraphContainer _self = null;

        private bool lv1_mdown = false;
        private bool var_mdown = false;

        private string strProject = "";
        private string strDesc = "";
        private string strVersion = "";
        private string strExtension = "";
        private string strHost = "";
        private string strPort = "22";
        private string strPath = "";
        private string strCmd = "";
        private string strUserName = "";
        private string strPwd = "";
        private bool remoteConnection = false;

        private Dictionary<string, Page> mapPage = new Dictionary<string, Page>();
        private ArrayList activitiess = new ArrayList();
        private Dictionary<string, Node> mapNodes = new Dictionary<string, Node>();
        private Dictionary<Node, Node> mapNodeRelationship = new Dictionary<Node, Node>();
        private ArrayList squareSelections = new ArrayList();
        private IActivity startActivity = null;
        private ArrayList variableList = new ArrayList();
        private ArrayList sysVariableList = new ArrayList();
        private System.Windows.Forms.PropertyGrid propertyGrid = null;
        private MemoryStream ms = null;

        private string strTmpTick;

        private GraphContainer()
        {
            sysVariableList.Add("CDR(accountcode)");
            sysVariableList.Add("ANSWEREDTIME");
            sysVariableList.Add("BLINDTRANSFER");
            sysVariableList.Add("CALLERID(all)");
            sysVariableList.Add("CALLERID(name)");
            sysVariableList.Add("CALLERID(num)");
            sysVariableList.Add("CALLINGPRES");
            sysVariableList.Add("CHANNEL");
            sysVariableList.Add("CONTEXT");
            sysVariableList.Add("STRFTIME(${EPOCH},,%d%mNaVH:NaVS)");
            sysVariableList.Add("DIALEDPEERNAME");
            sysVariableList.Add("DIALEDPEERNUMBER");
            sysVariableList.Add("DIALEDTIME");
            sysVariableList.Add("DIALSTATUS");
            sysVariableList.Add("DNID");
            sysVariableList.Add("EPOCH");
            sysVariableList.Add("EXTEN");
            sysVariableList.Add("HANGUPCAUSE");
            sysVariableList.Add("INVALID_EXTEN");
            sysVariableList.Add("LANGUAGE");
            sysVariableList.Add("MEETMESECS");
            sysVariableList.Add("PRIORITY");
            sysVariableList.Add("RDNIS");
            sysVariableList.Add("SIPDOMAIN");
            sysVariableList.Add("SIP_CODEC");
            sysVariableList.Add("SIPCALLID");
            sysVariableList.Add("SIPUSERAGENT");
            sysVariableList.Add("STRFTIME(${EPOCH},,%Y%m%d-%H%M%S)");
            sysVariableList.Add("TRANSFERCAPABILITY");
            sysVariableList.Add("TXTCIDNAME");
            sysVariableList.Add("UNIQUEID");
            sysVariableList.Add("TOUCH_MONITOR");
            sysVariableList.Add("TOUCH_MONITOR_PREFIX");

            sysVariableList.Add("AGENTBYCALLERID_${CALLERID}");
            sysVariableList.Add("AVAILCHAN");
            sysVariableList.Add("VXML_URL");
            sysVariableList.Add("ALERT_INFO");
            sysVariableList.Add("CAUSECODE");
            sysVariableList.Add("TRANSFER_CONTEXT");
            sysVariableList.Add("ENUM");
            sysVariableList.Add("PRI_CAUSE");
            sysVariableList.Add("MEETME_AGI_BACKGROUND");
            sysVariableList.Add("PLAYBACKSTATUS");
            sysVariableList.Add("QUEUESTATUS");
            sysVariableList.Add("VMSTATUS");
            sysVariableList.Add("MACRO_CONTEXT");
            sysVariableList.Add("MACRO_EXTEN");
            sysVariableList.Add("MACRO_OFFSET");
            sysVariableList.Add("MACRO_PRIORITY");
            sysVariableList.Add("REASON");
            sysVariableList.Add("ENV(RECORDED_FILE)");

            sysVariableList.Sort();
        }

        public string Tick
        {
            get
            {
                return strTmpTick;
            }

            set
            {
                strTmpTick = value;

            }
        }

        public PropertyGrid PropertyGridObject
        {
            get
            {
                return propertyGrid;
            }

            set
            {
                propertyGrid = value;
            }
        }

        public static GraphContainer Instance
        {
            get
            {
                if (_self == null)
                {
                    _self = new GraphContainer();
                }

                return _self;
            }
        }

        public string Extension
        {
            get
            {
                return strExtension;
            }

            set
            {
                strExtension = value;
            }
        }

        public string Project
        {
            get
            {
                return strProject;
            }

            set
            {
                strProject = value;
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

        public string Version
        {
            get
            {
                return strVersion;
            }

            set
            {
                strVersion = value;
            }
        }

        public string Host
        {
            get
            {
                return strHost;
            }

            set
            {
                strHost = value;
            }
        }

        public string Port
        {
            get
            {
                return strPort;
            }

            set
            {
                strPort = value;
            }
        }

        public string Path
        {
            get
            {
                return strPath;
            }

            set
            {
                strPath = value;
            }
        }

        public string Command
        {
            get
            {
                return strCmd;
            }

            set
            {
                strCmd = value;
            }
        }

        public bool RemoteConnection
        {
            get
            {
                return remoteConnection;
            }

            set
            {
                remoteConnection = value;
            }

        }



        public IActivity StartActivity
        {
            get
            {
                return startActivity;
            }

            set
            {
                startActivity = value;
            }
        }

        public IActivity FindActivity(string ID)
        {
            IActivity ret = null ;
            foreach (IActivity act in activitiess)
            {
                if (act.ActivityID == ID)
                {
                    ret = act;
                    break;
                }
            }

            return ret;
        }

        public bool FindDuplicateActivity(string ID, string strName)
        {
            bool ret = false;

            if (strName.Trim().Length > 0)
            {
                foreach (IActivity act in activitiess)
                {
                    if (act.ActivityID != ID)
                    {
                        if (act.ActivityName.Trim().ToLower() == strName.Trim().ToLower())
                        {
                            ret = true;
                            break;
                        }
                    }
                }
            }
            return ret;
        }

        public bool FindDuplicateActivityDescription(string ID, string strDescription)
        {
            bool ret = false;

            if (strDescription.Trim().Length > 0)
            {
                foreach (IActivity act in activitiess)
                {
                    if (act.ActivityID != ID)
                    {
                        if (act.Description.Trim().ToLower() == strDescription.Trim().ToLower())
                        {
                            ret = true;
                            break;
                        }
                    }
                }
            }
            return ret;
        }

        public Node FindNodeByLabel(Label lbl)
        {
            Dictionary<string, Node>.Enumerator lpNode = mapNodes.GetEnumerator();
            Node ret = null;

            while (lpNode.MoveNext())
            {
                KeyValuePair<string, Node> item = lpNode.Current;
                if (item.Value.Label == lbl)
                {
                    ret = item.Value;
                    break;
                }
            }

            return ret;
        }

        public Page GetPage(string strID)
        {
            return mapPage[strID];
        }

        public void DeletePage(string strID)
        {
            if (mapPage.ContainsKey(strID))
                mapPage.Remove(strID);
        }

        public void AddPage(string strID, Page p)
        {
            mapPage[strID] = p;
        }

        public Dictionary<string, Page> Pages
        {
            get
            {
                return mapPage;
            }
        }

        public ArrayList Activities
        {
            get
            {
                return activitiess;
            }
        }

        public Dictionary<string, Node> Nodes
        {
            get
            {
                return mapNodes;
            }
        }

        public Dictionary<Node, Node> NodeRelationship
        {
            get
            {
                return mapNodeRelationship;
            }
        }

        public ArrayList ActivitySelections
        {
            get
            {
                return squareSelections;
            }
        }

        public bool VariableMouseDown
        {
            get
            {
                return var_mdown;
            }

            set
            {
                var_mdown = value;
            }
        }

        public bool ToolBoxMouseDown
        {
            get
            {
                return lv1_mdown;
            }

            set
            {
                lv1_mdown = value;
            }
        }

        public ArrayList Variable
        {
            get
            {
                return variableList;
            }
        }

        public ArrayList SysVariable
        {
            get
            {
                return sysVariableList;
            }
        }

        public IActivity GetFarObjectX(string strDocID)
        {
            IActivity ret = null;
            
            try
            {
                foreach (IActivity act in activitiess)
                {
                    if (act.DocID == strDocID)
                    {
                        if (ret == null)
                        {
                            ret = act;
                        }
                        else
                        {
                            if (act.Position.X > ret.Position.X)
                            {
                                ret = act;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ret = null;
            }

            return ret;
        }

        public IActivity GetFarObjectY(string strDocID)
        {
            IActivity ret = null;

            try
            {
                foreach (IActivity act in activitiess)
                {
                    if (act.DocID == strDocID)
                    {
                        if (ret == null)
                        {
                            ret = act;
                        }
                        else
                        {
                            if (act.Position.Y > ret.Position.Y)
                            {
                                ret = act;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ret = null;
            }

            return ret;
        }

        public Node CreateNode(IDrawingBoard board, IGraphEvent lpThis, string strNodeName, string strNodeText, bool allowDrop, bool allowDraw)
        {
            Label l = new Label();
            l.Tag = strNodeName;
            Node node = new Node(l, lpThis, allowDrop, allowDraw);
            node.Text = strNodeText;
            return node;
        }

        /*
        <Page id="" pageName="" docID="" entry="" />

        <Activity activityID="" activityName="" activityValue="" x="" y="" width="" height="" docID="">
            <EntryNode id="" />
            <Node id="" />
            <Node id="" />
            <Node id="" />
            <Node id="" />
            <Node id="" />
        </Activity>

        <Node id="" docID="" lineNodeX="" lineNodeY="" allowDrop="" allowDraw="" LabelText="" />
        <Link key="" val="" />

         * 
         * 
         * 
            MemoryStream ms = new MemoryStream();
            TextWriter w = new StreamWriter(ms);
            TextReader r = new StreamReader(ms);

            w.WriteLine("12345");
            w.WriteLine("67890");
            w.Flush();

            ms.Seek(0, SeekOrigin.Begin);


            string r1 = r.ReadLine();
            string r2 = r.ReadLine();
         * 
        */

        /*
        public bool SaveFile(string strFile)
        {
            bool ret = false;
            FileStream fs = null;
            XmlTextWriter w = null;
            
            try
            {
                if (File.Exists(strFile))
                {
                    fs = new FileStream(strFile, FileMode.Truncate);
                }
                else
                {
                    fs = new FileStream(strFile, FileMode.CreateNew);
                }
                w = new XmlTextWriter(fs, Encoding.UTF8);

                w.WriteStartDocument();
                w.WriteStartElement("CallFlow");
                w.WriteAttributeString("Project", strProject);
                w.WriteAttributeString("Description", strDesc);
                w.WriteAttributeString("Version", strVersion);
                w.WriteAttributeString("Extension", strExtension);

                w.WriteAttributeString("Start", startActivity.ActivityID);

                //Page
                Dictionary<string, Page>.Enumerator pEnum = mapPage.GetEnumerator();
                while (pEnum.MoveNext())
                {
                    KeyValuePair<string, Page> val = pEnum.Current;
                    w.WriteStartElement("Page");
                    w.WriteAttributeString("flowName", val.Value.FlowName);
                    w.WriteAttributeString("docID", val.Value.DocID);
                    w.WriteAttributeString("entry", val.Value.Entry.ActivityID);
                    w.WriteEndElement();
                }

                //Activities
                foreach (IActivity activity in activitiess)
                {
                    w.WriteStartElement("Activity");
                    w.WriteAttributeString("activityID", activity.ActivityID);
                    w.WriteAttributeString("activityName", activity.ActivityName);
                    w.WriteAttributeString("activityValue", activity.ActivityValue);
                    w.WriteAttributeString("activityDesc", activity.Description);
                    w.WriteAttributeString("x", Convert.ToString(activity.Position.X));
                    w.WriteAttributeString("y", Convert.ToString(activity.Position.Y));
                    w.WriteAttributeString("width", Convert.ToString(activity.Width));
                    w.WriteAttributeString("height", Convert.ToString(activity.Height));
                    w.WriteAttributeString("docID", activity.DocID);

                    w.WriteStartElement("EntryNode");
                    w.WriteAttributeString("id", activity.EntryNode.NodeName);
                    w.WriteEndElement(); //EntryNode

                    if (activity.PrimaryNode != null)
                    {
                        w.WriteStartElement("PrimaryNode");
                        w.WriteAttributeString("id", activity.PrimaryNode.NodeName);
                        w.WriteEndElement(); //PrimaryNode
                    }

                    //Node in activity
                    foreach (Node n in activity.Nodes)
                    {
                        w.WriteStartElement("Node");
                        w.WriteAttributeString("id", n.NodeName);
                        w.WriteEndElement(); //Node
                    }

                    Dictionary<string, string>.Enumerator pValues = activity.Values().GetEnumerator();

                    while (pValues.MoveNext())
                    {
                        KeyValuePair<string, string> val = pValues.Current;

                        w.WriteStartElement("Attrs");
                        w.WriteAttributeString("key", val.Key);
                        w.WriteAttributeString("val", val.Value);
                        w.WriteEndElement();
                    }

                    w.WriteEndElement(); //Activity
                }

                //Node
                Dictionary<string, Node>.Enumerator pNode = mapNodes.GetEnumerator();
                while (pNode.MoveNext())
                {
                    KeyValuePair<string, Node> val = pNode.Current;

                    w.WriteStartElement("Node");
                    w.WriteAttributeString("id", val.Value.NodeName);
                    w.WriteAttributeString("docID", val.Value.DocID);
                    w.WriteAttributeString("lineNodeX", Convert.ToString(val.Value.Label.Location.X));
                    w.WriteAttributeString("lineNodeY", Convert.ToString(val.Value.Label.Location.Y));
                    w.WriteAttributeString("allowDrop", Convert.ToString(val.Value.AllowDrop));
                    w.WriteAttributeString("allowDraw", Convert.ToString(val.Value.AllowDraw));
                    w.WriteAttributeString("LabelText", val.Value.Text);
                    w.WriteAttributeString("NodeValue", val.Value.NodeValue);
                    w.WriteEndElement();
                }

                //Link
                Dictionary<Node, Node>.Enumerator pNodes = mapNodeRelationship.GetEnumerator();
                while (pNodes.MoveNext())
                {
                    KeyValuePair<Node, Node> val = pNodes.Current;

                    w.WriteStartElement("Link");
                    w.WriteAttributeString("key", val.Key.NodeName);
                    w.WriteAttributeString("val", val.Value.NodeName);
                    w.WriteEndElement();
                }

                foreach (string strVar in variableList)
                {
                    w.WriteStartElement("Variable");
                    w.WriteAttributeString("val", strVar);
                    w.WriteEndElement();
                }

                w.WriteEndElement(); //Call Flow
                w.WriteEndDocument();
                
                w.Flush();
                w.Close();
                
                w = null;
                
                fs.Close();
                fs = null;

                ret = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (w != null)
                    w.Close();

                if (fs != null)
                    fs.Close();
            }

            return ret;
        }
        */

        public bool SaveFile(string strFile)
        {
            bool ret = false;
            XmlTextWriter w = null;

            try
            {
                ms = new MemoryStream();
                w = new XmlTextWriter(ms, Encoding.UTF8);

                w.WriteStartDocument();
                w.WriteStartElement("CallFlow");
                w.WriteAttributeString("Project", strProject);
                w.WriteAttributeString("Description", strDesc);
                w.WriteAttributeString("Version", strVersion);
                w.WriteAttributeString("Extension", strExtension);
                w.WriteAttributeString("Host", strHost);
                w.WriteAttributeString("Port", strPort);
                w.WriteAttributeString("Path", strPath);
                w.WriteAttributeString("Command", strCmd);
                w.WriteAttributeString("UserName", strUserName);
                w.WriteAttributeString("Password", strPwd);
                w.WriteAttributeString("RemoteConnection", Convert.ToString(remoteConnection));
                if (startActivity != null)
                {
                    w.WriteAttributeString("Start", startActivity.ActivityID);
                }
                else
                {
                    w.WriteAttributeString("Start", "");
                }


                //Page
                Dictionary<string, Page>.Enumerator pEnum = mapPage.GetEnumerator();
                while (pEnum.MoveNext())
                {
                    KeyValuePair<string, Page> val = pEnum.Current;
                    w.WriteStartElement("Page");
                    w.WriteAttributeString("flowName", val.Value.FlowName);
                    w.WriteAttributeString("docID", val.Value.DocID);
                    w.WriteAttributeString("entry", val.Value.Entry.ActivityID);
                    w.WriteEndElement();
                }

                //Activities
                foreach (IActivity activity in activitiess)
                {
                    w.WriteStartElement("Activity");
                    w.WriteAttributeString("activityID", activity.ActivityID);
                    w.WriteAttributeString("activityName", activity.ActivityName);
                    w.WriteAttributeString("activityValue", activity.ActivityValue);
                    w.WriteAttributeString("activityDesc", activity.Description);
                    w.WriteAttributeString("x", Convert.ToString(activity.Position.X));
                    w.WriteAttributeString("y", Convert.ToString(activity.Position.Y));
                    w.WriteAttributeString("width", Convert.ToString(activity.Width));
                    w.WriteAttributeString("height", Convert.ToString(activity.Height));
                    w.WriteAttributeString("docID", activity.DocID);

                    w.WriteStartElement("EntryNode");
                    w.WriteAttributeString("id", activity.EntryNode.NodeName);
                    w.WriteEndElement(); //EntryNode

                    if (activity.PrimaryNode != null)
                    {
                        w.WriteStartElement("PrimaryNode");
                        w.WriteAttributeString("id", activity.PrimaryNode.NodeName);
                        w.WriteEndElement(); //PrimaryNode
                    }

                    //Node in activity
                    foreach (Node n in activity.Nodes)
                    {
                        w.WriteStartElement("Node");
                        w.WriteAttributeString("id", n.NodeName);
                        w.WriteEndElement(); //Node
                    }

                    Dictionary<string, string>.Enumerator pValues = activity.Values().GetEnumerator();

                    while (pValues.MoveNext())
                    {
                        KeyValuePair<string, string> val = pValues.Current;

                        w.WriteStartElement("Attrs");
                        w.WriteAttributeString("key", val.Key);
                        w.WriteAttributeString("val", val.Value);
                        w.WriteEndElement();
                    }

                    w.WriteEndElement(); //Activity
                }

                //Node
                Dictionary<string, Node>.Enumerator pNode = mapNodes.GetEnumerator();
                while (pNode.MoveNext())
                {
                    KeyValuePair<string, Node> val = pNode.Current;

                    w.WriteStartElement("Node");
                    w.WriteAttributeString("id", val.Value.NodeName);
                    w.WriteAttributeString("docID", val.Value.DocID);
                    w.WriteAttributeString("lineNodeX", Convert.ToString(val.Value.Label.Location.X));
                    w.WriteAttributeString("lineNodeY", Convert.ToString(val.Value.Label.Location.Y));
                    w.WriteAttributeString("allowDrop", Convert.ToString(val.Value.AllowDrop));
                    w.WriteAttributeString("allowDraw", Convert.ToString(val.Value.AllowDraw));
                    w.WriteAttributeString("LabelText", val.Value.Text);
                    w.WriteAttributeString("NodeValue", val.Value.NodeValue);
                    w.WriteEndElement();
                }

                //Link
                Dictionary<Node, Node>.Enumerator pNodes = mapNodeRelationship.GetEnumerator();
                while (pNodes.MoveNext())
                {
                    KeyValuePair<Node, Node> val = pNodes.Current;

                    w.WriteStartElement("Link");
                    w.WriteAttributeString("key", val.Key.NodeName);
                    w.WriteAttributeString("val", val.Value.NodeName);
                    w.WriteEndElement();
                }

                foreach (string strVar in variableList)
                {
                    w.WriteStartElement("Variable");
                    w.WriteAttributeString("val", strVar);
                    w.WriteEndElement();
                }

                w.WriteEndElement(); //Call Flow
                w.WriteEndDocument();

                w.Flush();

                ret = SaveFileImp(strFile);

                w.Close();
                w = null;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (w != null)
                    w.Close();

                if (ms != null)
                    ms.Close();

                ms = null;
            }

            return ret;
        }

        private bool SaveFileImp(string strFile)
        {
            bool ret = false;
            FileStream fs = null;
            TextWriter w = null;
            StreamReader memrdr = null;

            try
            {
                if (File.Exists(strFile))
                {
                    fs = new FileStream(strFile, FileMode.Truncate);
                }
                else
                {
                    fs = new FileStream(strFile, FileMode.CreateNew);
                }

                w = new StreamWriter(fs);

                if (ms != null)
                {
                    ms.Seek(0, SeekOrigin.Begin);
                    memrdr = new StreamReader(ms);

                    string str = memrdr.ReadLine();
                    while (str != null)
                    {
                        w.WriteLine(str);
                        str = memrdr.ReadLine();
                    }

                    memrdr.Close();
                    memrdr = null;
                }

                w.Flush();
                w.Close();
                w = null;

                fs.Close();
                fs = null;

                ret = true;
            }
            catch (Exception ex)
            {
                if (memrdr != null)
                    memrdr.Close();

                if (w != null)
                    w.Close();

                if (fs != null)
                    fs.Close();
            }

            return ret;
        }

        public void MaintainVariable()
        {
            Form frm = IsFormAlreadyOpen(typeof(frmVariable));
            if (frm == null)
            {
                frmVariable frmVar = new frmVariable();
                frmVar.BringToFront();
                frmVar.TopMost = true;
                frmVar.Show();
            }
            else
            {
                frm.BringToFront();
            }
        }

        public void CloseMaintainVariable()
        {
            Form frm = IsFormAlreadyOpen(typeof(frmVariable));
            if (frm == null)
            {
            }
            else
            {
                frm.Close();
            }
        }

        private Form IsFormAlreadyOpen(Type FormType)
        {
            foreach (Form OpenForm in Application.OpenForms)
            {
                if (OpenForm.GetType() == FormType)
                    return OpenForm;
            }

            return null;
        }

        public void Clear()
        {
            variableList.Clear();
            startActivity = null;
            squareSelections.Clear();
            mapNodes.Clear();
            mapNodeRelationship.Clear();
            activitiess.Clear();
            mapPage.Clear();

            strProject = "";
            strDesc = "";
            strVersion = "";
            strExtension = "";
            strHost = "";
            strPort = "22";
            strPath = "";
            strCmd = "";
            strUserName = "";
            strPwd = "";
            remoteConnection = false;
        }

        public string UserName
        {
            get
            {
                return strUserName;
            }

            set
            {
                strUserName = value;
            }
        }

        public string Password
        {
            get
            {
                return strPwd;
            }

            set
            {
                strPwd = value;
            }
        }

        public void RemovePage(string strDocID)
        {
            ArrayList tmpAct = new ArrayList();
            
            foreach (IActivity activity in activitiess)
            {
                if (activity.DocID == strDocID)
                {
                    tmpAct.Add(activity);
                }
            }
            foreach (IActivity activity in tmpAct)
            {
                activitiess.Remove(activity);
            }

            tmpAct = new ArrayList();
            Dictionary<string, Node>.Enumerator lpNode = mapNodes.GetEnumerator();
            while (lpNode.MoveNext())
            {
                KeyValuePair<string, Node> item = lpNode.Current;
                if (item.Value.DocID == strDocID)
                {
                    tmpAct.Add(item.Value);
                }
            }
            foreach (Node node in tmpAct)
            {
                mapNodes.Remove(node.NodeName);
                mapNodeRelationship.Remove(node);
            }

            if (startActivity != null)
            {
                if (startActivity.DocID == strDocID)
                {
                    startActivity = null;
                }
            }

            mapPage.Remove(strDocID);
        }

        private static byte[] Encrypt(byte[] clearData, byte[] Key, byte[] IV)
        {
            byte[] encryptedData = null;

            MemoryStream ms = new MemoryStream();

            Rijndael alg = Rijndael.Create();

            alg.Key = Key;
            alg.IV = IV;

            CryptoStream cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(clearData, 0, clearData.Length);
            cs.Close();

            encryptedData = ms.ToArray();

            return encryptedData;
        }

        private static string Encrypt(string clearText, string Password)
        {
            byte[] encryptedData = null;

            byte[] clearBytes = System.Text.Encoding.Unicode.GetBytes(clearText);
            byte[] bytSalt = System.Text.Encoding.ASCII.GetBytes("salt_denniswu");

            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, bytSalt);

            encryptedData = Encrypt(clearBytes, pdb.GetBytes(32), pdb.GetBytes(16));

            return Convert.ToBase64String(encryptedData);
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

    }
}
