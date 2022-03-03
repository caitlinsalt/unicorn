using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Unicorn.Exceptions;
using Unicorn.Helpers;
using Unicorn.Images.Jpeg;

namespace Unicorn.Images
{
    /// <summary>
    /// Loads and parses JPEG images (including JFIF and EXIF) sufficiently to embed them into a PDF.
    /// </summary>
    public class JpegSourceImage : BaseSourceImage
    {
        private readonly List<ImageDataBlock> _metadataBlocks = new List<ImageDataBlock>();

        private ImageDataBlock StartOfFrameBlock => _metadataBlocks.FirstOrDefault(b => b.BlockType == ImageDataBlockType.StartOfFrame)
            ?? throw new InvalidImageException(ImageLoadResources.JpegSourceImage_SofNotFound);

        private ImageDataBlock JfifBlock => _metadataBlocks.FirstOrDefault(b => b.BlockType == ImageDataBlockType.Jfif);

        private ExifSegment ExifSegment => _metadataBlocks.FirstOrDefault(b => b is ExifSegment) as ExifSegment;

        /// <summary>
        /// Horizontal resolution of the image in pixels per point.
        /// </summary>
        public double HorizontalDotsPerPoint { get; set; } = 1;

        /// <summary>
        /// Vertical resolution of the image in pixels per point.
        /// </summary>
        public double VerticalDotsPerPoint { get; set; } = 1;

        /// <summary>
        /// The image aspect ratio, as a width-over-height fraction.
        /// </summary>
        public override double AspectRatio => (DotWidth / HorizontalDotsPerPoint) / ((double) DotHeight / VerticalDotsPerPoint);

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
            await PopulateDataBlocksAsync().ConfigureAwait(false);
            PopulateSizes();
        }

        /// <summary>
        /// Scan through the file header blocks loading the positions of the data blocks, stopping when we reach
        /// Start Of Scan.  Uses the length of each block to find the start of the next, so that any images embedded
        /// inside this one are skipped over.
        /// </summary>
        /// <exception cref="InvalidImageException">A data block has been found with the wrong length.</exception>
        private async Task PopulateDataBlocksAsync()
        {
            while (true)
            {
                long startOfBlock = _dataStream.Position;
                int currentByte = _dataStream.ReadByte();
                if (currentByte == -1)
                {
                    return;
                }
                if (currentByte != 255)
                {
                    throw new InvalidImageException("wibble");
                }

                // Load the marker type byte.  If we have found a Start of Scan marker, stop loading metadata.
                int typeByte = _dataStream.ReadByte();
                if (typeByte == 0xda)
                {
                    return;
                }

                ImageDataBlock newBlock = await ImageDataBlockFactory.CreateBlockAsync(_dataStream, startOfBlock, typeByte).ConfigureAwait(false);
                _metadataBlocks.Add(newBlock);
                _dataStream.Seek(startOfBlock + newBlock.Length + 2, SeekOrigin.Begin);
            }
        }

        /// <summary>
        /// Load the image dimensions from the frame header, and the image resolution from the JFIF header if available.
        /// </summary>
        /// <exception cref="InvalidImageException">The file is truncated midway through either the frame header or the JFIF header.</exception>
        private void PopulateSizes()
        {
            const int yPixOffset = 5;
            _dataStream.Seek(StartOfFrameBlock.StartOffset + yPixOffset, SeekOrigin.Begin);
            DotHeight = _dataStream.ReadBigEndianUShort();
            DotWidth = _dataStream.ReadBigEndianUShort();
            if (DotWidth < 0 || DotHeight < 0)
            {
                throw new InvalidImageException(ImageLoadResources.JpegSourceImage_DimensionsNotFound);
            }
            if (JfifBlock != null)
            {
                PopulateDotsPerPoint();
            }
            _dataStream.Seek(0, SeekOrigin.Begin);
        }

        private void PopulateDotsPerPoint()
        {
            const int unitsOffset = 11;
            _dataStream.Seek(JfifBlock.StartOffset + unitsOffset, SeekOrigin.Begin);
            int unitsByte = _dataStream.ReadByte();
            int xDensity = _dataStream.ReadBigEndianUShort();
            int yDensity = _dataStream.ReadBigEndianUShort();
            if (yDensity < 0)
            {
                throw new InvalidImageException(ImageLoadResources.JpegSourceImage_ErrorReadingJFIFData);
            }
            double conversionConstant = 1;
            if (unitsByte == 1) // Resolution is in dots per in.
            {
                conversionConstant = 72;
            }
            else if (unitsByte == 2) // Resolution is in dots per cm.
            {
                conversionConstant = 28.3464567;
            }
            HorizontalDotsPerPoint = xDensity / conversionConstant;
            VerticalDotsPerPoint = yDensity / conversionConstant;
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
    }
}
