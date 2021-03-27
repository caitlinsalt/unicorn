namespace Unicorn.FontTools.OpenType
{
    /// <summary>
    /// The different character mapping subtable formats.  These values are defined in the OpenType specification.
    /// </summary>
    public enum CharacterMappingFormat
    {
        /// <summary>
        /// Subtable version 0 (plain byte mapping).
        /// </summary>
        PlainByteMapping = 0,

        /// <summary>
        /// Subtable version 2 (high byte mapped through subheader).
        /// </summary>
        HighByteSubheaderMapping = 2,

        /// <summary>
        /// Subtable version 4 (segmented tabular mapping).  This is the most common format for BMP Unicode fonts.
        /// </summary>
        SegmentedMapping = 4,

        /// <summary>
        /// Subtable version 6 (trimmed table mapping).
        /// </summary>
        TrimmedTableMapping = 6,

        /// <summary>
        /// Subtable version 8 (mixed 16- and 32-bit coverage).  "The use of this format is discouraged" according to the spec.
        /// </summary>
        Mixed32BitMapping = 8,

        /// <summary>
        /// Subtable version 10 (32-bit trimmed table mapping).  "This format is not widely used and is not supported by Microsoft."
        /// </summary>
        Trimmed32BitTableMapping = 10,

        /// <summary>
        /// Subtable version 12 (32-bit segmented tabular mapping).  This is the most common format for 32-bit Unicode fonts.
        /// </summary>
        Segmented32BitMapping = 12,

        /// <summary>
        /// Subtable version 13 (like version 12 but optimised for many-to-one mappings).
        /// </summary>
        ManyToOneMapping = 13,

        /// <summary>
        /// Subtable version 14 (Unicode Variation Sequence mapping table).
        /// </summary>
        VariationSequenceMapping = 14,
    }
}
