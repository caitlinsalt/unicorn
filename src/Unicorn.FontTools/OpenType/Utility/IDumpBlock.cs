using System.Collections.Generic;

namespace Unicorn.FontTools.OpenType.Utility
{
    /// <summary>
    /// Represents a block of textual data to be dumped to human-readable output.
    /// </summary>
    public interface IDumpBlock
    {
        /// <summary>
        /// Informative text about this block.
        /// </summary>
        string Info { get; }

        /// <summary>
        /// Header of the tabular data.
        /// </summary>
        IDumpBlockHeader BlockHeader { get; }

        /// <summary>
        /// Tabular data.
        /// </summary>
        IReadOnlyList<IDumpRecord> BlockData { get; }
        
        /// <summary>
        /// Further nested data blocks.
        /// </summary>
        IEnumerable<IDumpBlock> NestedData { get; }


        /// <summary>
        /// Format this block of data (including any nested blocks) as a sequence of strings.
        /// </summary>
        /// <returns>A sequence of strings containing the data in this data block and its children, formatted for output.</returns>
        IEnumerable<string> FormatBlock();
    }
}
