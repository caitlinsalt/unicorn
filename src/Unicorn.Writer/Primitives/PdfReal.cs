using System;
using System.Globalization;
using System.Text;

namespace Unicorn.Writer.Primitives
{
    /// <summary>
    /// Immutable class representing a real number.
    /// </summary>
    public class PdfReal : PdfNumber, IEquatable<PdfReal>
    {
        /// <summary>
        /// Value of this object.
        /// </summary>
        public decimal Value { get; }

        /// <summary>
        /// Value-setting constructor.
        /// </summary>
        /// <param name="val">The object value.</param>
        public PdfReal(decimal val)
        {
            Value = val;
        }

        /// <summary>
        /// Value-setting constructor.
        /// </summary>
        /// <param name="val">The object value.</param>
        public PdfReal(int val)
        {
            Value = val;
        }

        /// <summary>
        /// Value-setting constructor.
        /// </summary>
        /// <param name="val">The object value.</param>
        public PdfReal(float val)
        {
            Value = (decimal)val;
        }

        /// <summary>
        /// Value-setting constructor.
        /// </summary>
        /// <param name="val">The object value.</param>
        public PdfReal(double val)
        {
            Value = (decimal)val;
        }

        /// <summary>
        /// Convert this object to an array of bytes.
        /// </summary>
        /// <returns>An array of bytes representing the value of this object.</returns>
        protected override byte[] FormatBytes()
        {
            string formatted = Value.ToString("################0.0################ ", CultureInfo.InvariantCulture);
            return Encoding.ASCII.GetBytes(formatted);
        }

        /// <summary>
        /// Equality test method.
        /// </summary>
        /// <param name="other">The object to compare against.</param>
        /// <returns>True if the other object has the same value as this one; false otherwise.</returns>
        public bool Equals(PdfReal other)
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
        /// Equality test method.
        /// </summary>
        /// <param name="obj">The object to compare against.</param>
        /// <returns>True if the other object is a <see cref="PdfReal" /> instance with the same value as this one; false otherwise.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as PdfReal);
        }

        /// <summary>
        /// Generate a hash code for this object.
        /// </summary>
        /// <returns>The hash code of the object's value.</returns>
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="a">A <see cref="PdfReal" /> instance.</param>
        /// <param name="b">Another <see cref="PdfReal" /> instance.</param>
        /// <returns>True if the operands are equal in value; false otherwise.</returns>
        public static bool operator ==(PdfReal a, PdfReal b)
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
        /// <param name="a">A <see cref="PdfReal" /> instance.</param>
        /// <param name="b">Another <see cref="PdfReal" /> instance.</param>
        /// <returns>True if the operands are unequal in value; false otherwise.</returns>
        public static bool operator !=(PdfReal a, PdfReal b)
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

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="a">A <see cref="PdfReal" /> instance.</param>
        /// <param name="b">A <see cref="PdfInteger" /> instance.</param>
        /// <returns>True if the operands are equal in value; false otherwise.</returns>
        public static bool operator ==(PdfReal a, PdfInteger b)
        {
            if (a is null || b is null)
            {
                return false;
            }
            return a.Value == b.Value;
        }

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="a">A <see cref="PdfReal" /> instance.</param>
        /// <param name="b">A <see cref="PdfInteger" /> instance.</param>
        /// <returns>True if the operands are unequal in value; false otherwise.</returns>
        public static bool operator !=(PdfReal a, PdfInteger b)
        {
            if (a is null || b is null)
            {
                return true;
            }
            return a.Value != b.Value;
        }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="a">A <see cref="PdfInteger" /> instance.</param>
        /// <param name="b">A <see cref="PdfReal" /> instance.</param>
        /// <returns>True if the operands are equal in value; false otherwise.</returns>
        public static bool operator ==(PdfInteger a, PdfReal b)
        {
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
        /// <param name="b">A <see cref="PdfReal" /> instance.</param>
        /// <returns>True if the operands are unequal in value; false otherwise.</returns>
        public static bool operator !=(PdfInteger a, PdfReal b)
        {
            if (a is null || b is null)
            {
                return true;
            }
            return a.Value != b.Value;
        }
    }
}
