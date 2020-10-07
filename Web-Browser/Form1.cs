using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
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
            content.ContextChanged += content_OnContextChanged;
            SourceViewer.Text = content.HttpCode;
            UrlInput.Text = content.Url;
            Text = content.Title;
        }
        
        private void content_OnContextChanged(object sender, ContextChangedEventArgs e)
        {
            UrlInput.Text = e.Url;
            Text = e.Title;
        }

        private void GoBtn_Click(object sender, EventArgs e)
        {
            // call navigate on PageContent with URL input as arg
            string url = UrlInput.Text;
            content.Navigate(url);
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {

        }

        private void ForwardsBtn_Click(object sender, EventArgs e)
        {

        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {

        }

        private void HomeBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
