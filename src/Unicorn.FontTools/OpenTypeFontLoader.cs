using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using Unicorn.CoreTypes;
using Unicorn.FontTools.OpenType;

namespace Unicorn.FontTools
{
    /// <summary>
    /// Loader for <see cref="OpenTypeFontDescriptor" /> instances.  Maintains a cache of open OpenType fonts, so that if an application requests the same font at
    /// multiple different point sizes we can avoid loading the same file's metrics multiple times.
    /// </summary>
    public class OpenTypeFontLoader : IFontLoader
    {
        private readonly Dictionary<string, OpenTypeFont> _loadedFonts = new Dictionary<string, OpenTypeFont>();

        /// <summary>
        /// Load a font and return an <see cref="OpenTypeFontDescriptor" /> for it.
        /// </summary>
        /// <param name="path">The path to the font file.</param>
        /// <param name="pointSize">The point size that the font will be rendered at.</param>
        /// <returns>An <see cref="OpenTypeFontDescriptor" /> instance for the requested font.</returns>
        /// <remarks>Note that the class maintains a cache of loaded fonts, keyed by the path.  Because of this, if an application requests the same font using
        /// paths that are equivalent but not textually equal, such as <c>.\content\font.ttf</c> and <c>.\content\fonts\subdir\..\..\font.ttf</c> the
        /// file will be loaded twice, rather than being loaded from the cache the second time.</remarks>
        public IFontDescriptor LoadFont(string path, double pointSize)
        {
            lock (_loadedFonts)
            {
                if (!_loadedFonts.ContainsKey(path))
                {
                    MemoryMappedFile mmf = null;
                    try
                    {
#pragma warning disable CA2000 // Dispose objects before losing scope - the OpenTypeFont object becomes responsible for the memory-maped file.
                        mmf = MemoryMappedFile.CreateFromFile(path, FileMode.Open, null, 0, MemoryMappedFileAccess.Read);
#pragma warning restore CA2000 // Dispose objects before losing scope
                        OpenTypeFont otf = new OpenTypeFont(mmf, path);
                        mmf = null;
                        _loadedFonts.Add(path, otf);
                    }
                    finally
                    {
#pragma warning disable CA1508 // Avoid dead conditional code - this is misdetected.  The mmf variable may not be null, if an exception is thrown in the otf constructor.
                        mmf?.Dispose();
#pragma warning restore CA1508 // Avoid dead conditional code
                    }
                }
            }
            return new OpenTypeFontDescriptor(_loadedFonts[path], pointSize);
        }

        #region IDisposable Support
        private bool disposedValue; // To detect redundant calls

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="OpenTypeFontLoader" /> and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to only release unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    lock (_loadedFonts)
                    {
                        foreach (OpenTypeFont otf in _loadedFonts.Values)
                        {
                            otf.Dispose();
                        }
                        _loadedFonts.Clear();
                    }
                }

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        /// <summary>
        /// Releases all resources used by the <see cref="OpenTypeFont" />.
        /// </summary>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
