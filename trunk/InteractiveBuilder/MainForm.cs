/******************************************************************************************
 * The MIT License (MIT)
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
using System.Drawing;
using System.Drawing.Printing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Text;
using System.Xml.XPath;
using System.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Diagnostics;
using System.Threading;
using WeifenLuo.WinFormsUI.Docking;
using DennisWuWorks.InteractiveBuilder.Customization;
using Interaction.Graph;
using Tamir.SharpSsh;

namespace DennisWuWorks.InteractiveBuilder
{
    public partial class MainForm : Form
    {
        private bool m_bSaveLayout = true;
        private string strOpenFileName = "";
        private string strOpenFileFullName = "";
        private static MainForm _self = null;
        private DeserializeDockContent m_deserializeDockContent;
        private frmSolutionExplorer m_solutionExplorer = new frmSolutionExplorer();
        private frmPropertyWindow m_propertyWindow = new frmPropertyWindow();
        private frmToolbox m_toolbox = new frmToolbox();
        private frmOutputWindow m_outputWindow = new frmOutputWindow();
        private frmTaskList m_taskList = new frmTaskList();
        private AppState stateApp = AppState.Idle;
        private ThreadStart compileJob = null;
        private Thread compileThread = null;
        private Object padLock = new Object();
        private bool stopCompile = false;
        private ManualResetEvent[] compileFinishEvent = new ManualResetEvent[1];
        private PrintDocument pd = new PrintDocument();
        private PrintPageEventHandler printPageEventHandler;
        private PrintEventHandler beginPrintEventHandler;
        private PrintEventHandler endPrintEventHandler;

        private int currentPageCnt = 0;

        delegate void ChangeCursorCallback(Cursor c);
        delegate void EnabledCallback(bool c);

        //private string strPubKey = "<RSAKeyValue><Modulus>ji+v2TfBq56N+egZfIYocBiCdmymgFI2+FQukwG996kHluPacWaL71xZZJsxKhRT2fDdS8qN1D60rkqFZ37TwcPh8r+8MDSkauCmk9jig7GJ+hTDsZUJxb0ZBYw8WwU+uw8t682n2dAIEprXUTEggMzoVPcPJYAWmDkbo1lFUmU=</Modulus><Exponent>EQ==</Exponent></RSAKeyValue>";



        public MainForm()
        {
            InitializeComponent();
            MainForm._self = this;

            //showRightToLeft.Checked = (RightToLeft == RightToLeft.Yes);
            //RightToLeftLayout = showRightToLeft.Checked;
            m_solutionExplorer = new frmSolutionExplorer();
            m_solutionExplorer.RightToLeftLayout = RightToLeftLayout;
            m_deserializeDockContent = new DeserializeDockContent(GetContentFromPersistString);
            //ActivityCreator.Instance.LoadActivity();
            stateApp = AppState.Idle;
            toolBar.Visible = true;
            statusBar.Visible = true;

            printPageEventHandler = new PrintPageEventHandler(printDocument_PrintPage);
            beginPrintEventHandler = new PrintEventHandler(pd_BeginPrint);
            endPrintEventHandler = new PrintEventHandler(pd_EndPrint);

            pd.PrintPage += printPageEventHandler;
            pd.BeginPrint += beginPrintEventHandler;
            pd.EndPrint += endPrintEventHandler;


        
        }

        public void SelectNode(string strDocID)
        {
            m_solutionExplorer.SelectNode(strDocID);
        }

        public void ChangeCursor(Cursor c)
        {
            ChangeCursorCallback d = new ChangeCursorCallback(InternalChangeCursor);
            this.Invoke(d, new object[] { c });
        }

        private void InternalChangeCursor(Cursor  c)
        {
            this.Cursor = c;
        }

        public void EnabledWindow(bool c)
        {
            EnabledCallback d = new EnabledCallback(InternalEnabled);
            this.Invoke(d, new object[] { c });
        }

        private void InternalEnabled(bool c)
        {
            if (c)
            {
                this.Enabled = true;
            }
            else
            {
                this.Enabled = false;
            }
        }

        public bool StopCompile
        {
            get
            {
                lock (padLock)
                {
                    return stopCompile;

                }
            }

            set
            {
                lock (padLock)
                {
                    stopCompile = value;
                }
            }
        }

        public static MainForm Instance
        {
            get
            {
                return _self;
            }
        }

        #region Methods


        private IDockContent FindDocument(string text)
        {
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                foreach (Form form in MdiChildren)
                    if (form.Text == text)
                        return form as IDockContent;

                return null;
            }
            else
            {
                foreach (IDockContent content in dockPanel.Documents)
                    if (content.DockHandler.TabText == text)
                        return content;

                return null;
            }
        }


        private GraphDoc CreateNewDocument()
        {
            GraphDoc dummyDoc = new GraphDoc();

            int count = 1;
            string text = "Document" + count.ToString();
            while (FindDocument(text) != null)
            {
                count++;
                text = "Document" + count.ToString();
            }
            dummyDoc.Text = text;
            return dummyDoc;
        }

        private GraphDoc CreateNewDocument(string text)
        {
            GraphDoc dummyDoc = new GraphDoc();
            dummyDoc.Text = text;
            return dummyDoc;
        }


        private void CloseAllDocuments()
        {
            foreach (Form form in MdiChildren)
            {
                Type type = form.GetType();
                if (type.Name.ToUpper() == "GraphDoc".ToUpper())
                {
                    ((GraphDoc)form).IsClose = true;
                    form.Close();
                }
            }
            GraphContainer.Instance.Clear();
            stateApp = AppState.Idle;
            ChangeAppState();

            m_propertyWindow.ClearActivity();
        }

        private IDockContent GetContentFromPersistString(string persistString)
        {
            if (persistString == typeof(frmSolutionExplorer).ToString())
                return m_solutionExplorer;
            else if (persistString == typeof(frmPropertyWindow).ToString())
                return m_propertyWindow;
            else if (persistString == typeof(frmToolbox).ToString())
                return m_toolbox;
            else if (persistString == typeof(frmOutputWindow).ToString())
                return m_outputWindow;
            else if (persistString == typeof(frmTaskList).ToString())
                return m_taskList;
            else
            {
                return null;
            }
        }

        private void CloseAllContents()
        {
            // we don't want to create another instance of tool window, set DockPanel to null
            m_solutionExplorer.DockPanel = null;
            m_propertyWindow.DockPanel = null;
            m_toolbox.DockPanel = null;
            m_outputWindow.DockPanel = null;
            m_taskList.DockPanel = null;

            // Close all other document windows
            CloseAllDocuments();
        }

        private void SetSchema(object sender, System.EventArgs e)
        {
            CloseAllContents();

            Extender.SetSchema(dockPanel, Extender.Schema.VS2005);

        }

        private void SetDocumentStyle(object sender, System.EventArgs e)
        {
            DocumentStyle oldStyle = dockPanel.DocumentStyle;
            DocumentStyle newStyle;

            newStyle = DocumentStyle.DockingMdi;
            /*
            if (sender == menuItemDockingMdi)
                newStyle = DocumentStyle.DockingMdi;
            else if (sender == menuItemDockingWindow)
                newStyle = DocumentStyle.DockingWindow;
            else if (sender == menuItemDockingSdi)
                newStyle = DocumentStyle.DockingSdi;
            else
                newStyle = DocumentStyle.SystemMdi;
            */

            if (oldStyle == newStyle)
                return;

            if (oldStyle == DocumentStyle.SystemMdi || newStyle == DocumentStyle.SystemMdi)
                CloseAllDocuments();

            dockPanel.DocumentStyle = newStyle;
            /*
            menuItemDockingMdi.Checked = (newStyle == DocumentStyle.DockingMdi);
            menuItemDockingWindow.Checked = (newStyle == DocumentStyle.DockingWindow);
            menuItemDockingSdi.Checked = (newStyle == DocumentStyle.DockingSdi);
            menuItemSystemMdi.Checked = (newStyle == DocumentStyle.SystemMdi);
             */
        }

        private void SetDockPanelSkinOptions(bool isChecked)
        {
            if (isChecked)
            {
                // All of these options may be set in the designer.
                // This is not a complete list of possible options available in the skin.

                AutoHideStripSkin autoHideSkin = new AutoHideStripSkin();
                autoHideSkin.DockStripGradient.StartColor = Color.AliceBlue;
                autoHideSkin.DockStripGradient.EndColor = Color.Blue;
                autoHideSkin.DockStripGradient.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
                autoHideSkin.TabGradient.StartColor = SystemColors.Control;
                autoHideSkin.TabGradient.EndColor = SystemColors.ControlDark;
                autoHideSkin.TabGradient.TextColor = SystemColors.ControlText;
                autoHideSkin.TextFont = new Font("Showcard Gothic", 10);

                dockPanel.Skin.AutoHideStripSkin = autoHideSkin;

                DockPaneStripSkin dockPaneSkin = new DockPaneStripSkin();
                dockPaneSkin.DocumentGradient.DockStripGradient.StartColor = Color.Red;
                dockPaneSkin.DocumentGradient.DockStripGradient.EndColor = Color.Pink;

                dockPaneSkin.DocumentGradient.ActiveTabGradient.StartColor = Color.Green;
                dockPaneSkin.DocumentGradient.ActiveTabGradient.EndColor = Color.Green;
                dockPaneSkin.DocumentGradient.ActiveTabGradient.TextColor = Color.White;

                dockPaneSkin.DocumentGradient.InactiveTabGradient.StartColor = Color.Gray;
                dockPaneSkin.DocumentGradient.InactiveTabGradient.EndColor = Color.Gray;
                dockPaneSkin.DocumentGradient.InactiveTabGradient.TextColor = Color.Black;

                dockPaneSkin.TextFont = new Font("SketchFlow Print", 10);

                dockPanel.Skin.DockPaneStripSkin = dockPaneSkin;
            }
            else
            {
                dockPanel.Skin = new DockPanelSkin();
            }

        }

        #endregion

        #region Event Handlers

        private void menuItemExit_Click(object sender, System.EventArgs e)
        {
        }

        private void menuItemSolutionExplorer_Click(object sender, System.EventArgs e)
        {
            m_solutionExplorer.Show(dockPanel);
        }

        private void menuItemPropertyWindow_Click(object sender, System.EventArgs e)
        {
            m_propertyWindow.Show(dockPanel);
        }

        private void menuItemToolbox_Click(object sender, System.EventArgs e)
        {
            m_toolbox.Show(dockPanel);
        }

        private void menuItemOutputWindow_Click(object sender, System.EventArgs e)
        {
            m_outputWindow.Show(dockPanel);
        }

        private void menuItemTaskList_Click(object sender, System.EventArgs e)
        {
            m_taskList.Show(dockPanel);
        }

        private void menuItemAbout_Click(object sender, System.EventArgs e)
        {
        }

        private void menuItemNew_Click(object sender, System.EventArgs e)
        {
            if (stateApp == AppState.Open)
            {
                if (MessageBox.Show("Save document?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SaveCallFlow();
                }
                CloseAllDocuments();
                m_solutionExplorer.Clear();
                stateApp = AppState.Idle;
                ChangeAppState();

                strOpenFileName = "";
                strOpenFileFullName = "";
            }

            if (strOpenFileName.Trim().Length > 0)
            {
                if (MessageBox.Show("Close document?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (MessageBox.Show("Save document?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        SaveCallFlow();
                    }

                    CloseAllDocuments();
                    m_solutionExplorer.Clear();
                    stateApp = AppState.Idle;
                    ChangeAppState();

                    strOpenFileName = "";
                    strOpenFileFullName = "";
                }
                else
                {
                    return;
                }
            }

            frmCreateProject prj = new frmCreateProject();
            if (prj.ShowDialog() == DialogResult.OK)
            {
                GraphContainer.Instance.Project = prj.Project;
                GraphContainer.Instance.Description = prj.Description;
                GraphContainer.Instance.Version = prj.Version;
                GraphContainer.Instance.Extension = prj.Extension;
                GraphContainer.Instance.Host = prj.Host;
                GraphContainer.Instance.Port = Convert.ToString(prj.Port);
                GraphContainer.Instance.Path = prj.Path.Trim();
                GraphContainer.Instance.Command = prj.Command.Trim();
                GraphContainer.Instance.RemoteConnection = prj.RemoteConnection;
                GraphContainer.Instance.UserName = prj.UserName;
                GraphContainer.Instance.Password = prj.Password;

                m_solutionExplorer.CreateProjectNode(prj.Project);
                stateApp = AppState.Open;
                ChangeAppState();

            }
        }

        private void menuItemCreateFlow(object sender, System.EventArgs e)
        {
            frmCreateFlowName frm = new frmCreateFlowName();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                GraphDoc dummyDoc = CreateNewDocument();
                dummyDoc.FlowName = frm.FlowName;
                if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
                {
                    dummyDoc.MdiParent = this;
                    dummyDoc.Show();
                }
                else
                    dummyDoc.Show(dockPanel);

                m_solutionExplorer.CreateFlowNode(dummyDoc.FlowName, dummyDoc.DocID);
                
                if(GraphContainer.Instance.StartActivity == null)
                    GraphContainer.Instance.StartActivity = GraphContainer.Instance.Pages[dummyDoc.DocID].Entry;
            }
        }

        private void menuItemOpen_Click(object sender, System.EventArgs e)
        {
            if (stateApp == AppState.Open)
            {
                if (MessageBox.Show("Save document?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SaveCallFlow();
                }
                CloseAllDocuments();
                m_solutionExplorer.Clear();
                stateApp = AppState.Idle;
                ChangeAppState();

                strOpenFileName = "";
                strOpenFileFullName = "";
            }

            
            if (strOpenFileName.Length > 0)
            {
                if (MessageBox.Show("Close document?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CloseAllDocuments();
                    m_solutionExplorer.Clear();
                    stateApp = AppState.Idle;
                    ChangeAppState();
                    strOpenFileName = "";
                    strOpenFileFullName = "";
                }
                else
                {
                    return;
                }

            }

            OpenFileDialog openFile = new OpenFileDialog();
            //openFile.InitialDirectory = Application.ExecutablePath;
            openFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + Convert.ToString(Path.DirectorySeparatorChar) + "InteractiveCallFlow";
            openFile.Filter = "Call Flow Diagram (*.cfd)|*.cfd";
            openFile.FilterIndex = 1;
            openFile.RestoreDirectory = true;

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string fullName = openFile.FileName;
                string fileName = Path.GetFileName(fullName);

                if (strOpenFileName == fullName)
                {
                    MessageBox.Show("The document: " + fileName + " has already opened!");
                    return;
                }
                strOpenFileName = fullName;
                strOpenFileFullName = fileName;
                LoadDocument(fullName);

                stateApp = AppState.Open;
                ChangeAppState();

            }
        }

        private void menuItemFile_Popup(object sender, System.EventArgs e)
        {
        }

        private void menuItemClose_Click(object sender, System.EventArgs e)
        {
            if (stateApp == AppState.Open)
            {
                if (MessageBox.Show("Save document?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SaveCallFlow();
                }
            }

            CloseAllDocuments();
            m_solutionExplorer.Clear();
            strOpenFileName = "";
            strOpenFileFullName = "";

            stateApp = AppState.Idle;
            ChangeAppState();
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            string configFile = Path.Combine(Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)), "DockPanel.config");
            string configFileLocal = Path.Combine(Environment.CurrentDirectory, "DockPanel.config");

            try
            {
                if (File.Exists(configFile))
                    dockPanel.LoadFromXml(configFile, m_deserializeDockContent);
                else
                    dockPanel.LoadFromXml(configFileLocal, m_deserializeDockContent);


            }
            catch (Exception ex)
            {
            }

            ChangeAppState();

            this.Text = AssemblyProduct;
            ChangeToolBarView(menuItemFile);

            //Check license
            /*
            if (CheckLicense())
            {
                hasRegister = 1;
            }
            else
            {
                hasRegister = 0;
                frmRegistration reg = new frmRegistration();
                reg.ShowDialog();
                if (reg.NotRegister)
                {
                    Properties.Settings.Default.REG_DIALOG = 0;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    if (reg.DialogResult == DialogResult.OK)
                    {
                        //register success
                        MessageBox.Show("The application shall be closed right now after registration.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
                    }
                    else if (reg.DialogResult == DialogResult.Cancel)
                    {
                        //register failed
                    }

                }
            }
             */

        }


        private void ChangeAppState()
        {
            if (stateApp == AppState.Idle)
            {
                toolBarButtonSave.Enabled = false;
                toolBarButtonSaveAndClose.Enabled = false;
                toolBarButtonAddCallFlow.Enabled = false;
                toolBarButtonDeleteFlow.Enabled = false;
                toolBarButtonSelectStartFlow.Enabled = false;
                toolBarButtonVariables.Enabled = false;
                toolStripButtonClose.Enabled = false;
                toolBarButtonMake.Enabled = false;
                toolBarButtonStopMake.Enabled = false;
                toolBarButtonProjectProperty.Enabled = false;
                toolBarButtonFindSubFlow.Enabled = false;
                toolBarButtonFindActivity.Enabled = false;
                toolBarButtonRenameCallFlow.Enabled = false;
                toolBarButtonPrint.Enabled = false;
                toolBarButtonPrintPreview.Enabled = false;
                toolBarButtonPageSetup.Enabled = false;
            }
            else if (stateApp == AppState.Open)
            {
                toolBarButtonSave.Enabled = true;
                toolBarButtonSaveAndClose.Enabled = true;
                toolBarButtonAddCallFlow.Enabled = true;
                toolBarButtonDeleteFlow.Enabled = true;
                toolBarButtonSelectStartFlow.Enabled = true;
                toolBarButtonVariables.Enabled = true;
                toolStripButtonClose.Enabled = true;
                toolBarButtonMake.Enabled = true;
                toolBarButtonStopMake.Enabled = true;
                toolBarButtonProjectProperty.Enabled = true;
                toolBarButtonFindSubFlow.Enabled = true;
                toolBarButtonFindActivity.Enabled = true;
                toolBarButtonRenameCallFlow.Enabled = true;
                toolBarButtonPrint.Enabled = true;
                toolBarButtonPrintPreview.Enabled = true;
                toolBarButtonPageSetup.Enabled = true;
            }
        }

        private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string configFile = Path.Combine(Path.GetDirectoryName(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)), "DockPanel.config");

            try
            {
                if (m_bSaveLayout)
                    dockPanel.SaveAsXml(configFile);
                else if (File.Exists(configFile))
                    File.Delete(configFile);
            }
            catch (Exception ex)
            {
            }
        }

        private void menuItemToolBar_Click(object sender, System.EventArgs e)
        {
        }

        private void menuItemStatusBar_Click(object sender, System.EventArgs e)
        {
        }

        private void toolBar_ButtonClick(object sender, System.Windows.Forms.ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem == toolBarButtonNew)
                menuItemNew_Click(null, null);
            else if (e.ClickedItem == toolBarButtonOpen)
                menuItemOpen_Click(null, null);
            else if (e.ClickedItem == toolBarButtonSolutionExplorer)
                menuItemSolutionExplorer_Click(null, null);
            else if (e.ClickedItem == toolBarButtonPropertyWindow)
                menuItemPropertyWindow_Click(null, null);
            else if (e.ClickedItem == toolBarButtonToolbox)
                menuItemToolbox_Click(null, null);
            else if (e.ClickedItem == toolBarButtonOutputWindow)
                menuItemOutputWindow_Click(null, null);
            else if (e.ClickedItem == toolBarButtonTaskList)
                menuItemTaskList_Click(null, null);
            else if (e.ClickedItem == toolBarButtonSelectStartFlow)
            {
                SelectStartFlow();
            }
            else if (e.ClickedItem == toolBarButtonSave)
            {
                SaveCallFlow();
            }
            else if (e.ClickedItem == toolBarButtonAddCallFlow)
            {
                menuItemCreateFlow(null, null);
            }
            else if (e.ClickedItem == toolBarButtonDeleteFlow)
            {
                DeleteFlow();
            }
            else if (e.ClickedItem == toolStripButtonClose)
            {
                menuItemClose_Click(sender, null);
            }
            else if (e.ClickedItem == toolBarButtonVariables)
            {

                GraphContainer.Instance.MaintainVariable();

            }
        }

        private void SaveCallFlow()
        {
            if (strOpenFileName.Length > 0)
            {
                Interaction.Graph.GraphContainer.Instance.SaveFile(strOpenFileName);
            }
            else
            {

                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.InitialDirectory = Application.ExecutablePath;
                saveFile.Filter = "Call Flow Diagram (*.cfd)|*.cfd";
                saveFile.FilterIndex = 1;
                saveFile.RestoreDirectory = true;

                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    string fullName = saveFile.FileName;
                    string fileName = Path.GetFileName(fullName);

                    strOpenFileName = fullName;
                    strOpenFileFullName = fileName;
                    Interaction.Graph.GraphContainer.Instance.SaveFile(fullName);
                }
            }
        }

        private void SelectStartFlow()
        {
            frmSelectStartFlow frm = new frmSelectStartFlow();
            frm.FromType = 0;
            frm.StartActivity = GraphContainer.Instance.StartActivity;
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                if (frm.StartActivity != null)
                {
                    GraphContainer.Instance.StartActivity = frm.StartActivity;
                }
            }
        }

        public void FindActivity2(string strFlow, string strActivity)
        {
            foreach (Form form in MdiChildren)
            {
                Type type = form.GetType();
                if (type.Name.ToUpper() == "GraphDoc".ToUpper())
                {
                    if (((GraphDoc)form).FlowName.ToUpper() == strFlow.ToUpper())
                    {
                        form.Focus();

                        foreach (IActivity act in GraphContainer.Instance.Activities)
                        {
                            if (act.Description.ToUpper() == strActivity.ToUpper())
                            {
                                ((GraphDoc)form).HighlightActivity(act);
                                break;
                            }
                        }
                        break;
                    }
                }
            }

        }

        private void FindActivity()
        {
            frmSelectActivity frm = new frmSelectActivity();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                IActivity act = frm.StartActivity;
                if (act != null)
                {
                    foreach (Form form in MdiChildren)
                    {
                        Type type = form.GetType();
                        if (type.Name.ToUpper() == "GraphDoc".ToUpper())
                        {
                            if (((GraphDoc)form).DocID == act.DocID)
                            {
                                form.Focus();
                                ((GraphDoc)form).HighlightActivity(act);
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void FindSubFlow()
        {
            frmSelectStartFlow frm = new frmSelectStartFlow();
            frm.FromType = 1;
            frm.StartActivity = GraphContainer.Instance.StartActivity;
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                if (frm.SelectedPage != null)
                {
                    Page pSelect = frm.SelectedPage;

                    foreach (Form form in MdiChildren)
                    {
                        Type type = form.GetType();
                        if (type.Name.ToUpper() == "GraphDoc".ToUpper())
                        {
                            if (((GraphDoc)form).DocID == pSelect.DocID)
                            {
                                form.Focus();
                                break;
                            }
                        }
                    }


                }
            }
        }

        private void DeleteFlow()
        {
            frmDeleteFlow frm = new frmDeleteFlow();
            frm.ShowDialog();

            if (frm.DialogResult == DialogResult.OK)
            {
                Page p = frm.DeletePage;
                GraphContainer.Instance.RemovePage(p.DocID);
                m_solutionExplorer.RemoveFlowNode(p.DocID);
                foreach (Form form in MdiChildren)
                {
                    Type type = form.GetType();
                    if (type.Name.ToUpper() == "GraphDoc".ToUpper())
                    {
                        if (((GraphDoc)form).DocID == p.DocID)
                        {
                            ((GraphDoc)form).IsClose = true;
                            form.Close();
                            break;
                        }
                    }
                }

            }
        }

        private string ReadCallflowImp(string strFile)
        {
            string strRet = "";
            FileStream fs = null;
            TextReader w = null;
            StringBuilder sb = new StringBuilder();

            try
            {
                if (File.Exists(strFile))
                {
                    fs = new FileStream(strFile, FileMode.Open);
                    w = new StreamReader(fs);

                    string str = w.ReadLine();
                    while (str != null)
                    {
                        sb.Append(str);
                        str = w.ReadLine();
                    }

                    w.Close();
                    w = null;

                    fs.Close();
                    fs = null;

                    strRet = sb.ToString();
                }
            }
            catch (Exception ex)
            {
                if (w != null)
                    w.Close();

                if (fs != null)
                    fs.Close();
            }

            return strRet;
        }

        private void LoadDocument(string strFile)
        {
            string strXML = ReadCallflowImp(strFile);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(strXML);

            XPathNavigator nav = doc.CreateNavigator();
            string strStartActivityID = "";

            XPathNodeIterator projectIterator = nav.Select("/CallFlow");
            while (projectIterator.MoveNext())
            {
                string strProject = projectIterator.Current.GetAttribute("Project", string.Empty);
                string strDesc = projectIterator.Current.GetAttribute("Description", string.Empty);
                string strVersion = projectIterator.Current.GetAttribute("Version", string.Empty);
                string strExt = projectIterator.Current.GetAttribute("Extension", string.Empty);

                string strHost = projectIterator.Current.GetAttribute("Host", string.Empty);
                string strPort = projectIterator.Current.GetAttribute("Port", string.Empty);
                string strPath = projectIterator.Current.GetAttribute("Path", string.Empty);
                string strCmd = projectIterator.Current.GetAttribute("Command", string.Empty);
                string strUser = projectIterator.Current.GetAttribute("UserName", string.Empty);
                string strPwd = projectIterator.Current.GetAttribute("Password", string.Empty);
                string strRemoteConn = projectIterator.Current.GetAttribute("RemoteConnection", string.Empty);

                strStartActivityID = projectIterator.Current.GetAttribute("Start", string.Empty);
                GraphContainer.Instance.Project = strProject;
                GraphContainer.Instance.Description = strDesc;
                GraphContainer.Instance.Version = strVersion;
                GraphContainer.Instance.Extension = strExt;
                GraphContainer.Instance.Host = strHost;
                GraphContainer.Instance.Port = strPort;
                GraphContainer.Instance.Path = strPath;
                GraphContainer.Instance.Command = strCmd;
                GraphContainer.Instance.UserName = strUser;
                GraphContainer.Instance.Password = strPwd;
                GraphContainer.Instance.RemoteConnection = Convert.ToBoolean(strRemoteConn);

                m_solutionExplorer.CreateProjectNode(strProject);
            }

            XPathNodeIterator varIter = nav.Select("/CallFlow/Variable");
            while (varIter.MoveNext())
            {
                string strVar = varIter.Current.GetAttribute("val", string.Empty);
                GraphContainer.Instance.Variable.Add(strVar);
            }

            XPathNodeIterator pageIterator = nav.Select("/CallFlow/Page");
            while (pageIterator.MoveNext())
            {
                string strDocID = pageIterator.Current.GetAttribute("docID", string.Empty);
                string strFlowName = pageIterator.Current.GetAttribute("flowName", string.Empty);

                GraphDoc dummyDoc = CreateNewDocument();
                dummyDoc.DocID = strDocID;
                dummyDoc.FlowName = strFlowName;
                //dummyDoc.TmpFile = strFile;
                dummyDoc.TmpFile = strXML;

                if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
                {
                    dummyDoc.MdiParent = this;
                    dummyDoc.Show();
                }
                else
                    dummyDoc.Show(dockPanel);

                m_solutionExplorer.CreateFlowNode(dummyDoc.FlowName, dummyDoc.DocID);
            }

            XPathNodeIterator Iterator = nav.Select("/CallFlow/Link");
            while (Iterator.MoveNext())
            {
                string strKey = Iterator.Current.GetAttribute("key", string.Empty);
                string strVal = Iterator.Current.GetAttribute("val", string.Empty);

                Node n1 = GraphContainer.Instance.Nodes[strKey];
                Node n2 = GraphContainer.Instance.Nodes[strVal];
                GraphContainer.Instance.NodeRelationship[n1] = n2;
            }

            Dictionary<string, Page>.Enumerator pageEnum = GraphContainer.Instance.Pages.GetEnumerator();
            while (pageEnum.MoveNext())
            {
                KeyValuePair<string, Page> item = pageEnum.Current;
                GraphDoc t = item.Value.Document as GraphDoc;
                t.Redraw();

            }

            GraphContainer.Instance.StartActivity = GraphContainer.Instance.FindActivity(strStartActivityID);
        }

        private void menuItemNewWindow_Click(object sender, System.EventArgs e)
        {
            MainForm newWindow = new MainForm();
            newWindow.Text = newWindow.Text + " - New";
            newWindow.Show();
        }

        private void menuItemTools_Popup(object sender, System.EventArgs e)
        {
//            menuItemLockLayout.Checked = !this.dockPanel.AllowEndUserDocking;
        }

        private void menuItemLockLayout_Click(object sender, System.EventArgs e)
        {
            dockPanel.AllowEndUserDocking = !dockPanel.AllowEndUserDocking;
        }

        /*

        private void menuItemShowDocumentIcon_Click(object sender, System.EventArgs e)
        {
            dockPanel.ShowDocumentIcon = menuItemShowDocumentIcon.Checked = !menuItemShowDocumentIcon.Checked;
        }
        private void showRightToLeft_Click(object sender, EventArgs e)
        {
            CloseAllContents();
            if (showRightToLeft.Checked)
            {
                this.RightToLeft = RightToLeft.No;
                this.RightToLeftLayout = false;
            }
            else
            {
                this.RightToLeft = RightToLeft.Yes;
                this.RightToLeftLayout = true;
            }
            m_solutionExplorer.RightToLeftLayout = this.RightToLeftLayout;
            showRightToLeft.Checked = !showRightToLeft.Checked;
        }
        */
        private void exitWithoutSavingLayout_Click(object sender, EventArgs e)
        {
            m_bSaveLayout = false;
            Close();
            m_bSaveLayout = true;
        }

        #endregion

        private void toolBarButtonNew_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {

        }


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveCallFlow();
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

        private void CompileCallFlow()
        {

            compileJob = new ThreadStart(CompileJob);
            compileThread = new Thread(compileJob);
            compileThread.Start();

        }

        private void toolBarButtonMake_Click(object sender, EventArgs e)
        {
            if (stateApp == AppState.Open)
            {
                if (MessageBox.Show("Save document?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SaveCallFlow();
                    m_outputWindow.Clear();
                    m_taskList.Clear();
                    StopCompile = false;
                    CompileCallFlow();
                }
            }
        }

        private void CompileJob()
        {
            //string strOutFile = this.strOpenFileName.Replace(" ", "_");
            
            string strOutFile = this.strOpenFileName;
            string strPath = Path.GetDirectoryName(strOutFile);
            string strConf = Path.GetFileName(strOutFile).Replace(" ", "_");
            strOutFile = strPath + "\\" + strConf;
            

            string strArgs = string.Format("\"{0}\" \"{1}\"", new object[] { this.strOpenFileName, strOutFile + ".conf" });
            int exitCode = -1;
            Process p = new Process();
            DataReceivedEventHandler dataRecvHandler = new DataReceivedEventHandler(p_OutputDataReceived);
            compileFinishEvent[0] = new ManualResetEvent(false);

            try
            {
                p.OutputDataReceived += dataRecvHandler;
                ProcessStartInfo myProcessStartInfo = new ProcessStartInfo();

                string strCompiler = "";
                if (Properties.Settings.Default.COMPILER_PATH.ToLower().Trim() == "callflowcompiler.exe".ToLower())
                {
                    strCompiler = Environment.CurrentDirectory + "\\" + Properties.Settings.Default.COMPILER_PATH;
                }
                else
                {
                    strCompiler = Properties.Settings.Default.COMPILER_PATH;
                }

                myProcessStartInfo.FileName = strCompiler;
                myProcessStartInfo.Arguments = strArgs;
                myProcessStartInfo.UseShellExecute = false;
                myProcessStartInfo.CreateNoWindow = true;
                myProcessStartInfo.RedirectStandardOutput = true;
                p.StartInfo = myProcessStartInfo;
                p.Start();
                p.BeginOutputReadLine();

                while (!p.WaitForExit(1))
                {
                    if (StopCompile)
                    {
                        p.Kill();
                        break;
                    }
                }
                exitCode = p.ExitCode;
                compileFinishEvent[0].WaitOne();
            }
            catch (Win32Exception win32Ex)
            {
                CompileOutputText("Cannot find compiler.");
                exitCode = -999;
            }
            catch (ObjectDisposedException oex)
            {
                CompileOutputText("System failure.");
                exitCode = -999;
            }
            catch (InvalidOperationException invalidEx)
            {
                CompileOutputText("Compiler invalid operation.");
                exitCode = -999;
            }
            catch (ArgumentNullException argumentEx)
            {
                CompileOutputText("Invalid argument.");
                exitCode = -999;
            }
            finally
            {
                if (p != null)
                {
                    compileFinishEvent[0].Close();
                    p.OutputDataReceived -= dataRecvHandler;
                    p.Close();
                    p.Dispose();
                }
            }

            if (!StopCompile && exitCode == 0)
            {
                p = null;
                bool transferComplete = false;
                CompileOutputText("Build successful.");

                if (GraphContainer.Instance.RemoteConnection)
                {

                    SshTransferProtocolBase sshCp = new Sftp(GraphContainer.Instance.Host,
                        Convert.ToInt32(GraphContainer.Instance.Port),
                        GraphContainer.Instance.UserName,
                        GraphContainer.Instance.Password);
                    FileTransferEvent transferStart = new FileTransferEvent(sshCp_OnTransferStart);
                    FileTransferEvent transferProgress = new FileTransferEvent(sshCp_OnTransferProgress);
                    FileTransferEvent transferEnd = new FileTransferEvent(sshCp_OnTransferEnd);

                    try
                    {
                        CompileOutputText("Upload file to " + GraphContainer.Instance.Host);

                        sshCp.OnTransferStart += transferStart;
                        sshCp.OnTransferProgress += transferProgress;
                        sshCp.OnTransferEnd += transferEnd;

                        sshCp.Connect();

                        sshCp.Put(strOutFile + ".conf", GraphContainer.Instance.Path + "/" + strOpenFileFullName + ".conf");
                        Thread.Sleep(200);
                        transferComplete = true;
                    }
                    catch (Exception exTxr)
                    {
                        CompileOutputText("Cannot upload file - " + GraphContainer.Instance.Path + "/" + strOpenFileFullName);
                    }
                    finally
                    {
                        sshCp.OnTransferStart -= transferStart;
                        sshCp.OnTransferProgress -= transferProgress;
                        sshCp.OnTransferEnd -= transferEnd;

                        if (sshCp != null)
                        {
                            sshCp.Close();
                            sshCp = null;
                        }
                    }


                    if (transferComplete)
                    {

                        SshExec exec = new SshExec(GraphContainer.Instance.Host,
                            Convert.ToInt32(GraphContainer.Instance.Port),
                            GraphContainer.Instance.UserName,
                            GraphContainer.Instance.Password);

                        try
                        {
                            exec.Connect();
                            CompileOutputText("Reload PBX");
                            CompileOutputText(exec.RunCommand(GraphContainer.Instance.Command));
                        }
                        catch (Exception exExec)
                        {
                            CompileOutputText("Cannot reoload PBX");
                        }
                        finally
                        {
                            if (exec != null)
                            {
                                exec.Close();
                                exec = null;
                            }
                        }
                    }
                }
            }
            else
            {
                CompileOutputText("Build with error.");
            }

            CompileOutputText("Build end.");
        }

        private void sshCp_OnTransferStart(string src, string dst, int transferredBytes, int totalBytes, string message)
        {
            string strOut = string.Format("{0} {1} {2}", new object[] { message, totalBytes, transferredBytes});
            CompileOutputText(strOut);
        }

        private void sshCp_OnTransferProgress(string src, string dst, int transferredBytes, int totalBytes, string message)
        {
            string strOut = string.Format("{0} {1} {2}", new object[] { message, totalBytes, transferredBytes });
            CompileOutputText(strOut);
        }

        private void sshCp_OnTransferEnd(string src, string dst, int transferredBytes, int totalBytes, string message)
        {
            string strOut = string.Format("{0} {1} {2}", new object[] { message, totalBytes, transferredBytes });
            CompileOutputText(strOut);
            CompileOutputText("Finish transfer");
        }

        void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data == null)
            {
                compileFinishEvent[0].Set();
            }
            else
            {
                if (e.Data.Contains("Error"))
                {
                    PrintTaskList(e.Data);
                }

                CompileOutputText(e.Data);
            }
        }

        private void PrintTaskList(string text)
        {
            m_taskList.WriteLine(text);
        }

        private void CompileOutputText(string text)
        {
            m_outputWindow.WriteLine(text);
        }

        private void toolBarButtonStopMake_Click(object sender, EventArgs e)
        {
            StopCompile = true;
        }

        private void toolBarButtonProjectProperty_Click(object sender, EventArgs e)
        {
            frmCreateProject prj = new frmCreateProject();
            prj.Project = GraphContainer.Instance.Project;
            prj.Description = GraphContainer.Instance.Description;
            prj.Version = GraphContainer.Instance.Version;
            prj.Extension = GraphContainer.Instance.Extension;
            prj.Host = GraphContainer.Instance.Host;
            prj.Port = Convert.ToInt32(GraphContainer.Instance.Port);
            prj.Path = GraphContainer.Instance.Path;
            prj.UserName = GraphContainer.Instance.UserName;
            prj.Password = GraphContainer.Instance.Password;
            prj.Command = GraphContainer.Instance.Command;
            prj.RemoteConnection = GraphContainer.Instance.RemoteConnection;

            prj.ShowDialog();

            if (prj.DialogResult == DialogResult.OK)
            {
                m_solutionExplorer.ProjectName = prj.Project;

                GraphContainer.Instance.Project = prj.Project;
                GraphContainer.Instance.Description = prj.Description;
                GraphContainer.Instance.Version = prj.Version;
                GraphContainer.Instance.Extension = prj.Extension;
                GraphContainer.Instance.Host = prj.Host;
                GraphContainer.Instance.Port = Convert.ToString(prj.Port);
                GraphContainer.Instance.Path = prj.Path.Trim();
                GraphContainer.Instance.Command = prj.Command.Trim();
                GraphContainer.Instance.UserName = prj.UserName;
                GraphContainer.Instance.Password = prj.Password;
                GraphContainer.Instance.RemoteConnection = prj.RemoteConnection;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        private void dockPanel_ActiveContentChanged(object sender, EventArgs e)
        {

        }


        private void toolBarButtonAbout_Click(object sender, EventArgs e)
        {
            ShowHelp();
        }

        private void ShowHelp()
        {
            try
            {
                System.Diagnostics.Process.Start(Environment.CurrentDirectory + Convert.ToString(Path.DirectorySeparatorChar) + "interactivecallflow.chm");
            }
            catch (Exception ex)
            {
            }
        }

        private void toolBarButtonSettings_Click(object sender, EventArgs e)
        {
            frmSystemProps frm = new frmSystemProps();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                Properties.Settings.Default.Save();
            }
        }

        private void toolBarButtonSaveAndClose_Click(object sender, EventArgs e)
        {
            SaveCallFlow();
            CloseAllDocuments();
            m_solutionExplorer.Clear();
            strOpenFileName = "";
            strOpenFileFullName = "";

        }

        private void toolBarButtonExit_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void ChangeToolBarView(ToolStripMenuItem menuItem)
        {
            foreach (ToolStripItem button in toolBar.Items)
            {
                if (button is ToolStripButton)
                {
                    button.Visible = false;
                }
            }

            if (menuItem == menuItemFile)
            {
                toolBarButtonNew.Visible = true;
                toolBarButtonOpen.Visible = true;
                toolBarButtonSave.Visible = true;
                toolBarButtonSaveAndClose.Visible = true;
                toolStripButtonClose.Visible = true;
                toolBarButtonExit.Visible = true;
                toolBarButtonPrint.Visible = true;
                toolBarButtonPrintPreview.Visible = true;
                toolBarButtonPageSetup.Visible = true;
            }
            else if (menuItem == menuItemView)
            {
                toolBarButtonSolutionExplorer.Visible = true;
                toolBarButtonPropertyWindow.Visible = true;
                toolBarButtonToolbox.Visible = true;
                toolBarButtonOutputWindow.Visible = true;
                toolBarButtonTaskList.Visible = true;
            }
            else if (menuItem == menuItemFind)
            {
                toolBarButtonFindSubFlow.Visible = true;
                toolBarButtonFindActivity.Visible = true;
            }
            else if (menuItem == projectToolStripMenuItem)
            {
                toolBarButtonProjectProperty.Visible = true;
                toolBarButtonAddCallFlow.Visible = true;
                toolBarButtonDeleteFlow.Visible = true;
                toolBarButtonVariables.Visible = true;
                toolBarButtonMake.Visible = true;
                toolBarButtonStopMake.Visible = true;
                toolBarButtonRenameCallFlow.Visible = true;
                toolBarButtonSelectStartFlow.Visible = true;
            }
            else if (menuItem == menuItemTools)
            {
                toolBarButtonSettings.Visible = true;
            }
            else if (menuItem == menuItemHelp)
            {
                toolBarButtonHelp.Visible = true;
                toolBarButtonAbout.Visible = true;
            }
        }

        private void menuItemFile_Click(object sender, EventArgs e)
        {
            ChangeToolBarView(sender as ToolStripMenuItem);
        }

        private void menuItemView_Click(object sender, EventArgs e)
        {
            ChangeToolBarView(sender as ToolStripMenuItem);

        }

        private void menuItemFind_Click(object sender, EventArgs e)
        {
            ChangeToolBarView(sender as ToolStripMenuItem);

        }

        private void toolBarButtonFindSubFlow_Click(object sender, EventArgs e)
        {
            FindSubFlow();

        }

        private void toolBarButtonFindActivity_Click(object sender, EventArgs e)
        {
            FindActivity();

        }

        private void projectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeToolBarView(sender as ToolStripMenuItem);

        }

        private void menuItemTools_Click(object sender, EventArgs e)
        {
            ChangeToolBarView(sender as ToolStripMenuItem);

        }

        private void toolBarButtonAbout_Click_1(object sender, EventArgs e)
        {
            AboutDialog aboutDialog = new AboutDialog();
            aboutDialog.ShowDialog(this);

        }

        private void menuItemHelp_Click(object sender, EventArgs e)
        {
            ChangeToolBarView(sender as ToolStripMenuItem);

        }

        private void toolBarButtonRenameCallFlow_Click(object sender, EventArgs e)
        {
            try
            {
                GraphDoc graphDoc = this.ActiveMdiChild as GraphDoc;
                frmCreateFlowName frm = new frmCreateFlowName();
                frm.FlowName = graphDoc.FlowName;
                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    GraphContainer.Instance.Pages[graphDoc.DocID].FlowName = frm.FlowName;
                    graphDoc.FlowName = frm.FlowName;
                    m_solutionExplorer.ChangeSubFlowName(graphDoc.DocID, frm.FlowName);

                    if (GraphContainer.Instance.Pages[graphDoc.DocID].Entry != null)
                    {
                        GraphContainer.Instance.Pages[graphDoc.DocID].Entry.EntryNode.Text = frm.FlowName;
                    }
                }
            }
            catch (Exception ex)
            {
            }

        }

        private void toolBarButtonPrint_Click(object sender, EventArgs e)
        {
            printDialog1.Document = pd;
            if (printDialog1.ShowDialog(this) == DialogResult.OK)
            {
                pd.Print();
            }
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            if (printDialog1.PrinterSettings.PrintRange == PrintRange.CurrentPage)
            {
                try
                {
                    GraphDoc doc = this.ActiveMdiChild as GraphDoc;
                    if (doc.Print(e) == false)
                    {
                        e.HasMorePages = true;
                    }
                    else
                    {
                        e.HasMorePages = false;
                    }
                }
                catch (Exception ex)
                {
                }
            }
            else
            {
                Form frm = MdiChildren[currentPageCnt];

                try
                {
                    GraphDoc doc = frm as GraphDoc;
                    if (doc.Print(e) == false)
                    {
                        e.HasMorePages = true;
                    }
                    else
                    {
                        if (currentPageCnt < MdiChildren.Length-1)
                        {
                            e.HasMorePages = true;
                            currentPageCnt++;
                        }
                        else
                        {
                            e.HasMorePages = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }

        }

        void pd_EndPrint(object sender, PrintEventArgs e)
        {
            //GraphDoc doc = this.ActiveMdiChild as GraphDoc;
            //doc.RestoreBackground();

        }

        void pd_BeginPrint(object sender, PrintEventArgs e)
        {
            foreach (Form frm in MdiChildren)
            {
                try
                {
                    GraphDoc doc = frm as GraphDoc;
                    doc.ResetPrint();
                    currentPageCnt = 0;
                }
                catch (Exception ex)
                {
                }
            }

        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            pd.PrintPage -= printPageEventHandler;
            pd.BeginPrint -= beginPrintEventHandler;
            pd.EndPrint -= endPrintEventHandler;
        }

        private void toolBarButtonPrintPreview_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = pd;
            printPreviewDialog1.ShowDialog(this);
        }

        private void toolBarButtonPageSetup_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.Document = pd;
            pageSetupDialog1.ShowDialog(this);
        }

        private void toolBarButtonRegister_Click(object sender, EventArgs e)
        {
        }


    }

    public enum AppState
    {
        Idle,
        Open
    }
}