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
        public FavouritesDialogue(string title, string url)
        {
            InitializeComponent();
            TitleTextBox.Text = title;
            UrlTextBox.Text = url;
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            Favourites.AddEntry(UrlTextBox.Text, TitleTextBox.Text);
            Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
