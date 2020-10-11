using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Web_Browser
{
    public static class Favourites
    {
        private static SortedList<string, FavouriteEntry> FavCollection = new SortedList<string, FavouriteEntry>();
        public static string HomeUrl = "http://www.google.com";

        // "Do nothing" delegate to prevent race conditions:
        // https://stackoverflow.com/questions/289002/how-to-raise-custom-event-from-a-static-class
        public static event EventHandler<FavouritesChangedArgs> FavouriteChanged = delegate { };

        public static void AddEntry(string url, string title)
        {   
            FavouriteEntry nextEntry = new FavouriteEntry(url, title);
            try
            {
                FavCollection.Add(title, nextEntry);
                // Setup & trigger event
                OnFavouriteChanged(title, ARU.Added);
            }
            catch (ArgumentException)
            {
                // Key already exists / null key
                MessageBox.Show("A favourite with this title already exists.", "Add Favourite Error");
            }
        }

        public static void RemoveEntry(string title)
        {
            FavCollection.Remove(title);

            // Setup & trigger event
            OnFavouriteChanged(title, ARU.Removed);
        }

        public static IList<string> GetFavouriteTitles()
        {
            return FavCollection.Keys;
        }

        public static void EditEntryUrl(string title, string url)
        {
            FavouriteEntry nextEntry = new FavouriteEntry(url, title, GetTime(title));
            RemoveEntry(title);
            FavCollection.Add(title, nextEntry);

            // Setup & trigger event
            OnFavouriteChanged(title, ARU.Updated);
        }

        public static void EditEntryTitle(string title, string nextTitle)
        {
            FavouriteEntry nextEntry = new FavouriteEntry(GetUrl(title), nextTitle, GetTime(title));
            RemoveEntry(title);
            FavCollection.Add(nextTitle, nextEntry);

            // Setup & trigger event
            OnFavouriteChanged(title, ARU.Updated);
        }

        public static void EditEntry(string title, string nextTitle, string nextUrl)
        {
            FavouriteEntry nextEntry = new FavouriteEntry(nextUrl, nextTitle, GetTime(title));
            RemoveEntry(title);
            FavCollection.Add(nextTitle, nextEntry);

            // Setup & trigger event
            OnFavouriteChanged(title, ARU.Updated);
        }

        public static string GetUrl(string title)
        {
            return FavCollection[title].Url;
        }

        public static DateTime GetTime(string title)
        {
            return FavCollection[title].AccessTime;
        }

        static void OnFavouriteChanged(string title, ARU state)
        {
            FavouritesChangedArgs updatedEntry = new FavouritesChangedArgs();
            updatedEntry.AddRemUpd = state;
            updatedEntry.EntryKey = title;
            EventHandler<FavouritesChangedArgs> handler = FavouriteChanged;
            // handler never null so no need to check if null
            handler(null, updatedEntry);
        }

        private class FavouriteEntry : Entry
        {

            // when editing instantiate a new favourite and delete this one
            private readonly string _url;
            private readonly string _title;
            private readonly DateTime _accessTime;

            public override string Url => _url;

            public override string Title => _title;

            public override DateTime AccessTime => _accessTime;

            public FavouriteEntry(string url, string title)
            {
                _url = url;
                _title = title;
                _accessTime = DateTime.Now;
            }

            public FavouriteEntry(string url, string title, DateTime time)
            {
                _url = url;
                _title = title;
                _accessTime = time;
            }
        }
    }

    public enum ARU
    {
        Removed,
        Updated,
        Added
    }

    public class FavouritesChangedArgs : EventArgs
    {
        public ARU AddRemUpd;
        public string EntryKey;
    }
}
