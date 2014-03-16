using System;
using System.Diagnostics;
using System.Reflection;

namespace NhaList.Convenience.Types
{
    public class AssemblyConveniently
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
}