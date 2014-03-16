using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace NhaList.Convenience.Types
{
    public partial class Conveniently
    {
        public static void VerifyModelAccuracy<T>(T context, Action<string> assertFail)
            where T : DbContext
        {
            //lazy and dont want to research why this isnt loading 
            //use reflection to iterate over each collection in the context and just watch for errors.

            Type t = context.GetType();
            PropertyInfo[] props = t.GetProperties();
            foreach (PropertyInfo p in props)
            {
                bool isEnumerable = (from i in p.PropertyType.GetInterfaces()
                    where i == typeof (IEnumerable)
                    select i
                    ).Any();

                if (isEnumerable)
                {
                    try
                    {
                        var dataToPull = (IEnumerable) p.GetValue(context, null);
                        if (dataToPull != null)
                        {
                            IEnumerable<object> set = (from object d in dataToPull select d);
                            object result = set.FirstOrDefault();
                            if (result == null)
                            {
                                Trace.TraceWarning("Table<{0}> is empty", dataToPull);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        string error = ex.Message;
                        if (ex.InnerException != null)
                            error += ex.InnerException.Message;
                        assertFail(error);
                    }
                }
            }
        }
    }
}