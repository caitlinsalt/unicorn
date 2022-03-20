using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Unicorn.Base;

namespace Unicorn.Images
{
    /// <summary>
    /// Base class for classes which load and partially parse raster image files.
    /// </summary>
    public abstract class BaseSourceImage : ISourceImage, IDisposable
    {
        private protected readonly MemoryStream _dataStream = new MemoryStream();
        private bool disposedValue;

        /// <summary>
        /// The image width in pixels.
        /// </summary>
        public virtual int DotWidth { get; protected set; }

        /// <summary>
        /// The image height in pixels.
        /// </summary>
        public virtual int DotHeight { get; protected set; }

        /// <summary>
        /// The image aspect ratio, as a width-over-height fraction.
        /// </summary>
        public virtual double AspectRatio => (double)DotWidth / DotHeight;

        public IEnumerable<byte> RawData => _dataStream.ToArray();

        /// <summary>
        /// Load the image from a stream.
        /// </summary>
        /// <param name="stream">The source of the image data.</param>
        /// <returns>A <see cref="Task" /> which will be completed when the image is loaded.</returns>
        /// <exception cref="ArgumentNullException">The <c>stream</c> parameter is null.</exception>
        /// <exception cref="ObjectDisposedException">The <c>stream</c> parameter is disposed, or the <see cref="BaseSourceImage" /> object is disposed.</exception>
        /// <exception cref="NotSupportedException">The <c>stream</c> parameter does not support reading.</exception>
        /// <remarks>
        /// <para>
        /// Depending on the type of <see cref="Stream" /> passed to this method, this method may throw additional exception types not listed here.
        /// </para>
        /// <para>
        /// This method loads the entire data stream into memory.  It is the caller's responsibility to confirm that the data stream is not excessively large.
        /// </para>
        /// </remarks>
        public virtual async Task LoadFromAsync(Stream stream)
        {
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            await stream.CopyToAsync(_dataStream).ConfigureAwait(false);
            _dataStream.Seek(0, SeekOrigin.Begin);
        }

        #region Dispose pattern implementation

        /// <summary>
        /// Releases all resources used by the <see cref="BaseSourceImage" /> object.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release all resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _dataStream.Dispose();
                }

                disposedValue = true;
            }
        }

        /// <summary>
        /// Releases all resources used by the <see cref="BaseSourceImage" /> object.
        /// </summary>
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}
