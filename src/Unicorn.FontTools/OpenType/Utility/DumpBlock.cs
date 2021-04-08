using System;
using System.Collections.Generic;
using System.Linq;

namespace Unicorn.FontTools.OpenType.Utility
{
    /// <summary>
    /// Represents a block of textual data to be dumped to human-readable output.  The data can contain a non-tabular part (the <see cref="Info" />), a tabular part
    /// (the <see cref="BlockData" /> and its <see cref="BlockHeader" />) and further nested blocks (the <see cref="NestedData" />).
    /// </summary>
    public class DumpBlock
    {
        private static readonly DumpBlockHeader _defaultHeader = new DumpBlockHeader(new DumpColumn("Name"), new DumpColumn("Value"));

        /// <summary>
        /// Non-tabular data.
        /// </summary>
        public string Info { get; private set; }

        /// <summary>
        /// Header of the tabular data.
        /// </summary>
        public DumpBlockHeader BlockHeader { get; private set; }

        /// <summary>
        /// Tabular data.
        /// </summary>
        public IEnumerable<DumpRecord> BlockData { get; private set; }

        /// <summary>
        /// Further nested data blocks.
        /// </summary>
        public IEnumerable<DumpBlock> NestedData { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="info">Non-tabular data.</param>
        /// <param name="header">Tabular data header.</param>
        /// <param name="data">Tabular data.</param>
        /// <param name="nestedData">Nested data blocks.</param>
        public DumpBlock(string info, DumpBlockHeader header, IEnumerable<DumpRecord> data, IEnumerable<DumpBlock> nestedData)
        {
            Info = info ?? "";
            BlockHeader = header ?? _defaultHeader;
            BlockData = data ?? Array.Empty<DumpRecord>();
            NestedData = nestedData ?? Array.Empty<DumpBlock>();
        }

        /// <summary>
        /// Constructor for a data block whose tabular data uses the default "Name | Value" header.
        /// </summary>
        /// <param name="info">Non-tabular data.</param>
        /// <param name="data">Tabular data.</param>
        /// <param name="nestedData">Nested data blocks.</param>
        public DumpBlock(string info, IEnumerable<DumpRecord> data, IEnumerable<DumpBlock> nestedData) : this(info, _defaultHeader, data, nestedData) { }

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
                var columnWidths = new List<int>(BlockHeader.Count);
                for (int i = 0; i < BlockHeader.Count; ++i)
                {
                    columnWidths.Add(BlockHeader[i].HeaderText.Length);
                    int valLength = blockData.Select(r => r[i].Length).Max();
                    if (valLength > columnWidths.Last())
                    {
                        columnWidths[columnWidths.Count - 1] = valLength;
                    }
                }
                yield return BlockHeader.FormatHeader(columnWidths);
                foreach (var str in BlockData.Select(d => d.FormatRecord(BlockHeader, columnWidths)))
                {
                    yield return str;
                }
                yield return DumpBlockHeader.GetUnderline(columnWidths);
            }
            foreach (var str in NestedData.SelectMany(n => n.FormatBlock()))
            {
                yield return str;
            }
        }
    }
}
