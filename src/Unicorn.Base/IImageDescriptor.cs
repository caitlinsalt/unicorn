namespace Unicorn.Base
{
    /// <summary>
    /// A decriptor for an image that has been embedded into a document.
    /// </summary>
    public interface IImageDescriptor
    {
        /// <summary>
        /// A "fingerprint string" that can be used to uniuely identify the image.
        /// </summary>
        string ImageFingerprint { get; }

        /// <summary>
        /// The document the image has been embedded into.
        /// </summary>
        IDocumentDescriptor Document { get; }

        /// <summary>
        /// The ID of the image's data stream within the document.
        /// </summary>
        IPdfInternalReference DataStream { get; }

        /// <summary>
        /// How the image should be rotated on drawing.
        /// </summary>
        RightAngleRotation Rotation { get; }

        /// <summary>
        /// Record that this image may be used on a specific page.
        /// </summary>
        /// <param name="pageDescriptor">The page this image is used on.</param>
        /// <param name="preferredName">The name that the caller would like to refer to this image by on the page.</param>
        /// <returns>The name that this image can be referred to by on the given page.  Note that this may be different to the <c>preferredName</c> parameter.</returns>
        /// <remarks>
        /// <para>
        /// To display an image inside a PDF document, the image must be embedded in the document, and also must be named as a resource on each page that uses it.
        /// Within the page's stream of drawing instructions the image is referred to by its resource name.  One image may have different names on different pages,
        /// and an image name can refer to different images on different pages.
        /// </para>
        /// <para>
        /// This method records in the descriptor that a page would like to use an image as one of its resources, by a given name.  However, if the page is already
        /// using the image, the method should return the name that the page is already using instead.  Callers should therefore always use the return value of this
        /// method as the image name.
        /// </para>
        /// </remarks>
        string UseOnPage(IPageDescriptor pageDescriptor, string preferredName);

        /// <summary>
        /// Get the name that this image is referred to by on a given page.
        /// </summary>
        /// <param name="pageDescriptor">The page the image might be referred to on.</param>
        /// <returns>The name the image is referred to by on the page, or <c>null</c> if the page does not reference the image.</returns>
        string GetNameOnPage(IPageDescriptor pageDescriptor);
    }
}
