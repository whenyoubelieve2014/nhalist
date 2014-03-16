using System;
using System.Diagnostics;

namespace NhaList.Convenience.Types
{
    public partial class Conveniently
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