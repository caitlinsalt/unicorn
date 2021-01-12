using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Unicorn.FontTools.OpenType
{
    /// <summary>
    /// Read-only collection class for <see cref="HighByteSubheaderRecord" /> values.
    /// </summary>
    public class HighByteSubheaderRecordCollection : IReadOnlyCollection<HighByteSubheaderRecord>
    {
        private readonly HighByteSubheaderRecord[] _data;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="data">The data to be contained within the collection.</param>
        public HighByteSubheaderRecordCollection(IEnumerable<HighByteSubheaderRecord> data)
        {
            if (data is null)
            {
                _data = Array.Empty<HighByteSubheaderRecord>();
            }
            else
            {
                _data = data.ToArray();
            }
        }

        /// <summary>
        /// Indexer.
        /// </summary>
        /// <param name="index">Index of the element to return.</param>
        /// <returns>The element with the given index.</returns>
        /// <exception cref="IndexOutOfRangeException">Thrown if the index is less than zero or greater than or equal to the number of items in the 
        /// collection.</exception>
        public HighByteSubheaderRecord this[int index] => _data[index];

        /// <summary>
        /// The number of items in the collection.
        /// </summary>
        public int Count => _data.Length;

        /// <summary>
        /// Get an enumerator object to enumerate over this collection.
        /// </summary>
        /// <returns>An <see cref="IEnumerator{HighByteSubheaderRecord}" /> object for this collection.</returns>
        public IEnumerator<HighByteSubheaderRecord> GetEnumerator() => _data.AsEnumerable().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _data.GetEnumerator();
    }
}
