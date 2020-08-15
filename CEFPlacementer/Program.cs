using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CEFPlacementer
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            var msg = new StringBuilder();
            foreach(var arg in Environment.GetCommandLineArgs())
            {
                msg.AppendLine(arg);
            }
            MessageBox.Show(msg.ToString());
        }
    }
}
