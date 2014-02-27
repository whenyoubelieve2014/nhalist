using Microsoft.VisualStudio.TestTools.UnitTesting;
using NhaList.Controllers.API;
using NhaList.Models;

namespace UnitTestProject
{
    [TestClass]
    public class GeoSearchControllerTest
    {
        [TestMethod]
        public void GetTest_WhenSearchForSavedAddresses_Found()
        {
            searchAndFound("dc");
            searchAndFound("vienna");
        }

        private void searchAndFound(string address)
        {
            using (var target = new GeoSearchController(new NhaListEntityProvider(new NhaListEntities())))
            {
                GeoSearch actual = target.Get(address);
                Assert.IsNotNull(actual);
            }
        }
    }
}