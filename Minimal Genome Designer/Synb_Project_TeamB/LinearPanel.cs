using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Synb_Project_TeamB
{
    public partial class LinearPanel : Panel
    {
        public void CirclePanel()
        {
            this.SetStyle(ControlStyles.DoubleBuffer |
                ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint,true);
            this.UpdateStyles();
        }
    }
}
