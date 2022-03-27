using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Unicorn.Exceptions;
using Unicorn.Images.Jpeg;
using Unicorn.Writer;

namespace Unicorn.Images
{
    /// <summary>
    /// Loads and parses JPEG images (including JFIF and EXIF) sufficiently to embed them into a PDF.
    /// </summary>
    public class JpegSourceImage : BaseSourceImage
    {
        private readonly List<JpegDataSegment> _dataSegments = new List<JpegDataSegment>();

        private StartOfFrameSegment StartOfFrameSegment => _dataSegments.FirstOrDefault(b => b is StartOfFrameSegment) as StartOfFrameSegment;

        private JfifSegment JfifSegment => _dataSegments.FirstOrDefault(b => b is JfifSegment) as JfifSegment;

        private ExifSegment ExifSegment => _dataSegments.FirstOrDefault(b => b is ExifSegment) as ExifSegment;

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
        /// The encoding mode of the JPEG (sequential or progressive).
        /// </summary>
        public JpegEncodingMode EncodingMode => StartOfFrameSegment?.EncodingMode ?? JpegEncodingMode.Sequential;

        /// <summary>
        /// The raw data of the JPEG.
        /// </summary>
        public override IEnumerable<byte> RawData
        {
            get
            {
                if (Features.SelectedStreamFeatures.HasFlag(Features.StreamFeatures.RemoveExifDataFromJpegStreams))
                {
                    return new JpegSourceImageDataEnumerable(this);
                }
                return _dataStream.ToArray();
            }
        }

        /// <summary>
        /// Load a JPEG image from a stream.  The stream's current position should be the first byte of the JPEG data
        /// </summary>
        /// <param name="stream">The source data stream.</param>
        /// <returns>A <see cref="Task" /> which will be completed when the image is loaded.</returns>
        /// <exception cref="ArgumentNullException">The <c>stream</c> parameter is null.</exception>
        /// <exception cref="ObjectDisposedException">The <c>stream</c> parameter is disposed, or the <see cref="JpegSourceImage" /> object is disposed.</exception>
        /// <exception cref="NotSupportedException">The <c>stream</c> parameter does not support reading.</exception>
        /// <exception cref="InvalidImageException">
        /// Any one of the following issues has been found in the image data:
        /// <list type="bullet">
        ///   <item><description>The <c>stream</c> data does not begin with the JPEG "Start Of Image" segment marker.</description></item>
        ///   <item><description>The stream data does not contain a JPEG frame header segment.</description></item>
        ///   <item><description>The JPEG frame header segment appears to be too short to contain an image size at the correct location.</description></item>
        ///   <item><description>The data contains a JFIF segment, but it appears to be too short to contain image resolution data at the correct location.</description></item>
        ///   <item><description>The data contains an EXIF segment, but it does not contain a valid byte order marker, or the magic number following.</description></item>
        ///   <item><description>The data contains an EXIF segment, but it appears to contain pointers to locations outside the data stream.</description></item>
        ///   <item><description>The data contains an EXIF segment, but it appears to contain tags with data types not listed in the EXIF specification.</description></item>
        /// </list>
        /// </exception>
        /// <remarks>
        /// <para>
        /// This class does minimal syntax checking of the JPEG data, beyond confirming that it starts with the correct magic number, and that at some point in the data,
        /// it appears to contain a JPEG frame header which starts more than a few bytes from the end of the file, so that the image size can be read from the location it
        /// will be in if the frame header is valid.  If the file contains a JFIF segment, the class also reads the image resolution.  If the file contains an EXIF segment,
        /// the class checks that the EXIF segment contains a valid byte order marker and the "42" magic number that follows it; then tries to load all of the EXIF tags and
        /// checks they all have a valid data type listed in the EXIF spec.  It doesn't check that the individual tags' data types are actually the ones defined in the spec,
        /// but will throw an exception if the EXIF segment data tries to cause a buffer overflow by containing pointer values that point to locations outside the segment.
        /// </para>
        /// <para>
        /// Depending on the type of <see cref="Stream" /> passed to this method, this method may throw additional exception types not listed here.  It may throw any
        /// exception potentially throwable by <see cref="Stream.ReadAsync(byte[], int, int)" /> or <see cref="Stream.ReadByte"/>, for the given <see cref="Stream"/> implementation.
        /// </para>
        /// <para>
        /// This method loads data stream into memory, starting at its current position but continuing to the end of the stream, without checking for the End Of Image marker.
        /// It is the caller's responsibility to confirm that the data stream is not excessively large for their use case.
        /// </para>
        /// </remarks>
        public override async Task LoadFromAsync(Stream stream)
        {
            await base.LoadFromAsync(stream).ConfigureAwait(false);
            CheckStartOfImageMarker();
            await PopulateDataSegmentsAsync().ConfigureAwait(false);
            if (StartOfFrameSegment is null)
            {
                throw new InvalidImageException(ImageLoadResources.JpegSourceImage_SofNotFound);
            }
            PopulateSizes();
        }

