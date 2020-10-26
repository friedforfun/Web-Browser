using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Web_Browser
{
    public sealed class History : EntryRecord
    {

        private static readonly Lazy<History> singleton = new Lazy<History>(() => new History());

        public static History Instance { get { return singleton.Value; } }

        private History(): base("History")
        {
            
        }

        public override void KeyExists(ArgumentException e, EntryElement element, bool write)
        {
            // Key already exists / null key
            // add new entry with suffix (n) if (n-1) exists
            // else add new entry with suffix (1)
            string key = element.Title;
            int i = 0;
            foreach(EntryElement k in GetList())
            {
                if (k.Title.StartsWith(key))
                {
                    i++;
                }
            }
            //List<string> existingKeys = GetKeys().FindAll(k => k.StartsWith(key));
            StringBuilder sb = new StringBuilder(key);
            sb.Append($" ({i+1})");
            string newKey = sb.ToString();

            Console.WriteLine($"History Key collision.\nChanged: {key} -> {newKey}");

            AddEntry(element.Url, newKey, write);

        }

    }
}
