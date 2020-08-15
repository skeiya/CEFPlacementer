using CommandLine;
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
            var result = Parser.Default.ParseArguments<Options>(Environment.GetCommandLineArgs());
            result.WithParsed(RunOptions);
        }
        static void RunOptions(Options opts)
        {
            if (opts.Close) MessageBox.Show("Close");
        }
    }
}
