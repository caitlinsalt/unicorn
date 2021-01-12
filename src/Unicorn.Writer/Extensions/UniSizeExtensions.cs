using System;
using Unicorn.CoreTypes;
using Unicorn.Writer.Primitives;

namespace Unicorn.Writer.Extensions
{
    /// <summary>
    /// Extensions methods for the <see cref="UniSize" /> class.
    /// </summary>
    public static class UniSizeExtensions
    {
        private static readonly Lazy<PdfReal> _zero = new Lazy<PdfReal>(() => new PdfReal(0));

        /// <summary>
        /// Convert a <see cref="UniSize" /> instance into a <see cref="PdfRectangle" /> of the same size and with its bottom-left corner at the origin.
        /// </summary>
        /// <param name="size">The size to be converted.</param>
        /// <returns>A <see cref="PdfRectangle" /> instance of the same size as the parameter.</returns>
        /// <exception cref="NullReferenceException">Thrown if the size parameter is null.</exception>
        public static PdfRectangle ToPdfRectangle(this UniSize size)
        {
            return new PdfRectangle(_zero.Value, _zero.Value, new PdfReal(size.Width), new PdfReal(size.Height));
        }
    }
}
