using Unicorn.Base;
using Unicorn.Writer.Interfaces;
using Unicorn.Writer.Structural;

namespace Unicorn.ImageConvert
{
    internal class PrimitiveFactory
    {
        private readonly ImageMode _wireframeMode;

        private readonly IList<IPdfReference> _sources;

        private int _flipCount;

        internal PrimitiveFactory(ImageMode mode, IList<IPdfReference> sourceImages)
        {
            _wireframeMode = mode;
            _sources = sourceImages;
        }

        internal IFixedSizeDrawable CreatePrimitive(double width, double height, MarginSet margins)
        {
            if (_wireframeMode == ImageMode.Wireframe)
            {
                return new ImageWireframe(width, height, margins);
            }
            return new Image(width, height, margins);
        }

        internal IFixedSizeDrawable CopyPrimitiveRotated(IFixedSizeDrawable drawable, IEmbeddedImageDescriptor descriptor)
        {
            IFixedSizeDrawable ifd = CreatePrimitive(drawable.ContentHeight, drawable.Width,
                new MarginSet(0, 0, (drawable.Height - drawable.ContentHeight) / 2, (drawable.Height - drawable.ContentHeight) / 2));
            if (ifd is Image img)
            {
                img.ImageDescriptor = descriptor;
            }
            return ifd;
        }

        internal void LayOutOnPage(IPageDescriptor page, IPdfReference sourceReference, IFixedSizeDrawable drawable)
        {
            IEmbeddedImageDescriptor descriptor = null;
            if (_wireframeMode != ImageMode.Wireframe)
            {
                PdfPage thePage = page as PdfPage;
                if (_wireframeMode == ImageMode.Mock)
                {
                    descriptor = thePage.UseImage(_sources[_flipCount++]);
                }
                else
                {
                    descriptor = thePage.UseImage(sourceReference);
                }
                Image theImage = drawable as Image;
                theImage.ImageDescriptor = descriptor;
                if (_flipCount >= _sources.Count)
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
