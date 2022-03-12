using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Unicorn.Images.Jpeg;

namespace Unicorn.Tests.Integration.Images.Jpeg
{
    [TestClass]
    public class JpegDataSegmentFactoryIntegrationTests
    {
        private readonly string _sourceImage01Path = Path.Combine("TestData", "exampleJpegImage01.jpg");

        private const int _sourceImage01StartOfFrameSegmentOffset = 0x3a4f;
        private const int _sourceImage01StartOfFrameSegmentMarkerByte = 0xc2;
        private const int _sourceImage01ExifSegmentOffset = 0x14;
        private const int _sourceImage01JfifSegmentOffset = 0x2;

        // Note that the "unknown" segment we are testing here uses the same APP1 segment marker as an Exif segment,
        // but it is not an Exif segment and must not be detected as such.
        private const int _sourceImage01UnknownSegmentOffset = 0x2a9c;
        private const int _sourceImage01UnknownSegmentMarkerByte = 0xe1;

        private const int _exifSegmentMarkerByte = 0xe1;
        private const int _jfifSegmentMarkerByte = 0xe0;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public async Task JpegDataSegmentFactoryClass_CreateSegmentAsyncMethod_ReturnsStartOfFrameSegment_ForTestImage01()
        {
            using FileStream sourceDataStream = new(_sourceImage01Path, FileMode.Open, FileAccess.Read);

            JpegDataSegment testOutput = await JpegDataSegmentFactory.CreateSegmentAsync(sourceDataStream, 
                _sourceImage01StartOfFrameSegmentOffset, _sourceImage01StartOfFrameSegmentMarkerByte).ConfigureAwait(false);

            Assert.IsNotNull(testOutput);
            Assert.IsInstanceOfType(testOutput, typeof(StartOfFrameSegment));
            StartOfFrameSegment segment = (StartOfFrameSegment)testOutput;
            Assert.IsTrue(segment.DotWidth != 0);
            Assert.IsTrue(segment.DotHeight != 0);
        }

        [TestMethod]
        public async Task JpegDataSegmentFactoryClass_CreateSegmentAsyncMethod_ReturnsExifSegment_ForTestImage01()
        {
            using FileStream sourceDataStream = new(_sourceImage01Path, FileMode.Open, FileAccess.Read);

            JpegDataSegment testOutput = await JpegDataSegmentFactory.CreateSegmentAsync(sourceDataStream,
                _sourceImage01ExifSegmentOffset, _exifSegmentMarkerByte).ConfigureAwait(false);

            Assert.IsNotNull(testOutput);
            Assert.IsInstanceOfType(testOutput, typeof(ExifSegment));
            Assert.IsTrue(((ExifSegment)testOutput).Tags.Any());
        }

        [TestMethod]
        public async Task JpegDataSegmentFactoryClass_CreateSegmentAsyncMethod_ReturnsJfifSegment_ForTestImage01()
        {
            using FileStream sourceDataStream = new(_sourceImage01Path, FileMode.Open, FileAccess.Read);

            JpegDataSegment testOutput = await JpegDataSegmentFactory.CreateSegmentAsync(sourceDataStream,
                _sourceImage01JfifSegmentOffset, _jfifSegmentMarkerByte).ConfigureAwait(false);

            Assert.IsNotNull(testOutput);
            Assert.IsInstanceOfType(testOutput, typeof(JfifSegment));
        }

        [TestMethod]
        public async Task JpegDataSegmentFactoryClass_CreateSegmentAsyncMethod_ReturnsAnUnknownSegment_ForTestImage01()
        {
            using FileStream sourceDataStream = new(_sourceImage01Path, FileMode.Open, FileAccess.Read);

            JpegDataSegment testOutput = await JpegDataSegmentFactory.CreateSegmentAsync(sourceDataStream,
                _sourceImage01UnknownSegmentOffset, _sourceImage01UnknownSegmentMarkerByte).ConfigureAwait(false);

            Assert.IsNotNull(testOutput);
            Assert.AreEqual(JpegDataSegmentType.Unknown, testOutput.SegmentType);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
