using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Threading.Tasks;
using Unicorn.Images;

namespace Unicorn.Tests.Integration.Images
{
    [TestClass]
    public class JpegSourceImageIntegrationTests
    {
        // Example image 01 was created using a Samsung phone, then edited using GIMP.  It is a JFIF file that includes an EXIF segment.
        // Example image 02 is example image 01 edited to have a lower resolution and intended to be displayed with non-square pixels, to
        //     test the aspect ratio code handles these cases properly.  It also is a JFIF file with an EXIF segment.
        // Example image 03 was created using a late-2000s Nikon camera and is exactly as written by the camera.  It is an EXIF file
        //     and does not have a JFIF segment.  It uses the EXIF Orientation tag to indicate it should be rotated for display.

        private readonly string _sourceImagePath = Path.Combine("TestData", "exampleJpegImage01.jpg");
        private readonly string _sourceImagePathWithNonSquarePixels = Path.Combine("TestData", "exampleJpegImage02.jpg");
        private readonly string _sourceImagePathWithExifRotation = Path.Combine("TestData", "exampleJpegImage03.jpg");
        private const int _sourceImageWidth = 823;
        private const int _sourceImageHeight = 581;
        private const double _sourceImageWithNonSquarePixelsAspectRatio = 805 / (double)568;
        private const double _sourceImageWithExifRotationAspectRatio = 2592 / (double)3872;
        private const int _sourceImage03Width = 2592;
        private const int _sourceImage03Height = 3872;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public async Task JpegSourceImageClass_LoadFromAsyncMethod_DoesNotThrowException()
        {
            using FileStream sourceDataStream = new(_sourceImagePath, FileMode.Open, FileAccess.Read);
            using JpegSourceImage testObject = new();

            await testObject.LoadFromAsync(sourceDataStream).ConfigureAwait(false);
        }

        [TestMethod]
        public async Task JpegSourceImageClass_LoadFromAsyncMethod_SetsDotWidthPropertyToCorrectValue()
        {
            using FileStream sourceDataStream = new(_sourceImagePath, FileMode.Open, FileAccess.Read);
            using JpegSourceImage testObject = new();

            await testObject.LoadFromAsync(sourceDataStream).ConfigureAwait(false);

            Assert.AreEqual(_sourceImageWidth, testObject.DotWidth);
        }

        [TestMethod]
        public async Task JpegSourceImageClass_LoadFromAsyncMethod_SetsRawDotWidthPropertyToCorrectValue()
        {
            using FileStream sourceDataStream = new(_sourceImagePath, FileMode.Open, FileAccess.Read);
            using JpegSourceImage testObject = new();

            await testObject.LoadFromAsync(sourceDataStream).ConfigureAwait(false);

            Assert.AreEqual(_sourceImageWidth, testObject.RawDotWidth);
        }

        [TestMethod]
        public async Task JpegSourceImageClass_LoadFromAsyncMethod_SetsDotHeightPropertyToCorrectValue()
        {
            using FileStream sourceDataStream = new(_sourceImagePath, FileMode.Open, FileAccess.Read);
            using JpegSourceImage testObject = new();

            await testObject.LoadFromAsync(sourceDataStream).ConfigureAwait(false);

            Assert.AreEqual(_sourceImageHeight, testObject.DotHeight);
        }

        [TestMethod]
        public async Task JpegSourceImageClass_LoadFromAsyncMethod_SetsRawDotHeightPropertyToCorrectValue()
        {
            using FileStream sourceDataStream = new(_sourceImagePath, FileMode.Open, FileAccess.Read);
            using JpegSourceImage testObject = new();

            await testObject.LoadFromAsync(sourceDataStream).ConfigureAwait(false);

            Assert.AreEqual(_sourceImageHeight, testObject.RawDotHeight);
        }

        [TestMethod]
        public async Task JpegSourceImageClass_LoadFromAsyncMethod_SetsAspectRatioPropertyToCorrectValue()
        {
            using FileStream sourceDataStream = new(_sourceImagePath, FileMode.Open, FileAccess.Read);
            using JpegSourceImage testObject = new();

            await testObject.LoadFromAsync(sourceDataStream).ConfigureAwait(false);

            Assert.AreEqual(_sourceImageWidth / (double)_sourceImageHeight, testObject.AspectRatio);
        }

        [TestMethod]
        public async Task JpegSourceImageClass_LoadFromAsyncMethod_SetsAspectRatioPropertyToCorrectValue_IfImagePixelsAreNotSquare()
        {
            using FileStream sourceDataStream = new(_sourceImagePathWithNonSquarePixels, FileMode.Open, FileAccess.Read);
            using JpegSourceImage testObject = new();

            await testObject.LoadFromAsync(sourceDataStream).ConfigureAwait(false);

            Assert.AreEqual(_sourceImageWithNonSquarePixelsAspectRatio, testObject.AspectRatio);
        }

        [TestMethod]
        public async Task JpegSourceImageClass_LoadFromAsyncMethod_SetsAspectRatioPropertyToCorrectValue_IfImageIsRotatedWithExifTag()
        {
            using FileStream sourceDataStream = new(_sourceImagePathWithExifRotation, FileMode.Open, FileAccess.Read);
            using JpegSourceImage testObject = new();

            await testObject.LoadFromAsync(sourceDataStream).ConfigureAwait(false);

            Assert.AreEqual(_sourceImageWithExifRotationAspectRatio, testObject.AspectRatio);
        }

        [TestMethod]
        public async Task JpegSourceImageClass_LoadFromAsyncMethod_SetsDotWidthPropertyToCorrectValue_IfImageIsRotatedWithExifTag()
        {
            using FileStream sourceDataStream = new(_sourceImagePathWithExifRotation, FileMode.Open, FileAccess.Read);
            using JpegSourceImage testObject = new();

            await testObject.LoadFromAsync(sourceDataStream).ConfigureAwait(false);

            Assert.AreEqual(_sourceImage03Width, testObject.DotWidth);
        }

        [TestMethod]
        public async Task JpegSourceImageClass_LoadFromAsyncMethod_SetsRawDotWidthPropertyToCorrectValue_IfImageIsRotatedWithExifTag()
        {
            using FileStream sourceDataStream = new(_sourceImagePathWithExifRotation, FileMode.Open, FileAccess.Read);
            using JpegSourceImage testObject = new();

            await testObject.LoadFromAsync(sourceDataStream).ConfigureAwait(false);

            Assert.AreEqual(_sourceImage03Height, testObject.RawDotWidth);
        }

        [TestMethod]
        public async Task JpegSourceImageClass_LoadFromAsyncMethod_SetsDotHeightPropertyToCorrectValue_IfImageIsRotatedWithExifTag()
        {
            using FileStream sourceDataStream = new(_sourceImagePathWithExifRotation, FileMode.Open, FileAccess.Read);
            using JpegSourceImage testObject = new();

            await testObject.LoadFromAsync(sourceDataStream).ConfigureAwait(false);

            Assert.AreEqual(_sourceImage03Height, testObject.DotHeight);
        }

        [TestMethod]
        public async Task JpegSourceImageClass_LoadFromAsyncMethod_SetsRawDotHeightPropertyToCorrectValue_IfImageIsRotatedWithExifTag()
        {
            using FileStream sourceDataStream = new(_sourceImagePathWithExifRotation, FileMode.Open, FileAccess.Read);
            using JpegSourceImage testObject = new();

            await testObject.LoadFromAsync(sourceDataStream).ConfigureAwait(false);

            Assert.AreEqual(_sourceImage03Width, testObject.RawDotHeight);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
