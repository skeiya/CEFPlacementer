using CefSharp.WinForms;
using System;
using System.Windows.Forms;

namespace CEFBrowser
{
    public partial class Form1 : Form
    {
        private ChromiumWebBrowser _chromiumWebBrowser1;

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            _chromiumWebBrowser1 = new ChromiumWebBrowser();
            _chromiumWebBrowser1.Dock = DockStyle.Fill;
            this.Controls.Add(_chromiumWebBrowser1);
            this.Shown += Form1_Shown;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            _chromiumWebBrowser1.Load(URL);
        }

        public string URL { get; internal set; } = "google.com";
    }
}
