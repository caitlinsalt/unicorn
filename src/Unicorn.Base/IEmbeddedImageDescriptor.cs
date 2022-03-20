namespace Unicorn.Base
{
    /// <summary>
    /// A decriptor for an image that has been embedded into a specific page of a document.
    /// </summary>
    /// <remarks>
    /// PDF documents can contain embedded rasterised images which can be used on pages, but 
    /// the image must be referenced individually as a resource on each page that uses it.
    /// An implementation of this descriptor interface must contain all of the information
    /// required to use an image on a given page, once it has been added to that page's resources.
    /// </remarks>
    public interface IEmbeddedImageDescriptor
    {
        /// <summary>
        /// The page on which an image has been embedded.
        /// </summary>
        IPageDescriptor ParentPage { get; }

        /// <summary>
        /// A string key which can be used to refer to the specific image on a given page.
        /// </summary>
        /// <remarks>
        /// Note that an image key must be unique on a specific page, but not unique within a document.
        /// An image may have different keys on different pages, and if the same key is a valid key on
        /// different pages, it may refer to different images.
        /// </remarks>
        string ImageKey { get; }
    }
}
