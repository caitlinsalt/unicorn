using System;

namespace Unicorn.Writer.Primitives
{
    /// <summary>
    /// The class which represents a true or false value.  It is immutable and its constructor is private, but it provides static properties to obtain true and false instances, as well as a 
    /// <see cref="Get(bool)" /> method to get the instance for a specific runtime value.
    /// </summary>
    public class PdfBoolean : PdfSimpleObject, IEquatable<PdfBoolean>
    {
        private static readonly byte[] _true = { 0x74, 0x72, 0x75, 0x65, 0x20 };         // "true "
        private static readonly byte[] _false = { 0x66, 0x61, 0x6c, 0x73, 0x65, 0x20 };  // "false "

        /// <summary>
        /// The true value.
        /// </summary>
        public static readonly PdfBoolean True = new PdfBoolean(true);

        /// <summary>
        /// The false value.
        /// </summary>
        public static readonly PdfBoolean False = new PdfBoolean(false);

        /// <summary>
        /// The value of this object.
        /// </summary>
        public bool Value { get; }

        private PdfBoolean(bool val)
        {
            Value = val;
        }

        /// <summary>
        /// Get an instance 
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static PdfBoolean Get(bool val)
        {
            return val ? True : False;
        }

        /// <summary>
        /// Convert this instance into an array of bytes.
        /// </summary>
        /// <returns>An array of bytes encoding the values "true " and "false ".</returns>
        protected override byte[] FormatBytes()
        {
            return Value ? _true : _false;
        }

        /// <summary>
        /// Test if this instance is equal to a second instance.
        /// </summary>
        /// <param name="other">The instance to test against.</param>
        /// <returns>True if the other instance is equal to this; false if not.</returns>
        public bool Equals(PdfBoolean other)
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
        /// Test if this instance is equal to an object.
        /// </summary>
        /// <param name="obj">The object to test against.</param>
        /// <returns>True if the other object is equal to this; false if not.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as PdfBoolean);
        }

        /// <summary>
        /// Create a hash code for this instance.
        /// </summary>
        /// <returns>The hash code of the underlying true or false value.</returns>
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="a">A <see cref="PdfBoolean" /> instance.</param>
        /// <param name="b">A second <see cref="PdfBoolean" /> instance.</param>
        /// <returns>True if the two parameters are equal, false if not.</returns>
        public static bool operator ==(PdfBoolean a, PdfBoolean b)
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
        /// <param name="a">A <see cref="PdfBoolean" /> instance.</param>
        /// <param name="b">A second <see cref="PdfBoolean" /> instance.</param>
        /// <returns>True if the two parameters are unequal, false if not.</returns>
        public static bool operator !=(PdfBoolean a, PdfBoolean b)
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
