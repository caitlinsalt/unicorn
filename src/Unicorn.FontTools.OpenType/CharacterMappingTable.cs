using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unicorn.FontTools.OpenType.Extensions;
using Unicorn.FontTools.OpenType.Utility;

namespace Unicorn.FontTools.OpenType
{
    /// <summary>
    /// The 'cmap' table, containing a set of mappings from character encoding code points to font glyph IDs.
    /// </summary>
    public class CharacterMappingTable : Table
    {
        /// <summary>
        /// The set of mappings which make up the table data.
        /// </summary>
        public CharacterMappingCollection Mappings { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="data">The set of mappings contained in the table.</param>
        public CharacterMappingTable(IEnumerable<CharacterMapping> data) : base("cmap")
        {
            Mappings = new CharacterMappingCollection(data);
        }

        /// <summary>
        /// Find the character mapping for the given platform and encoding if available.
        /// </summary>
        /// <param name="platform">The platform to find the mapping for.</param>
        /// <param name="encoding">The encoding to find the mapping for.</param>
        /// <returns>The <see cref="CharacterMapping" /> instance for the given platform and encoding, or <c>null</c> if no such mapping is defined.</returns>
        public CharacterMapping SelectExactMapping(PlatformId platform, int encoding)
        {
            return Mappings.FirstOrDefault(m => m.Platform == platform && m.Encoding == encoding);
        }

        /// <summary>
        /// Determine which character mapping, out of those available in this font, is the best one to use for the requested platform and encoding.
        /// </summary>
        /// <param name="platform">The platform to choose a mapping for.</param>
        /// <param name="encoding">The encoding to choose a mapping for.</param>
        /// <returns>The <see cref="CharacterMapping" /> instance for the given platform and encoding if available; the closest mapping if not, or <c>null</c>
        /// if no suitable mapping could be found.</returns>
        public CharacterMapping SelectBestMapping(PlatformId platform, int encoding)
        {
            if (platform == PlatformId.Windows)
            {
                return SelectExactMapping(platform, encoding) ?? SelectExactMapping(platform, 10) ?? SelectExactMapping(platform, 1);
            }
            if (platform == PlatformId.Macintosh)
            {
                return SelectExactMapping(platform, encoding) ?? SelectExactMapping(platform, 0) ?? Mappings.FirstOrDefault(m => m.Platform == platform);
            }
            return SelectExactMapping(platform, encoding) ?? Mappings.LastOrDefault(m => m.Platform == platform);
        }

        /// <summary>
        /// Determine which character mapping, out of those available in this font, is the best one to use for the given platform.
        /// </summary>
        /// <param name="platform">The platform to choose the mapping for.</param>
        /// <returns>A <see cref="CharacterMapping" /> instance, or <c>null</c> if nothing suitable is available.</returns>
        public CharacterMapping SelectBestMapping(PlatformId platform)
        {
            if (platform == PlatformId.Windows)
            {
                return SelectBestMapping(platform, 10);
            }
            return SelectBestMapping(platform, 255);
        }

        /// <summary>
        /// Dump the content of this table to a <see cref="TextWriter" />.  Returns silently if the parameter is <c>null</c>.
        /// </summary>
        /// <param name="writer">The writer to dump output to.</param>
        public override void Dump(TextWriter writer)
        {
            if (writer is null)
            {
                return;
            }
            writer.WriteLine($"cmap table has {Mappings.Count} character mappings.");
            foreach (CharacterMapping map in Mappings)
            {
                map.Dump(writer);
            }
        }

        private static int SubtableRecordOffset(int baseOffset, int count) => baseOffset + 4 + 8 * count;

        private static Func<PlatformId, int, byte[], int, CharacterMapping> GetSubtableBuilderMethod(CharacterMappingFormat version)
        {
            switch (version)
            {
                case CharacterMappingFormat.PlainByteMapping:
                    return PlainByteCharacterMapping.FromBytes;
                case CharacterMappingFormat.HighByteSubheaderMapping:
                    return HighByteSubheaderCharacterMapping.FromBytes;
                case CharacterMappingFormat.SegmentedMapping:
                    return SegmentedCharacterMapping.FromBytes;
                case CharacterMappingFormat.TrimmedTableMapping:
                    return TrimmedTableCharacterMapping.FromBytes;
                case CharacterMappingFormat.Segmented32BitMapping:
                case CharacterMappingFormat.ManyToOneMapping:
                case CharacterMappingFormat.Mixed32BitMapping:
                    return Segmented32BitCharacterMapping.FromBytes;
                case CharacterMappingFormat.Trimmed32BitTableMapping:
                    return Trimmed32BitTableCharacterMapping.FromBytes;
                default:
                    return null;
            }
        }

        /// <summary>
        /// Construct a <see cref="CharacterMappingTable" /> from an array of bytes.
        /// </summary>
        /// <param name="arr">The array of data to load from.</param>
        /// <param name="offset">The index of the start of the table within the data array.</param>
        /// <param name="len">The length of the table data within the array.</param>
        /// <returns></returns>
        public static CharacterMappingTable FromBytes(byte[] arr, int offset, int len)
        {
            FieldValidation.ValidateNonNegativeIntegerParameter(len, nameof(len));
            if (len < 4)
            {
                throw new ArgumentException(Resources.CharacterMappingTable_FromBytes_InsufficientLength, nameof(len));
            }
            ushort mappingCount = arr.ToUShort(offset + 2);
            List<CharacterMapping> subtables = new List<CharacterMapping>(mappingCount);
            for (int i = 0; i < mappingCount; ++i)
            {
                PlatformId platform = (PlatformId)arr.ToUShort(SubtableRecordOffset(offset, i));
                ushort encoding = arr.ToUShort(SubtableRecordOffset(offset, i) + 2);
                int mappingOffset = arr.ToInt(SubtableRecordOffset(offset, i) + 4);
                CharacterMappingFormat subtableVersion = (CharacterMappingFormat) arr.ToUShort(offset + mappingOffset);
                Func<PlatformId, int, byte[], int, CharacterMapping> builder = GetSubtableBuilderMethod(subtableVersion);
                if (builder != null)
                {
                    subtables.Add(builder(platform, encoding, arr, offset + mappingOffset));
                }
            }
            return new CharacterMappingTable(subtables);
        }
    }
}
