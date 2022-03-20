using System;
using System.Collections.Generic;
using System.Linq;
using Unicorn.Base;
using Unicorn.Exceptions;
using Unicorn.Images;
using Unicorn.Writer.Extensions;
using Unicorn.Writer.Interfaces;
using Unicorn.Writer.Primitives;
using Unicorn.Writer.Streams;

namespace Unicorn.Writer.Structural
{
    /// <summary>
    /// Class representing a page in a PDF document.
    /// </summary>
    public class PdfPage : PdfPageTreeItem, IPageDescriptor, IPdfPage
    {
        /// <summary>
        /// The <see cref="PdfDocument" /> that contains this page.
        /// </summary>
        public PdfDocument HomeDocument { get; private set; }

        /// <summary>
        /// Whether or not the page is open for composition.
        /// </summary>
        public PageState PageState { get; private set; }

        /// <summary>
        /// The size of this page.
        /// </summary>
        public PhysicalPageSize PageSize { get; private set; }

        /// <summary>
        /// The orientation of this page.
        /// </summary>
        public PageOrientation PageOrientation { get; private set; }

        /// <summary>
        /// The graphics context, for drawing.
        /// </summary>
        public IGraphicsContext PageGraphics { get; private set; }

        /// <summary>
        /// The proportion of the total width of the page taken up by the left margin.
        /// </summary>
        public double HorizontalMarginProportion { get; private set; }

        /// <summary>
        /// The proportion of the total height of the page taken up by the top margin.
        /// </summary>
        public double VerticalMarginProportion { get; private set; }

        /// <summary>
        /// The Y-coordinate of the top margin, in Unicorn coordinates.
        /// </summary>
        public double TopMarginPosition { get; private set; }

        /// <summary>
        /// The Y-coordinate of the bottom margin, in Unicorn coordinates.
        /// </summary>
        public double BottomMarginPosition { get; private set; }

        /// <summary>
        /// The X-coordinate of the left margin, in Unicorn coordinates.
        /// </summary>
        public double LeftMarginPosition { get; private set; }

        /// <summary>
        /// The X-coordinate of the right margin, in Unicorn coordinates.
        /// </summary>
        public double RightMarginPosition { get; private set; }

        /// <summary>
        /// The width of the usable area of the page - in other words, the distance in points between the left margin and right margin.
        /// </summary>
        public double PageAvailableWidth { get; private set; }

        /// <summary>
        /// A saved Y-coordinate.  This is used purely by client code when laying out a page.
        /// </summary>
        public double CurrentVerticalCursor { get; set; }

        /// <summary>
        /// The amount of height left to use on the page, being the difference between the bottom margin position and the vertical cursor.  
        /// Negative if the vertical cursor position has overspilled into the bottom margin.
        /// </summary>
        public double PageAvailableHeight => BottomMarginPosition - CurrentVerticalCursor;

        private double PageHeight { get; set; }

        /// <summary>
        /// The MediaBox rectangle, representing the usable area of the page (including margins) in PDF userspace coordinates.
        /// </summary>
        public PdfRectangle MediaBox { get; private set; }

        /// <summary>
        /// The <see cref="PdfStream" /> containing the content of this page.
        /// </summary>
        public PdfStream ContentStream { get; private set; }

        private readonly PdfDictionary _fontDictionary = new PdfDictionary();

        private readonly Dictionary<IPdfReference, PdfName> _reverseImageCache = new Dictionary<IPdfReference, PdfName>();

