using System;
using Unicorn.FontTools.OpenType.Extensions;
using Unicorn.FontTools.OpenType.Utility;

namespace Unicorn.FontTools.OpenType
{
    /// <summary>
    /// The "subheader record" portion of a character mapping Type 2 table.
    /// </summary>
    public struct HighByteSubheaderRecord : IEquatable<HighByteSubheaderRecord>
    {
        /// <summary>
        /// The start of the byte range that this table entry applies to.
        /// </summary>
        public byte FirstByte { get; }

        /// <summary>
        /// The end of the byte range that this table entry applies to.
        /// </summary>
        public byte LastByte { get; }

        /// <summary>
        /// Delta offset that is added to the final value looked up, to give a glyph ID.
        /// </summary>
        public short IdDelta { get; }

        /// <summary>
        /// Starting index in the lookup table, where the first entry for the block of codepoints described by this header is located.  Note that this value is
        /// different from the on-disk storage of an OpenType file, in which this value gives the offset from its own address to the target address.  This value will
        /// be within the range of a <see cref="ushort" />.
        /// </summary>
        public int StartIndex { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="first">Value for the <see cref="FirstByte" /> property.</param>
        /// <param name="last">Value for the <see cref="LastByte" /> property.</param>
        /// <param name="delta">Value for the <see cref="IdDelta" /> property.</param>
        /// <param name="start">Value for the <see cref="StartIndex" /> property. Must be within the range of a <see cref="ushort" />.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the <c>start</c> parameter is less than 0 or greater than 65,535.</exception>
        public HighByteSubheaderRecord(byte first, byte last, short delta, int start)
        {
            FieldValidation.ValidateUShortParameter(start, nameof(start));

            FirstByte = first;
            LastByte = last;
            IdDelta = delta;
            StartIndex = start;
        }

        /// <summary>
        /// Construct a <see cref="HighByteSubheaderRecord" /> value by loading data from an array of bytes.
        /// </summary>
        /// <param name="arr">The array of bytes to load from.</param>
        /// <param name="offset">The location in the array at which the start of the data is located.</param>
        /// <param name="rangeOffset">The value to subtract from the <see cref="StartIndex" /> property on loading to turn it into a start index, being the number
        /// of bytes from the loation of the value itself to the end of the array it is stored in.</param>
        /// <returns></returns>
        public static HighByteSubheaderRecord FromBytes(byte[] arr, int offset, int rangeOffset)
        {
            if (arr is null)
            {
                throw new ArgumentNullException(nameof(arr));
            }
            if (arr.Length < 8)
            {
                throw new InvalidOperationException();
            }
            return new HighByteSubheaderRecord(arr[offset + 1], (byte)(arr[offset + 1] + arr[offset + 3]), arr.ToShort(offset + 4), 
                (ushort)(arr.ToUShort(offset + 6) - rangeOffset));
        }

        /// <summary>
        /// Equality-test method.
        /// </summary>
        /// <param name="other">Another <see cref="HighByteSubheaderRecord" /> value.</param>
        /// <returns><c>true</c> if the parameter is equal to this value, <c>false if not.</c></returns>
        public bool Equals(HighByteSubheaderRecord other) => this == other;

        /// <summary>
        /// Equality-test method.
        /// </summary>
        /// <param name="obj">A value or object to compare.</param>
        /// <returns><c>true</c> if the parameter is a <see cref="HighByteSubheaderRecord" /> value that is equal to this one, <c>false</c> otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (obj is HighByteSubheaderRecord other)
            {
                return Equals(other);
            }
            return false;
        }

        /// <summary>
        /// Hash code method.
        /// </summary>
        /// <returns>A hashcode for this value.</returns>
        public override int GetHashCode()
        {
            return FirstByte.GetHashCode() ^ LastByte.GetHashCode() ^ IdDelta.GetHashCode() ^ StartIndex.GetHashCode();
        }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="a">A <see cref="HighByteSubheaderRecord" /> value.</param>
        /// <param name="b">A <see cref="HighByteSubheaderRecord" /> value.</param>
        /// <returns><c>true</c> if the operands are equal, <c>false</c> if not.</returns>
        public static bool operator ==(HighByteSubheaderRecord a, HighByteSubheaderRecord b)
        {
            return a.FirstByte == b.FirstByte && a.LastByte == b.LastByte && a.IdDelta == b.IdDelta && a.StartIndex == b.StartIndex;
        }

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="a">A <see cref="HighByteSubheaderRecord" /> value.</param>
        /// <param name="b">A <see cref="HighByteSubheaderRecord" /> value.</param>
        /// <returns><c>true</c> if the operands are not equal, <c>false</c> if they are.</returns>
        public static bool operator !=(HighByteSubheaderRecord a, HighByteSubheaderRecord b)
        {
            return a.FirstByte != b.FirstByte || a.LastByte != b.LastByte || a.IdDelta != b.IdDelta || a.StartIndex != b.StartIndex;
        }
    }
}
