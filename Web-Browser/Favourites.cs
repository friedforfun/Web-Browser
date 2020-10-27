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
        private static readonly Lazy<Favourites> singleton = new Lazy<Favourites>(() => new Favourites());

        public static Favourites Instance { get => singleton.Value; }

        private Favourites(): base("Favourites")
        {
            HomeUrl = Properties.Settings.Default.HomeURL;
        }

        public override void KeyExists(ArgumentException e, EntryElement element, bool write)
        {
            // Key already exists / null key
            MessageBox.Show("A favourite with this title already exists.\n Try to add a custom favourite with a new name", "Add Favourites Error");
        }

        public void SetHomeURL(string url)
        {
            HomeUrl = url;
            Properties.Settings.Default.HomeURL = url;
            Properties.Settings.Default.Save();
        }

    }
}

