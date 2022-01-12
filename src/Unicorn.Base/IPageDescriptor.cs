using System;

namespace Unicorn.Base
{
    /// <summary>
    /// Describes a page within a document.
    /// </summary>
    public interface IPageDescriptor
    {
        /// <summary>
        /// The graphics context for carrying out low level drawing operations to this page.
        /// </summary>
        IGraphicsContext PageGraphics { get; }

        /// <summary>
        /// The size of this page.
        /// </summary>
        PhysicalPageSize PageSize { get; }

        /// <summary>
        /// The orientation of this page.
        /// </summary>
        PageOrientation PageOrientation { get; }

        /// <summary>
        /// The proportion of the total page width taken up by the left margin.
        /// </summary>
        double HorizontalMarginProportion { get; }

        /// <summary>
        /// The proportion of the total page height taken up by the top margin.
        /// </summary>
        double VerticalMarginProportion { get; }

        /// <summary>
        /// The vertical coordinate of the top margin edge.
        /// </summary>
        double TopMarginPosition { get; }

        /// <summary>
        /// The vertical coordinate of the bottom margin edge.
        /// </summary>
        double BottomMarginPosition { get; }

        /// <summary>
        /// The horizontal coordinate of the left margin edge.
        /// </summary>
        double LeftMarginPosition { get; }

        /// <summary>
        /// The horizontal coordinate of the right margin edge.
        /// </summary>
        double RightMarginPosition { get; }

        /// <summary>
        /// The available width between left and right margin edges.
        /// </summary>
        double PageAvailableWidth { get; }

        /// <summary>
        /// A counter to keep track of the current vertical position on a page that is being composed.
        /// </summary>
        double CurrentVerticalCursor { get; set; }

        /// <summary>
        /// The available vertical space left between the vertical cursor and the bottom margin.
        /// Negative if the vertical cursor is in the bottom margin or off the bottom of the page.
        /// </summary>
        double PageAvailableHeight { get; }

        /// <summary>
        /// Lay out a non-splittable drawable on the page, against the left margin, updating the vertical cursor.
        /// </summary>
        /// <param name="drawable"></param>
        void LayOut(IDrawable drawable);

        /// <summary>
        /// Lay out a splittable drawable on the page, against the left margin.  If the drawable is too tall to fit on
        /// the page, a new page of the same dimensions is created, and an attempt is made to split the drawable across 
        /// both pages.  If this attempt fails, the drawable is laid out on the new page.
        /// </summary>
        /// <typeparam name="T">The type of splittable being handled.</typeparam>
        /// <param name="splittable">The item to be drawn on the page.</param>
        /// <param name="document">The document to which the page belongs, to be used in creating a new page.</param>
        /// <returns>The page descriptor of a new page, if one was created, or <c>null</c> if the item fitted on this page.</returns>
        IPageDescriptor LayOut<T>(ISplittable<T> splittable, IDocumentDescriptor document) where T : ISplittable<T>;

        /// <summary>
        /// Lay out a splittable drawable on the page, against the left margin.  If the drawable is too tall to fit on 
        /// the page, a new page is created using a page generator function, and an attempt is made to split the drawable
        /// across both pages.  If this attempt fails, the drawable is laid out on the new page.
        /// </summary>
        /// <typeparam name="T">The type of splittable being handled.</typeparam>
        /// <param name="splittable">The item to be drawn on the page.</param>
        /// <param name="pageGenerator">A function to be called to create a new page if one is required.</param>
        /// <returns>The page descriptor of a new page, if one was created, or <c>null</c> if the item fitted on this page.</returns>
        IPageDescriptor LayOut<T>(ISplittable<T> splittable, Func<IPageDescriptor> pageGenerator) where T : ISplittable<T>;
    }
}
