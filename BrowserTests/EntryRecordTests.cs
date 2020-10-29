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
            EntryElement e = new EntryElement("http://www.duckduckgo.com", "DuckDuckGo", CompareBy.AlphabetTitle);
            h.AddEntry("http://www.duckduckgo.com", "DuckDuckGo", false);
            Assert.AreEqual(h.GetList()[0].Title, e.Title, "Title mismatch in Add_ToEmpty_History");
            Assert.AreEqual(h.GetList()[0].Url, e.Url, "URL mismatch in ADD_ToEmpty_History");
            Assert.AreEqual(h.GetList().Count, 1, "List Size mismatch");
        }

        [TestMethod]
        public void AddAlt_ToEmpty_List()
        {
            EntryRecord h = new EntryRecord("Test", CompareBy.AlphabetTitle, false);
            EntryElement e = new EntryElement("http://www.duckduckgo.com", "DuckDuckGo", CompareBy.AlphabetTitle);
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
        public void Remove_FromEmpty_EntryRecord()
        {
            EntryRecord h = new EntryRecord("Test", CompareBy.AlphabetTitle, false);
            EntryElement e = new EntryElement("http://www.duckduckgo.com", "DuckDuckGo", CompareBy.AlphabetTitle);

            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => h.RemoveEntry("DuckDuckGo", false, false));
        }

        [TestMethod]
        public void Remove_EntryFrom_EntryRecord()
        {
            EntryRecord h = new EntryRecord("Test", CompareBy.AlphabetTitle, false);
            EntryElement e = new EntryElement("http://www.duckduckgo.com", "DuckDuckGo", CompareBy.AlphabetTitle);
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

        [TestMethod]
        public void Clear_EntryRecord_EntryRecord()
        {
            EntryRecord h = new EntryRecord("Test", CompareBy.AlphabetTitle, false);
            EntryElement e = new EntryElement("http://www.duckduckgo.com", "DuckDuckGo", CompareBy.AlphabetTitle);
            h.AddEntry(e, false);
            Assert.AreSame(h.GetList()[0], e, "Expected Object and Actual object are not the same");
            Assert.AreEqual(h.GetList().Count, 1, "List size of 1 expected");
            h.ClearList(false);
            Assert.AreEqual(h.GetList().Count, 0, "List size of 0 expected");
        }

        [TestMethod]
        public void GetList_Test_EntryRecord()
        {
            EntryRecord h = new EntryRecord("Test", CompareBy.AlphabetTitle, false);
            List<EntryElement> list = new List<EntryElement>();
            EntryElement e1 = new EntryElement("http://www.duckduckgo.com", "DuckDuckGo", CompareBy.AlphabetTitle);
            EntryElement e2 = new EntryElement("http://www.duckduckgo.com", "DuckDuckGo2", CompareBy.AlphabetTitle);
            EntryElement e3 = new EntryElement("http://www.duckduckgo.com", "DuckDuckGo3", CompareBy.AlphabetTitle);
            EntryElement e4 = new EntryElement("http://www.duckduckgo.com", "DuckDuckGo4", CompareBy.AlphabetTitle);

            Assert.AreEqual(h.GetList().Count, list.Count, "List size 0 expected");

            h.AddEntry(e1, false);
            h.AddEntry(e2, false);
            h.AddEntry(e3, false);
            h.AddEntry(e4, false);

            
            list.Add(e1);
            list.Add(e2);
            list.Add(e3);
            list.Add(e4);

            Assert.AreNotSame(h.GetList(), list, "Expected Object and Actual object are the same");
            Assert.AreEqual(h.GetList().Count, list.Count, "List size 4 expected");
            for (int i = 0; i < list.Count; i++)
            {
                Assert.AreSame(h.GetList()[i], list[i], "Expected Object and Actual object are not the same");
            }
        }

        [TestMethod]
        public void Test_EditEntryUrl_EntryRecord()
        {
            EntryRecord h = new EntryRecord("Test", CompareBy.AlphabetTitle, false);
            EntryElement e = new EntryElement("http://www.duckduckgo.com", "DuckDuckGo", CompareBy.AlphabetTitle);

            h.AddEntry(e, false);
            Assert.AreEqual(h.GetUrl("DuckDuckGo"), "http://www.duckduckgo.com", "Expected and Actual URL mismatch");

            h.EditEntryUrl("DuckDuckGo", "http://www.google.com", false);
            Assert.AreEqual(h.GetUrl("DuckDuckGo"), "http://www.google.com", "Expected and Actual URL mismatch");
        }

        [TestMethod]
        public void Test_EditEntryUrlException_EntryRecord()
        {
            EntryRecord h = new EntryRecord("Test", CompareBy.AlphabetTitle, false);
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => h.EditEntryUrl("DuckDuckGo", "http://www.google.com", false));
        }

        [TestMethod]
        public void Test_EditEntryTitle_EntryRecord()
        {
            EntryRecord h = new EntryRecord("Test", CompareBy.AlphabetTitle, false);
            EntryElement e = new EntryElement("http://www.duckduckgo.com", "DuckDuckGo", CompareBy.AlphabetTitle);

            h.AddEntry(e, false);
            Assert.AreEqual(h.GetList()[0].Title, "DuckDuckGo", "Expected and Actual Title mismatch");

            h.EditEntryTitle("DuckDuckGo", "DifferentTitle", false);
            Assert.AreEqual(h.GetList()[0].Title, "DifferentTitle", "Expected and Actual Title mismatch");
        }

        [TestMethod]
        public void Test_EditEntryTitleException_EntryRecord()
        {
            EntryRecord h = new EntryRecord("Test", CompareBy.AlphabetTitle, false);
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => h.EditEntryTitle("DuckDuckGo", "DifferentTitle", false));
        }

        [TestMethod]
        public void Test_EditEntryParams_EntryRecord()
        {
            EntryRecord h = new EntryRecord("Test", CompareBy.AlphabetTitle, false);
            EntryElement e = new EntryElement("http://www.duckduckgo.com", "DuckDuckGo", CompareBy.AlphabetTitle);

            h.AddEntry(e, false);
            Assert.AreEqual(h.GetList()[0].Title, "DuckDuckGo", "Expected and Actual Title mismatch");
            Assert.AreEqual(h.GetList()[0].Url, "http://www.duckduckgo.com", "Expected and Actual Title mismatch");

            h.EditEntry("DuckDuckGo", "DifferentTitle", "http://www.google.com", false);
            Assert.AreEqual(h.GetList()[0].Title, "DifferentTitle", "Expected and Actual Title mismatch");
            Assert.AreEqual(h.GetList()[0].Url, "http://www.google.com", "Expected and Actual Title mismatch");
        }

        [TestMethod]
        public void Test_EditEntryParamsException_EntryRecord()
        {
            EntryRecord h = new EntryRecord("Test", CompareBy.AlphabetTitle, false);
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => h.EditEntry("DuckDuckGo", "DifferentTitle", "http://www.google.com", false));
        }

        [TestMethod]
        public void Test_EditEntryObject_EntryRecord()
        {
            EntryRecord h = new EntryRecord("Test", CompareBy.AlphabetTitle, false);
            EntryElement e = new EntryElement("http://www.duckduckgo.com", "DuckDuckGo", CompareBy.AlphabetTitle);
            
            h.AddEntry(e, false);
            Assert.AreEqual(h.GetList()[0].Title, "DuckDuckGo", "Expected and Actual Title mismatch");
            Assert.AreEqual(h.GetList()[0].Url, "http://www.duckduckgo.com", "Expected and Actual Title mismatch");

            EntryElement u = new EntryElement("http://www.google.com", "DuckDuckGo", CompareBy.AlphabetTitle);

            h.EditEntry(u, false);
            Assert.AreEqual(h.GetList()[0].Title, "DuckDuckGo", "Expected and Actual Title mismatch");
            Assert.AreEqual(h.GetList()[0].Url, "http://www.google.com", "Expected and Actual Title mismatch");
            Assert.AreEqual(h.GetList().Count, 1, "List size of 1 expected");
        }

        [TestMethod]
        public void Test_EditEntryObjectException_EntryRecord()
        {
            EntryRecord h = new EntryRecord("Test", CompareBy.AlphabetTitle, false);
            EntryElement e = new EntryElement("http://www.duckduckgo.com", "DuckDuckGo", CompareBy.AlphabetTitle);
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => h.EditEntry(e, false));
        }

        [TestMethod]
        public void Test_GetUrl_EntryRecord()
        {
            EntryRecord h = new EntryRecord("Test", CompareBy.AlphabetTitle, false);
            EntryElement e = new EntryElement("http://www.duckduckgo.com", "DuckDuckGo", CompareBy.AlphabetTitle);
            h.AddEntry(e, false);

            Assert.AreEqual(h.GetUrl("DuckDuckGo"), "http://www.duckduckgo.com", "Expected and Actual URL mismatch");
        }

        [TestMethod]
        public void Test_GetUrlException_EntryRecord()
        {
            EntryRecord h = new EntryRecord("Test", CompareBy.AlphabetTitle, false);
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => h.GetUrl("DuckDuckGo"));
        }

        [TestMethod]
        public void Test_GetTime_EntryRecord()
        {
            EntryRecord h = new EntryRecord("Test", CompareBy.AlphabetTitle, false);
            EntryElement e = new EntryElement("http://www.duckduckgo.com", "DuckDuckGo", CompareBy.AlphabetTitle);
            h.AddEntry(e, false);

            string time = e.AccessTime.ToString();

            Assert.AreEqual(h.GetTime("DuckDuckGo").ToString(), time, "Expected and Actual Time string mismatch"); 
        }

        [TestMethod]
        public void Test_GetTimeException_EntryRecord()
        {
            EntryRecord h = new EntryRecord("Test", CompareBy.AlphabetTitle, false);
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => h.GetTime("DuckDuckGo"));
        }


        [TestMethod]
        public void Test_GetIndex_EntryRecord()
        {
            EntryRecord h = new EntryRecord("Test", CompareBy.AlphabetTitle, false);
            EntryElement e1 = new EntryElement("http://www.duckduckgo.com", "DuckDuckGo", CompareBy.AlphabetTitle);
            EntryElement e2 = new EntryElement("http://www.duckduckgo.com", "DuckDuckGo2", CompareBy.AlphabetTitle);
            EntryElement e3 = new EntryElement("http://www.duckduckgo.com", "DuckDuckGo3", CompareBy.AlphabetTitle);
            EntryElement e4 = new EntryElement("http://www.duckduckgo.com", "DuckDuckGo4", CompareBy.AlphabetTitle);
            h.AddEntry(e1, false);
            h.AddEntry(e2, false);
            h.AddEntry(e3, false);
            h.AddEntry(e4, false);

            Assert.AreEqual(h.GetIndex("DuckDuckGo3"), 2, "Expected and Actual index mismatch");
            Assert.AreEqual(h.GetIndex("DuckDuckGo4"), 3, "Expected and Actual index mismatch");
            Assert.AreEqual(h.GetIndex("DuckDuckGo"), 0, "Expected and Actual index mismatch");
            Assert.AreEqual(h.GetIndex("DuckDuckGo2"), 1, "Expected and Actual index mismatch");

        }

        [TestMethod]
        public void Test_GetIndexException_EntryRecord()
        {
            EntryRecord h = new EntryRecord("Test", CompareBy.AlphabetTitle, false);
            Assert.AreEqual(h.GetIndex("DuckDuckGo"), -1, "This index wasnt -1");
        }

        [TestMethod]
        public void Test_GetEntry_EntryRecord()
        {
            EntryRecord h = new EntryRecord("Test", CompareBy.AlphabetTitle, false);
            EntryElement e = new EntryElement("http://www.duckduckgo.com", "DuckDuckGo", CompareBy.AlphabetTitle);
            h.AddEntry(e, false);

            Assert.AreSame(h.GetEntry(0), e, "Expected and Actual Object mismatch"); 
        }

        [TestMethod]
        public void Test_GetEntryException_EntryRecord()
        {
            EntryRecord h = new EntryRecord("Test", CompareBy.AlphabetTitle, false);
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => h.GetEntry(0));
        }

        [TestMethod]
        public void Test_EventAddEntry_EntryRecord()
        {
            bool eventTriggered = false;
            EntryRecord h = new EntryRecord("Test", CompareBy.AlphabetTitle, false);
            h.EntryChanged += delegate {  eventTriggered = true; };
            EntryElement e = new EntryElement("http://www.duckduckgo.com", "DuckDuckGo", CompareBy.AlphabetTitle);
            Assert.AreEqual(eventTriggered, false, "The event should not have triggered");
            h.AddEntry(e, false);
            Assert.AreEqual(eventTriggered, true, "The event should have triggered");
        }

        [TestMethod]
        public void Test_EventRemoveEntry_EntryRecord()
        {
            bool eventTriggered = false;
            EntryRecord h = new EntryRecord("Test", CompareBy.AlphabetTitle, false);
            h.EntryChanged += delegate { eventTriggered = true; };
            EntryElement e = new EntryElement("http://www.duckduckgo.com", "DuckDuckGo", CompareBy.AlphabetTitle);
            Assert.AreEqual(eventTriggered, false, "The event should not have triggered");
            h.AddEntry(e, false);
            Assert.AreEqual(eventTriggered, true, "The event should have triggered");
            eventTriggered = false;
            Assert.AreEqual(eventTriggered, false, "The event should not have triggered");
            h.RemoveEntry("DuckDuckGo", false, true);
            Assert.AreEqual(eventTriggered, true, "The event should have triggered");
        }

        [TestMethod]
        public void Test_EventEditEntry_EntryRecord()
        {
            bool eventTriggered = false;
            EntryRecord h = new EntryRecord("Test", CompareBy.AlphabetTitle, false);
            h.EntryChanged += delegate { eventTriggered = true; };
            EntryElement e = new EntryElement("http://www.duckduckgo.com", "DuckDuckGo", CompareBy.AlphabetTitle);
            Assert.AreEqual(eventTriggered, false, "The event should not have triggered");
            h.AddEntry(e, false);
            Assert.AreEqual(eventTriggered, true, "The event should have triggered");
            eventTriggered = false;
            Assert.AreEqual(eventTriggered, false, "The event should not have triggered");

            EntryElement j = new EntryElement("http://www.google.com", "DuckDuckGo", CompareBy.AlphabetTitle);
            h.EditEntry(j, false);
        }

        [TestMethod]
        public void Test_EventExpectedParams_EntryRecord()
        {
            object sentFrom = null;
            EntryRecordChanged args = null;
            bool eventTriggered = false;
            EntryRecord h = new EntryRecord("Test", CompareBy.AlphabetTitle, false);
            h.EntryChanged += delegate(object sender, EntryRecordChanged e) { eventTriggered = true; sentFrom = sender; args = e; };
            EntryElement e = new EntryElement("http://www.duckduckgo.com", "DuckDuckGo", CompareBy.AlphabetTitle);
            Assert.AreEqual(eventTriggered, false, "The event should not have triggered");
            Assert.AreSame(sentFrom, null, "The event should be null");
            Assert.AreSame(args, null, "The event should be null");
            h.AddEntry(e, false);
            Assert.AreEqual(eventTriggered, true, "The event should have triggered");
            Assert.AreSame(sentFrom, h, "h should be the sender object");
            Assert.AreSame(args.EntryKey, e.Title, "Entry Key should be the title");
            Assert.AreEqual(args.AddRemUpd, ARU.Added, "AddRemUpd should be Added");
            Assert.AreEqual(args.Path, "Test", "Path should match path used when instantiating h");
            Assert.AreEqual(args.WriteFile, false, "WriteFile should be false");

        }


    }


}
