using System;
using System.IO;
using Unicorn.Base;
using Unicorn.FontTools;

namespace Unicorn.TextConvert
{
    public class TruetypeFontFinder : IFontFinder, IDisposable
    {
        private readonly string _defaultFontLocation;
        private readonly OpenTypeFontLoader _fontLoader;
        private bool _disposed;

        public TruetypeFontFinder(string defaultLocation)
        {
            _defaultFontLocation = defaultLocation;
            _fontLoader = new OpenTypeFontLoader();
        }

        public IFontDescriptor FindFont(string name, double size)
        {
            string verifiedName = null;
            if (string.IsNullOrWhiteSpace(name))
            {
                return null;
            }
            if (File.Exists(name))
            {
                verifiedName = name;
            }
            else if (!Path.IsPathRooted(name))
            {
                if (File.Exists(FontInDefaultLocation(name)))
                {
                    verifiedName = FontInDefaultLocation(name);
                }
                else if (File.Exists(FontInDefaultLocationWithExtension(name)))
                {
                    verifiedName = FontInDefaultLocationWithExtension(name);
                }
            }
            if (!string.IsNullOrWhiteSpace(verifiedName))
            {
                return _fontLoader.LoadFont(verifiedName, size);
            }
            return null;
        }

        private string FontInDefaultLocation(string name) => Path.Combine(_defaultFontLocation, name);

        private string FontInDefaultLocationWithExtension(string name) => Path.ChangeExtension(FontInDefaultLocation(name), "ttf");

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _fontLoader.Dispose();
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
