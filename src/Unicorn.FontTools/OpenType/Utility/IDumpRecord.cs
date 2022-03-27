using System.Collections.Generic;

namespace Unicorn.FontTools.OpenType.Utility
{
    /// <summary>
    /// A single row in a tabular data set.
    /// </summary>
    public interface IDumpRecord : IReadOnlyList<string>
    {
        /// <summary>
        /// Convert the data row into a formatted string, with each field correctly padded.
        /// </summary>
        /// <param name="header">The column definitions for this table.</param>
        /// <returns>A string containing the row's data, correctly formatted for display.</returns>
        string FormatRecord(IDumpBlockHeader header);
    }
}
