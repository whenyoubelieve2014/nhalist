using Microsoft.Practices.Unity;

namespace NhaList.ExtensionMethods
{
    public static class UnityExtension
    {
        internal static UnityContainer DefaultContainer;

        static UnityExtension()
        {
            DefaultContainer = new UnityContainer();
            DefaultContainer.RegisterTypes(
                AllClasses.FromLoadedAssemblies(),
                WithMappings.FromMatchingInterface,
                WithName.Default);
            var singleton = new ContainerControlledLifetimeManager();
            DefaultContainer.RegisterType<IVersionAppender, VersionAppender>(singleton);
        }

        public static T Resolve<T>()
        {
            return DefaultContainer.Resolve<T>();
        }
    }
}