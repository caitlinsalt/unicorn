using Unicorn.Writer.Interfaces;

namespace Unicorn.Writer.Primitives
{
#pragma warning disable CA1710 // Identifiers should have correct suffix

    /// <summary>
    /// Immutable class representing a PDF rectangle: a PDF array with four elements, representing the lower-left and upper-right corners of a non-rotated rectangle.
    /// The coordinates can be either integers or reals, but not a mixture.
    /// </summary>
    public class PdfRectangle : PdfArray
    {
        /// <summary>
        /// Constructor that takes <see cref="PdfInteger" /> parameters.
        /// </summary>
        /// <param name="lowerLeftX">The lower-left X coordinate.</param>
        /// <param name="lowerLeftY">The lower-left Y coordinate.</param>
        /// <param name="upperRightX">The upper-right X coordinate.</param>
        /// <param name="upperRightY">The upper-right Y coordinate.</param>
        public PdfRectangle(PdfInteger lowerLeftX, PdfInteger lowerLeftY, PdfInteger upperRightX, PdfInteger upperRightY) 
            : base(new IPdfPrimitiveObject[] { lowerLeftX, lowerLeftY, upperRightX ,upperRightY })
        {

        }

        /// <summary>
        /// Constructor that takes <see cref="PdfReal" /> parameters.
        /// </summary>
        /// <param name="lowerLeftX">The lower-left X coordinate.</param>
        /// <param name="lowerLeftY">The lower-left Y coordinate.</param>
        /// <param name="upperRightX">The upper-right X coordinate.</param>
        /// <param name="upperRightY">The upper-right Y coordinate.</param>
        public PdfRectangle(PdfReal lowerLeftX, PdfReal lowerLeftY, PdfReal upperRightX, PdfReal upperRightY)
            : base(new IPdfPrimitiveObject[] { lowerLeftX, lowerLeftY, upperRightX, upperRightY })
        {

        }

        /// <summary>
        /// Constructor that takes <see cref="int" /> parameters.
        /// </summary>
        /// <param name="lowerLeftX">The lower-left X coordinate.</param>
        /// <param name="lowerLeftY">The lower-left Y coordinate.</param>
        /// <param name="upperRightX">The upper-right X coordinate.</param>
        /// <param name="upperRightY">The upper-right Y coordinate.</param>
        public PdfRectangle(int lowerLeftX, int lowerLeftY, int upperRightX, int upperRightY)
            : this(new PdfInteger(lowerLeftX), new PdfInteger(lowerLeftY), new PdfInteger(upperRightX), new PdfInteger(upperRightY))
        {

        }

        /// <summary>
        /// Constructor that takes <see cref="double" /> parameters.
        /// </summary>
        /// <param name="lowerLeftX">The lower-left X coordinate.</param>
        /// <param name="lowerLeftY">The lower-left Y coordinate.</param>
        /// <param name="upperRightX">The upper-right X coordinate.</param>
        /// <param name="upperRightY">The upper-right Y coordinate.</param>
        public PdfRectangle(double lowerLeftX, double lowerLeftY, double upperRightX, double upperRightY)
            : this(new PdfReal(lowerLeftX), new PdfReal(lowerLeftY), new PdfReal(upperRightX), new PdfReal(upperRightY))
        {

        }
    }

#pragma warning restore CA1710 // Identifiers should have correct suffix
}
