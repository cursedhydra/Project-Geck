﻿using System;
using System.Windows.Forms;

namespace Geck
{
    static class Program
    {
        /// <summary>
        /// Build a Fallout Tabletop character
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
