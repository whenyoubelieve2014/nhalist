using System;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using NhaList.Convenience.Types;

namespace NhaList.Convenience.ExtensionMethods
{
    public static class StringExtension
    {
        /// <summary>
        ///     Compares 2 strings, ignore case
        /// </summary>
        /// <param name="x">string to compare</param>
        /// <param name="y">string to compare</param>
        /// <returns>true if equals; otherwise, false</returns>
        public static bool ConvenientlyEquals(this string x, string y)
        {
            return string.Compare(x, y, StringComparison.OrdinalIgnoreCase) == 0;
        }

        /// <summary>
        ///     Checks if the string is not null, empty and not whitespaces
        /// </summary>
        /// <param name="x">string to check</param>
        /// <returns>true if the string is not null, empty and not whitespaces; otherwise, false</returns>
        public static bool ConvenientlyIsNotEmpty(this string x)
        {
            return !x.ConvenientlyIsEmpty();
        }

        /// <summary>
        ///     Checks if the string is null, empty or whitespaces
        /// </summary>
        /// <param name="x">string to check</param>
        /// <returns>true if the string is null, empty or whitespaces; otherwise, false</returns>
        public static bool ConvenientlyIsEmpty(this string x)
        {
            return string.IsNullOrWhiteSpace(x);
        }
    }

    public static class ObjectExtension
    {
        private static readonly JavaScriptSerializer Serializer;

        static ObjectExtension()
        {
            Serializer = new JavaScriptSerializer();
        }

        public static string ToJson(this object obj)
        {
            return Conveniently.Try(() => Serializer.Serialize(obj), error => null);
        }
    }
}