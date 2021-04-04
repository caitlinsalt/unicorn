using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Tests.Utility.Extensions
{
    /// <summary>
    /// Extension methods for the <see cref="IEnumerable{T}" /> interface.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Returns the index of the maximum value in the sequence.
        /// </summary>
        /// <typeparam name="T">The type of items in the sequence.  This type must implement <see cref="IComparable{T}" /> against itself.</typeparam>
        /// <param name="sequence"></param>
        /// <returns></returns>
        public static int MaxIndex<T>(this IEnumerable<T> sequence) where T : IComparable<T>
        {
            if (sequence == null)
            {
                throw new ArgumentNullException(nameof(sequence));
            }

            int maxIndex = -1;
            T maxValue = default;

            int index = 0;
            foreach (T item in sequence)
            {
                if (item.CompareTo(maxValue) > 0 || maxIndex == -1)
                {
                    maxIndex = index;
                    maxValue = item;
                }
                index++;
            }
            return maxIndex;
        }
    }
}
