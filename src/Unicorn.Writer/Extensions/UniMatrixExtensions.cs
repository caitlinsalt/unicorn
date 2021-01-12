using Unicorn.CoreTypes;
using Unicorn.Writer.Primitives;

namespace Unicorn.Writer.Extensions
{
    /// <summary>
    /// Extension methods for the <see cref="UniMatrix" /> struct.
    /// </summary>
    public static class UniMatrixExtensions
    {
        /// <summary>
        /// Convert a <see cref="UniMatrix" /> value into an array of <see cref="PdfReal" /> values.  Note that this does not return a <see cref="PdfArray" />, 
        /// as the <c>cm</c> operator takes six individual parameters.
        /// </summary>
        /// <param name="matrix">The matrix to be converted.</param>
        /// <returns>An array of six elements consisting of the first two elements of each row of the matrix.  The constant elements are ignored.</returns>
        public static PdfReal[] ToPdfRealArray(this UniMatrix matrix)
        {
            return new[] 
            { 
                new PdfReal(matrix.R0C0), 
                new PdfReal(matrix.R0C1), 
                new PdfReal(matrix.R1C0), 
                new PdfReal(matrix.R1C1), 
                new PdfReal(matrix.R2C0), 
                new PdfReal(matrix.R2C1) 
            };
        }
    }
}
