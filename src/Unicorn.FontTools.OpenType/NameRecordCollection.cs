using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Unicorn.FontTools.OpenType
{
    /// <summary>
    /// Collection class for <see cref="NameRecord" /> objects.
    /// </summary>
    public class NameRecordCollection : IReadOnlyCollection<NameRecord>
    {
        private readonly NameRecord[] _names;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="data">The data to store in the collection, or <c>null</c> to create an empty collection.</param>
        public NameRecordCollection(IEnumerable<NameRecord> data)
        {
            if (data is null)
            {
                _names = Array.Empty<NameRecord>();
            }
            else
            {
                _names = data.ToArray();
            }
        }

        /// <summary>
        /// By-position indexer.
        /// </summary>
        /// <param name="index">The index of the element to return.</param>
        /// <returns>The element at the given index in the collection.</returns>
        /// <exception cref="IndexOutOfRangeException">Thrown if the index parameter is less than zero or greater than or equal to the number of items in 
        /// the collection.</exception>
        public NameRecord this[int index] => _names[index];

        /// <summary>
        /// The number of itmes in the collection.
        /// </summary>
        public int Count => _names.Length;

        /// <summary>
        /// Enumerate over the contents of this collection.
        /// </summary>
        /// <returns>An enumerator for this collection.</returns>
        public IEnumerator<NameRecord> GetEnumerator() => _names.AsEnumerable().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _names.GetEnumerator();
    }
}
