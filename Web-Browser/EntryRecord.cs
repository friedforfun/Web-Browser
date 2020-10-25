using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Diagnostics;

namespace Web_Browser
{
    /// <summary>
    /// Interface used to write an Entry of sorted list type to XML by converting to array
    /// </summary>
    /// <typeparam name="T">Type implementing the Entry class</typeparam>
    interface ICanWriteXML<T> where T : Entry
    {
        void SerializeCollection();
        void DeserializeCollection();
    }

    /// <summary>
    /// An entry record used for History and Favourites collection
    /// </summary>
    
    public class EntryRecord : ICanWriteXML<EntryElement>
    {
        public string Filename;

        private SortedList<string, EntryElement> EntryCollection = new SortedList<string, EntryElement>();

        public event EventHandler<EntryRecordChanged> EntryChanged = delegate { };

        private Persistance<EntryElement> persistanceManager;

        public EntryRecord(string filename)
        {
            Filename = filename;
            persistanceManager = new Persistance<EntryElement>(filename);
            // if file exists deserialize here
        }

        /// <summary>
        /// Add a new entry to the collection
        /// </summary>
        /// <param name="url">The URL of the entry</param>
        /// <param name="title">The title of the entry</param>
        public void AddEntry(string url, string title, bool write)
        {
            EntryElement nextEntry = instantiateEntry(url, title);
            try
            {
                if (title != "")
                {
                    EntryCollection.Add(title, nextEntry);
                    OnEntryChanged(title, ARU.Added, write);
                } else
                {
                    // url as entry title & key
                    EntryCollection.Add(url, nextEntry);
                    OnEntryChanged(url, ARU.Added, write);
                }

            }
            catch (ArgumentException e)
            {
                KeyExists(e, nextEntry, write);
            }
        }

        private EntryElement instantiateEntry(string url, string title)
        {
            EntryElement nextEntry;
            if (title != "")
            {
                nextEntry = new EntryElement(url, title);
            } else
            {
                nextEntry = new EntryElement(url, url);
            }
            return nextEntry;
        }

        public virtual void KeyExists(ArgumentException e, EntryElement element, bool write)
        {
            // Key already exists / null key
            MessageBox.Show("An element with this key already exists.", "Add Collection Error");
        }

        public virtual ToolStripItemCollection BuildMenu(ToolStrip owner)
        {
            ToolStripItem[] items = new ToolStripItem[EntryCollection.Count];
            int i = 0;
            foreach(EntryElement entry in EntryCollection.Values)
            {
                items[i] = new ToolStripMenuItem();
                items[i].Text = entry.Title;
                items[i].Size = new System.Drawing.Size(270, 34);
                items[i].Name = entry.Title;
            }
            ToolStripItemCollection tic = new ToolStripItemCollection(owner, items);
            return tic;
        }

        /// <summary>
        /// Remove the entry from the list by key
        /// </summary>
        /// <param name="title"></param>
        /// <param name="write"></param>
        public void RemoveEntry(string title, bool write)
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
            OnEntryChanged(title, ARU.Removed, write);
        }

        /// <summary>
        /// Remove entry from the list, control thrown event
        /// </summary>
        /// <param name="title"></param>
        /// <param name="write"></param>
        /// <param name="bEvent"></param>
        public void RemoveEntry(string title, bool write, bool bEvent)
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
            if (bEvent)
            {
                OnEntryChanged(title, ARU.Removed, write);
            }
        }


        public IList<string> GetKeys()
        {
            return EntryCollection.Keys;
        }

        public void EditEntryUrl(string title, string url, bool write)
        {
            EntryElement nextEntry = new EntryElement(url, title, GetTime(title));
            RemoveEntry(title, write, false);
            try
            {
                EntryCollection.Add(title, nextEntry);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Got an argument Exception when attempting to add an element to a list");
            }

            // Setup & trigger event
            OnEntryChanged(title, ARU.Updated, write);
        }

        public void EditEntryTitle(string title, string nextTitle, bool write)
        {
            EntryElement nextEntry = new EntryElement(GetUrl(title), nextTitle, GetTime(title));
            RemoveEntry(title, write, false);
            EntryCollection.Add(nextTitle, nextEntry);

            // Setup & trigger event
            OnEntryChanged(title, ARU.Updated, write);
        }

        public void EditEntry(string title, string nextTitle, string nextUrl, bool write)
        {
            EntryElement nextEntry = new EntryElement(nextUrl, nextTitle, GetTime(title));
            RemoveEntry(title, write, false);
            EntryCollection.Add(nextTitle, nextEntry);

            // Setup & trigger event
            OnEntryChanged(title, ARU.Updated, write);
        }


        public void EditEntry(EntryElement nextEntry, bool write)
        {
            string title = nextEntry.Title;   
            RemoveEntry(title, write, false);
            EntryCollection.Add(title, nextEntry);

            // Setup & trigger event
            OnEntryChanged(title, ARU.Updated, write);
        }

        public string GetUrl(string title)
        {
            return EntryCollection[title].Url;
        }

        public DateTime GetTime(string title)
        {
            return EntryCollection[title].AccessTime;
        }

        void OnEntryChanged(string title, ARU state, bool WriteFile)
        {
            EntryRecordChanged updatedEntry = new EntryRecordChanged();
            updatedEntry.AddRemUpd = state;
            updatedEntry.EntryKey = title;
            updatedEntry.WriteFile = WriteFile;
            EventHandler<EntryRecordChanged> handler = EntryChanged;
            // handler has null deligate so no need to check if null
            handler(null, updatedEntry);
            if (WriteFile)
            {
                SerializeCollection();
            }
        }


        public void SerializeCollection()
        {
            persistanceManager.SerializeCollection(EntryCollection);
        }

        public void DeserializeCollection()
        {
            SortedList<string, EntryElement> _tempCollection = persistanceManager.DeserializeCollection();
            foreach(string key in _tempCollection.Keys)
            {
                EntryElement newElement = _tempCollection[key];
                if (EntryCollection.ContainsKey(key))
                {
                    EditEntry(newElement, false);
                }
                else
                {
                    string title = newElement.Title;
                    string url = newElement.Url;
                    AddEntry(url, title, false);
                }
            }

        }
    }

    [KnownType(typeof(EntryElement[]))]
    [DataContract]
    public class EntryElement : Entry
    {

        // when editing instantiate a new favourite and delete this one
        private string _url;
        private string _title;
        private DateTime _accessTime;
        
        [DataMember]
        public override string Url 
        {
            get => _url;
            set => _url = value;
        }
        [DataMember]
        public override string Title
        {
            get => _title;
            set => _title = value;
        }
        [DataMember]
        public override DateTime AccessTime
        {
            get => _accessTime;
            set => _accessTime = value;
        }
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
        public bool WriteFile;
        public ARU AddRemUpd;
        public string EntryKey;
    }
}
