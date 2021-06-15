using System;
using Unicorn.Base;

namespace Unicorn.TextConvert
{
    public class CollectiveFontFinder : IFontFinder, IDisposable
    {
        private readonly TruetypeFontFinder _ttfFinder;
        private readonly StandardFontFinder _standardFinder;
        private bool _disposed;

        public CollectiveFontFinder(string defaultFontFolder)
        {
            _ttfFinder = new TruetypeFontFinder(defaultFontFolder);
            _standardFinder = new StandardFontFinder();
        }

        public IFontDescriptor FindFont(string name, double size) => _ttfFinder.FindFont(name, size) ?? _standardFinder.FindFont(name, size);

        #region IDisposable implementation

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _ttfFinder.Dispose();
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}
