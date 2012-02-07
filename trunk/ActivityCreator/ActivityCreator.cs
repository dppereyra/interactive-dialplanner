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
using System.Diagnostics;
using System.Reflection;
using System.Runtime.Serialization;
using System.Drawing;
using System.Resources;

namespace Interaction.Graph
{
    public class ActivityCreator
    {
        private static ActivityCreator _self = null;
        private Dictionary<string, Assembly> mapModule = new Dictionary<string, Assembly>();
        public delegate void NotifyLoadInstance(object sender, NotifyEventArgs args);
        public NotifyLoadInstance _onNotifyLoadInstance;

        private ActivityCreator()
        {
            
        }

        public static ActivityCreator Instance
        {
            get
            {
                if (_self == null)
                    _self = new ActivityCreator();

                return _self;
            }
        }

        public event NotifyLoadInstance NotifyLoadInstanceEvent
        {
            add
            {
                _onNotifyLoadInstance += value;
            }

            remove
            {
                _onNotifyLoadInstance -= value;
            }
        }


        private void RaiseEvent(NotifyEventArgs args)
        {
            try
            {
                if (_onNotifyLoadInstance != null)
                {
                    _onNotifyLoadInstance.Invoke(this, args);

                }
            }
            catch (Exception ex)
            {
            }
        }

        public ArrayList Bitmaps()
        {
            ArrayList list = new ArrayList();
            Dictionary<string, Assembly>.Enumerator lpAssembly = mapModule.GetEnumerator();

            while (lpAssembly.MoveNext())
            {
                KeyValuePair<string, Assembly> item = lpAssembly.Current;

                Assembly assembly = item.Value;
                foreach (Type type in assembly.GetTypes())
                {
                    if (type.IsClass == true)
                    {
                        if (type.Name.IndexOf("Activity") > 0)
                        {
                            // create an instance of the object
                            IActivity s = Activator.CreateInstance(type) as IActivity;
                            if (s.ExistToolBox)
                            {
                                ActivityIcon i = new ActivityIcon();
                                i.icon = s.Icon;
                                i.strName = s.ActivityName;
                                list.Add(i);
                                break;
                            }
                        }
                    }
                }
            }

            return list;
        }
        
        public void LoadActivity()
        {
            string strPath = Environment.CurrentDirectory;

            string[] strFiles = Directory.GetFiles(strPath, "*Activity.dll");

            foreach(string strModule in strFiles)
            {
                Assembly asm = Assembly.LoadFrom(strModule);
                foreach (Type type in asm.GetTypes())
                {
                    try
                    {
                        if (type.IsClass == true)
                        {
                            if (type.Name.IndexOf("Activity") > 0)
                            {
                                Debug.Print(strPath);
                                NotifyEventArgs arg = new NotifyEventArgs();
                                arg.m_Msg = type.Name;
                                RaiseEvent(arg);

                                IActivity ClassObj = Activator.CreateInstance(type) as IActivity;
                                mapModule[ClassObj.ActivityName.ToUpper()] = asm;
                                break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.Print(ex.ToString());
                    }
                }
            }

        }

        public IActivity CreateActivity(string strName)
        {
            IActivity s = null;

            if (mapModule.ContainsKey(strName.ToUpper()))
            {
                Assembly assembly = mapModule[strName.ToUpper()];
                foreach (Type type in assembly.GetTypes())
                {
                    if (type.IsClass == true)
                    {
                        if (type.Name.IndexOf("Activity") > 0)
                        {
                            // create an instance of the object
                            s = Activator.CreateInstance(type) as IActivity;
                            s.ActivityID = System.Guid.NewGuid().ToString();
                            break;
                        }
                    }
                }
            }

            return s;
        }

        public struct ActivityIcon
        {
            public Image icon;
            public string strName;
        }
    }

    public class NotifyEventArgs : EventArgs
    {
        public string m_Msg = "";
    }
}
