using System.Collections.Generic;
using Unicorn.Writer.Primitives;

namespace Unicorn.Writer.Interfaces
{
    /// <summary>
    /// The interface which represents "primitive objects" - the base types which make up PDF data, such as "integer", "real", "string" or "dictionary" (this is not an exclusive list).
    /// </summary>
    public interface IPdfPrimitiveObject : IPdfWriteable
    {
        /// <summary>
        /// The length of the object when converted to bytes.  PDF files have a limit of 255 characters between line-separators outwith streams; this property is used to determine if 
        /// a line separator may need to be inserted.
        /// </summary>
        int ByteLength { get; }

        /// <summary>
        /// Convert the object to bytes and append them to a list.
        /// </summary>
        /// <param name="bytes">The list to append the object's bytes to.</param>
        /// <returns>The number of bytes added to the list.</returns>
        int WriteTo(IList<byte> bytes);

        /// <summary>
        /// Write the object to a <see cref="PdfStream" />.
        /// </summary>
        /// <param name="stream">The stream to write the object to.</param>
        /// <returns>The number of bytes written.</returns>
        int WriteTo(PdfStream stream);
    }
}
