using Unicorn.CoreTypes;
using Unicorn.Writer.Interfaces;
using Unicorn.Writer.Primitives;

namespace Unicorn.Writer.Extensions
{
    /// <summary>
    /// Extension methods for the <see cref="UniDashStyle" /> enumeration.
    /// </summary>
    public static class UniDashStyleExtensions
    {
        /// <summary>
        /// Convert a <see cref="UniDashStyle" /> value into the PDF operator for setting the current dash style of a content stream, and its operands.  
        /// If the scale parameter is set to the line width, the dots in styles with dots, and the gaps between dots and/or dashes, will be square.
        /// </summary>
        /// <param name="val"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
        public static IPdfPrimitiveObject[] ToPdfObjects(this UniDashStyle val, double scale)
        {
            IPdfPrimitiveObject[] output = new IPdfPrimitiveObject[2];
            output[1] = PdfInteger.Zero;  
            PdfReal square = val != UniDashStyle.Solid ? new PdfReal(scale) : null;
            switch (val)
            { 
                case UniDashStyle.Solid:
                default:
                    output[0] = new PdfArray();
                    break;
                case UniDashStyle.Dash:
                    output[0] = new PdfArray(new PdfReal(scale * 3), square);
                    break;
                case UniDashStyle.Dot:
                    output[0] = new PdfArray(new PdfReal(scale));
                    break;
                case UniDashStyle.DashDot:
                    output[0] = new PdfArray(new PdfReal(scale * 3), square, square, square);
                    break;
                case UniDashStyle.DashDotDot:
                    output[0] = new PdfArray(new PdfReal(scale * 3), square, square, square, square, square);
                    break;
            }
            return output;
        }
    }
}
