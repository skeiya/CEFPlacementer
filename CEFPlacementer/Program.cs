using CommandLine;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;

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
            KillExsistingTarget();
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

        private static void Load(string url, Rectangle? pos)
        {
            KillExsistingTarget();
            Launch(url, pos);
        }

        private static void KillExsistingTarget()
        {
            var target = FindTarget();
            if (target != null) Kill(target);
        }

        private static void Kill(Process target)
        {
            target.Kill();
        }

        private static void Launch(string url, Rectangle? pos)
        {
            var p = Process.Start(TargetName, url);
            if (!pos.HasValue) return;
            var rect = pos.Value;
            Thread.Sleep(1000);
            MoveWindow(p.MainWindowHandle, rect.X, rect.Y, rect.Width, rect.Height, true);
        }

        private static Process FindTarget()
        {
            foreach (var p in Process.GetProcesses())
            {
                if (p.ProcessName.Equals(TargetProcessName)) return p;
            }
            return null;
        }

        private static string TargetName => TargetProcessName + ".exe";
        private static string TargetProcessName => "CEFBrowser";

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
    }
}
