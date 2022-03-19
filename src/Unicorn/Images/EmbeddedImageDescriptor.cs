using Unicorn.Base;
using Unicorn.Writer.Primitives;

namespace Unicorn.Images
{
    /// <summary>
    /// A decriptor for an image that has been embedded into a specific page of a document.
    /// </summary>
    public class EmbeddedImageDescriptor : IEmbeddedImageDescriptor
    {
        /// <summary>
        /// The page on which the image has been embedded.
        /// </summary>
        public IPageDescriptor ParentPage { get; }

        /// <summary>
        /// The name of the image when used on this page.  Equal to the <see cref="Name"/> property's <see cref="PdfName.Value"/> property.
        /// </summary>
        public string ImageKey { get; }

        /// <summary>
        /// The name of the image when used on this page.
        /// </summary>
        public PdfName Name { get; }

        /// <summary>
        /// Property-setting constructor.
        /// </summary>
        /// <param name="parent">The page on which this image can be used.</param>
        /// <param name="name">The name used to refer to the image on that page.</param>
        public EmbeddedImageDescriptor(IPageDescriptor parent, PdfName name)
        {
            ParentPage = parent;
            Name = name;
            ImageKey = Name.Value;
        }
    }
}
