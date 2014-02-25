using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NhaList;
using NhaList.Controllers.API;

namespace UnitTestProject
{
    [TestClass]
    public class UnityBootstrapTest
    {
        [TestMethod]
        public void RegisterTypesTest()
        {
            var target = new UnityBootstrap();
            IUnityContainer container = new UnityContainer();
            target.RegisterTypes(container);
            var provider = container.Resolve<INhaListEntityProvider>();
            Assert.IsInstanceOfType(provider, typeof (NhaListEntityProvider));
        }

        [TestMethod]
        public void InitialiseTest()
        {
            var target = new UnityBootstrap();
            var container = target.Initialise();
            var controller = container.Resolve<GeoSearchController>();
            Assert.IsNotNull(controller);
            Assert.IsInstanceOfType(controller, typeof(GeoSearchController));
        }
    }
}