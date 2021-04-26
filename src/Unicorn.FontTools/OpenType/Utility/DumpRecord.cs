using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Unicorn.FontTools.OpenType.Utility
{
    /// <summary>
    /// Represents a row in a dumped tabular data set.
    /// </summary>
    public class DumpRecord : IDumpRecord
    {
        private readonly string[] _data;

        /// <summary>
        /// Construct a record from a sequence of string data items.
        /// </summary>
        /// <param name="data">The data that comprises the record.</param>
        public DumpRecord(IEnumerable<string> data)
        {
            _data = data is null ? Array.Empty<string>() : data.ToArray();
        }

        /// <summary>
        /// Construct a record from an array of string data items.
        /// </summary>
        /// <param name="data">The data that conprises the record.</param>
        public DumpRecord(params string[] data)
        {
            _data = data.ToArray();
        }

        /// <summary>
        /// Get the data item at the specified index in the record.
        /// </summary>
        /// <param name="index">The index of the item to retrieve.</param>
        /// <returns>The data item at the given index.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><c>index</c> is less than 0 or <c>index</c> is greater than or equal to <see cref="Count" />.</exception>
        public string this[int index] => _data[index];

        /// <summary>
        /// The number of items in the data record.
        /// </summary>
        public int Count => _data.Length;

        /// <summary>
        /// Convert this record to a string, suitable for tabular display, with each field padded to a minimum width.
        /// </summary>
        /// <param name="header">The tabular header, used to determine the alignment of each field.</param>
        /// <returns>A string containing the record's data, with each field padded to a given width and separated by <c>|</c> characters.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Either <c>widths</c> or <c>header</c> contain fewer elements than this record.</exception>
        public string FormatRecord(IDumpBlockHeader header)
        {
            if (header is null)
            {
                throw new ArgumentNullException(nameof(header));
            }
            if (header.Count < Count)
            {
                throw new ArgumentException(Resources.DumpRecord_FormatRecord_ShortDumpBlockHeader, nameof(header));
            }
            return "|" + string.Join("|", this.Select((v, i) => " " + (GetPadFunction(header[i].Alignment))(v, header.ColumnWidths[i]) + " ")) + "|"; 
        }

        /// <summary>
        /// Returns an enumerator for iterating over the fields in the record.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate over the fields in the record.</returns>
        public IEnumerator<string> GetEnumerator() => (_data as IEnumerable<string>).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private static Func<string, int, string> GetPadFunction(DumpAlignment align)
        {
            if (align == DumpAlignment.Right)
            {
                return (s, i) => s.PadLeft(i);
            }
            return (s, i) => s.PadRight(i);
        }
    }
}
