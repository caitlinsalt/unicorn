using Unicorn.Base;
using Unicorn.Images;
using Unicorn.Writer.Interfaces;
using Unicorn.Writer.Structural;

namespace Unicorn.ImageConvert
{
    internal class PrimitiveFactory
    {
        private readonly ImageMode _wireframeMode;

        private readonly IList<ISourceImage> _fixedSources = new List<ISourceImage>();

        private int _flipCount;

        internal PrimitiveFactory(ImageMode mode)
        {
            _wireframeMode = mode;
            _fixedSources.Add(new SingleColourSourceImage(new RgbColour(0.3569, 0.8078, 0.9804)));
            _fixedSources.Add(new SingleColourSourceImage(new RgbColour(0.9608, 0.6627, 0.7216)));
        }

        internal IFixedSizeDrawable CreatePrimitive(double width, double height, MarginSet margins)
        {
            if (_wireframeMode == ImageMode.Wireframe)
            {
                return new ImageWireframe(width, height, margins);
            }
            return new Image(width, height, margins);
        }

        internal IFixedSizeDrawable CopyPrimitiveRotated(IFixedSizeDrawable drawable, IImageDescriptor descriptor)
        {
            IFixedSizeDrawable ifd = CreatePrimitive(drawable.ContentHeight, drawable.Width,
                new MarginSet(0, 0, (drawable.Height - drawable.ContentHeight) / 2, (drawable.Height - drawable.ContentHeight) / 2));
            if (ifd is Image img)
            {
                img.ImageDescriptor = descriptor;
            }
            return ifd;
        }

        internal void LayOutOnPage(IPageDescriptor page, ISourceImage sourceReference, IFixedSizeDrawable drawable)
        {
            IImageDescriptor descriptor = null;
            if (_wireframeMode != ImageMode.Wireframe)
            {
                PdfPage thePage = page as PdfPage;
                if (_wireframeMode == ImageMode.Mock)
                {
                    descriptor = thePage.UseImage(_fixedSources[_flipCount++]);
                }
                else
                {
                    descriptor = thePage.UseImage(sourceReference);
                }
                Image theImage = drawable as Image;
                theImage.ImageDescriptor = descriptor;
                if (_flipCount >= _fixedSources.Count)
                {
                    _flipCount = 0;
                }
            }
            if (page.PageAvailableHeight > drawable.Height)
            {
                page.LayOut(drawable);
            }
            else
            {
                page.LayOut(CopyPrimitiveRotated(drawable, descriptor));
            }
        }
    }
}
