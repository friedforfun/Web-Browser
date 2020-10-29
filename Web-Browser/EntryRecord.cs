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

        private CompareBy _sortStrategy;

        public EntryRecord(string filename, CompareBy sortOrder, bool withPersistence)
        {
            Filename = filename;
            if (withPersistence) persistanceManager = new Persistance<EntryElement>(filename);
            _sortStrategy = sortOrder;
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
                _EntryCollection.Sort();
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

        /// <summary>
        /// Add an already instantiated new entry to the collection
        /// </summary>
        /// <param name="entry"></param>
        /// <param name="write"></param>
        public void AddEntry(EntryElement entry, bool write)
        {
            try
            {
                _EntryCollection.Add(entry);
                _EntryCollection.Sort();
                OnEntryChanged(entry.Title, ARU.Added, write);

            }
            catch (ArgumentException e)
            {
                KeyExists(e, entry, write);
            }
        }

        /// <summary>
        /// Instantiate a new entry, handle empty title case
        /// </summary>
        /// <param name="url"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        private EntryElement instantiateEntry(string url, string title)
        {
            EntryElement nextEntry;
            if (title != "")
            {
                nextEntry = new EntryElement(url, title, _sortStrategy);
            } else
            {
                nextEntry = new EntryElement(url, url, _sortStrategy);
            }
            return nextEntry;
        }

        /// <summary>
        /// Method for child classes to override, called by an event that occurs when an entry title has a name collision
        /// </summary>
        /// <param name="e"></param>
        /// <param name="element"></param>
        /// <param name="write"></param>
        public virtual void KeyExists(ArgumentException e, EntryElement element, bool write)
        {
            // Key already exists / null key
            Console.WriteLine("An element with this key already exists.", "Add Collection Error");
            throw new NotImplementedException();
        }

        /// <summary>
        /// Remove entry from the list, control thrown event
        /// </summary>
        /// <param name="title"></param>
        /// <param name="write"></param>
        /// <param name="bEvent"></param>
        public void RemoveEntry(string title, bool write, bool bEvent)
        {
            int index = GetIndex(title);
            _EntryCollection.RemoveAt(index);
            _EntryCollection.Sort();

            // attempt to update the gui regardless of error state
            if (bEvent)
            {
                OnEntryChanged(title, ARU.Removed, write);
            }
        }
        /// <summary>
        /// clear all elements from the list
        /// </summary>
        /// <param name="write"></param>
        public void ClearList(bool write)
        {
            _EntryCollection.Clear();
            OnEntryChanged(null, ARU.Cleared, write);
        }

        /// <summary>
        /// get the list object
        /// </summary>
        /// <returns></returns>
        public List<EntryElement> GetList()
        {
            _EntryCollection.Sort();
            return _EntryCollection;
        }

        /// <summary>
        /// Edit the url of an entry, use title to find the entry
        /// </summary>
        /// <param name="title"></param>
        /// <param name="url"></param>
        /// <param name="write"></param>
        public void EditEntryUrl(string title, string url, bool write)
        {
            EntryElement nextEntry = new EntryElement(url, title, GetTime(title), _sortStrategy);
            RemoveEntry(title, write, false);
            _EntryCollection.Sort();
            try
            {
                _EntryCollection.Add(nextEntry);
                _EntryCollection.Sort();
                //EntryCollection.Add(title, nextEntry);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Got an argument Exception when attempting to add an element to a list");
            }

            // Setup & trigger event
            OnEntryChanged(title, ARU.Updated, write);
        }

        /// <summary>
        /// Edit the title of an entry
        /// </summary>
        /// <param name="title"></param>
        /// <param name="nextTitle"></param>
        /// <param name="write"></param>
        public void EditEntryTitle(string title, string nextTitle, bool write)
        {
            EntryElement nextEntry = new EntryElement(GetUrl(title), nextTitle, GetTime(title), _sortStrategy);
            RemoveEntry(title, write, false);
            _EntryCollection.Add(nextEntry);
            _EntryCollection.Sort();

            // Setup & trigger event
            OnEntryChanged(title, ARU.Updated, write);
        }

        /// <summary>
        /// Edit the title and url of an entry
        /// </summary>
        /// <param name="title"></param>
        /// <param name="nextTitle"></param>
        /// <param name="nextUrl"></param>
        /// <param name="write"></param>
        public void EditEntry(string title, string nextTitle, string nextUrl, bool write)
        {
            EntryElement nextEntry = new EntryElement(nextUrl, nextTitle, GetTime(title), _sortStrategy);
            RemoveEntry(title, write, false);
            OnEntryChanged(title, ARU.Removed, false);
            _EntryCollection.Add(nextEntry);
            _EntryCollection.Sort();
            //EntryCollection.Add(nextTitle, nextEntry);

            // Setup & trigger event

            OnEntryChanged(nextTitle, ARU.Added, write);
        }

        /// <summary>
        /// Pass an entry object with a title already in the list (use with care)
        /// </summary>
        /// <param name="nextEntry"></param>
        /// <param name="write"></param>
        public void EditEntry(EntryElement nextEntry, bool write)
        {
            string title = nextEntry.Title;   
            RemoveEntry(title, write, false);
            OnEntryChanged(title, ARU.Removed, false);
            _EntryCollection.Add(nextEntry);
            _EntryCollection.Sort();
            //EntryCollection.Add(title, nextEntry);

            // Setup & trigger event
            OnEntryChanged(nextEntry.Title, ARU.Added, write);
        }

        /// <summary>
        /// Get the URL of the entry by its key
        /// </summary>
        /// <param name="title">The title(key) of the entry</param>
        /// <returns>The entry URl</returns>
        public string GetUrl(string title)
        {
            int index = GetIndex(title);
            return _EntryCollection[index].Url;
        }

        /// <summary>
        /// Get the time of the entry with name title
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public DateTime GetTime(string title)
        {
            int index = GetIndex(title);
            return _EntryCollection[index].AccessTime;
        }

        /// <summary>
        /// Get the index in the list of the entry with name title
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public int GetIndex(string title)
        {
            return _EntryCollection.FindIndex(entry => entry.Title.Equals(title));
        }

        /// <summary>
        ///  Get the entry object at the specified index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public EntryElement GetEntry(int index)
        {
            return _EntryCollection[index];
        }

        /// <summary>
        /// Event called whenever a change to the list occurs
        /// </summary>
        /// <param name="title"></param>
        /// <param name="state"></param>
        /// <param name="WriteFile"></param>
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

        /// <summary>
        /// Method to serialize the list
        /// </summary>
        public void SerializeCollection()
        {
            _EntryCollection.Sort();
            persistanceManager.SerializeCollection(_EntryCollection);
        }

        /// <summary>
        /// Method to deserialize the list
        /// </summary>
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
            _EntryCollection.Sort();
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
        public EntryElement(string url, string title, CompareBy comp)
        {
            _url = url;
            _title = title;
            _accessTime = DateTime.Now;
            Compareby = comp;
        }

        public EntryElement(string url, string title, DateTime time, CompareBy comp)
        {
            _url = url;
            _title = title;
            _accessTime = time;
            Compareby = comp;
        }

        public CompareBy Compareby;

        /// <summary>
        /// Implement CompareTo for sorting algorithm
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
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
        Added,
        Cleared
    }

    public class EntryRecordChanged : EventArgs
    {
        public bool WriteFile;
        public ARU AddRemUpd;
        public string EntryKey;
        public string Path;
    }
}
