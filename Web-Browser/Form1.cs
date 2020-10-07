using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Web_Browser
{
    public partial class BrowserWindow : Form
    {
        private PageContent content;
        private static string HomeURL = "http://www.google.com";

        public BrowserWindow()
        {
            InitializeComponent();
        }


        private async void BrowserWindow_Load(object sender, EventArgs e)
        {
            content = await PageContent.AsyncCreate(HomeURL);
            SourceViewer.Text = content.HttpCode;
            UrlInput.Text = content.Url;
            Text = content.Title;
        }

        private void GoBtn_Click(object sender, EventArgs e)
        {
            // call navigate on PageContent with URL input as arg
            string url = UrlInput.Text;
            content.Navigate(url);
        }
    }
}
