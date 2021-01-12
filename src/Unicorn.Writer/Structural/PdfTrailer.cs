using System;
using System.Globalization;
using System.IO;
using System.Text;
using Unicorn.Writer.Interfaces;
using Unicorn.Writer.Primitives;

namespace Unicorn.Writer.Structural
{
    /// <summary>
    /// Represents the trailer of a PDF file - the very last part, which contains links to the catalogue and the cross-ref table.
    /// </summary>
    public class PdfTrailer : IPdfWriteable
    {
        private readonly PdfCatalogue _root;
        private readonly PdfCrossRefTable _xrefs;
        private int? _xrefLocation;

        /// <summary>
        /// Value-setting constructor
        /// </summary>
        /// <param name="root">The page tree root of the document.</param>
        /// <param name="xrefs">The cross-reference table of the document.</param>
        public PdfTrailer(PdfCatalogue root, PdfCrossRefTable xrefs)
        {
            _root = root ?? throw new ArgumentNullException(nameof(root));
            _xrefs = xrefs ?? throw new ArgumentNullException(nameof(xrefs));
        }

        /// <summary>
        /// Record the byte offset, in the PDF file, of the cross-reference table.  This method must be called before the trailer is written to the stream.
        /// </summary>
        /// <param name="location">The address of the cross-reference table, in bytes from the start of the file.</param>
        public void SetCrossReferenceTableLocation(int location)
        {
            if (location <= 8)
            {
                throw new ArgumentOutOfRangeException(nameof(location),
                    string.Format(CultureInfo.CurrentCulture, Resources.Structural_PdfTrailer_SetCrossReferenceTableLocation_Invalid_Location_Error, location));
            }
            _xrefLocation = location;
        }

        /// <summary>
        /// Write this object to a <see cref="Stream" />.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <returns>The number of bytes written.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the stream parameter is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the <see cref="SetCrossReferenceTableLocation(int)" /> method has not been called to set the address of the cross-reference 
        /// table before writing the trailer to the stream.</exception>
        public int WriteTo(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            if (!_xrefLocation.HasValue)
            {
                throw new InvalidOperationException(Resources.Structural_PdfTrailer_WriteTo_CrossRef_Location_Not_Known_Error);
            }
            PdfDictionary dict = GetDictionary();
            int written = StreamWrite(stream, new byte[] { 0x74, 0x72, 0x61, 0x69, 0x6c, 0x65, 0x72, 0xa });                      // "trailer\n"
            written += dict.WriteTo(stream);
            written += StreamWrite(stream, new byte[] { 0x73, 0x74, 0x61, 0x72, 0x74, 0x78, 0x72, 0x65, 0x66, 0xa });             // "startxref\n"
            written += StreamWrite(stream, Encoding.ASCII.GetBytes(_xrefLocation.Value.ToString(CultureInfo.InvariantCulture)));
            written += StreamWrite(stream, new byte[] { 0xa, 0x25, 0x25, 0x45, 0x4f, 0x46 });                                     // "\n%%EOF"
            return written;
        }

        private PdfDictionary GetDictionary()
        {
            PdfDictionary dict = new PdfDictionary();
            dict.Add(CommonPdfNames.Size, new PdfInteger(_xrefs.Count));
            dict.Add(CommonPdfNames.Root, _root.GetReference());
            return dict;
        }

        private static int StreamWrite(Stream stream, byte[] bytes)
        {
            stream.Write(bytes, 0, bytes.Length);
            return bytes.Length;
        }
    }
}
