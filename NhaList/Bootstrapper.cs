using System;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using NhaList.ExtensionMethods;
using NhaList.Models;
using Unity.Mvc4;

namespace NhaList
{
    public class UnityBootstrap
    {
        public static UnityBootstrap Bootstrapper = new UnityBootstrap();

        public IUnityContainer Initialise(HttpConfiguration webApiConfig = null)
        {
            IUnityContainer container = BuildUnityContainer();
            ObjectFactory.DefaultContainer = container;

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            if (webApiConfig != null) webApiConfig.DependencyResolver = new UnityResolver(container);
            return container;
        }


        private IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        }

        public void RegisterTypes(IUnityContainer container)
        {
            IOrderedEnumerable<Type> classes = AllClasses.FromLoadedAssemblies()
                .Where(c => c != typeof (VersionAppender) && c != typeof (NhaListEntities))
                .OrderBy(c => c.FullName);
            container.RegisterTypes(
                classes,
                WithMappings.FromMatchingInterface,
                WithName.Default);

            var singleton = new ContainerControlledLifetimeManager();
            container.RegisterType<IVersionAppender, VersionAppender>(singleton);
            container.RegisterType<INhaListDbContext, NhaListEntities>(new PerThreadLifetimeManager());
        }
    }
}