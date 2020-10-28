using Microsoft.VisualStudio.TestTools.UnitTesting;
using Web_Browser;

namespace BrowserTests
{
    [TestClass]
    public class PageEntryTests
    {
        [TestMethod]
        public void Test_EntryBack_Null()
        {
            PageContent.PageHistory.PageEntry e = new PageContent.PageHistory.PageEntry("http://www.duckduckgo.com", "A");

            Assert.AreSame(e.Back, null, "It should be null");
        }

        [TestMethod]
        public void Test_EntryForwards_Null()
        {
            PageContent.PageHistory.PageEntry e = new PageContent.PageHistory.PageEntry("http://www.duckduckgo.com", "A");

            Assert.AreSame(e.Forwards, null, "It should be null");
        }

        [TestMethod]
        public void Test_EntryBack_Entry()
        {
            PageContent.PageHistory.PageEntry e = new PageContent.PageHistory.PageEntry("http://www.duckduckgo.com", "A");
            PageContent.PageHistory.PageEntry f = new PageContent.PageHistory.PageEntry("http://www.duckduckgo.com", "B");

            e.Back = f;

            Assert.AreSame(e.Back, f, "It should be f");
        }

        [TestMethod]
        public void Test_EntryForwards_Entry()
        {
            PageContent.PageHistory.PageEntry e = new PageContent.PageHistory.PageEntry("http://www.duckduckgo.com", "A");
            PageContent.PageHistory.PageEntry f = new PageContent.PageHistory.PageEntry("http://www.duckduckgo.com", "B");

            e.Forwards = f;

            Assert.AreSame(e.Forwards, f, "It should be f");
        }

        [TestMethod]
        public void Test_EntryURL_String()
        {
            PageContent.PageHistory.PageEntry e = new PageContent.PageHistory.PageEntry("http://www.duckduckgo.com", "A");

            Assert.AreSame(e.Back, null, "It should be null");
        }

        [TestMethod]
        public void Test_EntryTitle_String()
        {
            PageContent.PageHistory.PageEntry e = new PageContent.PageHistory.PageEntry("http://www.duckduckgo.com", "A");

            Assert.AreSame(e.Forwards, null, "It should be null");
        }

    }
}
