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

        //private SortedList<string, EntryElement> EntryCollection = new SortedList<string, EntryElement>();
        private List<EntryElement> _EntryCollection = new List<EntryElement>();

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
                if (GetIndex(nextEntry.Title) > -1) throw new ArgumentException("Title should be unique for each entry");
                _EntryCollection.Add(nextEntry);
                OnEntryChanged(nextEntry.Title, ARU.Added, write);
                /*
                if (title != "")
                {
                    EntryCollection.Add(title, nextEntry);

                    OnEntryChanged(nextEntry.Title, ARU.Added, write);
                } else
                {
                    // url as entry title & key
                    EntryCollection.Add(url, nextEntry);
                    OnEntryChanged(url, ARU.Added, write);
                }*/

            }
            catch (ArgumentException e)
            {
                KeyExists(e, nextEntry, write);
            }
        }

        public void AddEntry(EntryElement entry, bool write)
        {
            try
            {
                _EntryCollection.Add(entry);
                OnEntryChanged(entry.Title, ARU.Added, write);
                /*
                if (title != "")
                {
                    EntryCollection.Add(title, nextEntry);

                    OnEntryChanged(nextEntry.Title, ARU.Added, write);
                } else
                {
                    // url as entry title & key
                    EntryCollection.Add(url, nextEntry);
                    OnEntryChanged(url, ARU.Added, write);
                }*/

            }
            catch (ArgumentException e)
            {
                KeyExists(e, entry, write);
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

        /*
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
        }*/

        /// <summary>
        /// Remove the entry from the list by key
        /// </summary>
        /// <param name="title"></param>
        /// <param name="write"></param>
        public void RemoveEntry(string title, bool write)
        {
            try
            {
                int index = GetIndex(title);
                _EntryCollection.RemoveAt(index);

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
                int index = GetIndex(title);
                _EntryCollection.RemoveAt(index);

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


        public List<EntryElement> GetList()
        {
            return _EntryCollection;
        }

        public void EditEntryUrl(string title, string url, bool write)
        {
            EntryElement nextEntry = new EntryElement(url, title, GetTime(title));
            RemoveEntry(title, write, false);
            try
            {
                _EntryCollection.Add(nextEntry);
                //EntryCollection.Add(title, nextEntry);
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
            _EntryCollection.Add(nextEntry);

            // Setup & trigger event
            OnEntryChanged(title, ARU.Updated, write);
        }

        public void EditEntry(string title, string nextTitle, string nextUrl, bool write)
        {
            EntryElement nextEntry = new EntryElement(nextUrl, nextTitle, GetTime(title));
            RemoveEntry(title, write, false);
            _EntryCollection.Add(nextEntry);
            //EntryCollection.Add(nextTitle, nextEntry);

            // Setup & trigger event
            OnEntryChanged(title, ARU.Updated, write);
        }


        public void EditEntry(EntryElement nextEntry, bool write)
        {
            string title = nextEntry.Title;   
            RemoveEntry(title, write, false);
            _EntryCollection.Add(nextEntry);
            //EntryCollection.Add(title, nextEntry);

            // Setup & trigger event
            OnEntryChanged(title, ARU.Updated, write);
        }

        public string GetUrl(string title)
        {
            int index = GetIndex(title);
            return _EntryCollection[index].Url;
        }

        public DateTime GetTime(string title)
        {
            int index = GetIndex(title);
            return _EntryCollection[index].AccessTime;
        }

        public int GetIndex(string title)
        {
            return _EntryCollection.FindIndex(entry => entry.Title.Equals(title));
        }

        void OnEntryChanged(string title, ARU state, bool WriteFile)
        {
            EntryRecordChanged updatedEntry = new EntryRecordChanged();
            updatedEntry.AddRemUpd = state;
            updatedEntry.EntryKey = title;
            updatedEntry.WriteFile = WriteFile;
            updatedEntry.Path = Filename;
            EventHandler<EntryRecordChanged> handler = EntryChanged;
            // handler has null deligate so no need to check if null
            handler(this, updatedEntry);
            if (WriteFile)
            {
                SerializeCollection();
            }
        }


        public void SerializeCollection()
        {
            persistanceManager.SerializeCollection(_EntryCollection);
        }

        public void DeserializeCollection()
        {
            List<EntryElement> _tempCollection = persistanceManager.DeserializeCollection();
            if (_tempCollection == null) return;
            
            foreach (EntryElement entry in _tempCollection)
            {
                int index = GetIndex(entry.Title);

                // When the entry being read has a key collision
                if (_EntryCollection.Contains(entry))
                {
                    return;
                }
                else if (index > -1)
                {
                    EntryElement current = _EntryCollection[index];
                    if (entry.Url.Equals(current.Url) && entry.AccessTime.CompareTo(current.AccessTime) > 0)
                    {
                        // The key & URL are the same
                        // use most recent access time
                        EditEntry(entry, false);
                    }
                    return;
                } else
                {
                    AddEntry(entry, false);
                }
            }

        }
    }

    [KnownType(typeof(EntryElement[]))]
    [DataContract]
    public class EntryElement : Entry, IComparable<EntryElement>
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

        public CompareBy Compareby = CompareBy.AlphabetTitle;

        public int CompareTo(EntryElement other)
        {
            if (other == null) return 1;

            switch (Compareby)
            {
                case CompareBy.AlphabetTitle:
                    return string.Compare(Title, other.Title);
                case CompareBy.AlphabetUrl:
                    return string.Compare(Url, other.Url);
                case CompareBy.Chronological:
                    return AccessTime.CompareTo(other.AccessTime);
                default:
                    throw new ArgumentException("CompareBy enum has undefined case");
            }
        }

        public override string ToString()
        {
            return $"{Title} | {Url}\n | {AccessTime}";
        }
    }

    public enum CompareBy
    {
        AlphabetTitle,
        AlphabetUrl,
        Chronological
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
        public string Path;
    }
}
