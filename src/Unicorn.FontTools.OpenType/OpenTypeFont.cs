using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO.MemoryMappedFiles;
using System.Linq;
using Unicorn.FontTools.OpenType.Extensions;
using Unicorn.FontTools.OpenType.Interfaces;
using Unicorn.FontTools.OpenType.Utility;

namespace Unicorn.FontTools.OpenType
{
    /// <summary>
    /// OpenType font data and metadata.
    /// </summary>
    public class OpenTypeFont : IDisposable, IOpenTypeFont
    {
        private MemoryMappedFile _mmf;
        private MemoryMappedViewAccessor _accessor;

        /// <summary>
        /// The full path of the file this font was loaded from.
        /// </summary>
        public string Filename { get; private set; }

        /// <summary>
        /// The length of the raw data of this font, in bytes.
        /// </summary>
        public long Length => _accessor.Capacity;

        /// <summary>
        /// The header <see cref="OffsetTable" /> - the most important contents being the number of data tables in the font.
        /// </summary>
        public OffsetTable OffsetHeader { get; set; }

        /// <summary>
        /// The ratio between font design units and em units (in other words, when the font is rendered at x points, this number of design units will measure x points.
        /// Generally a medium-sized power of 2 such as 2048, but can be any value up to 16,384.
        /// </summary>
        public int DesignUnitsPerEm => Header.FontUnitScale;

        /// <summary>
        /// The "head" table of the font, which must be present for the font to be a valid OpenType file.
        /// </summary>
        public HeaderTable Header => GetTable<HeaderTable>("head");

        /// <summary>
        /// The "hhea" table of the font, which must be present for the font to be a valid OpenType file.
        /// </summary>
        public HorizontalHeaderTable HorizontalHeader => GetTable<HorizontalHeaderTable>("hhea");

        /// <summary>
        /// The content of the font's "hmtx" table.
        /// </summary>
        public HorizontalMetricsTable HorizontalMetrics => GetTable<HorizontalMetricsTable>("hmtx");

        /// <summary>
        /// The "maxp" table of this font, which must be present for the font to be a valid OpenType file.
        /// </summary>
        public MaximumProfileTable MaximumProfile => GetTable<MaximumProfileTable>("maxp");

        /// <summary>
        /// The content of the font's "OS/2" data table.
        /// </summary>
        public OS2MetricsTable OS2Metrics => GetTable<OS2MetricsTable>("OS/2");

        /// <summary>
        /// The content of the font's "cmap" data table.
        /// </summary>
        public CharacterMappingTable CharacterMapping => GetTable<CharacterMappingTable>("cmap");

        /// <summary>
        /// The content of the font's "name" data table.
        /// </summary>
        public NamingTable Naming => GetTable<NamingTable>("name");

        /// <summary>
        /// The content of the font's "post" data table.
        /// </summary>
        public PostScriptTable PostScriptData => GetTable<PostScriptTable>("post");

        private T GetTable<T>(string tableName) where T : Table
        {
            if (!TableIndex.ContainsKey(tableName))
            {
                return null;
            }
            TableIndexRecord index = TableIndex[tableName];
            if (index.Data is null)
            {
                index.Data = GetTableData(index);
            }
            return (T)index.Data;
        }

        /// <summary>
        /// The index of data tables in the font.
        /// </summary>
        public Dictionary<string, TableIndexRecord> TableIndex { get; } = new Dictionary<string, TableIndexRecord>();

        /// <summary>
        /// Confirm that the structure of this font is valid.  Currently checks that it has an OffsetTable and records in the index for all of the compulsary
        /// table types for this type of font.
        /// </summary>
        public void CheckValidity()
        {
            if (OffsetHeader is null)
            {
                throw new OpenTypeFormatException(Resources.OpenTypeFont_CheckValidity_MissingHeaderError);
            }
            CheckTablesPresent();
        }

        private void CheckTablesPresent()
        {
            string[] requiredTables = new[] { "cmap", "head", "hhea", "hmtx", "maxp", "name", "OS/2", "post" };
            string[] requiredTrueTypeTables = new[] { "glyf", "loca" };
            string[] requiredCffTables = new[] { "CFF ", "CFF2" };
            CheckTablesPresent(requiredTables);
            switch (OffsetHeader.FontKind)
            {
                case FontKind.TrueType:
                    CheckTablesPresent(requiredTrueTypeTables);
                    break;
                case FontKind.Cff:
                    CheckTablesPresent(requiredCffTables);
                    break;
            }
        }

