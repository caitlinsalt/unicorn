using System;
using System.Collections.Generic;
using System.IO;
using Unicorn.Writer.Extensions;
using Unicorn.Writer.Interfaces;

namespace Unicorn.Writer.Primitives
{
    /// <summary>
    /// Class representing the PDF null object.  This class is a singleton; the instance is exposed through the <see cref="Value" /> property.
    /// </summary>
    public class PdfNull : IPdfPrimitiveObject, IEquatable<PdfNull>
    {
        /// <summary>
        /// The singleton instance of this class.
        /// </summary>
        public static readonly PdfNull Value = new PdfNull();

        private static readonly byte[] _bytes = { 0x6e, 0x75, 0x6c, 0x6c, 0x20 }; // "null "

        /// <summary>
        /// The length of this object when encoded as bytes.
        /// </summary>
        public int ByteLength => 5;

        private PdfNull() { }

        /// <summary>
        /// Write this object to a <see cref="Stream" />.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <returns>The number of bytes written.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the parameter is null.</exception>
        public int WriteTo(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            stream.Write(_bytes, 0, _bytes.Length);
            return _bytes.Length;
        }

        /// <summary>
        /// Convert this object to bytes and append them to a list.
        /// </summary>
        /// <param name="bytes">The list to append to.</param>
        /// <returns>The number of bytes appended.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the list parameter is null.</exception>
        public int WriteTo(IList<byte> bytes)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException(nameof(bytes));
            }
            bytes.AddRange(_bytes);
            return _bytes.Length;
        }

        /// <summary>
        /// Write this object to a <see cref="PdfStream" />.
        /// </summary>
        /// <param name="stream">The <see cref="PdfStream" /> to write to.</param>
        /// <returns>The number of bytes written.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the stream parameter is null.</exception>
        public int WriteTo(PdfStream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            stream.AddBytes(_bytes);
            return _bytes.Length;
        }

        /// <summary>
        /// Equality test method.
        /// </summary>
        /// <param name="other">Another <see cref="PdfNull" /> instance.</param>
        /// <returns>Returns true.</returns>
        public bool Equals(PdfNull other)
        {
            return !ReferenceEquals(other, null);
        }

        /// <summary>
        /// Equality test method.
        /// </summary>
        /// <param name="obj">An object to test against.</param>
        /// <returns>True if the parameter is a <see cref="PdfNull" /> instance; false otherwise.</returns>
        public override bool Equals(object obj)
        {
            return obj is PdfNull;
        }

        /// <summary>
        /// Return a hashcode for this object.
        /// </summary>
        /// <returns>A constant hashcode, as all <see cref="PdfNull" /> instances can be considered equal.</returns>
        public override int GetHashCode()
        {
            return 4472;
        }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="a">A <see cref="PdfNull" /> instance.</param>
        /// <param name="b">Another <see cref="PdfNull" /> instance.</param>
        /// <returns>True if the operands are both null or both not null; false otherwise</returns>
        public static bool operator ==(PdfNull a, PdfNull b)
        {
            return !((a is null) ^ (b is null));
        }

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="a">A <see cref="PdfNull" /> instance.</param>
        /// <param name="b">Another <see cref="PdfNull" /> instance.</param>
        /// <returns>False if the operands are both null or both not null; true otherwise.</returns>
        public static bool operator !=(PdfNull a, PdfNull b)
        {
            return (a is null) ^ (b is null);
        }
    }
}
