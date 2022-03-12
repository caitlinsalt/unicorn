using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Threading.Tasks;
using Unicorn.Images.Jpeg;

namespace Unicorn.Tests.Integration.Images.Jpeg
{
    [TestClass]
    public class JfifSegmentIntegrationTests
    {
        private readonly string _sourceImage01Path = Path.Combine("TestData", "exampleJpegImage01.jpg");
        private const int _sourceImage01JfifSegmentOffset = 0x2;
        private const int _sourceImage01JfifSegmentLength = 0x12;
        private const double _sourceImage01HorizontalDotsPerPoint = 1d;
        private const double _sourceImage01VerticalDotsPerPoint = 1d;

        private readonly string _sourceImage02Path = Path.Combine("TestData", "exampleJpegImage02.jpg");
        private const int _sourceImage02JfifSegmentOffset = 0x2;
        private const int _sourceImage02JfifSegmentLength = 0x12;
        private const double _sourceImage02HorizontalDotsPerPoint = 1d;
        private const double _sourceImage02VerticalDotsPerPoint = 0.5;

        [TestMethod]
        public async Task JfifSegmentClass_PopulateSegmentAsyncMethod_LoadsHorizontalDotsPerPointPropertyWithCorrectValue_IfTestFileIsExampleJpegImage01()
        {
            using FileStream sourceDataStream = new(_sourceImage01Path, FileMode.Open, FileAccess.Read);
            JfifSegment testObject = new(_sourceImage01JfifSegmentOffset, _sourceImage01JfifSegmentLength);

            await testObject.PopulateSegmentAsync(sourceDataStream);

            Assert.AreEqual(_sourceImage01HorizontalDotsPerPoint, testObject.HorizontalDotsPerPoint);
        }

        [TestMethod]
        public async Task JfifSegmentClass_PopulateSegmentAsyncMethod_LoadsVerticalDotsPerPointPropertyWithCorrectValue_IfTestFileIsExampleJpegImage01()
        {
            using FileStream sourceDataStream = new(_sourceImage01Path, FileMode.Open, FileAccess.Read);
            JfifSegment testObject = new(_sourceImage01JfifSegmentOffset, _sourceImage01JfifSegmentLength);

            await testObject.PopulateSegmentAsync(sourceDataStream);

            Assert.AreEqual(_sourceImage01VerticalDotsPerPoint, testObject.VerticalDotsPerPoint);
        }

        [TestMethod]
        public async Task JfifSegmentClass_PopulateSegmentAsyncMethod_LoadsHorizontalDotsPerPointPropertyWithCorrectValue_IfTestFileIsExampleJpegImage02()
        {
            using FileStream sourceDataStream = new(_sourceImage02Path, FileMode.Open, FileAccess.Read);
            JfifSegment testObject = new(_sourceImage02JfifSegmentOffset, _sourceImage01JfifSegmentLength);

            await testObject.PopulateSegmentAsync(sourceDataStream);

            Assert.AreEqual(_sourceImage02HorizontalDotsPerPoint, testObject.HorizontalDotsPerPoint);
        }

        [TestMethod]
        public async Task JfifSegmentClass_PopulateSegmentAsyncMethod_LoadsVerticalDotsPerPointPropertyWithCorrectValue_IfTestFileIsExampleJpegImage02()
        {
            using FileStream sourceDataStream = new(_sourceImage02Path, FileMode.Open, FileAccess.Read);
            JfifSegment testObject = new(_sourceImage02JfifSegmentOffset, _sourceImage02JfifSegmentLength);

            await testObject.PopulateSegmentAsync(sourceDataStream);

            Assert.AreEqual(_sourceImage02VerticalDotsPerPoint, testObject.VerticalDotsPerPoint);
        }
    }
}
