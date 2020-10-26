using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        private FileWatcher watcher;

        public BrowserWindow()
        {
            InitializeComponent();
            MenuPicker.BringToFront();
            favourites = Favourites.Instance;
            history = History.Instance;
            favourites.EntryChanged += Favourites_Changed;
            history.EntryChanged += History_Changed;
            string path = Application.StartupPath;
            watcher = new FileWatcher(path);
            watcher.FSEventHandler += FS_Changed;
            watcher.WatcherError += Watcher_Error;
            watcher.Run();
            favourites.DeserializeCollection();
            history.DeserializeCollection();
        }

        private void FS_Changed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"File: {e.FullPath} {e.ChangeType} {e.Name}");
            if (e.Name == favourites.Filename)
            {
                // Favourites changed
            } 
            else if (e.Name == history.Filename)
            {
                // History changed
            }
        }

        private void Watcher_Error(object sender, ErrorEventArgs e)
        {
            Console.WriteLine($"Error: {e}");
        }


        private async void BrowserWindow_Load(object sender, EventArgs e)
        {
            content = await PageContent.AsyncCreate(favourites.HomeUrl, history);
            content.ContextChanged += content_OnContextChanged;
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

        /// <summary>
        /// When favourites changed event gets thrown, this method updates the favourites collection in the gui
        /// </summary>
        /// <param name="e">EntryRecordChanged event parameter, indicates what kind of event got thrown & updates the list accordingly</param>
        private void Favourites_Changed(object sender, EntryRecordChanged e)
        {
            ToolStripDropDown favDropdown = OpenFavourites.DropDown;
            Update_History_Favourites_Menu(favDropdown, e);
            // repaint edit menu also
        }

        /// <summary>
        /// When history changed event gets thrown, this method updates the history collection in the gui
        /// </summary>

        /// <param name="e">EntryRecordChanged event parameter, indicates what kind of event got thrown & updates the list accordingly</param>
        private void History_Changed(object sender, EntryRecordChanged e)
        {
            ToolStripDropDown histDropdown = OpenHistory.DropDown;
            Update_History_Favourites_Menu(histDropdown, e);
        }

        /// <summary>
        /// Handles the duplicate logic between updating History/Favourites in gui
        /// </summary>
        /// <param name="dropDown">The dropdown object from the ToolStripMenuItem that uses this collection</param>
        /// <param name="e">The event args, to determine gui update behaviour</param>
        private void Update_History_Favourites_Menu(ToolStripDropDown dropDown, EntryRecordChanged e)
        {
            switch (e.AddRemUpd)
            {
                case ARU.Added:
                    ToolStripMenuItem nextItem = new ToolStripMenuItem(e.EntryKey);
                    nextItem.Click += MenuItem_Click;
                    nextItem.Name = e.EntryKey;
                    nextItem.Tag = e.Path;
                    dropDown.Items.Add(nextItem);
                    break;

                case ARU.Removed:
                    dropDown.Items.RemoveByKey(e.EntryKey);
                    break;

                case ARU.Updated:
                    dropDown.Items.RemoveByKey(e.EntryKey);
                    ToolStripMenuItem updatedItem = new ToolStripMenuItem(e.EntryKey);
                    updatedItem.Name = e.EntryKey;
                    updatedItem.Click += MenuItem_Click;
                    dropDown.Items.Add(updatedItem);
                    break;
            }
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem source = (ToolStripMenuItem) sender;
            string key = source.Name;
            string id = (string) source.Tag;
            string buttonUrl;

            if (id.Equals("Favourites"))
            {
               buttonUrl = favourites.GetUrl(key);
            } else if (id.Equals("History"))
            {
                buttonUrl = history.GetUrl(key);
            } else
            {
                Console.WriteLine("ID not found");
                buttonUrl = null;
            }

            if (buttonUrl.Equals(content.Url))
            {
                content.NavigateNoHistory(buttonUrl);
            }
            else
            {
                content.Navigate(buttonUrl);
            }
        }

        private void GoBtn_Click(object sender, EventArgs e)
        {
            // call navigate on PageContent with URL input as arg
            string url = UrlInput.Text;
            if (url.Equals(content.Url))
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
            if (content.Url != favourites.HomeUrl)
            {
                content.Navigate(favourites.HomeUrl);
            } else
            {
                content.NavigateNoHistory(favourites.HomeUrl);
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
            // Add entry and write to file
            favourites.AddEntry(content.Url, content.Title, true);
        }

        private void AddCustomFavourite_Click(object sender, EventArgs e)
        {
           FavouritesDialogue CustomFavourite = new FavouritesDialogue(content.Title, content.Url, favourites);
           CustomFavourite.Show();
        }

        private void EditHistory_Click(object sender, EventArgs e)
        {
            EntryCollectionEditor historyEditor = new EntryCollectionEditor(history);
            historyEditor.ElementsDeleted += Editor_ElementsDeleted;
            historyEditor.Show();
        }

        private void EditFavourites_Click(object sender, EventArgs e)
        {
            EntryCollectionEditor favouritesEditor = new EntryCollectionEditor(favourites);
            favouritesEditor.ElementsDeleted += Editor_ElementsDeleted;
            favouritesEditor.Show();
        }

        private void Editor_ElementsDeleted(object sender, EntryCollectionEditorDeletedArgs e)
        {
            
            foreach (string key in e.keys)
            {
                Console.WriteLine("Deleted: {0}", key);
                if (e.SourceName.Equals("History"))
                {
                    history.RemoveEntry(key, true);
                } else
                {
                    favourites.RemoveEntry(key, true);
                }
                
            }


            //throw new NotImplementedException();
        }

        private void MenuPicker_MouseLeave(object sender, EventArgs e)
        {
            MenuPicker.Visible = false;
        }

        private void SetHomePage_Click(object sender, EventArgs e)
        {
            favourites.SetHomeURL(content.Url);
        }
    }
}
