using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Process.Start("CEFPlacementer.exe", "-lgoogle.com -p100:100:400:200");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("CEFPlacementer.exe", "-lYahoo.co.jp -p100:100:200:400");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start("CEFPlacementer.exe", "-c");
        }
    }
}
