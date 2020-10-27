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
        private EntryElement _sourceElement;
        private EntryRecord _record;
        public EntryEditor(EntryRecord source, int index)
        {
            _record = source;
            _sourceElement = _record.GetEntry(index);
            InitializeComponent();
            TitleTextBox.Text = _sourceElement.Title;
            UrlTextBox.Text = _sourceElement.Url;
            AccessTimeLabel.Text = _sourceElement.AccessTime.ToString();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            if (!_sourceElement.Title.Equals(TitleTextBox.Text) || !_sourceElement.Url.Equals(UrlTextBox.Text))
            {
                Console.WriteLine($"{_sourceElement.Title} => {TitleTextBox.Text}");
                _record.EditEntry(_sourceElement.Title, TitleTextBox.Text, UrlTextBox.Text, true);
            }
            OnListMutated(EventArgs.Empty);
            Close();
        }

        protected virtual void OnListMutated(EventArgs e)
        {
            EventHandler handler = ListMutated;
            handler(this, e);
            
        }

        public event EventHandler ListMutated = delegate { };
    }

    public class ListMutatedEventArgs : EventArgs
    {
        public string Title;
    }
}
