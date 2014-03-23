using System;

namespace NhaList.Convenience.ExtensionMethods
{
    public static class SmartTranslation
    {
        public static string ToSmartString(this DateTime date)
        {
            return Smart.Date.Format(date);
        }

        public class Smart
        {
            public class Date
            {
                public static string Format(DateTime date)
                {
                    return date.ToLongDateString();
                }
            }
        }
    }
}