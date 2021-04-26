using System.Collections.Generic;

namespace Unicorn.FontTools.OpenType.Utility
{
    /// <summary>
    /// Header for a table of dumped data.
    /// </summary>
    public interface IDumpBlockHeader : IReadOnlyList<DumpColumn>
    {
        /// <summary>
        /// The widths of each column in the data.
        /// </summary>
        IReadOnlyList<int> ColumnWidths { get; }

        /// <summary>
        /// Update the <see cref="ColumnWidths" /> property taking different data into account.
        /// </summary>
        /// <param name="data">Data to derive the column widths from, if the data in a column is wider than its header.</param>
        void MeasureColumnWidths(IReadOnlyList<IDumpRecord> data);

        /// <summary>
        /// Convert a table header to a formatted string.
        /// </summary>
        /// <returns></returns>
        string FormatHeader();

        /// <summary>
        /// Returns an "ASCII Art" table horizontal line that matches the columns defined by this header.
        /// </summary>
        /// <returns>A string such as <c>+---+------------+--------------------+----------+-------+</c> that can be used as a horizontal line in a text copy of the
        /// data in this table.</returns>
        string GetUnderline();
    }
}
