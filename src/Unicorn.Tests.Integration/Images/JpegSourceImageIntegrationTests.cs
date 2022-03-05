using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Threading.Tasks;
using Unicorn.Images;

namespace Unicorn.Tests.Integration.Images
{
    [TestClass]
    public class JpegSourceImageIntegrationTests
    {
        private readonly string _sourceImagePath = Path.Combine("TestData", "exampleJpegImage01.jpg");
        private readonly string _sourceImagePathWithNonSquarePixels = Path.Combine("TestData", "exampleJpegImage02.jpg");
        private readonly string _sourceImagePathWithExifRotation = Path.Combine("TestData", "exampleJpegImage03.jpg");
        private const int _sourceImageWidth = 823;
        private const int _sourceImageHeight = 581;
        private const double _sourceImageWithNonSquarePixelsAspectRatio = 805 / (double)568;
        private const double _sourceImageWithExifRotationAspectRatio = 2592 / (double)3872;

        [TestMethod]
        public async Task JpegSourceImageClass_LoadFromAsyncMethod_DoesNotThrowException()
        {
            using FileStream sourceDataStream = new(_sourceImagePath, FileMode.Open, FileAccess.Read);
            using JpegSourceImage testObject = new();

            await testObject.LoadFromAsync(sourceDataStream);
        }

        [TestMethod]
        public async Task JpegSourceImageClass_LoadFromAsyncMethod_SetsDotWidthPropertyToCorrectValue()
        {
            using FileStream sourceDataStream = new(_sourceImagePath, FileMode.Open, FileAccess.Read);
            using JpegSourceImage testObject = new();

            await testObject.LoadFromAsync(sourceDataStream);

            Assert.AreEqual(_sourceImageWidth, testObject.DotWidth);
        }

        [TestMethod]
        public async Task JpegSourceImageClass_LoadFromAsyncMethod_SetsDotHeightPropertyToCorrectValue()
        {
            using FileStream sourceDataStream = new(_sourceImagePath, FileMode.Open, FileAccess.Read);
            using JpegSourceImage testObject = new();

            await testObject.LoadFromAsync(sourceDataStream);

            Assert.AreEqual(_sourceImageHeight, testObject.DotHeight);
        }

        [TestMethod]
        public async Task JpegSourceImageClass_LoadFromAsyncMethod_SetsAspectRatioPropertyToCorrectValue()
        {
            using FileStream sourceDataStream = new(_sourceImagePath, FileMode.Open, FileAccess.Read);
            using JpegSourceImage testObject = new();

            await testObject.LoadFromAsync(sourceDataStream);

            Assert.AreEqual(_sourceImageWidth / (double)_sourceImageHeight, testObject.AspectRatio);
        }

        [TestMethod]
        public async Task JpegSourceImageClass_LoadFromAsyncMethod_SetsAspectRatioPropertyToCorrectValue_IfImagePixelsAreNotSquare()
        {
            using FileStream sourceDataStream = new(_sourceImagePathWithNonSquarePixels, FileMode.Open, FileAccess.Read);
            using JpegSourceImage testObject = new();

            await testObject.LoadFromAsync(sourceDataStream);

            Assert.AreEqual(_sourceImageWithNonSquarePixelsAspectRatio, testObject.AspectRatio);
        }

        [TestMethod]
        public async Task JpegSourceImageClass_LoadFromAsyncMethod_SetsAspectRatioPropertyToCorrectValue_IfImageIsRotatedWithExifTag()
        {
            using FileStream sourceDataStream = new(_sourceImagePathWithExifRotation, FileMode.Open, FileAccess.Read);
            using JpegSourceImage testObject = new();

            await testObject.LoadFromAsync(sourceDataStream);

            Assert.AreEqual(_sourceImageWithExifRotationAspectRatio, testObject.AspectRatio);
        }
    }
}
