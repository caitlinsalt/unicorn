using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Unicorn.FontTools.OpenType.Utility
{
    /// <summary>
    /// Header of a tabular data set, consisting of a set of columns each with a name and an alignment.
    /// </summary>
    public class DumpBlockHeader : IReadOnlyList<DumpColumn>
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
        /// <param name="widths">Column widths</param>
        /// <returns>A string consisting of the header names, suitably padded as per the given <c>widths</c>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The number of elements in <c>widths</c> is less than the number of columns in the header.</exception>
        public string FormatHeader(IEnumerable<int> widths)
        {
            var widthsArr = widths.ToArray();
            var strings = new string[Count];
            for (int i = 0; i < Count; ++i)
            {
                if (this[i].Alignment == DumpAlignment.Right)
                {
                    strings[i] = " " + this[i].HeaderText.PadLeft(widthsArr[i]) + " ";
                }
                else
                {
                    strings[i] = " " + this[i].HeaderText.PadRight(widthsArr[i]) + " ";
                }
            }
            string underline = GetUnderline(widthsArr);
            return underline + "\n|" + string.Join("|", strings) + "|\n" + underline;
        }

        /// <summary>
        /// Generate an "underline row" of the correct width to go with a header.
        /// </summary>
        /// <param name="widths">The widths of the columns that this row should match.</param>
        /// <returns>A string suitable for use as the top or bottom of a table.</returns>
        public static string GetUnderline(IEnumerable<int> widths) => "+" + string.Join("+", widths.Select(w => new string('-', w + 2))) + "+";

        /// <summary>
        /// Returns an enumerator for the columns in this header.
        /// </summary>
        /// <returns>An enumerator which can be used to iterate over the columns in this header.</returns>
        public IEnumerator<DumpColumn> GetEnumerator() => (IEnumerator<DumpColumn>)_data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
