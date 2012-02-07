using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Interaction.Graph
{
    public interface IGraphEvent
    {
        void GraphMouseMove(object sender, MouseEventArgs e);
        void GraphMouseDown(object sender, MouseEventArgs e);
        void GraphMouseUp(object sender, MouseEventArgs e);
    }
}
