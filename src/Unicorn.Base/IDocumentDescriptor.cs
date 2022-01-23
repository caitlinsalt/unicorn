using System.IO;
using System.Threading.Tasks;

namespace Unicorn.Base
{
    /// <summary>
    /// A descriptor for an entire document.
    /// </summary>
    public interface IDocumentDescriptor
    {
        /// <summary>
        /// The default size of newly-added pages.
        /// </summary>
        PhysicalPageSize DefaultPhysicalPageSize { get; set; }

        /// <summary>
        /// The default orientation of newly-added pages.
        /// </summary>
        PageOrientation DefaultPageOrientation { get; set; }

        /// <summary>
        /// The default horizontal margin width of newly-added pages, as a proportion of the page width.
        /// </summary>
        double DefaultHorizontalMarginProportion { get; set; }

        /// <summary>
        /// The default vertical margin height of newly-added pages, as a proportion of the page height.
        /// </summary>
        double DefaultVerticalMarginProportion { get; set; }

        /// <summary>
        /// The current page of the document.  May be null if no pages have been added to the document.
        /// </summary>
        IPageDescriptor CurrentPage { get; }

        /// <summary>
        /// Create a new page with the default physical size and orientation and append it to the document.
        /// </summary>
        /// <returns>A page descriptor for the new page.</returns>
        IPageDescriptor AppendDefaultPage();

        /// <summary>
        /// Create a new page with the same dimensions as the current page (if there is one), or with the default
        /// physical size and orientation if there is no current page, and append it to the document.
        /// </summary>
        /// <returns>A page descriptor for the new page</returns>
        IPageDescriptor AppendPage();

        /// <summary>
        /// Create a new page with the default physical size and specified orientation and append it to the document.
        /// </summary>
        /// <param name="orientation">The orientation of the new page.</param>
        /// <returns>A page descriptor for the new page.</returns>
        IPageDescriptor AppendPage(PageOrientation orientation);

        /// <summary>
        /// Create a new page with specified physical size and orientation and append it to the document.
        /// </summary>
        /// <param name="size">The size of the new page.</param>
        /// <param name="orientation">The orientation of the new page.</param>
        /// <param name="horizontalMarginProportion">The horizontal margin width of the new page, as a proportion of the page width.</param>
        /// <param name="verticalMarginProportion">The vertical margin height of the new page, as a proportion of the page height.</param>
        /// <returns>A page descriptor for the new page.</returns>
        IPageDescriptor AppendPage(PhysicalPageSize size, PageOrientation orientation, double horizontalMarginProportion, double verticalMarginProportion);

        /// <summary>
        /// Write a copy of the document content to the given stream.
        /// </summary>
        /// <param name="destination">The <see cref="Stream" /> to write the document content to.</param>
        void Write(Stream destination);

        /// <summary>
        /// Write a copy of the document content to the given stream, asynchronously.
        /// </summary>
        /// <param name="destination">The <see cref="Stream" /> to write the document content to.</param>
        Task WriteAsync(Stream destination);
    }
}
