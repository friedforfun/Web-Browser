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
    public partial class EntryEditor : Form
    {
        private EntryElement source;
        public EntryEditor(EntryElement element)
        {
            source = element;
            InitializeComponent();
            TitleTextBox.Text = element.Title;
            UrlTextBox.Text = element.Url;
            AccessTimeLabel.Text = element.AccessTime.ToString();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            source.Title = TitleTextBox.Text;
            source.Url = UrlTextBox.Text;
            Close();
        }
    }
}
