using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Web_Browser;

namespace BrowserTests
{
    [TestClass]
    public class EntryRecordTests
    {

        [TestMethod]
        public void Add_ToEmpty_List()
        {
            EntryRecord h = new EntryRecord("Test", CompareBy.AlphabetTitle, false);
            EntryElement e = new EntryElement("http://www.duckduckgo.com", "DuckDuckGo");
            h.AddEntry("http://www.duckduckgo.com", "DuckDuckGo", false);
            Assert.AreEqual(h.GetList()[0].Title, e.Title, "Title mismatch in Add_ToEmpty_History");
            Assert.AreEqual(h.GetList()[0].Url, e.Url, "URL mismatch in ADD_ToEmpty_History");
            Assert.AreEqual(h.GetList().Count, 1, "List Size mismatch");
        }

        [TestMethod]
        public void AddAlt_ToEmpty_List()
        {
            EntryRecord h = new EntryRecord("Test", CompareBy.AlphabetTitle, false);
            EntryElement e = new EntryElement("http://www.duckduckgo.com", "DuckDuckGo");
            h.AddEntry(e, false);
            Assert.AreEqual(h.GetList()[0].Title, "DuckDuckGo", "Title mismatch in Add_ToEmpty_History");
            Assert.AreEqual(h.GetList()[0].Url, "http://www.duckduckgo.com", "URL mismatch in ADD_ToEmpty_History");
            Assert.AreEqual(h.GetList().Count, 1, "List Size mismatch");
        }

        [TestMethod]
        public void Add_EmptyTitleTo_List()
        {
            EntryRecord h = new EntryRecord("Test", CompareBy.AlphabetTitle, false);
            h.AddEntry("http://www.duckduckgo.com", "", false);
            Assert.AreEqual(h.GetList()[0].Title, "http://www.duckduckgo.com", "Title mismatch in Add_ToEmpty_History");
            Assert.AreEqual(h.GetList()[0].Url, "http://www.duckduckgo.com", "URL mismatch in ADD_ToEmpty_History");
            Assert.AreEqual(h.GetList().Count, 1, "List Size mismatch");
        }

        [TestMethod]
        public void Remove_FromEmpty_History()
        {
            EntryRecord h = new EntryRecord("Test", CompareBy.AlphabetTitle, false);
            EntryElement e = new EntryElement("http://www.duckduckgo.com", "DuckDuckGo");

            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => h.RemoveEntry("DuckDuckGo", false, false));
        }

        [TestMethod]
        public void Remove_EntryFrom_History()
        {
            EntryRecord h = new EntryRecord("Test", CompareBy.AlphabetTitle, false);
            EntryElement e = new EntryElement("http://www.duckduckgo.com", "DuckDuckGo");
            h.AddEntry(e, false);
            Assert.AreSame(h.GetList()[0], e);
            h.RemoveEntry("DuckDuckGo", false, false);
            Assert.AreEqual(h.GetList().Count, 0);
        }

        [TestMethod]
        public void Check_KeyExists_NotImplemented()
        {
            EntryRecord h = new EntryRecord("Test", CompareBy.AlphabetTitle, false);

            // Key exists must be implemented by derived classes
            Assert.ThrowsException<System.NotImplementedException>(() => h.KeyExists(null, null, false));
        }
    }
}
