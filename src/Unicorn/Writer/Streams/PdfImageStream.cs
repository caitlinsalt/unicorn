using System;
using System.Collections.Generic;
using Unicorn.Writer.Interfaces;
using Unicorn.Writer.Primitives;

namespace Unicorn.Writer.Streams
{

#pragma warning disable CA1711 // Identifiers should not have incorrect suffix.  This is a stream in the PDF sense if not in the .NET one.

    /// <summary>
    /// A particular family of PDF streams which contain rasterised image data, and as such, have additional metadata required to define
    /// its properties.
    /// </summary>
    public abstract class PdfImageStream : PdfStream
    {
        /// <summary>
        /// Construct a <see cref="PdfImageStream"/>.  This constructor is solely here to set two metadata properties which are
        /// common to all image stream objects but which do not depend on the image content: "/Type /XObject" and "/Subtype /Image".
        /// </summary>
        /// <param name="objectId">An indirect object ID obtained from a cross-reference table.</param>
        /// <param name="filters">The sequence of filters to apply to the stream data.  As Unicorn is focused on writing output, these are in encoding order.</param>
        /// <param name="generation">The generation number of this stream.  Defaults to 0.</param>
        protected PdfImageStream(int objectId, IEnumerable<IPdfFilterEncoder> filters = null, int generation = 0)
            : base(objectId, filters, null, generation)
        {
            MetaDictionary.Add(CommonPdfNames.Type, CommonPdfNames.XObject);
            MetaDictionary.Add(CommonPdfNames.Subtype, CommonPdfNames.Image);
        }

        /// <summary>
        /// Indicate that this stream cannot have further data added.
        /// </summary>
        public override bool CanAddData => false;

        /// <summary>
        /// Attempt (and fail) to add bytes to the data stream.
        /// </summary>
        /// <param name="bytes">THe data to attempt to add to the data stream.</param>
        /// <exception cref="InvalidOperationException">Always thrown, because image streams cannot have additional data appended.</exception>
        public override void AddBytes(IEnumerable<byte> bytes)
            => throw new InvalidOperationException(WriterResources.Streams_PdfImageStream_AddBytes_InvalidOperation_Error);
    }

#pragma warning restore CA1711 // Identifiers should not have incorrect suffix

}