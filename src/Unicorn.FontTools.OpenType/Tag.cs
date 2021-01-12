using System;
using System.Text;

namespace Unicorn.FontTools.OpenType
{
    /// <summary>
    /// The OpenType tag type, used to identify a table.  In an OpenType file this consists of four ASCII bytes, but programmatically it is convenient to refer
    /// to it as a string, as the standard tags generally have a mnemonic meaning.
    /// </summary>
    public struct Tag : IEquatable<Tag>
    {
        /// <summary>
        /// The value of the tag, in string form.
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        /// Construct a tag from its raw bytes.
        /// </summary>
        /// <param name="value">An array of four bytes containing the tag's value.</param>
        /// <exception cref="ArgumentNullException">Thrown if the <c>value</c> parameter is null.</exception>
        /// <exception cref="ArgumentException">Thrown if the <c>value</c> parameter is not four bytes long.</exception>
        public Tag(byte[] value)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            if (value.Length != 4)
            {
                throw new ArgumentException(Resources.Tag_Constructor_ArrayLengthError, nameof(value));
            }
            Value = Encoding.ASCII.GetString(value);
        }

        /// <summary>
        /// Construct a tag from a group of bytes within an array.
        /// </summary>
        /// <param name="arr">An array of bytes.</param>
        /// <param name="offset">A location within the array to be taken as the start of a four-byte tag.</param>
        /// <exception cref="ArgumentNullException">Thrown if the <c>arr</c> parameter is null.</exception>
        /// <exception cref="ArgumentException">Thrown if the <c>offset</c> parameter is outside the bounds of the array, or less than four bytes from its 
        /// end.</exception>
        public Tag(byte[] arr, int offset)
        {
            if (arr is null)
            {
                throw new ArgumentNullException(nameof(arr));
            }
            if (arr.Length < offset + 4)
            {
                throw new ArgumentException(Resources.Tag_Constructor_ArrayLengthError, nameof(arr));
            }
            Value = Encoding.ASCII.GetString(arr, offset, 4);
        }

        /// <summary>
        /// Construct a tag from a string.
        /// </summary>
        /// <param name="value">A four-character string containing the tag's value.</param>
        /// <exception cref="ArgumentNullException">Thrown if the <c>value</c> parameter is null.</exception>
        /// <exception cref="ArgumentException">Thrown if the <c>value</c> parameter is not exactly four characters long.</exception>
        public Tag(string value)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            if (value.Length != 4)
            {
                throw new ArgumentException(Resources.Tag_Constructor_ArrayLengthError, nameof(value));
            }
            Value = value;
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="a">A <see cref="Tag" /> value.</param>
        /// <param name="b">A <see cref="Tag" /> value.</param>
        /// <returns><c>true</c> if the operands' <see cref="Value" /> properties are equal, <c>false</c> otherwise.</returns>
        public static bool operator ==(Tag a, Tag b)
        {
            return a.Value == b.Value;
        }

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="a">A <see cref="Tag" /> value.</param>
        /// <param name="b">A <see cref="Tag" /> value.</param>
        /// <returns><c>true</c> if the operands' <see cref="Value" /> properties differ, <c>false</c> if they are equal.</returns>
        public static bool operator !=(Tag a, Tag b)
        {
            return a.Value != b.Value;
        }

        /// <summary>
        /// Equality test method.
        /// </summary>
        /// <param name="other">Another <see cref="Tag" /> value.</param>
        /// <returns><c>true</c> if the parameter is equal to this value, <c>false</c> otherwise.</returns>
        public bool Equals(Tag other)
        {
            return this == other;
        }

        /// <summary>
        /// Equality test method.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Tag t)
            {
                return Equals(t);
            }
            return false;
        }

        /// <summary>
        /// Hash code method.
        /// </summary>
        /// <returns>A hash code representing this value.</returns>
        public override int GetHashCode()
        {
            return Value?.GetHashCode() ?? 60103;
        }

        /// <summary>
        /// String conversion method.
        /// </summary>
        /// <returns>The <see cref="Value" /> of this tag, as a string.</returns>
        public override string ToString()
        {
            return Value;
        }
    }
}