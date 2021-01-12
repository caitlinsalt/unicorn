using System;
using System.Collections.Generic;

namespace Unicorn.Writer.Extensions
{
    /// <summary>
    /// Extension methods for the <see cref="IList{T}" /> type.
    /// </summary>
    public static class IListExtensions
    {
        /// <summary>
        /// Utility method to make up for there being a <see cref="List{T}.AddRange" /> method but no <c>IList&lt;T&gt;.AddRange</c> method.
        /// </summary>
        /// <typeparam name="T">The type of elements in the <see cref="IList{T}"/>.</typeparam>
        /// <param name="list">The collection to add elements to.</param>
        /// <param name="collection">The collection of elements to be added.</param>
        public static void AddRange<T>(this IList<T> list, IEnumerable<T> collection)
        {
            if (list is List<T> concrete)
            {
                concrete.AddRange(collection);
                return;
            }
            if (list is null)
            {
                throw new ArgumentNullException(nameof(list));
            }
            if (collection is null)
            {
                throw new ArgumentNullException(nameof(collection));
            }
            foreach (T item in collection)
            {
                list.Add(item);
            }
        }
    }
}
