using System;
using System.Collections.Generic;
using System.Linq;

namespace Unicorn.FontTools.OpenType.Utility
{
    /// <summary>
    /// Represents a block of textual data to be dumped to human-readable output.  The data can contain a non-tabular part (the <see cref="Info" />), a tabular part
    /// (the <see cref="BlockData" /> and its <see cref="BlockHeader" />) and further nested blocks (the <see cref="NestedData" />).
    /// </summary>
    public class DumpBlock : IDumpBlock
    {
        private static readonly IDumpBlockHeader _defaultHeader = new DumpBlockHeader(new DumpColumn("Field"), new DumpColumn("Value"));

        /// <summary>
        /// Non-tabular data.
        /// </summary>
        public string Info { get; private set; }

        /// <summary>
        /// Header of the tabular data.
        /// </summary>
        public IDumpBlockHeader BlockHeader { get; private set; }

        /// <summary>
        /// Tabular data.
        /// </summary>
        public IReadOnlyList<IDumpRecord> BlockData { get; private set; }

        /// <summary>
        /// Further nested data blocks.
        /// </summary>
        public IEnumerable<IDumpBlock> NestedData { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="info">Non-tabular data.</param>
        /// <param name="header">Tabular data header.</param>
        /// <param name="data">Tabular data.</param>
        /// <param name="nestedData">Nested data blocks.</param>
        public DumpBlock(string info, IDumpBlockHeader header, IEnumerable<IDumpRecord> data, IEnumerable<IDumpBlock> nestedData)
        {
            Info = info ?? "";
            BlockHeader = header ?? _defaultHeader;
            BlockData = data is null ? Array.Empty<IDumpRecord>() : data.ToArray();
            NestedData = nestedData is null ? Array.Empty<IDumpBlock>() : nestedData.ToArray();
        }

        /// <summary>
        /// Constructor for a data block whose tabular data uses the default "Name | Value" header.
        /// </summary>
        /// <param name="info">Non-tabular data.</param>
        /// <param name="data">Tabular data.</param>
        /// <param name="nestedData">Nested data blocks.</param>
        public DumpBlock(string info, IEnumerable<IDumpRecord> data, IEnumerable<IDumpBlock> nestedData) : this(info, _defaultHeader, data, nestedData) { }

        /// <summary>
        /// Format this block of data (including any nested blocks) as a sequence of strings.
        /// </summary>
        /// <returns>A sequence of strings containing the data in this data block and its children, formatted for output.</returns>
        public IEnumerable<string> FormatBlock()
        {
            yield return Info;
            var blockData = BlockData.ToList();
            if (blockData.Any())
            {
                BlockHeader.MeasureColumnWidths(BlockData);
                yield return BlockHeader.FormatHeader();
                foreach (var str in BlockData.Select(d => d.FormatRecord(BlockHeader)))
                {
                    yield return str;
                }
                yield return BlockHeader.GetUnderline();
            }
            foreach (var str in NestedData.SelectMany(n => n.FormatBlock()))
            {
                yield return str;
            }
        }
    }
}
