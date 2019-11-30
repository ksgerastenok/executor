using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace AutoRun
{
    public static class Program : Object
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThreadAttribute]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(AutoRun.Instance);
        }
    }
}
