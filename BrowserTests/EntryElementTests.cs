using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Web_Browser;

namespace BrowserTests
{
    [TestClass]
    public class EntryElementTests
    {
        [TestMethod]
        public void Test_ToString()
        {
            EntryElement e = new EntryElement("http://www.duckduckgo.com", "A", CompareBy.AlphabetTitle);

            Assert.AreEqual(e.ToString(), string.Format("A | http://www.duckduckgo.com\n | {0}", e.AccessTime), "It incorrect print format");
        }


        [TestMethod]
        public void Test_CompareTo_Alphabetical_Same()
        {
            EntryElement e = new EntryElement("http://www.duckduckgo.com", "A", CompareBy.AlphabetTitle);
            EntryElement f = new EntryElement("http://www.duckduckgo.com", "A", CompareBy.AlphabetTitle);

            Assert.AreEqual(e.CompareTo(f), 0, "e and f comparison should be 0");
        }

        [TestMethod]
        public void Test_CompareTo_Alphabetical_LessThan()
        {
            EntryElement e = new EntryElement("http://www.duckduckgo.com", "A", CompareBy.AlphabetTitle);
            EntryElement f = new EntryElement("http://www.duckduckgo.com", "B", CompareBy.AlphabetTitle);

            Assert.AreEqual(e.CompareTo(f) < 0, true, "e compared to f should be less than 0");
        }

        [TestMethod]
        public void Test_CompareTo_Alphabetical_GreaterThan()
        {
            EntryElement e = new EntryElement("http://www.duckduckgo.com", "A", CompareBy.AlphabetTitle);
            EntryElement f = new EntryElement("http://www.duckduckgo.com", "B", CompareBy.AlphabetTitle);

            Assert.AreEqual(f.CompareTo(e) > 0, true, "f compared to e should be greater than 0");
        }

        [TestMethod]
        public void Test_CompareTo_Chronological_Same()
        {
            EntryElement e = new EntryElement("http://www.duckduckgo.com", "A", CompareBy.Chronological);
            EntryElement f = new EntryElement("http://www.duckduckgo.com", "A", e.AccessTime, CompareBy.Chronological);

            Assert.AreEqual(e.CompareTo(f), 0, "e and f comparison should be 0");
        }

        [TestMethod]
        public void Test_CompareTo_Chronological_LessThan()
        {
            EntryElement e = new EntryElement("http://www.duckduckgo.com", "A", CompareBy.Chronological);
            EntryElement f = new EntryElement("http://www.duckduckgo.com", "B", CompareBy.Chronological);

            Assert.AreEqual(e.CompareTo(f) < 0, true, "e compared to f should be less than 0");
        }

        [TestMethod]
        public void Test_CompareTo_Chronological_GreaterThan()
        {
            EntryElement e = new EntryElement("http://www.duckduckgo.com", "A", CompareBy.Chronological);
            EntryElement f = new EntryElement("http://www.duckduckgo.com", "B", CompareBy.Chronological);

            Assert.AreEqual(f.CompareTo(e) > 0, true, "f compared to e should be greater than 0");
        }

        [TestMethod]
        public void Test_CompareTo_AlphabeticalUrl_Same()
        {
            EntryElement e = new EntryElement("http://www.duckduckgo.com", "A", CompareBy.AlphabetUrl);
            EntryElement f = new EntryElement("http://www.duckduckgo.com", "A", CompareBy.AlphabetUrl);

            Assert.AreEqual(e.CompareTo(f), 0, "e and f comparison should be 0");
        }

        [TestMethod]
        public void Test_CompareTo_AlphabeticalUrl_LessThan()
        {
            EntryElement e = new EntryElement("http://www.a.com", "A", CompareBy.AlphabetUrl);
            EntryElement f = new EntryElement("http://www.b.com", "B", CompareBy.AlphabetUrl);

            Assert.AreEqual(e.CompareTo(f) < 0, true, "e compared to f should be less than 0");
        }

        [TestMethod]
        public void Test_CompareTo_AlphabeticalUrl_GreaterThan()
        {
            EntryElement e = new EntryElement("http://www.a.com", "A", CompareBy.AlphabetUrl);
            EntryElement f = new EntryElement("http://www.b.com", "B", CompareBy.AlphabetUrl);

            Assert.AreEqual(f.CompareTo(e) > 0, true, "f compared to e should be greater than 0");
        }

    }
}
