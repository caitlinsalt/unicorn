using Unicorn.CoreTypes;
using Unicorn.Writer.Primitives;
using Unicorn.Writer.Structural;

namespace Unicorn.Writer.Interfaces
{
    /// <summary>
    /// Interface defining the <see cref="PdfPage" /> functionality not inherited from other classes, to make testing of <see cref="PdfPage" />'s consumers more
    /// straightforward.
    /// </summary>
    public interface IPdfPage
    {
        /// <summary>
        /// The stream which contains the page's content.
        /// </summary>
        PdfStream ContentStream { get; }

        /// <summary>
        /// Register that a font is likely to be used on this page (and should be embedded in the document if appropriate for the font type).
        /// </summary>
        /// <param name="font">Descriptor of the font to be used.</param>
        /// <returns>A <see cref="PdfFont" /> instance representing the font resource information for the given descriptor.</returns>
        PdfFont UseFont(IFontDescriptor font);
    }
}
