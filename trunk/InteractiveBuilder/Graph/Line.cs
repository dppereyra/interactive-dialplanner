using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Interaction.Graph
{
    public class Line
    {
        private Point from = new Point(0, 0);
        private Point to = new Point(0, 0);

        public Point Start
        {
            get
            {
                return from;
            }

            set
            {
                from = value;
            }
        }

        public Point End
        {
            get
            {
                return to;
            }

            set
            {
                to = value;
            }
        }
    }
}