        private void CheckTablesPresent(IEnumerable<string> tableNames)
        {
            string[] missingTables = tableNames.Where(t => !TableIndex.ContainsKey(t)).ToArray();
            if (missingTables.Length > 0)
            {
                throw new OpenTypeFormatException(string.Format(CultureInfo.CurrentCulture,
                    Resources.OpenTypeFont_CheckTablesPresent_MissingTablesError, string.Join(", ", missingTables)));
            }
        }

        /// <summary>
        /// Load an OpenType font from a memory-mapped file.
        /// </summary>
        /// <param name="mmf">The memory-mapped file to load data from.</param>
        /// <param name="fn">The full path of the file this font was loaded from.</param>
        /// <returns>A font object.</returns>
        public OpenTypeFont(MemoryMappedFile mmf, string fn)
        {
            if (mmf is null)
            {
                throw new ArgumentNullException(nameof(mmf));
            }
            Filename = fn;
            _mmf = mmf;
            _accessor = _mmf.CreateViewAccessor(0, 0, MemoryMappedFileAccess.Read);
            OffsetHeader = LoadOffsetTable(_accessor);
            long offset = 12;
            for (int i = 0; i < OffsetHeader.TableCount; ++i)
            {
                TableIndexRecord record = LoadTableRecord(_accessor, offset + i * 16);
                TableIndex.Add(record.TableTag.Value, record);
            }
        }

        private static OffsetTable LoadOffsetTable(MemoryMappedViewAccessor accessor)
        {
            FontKind fontKind;
            ushort tableCount, searchRange, entrySelector, rangeShift;
            byte[] buffer = new byte[4];
            accessor.ReadArray(0, buffer, 0, 4);
            uint magicNumber = buffer.ToUInt();
            switch (magicNumber)
            {
                case 0x10000:
                    fontKind = FontKind.TrueType;
                    break;
                case 0x4f54544f:
                    fontKind = FontKind.Cff;
                    break;
                default:
                    throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.OpenTypeFont_LoadOffsetTable_UnknownMagicError,
                        magicNumber));
            }
            accessor.ReadArray(4, buffer, 0, 2);
            tableCount = buffer.ToUShort();
            accessor.ReadArray(6, buffer, 0, 2);
            searchRange = buffer.ToUShort();
            accessor.ReadArray(8, buffer, 0, 2);
            entrySelector = buffer.ToUShort();
            accessor.ReadArray(10, buffer, 0, 2);
            rangeShift = buffer.ToUShort();