        /// <summary>
        /// Value-setting constructor.
        /// </summary>
        /// <param name="parent">The parent node of this page in the document page tree.</param>
        /// <param name="objectId">The indirect object ID of this page.</param>
        /// <param name="homeDocument">The <see cref="PdfDocument" /> that this page belongs to.</param>
        /// <param name="size">The paper size of this page.</param>
        /// <param name="orientation">The orientation of this page.</param>
        /// <param name="horizontalMarginProportion">The proportion of the page taken up by each of the left and right margins.</param>
        /// <param name="verticalMarginProportion">The proportion of the page taken up by each of the top and bottom margins.</param>
        /// <param name="contentStream">The <see cref="PdfStream" /> which will store the content of this page.</param>
        /// <param name="generation">The object generation number.  Defaults to zero.  As we do not currently support rewriting existing documents, 
        /// this should not be set.</param>
        public PdfPage(
            PdfPageTreeNode parent, 
            int objectId,
            PdfDocument homeDocument,
            PhysicalPageSize size, 
            PageOrientation orientation, 
            double horizontalMarginProportion, 
            double verticalMarginProportion, 
            PdfStream contentStream,
            int generation = 0) 
            : base(parent, objectId, generation)
        {
            if (parent is null)
            {
                throw new ArgumentNullException(nameof(parent));
            }
            if (homeDocument is null)
            {
                throw new ArgumentNullException(nameof(homeDocument));
            }

            HomeDocument = homeDocument;
            PageState = PageState.Open;
            PageSize = size;
            PageOrientation = orientation;
            HorizontalMarginProportion = horizontalMarginProportion;
            VerticalMarginProportion = verticalMarginProportion;

            UniSize pagePtSize = size.ToUniSize(orientation);
            PageHeight = pagePtSize.Height;
            TopMarginPosition = pagePtSize.Height * VerticalMarginProportion;
            BottomMarginPosition = pagePtSize.Height - TopMarginPosition;
            LeftMarginPosition = pagePtSize.Width * HorizontalMarginProportion;
            RightMarginPosition = pagePtSize.Width - LeftMarginPosition;
            PageAvailableWidth = RightMarginPosition - LeftMarginPosition;
            CurrentVerticalCursor = TopMarginPosition;
            MediaBox = size.ToPdfRectangle(orientation);
            ContentStream = contentStream;
            PageGraphics = new PageGraphics(this, XTransformer, YTransformer);
        }

        private double XTransformer(double x) => x;

        private double YTransformer(double y) => PageHeight - y;

        /// <summary>
        /// Register that a font is likely to be used on this page.  If the font format supports embedding, this will register the font for embedding also.
        /// </summary>
        /// <param name="font">The font that is likely to be used on this page.</param>
        /// <returns>A <see cref="PdfFont" /> object representing the font information dictionary that will be written to the output file.  This may be the 
        /// same object returned by other calls to the <see cref="UseFont(IFontDescriptor)" /> method with the same parameter, or parameters with the same
        /// <see cref="IFontDescriptor.UnderlyingKey" /> property, including calls on other <see cref="PdfPage" /> instances.</returns>
        public PdfFont UseFont(IFontDescriptor font)
        {
            PdfFont fontObject = HomeDocument.UseFont(font);
            lock (_fontDictionary)
            {
                if (!_fontDictionary.ContainsKey(fontObject.InternalName))
                {
                    _fontDictionary.Add(fontObject.InternalName, fontObject.GetReference());
                }
            }
            return fontObject;
        }

        /// <summary>
        /// Add an image to a page's resources, so that it can be drawn on the page.
        /// </summary>
        /// <param name="imageReference">Reference to an image data stream, acquired by calling <see cref="PdfDocument.UseImage(ISourceImage)"/>.</param>
        /// <returns>An <see cref="IEmbeddedImageDescriptor"/> which can be used to draw the image on the page.</returns>
        public IEmbeddedImageDescriptor UseImage(IPdfReference imageReference)
        {
            lock (_reverseImageCache)
            {
                if (_reverseImageCache.ContainsKey(imageReference))
                {
                    return new EmbeddedImageDescriptor(this, _reverseImageCache[imageReference]);
                }
                var name = new PdfName($"UniImg{_reverseImageCache.Count}");
                _reverseImageCache.Add(imageReference, name);
                return new EmbeddedImageDescriptor(this, name);
            }
        }

        /// <summary>
        /// Carry out any operations needed to cleanly complete the content stream of this page, such as balancing unbalanced PDF operators.
        /// </summary>
        public void ClosePage()
        {
            PageState = PageState.Closed;
            PageGraphics.CloseGraphics();
        }

        /// <summary>
        /// Lay out a non-splittable drawable on the page, against the left margin, updating the vertical cursor.
        /// </summary>
        /// <param name="drawable"></param>
        /// <exception cref="ArgumentNullException">The <c>drawable</c> parameter is <c>null</c>.</exception>
        public void LayOut(IDrawable drawable)
        {
            if (drawable is null)
            {
                throw new ArgumentNullException(nameof(drawable));
            }
            drawable.DrawAt(PageGraphics, LeftMarginPosition, CurrentVerticalCursor);
            CurrentVerticalCursor += drawable.Height;
        }

