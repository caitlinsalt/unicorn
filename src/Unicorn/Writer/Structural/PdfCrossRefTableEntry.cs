using System;
using Unicorn.Writer.Interfaces;

namespace Unicorn.Writer.Structural
{
    /// <summary>
    /// Class which represents an "occupied entry" in a <see cref="PdfCrossRefTable" />, consisting of an indirect object and its address in a PDF file.
    /// </summary>
    public class PdfCrossRefTableEntry
    {
        public int ObjectId { get; }

        public int ObjectGeneration { get; }

        /// <summary>
        /// The address of the <see cref="Value" /> object within its PDF file, as a byte offset from the start of the file.
        /// </summary>
        public int Offset { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="value">The indirect object that this entry refers to.</param>
        /// <param name="offset">The address of the object within its file.</param>
        public PdfCrossRefTableEntry(IPdfIndirectObject value, int offset)
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            ObjectId = value.ObjectId;
            ObjectGeneration = value.Generation;
            Offset = offset;
        }
    }
}
