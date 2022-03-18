using System;
using System.Collections.Generic;
using Unicorn.Writer.Interfaces;
using Unicorn.Writer.Primitives;

namespace Unicorn.Writer.Streams
{

#pragma warning disable CA1711 // Identifiers should not have incorrect suffix.  This is a stream in the PDF sense if not in the .NET sense.

    /// <summary>
    /// A data stream that describes a rasterised image that consists of a single colour, for use in wireframing, mocking out layouts, and suchlike.
    /// </summary>
    public class PdfMockImageStream : PdfImageStream
    {
        /// <summary>
        /// Construct a data stream describing a rasterised image that consists of a single colour.
        /// </summary>
        /// <param name="objectId"></param>
        /// <param name="colour"></param>
        /// <param name="filters"></param>
        /// <param name="generation"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public PdfMockImageStream(int objectId, IColour colour, IEnumerable<IPdfFilterEncoder> filters = null, int generation = 0) : base(objectId, filters, generation)
        {
            if (colour == null)
            {
                throw new ArgumentNullException(nameof(colour));
            }

            MetaDictionary.Add(CommonPdfNames.Width, PdfInteger.One);
            MetaDictionary.Add(CommonPdfNames.Height, PdfInteger.One);
            MetaDictionary.Add(CommonPdfNames.ColourSpace, new PdfName(colour.ColourSpaceName));
            MetaDictionary.Add(CommonPdfNames.BitsPerComponent, new PdfInteger(colour.BitsPerComponent));
            AddBytes(colour.ComponentData);
        }
    }

#pragma warning restore CA1711 // Identifiers should not have incorrect suffix

}