        /// <summary>
        /// Lay out a splittable drawable on the page, against the left margin.  If the drawable is too tall to fit on
        /// the page, a new page of the same dimensions is created, and an attempt is made to split the drawable across 
        /// both pages.  If this attempt fails, the drawable is laid out on the new page.
        /// </summary>
        /// <typeparam name="T">The type of splittable being handled.</typeparam>
        /// <param name="splittable">The item to be drawn on the page.</param>
        /// <param name="pageGenerator">A function which, when called, will return an <see cref="IPageDescriptor" /> representing a new page in the current document.</param>
        /// <returns>The page descriptor of a new page, if one was created, or this object if the item fitted on this page.</returns>
        /// <exception cref="ArgumentNullException">The <c>splittable</c> parameter is <c>null</c>, or the <c>pageGenerator</c> parameter is <c>null</c>.</exception>
        /// <exception cref="DrawableSplitException">
        /// The <c>splittable</c> parameter would not fit on the current page or on the page returned by the <c>pageGenerator</c> parameter, and when split, 
        /// its height was not reduced.
        /// </exception>
        public IPageDescriptor LayOut<T>(ISplittable<T> splittable, Func<IPageDescriptor> pageGenerator) where T : ISplittable<T>
        {
            if (splittable is null)
            {
                throw new ArgumentNullException(nameof(splittable));
            }
            if (pageGenerator is null)
            {
                throw new ArgumentNullException(nameof(pageGenerator));
            }

            if (!splittable.OverspillHeight)
            {
                LayOut(splittable);
                return this;
            }

            IPageDescriptor newPage = pageGenerator();
            double originalSplittableHeight = splittable.ContentHeight;
            ISplittable<T> splitPortion = splittable.Split(newPage.PageAvailableHeight, WidowsAndOrphans.Prevent);
            if (!splittable.OverspillHeight)
            {
                LayOut(splittable);
            }
            else if (splittable.ContentHeight < originalSplittableHeight || splittable.ContentHeight < newPage.PageAvailableHeight)
            {
                newPage.LayOut(splittable);
            }
            else
            {
                throw new DrawableSplitException(WriterResources.Structural_PdfPage_Drawable_Split_Failed_Error);
            }
            if (splitPortion != null)
            {
                newPage.LayOut(splitPortion, pageGenerator);
            }

            return newPage;
        }

        /// <summary>
        /// Lay out a splittable drawable on the page, against the left margin.  If the drawable is too tall to fit on
        /// the page, a new page of the same dimensions is created, and an attempt is made to split the drawable across 
        /// both pages.  If this attempt fails, the drawable is laid out on the new page.
        /// </summary>
        /// <typeparam name="T">The type of splittable being handled.</typeparam>
        /// <param name="splittable">The item to be drawn on the page.</param>
        /// <param name="document">The document to which the page belongs, to be used in creating a new page.</param>
        /// <returns>The page descriptor of a new page, if one was created, or this object if the item fitted on this page.</returns>
        /// <exception cref="ArgumentNullException">The <c>splittable</c> parameter is <c>null</c>.</exception>
        /// <exception cref="NullReferenceException">The <c>document</c> parameter is <c>null</c> and a new page was required.</exception>
        /// <exception cref="DrawableSplitException">
        /// The <c>splittable</c> parameter would not fit on the current page or on the page returned by the <c>pageGenerator</c> parameter, and when split, 
        /// its height was not reduced.
        /// </exception>
        public IPageDescriptor LayOut<T>(ISplittable<T> splittable, IDocumentDescriptor document) where T : ISplittable<T> => LayOut(splittable, () => document.AppendPage());

        /// <summary>
        /// Construct the dictionary which will be written to the output to represent this object.
        /// </summary>
        /// <returns>A <see cref="PdfDictionary" /> containing the properties of this object in the correct format.</returns>
        protected override PdfDictionary MakeDictionary()
        {
            PdfDictionary dictionary = new PdfDictionary();
            PdfDictionary resourceDictionary = new PdfDictionary();
            if (_fontDictionary.Count > 0)
            {
                resourceDictionary.Add(CommonPdfNames.Font, _fontDictionary);
            }
            if (_reverseImageCache.Count > 0)
            {
                PdfDictionary xobjDictionary = new PdfDictionary();
                xobjDictionary.AddRange(_reverseImageCache.Select(kp => new KeyValuePair<PdfName, IPdfPrimitiveObject>(kp.Value, kp.Key)));
                resourceDictionary.Add(CommonPdfNames.XObject, xobjDictionary);
            }
            dictionary.Add(CommonPdfNames.Type, CommonPdfNames.Page);
            dictionary.Add(CommonPdfNames.Parent, Parent.GetReference());
            dictionary.Add(CommonPdfNames.Resources, resourceDictionary);
            dictionary.Add(CommonPdfNames.MediaBox, MediaBox);
            if (ContentStream != null)
            {
                dictionary.Add(CommonPdfNames.Contents, ContentStream.GetReference());
            }
            return dictionary;
        }
    }
}
