using System;
using System.Windows.Forms;

namespace CEFBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Shown += Form1_Shown;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            chromiumWebBrowser1.Load(URL);
        }

        public string URL { get; internal set; } = "google.com";
    }
}
