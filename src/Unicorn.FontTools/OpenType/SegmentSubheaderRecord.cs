using System;
using Unicorn.FontTools.OpenType.Utility;

namespace Unicorn.FontTools.OpenType
{
    /// <summary>
    /// A mapping segment for the OpenType type 4 character mapping.
    /// </summary>
    public struct SegmentSubheaderRecord : IEquatable<SegmentSubheaderRecord>
    {
        /// <summary>
        /// First codepoint the segment applies to.  Within the range of a <see cref="ushort" />.
        /// </summary>
        public int StartCode { get; }

        /// <summary>
        /// Last codepoint the segment applies to.  Within the range of a <see cref="ushort" />.
        /// </summary>
        public int EndCode { get; }

        /// <summary>
        /// Delta offset that is added to either the codepoint or the mapped result from the glyph mapping array, to get the final glyph ID.
        /// </summary>
        public short IdDelta { get; }

        /// <summary>
        /// Start location of this segment's data in the glyph mapping array, or -1 if the glyph mapping step should not be carried out.
        /// </summary>
        public int StartOffset { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="start">Value for the <see cref="StartCode" /> property.</param>
        /// <param name="end">Value for the <see cref="EndCode" /> property.</param>
        /// <param name="delta">Value for the <see cref="IdDelta" /> property.</param>
        /// <param name="offset">Value for the <see cref="StartOffset" /> property.</param>
        public SegmentSubheaderRecord(int start, int end, short delta, int offset)
        {
            FieldValidation.ValidateUShortParameter(start, nameof(start));
            FieldValidation.ValidateUShortParameter(end, nameof(end));

            StartCode = start;
            EndCode = end;
            IdDelta = delta;
            StartOffset = offset;
        }

        /// <summary>
        /// Equality test method.
        /// </summary>
        /// <param name="other">Another <see cref="SegmentSubheaderRecord" /> value.</param>
        /// <returns><c>true</c> if the parameter is equal in value to this, <c>false</c> if not.</returns>
        public bool Equals(SegmentSubheaderRecord other) => this == other;

        /// <summary>
        /// Equality test method.
        /// </summary>
        /// <param name="obj">Another object or value.</param>
        /// <returns><c>true</c> if the parameter is another <see cref="SegmentSubheaderRecord" /> value that is equal to this, <c>false</c> otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (obj is SegmentSubheaderRecord other)
            {
                return Equals(other);
            }
            return false;
        }

        /// <summary>
        /// Hash code method.
        /// </summary>
        /// <returns>A hash code for this value.</returns>
        public override int GetHashCode() => StartCode.GetHashCode() ^ EndCode.GetHashCode() ^ IdDelta.GetHashCode() ^ StartOffset.GetHashCode();

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="a">A <see cref="SegmentSubheaderRecord" /> value.</param>
        /// <param name="b">A <see cref="SegmentSubheaderRecord" /> value.</param>
        /// <returns><c>true</c> if the parameters are equal in value, <c>false</c> if not.</returns>
        public static bool operator ==(SegmentSubheaderRecord a, SegmentSubheaderRecord b)
            => a.StartCode == b.StartCode && a.EndCode == b.EndCode && a.IdDelta == b.IdDelta && a.StartOffset == b.StartOffset;

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="a">A <see cref="SegmentSubheaderRecord" /> value.</param>
        /// <param name="b">A <see cref="SegmentSubheaderRecord" /> value.</param>
        /// <returns><c>true</c> if the parameters are not equal in value, <c>false</c> if they are.</returns>
        public static bool operator !=(SegmentSubheaderRecord a, SegmentSubheaderRecord b)
            => a.StartCode != b.StartCode || a.EndCode != b.EndCode || a.IdDelta != b.IdDelta || a.StartOffset != b.StartOffset;
    }
}
