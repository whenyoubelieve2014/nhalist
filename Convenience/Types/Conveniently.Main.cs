using System;
using System.Diagnostics;

namespace NhaList.Convenience.Types
{
    public partial class Conveniently
    {
        #region Try.Func

        public static T Try<T>(Func<T> func)
        {
            return Try(func, error => Debug.Fail(error.ToString()), error => default(T));
        }

        public static T Try<T>(Func<T> func, Func<Exception, T> returnOnError)
        {
            return Try(func, error => Debug.Fail(error.ToString()), returnOnError);
        }

        public static T Try<T>(Func<T> func, Action<Exception> onError, Func<Exception, T> returnOnError)
        {
            if (func == null) throw new ArgumentNullException("func");
            try
            {
                T result = func();
                return result;
            }
            catch (Exception error)
            {
                Trace.TraceError(error.ToString());
                onError(error);
                return returnOnError(error);
            }
        }

        #endregion

        #region Try.Action

        public static void Try(Action action)
        {
            Try(action, error => Debug.Fail(error.ToString()));
        }


        public static void Try(Action action, Action<Exception> onError)
        {
            if (action == null) throw new ArgumentNullException("action");
            try
            {
                action();
            }
            catch (Exception error)
            {
                Trace.TraceError(error.ToString());
                onError(error);
            }
        }

        #endregion
    }
}