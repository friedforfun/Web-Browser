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
    public partial class FavouritesDialogue : Form
    {
        Favourites fav;
        public FavouritesDialogue(string title, string url, Favourites favourites)
        {
            InitializeComponent();
            TitleTextBox.Text = title;
            UrlTextBox.Text = url;
            fav = favourites;
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            // Add entry and write to file
            try
            {
                fav.AddEntry(UrlTextBox.Text, TitleTextBox.Text, true);
                Close();
            }
            catch (Exception)
            {
                MessageBox.Show("A favourite with this title already exists.\n Try to add a custom favourite with a new name", "Add Favourites Error");
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
