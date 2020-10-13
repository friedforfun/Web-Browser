using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_Browser
{
    /// <summary>
    /// Abstract History navigation class for back/forwards buttons
    /// </summary>
    public abstract class HistoryNav
    {
        /// <summary>
        /// The head of the History list
        /// </summary>
        protected abstract HistoryEntry Head { get; set; }

        /// <summary>
        /// Add a new entry to the head of the history list
        /// </summary>
        /// <param name="e">The new entry to be added</param>
        protected abstract void AddEntry(HistoryEntry e);

    }

    public abstract class HistoryEntry: Entry
    {
        /// <summary>
        /// The entry chronologically after this Entry
        /// </summary>
        public abstract HistoryEntry Forwards { get; set; }

        /// <summary>
        /// The entry chronologically before this Entry
        /// </summary>
        public abstract HistoryEntry Back { get; set; }  
    }

    /// <summary>
    /// A Node in History/Favourites .
    /// Each entry has: URL, Access Date, HTML title
    /// </summary>
    public abstract class Entry
    {
        public abstract string Url { get; }
        public abstract string Title { get; }
        public abstract DateTime AccessTime { get; }


    }
}
