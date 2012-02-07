using System;
using System.Collections.Generic;
using System.Text;

namespace DennisWuWorks.InteractiveBuilder
{
    public class DragItem : Object
    {
        private string strKey;
        private  int dragType; // 0=activity

        public DragItem(): base()
        {
            strKey = "";
            dragType = -1;
        }

        public string Key
        {
            get
            {
                return strKey;
            }

            set
            {
                strKey = value;
            }
        }

        public int DragType
        {
            get
            {
                return dragType;
            }

            set
            {
                dragType = value;
            }
        }
    }
}
