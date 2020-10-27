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

    public partial class EntryCollectionEditor : Form 
    {
        private string name;

        // Use this to raise rerender events
        private EntryRecord _source;
        public EntryCollectionEditor(EntryRecord source)
        {
            _source = source;
            name = source.Filename;
            InitializeComponent();
            Text = source.Filename;
            _paintList(source.GetList());
            EntrySelector.SelectedIndexChanged += EntrySelector_SelectedIndexChanged;
            //EntrySelector;
        }

        private void _paintList(List<EntryElement> list)
        {
            EntrySelector.BeginUpdate();
            EntrySelector.Items.Clear();
            foreach (EntryElement entry in list)
            {
                ListViewItem nEntry = new ListViewItem(entry.Title);
                nEntry.SubItems.Add(entry.Url);
                nEntry.SubItems.Add(entry.AccessTime.ToString());
                EntrySelector.Items.Add(nEntry);
            }
            EntrySelector.EndUpdate();
        }

        private void EntrySelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection sel = EntrySelector.SelectedItems;

            if (sel.Count > 1)
            {
                DeleteBtn.Enabled = true;
                EditBtn.Enabled = false;
            } else if (sel.Count == 0)
            {
                EditBtn.Enabled = false;
                DeleteBtn.Enabled = false;
            } else
            {
                DeleteBtn.Enabled = true;
                EditBtn.Enabled = true;
            }
            
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
            ListView.SelectedListViewItemCollection sel = EntrySelector.SelectedItems;

            foreach (ListViewItem.ListViewSubItemCollection subitems in sel)
            {
                _source.RemoveEntry(subitems[0].Text, true);
            }
            _paintList(_source.GetList());
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            _source.ClearList();
            _paintList(_source.GetList());
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection sel = EntrySelector.SelectedItems;
            int index = _source.GetIndex(sel[0].SubItems[0].Text);
            EntryEditor editor = new EntryEditor(_source.GetEntry(index));
            editor.Show();
        }

        private void FilterInput_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
