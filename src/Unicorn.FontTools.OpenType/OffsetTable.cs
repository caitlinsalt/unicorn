using Unicorn.FontTools.OpenType.Utility;

namespace Unicorn.FontTools.OpenType
{
    /// <summary>
    /// The offset table, or main header table for an OpenType font.
    /// </summary>
    public class OffsetTable
    {
        /// <summary>
        /// The kind of font.
        /// </summary>
        public FontKind FontKind { get; private set; }

        /// <summary>
        /// The number of tables that the font consists of.  Within the range of a <see cref="ushort" />.
        /// </summary>
        public int TableCount { get; private set; }

        /// <summary>
        /// The SearchRange field (derived from the number of tables).  Within the range of a <see cref="ushort" />.
        /// </summary>
        public int SearchRange { get; private set; }

        /// <summary>
        /// The EntrySelector field: the minimum number of bits needed to store the number of tables.  Within the range of a <see cref="ushort" /> according to 
        /// the OpenType spec, and must be 16 or less in reality.
        /// </summary>
        public int EntrySelector { get; private set; }

        /// <summary>
        /// The RangeShift field (derived from the number of tables).  Within the range of a <see cref="ushort" />.
        /// </summary>
        public int RangeShift { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="kind">Value of the <see cref="FontKind" /> property.</param>
        /// <param name="count">Value of the <see cref="TableCount" /> property.</param>
        /// <param name="searchRange">Value of the <see cref="SearchRange"/> property.</param>
        /// <param name="entrySelector">Value of the <see cref="EntrySelector" /> property.</param>
        /// <param name="rangeShift">Value of the <see cref="RangeShift" /> property.</param>
        public OffsetTable(FontKind kind, int count, int searchRange, int entrySelector, int rangeShift)
        {
            FieldValidation.ValidateUShortParameter(count, nameof(count));
            FieldValidation.ValidateUShortParameter(searchRange, nameof(searchRange));
            FieldValidation.ValidateUShortParameter(entrySelector, nameof(entrySelector));
            FieldValidation.ValidateUShortParameter(rangeShift, nameof(rangeShift));

            FontKind = kind;
            TableCount = count;
            SearchRange = searchRange;
            EntrySelector = entrySelector;
            RangeShift = rangeShift;
        }
    }
}
