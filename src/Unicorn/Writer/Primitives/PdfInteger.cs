using System;
using System.Globalization;
using System.Text;

namespace Unicorn.Writer.Primitives
{
    /// <summary>
    /// The class which represents an immutable PDF integer object.
    /// </summary>
    public class PdfInteger : PdfNumber, IEquatable<PdfInteger>
    {
        private static readonly Lazy<PdfInteger> _zero = new Lazy<PdfInteger>(() => new PdfInteger(0));

        /// <summary>
        /// A canned <see cref="PdfInteger" /> instance for the value 0.
        /// </summary>
        public static PdfInteger Zero => _zero.Value;

        /// <summary>
        /// The integer value of the object.
        /// </summary>
        public int Value { get; }

        /// <summary>
        /// Value-setting constructor.
        /// </summary>
        /// <param name="val">The value of the object.</param>
        public PdfInteger(int val)
        {
            Value = val;
        }

        /// <summary>
        /// Convert this object into an array of bytes.
        /// </summary>
        /// <returns>An array of bytes representing the value of the object</returns>
        protected override byte[] FormatBytes()
        {
            string formatted = Value.ToString("d", CultureInfo.InvariantCulture) + " ";
            return Encoding.ASCII.GetBytes(formatted);
        }

        /// <summary>
        /// Test for equality.
        /// </summary>
        /// <param name="other">the object to test against.</param>
        /// <returns>True if the parameter has the same value as this object, false otherwise.</returns>
        public bool Equals(PdfInteger other)
        {
            if (other is null)
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return Value == other.Value;
        }

        /// <summary>
        /// Test for equality.
        /// </summary>
        /// <param name="obj">The object to test against.</param>
        /// <returns>True if the parameter is a <see cref="PdfInteger" /> instance with the same value as this object, false otherwise.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as PdfInteger);
        }

        /// <summary>
        /// Generate a hashcode based on the value of this object.
        /// </summary>
        /// <returns>The hashcode of the value of this object.</returns>
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="a">A <see cref="PdfInteger" /> instance.</param>
        /// <param name="b">A second <see cref="PdfInteger" /> instance.</param>
        /// <returns>True if the two instances are equal, false otherwise.</returns>
        public static bool operator ==(PdfInteger a, PdfInteger b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }
            if (a is null || b is null)
            {
                return false;
            }
            return a.Value == b.Value;
        }

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="a">A <see cref="PdfInteger" /> instance.</param>
        /// <param name="b">Another <see cref="PdfInteger" /> instance.</param>
        /// <returns>True if the two instances are unequal, false otherwise.</returns>
        public static bool operator !=(PdfInteger a, PdfInteger b)
        {
            if (ReferenceEquals(a, b))
            {
                return false;
            }
            if (a is null || b is null)
            {
                return true;
            }
            return a.Value != b.Value;
        }
    }
}
