﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Synb_Project_TeamB
{
    public partial class Temp_Box : PictureBox
    {
        public Temp_Box()
        {
            this.SetStyle(ControlStyles.DoubleBuffer |
                ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
        }
    }
}