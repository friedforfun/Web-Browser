using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Web_Browser;

namespace BrowserTests
{
    [TestClass]
    public class FavouritesUnitTests
    {
        [TestMethod]
        public void Instantiate_Multiple_History()
        {
            Favourites h = Favourites.InstanceNoFileWrite;
            Favourites hi = Favourites.InstanceNoFileWrite;
            Assert.AreSame(h, hi, "Instances of Favourites are not the same object");
        }

        [TestMethod]
        public void Set_Home_URL()
        {
            Favourites h = Favourites.InstanceNoFileWrite;
            h.SetHomeURL("http://www.example.com");
            Assert.AreEqual(h.HomeUrl, "http://www.example.com", "Home URL not being set correctly");
        }


        [TestMethod]
        public void Test_KeyExists_Method()
        {
            Favourites h = Favourites.InstanceNoFileWrite;
            h.AddEntry("http://www.duckduckgo.com", "DuckDuckGo", false);
            Assert.ThrowsException<System.ArgumentException>(() => h.AddEntry("http://www.duckduckgo.com", "DuckDuckGo", false));

        }



    }
}
