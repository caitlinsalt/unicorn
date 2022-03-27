using System;
using System.Text;
using Unicorn.Base;
using Unicorn.Writer.Interfaces;

namespace Unicorn.Writer.Primitives
{
    /// <summary>
    /// Immutable class representing a reference to a PDF indirect object.
    /// </summary>
    public class PdfReference : PdfSimpleObject, IPdfReference, IPdfInternalReference, IEquatable<PdfReference>
    {
        /// <summary>
        /// The ID of the object that this reference refers to.
        /// </summary>
        public int ObjectId { get; }

        /// <summary>
        /// The generation number of the object that this reference refers to.
        /// </summary>
        public int Generation { get; }

        /// <summary>
        /// The generation number of the object that this reference refers to.
        /// </summary>
        public int Version => Generation;
        
        /// <summary>
        /// Value-setting constructor.
        /// </summary>
        /// <param name="referent">The indirect object that this should be a reference to.</param>
        /// <exception cref="ArgumentNullException">Thrown if the referent parameter is null.</exception>
        public PdfReference(IPdfIndirectObject referent)
        {
            if (referent is null)
            {
                throw new ArgumentNullException(nameof(referent));
            }
            ObjectId = referent.ObjectId;
            Generation = referent.Generation;
        }

        private PdfReference(int objectId, int generation)
        {
            ObjectId = objectId;
            Generation = generation;
        }

        /// <summary>
        /// Convert any <see cref="IPdfInternalReference"/> implementation into a <see cref="PdfReference"/>
        /// </summary>
        /// <param name="reference">An <see cref="IPdfInternalReference"/>.</param>
        /// <returns>
        /// A <see cref="PdfReference"/> referring to the same PDF object as the parameter.  
        /// If the paraeter is a <see cref="PdfReference"/> instance, it may itself be returned.
        /// </returns>
        public static PdfReference FromInternalReference(IPdfInternalReference reference)
        {
            if (reference is null)
            {
                return null;
            }
            if (reference is PdfReference pdfReference)
            {
                return pdfReference;
            }
            return new PdfReference(reference.ObjectId, reference.Version);
        }

        /// <summary>
        /// Converts this object to an array of bytes.
        /// </summary>
        /// <returns>An array of bytes representing this object.</returns>
        protected override byte[] FormatBytes()
        {
            return Encoding.ASCII.GetBytes($"{ObjectId} {Generation} R\xa");
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
            return ObjectId == other.ObjectId && Generation == other.Generation;
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
            return ObjectId.GetHashCode() ^ Generation.GetHashCode();
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
