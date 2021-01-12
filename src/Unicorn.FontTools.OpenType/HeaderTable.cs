using System;
using System.IO;
using Unicorn.FontTools.OpenType.Extensions;
using Unicorn.FontTools.OpenType.Utility;

namespace Unicorn.FontTools.OpenType
{
    /// <summary>
    /// The font header table.
    /// </summary>
    public class HeaderTable : Table
    {
        /// <summary>
        /// Major version number (normally 1).
        /// </summary>
        public int MajorVersion { get; }

        /// <summary>
        /// Minor version number (normally 0).
        /// </summary>
        public int MinorVersion { get; }

        /// <summary>
        /// Revision number.
        /// </summary>
        public decimal Revision { get; }

        /// <summary>
        /// Checksub adjustment value.
        /// </summary>
        public long ChecksumAdjustment { get; }

        /// <summary>
        /// Magic number (normally 0x5f0f3c5f)
        /// </summary>
        public long Magic { get; }

        /// <summary>
        /// Font flags.
        /// </summary>
        public FontProperties Flags { get; }

        /// <summary>
        /// Number of font design units per em.
        /// </summary>
        public int FontUnitScale { get; }

        /// <summary>
        /// Date font created.
        /// </summary>
        public DateTime Created { get; }

        /// <summary>
        /// Date font last modified.
        /// </summary>
        public DateTime Modified { get; }

        /// <summary>
        /// Minimum x-value for all non-empty glyph bounding boxes.
        /// </summary>
        public short XMin { get; }

        /// <summary>
        /// Minimum y-value for all non-empty glyph bounding boxes.
        /// </summary>
        public short YMin { get; }

        /// <summary>
        /// Maximum x-value for all non-empty glyph bounding boxes.
        /// </summary>
        public short XMax { get; }

        /// <summary>
        /// Maximum y-value for all non-empty glyph bounding boxes.
        /// </summary>
        public short YMax { get; }

        /// <summary>
        /// Font style flags.  Apple-style calculations use this field in preference to <see cref="OS2MetricsTable.FontSelection" />.
        /// </summary>
        public MacStyleProperties StyleFlags { get; }

        /// <summary>
        /// The smallest pixel size at which this font is still considered legible.
        /// </summary>
        public int SmallestReadablePixelSize { get; }

        /// <summary>
        /// Typical character direction.  Deprecated; normally set to <see cref="FontDirectionHint.NeutralOrLeftToRight"/>.
        /// </summary>
        public FontDirectionHint DirectionHint { get; }

        /// <summary>
        /// If true, offset values in some tables are 32-bit offsets.  If false, they are 16-bit offsets.
        /// </summary>
        public bool UseLongOffsets { get; }

