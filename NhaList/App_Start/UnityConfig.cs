using System.Web.Http;

namespace NhaList
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            UnityBootstrap.Bootstrapper.Initialise(GlobalConfiguration.Configuration);
        }
    }
}