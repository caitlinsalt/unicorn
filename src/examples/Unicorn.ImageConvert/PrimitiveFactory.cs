using Unicorn.Base;
using Unicorn.Writer.Interfaces;
using Unicorn.Writer.Structural;

namespace Unicorn.ImageConvert
{
    internal class PrimitiveFactory
    {
        private readonly bool _wireframeMode;

        private readonly IList<IPdfReference> _sources;

        private int _flipCount;

        internal PrimitiveFactory(bool wireframeMode, IList<IPdfReference> sourceImages)
        {
            _wireframeMode = wireframeMode;
            _sources = sourceImages;
        }

        internal IFixedSizeDrawable CreatePrimitive(double width, double height, MarginSet margins)
        {
            if (_wireframeMode)
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

        internal void LayOutOnPage(IPageDescriptor page, IFixedSizeDrawable drawable)
        {
            IEmbeddedImageDescriptor descriptor = null;
            if (!_wireframeMode)
            {
                PdfPage thePage = page as PdfPage;
                descriptor = thePage.UseImage(_sources[_flipCount++]);
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
