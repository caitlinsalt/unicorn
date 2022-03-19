using Unicorn.Base;
using Unicorn.Writer.Primitives;
using Unicorn.Writer.Streams;
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

        /// <summary>
        /// Register that an image is likely to be used on this page.  The image must already have been embedded in the document
        /// by calling <see cref="PdfDocument.UseImage(ISourceImage)"/>.
        /// </summary>
        /// <remarks>
        /// Although the same image can be used on multiple pages within a document, and multiple times on each page, it needs to be referenced 
        /// separately on each page that uses it.  The name returned by this method should only be used to refer to the image when drawing it 
        /// on this specific page, but can be used any number of times within this page.  Using the name returned by this document on other pages
        /// may result in 
        /// </remarks>
        /// <param name="imageReference">Reference to an image stream that has been embedded in the document.</param>
        /// <returns>A <see cref="PdfName"/> which can be used to refer to the image in drawing operations on this page.</returns>
        IEmbeddedImageDescriptor UseImage(IPdfReference imageReference);
    }
}
