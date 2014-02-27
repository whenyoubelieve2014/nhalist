using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Http.Dependencies;
using Microsoft.Practices.Unity;

namespace NhaList
{
    public class UnityResolver : IDependencyResolver
    {
        protected IUnityContainer Container;

        public UnityResolver(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            Container = container;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return Container.Resolve(serviceType);
            }
            catch (ResolutionFailedException innerException)
            {
                string msg = string.Format("Cannot resolve type <{0}>", serviceType.FullName);
                if (serviceType.Namespace != null &&
                    serviceType.Namespace.StartsWith(UnityBootstrap.NAMESPACE_NHALIST,
                        StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException(msg, innerException);
                }
                Trace.TraceError(msg);
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return Container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException innerException)
            {
                string msg = string.Format("Cannot resolve type <{0}>", serviceType.FullName);
                if (serviceType.Namespace != null &&
                    serviceType.Namespace.StartsWith(UnityBootstrap.NAMESPACE_NHALIST,
                        StringComparison.OrdinalIgnoreCase))
                {
                    throw new InvalidOperationException(msg, innerException);
                }
                Trace.TraceError(msg);
                return Enumerable.Empty<object>();
            }
        }

        public IDependencyScope BeginScope()
        {
            IUnityContainer child = Container.CreateChildContainer();
            return new UnityResolver(child);
        }

        public void Dispose()
        {
            Container.Dispose();
        }
    }
}