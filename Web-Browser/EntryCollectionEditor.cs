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

    public partial class EntryCollectionEditor : Form 
    {
        public EntryCollectionEditor(EntryRecord source)
        {
            InitializeComponent();
            Text = source.Filename;
            _paintList(source.GetList());
            //EntrySelector;
        }

        private void _paintList(List<EntryElement> list)
        {
            EntrySelector.BeginUpdate();
            foreach (EntryElement entry in list)
            {
                ListViewItem nEntry = new ListViewItem(entry.Title);
                nEntry.SubItems.Add(entry.Url);
                nEntry.SubItems.Add(entry.AccessTime.ToString());
                EntrySelector.Items.Add(nEntry);
            }
            EntrySelector.EndUpdate();
        }

        private void DoneBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FilterBtn_Click(object sender, EventArgs e)
        {

        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {

        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {

        }

        private void EditBtn_Click(object sender, EventArgs e)
        {

        }

        private void FilterInput_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
