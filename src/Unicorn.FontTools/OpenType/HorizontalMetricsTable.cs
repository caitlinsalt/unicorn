﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Unicorn.FontTools.Extensions;
using Unicorn.FontTools.OpenType.Utility;

namespace Unicorn.FontTools.OpenType
{
    /// <summary>
    /// The content of the "hmtx" table.  On disk the content of this table can be abbreviated if a sequence of glyphs at the end of the table share the same
    /// AdvanceWidth property; in this representation, full records are provided for every glyph.
    /// </summary>
    public class HorizontalMetricsTable : Table
    {
        /// <summary>
        /// Collection of horizontal metrics records for individual glyphs.
        /// </summary>
        public HorizontalMetricRecordCollection Metrics { get; private set; }
        
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="data">The data contained in this table.</param>
        public HorizontalMetricsTable(IEnumerable<HorizontalMetricRecord> data) : base("hmtx")
        {
            Metrics = new HorizontalMetricRecordCollection(data);
        }

        /// <summary>
        /// Create a representation of the data in this table.
        /// </summary>
        /// <returns>A <see cref="DumpBlock" /> object containing the data from this table in textual form.</returns>
        public override IDumpBlock Dump()
            => new DumpBlock(
                "hmtx table contents:",
                new DumpBlockHeader(
                    new DumpColumn("Glyph", DumpAlignment.Right),
                    new DumpColumn("Advance Width", DumpAlignment.Right),
                    new DumpColumn("LSB", DumpAlignment.Right)),
                Metrics.Select((m, i) => new DumpRecord(
                    i.ToString(CultureInfo.CurrentCulture), 
                    m.AdvanceWidth.ToString(CultureInfo.CurrentCulture), 
                    m.LeftSideBearing.ToString(CultureInfo.CurrentCulture))),
                null);


        /// <summary>
        /// Construct a <see cref="HorizontalMetricsTable" /> instance from an array of bytes.  To do so requires some data loaded from other tables.
        /// </summary>
        /// <param name="arr">The array to load the data from.</param>
        /// <param name="offset">The starting location of the data in the array.</param>
        /// <param name="glyphCount">The total number of glyphs in the font (available in the maxp table).</param>
        /// <param name="fullRecordCount">The number of glyphs that have a full horizontal metric record on disk (available in the hhea table).</param>
        /// <returns>A <see cref="HorizontalMetricsTable" /> instance.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the array parameter is not long enough to contain the amount of data specified.</exception>
        public static HorizontalMetricsTable FromBytes(byte[] arr, int offset, int glyphCount, int fullRecordCount)
        {
            ushort advWidth = 0;
            List<HorizontalMetricRecord> metrics = new List<HorizontalMetricRecord>(glyphCount);
            for (int i = 0; i < fullRecordCount; ++i)
            {
                advWidth = arr.ToUShort(offset);
                offset += 2;
                short lsb = arr.ToShort(offset);
                offset += 2;
                metrics.Add(new HorizontalMetricRecord(advWidth, lsb));
            }
            for (int i = 0; i < glyphCount - fullRecordCount; ++i)
            {
                short lsb = arr.ToShort(offset);
                offset += 2;
                metrics.Add(new HorizontalMetricRecord(advWidth, lsb));
            }
            return new HorizontalMetricsTable(metrics);
        }
    }
}
