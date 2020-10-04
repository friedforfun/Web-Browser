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
        public BrowserWindow()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void menuBtn_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private async void goBtn_Click(object sender, EventArgs e)
        {
            string url = this.URLInput.Text;
            // make sure url is in the correct format: http://www.<domain>.<suffix>[/:][a-zA-Z0-9]*
            var response = await HttpRequests.Get(url);
            this.sourceViewer.Text = response.HttpSourceCode;
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            this.tabPage1.Text = "A tab";
        }
    }
}
