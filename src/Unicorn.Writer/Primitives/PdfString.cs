using System;
using System.Text;

namespace Unicorn.Writer.Primitives
{
    /// <summary>
    /// An immutable class representing a PDF string.
    /// </summary>
    public class PdfString : PdfSimpleObject, IEquatable<PdfString>
    {
        /// <summary>
        /// The value of this object.
        /// </summary>
        public string Value { get; }
      
        /// <summary>
        /// Value-setting constructor.
        /// </summary>
        /// <param name="val">The value of the new object.</param>
        public PdfString(string val)
        {
            Value = val;
        }

        /// <summary>
        /// Convert this object into an array of bytes.
        /// </summary>
        /// <returns>An array of bytes representing the contents of the object.</returns>
        protected override byte[] FormatBytes()
        {
            StringBuilder sb = new StringBuilder(Value);
            sb.Replace("\\", @"\\");
            sb.Replace("\xa", @"\n");
            sb.Replace("\xd", @"\r");
            sb.Replace("\t", @"\t");
            sb.Replace("\b", @"\b");
            sb.Replace("\f", @"\f");
            if (EscapeParenthesesNeeded())
            {
                sb.Replace("(", @"\(");
                sb.Replace(")", @"\)");
            }
            sb.Insert(0, "(");
            sb.Append(')');
            for (int i = 253; i < sb.Length; i += 253)
            {
                sb.Insert(i, "\\\n");
            }
            return Encoding.UTF8.GetBytes(sb.ToString());
        }

        private bool EscapeParenthesesNeeded()
        {
            int diff = 0;
            foreach (char c in Value)
            {
                if (c == '(')
                {
                    diff++;
                }
                else if (c == ')')
                {
                    diff--;
                    if (diff < 0)
                    {
                        return true;
                    }
                }
            }
            return diff != 0;
        }

        /// <summary>
        /// Equality test.
        /// </summary>
        /// <param name="other">The object to test against.</param>
        /// <returns>True if the two instances are equal in value; false otherwise.</returns>
        public bool Equals(PdfString other)
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
        /// Equality test.
        /// </summary>
        /// <param name="obj">The object to test against.</param>
        /// <returns>True if the other object is a <see cref="PdfString" /> instance that is equal in value to this object; false otherwise.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as PdfString);
        }

        /// <summary>
        /// Get a hash code for this object.
        /// </summary>
        /// <returns>A hashcode that is derived from the value of this object.</returns>
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="a">A <see cref="PdfString" /> instance.</param>
        /// <param name="b">Another <see cref="PdfString" /> instance.</param>
        /// <returns>True if the two operands are equal in value; false otherwise.</returns>
        public static bool operator ==(PdfString a, PdfString b)
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
        /// <param name="a">A <see cref="PdfString" /> instance.</param>
        /// <param name="b">Another <see cref="PdfString" /> instance.</param>
        /// <returns>True if the two operands are unequal in value; false otherwise.</returns>
        public static bool operator !=(PdfString a, PdfString b)
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
