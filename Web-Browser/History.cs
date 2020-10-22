using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Web_Browser
{
    public sealed class History : EntryRecord
    {

        private static readonly Lazy<History> singleton = new Lazy<History>(() => new History());

        public static History Instance { get { return singleton.Value; } }

        private History(): base("history")
        {
            
        }

    }
}
