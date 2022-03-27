using System;
using System.Collections.Generic;

namespace Unicorn.Helpers
{
    /// <summary>
    /// Extension methods for the <see cref="List{T}" /> class.
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        /// Remove all elements of a list including and after the element at a given index.  Afterwards, the number of items in the list will equal the <c>idx</c>
        /// parameter.
        /// </summary>
        /// <typeparam name="T">The type of the list elements.</typeparam>
        /// <param name="list">The list to remove elements from.</param>
        /// <param name="idx">The index of the first element to remove.</param>
        /// <exception cref="ArgumentNullException">The <c>list</c> parameter is <c>null</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The <c>idx</c> parameter is less than 0, or greater than or equal to the value of the 
        /// <see cref="List{T}.Count"/> property of the <c>list</c> parameter.</exception>
        public static void RemoveAfter<T>(this List<T> list, int idx)
        {
            if (list is null)
            {
                throw new ArgumentNullException(nameof(list));
            }
            if (idx < 0 || idx >= list.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(idx));
            }
            if (idx == 0)
            {
                list.Clear();
                return;
            }
            while (list.Count > idx)
            {
                list.RemoveAt(list.Count - 1);
            }
        }
    }
}
