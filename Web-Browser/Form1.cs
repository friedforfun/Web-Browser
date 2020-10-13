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
        private Favourites favourites;
        private History history;

        public BrowserWindow()
        {
            InitializeComponent();
            MenuPicker.BringToFront();
            favourites = Favourites.Instance;
            history = History.Instance;
            content.ContextChanged += content_OnContextChanged;
            favourites.EntryChanged += Favourites_Changed;
            history.EntryChanged += History_Changed;
        }


        private async void BrowserWindow_Load(object sender, EventArgs e)
        {
            content = await PageContent.AsyncCreate(favourites.HomeUrl);
            SourceViewer.Text = content.HttpCode;
            UrlInput.Text = content.Url;
            Text = content.Title;
            StatusCodeLabel.Text = content.StatusMessage;
            SetStateForwardsBack();
        }
        
        private void content_OnContextChanged(object sender, ContextChangedEventArgs e)
        {
            UrlInput.Text = e.Url;
            Text = e.Title;
            SourceViewer.Text = content.HttpCode;
            StatusCodeLabel.Text = content.StatusMessage;
            SetStateForwardsBack();
        }

        private void Favourites_Changed(object sender, EntryRecordChanged e)
        {
            ToolStripDropDown dropdown = OpenFavourites.DropDown;
            switch (e.AddRemUpd)
            {
                case ARU.Added:
                    ToolStripMenuItem nextItem = new ToolStripMenuItem(e.EntryKey);
                    nextItem.Name = e.EntryKey;
                    dropdown.Items.Add(nextItem);
                    break;

                case ARU.Removed:
                    dropdown.Items.RemoveByKey(e.EntryKey);
                    break;

                case ARU.Updated:
                    dropdown.Items.RemoveByKey(e.EntryKey);
                    ToolStripMenuItem updatedItem = new ToolStripMenuItem(e.EntryKey);
                    updatedItem.Name = e.EntryKey;
                    dropdown.Items.Add(updatedItem);
                    break;
            }
        }

        private void History_Changed(object sender, EntryRecordChanged e)
        {

        }

        private void GoBtn_Click(object sender, EventArgs e)
        {
            // call navigate on PageContent with URL input as arg
            string url = UrlInput.Text;
            if (url == content.Url)
            {
                content.NavigateNoHistory(url);
            } else
            {
                content.Navigate(url);
            }
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
            if (content.Url != Favourites.HomeUrl)
            {
                content.Navigate(Favourites.HomeUrl);
            } else
            {
                content.NavigateNoHistory(Favourites.HomeUrl);
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

        private void AddFavourites_Click(object sender, EventArgs e)
        {
            favourites.AddEntry(content.Url, content.Title);
        }

        private void AddCustomFavourite_Click(object sender, EventArgs e)
        {
           FavouritesDialogue CustomFavourite = new FavouritesDialogue(content.Title, content.Url);
           CustomFavourite.Show();
        }
    }
}
