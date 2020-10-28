using Microsoft.VisualStudio.TestTools.UnitTesting;
using Web_Browser;

namespace BrowserTests
{
    [TestClass]
    public class PageContentTests
    {
        [TestMethod]
        public async void Test_Status_200()
        {
            History h = History.InstanceNoFileWrite;
            Favourites f = Favourites.InstanceNoFileWrite;
            PageContent e = await PageContent.AsyncCreate("http://httpstat.us/200", h, f);

            Assert.AreEqual(e.StatusCode, 200, "It should be 200");
        }

        [TestMethod]
        public async void Test_Status_400()
        {
            History h = History.InstanceNoFileWrite;
            Favourites f = Favourites.InstanceNoFileWrite;
            PageContent e = await PageContent.AsyncCreate("http://httpstat.us/400", h, f);

            Assert.AreEqual(e.StatusCode, 400, "It should be 400");
        }

    }
}
