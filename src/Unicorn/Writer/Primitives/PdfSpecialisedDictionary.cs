using System;
using System.Collections.Generic;
using System.IO;

namespace Unicorn.Writer.Primitives
{

#pragma warning disable CA1711 // Identifiers should not have incorrect suffix - this is a dictionary in the PDF sense if not in the .NET sense.

    /// <summary>
    /// PDF documents contain a number of structures which are "dictionaries" - the PDF parlance for a name-value store - in specific formats, normally with a 
    /// <c>/Type</c> entry to specify what type of structure they are.  This type provides support for objects that are written to the PDF file as this kind of
    /// structure; examples include fonts, pages, page tree nodes, and the document catalogue itself.
    /// </summary>
    public abstract class PdfSpecialisedDictionary : PdfIndirectObject
    {
        /// <summary>
        /// Construct the dictionary which will be written to the output to represent this object.
        /// </summary>
        /// <returns>A <see cref="PdfDictionary" /> containing the properties of this object in the correct format.</returns>
        protected abstract PdfDictionary MakeDictionary();

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="objectId">The object ID of this indirect object, within its document.</param>
        /// <param name="generation">The generation number of this object.  As Unicorn does not currently support updating existing PDF files, this parameter
        /// should currently always be zero.</param>
        protected PdfSpecialisedDictionary(int objectId, int generation = 0) : base(objectId, generation)
        {
        }

        /// <summary>
        /// Write this dictionary to a <see cref="Stream" />.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <returns>The number of bytes written.</returns>
        public override int WriteTo(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            return Write(WriteToStream, MakeDictionary().WriteTo, stream);
        }

        /// <summary>
        /// Convert this dictionary into an array of bytes and append them to a list.
        /// </summary>
        /// <param name="bytes">The list to append the data to.</param>
        /// <returns></returns>
        public override int WriteTo(IList<byte> bytes)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException(nameof(bytes));
            }
            return Write(WriteToList, MakeDictionary().WriteTo, bytes);
        }
    }

#pragma warning restore CA1711 // Identifiers should not have incorrect suffix

}
