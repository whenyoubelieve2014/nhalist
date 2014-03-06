using System;
using System.Diagnostics;
using System.Reflection;

namespace NhaList.Convenience
{
    public static class AssemblyConveniently
    {
        public static string GetConfigPath()
        {
            try
            {
                Assembly entry = Assembly.GetCallingAssembly();
                return entry.Location;
            }
            catch (Exception innerException)
            {
                Trace.TraceError(string.Format("Reflection failed to get calling assembly. {0}", innerException));
                throw;
            }
        }
    }

    public static class Conveniently
    {
        public static T Try<T>(Func<T> func)
        {
            if (func == null) throw new ArgumentNullException("func");
            T result;
            string fullname = typeof (T).FullName;
            try
            {
                result = func();
            }
            catch (Exception inner)
            {
                Trace.TraceError(string.Format("tryReturn<{0}> failed. Exception: {1}", fullname, inner));
                throw;
            }
            Trace.WriteLine(string.Format("tryReturn {0}", fullname));
            return result;
        }
    }
}