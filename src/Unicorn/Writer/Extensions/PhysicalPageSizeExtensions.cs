using Unicorn.CoreTypes;
using Unicorn.Writer.Primitives;

namespace Unicorn.Writer.Extensions
{
    /// <summary>
    /// Extension methods for the <see cref="PhysicalPageSize" /> enumeration.
    /// </summary>
    public static class PhysicalPageSizeExtensions
    {
        /// <summary>
        /// Convert a <see cref="PhysicalPageSize" /> value to a <see cref="PdfRectangle" /> representing the size of the page.
        /// </summary>
        /// <param name="pageSize">The page size to be converted.</param>
        /// <returns>A <see cref="PdfRectangle" /> instance containing the dimensions of the page (in portrait orientation).  
        /// The first coordinate pair is (0,0); the second is (width, height).</returns>
        public static PdfRectangle ToPdfRectangle(this PhysicalPageSize pageSize)
        {
            return pageSize.ToUniSize().ToPdfRectangle();
        }

        /// <summary>
        /// Convert a <see cref="PhysicalPageSize" /> value to a <see cref="PdfRectangle" /> representing the size of the page.
        /// </summary>
        /// <param name="pageSize">The page size to be converted.</param>
        /// <param name="orientation">The orientation of the page.</param>
        /// <returns>A <see cref="PdfRectangle" /> instance containing the dimensions of the page (in portrait orientation).  
        /// The first coordinate pair is (0,0); the second is (width, height).</returns>
        public static PdfRectangle ToPdfRectangle(this PhysicalPageSize pageSize, PageOrientation orientation)
        {
            return pageSize.ToUniSize(orientation).ToPdfRectangle();
        }
    }
}
