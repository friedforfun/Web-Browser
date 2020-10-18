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
            fav.AddEntry(UrlTextBox.Text, TitleTextBox.Text);
            Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
