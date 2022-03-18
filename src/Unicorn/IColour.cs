using System.Collections.Generic;
using Unicorn.Base;
using Unicorn.Writer.Primitives;

namespace Unicorn
{
    /// <summary>
    /// Represents a colour in a PDF document, including knowledge of the colour space it is in.  This interface extends the <see cref="IUniColour" /> interface by
    /// requiring implementations to provide methods for generating the low-level PDF stroke and non-stroke colour selection operators to select this colour.  These
    /// methods are required by the Unicorn drawing operations.
    /// </summary>
    public interface IColour : IUniColour
    {
        /// <summary>
        /// Return a sequence of <see cref="PdfOperator"/>s to change the selected stroke colour from <c>currentColour</c> to this.  This may be an empty sequence
        /// (if <c>currentColour</c> equals this colour), two operators (a colour space selection operator followed by a colour selection operator) or one (a 
        /// colour selection operator alone, or a combined space-and-colour selection operator).
        /// </summary>
        /// <param name="currentColour">The currently-selected stroke colour.</param>
        /// <returns>A sequence of either zero, one or two <see cref="PdfOperator" /> objects.</returns>
        IEnumerable<PdfOperator> StrokeSelectionOperators(IUniColour currentColour);

        /// <summary>
        /// Return a sequence of <see cref="PdfOperator"/>s to change the selected non-stroke colour from <c>currentColour</c> to this.  This may be an empty sequence
        /// (if <c>currentColour</c> equals this colour), two operators (a colour space selection operator followed by a colour selection operator) or one (a 
        /// colour selection operator alone, or a combined space-and-colour selection operator).
        /// </summary>
        /// <param name="currentColour">The currently-selected non-stroke colour.</param>
        /// <returns>A sequence of either zero, one or two <see cref="PdfOperator" /> objects.</returns>
        IEnumerable<PdfOperator> NonStrokeSelectionOperators(IUniColour currentColour);

        /// <summary>
        /// In general, in a PDF, the components of a colour are treated as continuous ranges between 0 and 1 inclusive.  The exception to this is when handling
        /// rasterised image data, when the components are treated as unsigned integers.  This value gives the size of those integers for a given colour implementation.
        /// It is limited to the values 1, 2, 4 or 8.  Within Unicorn, all implementations of this interface use 8 bits per component at present, although this may
        /// vary in future.
        /// </summary>
        int BitsPerComponent { get; }

        /// <summary>
        /// In general, in a PDF, the components of a colour are treated as continuous ranges between 0 and 1 inclusive.  The exception to this is when handling
        /// rasterised image data, when the components are treated as unsigned integers.  This value gives the bytes which represent a single sample of this colour in a
        /// rasterised image.
        /// </summary>
        /// <remarks>
        /// In rasterised image data, the image data bits are packed, and only the first sample of each row starts on a byte boundary.  Because of this, if <see cref="BitsPerComponent"/>
        /// is less than 8, the value of this property must also be packed, and if the code assembles a row of image data from multiple <see cref="ComponentData"/> values, they may also 
        /// need to be packed within a row.  For example, if a colour has four bits per component and three components, this property will be two bytes with the low 4 bits of the
        /// second byte all zero, and to assemble a row, alternate samples will need to be bit-shifted half a byte with the high bits of the first byte becoming the low bits of the
        /// second byte of the previous sample.
        /// </remarks>
        IEnumerable<byte> ComponentData { get; }
    }
}
