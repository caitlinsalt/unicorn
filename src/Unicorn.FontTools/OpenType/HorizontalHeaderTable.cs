﻿using System;
using System.Globalization;
using Unicorn.FontTools.Extensions;
using Unicorn.FontTools.OpenType.Utility;

namespace Unicorn.FontTools.OpenType
{
    /// <summary>
    /// The "hhea" table, containing global horizontal metrics for a font.
    /// </summary>
    public class HorizontalHeaderTable : Table
    {
        /// <summary>
        /// Major version number (normally 1).
        /// </summary>
        public int MajorVersion { get; private set; }

        /// <summary>
        /// Minor version number (normally 0).
        /// </summary>
        public int MinorVersion { get; private set; }

        /// <summary>
        /// Font ascender.  Normally only used to do Apple Mac-style calculations (Windows-style calculations use the OS/2 table).
        /// </summary>
        public short Ascender { get; private set; }

        /// <summary>
        /// Font descender.  Normally only used to do Apple Mac-style calculations (Windows-style calculations use the OS/2 table).
        /// </summary>
        public short Descender { get; private set; }

        /// <summary>
        /// Font line gap.
        /// </summary>
        public short LineGap { get; private set; }

        /// <summary>
        /// Maximum advance width, of the individual glyph values listed in the hmtx table.
        /// </summary>
        public int MaxAdvanceWidth { get; private set; }

        /// <summary>
        /// Minimum left side bearing, of the individual glyph values listed in the hmtx table.
        /// </summary>
        public short MinLeftSideBearing { get; private set; }

        /// <summary>
        /// Minimum right side bearing of the individual glyphs, where RSB = AW - LSB - (Xmax - Xmin).
        /// </summary>
        public short MinRightSideBearing { get; private set; }

        /// <summary>
        /// Maximum X-extent of the individual glyphs, where XExtent = LSB + (Xmax - Xmin).
        /// </summary>
        public short XMaxExtent { get; private set; }

        /// <summary>
        /// Used to calculate the text cursor angle: the vertical rise amount.  Conventionally 1 for vertical text cursors (but could be any value).
        /// </summary>
        public short CaretSlopeRise { get; private set; }

        /// <summary>
        /// Used to calculate the text cursor angle: the horizontal run amount.  0 gives a vertical text cursor.
        /// </summary>
        public short CaretSlopeRun { get; private set; }

        /// <summary>
        /// The amount by which glyph highlights should be shifted for slanted fonts.  Zero for non-slanted fonts.
        /// </summary>
        public short CaretOffset { get; private set; }

        /// <summary>
        /// Data format.  Should be 0.
        /// </summary>
        public short MetricDataFormat { get; private set; }

        /// <summary>
        /// Number of HMetric entries in the hmtx table.
        /// </summary>
        public int HmtxHMetricCount { get; private set; }

        internal HorizontalHeaderTable(ushort major, ushort minor, short ascender, short descender, short lineGap, ushort maxAdvWidth, short minLsb, short minRsb,
            short xMaxExt, short caretRise, short caretRun, short caretOffset, short metricFormat, ushort hmtxCount)
            : base("hhea")
        {
            MajorVersion = major;
            MinorVersion = minor;
            Ascender = ascender;
            Descender = descender;
            LineGap = lineGap;
            MaxAdvanceWidth = maxAdvWidth;
            MinLeftSideBearing = minLsb;
            MinRightSideBearing = minRsb;
            XMaxExtent = xMaxExt;
            CaretSlopeRise = caretRise;
            CaretSlopeRun = caretRun;
            CaretOffset = caretOffset;
            MetricDataFormat = metricFormat;
            HmtxHMetricCount = hmtxCount;
        }

        /// <summary>
        /// Convert an array of bytes to a <see cref="HorizontalHeaderTable" /> object.
        /// </summary>
        /// <param name="arr">The array to convert.</param>
        /// <param name="offset">Offset location to start at within the array.</param>
        /// <param name="len">Table data length.</param>
        /// <returns>A <see cref="HorizontalHeaderTable" /> object</returns>
        /// <exception cref="InvalidOperationException">Thrown if the array does not contain enough data (if the array length is not at least 36 greater than the 
        /// offset parameter.</exception>
        public static HorizontalHeaderTable FromBytes(byte[] arr, int offset, int len)
        {
            FieldValidation.ValidateNonNegativeIntegerParameter(len, nameof(len));
            if (len < 36)
            {
                throw new InvalidOperationException(Resources.HorizontalHeaderTable_FromBytes_InsufficientDataError);
            }
            return new HorizontalHeaderTable(
                arr.ToUShort(offset),           // MajorVersion
                arr.ToUShort(offset + 2),       // MinorVersion
                arr.ToShort(offset + 4),        // Ascender
                arr.ToShort(offset + 6),        // Descender
                arr.ToShort(offset + 8),        // LineGap
                arr.ToUShort(offset + 10),      // MaxAadvanceWidth
                arr.ToShort(offset + 12),       // MinLeftSideBearing
                arr.ToShort(offset + 14),       // MinRightSideBearing
                arr.ToShort(offset + 16),       // XMaxExtent
                arr.ToShort(offset + 18),       // CaretSlopeRise
                arr.ToShort(offset + 20),       // CaretSlopeRun
                arr.ToShort(offset + 22),       // CaretOffset (followed by 4 reserved 2-byte fields)
                arr.ToShort(offset + 32),       // MetricDataFormat
                arr.ToUShort(offset + 34));     // HmtxHMetricCount
        }

        /// <summary>
        /// Create a representation of the data in this table.
        /// </summary>
        /// <returns>A <see cref="DumpBlock" /> object containing the data from this table in textual form.</returns>
        public override IDumpBlock Dump()
            => new DumpBlock(
                "hhea table contents:",
                new DumpBlockHeader(new DumpColumn("Field"), new DumpColumn("Value", DumpAlignment.Right)),
                new DumpRecord[]
                {
                    new DumpRecord("MajorVersion", MajorVersion.ToString(CultureInfo.CurrentCulture)),
                    new DumpRecord("MinorVersion", MinorVersion.ToString(CultureInfo.CurrentCulture)),
                    new DumpRecord("Ascender", Ascender.ToString(CultureInfo.CurrentCulture)),
                    new DumpRecord("Descender", Descender.ToString(CultureInfo.CurrentCulture)),
                    new DumpRecord("LineGap", LineGap.ToString(CultureInfo.CurrentCulture)),
                    new DumpRecord("MaxAdvanceWidth", MaxAdvanceWidth.ToString(CultureInfo.CurrentCulture)),
                    new DumpRecord("MinLeftSideBearing", MinLeftSideBearing.ToString(CultureInfo.CurrentCulture)),
                    new DumpRecord("MinRightSideBearing", MinRightSideBearing.ToString(CultureInfo.CurrentCulture)),
                    new DumpRecord("XMaxExtent", XMaxExtent.ToString(CultureInfo.CurrentCulture)),
                    new DumpRecord("CaretSlopeRise", CaretSlopeRise.ToString(CultureInfo.CurrentCulture)),
                    new DumpRecord("CaretSlopeRun", CaretSlopeRun.ToString(CultureInfo.CurrentCulture)),
                    new DumpRecord("CaretOffset", CaretOffset.ToString(CultureInfo.CurrentCulture)),
                    new DumpRecord("MetricDataFormat", MetricDataFormat.ToString(CultureInfo.CurrentCulture)),
                    new DumpRecord("HmtxHMetricCount", HmtxHMetricCount.ToString(CultureInfo.CurrentCulture)),
                },
                null);
    }
}
