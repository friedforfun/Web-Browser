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
        private static string HomeUrl = "http://www.google.com";

        public BrowserWindow()
        {
            InitializeComponent();
            MenuPicker.BringToFront();
        }


        private async void BrowserWindow_Load(object sender, EventArgs e)
        {
            content = await PageContent.AsyncCreate(HomeUrl);
            content.ContextChanged += content_OnContextChanged;
            SourceViewer.Text = content.HttpCode;
            UrlInput.Text = content.Url;
            Text = content.Title;
            SetStateForwardsBack();

        }
        
        private void content_OnContextChanged(object sender, ContextChangedEventArgs e)
        {
            UrlInput.Text = e.Url;
            Text = e.Title;
            SourceViewer.Text = content.HttpCode;
            SetStateForwardsBack();
        }

        private void GoBtn_Click(object sender, EventArgs e)
        {
            // call navigate on PageContent with URL input as arg
            string url = UrlInput.Text;
            content.Navigate(url);
            //Console.WriteLine("THis: {0}", content.LocalHistory.test);
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            content.Back();
        }

        private void ForwardsBtn_Click(object sender, EventArgs e)
        {
            content.Forwards();
        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            content.NavigateNoHistory(content.Url);
        }

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            if (content.Url != HomeUrl)
            {
                content.Navigate(HomeUrl);
            } else
            {
                content.NavigateNoHistory(HomeUrl);
            }
            
        }

        private void SetStateForwardsBack()
        {
            if (!content.LocalHistory.CanStepBack)
            {
                BackBtn.Enabled = false;
            }
            else
            {
                BackBtn.Enabled = true;
            }
            if (!content.LocalHistory.CanStepForward)
            {
                ForwardsBtn.Enabled = false;
            }
            else
            {
                ForwardsBtn.Enabled = true;
            }
        }

        private void MenuBtn_Click(object sender, EventArgs e)
        {
            MenuPicker.Visible = MenuPicker.Visible ? false : true;
        }
    }
}