        /// <summary>
        /// Glyph data format.  Normally zero at present.
        /// </summary>
        public short GlyphDataFormat { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="majorVersion">The <see cref="MajorVersion" /> property value.</param>
        /// <param name="minorVersion">The <see cref="MinorVersion" /> property value.</param>
        /// <param name="rev">The <see cref="Revision" /> property value.</param>
        /// <param name="checksumAdj">The <see cref="ChecksumAdjustment" /> property value.</param>
        /// <param name="magic">The <see cref="Magic" /> property value.</param>
        /// <param name="flags">The <see cref="Flags"/> property value.</param>
        /// <param name="scale">The <see cref="FontUnitScale" /> property value.</param>
        /// <param name="created">The <see cref="Created" /> property value.</param>
        /// <param name="modified">The <see cref="Modified" /> property value.</param>
        /// <param name="xMin">The <see cref="XMin" /> property value.</param>
        /// <param name="yMin">The <see cref="YMin" /> property value.</param>
        /// <param name="xMax">The <see cref="XMax" /> property value.</param>
        /// <param name="yMax">The <see cref="YMax" /> property value.</param>
        /// <param name="styleFlags">The <see cref="StyleFlags" /> property value.</param>
        /// <param name="smallestReadableSize">The <see cref="SmallestReadablePixelSize" /> property value.</param>
        /// <param name="dirHint">The <see cref="DirectionHint" /> property value.</param>
        /// <param name="useLongOffsets">The <see cref="UseLongOffsets" /> property value.</param>
        /// <param name="dataFormat">The <see cref="GlyphDataFormat" /> property value.</param>
        public HeaderTable(int majorVersion, int minorVersion, decimal rev, long checksumAdj, long magic, FontProperties flags, int scale, DateTime created,
            DateTime modified, short xMin, short yMin, short xMax, short yMax, MacStyleProperties styleFlags, int smallestReadableSize, FontDirectionHint dirHint,
            bool useLongOffsets, short dataFormat)
            : base("head")
        {
            FieldValidation.ValidateUShortParameter(majorVersion, nameof(majorVersion));
            FieldValidation.ValidateUShortParameter(minorVersion, nameof(minorVersion));
            FieldValidation.ValidateUShortParameter(scale, nameof(scale));
            FieldValidation.ValidateUShortParameter(smallestReadableSize, nameof(smallestReadableSize));
            FieldValidation.ValidateUIntParameter(checksumAdj, nameof(checksumAdj));
            FieldValidation.ValidateUIntParameter(magic, nameof(magic));

            MajorVersion = majorVersion;
            MinorVersion = minorVersion;
            Revision = rev;
            ChecksumAdjustment = checksumAdj;
            Magic = magic;
            Flags = flags;
            FontUnitScale = scale;
            Created = created;
            Modified = modified;
            XMin = xMin;
            YMin = yMin;
            XMax = xMax;
            YMax = yMax;
            StyleFlags = styleFlags;
            SmallestReadablePixelSize = smallestReadableSize;
            DirectionHint = dirHint;
            UseLongOffsets = useLongOffsets;
            GlyphDataFormat = dataFormat;
        }

        /// <summary>
        /// Convert a byte array into a <see cref="HeaderTable" /> object.
        /// </summary>
        /// <param name="data">The array to be converted.</param>
        /// <param name="offset">The data start offset.</param>
        /// <param name="len">Table length.</param>
        /// <returns>A <see cref="HeaderTable" /> instance.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the array is insufficiently long to carry out the conversion.</exception>
        public static HeaderTable FromBytes(byte[] data, int offset, int len)
        {
            FieldValidation.ValidateNonNegativeIntegerParameter(len, nameof(len));
            if (len < 54)
            {
                throw new InvalidOperationException(Resources.HeaderTable_FromBytes_InsufficientDataError);
            }
            return new HeaderTable(
                data.ToUShort(offset),                          // MajorVersion
                data.ToUShort(offset + 2),                      // MinorVersion
                data.ToFixed(offset + 4),                       // Revision
                data.ToUInt(offset + 8),                        // ChecksumAdjustment
                data.ToUInt(offset + 12),                       // Magic
                (FontProperties)data.ToUShort(offset + 16),          // FontFlags
                data.ToUShort(offset + 18),                     // FontUnitScale
                data.ToDateTime(offset + 20),                   // Created
                data.ToDateTime(offset + 28),                   // Modified
                data.ToShort(offset + 36),                      // XMin
                data.ToShort(offset + 38),                      // YMin
                data.ToShort(offset + 40),                      // XMax
                data.ToShort(offset + 42),                      // YMax
                (MacStyleProperties)data.ToUShort(offset + 44),      // StyleFlags
                data.ToUShort(offset + 46),                     // SmallestReadablePixelSize
                (FontDirectionHint)data.ToShort(offset + 48),   // DirectionHint
                data.ToShort(offset + 50) == 1,                 // UseLongOffsets
                data.ToShort(offset + 52));                     // GlyphDataFormat
        }

        /// <summary>
        /// Dump contents of table to a <see cref="TextWriter" />.  Returns silently if the parameter is null.
        /// </summary>
        /// <param name="writer">The destination to dump to.</param>
        public override void Dump(TextWriter writer)
        {
            if (writer is null)
            {
                return;
            }
            writer.WriteLine("head table contents:");
            writer.WriteLine("Field                     | Value");
            writer.WriteLine("--------------------------|-------------------------------------------");
            writer.WriteLine($"MajorVersion              | {MajorVersion}");
            writer.WriteLine($"MinorVersion              | {MinorVersion}");
            writer.WriteLine($"Revision                  | {Revision}");
            writer.WriteLine($"ChecksumAdjustment        | {ChecksumAdjustment}");
            writer.WriteLine($"Magic                     | {Magic}");
            writer.WriteLine($"Flags                     | {Flags}");
            writer.WriteLine($"FontUnitScale             | {FontUnitScale}");
            writer.WriteLine($"Created                   | {Created}");
            writer.WriteLine($"Modified                  | {Modified}");
            writer.WriteLine($"XMin                      | {XMin}");
            writer.WriteLine($"YMin                      | {YMin}");
            writer.WriteLine($"XMax                      | {XMax}");
            writer.WriteLine($"YMax                      | {YMax}");
            writer.WriteLine($"StyleFlags                | {StyleFlags}");
            writer.WriteLine($"SmallestReadablePixelSize | {SmallestReadablePixelSize}");
            writer.WriteLine($"DirectionHint             | {DirectionHint}");
            writer.WriteLine($"UseLongOffsets            | {UseLongOffsets}");
            writer.WriteLine($"GlyphDataFormat           | {GlyphDataFormat}");
        }
    }
}
