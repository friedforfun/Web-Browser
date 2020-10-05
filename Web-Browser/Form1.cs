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

        private void menuBtn_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void goBtn_Click(object sender, EventArgs e)
        {
            //string url = this.URLInput.Text;
            // make sure url is in the correct format: http://www.<domain>.<suffix>[/:][a-zA-Z0-9]*
            //var response = await HttpRequests.Get(url);
            //this.sourceViewer.Text = response.HttpSourceCode;
        }

        private void tabPage0_Enter(object sender, EventArgs e)
        {

        }

        private void NewTab_Enter(object sender, EventArgs e)
        {
            //int numTabs = tabControl.TabPages.Count - 1;
            //string tabName = $"tabPage{numTabs}";
            //tabControl.TabPages.Insert(numTabs, tabName);

            //tabControl.SelectedIndex = numTabs;

            // change current tab to the newly created tab
        }

        private async void BrowserWindow_Load(object sender, EventArgs e)
        {
            Console.WriteLine("window width: {0}", Width);
            // initialise my tabs ect here
            BrowserTabControl tabs = new BrowserTabControl(this);
            BrowserTabPage HomePage = await BrowserTabPage.AsyncCreate(this);
            tabs.Controls.Add(HomePage);
            //tabs.Controls.Add(this.tabPage1);
            tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            tabs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tabs.Location = new System.Drawing.Point(0, 0);
            tabs.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            tabs.Name = "tabControl";
            tabs.SelectedIndex = 0;
            tabs.Size = new System.Drawing.Size(1168, 796);
            tabs.TabIndex = 4;

            Controls.Add(tabs);
            // Add 'home' BrowserTabPage
            // Add '+' BrowserTabPage

        }

        private void panel1_Resize(object sender, EventArgs e)
        {

        }

        private void BrowserWindow_Resize(object sender, EventArgs e)
        {
            // resize tab Control and children with this
            Console.WriteLine("Resize event thrown");
            Console.WriteLine("Width: {0}", Width);
            Console.WriteLine("Height: {0}", Height);

            // Update the Width and Height fields in the BrowserTabControl object/s
            /*
            Control[] tabsArr = Controls.Find("tabControl", false);
            foreach (BrowserTabControl tabControl in tabsArr)
            {
                tabControl.Width = Width;
                tabControl.Height = Height;
            }
            */
        }
    }
}
