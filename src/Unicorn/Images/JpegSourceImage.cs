using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Unicorn.Exceptions;

namespace Unicorn.Images
{
    /// <summary>
    /// Loads and parses JPEG images (including JFIF and EXIF) sufficiently to embed them into a PDF.
    /// </summary>
    public class JpegSourceImage : BaseSourceImage
    {
        private long _startOfFramePosition = -1;

        /// <summary>
        /// Load a JPEG image from a stream.
        /// </summary>
        /// <param name="stream">The source data stream.</param>
        /// <returns>A <see cref="Task" /> which will be completed when the image is loaded.</returns>
        /// <exception cref="ArgumentNullException">The <c>stream</c> parameter is null.</exception>
        /// <exception cref="ObjectDisposedException">The <c>stream</c> parameter is disposed, or the <see cref="JpegSourceImage" /> object is disposed.</exception>
        /// <exception cref="NotSupportedException">The <c>stream</c> parameter does not support reading.</exception>
        /// <exception cref="InvalidImageException">
        /// The <c>stream</c> data does not begin with the JPEG "Start Of Image" marker, or the stream data does not contain a JPEG frame header, or the JPEG frame header
        /// appears to be too short to contain an image size.
        /// </exception>
        /// <remarks>
        /// <para>
        /// This class does minimal syntax checking of the JPEG data, beyond confirming that it starts with the correct magic number, and that at some point in the data,
        /// it appears to contain a JPEG frame header which starts more than a few bytes from the end of the file, so that the image size can be read from the location it
        /// will be in if the frame header is valid.  It does not do any other checking of the data.
        /// </para>
        /// <para>
        /// Depending on the type of <see cref="Stream" /> passed to this method, this method may throw additional exception types not listed here.
        /// </para>
        /// <para>
        /// This method loads the entire data stream into memory.  It is the caller's responsibility to confirm that the data stream is not excessively large.
        /// </para>
        /// </remarks>
        public override async Task LoadFromAsync(Stream stream)
        {
            await base.LoadFromAsync(stream).ConfigureAwait(false);
            CheckStartOfImageMarker();
            _startOfFramePosition = FindStartOfFrame();
            PopulateSizes();
        }

        private long FindStartOfFrame()
        {
            AdvanceToMarker(ImageLoadResources.JpegSourceImage_SofNotFound);
            while (true)
            {
                int currentByte = _dataStream.ReadByte();
                CheckEndOfStream(currentByte, ImageLoadResources.JpegSourceImage_SofNotFound);
                if (IsStartOfFrameMarker(currentByte))
                {
                    long rval = _dataStream.Position - 2;
                    _dataStream.Seek(0, SeekOrigin.Begin);
                    return rval;
                }
                HopFromMarkerToMarker(ImageLoadResources.JpegSourceImage_SofNotFound);
            }
        }

        private void PopulateSizes()
        {
            const int yPixOffset = 5;
            _dataStream.Seek(_startOfFramePosition + yPixOffset, SeekOrigin.Begin);
            DotHeight = LoadUShortFromCurrentPosition(ImageLoadResources.JpegSourceImage_DimensionsNotFound);
            DotWidth = LoadUShortFromCurrentPosition(ImageLoadResources.JpegSourceImage_DimensionsNotFound);
            _dataStream.Seek(0, SeekOrigin.Begin);
        }

        private static void CheckEndOfStream(int b, string errorMessage)
        {
            if (b == -1)
            {
                throw new InvalidImageException(errorMessage);
            }   
        }

        /// <summary>
        /// This method moves to the next 0xFF byte in the stream.
        /// </summary>
        /// <param name="errorIfNotFound"></param>
        private void AdvanceToMarker(string errorIfNotFound)
        {
            int currentByte;
            do
            {
                currentByte = _dataStream.ReadByte();
            } while (currentByte != -1 && currentByte != 255);
            CheckEndOfStream(currentByte, errorIfNotFound);
        }

        /// <summary>
        /// This method assumes we have just read a marker, and therefore the stream is pointing at a block length word.  The method
        /// reads that block length word and skips that distance forward, then checks that the byte we are pointing at is also a marker.
        /// </summary>
        /// <param name="errorMessage">The exception message to throw if the file structure is wrong.</param>
        private void HopFromMarkerToMarker(string errorMessage)
        {
            int blockLength = LoadUShortFromCurrentPosition(errorMessage);
            _dataStream.Seek(blockLength - 2, SeekOrigin.Current);
            int currentByte = _dataStream.ReadByte();
            if (currentByte != 255)
            {
                throw new InvalidImageException(errorMessage);
            }
        }

        /// <summary>
        /// Confirm that the first bytes in the stream are the JPEG SOI marker, FFD8.
        /// </summary>
        private void CheckStartOfImageMarker()
        {
            if (_dataStream.ReadByte() != 0xff || _dataStream.ReadByte() != 0xd8)
            {
                throw new InvalidImageException(ImageLoadResources.JpegSourceImage_SoiNotFound);
            }
        }

        private static bool IsStartOfFrameMarker(int markerSecondByte)
        {
            // These values are from the JPEG specification: note they are not a contiguous sequence.
            int[] validMarkers = { 0xc0, 0xc1, 0xc2, 0xc3, 0xc5, 0xc6, 0xc7, 0xc8, 0xc9, 0xca, 0xcb, 0xcd, 0xce, 0xcf };
            return validMarkers.Contains(markerSecondByte);
        }

        private int CheckedByteRead(string errorMessage)
        {
            int b = _dataStream.ReadByte();
            if (b == -1)
            {
                throw new InvalidImageException(errorMessage);
            }
            return b;
        }

        private int LoadUShortFromCurrentPosition(string errorMessage)
            => (CheckedByteRead(errorMessage) << 8) | (CheckedByteRead(errorMessage));
    }
}
