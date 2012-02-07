using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Interaction.Graph
{
    public class SupplyStore
    {
        private static SupplyStore _instance;
        private List<string> op = new List<string>();
        private List<string> optype = new List<string>();

        private SupplyStore()
        {
            LoadSupplies();
        }

        public static SupplyStore Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SupplyStore();
                }

                return (_instance);
            }
        }

        public List<string> Operator
        {
            get { return (_instance.op as List<string>); }
        }

        public List<string> OperatorType
        {
            get { return (_instance.optype as List<string>); }
        }

        private void LoadSupplies()
        {
            optype.Add("=");
            optype.Add(">");
            optype.Add("<");
            optype.Add("!=");

            op.Add("+");
            op.Add("-");
            op.Add("*");
            op.Add("/");
            op.Add("%");
            op.Add("<");
            op.Add(">");
            op.Add("<=");
            op.Add(">=");
            op.Add("==");
        }

    }
}
