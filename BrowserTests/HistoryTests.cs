using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Web_Browser;

namespace BrowserTests
{
    [TestClass]
    public class HistoryUnitTests
    {
        [TestMethod]
        public void Instantiate_Multiple_History()
        {
            History h = History.InstanceNoFileWrite;
            History hi = History.InstanceNoFileWrite;
            Assert.AreSame(h, hi, "Instances of history are not the same object");
        }

        [TestMethod]
        public void Test_KeyExists_Method()
        {
            History h = History.InstanceNoFileWrite;
            h.AddEntry("http://www.duckduckgo.com", "DuckDuckGo", false);
            h.AddEntry("http://www.duckduckgo.com", "DuckDuckGo", false);
            Assert.AreEqual(h.GetList()[0].Title, "DuckDuckGo");
            Assert.AreEqual(h.GetList()[1].Title, "DuckDuckGo (2)");
        }



    }
}
