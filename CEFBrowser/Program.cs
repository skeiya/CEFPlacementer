using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CEFBrowser
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var f = new Form1();
            if (Environment.GetCommandLineArgs().Length == 2)
            {
                f.URL = Environment.GetCommandLineArgs()[1];
            }
            Application.Run(f);
        }
    }
}