            return new OffsetTable(fontKind, tableCount, searchRange, entrySelector, rangeShift);
        }

        private TableIndexRecord LoadTableRecord(MemoryMappedViewAccessor accessor, long offset)
        {
            byte[] buffer = new byte[4];
            Tag tableTag;
            uint checksum, tableOffset, len;
            accessor.ReadArray(offset, buffer, 0, 4);
            tableTag = new Tag(buffer);
            accessor.ReadArray(offset + 4, buffer, 0, 4);
            checksum = buffer.ToUInt();
            accessor.ReadArray(offset + 8, buffer, 0, 4);
            tableOffset = buffer.ToUInt();
            accessor.ReadArray(offset + 12, buffer, 0, 4);
            len = buffer.ToUInt();
            return new TableIndexRecord(tableTag, checksum, tableOffset, len, GetLoadingMethod(tableTag));
        }

        private TableLoadingMethod GetLoadingMethod(Tag t)
        {
            switch (t.Value)
            {
                case "head":
                    return HeaderTable.FromBytes;
                case "hhea":
                    return HorizontalHeaderTable.FromBytes;
                case "maxp":
                    return MaximumProfileTable.FromBytes;
                case "hmtx":
                    return LoadHmtxTable;
                case "OS/2":
                    return OS2MetricsTable.FromBytes;
                case "name":
                    return NamingTable.FromBytes;
                case "cmap":
                    return CharacterMappingTable.FromBytes;
                case "post":
                    return PostScriptTable.FromBytes;
                default:
                    return null;
            }
        }

        private HorizontalMetricsTable LoadHmtxTable(byte[] arr, int offset, int len)
            => HorizontalMetricsTable.FromBytes(arr, offset, MaximumProfile.GlyphCount, HorizontalHeader.HmtxHMetricCount);

        /// <summary>
        /// Return the contents of the table with the given index record, from a cached copy of the data if available.
        /// </summary>
        /// <param name="indexRecord">The index record for the table to load.</param>
        /// <returns>A <see cref="Table" /> implementation, or <c>null</c> if the table cannot be loaded.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the parameter is null.</exception>
        public Table GetTableData(TableIndexRecord indexRecord)
        {
            if (indexRecord is null)
            {
                throw new ArgumentNullException(nameof(indexRecord));
            }
            if (indexRecord.Data != null)
            {
                return indexRecord.Data;
            }
            if (indexRecord.LoadingMethod == null)
            {
                return null;
            }

            byte[] rawTable = new byte[indexRecord.Length];
            _accessor.ReadArray(indexRecord.Offset.Value, rawTable, 0, (int)indexRecord.Length);
            return indexRecord.LoadingMethod(rawTable, 0, (int)indexRecord.Length);
        }

        /// <summary>
        /// Get the contents of the table with the given tag, if it exists.
        /// </summary>
        /// <param name="t">The tag of the table to attempt to load.</param>
        /// <returns>A <see cref="Table" /> implementation, or <c>null</c> if a table with the given tag does not exist or cannot be loaded.</returns>
        public Table GetTableData(Tag t)
        {
            if (!TableIndex.ContainsKey(t.Value))
            {
                return null;
            }
            TableIndexRecord indexEntry = TableIndex[t.Value];
            return GetTableData(indexEntry);
        }

        /// <summary>
        /// Return the advance width (in font design units) of the given codepoint on the given platform, using the best encoding for that platform.
        /// </summary>
        /// <param name="platform">The platform to measure for.</param>
        /// <param name="codePoint">The code point to be measured. Must be within the range of a <see cref="uint" />.</param>
        /// <returns>The advance width value for the bset glyph found to represent the given code point on the specified platform.</returns>
        public int AdvanceWidth(PlatformId platform, long codePoint)
        {
            FieldValidation.ValidateUIntParameter(codePoint, nameof(codePoint));
            int glyph = GetGlyphId(platform, codePoint);
            return HorizontalMetrics.Metrics[glyph].AdvanceWidth;
        }

        /// <summary>
        /// Determine whether or not this font defines a glyph (other than the special <c>.notdef</c> glyph) for the given platform and codepoint.
        /// </summary>
        /// <param name="platform">The platform to check for.</param>
        /// <param name="codePoint">The code point to check.  Must be within the range of a <see cref="uint" />.</param>
        /// <returns></returns>
        public bool HasGlyphDefined(PlatformId platform, long codePoint)
        {
            FieldValidation.ValidateUIntParameter(codePoint, nameof(codePoint));
            return GetGlyphId(platform, codePoint) != 0;
        }

        private int GetGlyphId(PlatformId platform, long codePoint)
        {
            CharacterMapping mapping = CharacterMapping.SelectBestMapping(platform);
            return mapping.MapCodePoint(codePoint);
        }

        private class Enumerator : IEnumerator<byte>
        {
            long idx = -1;
            private readonly OpenTypeFont _font;

            internal Enumerator(OpenTypeFont font)
            {
                _font = font;
            }

            public byte Current => _font._accessor.ReadByte(idx);

            object IEnumerator.Current => _font._accessor.ReadByte(idx);

            public bool MoveNext()
            {
                idx++;
                return idx < _font._accessor.Capacity;
            }

            public void Reset()
            {
                idx = 0;
            }

            #region IDisposable Support
            private bool disposedValue;

            protected virtual void Dispose(bool disposing)
            {
                if (!disposedValue)
                {
                    disposedValue = true;
                }
            }

            // This code added to correctly implement the disposable pattern.
            public void Dispose()
            {
                // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
                Dispose(true);
                GC.SuppressFinalize(this);
            }
            #endregion
        }

        /// <summary>
        /// Returns an enumerator that iterates over the bytes that comprise the raw data of this font.
        /// </summary>
        /// <returns>An enumerator that will return the raw data of this font.</returns>
        public IEnumerator<byte> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        #region IDisposable Support
        private bool disposedValue; // To detect redundant calls

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="OpenTypeFont" /> and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to only release unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _mmf?.Dispose();
                    _mmf = null;
                    _accessor?.Dispose();
                    _accessor = null;
                }

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        /// <summary>
        /// Releases all resources used by the <see cref="OpenTypeFont" />.
        /// </summary>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
