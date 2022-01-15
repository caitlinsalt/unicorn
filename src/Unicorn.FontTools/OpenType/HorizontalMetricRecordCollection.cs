using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Unicorn.FontTools.OpenType
{
    /// <summary>
    /// Read-only collection class for <see cref="HorizontalMetricRecord" /> values, used by the <see cref="HorizontalMetricsTable" /> type.
    /// </summary>
    public class HorizontalMetricRecordCollection : IReadOnlyList<HorizontalMetricRecord>
    {
        private readonly HorizontalMetricRecord[] _arr;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="data">Data to create the collection from.</param>
        public HorizontalMetricRecordCollection(IEnumerable<HorizontalMetricRecord> data)
        {
            if (data is null)
            {
                _arr = Array.Empty<HorizontalMetricRecord>();
            }
            else
            {
                _arr = data.ToArray();
            }
        }

        /// <summary>
        /// Indexer.
        /// </summary>
        /// <param name="index">The item to access.</param>
        /// <returns>The item with the given index.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the parameter is less than zero or greater than or equal to the number of items in the 
        /// collection.</exception>
        public HorizontalMetricRecord this[int index] => _arr[index];

        /// <summary>
        /// The number of items in the collection.
        /// </summary>
        public int Count => _arr.Length;

        /// <summary>
        /// Get an enumerator over this collection.
        /// </summary>
        /// <returns>An <see cref="IEnumerator{HorizontalMetricRecord}" /> instance.</returns>
        public IEnumerator<HorizontalMetricRecord> GetEnumerator() => _arr.AsEnumerable().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _arr.GetEnumerator();
    }
}