        /// <summary>
        /// Scan through the file data segments, loading each one to the extent that we care about it.  For most segments only the 
        /// name and location is loaded.  For an EXIF segment we load all the metadata tags but ignore any thumbnail.  Uses the length of 
        /// each block to find the start of the next, so that the segments of any thumbnail images embedded inside this one are skipped over.
        /// </summary>
        private async Task PopulateDataSegmentsAsync()
        {
            while (true)
            {
                // We enter this loop assuming the stream pointer potentially is at the start of a data segment.
                // We search forward for a segment marker.
                int currentByte;
                do
                {
                    currentByte = _dataStream.ReadByte();
                    if (currentByte == -1)
                    {
                        return;
                    }
                } while (currentByte != 255);
                long startOfSegment = _dataStream.Position - 1;

                // Load the marker type byte.  If the type byte is apparently zero, this isn't really a segment marker,
                // it's a "stuffed FF" byte inside other data.
                int typeByte = _dataStream.ReadByte();
                if (typeByte == 0)
                {
                    continue;
                }
                // Check for the EOI marker
                if (typeByte == 0xd9)
                {
                    return;
                }

                JpegDataSegment newSegment = await JpegDataSegmentFactory.CreateSegmentAsync(_dataStream, startOfSegment, typeByte).ConfigureAwait(false);
                _dataSegments.Add(newSegment);

                // Reposition the stream pointer at the byte following the segment just loaded
                _dataStream.Seek(startOfSegment + newSegment.Length, SeekOrigin.Begin);
            }
        }

        /// <summary>
        /// Load the image dimensions from the frame header segment, and the image resolution from the JFIF segment if available, taking account of 
        /// any EXIF rotation tag present.
        /// </summary>
        /// <exception cref="InvalidImageException">The file is truncated midway through either the frame header segment or the JFIF segment.</exception>
        private void PopulateSizes()
        {
            if (JfifSegment != null)
            {
                PopulateDotsPerPoint();
            }
            if (ExifSegment?.Orientation != null && ExifSegment.Orientation.Value.IsQuarterRotated())
            {
                DotWidth = StartOfFrameSegment.DotHeight;
                DotHeight = StartOfFrameSegment.DotWidth;
            }
            else
            {
                DotWidth = StartOfFrameSegment.DotWidth;
                DotHeight = StartOfFrameSegment.DotHeight;
            }
        }

        private void PopulateDotsPerPoint()
        {
            HorizontalDotsPerPoint = JfifSegment.HorizontalDotsPerPoint;
            VerticalDotsPerPoint = JfifSegment.VerticalDotsPerPoint;
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

        internal class JpegSourceImageDataEnumerable : IEnumerable<byte>
        {
            private readonly JpegSourceImage _sourceImage;

            internal JpegSourceImageDataEnumerable(JpegSourceImage source)
            {
                _sourceImage = source;
            }

            public IEnumerator<byte> GetEnumerator()
                => new JpegSourceImageDataEnumerator(_sourceImage);

            IEnumerator IEnumerable.GetEnumerator()
                => new JpegSourceImageDataEnumerator(_sourceImage);
        }

        internal class JpegSourceImageDataEnumerator : IEnumerator<byte>
        {
            private readonly JpegSourceImage _sourceImage;
            private readonly byte[] _rawData;
            private int _position = -1;

            internal JpegSourceImageDataEnumerator(JpegSourceImage source)
            {
                _sourceImage = source;
                _rawData = _sourceImage._dataStream.ToArray();
            }

            public byte Current => _position >= 0 && _position < _rawData.Length ? _rawData[_position] : (byte)0;

            object IEnumerator.Current => Current;

            public void Dispose() { }

            public bool MoveNext()
            {
                _position++;
                SkipSignificantSegments();
                return _position < _rawData.Length;
            }

            public void Reset()
            {
                _position = -1;
            }

            private void SkipSignificantSegments()
            {
                if (SkipSegment(_sourceImage.ExifSegment))
                {
                    SkipSignificantSegments();
                }
                if (SkipSegment(_sourceImage.JfifSegment))
                {
                    SkipSignificantSegments();
                }
            }
            
            private bool SkipSegment(JpegDataSegment segment)
            {
                if (WithinSegment(segment))
                {
                    _position += segment.Length;
                    return true;
                }
                return false;
            }

            private bool WithinSegment(JpegDataSegment segment)
                => segment != null && _position >= segment.StartOffset && _position < segment.StartOffset + segment.Length;
        }
    }
}
