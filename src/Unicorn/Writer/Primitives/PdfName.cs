using System;
using System.Text;

namespace Unicorn.Writer.Primitives
{
    /// <summary>
    /// Immutable class representing a PDF name object
    /// </summary>
    public class PdfName : PdfSimpleObject, IEquatable<PdfName>
    {
        /// <summary>
        /// The value of this name object.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Value-setting constructor.
        /// </summary>
        /// <param name="name">The value of the new object.</param>
        /// <exception cref="ArgumentNullException">Thrown if the parameter is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the parameter contains whitespace characters, or characters classed as "delimiters" by the PDF standard.</exception>
        public PdfName(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            if (ContainsWhitespace(name) || ContainsDelimiter(name))
            {
                throw new ArgumentOutOfRangeException(nameof(name), $"Name {name} contains illegal characters");
            }
            Value = name;
        }

        /// <summary>
        /// Convert this object to an array of bytes.
        /// </summary>
        /// <returns>An array of bytes representing this object.</returns>
        protected override byte[] FormatBytes()
        {
            return Encoding.UTF8.GetBytes($"/{Value} ");
        }

        private static bool ContainsWhitespace(string name)
        {
            return name.Contains(" ") || name.Contains("\x0") || name.Contains("\t") || name.Contains("\r") || name.Contains("\n") || name.Contains("\f");
        }

        private static bool ContainsDelimiter(string name)
        {
            return name.Contains("(") || name.Contains(")") || name.Contains("<") || name.Contains(">") || name.Contains("[") || name.Contains("]") || name.Contains("{") ||
                name.Contains("}") || name.Contains("/") || name.Contains("%");
        }

        /// <summary>
        /// Equality test method.
        /// </summary>
        /// <param name="other">The object to test against.</param>
        /// <returns>True if the other object has the same value as this; false otherwise.</returns>
        public bool Equals(PdfName other)
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
        /// <param name="obj">The object to test against.</param>
        /// <returns>True if the other object is a <see cref="PdfName" /> instance with the same value as this; false otherwise.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as PdfName);
        }

        /// <summary>
        /// Generate a hashcode for this object.
        /// </summary>
        /// <returns>The hashcode of the value of this object.</returns>
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="a">A <see cref="PdfName" /> instance.</param>
        /// <param name="b">Another <see cref="PdfName" /> instance.</param>
        /// <returns>True if the parameters are equal; false otherwise.</returns>
        public static bool operator ==(PdfName a, PdfName b)
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
        /// <param name="a">A <see cref="PdfName" /> instance.</param>
        /// <param name="b">Another <see cref="PdfName" /> instance.</param>
        /// <returns>True if the parameters are unequal; false otherwise.</returns>
        public static bool operator !=(PdfName a, PdfName b)
        {
            if (ReferenceEquals(a, b))
            {
                return false;
            }
            if (a == null || b == null)
            {
                return true;
            }
            return a.Value != b.Value;
        }
    }
}
