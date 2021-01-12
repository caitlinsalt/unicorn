using System;
using System.Collections.Generic;
using System.Text;
using Unicorn.Writer.Interfaces;

namespace Unicorn.Writer.Primitives
{
    /// <summary>
    /// Immutable class representing a reference to a PDF indirect object.
    /// </summary>
    public class PdfReference : PdfSimpleObject, IEquatable<PdfReference>
    {
        /// <summary>
        /// The object this reference refers to.
        /// </summary>
        public IPdfIndirectObject Value { get; }
        
        /// <summary>
        /// Value-setting constructor.
        /// </summary>
        /// <param name="referent">The indirect object that this should be a reference to.</param>
        /// <exception cref="ArgumentNullException">Thrown if the referent parameter is null.</exception>
        public PdfReference(IPdfIndirectObject referent)
        {
            if (referent == null)
            {
                throw new ArgumentNullException(nameof(referent));
            }
            Value = referent;
        }

        /// <summary>
        /// Converts this object to an array of bytes.
        /// </summary>
        /// <returns>An array of bytes representing this object.</returns>
        protected override byte[] FormatBytes()
        {
            return Encoding.ASCII.GetBytes($"{Value.ObjectId} {Value.Generation} R\xa");
        }

        /// <summary>
        /// Equality-testing method.
        /// </summary>
        /// <param name="other">The object to test against.</param>
        /// <returns>True if both objects refer to the same indirect object; false otherwise.</returns>
        public bool Equals(PdfReference other)
        {
            if (other == null)
            {
                return false;
            }
            return Value.ObjectId == other.Value.ObjectId && Value.Generation == other.Value.Generation;
        }

        /// <summary>
        /// Equality-testing method.
        /// </summary>
        /// <param name="obj">The object to test against.</param>
        /// <returns>True if the parameter is a <see cref="PdfReference" /> instance referring to the same indirect object as this; false otherwise.</returns>
        public override bool Equals(object obj)
        {
            PdfReference other = obj as PdfReference;
            if (other == null)
            {
                return false;
            }
            return Equals(other);
        }

        /// <summary>
        /// Hash code method.
        /// </summary>
        /// <returns>A hash code derived from the value of this object.</returns>
        public override int GetHashCode()
        {
            return Value.ObjectId.GetHashCode() ^ Value.Generation.GetHashCode();
        }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="a">A <see cref="PdfReference" /> instance.</param>
        /// <param name="b">Another <see cref="PdfReference" /> instance.</param>
        /// <returns>True if the parameters are equal; false otherwise.</returns>
        public static bool operator ==(PdfReference a, PdfReference b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }
            if (a is null || b is null)
            {
                return false;
            }
            return a.Equals(b);
        }

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="a">A <see cref="PdfReference" /> instance.</param>
        /// <param name="b">Another <see cref="PdfReference" /> instance.</param>
        /// <returns>True if the parameters are unequal; false otherwise.</returns>
        public static bool operator !=(PdfReference a, PdfReference b)
        {
            if (ReferenceEquals(a, b))
            {
                return false;
            }
            if (a is null || b is null)
            {
                return true;
            }
            return !a.Equals(b);
        }
    }
}
