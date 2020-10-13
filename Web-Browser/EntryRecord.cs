using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Web_Browser
{
    /// <summary>
    /// Interface used to write an Entry sorted list to XML
    /// </summary>
    /// <typeparam name="T">Type implementing the Entry class</typeparam>
    interface IWriteXML<T> where T : Entry
    {
        SortedList<string, T> GetList();
    }
    /// <summary>
    /// An entry record used for History and Favourites collection
    /// </summary>
    public class EntryRecord : IWriteXML<EntryElement>
    {
        private SortedList<string, EntryElement> EntryCollection = new SortedList<string, EntryElement>();

        public event EventHandler<EntryRecordChanged> EntryChanged = delegate { };

        /// <summary>
        /// Add a new entry to the collection
        /// </summary>
        /// <param name="url">The URL of the entry</param>
        /// <param name="title">The title of the entry</param>
        public void AddEntry(string url, string title)
        {
            EntryElement nextEntry = new EntryElement(url, title);
            try
            {
                EntryCollection.Add(title, nextEntry);
                // Setup & trigger event
                OnEntryChanged(title, ARU.Added);
            }
            catch (ArgumentException)
            {
                // Key already exists / null key
                MessageBox.Show("A favourite with this title already exists.", "Add Favourite Error");
            }
        }


        public SortedList<string, EntryElement> GetList()
        {
            return EntryCollection;
        }

        /// <summary>
        /// Remove the entry from the list by key
        /// </summary>
        /// <param name="title"></param>
        public void RemoveEntry(string title)
        {
            try
            {
                EntryCollection.Remove(title);

            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Attempted to remove a non-existent element from a list");
            }
            // attempt to update the gui regardless of error state
            OnEntryChanged(title, ARU.Removed);
        }

        public IList<string> GetTitle()
        {
            return EntryCollection.Keys;
        }

        public void EditEntryUrl(string title, string url)
        {
            EntryElement nextEntry = new EntryElement(url, title, GetTime(title));
            RemoveEntry(title);
            try
            {
                EntryCollection.Add(title, nextEntry);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Got an argument Exception when attempting to add an element to a list");
            }

            // Setup & trigger event
            OnEntryChanged(title, ARU.Updated);
        }

        public void EditEntryTitle(string title, string nextTitle)
        {
            EntryElement nextEntry = new EntryElement(GetUrl(title), nextTitle, GetTime(title));
            RemoveEntry(title);
            EntryCollection.Add(nextTitle, nextEntry);

            // Setup & trigger event
            OnEntryChanged(title, ARU.Updated);
        }

        public void EditEntry(string title, string nextTitle, string nextUrl)
        {
            EntryElement nextEntry = new EntryElement(nextUrl, nextTitle, GetTime(title));
            RemoveEntry(title);
            EntryCollection.Add(nextTitle, nextEntry);

            // Setup & trigger event
            OnEntryChanged(title, ARU.Updated);
        }

        public string GetUrl(string title)
        {
            return EntryCollection[title].Url;
        }

        public DateTime GetTime(string title)
        {
            return EntryCollection[title].AccessTime;
        }

        void OnEntryChanged(string title, ARU state)
        {
            EntryRecordChanged updatedEntry = new EntryRecordChanged();
            updatedEntry.AddRemUpd = state;
            updatedEntry.EntryKey = title;
            EventHandler<EntryRecordChanged> handler = EntryChanged;
            // handler never null so no need to check if null
            handler(null, updatedEntry);
        }
    }

    public class EntryElement : Entry
    {

        // when editing instantiate a new favourite and delete this one
        private readonly string _url;
        private readonly string _title;
        private readonly DateTime _accessTime;

        public override string Url => _url;

        public override string Title => _title;

        public override DateTime AccessTime => _accessTime;

        public EntryElement(string url, string title)
        {
            _url = url;
            _title = title;
            _accessTime = DateTime.Now;
        }

        public EntryElement(string url, string title, DateTime time)
        {
            _url = url;
            _title = title;
            _accessTime = time;
        }
    }

    public enum ARU
    {
        Removed,
        Updated,
        Added
    }

    public class EntryRecordChanged : EventArgs
    {
        public ARU AddRemUpd;
        public string EntryKey;
    }
}
