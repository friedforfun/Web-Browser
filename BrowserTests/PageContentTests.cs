using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Web_Browser;

namespace BrowserTests
{
    [TestClass]
    public sealed class PageContentTests
    {

        public async Task<PageContent> instantiatePageContent(string url)
        {
            History h = History.InstanceNoFileWrite;
            Favourites f = Favourites.InstanceNoFileWrite;
            return await PageContent.AsyncCreate(url, h, f);
        }

        [TestMethod]
        public async Task Test_Status_200()
        {
            PageContent e = await instantiatePageContent("http://httpstat.us/200");

            Assert.AreEqual(e.StatusCode, 200, "It should be 200");
            Assert.AreEqual(e.StatusMessage, "200: Ok", "Incorrect Message");
        }

        [TestMethod]
        public async Task Test_Status_400()
        {
            PageContent e = await instantiatePageContent("http://httpstat.us/400");

            Assert.AreEqual(e.StatusCode, 400, "It should be 400");
            Assert.AreEqual(e.StatusMessage, "400: Bad Request", "Incorrect Message");
        }

        [TestMethod]
        public async Task Test_Status_403()
        {
            PageContent e = await instantiatePageContent("http://httpstat.us/403");

            Assert.AreEqual(e.StatusCode, 403, "It should be 403");
            Assert.AreEqual(e.StatusMessage, "403: Forbidden", "Incorrect Message");
        }

        [TestMethod]
        public async Task Test_Status_404()
        {
            PageContent e = await instantiatePageContent("http://httpstat.us/404");

            Assert.AreEqual(e.StatusCode, 404, "It should be 404");
            Assert.AreEqual(e.StatusMessage, "404: Not Found", "Incorrect Message");
        }

        [TestMethod]
        public async Task Test_Navigate_Success()
        {
            bool waiting = true;
            PageContent e = await instantiatePageContent("http://httpstat.us/200");
            e.ContextChanged += delegate { waiting = false; };
            waiting = true;
            e.Navigate("http://duckduckgo.com");

            while (waiting)
            {
                await Task.Delay(10);
            }
            

            Assert.AreEqual(e.StatusCode, 200, "It should be 200");
            Assert.AreEqual(e.StatusMessage, "200: Ok", "Incorrect Message");
        }

    }
}
