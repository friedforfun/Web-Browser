﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Browser
{
    /// <summary>
    /// Abstract History class
    /// </summary>
    abstract class History
    {
        /// <summary>
        /// The head of the History list
        /// </summary>
        protected abstract Entry Head { get; set; }

        /// <summary>
        /// Add a new entry to the head of the history list
        /// </summary>
        /// <param name="e">The new entry to be added</param>
        protected abstract void AddEntry(Entry e);



    }

    /// <summary>
    /// A Node in the History class.
    /// Each entry has: URL, Access Date, HTML title
    /// </summary>
    abstract class Entry
    {
        protected abstract string Url { get; }
        protected abstract string Title { get; }
        protected abstract DateTime AccessTime { get; }

        /// <summary>
        /// The entry chronologically after this Entry
        /// </summary>
        public abstract Entry Forwards { get; set; }

        /// <summary>
        /// The entry chronologically before this Entry
        /// </summary>
        public abstract Entry Back { get; set; }
    }
}