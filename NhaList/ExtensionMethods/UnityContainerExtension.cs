using System;
using Microsoft.Practices.Unity;

namespace NhaList.ExtensionMethods
{
    public static class ObjectFactory
    {
        public static IUnityContainer DefaultContainer;

        public static T Resolve<T>()
        {
            if (DefaultContainer != null) return DefaultContainer.Resolve<T>();
            throw new NullReferenceException("UnityExtension.DefaultContainer");
        }
    }
}