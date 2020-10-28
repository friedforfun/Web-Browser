using Microsoft.VisualStudio.TestTools.UnitTesting;
using Web_Browser;

namespace BrowserTests
{
    [TestClass]
    public class PageHistoryTests
    {

        [TestMethod]
        public void Test_IsEmpty_False()
        {
            PageContent.PageHistory e = new PageContent.PageHistory("http://www.duckduckgo.com", "A");

            Assert.AreEqual(e.IsEmpty, false, "It should be false");
        }

        [TestMethod]
        public void Test_CanStepForwards_True()
        {
            PageContent.PageHistory e = new PageContent.PageHistory("http://www.duckduckgo.com", "A");
            e.NewPage("http://www.duckduckgo.com", "B");
            e.StepBack();

            Assert.AreEqual(e.CanStepForward, true, "It should be true");
        }

        [TestMethod]
        public void Test_CanStepForwards_False()
        {
            PageContent.PageHistory e = new PageContent.PageHistory("http://www.duckduckgo.com", "A");

            Assert.AreEqual(e.CanStepForward, false, "It should be false");
        }

        [TestMethod]
        public void Test_CanStepBack_True()
        {
            PageContent.PageHistory e = new PageContent.PageHistory("http://www.duckduckgo.com", "A");
            e.NewPage("http://www.duckduckgo.com", "B");

            Assert.AreEqual(e.CanStepBack, true, "It should be true");
        }

        [TestMethod]
        public void Test_CanStepBack_False()
        {
            PageContent.PageHistory e = new PageContent.PageHistory("http://www.duckduckgo.com", "A");

            Assert.AreEqual(e.CanStepForward, false, "It should be false");
        }

        [TestMethod]
        public void Test_GetUrl()
        {
            PageContent.PageHistory e = new PageContent.PageHistory("http://www.duckduckgo.com", "A");
            Assert.AreEqual(e.GetUrl, "http://www.duckduckgo.com", "First Url should match");
            e.NewPage("http://www.google.com", "B");

            Assert.AreEqual(e.GetUrl, "http://www.google.com", "Second Url should match");
        }

        [TestMethod]
        public void Test_GetTitle()
        {
            PageContent.PageHistory e = new PageContent.PageHistory("http://www.duckduckgo.com", "A");
            Assert.AreEqual(e.GetTitle, "A", "First Title should match");
            e.NewPage("http://www.google.com", "B");

            Assert.AreEqual(e.GetTitle, "B", "Second Title should match");
        }

    }
}
