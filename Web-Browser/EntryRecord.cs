using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace Web_Browser
{
    /// <summary>
    /// Interface used to write an Entry of sorted list type to XML by converting to array
    /// </summary>
    /// <typeparam name="T">Type implementing the Entry class</typeparam>
    interface ICanWriteXML<T> where T : Entry
    {
        T[] GetList();
       // void SetList(T[] list);
    }

    /// <summary>
    /// An entry record used for History and Favourites collection
    /// </summary>
    
    [DataContract]
    public class EntryRecord : ICanWriteXML<EntryElement>
    {
        [XmlIgnore]
        private SortedList<string, EntryElement> EntryCollection = new SortedList<string, EntryElement>();

        [DataMember]
        public EntryElement[] serialiser
        {
            get => GetList();
            set => SetList(value);
        }

        public event EventHandler<EntryRecordChanged> EntryChanged = delegate { };

        [XmlIgnore]
        private Persistance<EntryElement> persistanceManager;

        public EntryRecord(string filename)
        {
            persistanceManager = new Persistance<EntryElement>(filename);
        }

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
                if (title != "")
                {
                    EntryCollection.Add(title, nextEntry);
                    OnEntryChanged(title, ARU.Added);
                } else
                {
                    EntryCollection.Add(url, nextEntry);
                    OnEntryChanged(url, ARU.Added);
                }
                // Setup & trigger event

            }
            catch (ArgumentException)
            {
                // Key already exists / null key
                MessageBox.Show("A favourite with this title already exists.", "Add Favourite Error");
            }
        }


        public EntryElement[] GetList()
        {
            EntryElement[] list = new EntryElement[EntryCollection.Count];
            int i = 0;
            foreach (string key in EntryCollection.Keys)
            {
                EntryElement ele = EntryCollection[key];
                list[i] = ele;
                i++;
            }
            return list;
        }

        public void SetList(EntryElement[] list)
        {
            EntryCollection.Clear();
            for (int i = 0; i < list.Length; i++)
            {
                EntryCollection.Add(list[i].Title, list[i]);
            }
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

        public IList<string> GetTitles()
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
            WriteSerializedCollection();
        }


        public void WriteSerializedCollection()
        {
            persistanceManager.SerizalizeCollection(EntryCollection);
        }

    }
    [KnownType(typeof(EntryElement[]))]
    [DataContract]
    public class EntryElement : Entry
    {

        // when editing instantiate a new favourite and delete this one
        [DataMember]
        private string _url;
        [DataMember]
        private string _title;
        [DataMember]
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
        public ARU AddRemUpd;
        public string EntryKey;
    }
}
