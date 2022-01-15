using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Unicorn.FontTools.OpenType.Utility
{
    /// <summary>
    /// Header of a tabular data set, consisting of a set of columns each with a name and an alignment.
    /// </summary>
    public class DumpBlockHeader : IDumpBlockHeader
    {
        private readonly DumpColumn[] _data;

        /// <summary>
        /// Returns the column with the given index.
        /// </summary>
        /// <param name="index">The index of the column to retrieve.</param>
        /// <returns>The column at the given index.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><c>index</c> is less than 0 or is equal to or greater than <see cref="Count" />.</exception>
        public DumpColumn this[int index] => _data[index];

        /// <summary>
        /// The number of columns in the header.
        /// </summary>
        public int Count => _data.Length;

        /// <summary>
        /// The widths of each column.  May be <c>null</c>; if it is, call <see cref="MeasureColumnWidths(IReadOnlyList{IDumpRecord})" /> to initialise it.  This method
        /// may also be called at any time to update it if the data has changed.
        /// </summary>
        public IReadOnlyList<int> ColumnWidths { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="data">The columns comprising the header.</param>
        public DumpBlockHeader(IEnumerable<DumpColumn> data)
        {
            _data = data is null ? Array.Empty<DumpColumn>() : data.ToArray();
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="data">The columns comprising the header.</param>
        public DumpBlockHeader(params DumpColumn[] data)
        {
            _data = data.ToArray();
        }

        /// <summary>
        /// Format the header as a string, with separators, and with each column padded to the given width.
        /// </summary>
        /// <returns>A string consisting of the header names, suitably padded as per the given <c>widths</c>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The number of elements in <c>widths</c> is less than the number of columns in the header.</exception>
        public string FormatHeader()
        {
            var strings = new string[Count];
            if (ColumnWidths is null)
            {
                MeasureColumnWidths();    
            }
            for (int i = 0; i < Count; ++i)
            {
                if (this[i].Alignment == DumpAlignment.Right)
                {
                    strings[i] = " " + this[i].HeaderText.PadLeft(ColumnWidths[i]) + " ";
                }
                else
                {
                    strings[i] = " " + this[i].HeaderText.PadRight(ColumnWidths[i]) + " ";
                }
            }
            string underline = GetUnderline();
            return underline + "\n|" + string.Join("|", strings) + "|\n" + underline;
        }

        /// <summary>
        /// Generate an "underline row" of the correct width to go with a header.
        /// </summary>
        /// <returns>A string suitable for use as the top or bottom of a table.</returns>
        public string GetUnderline() 
        { 
            if (ColumnWidths is null)
            {
                MeasureColumnWidths();
            }
            return "+" + string.Join("+", ColumnWidths.Select(w => new string('-', w + 2))) + "+"; 
        }

        /// <summary>
        /// Record the maximum width required to display each column in the given data with its header.
        /// </summary>
        /// <param name="data">The tabular data to measure the width of.</param>
        /// <exception cref="ArgumentNullException"><c>data</c> is null.</exception>
        /// <exception cref="ArgumentException"><c>data</c> contains rows with fewer elements than this header has columns.</exception>
        public void MeasureColumnWidths(IReadOnlyList<IDumpRecord> data)
        {
            if (data is null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            if (!data.Any())
            {
                MeasureColumnWidths();
                return;
            }
            if (data.Any(r => r.Count < Count))
            {
                throw new ArgumentException("Some table rows have fewer columns than the table header", nameof(data));
            }
            var columnWidths = new List<int>(Count);
            for (int i = 0; i < Count; ++i)
            {
                columnWidths.Add(this[i].HeaderText.Length);
                int valLength = data.Select(r => r[i].Length).Max();
                if (valLength > columnWidths.Last())
                {
                    columnWidths[columnWidths.Count - 1] = valLength;
                }
            }
            ColumnWidths = columnWidths;
        }

        /// <summary>
        /// Returns an enumerator for the columns in this header.
        /// </summary>
        /// <returns>An enumerator which can be used to iterate over the columns in this header.</returns>
        public IEnumerator<DumpColumn> GetEnumerator() => (_data as IEnumerable<DumpColumn>).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void MeasureColumnWidths()
        {
            ColumnWidths = _data.Select(c => c.HeaderText.Length).ToArray();
        }
    }
}
