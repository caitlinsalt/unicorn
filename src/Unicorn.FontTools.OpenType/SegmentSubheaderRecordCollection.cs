using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Unicorn.FontTools.OpenType
{
    /// <summary>
    /// Read-only collection class for the <see cref="SegmentSubheaderRecord" /> type.
    /// </summary>
    public class SegmentSubheaderRecordCollection : IReadOnlyCollection<SegmentSubheaderRecord>
    {
        private readonly SegmentSubheaderRecord[] _data;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="data">Content of the collection.</param>
        public SegmentSubheaderRecordCollection(IEnumerable<SegmentSubheaderRecord> data)
        {
            if (data is null)
            {
                _data = Array.Empty<SegmentSubheaderRecord>();
            }
            else
            {
                _data = data.ToArray();
            }
        }

        /// <summary>
        /// Indexer.
        /// </summary>
        /// <param name="index">The index of the element to return.</param>
        /// <returns>The element with the given index.</returns>
        /// <exception cref="IndexOutOfRangeException">Thrown if the parameter is negative or greater than or equal to the number of elements in the 
        /// collection.</exception>
        public SegmentSubheaderRecord this[int index] => _data[index];

        /// <summary>
        /// The number of elements in the collection.
        /// </summary>
        public int Count => _data.Length;

        /// <summary>
        /// Get an enumerator for enumerating over the collection.
        /// </summary>
        /// <returns>An <see cref="IEnumerator{SegmentSubheaderRecord}" /> instance derived from this collection.</returns>
        public IEnumerator<SegmentSubheaderRecord> GetEnumerator() => _data.AsEnumerable().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _data.GetEnumerator();
    }
}
