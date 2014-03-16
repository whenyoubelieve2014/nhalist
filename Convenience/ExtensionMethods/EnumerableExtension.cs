using System.Collections.Generic;
using System.Linq;

namespace NhaList.Convenience.ExtensionMethods
{
    public static class EnumerableExtension
    {
        /// <summary>
        ///     Checks if a set is empty
        /// </summary>
        /// <typeparam name="T">any type</typeparam>
        /// <param name="x">the set to check</param>
        /// <returns>true if empty; otherwise, false</returns>
        public static bool ConvenientlyIsEmpty<T>(this IEnumerable<T> x)
        {
            return !x.Any();
        }
    }
}