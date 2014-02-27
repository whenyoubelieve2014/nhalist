using System;
using System.Diagnostics;
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
        public const string NAMESPACE_NHALIST = "NhaList";

        public void RegisterTypes(IUnityContainer container)
        {
            //to hit this breakpoint, kill IIS Express
            //Debugger.Break();


            //these types either have special lifetime
            //or needs to be mapped differently than matching names
            var exclusions = new[]
            {
                typeof (VersionProvider).Name //singleton
                , typeof (NhaListEntities).Name //perThread
            };

            IOrderedEnumerable<Type> classes = AllClasses.FromLoadedAssemblies()
                .Where(c =>
                {
                    string name = c.Name;
                    return !exclusions.Contains(name)
                           &&
                           (c.Namespace != null &&
                            c.Namespace.StartsWith(NAMESPACE_NHALIST, StringComparison.OrdinalIgnoreCase))
                            ;
                })
                .OrderBy(c => c.FullName);

            container.RegisterTypes(
                classes,
                WithMappings.FromMatchingInterface,
                WithName.Default);
            Trace.WriteLine(string.Format("Unity registrations: {0}", container.Registrations.Count()));

            foreach (ContainerRegistration registration in container.Registrations)
            {
                Trace.WriteLine(string.Format("{0}-->{1}", registration.RegisteredType.Name,
                    registration.MappedToType.Name));
            }

            var singleton = new ContainerControlledLifetimeManager();
            container.RegisterType<IVersionProvider, VersionProvider>(singleton);
            container.RegisterType<INhaListDbContext, NhaListEntities>(new PerThreadLifetimeManager());
        }
    }
}