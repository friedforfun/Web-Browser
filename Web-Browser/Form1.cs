﻿using System;
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

        private void goBtn_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Go fired");
        }
    }
}
