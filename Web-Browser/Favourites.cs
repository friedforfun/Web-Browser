using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Web_Browser
{
    // Sealed to help the JIT compiler optimisation
    public sealed class Favourites : EntryRecord
    {
        public string HomeUrl;

        // Lazy 
        private static readonly Lazy<Favourites> singleton = new Lazy<Favourites>(() => new Favourites(Properties.Settings.Default.HomeURL, true));
        private static readonly Lazy<Favourites> singletonNoFileWrite = new Lazy<Favourites>(() => new Favourites("http://www.duckduckgo.com", false));

        public static Favourites Instance { get => singleton.Value; }
        public static Favourites InstanceNoFileWrite { get => singletonNoFileWrite.Value; }

        private Favourites(string home, bool withPersistance): base("Favourites", CompareBy.AlphabetTitle, withPersistance)
        {
            HomeUrl = home;
        }

        public override void KeyExists(ArgumentException e, EntryElement element, bool write)
        {
            // Key already exists / null key
            // throw error to be handled in ui
            //MessageBox.Show("A favourite with this title already exists.\n Try to add a custom favourite with a new name", "Add Favourites Error");
            throw new ArgumentException("A favourite with this title already exists.");
        }

        public void SetHomeURL(string url)
        {
            HomeUrl = url;
        }

    }
}

