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
        private string name;
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

        public event EventHandler<EntryCollectionEditorDeletedArgs> ElementsDeleted = delegate { };

        private void OnElementsDeleted(EntryCollectionEditorDeletedArgs e)
        {
            EventHandler<EntryCollectionEditorDeletedArgs> handler = ElementsDeleted;
            // handler has null deligate so no need to check if null
            handler(this, e);
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
            string[] delKeys = new string[sel.Count];

            for (int i = 0; i < sel.Count; i++)
            {
                delKeys[i] = sel[i].SubItems[0].Text;
            }
            EntryCollectionEditorDeletedArgs args = new EntryCollectionEditorDeletedArgs();
            args.SourceName = name;
            args.keys = delKeys;
            OnElementsDeleted(args);
            _paintList(_source.GetList());
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            List<EntryElement> list = _source.GetList();
            string[] delKeys = new string[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                delKeys[i] = list[i].Title;
            }
            EntryCollectionEditorDeletedArgs args = new EntryCollectionEditorDeletedArgs();
            args.SourceName = name;
            args.keys = delKeys;
            OnElementsDeleted(args);
            _paintList(_source.GetList());
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {

        }

        private void FilterInput_TextChanged(object sender, EventArgs e)
        {

        }
    }

    public class EntryCollectionEditorDeletedArgs: EventArgs
    {
        public string SourceName;
        public string[] keys;
    }

}
