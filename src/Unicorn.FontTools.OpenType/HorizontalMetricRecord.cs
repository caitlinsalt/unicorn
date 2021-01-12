using System;
using Unicorn.FontTools.OpenType.Utility;

namespace Unicorn.FontTools.OpenType
{
    /// <summary>
    /// An entry in the horizontal metrics ('hmtx') table, giving the advance width and left side bearing of a particular glyph.
    /// </summary>
    public struct HorizontalMetricRecord : IEquatable<HorizontalMetricRecord>
    {
        /// <summary>
        /// The advance width of a glyph.  Within the range of a <see cref="ushort" />.
        /// </summary>
        public int AdvanceWidth { get; private set; }

        /// <summary>
        /// The left side bearing of a glyph.
        /// </summary>
        public short LeftSideBearing { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="advWidth">The value for the <see cref="AdvanceWidth" /> property.</param>
        /// <param name="lsb">The value for the <see cref="LeftSideBearing" /> property.</param>
        public HorizontalMetricRecord(int advWidth, short lsb)
        {
            FieldValidation.ValidateUShortParameter(advWidth, nameof(advWidth));

            AdvanceWidth = advWidth;
            LeftSideBearing = lsb;
        }

        /// <summary>
        /// Equality-test method.
        /// </summary>
        /// <param name="other">Another <see cref="HorizontalMetricRecord" /> value to compare.</param>
        /// <returns><c>true</c> if both properties of the other value are equal to those of this, <c>false</c> if not.</returns>
        public bool Equals(HorizontalMetricRecord other) => this == other;

        /// <summary>
        /// Equality-test method.
        /// </summary>
        /// <param name="obj">Another value or object.</param>
        /// <returns><c>true</c> if the parameter is another <see cref="HorizontalMetricRecord" /> value that is equal to this, <c>false</c> if not.</returns>
        public override bool Equals(object obj)
        {
            if (obj is HorizontalMetricRecord record)
            {
                return Equals(record);
            }
            return false;
        }

        /// <summary>
        /// Hash code method.
        /// </summary>
        /// <returns>A hash code derived from this value.</returns>
        public override int GetHashCode()
        {
            return AdvanceWidth.GetHashCode() ^ unchecked(LeftSideBearing * 2).GetHashCode();
        }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="a">A <see cref="HorizontalMetricRecord" /> value.</param>
        /// <param name="b">A <see cref="HorizontalMetricRecord" /> value.</param>
        /// <returns><c>true</c> if both operands are equal, <c>false</c> if not.</returns>
        public static bool operator ==(HorizontalMetricRecord a, HorizontalMetricRecord b)
        {
            return a.AdvanceWidth == b.AdvanceWidth && a.LeftSideBearing == b.LeftSideBearing;
        }

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="a">A <see cref="HorizontalMetricRecord" /> value.</param>
        /// <param name="b">A <see cref="HorizontalMetricRecord" /> value.</param>
        /// <returns><c>true</c> if the operands are different, <c>false</c> if they are equal.</returns>
        public static bool operator !=(HorizontalMetricRecord a, HorizontalMetricRecord b)
        {
            return a.AdvanceWidth != b.AdvanceWidth || a.LeftSideBearing != b.LeftSideBearing;
        }
    }
}
