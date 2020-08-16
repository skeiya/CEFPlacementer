using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace SampleClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("CEFPlacementer.exe", "-lgoogle.com " + GetPositionArg());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("CEFPlacementer.exe", "-lYahoo.co.jp " + GetPositionArg());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start("CEFPlacementer.exe", "-c");
        }

        private string GetPositionArg()
        {
            var clientRect = new Rectangle(panel1.Location.X, panel1.Location.Y, panel1.Width, panel1.Height);
            var screenRect = this.RectangleToScreen(clientRect);
            return "-p" + screenRect.X.ToString() + ":" + screenRect.Y.ToString() + ":" + screenRect.Width.ToString() + ":" + screenRect.Height.ToString();
        }
    }
}
