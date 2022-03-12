using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Threading.Tasks;
using Unicorn.Images.Jpeg;

namespace Unicorn.Tests.Integration.Images.Jpeg
{
    [TestClass]
    public class StartOfFrameSegmentIntegrationTests
    {
        private readonly string _sourceImage01Path = Path.Combine("TestData", "exampleJpegImage01.jpg");
        private const int _sourceImage01StartOfFrameOffset = 0x3a4f;
        private const int _sourceImage01SegmentLength = 0x11;
        private const int _sourceImage01Width = 823;
        private const int _sourceImage01Height = 581;

        private readonly string _sourceImage03Path = Path.Combine("TestData", "exampleJpegImage03.jpg");
        private const int _sourceImage03StartOfFrameOffset = 0x9530;
        private const int _sourceImage03SegmentLength = 0x11;

        // Example image 3 is a landscape-format image that uses the EXIF Orientation tag to indicate it should be displayed as portrait-format.
        // The width and height for the SOF segment therefore show it as landscape, but within the full context of a JpegSourceImage it should appear
        // as portrait, with the width and height given here transposed.
        private const int _sourceImage03Width = 3872;
        private const int _sourceImage03Height = 2592;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public async Task StartOfFrameSegmentClass_PopulateSegmentAsyncMethod_SetsDotWidthPropertyToCorrectValue_IfTestFileIsExampleJpegImage01()
        {
            using FileStream sourceDataStream = new(_sourceImage01Path, FileMode.Open, FileAccess.Read);
            StartOfFrameSegment testObject = new(_sourceImage01StartOfFrameOffset, _sourceImage01SegmentLength);

            await testObject.PopulateSegmentAsync(sourceDataStream).ConfigureAwait(false);

            Assert.AreEqual(_sourceImage01Width, testObject.DotWidth);
        }

        [TestMethod]
        public async Task StartOfFrameSegmentClass_PopulateSegmentAsyncMethod_SetsDotHeightPropertyToCorrectValue_IfTestFileIsExampleJpegImage01()
        {
            using FileStream sourceDataStream = new(_sourceImage01Path, FileMode.Open, FileAccess.Read);
            StartOfFrameSegment testObject = new(_sourceImage01StartOfFrameOffset, _sourceImage01SegmentLength);

            await testObject.PopulateSegmentAsync(sourceDataStream).ConfigureAwait(false);

            Assert.AreEqual(_sourceImage01Height, testObject.DotHeight);
        }

        [TestMethod]
        public async Task StartOfFrameSegmentClass_PopulateSegmentAsyncMethod_SetsDotWidthPropertyToCorrectValue_IfTestFileIsExampleJpegImage03()
        {
            using FileStream sourceDataStream = new(_sourceImage03Path, FileMode.Open, FileAccess.Read);
            StartOfFrameSegment testObject = new(_sourceImage03StartOfFrameOffset, _sourceImage03SegmentLength);

            await testObject.PopulateSegmentAsync(sourceDataStream).ConfigureAwait(false);

            Assert.AreEqual(_sourceImage03Width, testObject.DotWidth);
        }

        [TestMethod]
        public async Task StartOfFrameSegmentClass_PopulateSegmentAsyncMethod_SetsDotHeightPropertyToCorrectValue_IfTestFileIsExampleJpegImage03()
        {
            using FileStream sourceDataStream = new(_sourceImage03Path, FileMode.Open, FileAccess.Read);
            StartOfFrameSegment testObject = new(_sourceImage03StartOfFrameOffset, _sourceImage03SegmentLength);

            await testObject.PopulateSegmentAsync(sourceDataStream).ConfigureAwait(false);

            Assert.AreEqual(_sourceImage03Height, testObject.DotHeight);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
