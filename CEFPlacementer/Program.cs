using CommandLine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
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
            if (!string.IsNullOrEmpty(opts.URL)) Load(opts.URL, GetPosition(opts.PositionString));
            if (opts.Close) Close();
        }

        private static void Close()
        {
            throw new NotImplementedException();
        }

        private static Rectangle? GetPosition(string positionString)
        {
            var tokens = positionString.Split(':');
            if (tokens.Count() != 4) return null;
            try
            {
                return new Rectangle(int.Parse(tokens[0]), int.Parse(tokens[1]), int.Parse(tokens[2]), int.Parse(tokens[3]));
            }
            catch
            {
                return null;
            }
        }

        private static void Load(string uRL, Rectangle? pos)
        {
            var target = FindTarget();
            if (target == null)
            {
                Launch(uRL);
                return;
            }
            target.StandardInput.WriteLine(uRL);
            target.StandardInput.Flush();
        }

        private static void Launch(string uRL)
        {
            Process.Start(TargetName, uRL);
        }

        private static Process FindTarget()
        {
            foreach(var p in Process.GetProcesses())
            {
                if (p.ProcessName.Equals(TargetName)) return p;
            }
            return null;
        }

        private static string TargetName => "CEFBrowser.exe";
    }
}
