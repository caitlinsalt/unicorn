using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Unicorn.Images.Jpeg;

namespace Unicorn.Tests.Integration.Images.Jpeg
{
    [TestClass]
    public class ExifSegmentIntegrationTests
    {
        private readonly string _sourceImage01Path = Path.Combine("TestData", "exampleJpegImage01.jpg");
        private const int _sourceImage01ExifSegmentOffset = 0x14;
        private const int _sourceImage01ExifSegmentLength = 0x2a86;
        private const string _sourceImage01Maker = "samsung";
        private const string _sourceImage01Model = "SM-A127F";
        private const string _sourceImage01Software = "GIMP 2.10.28";
        private const decimal _sourceImage01FNumber = 2m;
        private const int _sourceImage01Saturation = 0;

        private readonly string _sourceImage03Path = Path.Combine("TestData", "exampleJpegImage03.jpg");
        private const int _sourceImage03ExifSegmentOffset = 0x2;
        private const int _sourceImage03ExifSegmentLength = 0x94a6;
        private const string _sourceImage03Maker = "NIKON CORPORATION";
        private const string _sourceImage03Model = "NIKON D200";
        private const decimal _sourceImage03FNumber = 6.3m;
        private const int _sourceImage03Saturation = 2;

        [TestMethod]
        public async Task ExifSegmentClass_PopulateSegmentAsyncMethod_LoadsMakerTagWithCorrectValue_IfTestFileIsExampleJpegImage01()
        {
            using FileStream sourceDataStream = new(_sourceImage01Path, FileMode.Open, FileAccess.Read);
            ExifSegment testObject = new(_sourceImage01ExifSegmentOffset, _sourceImage01ExifSegmentLength);

            await testObject.PopulateSegmentAsync(sourceDataStream);

            var tag = testObject.Tags.FirstOrDefault(t => t.Id == ExifTagId.Make);
            Assert.IsNotNull(tag);
            Assert.AreEqual(typeof(string), tag.Value.GetType());
            Assert.AreEqual(_sourceImage01Maker, tag.Value as string);
        }

        [TestMethod]
        public async Task ExifSegmentClass_PopulateSegmentAsyncMethod_LoadsModelTagWithCorrectValue_IfTestFileIsExampleJpegImage01()
        {
            using FileStream sourceDataStream = new(_sourceImage01Path, FileMode.Open, FileAccess.Read);
            ExifSegment testObject = new(_sourceImage01ExifSegmentOffset, _sourceImage01ExifSegmentLength);

            await testObject.PopulateSegmentAsync(sourceDataStream);

            var tag = testObject.Tags.FirstOrDefault(t => t.Id == ExifTagId.Model);
            Assert.IsNotNull(tag);
            Assert.AreEqual(typeof(string), tag.Value.GetType());
            Assert.AreEqual(_sourceImage01Model, tag.Value as string);
        }

        [TestMethod]
        public async Task ExifSegmentClass_PopulateSegmentAsyncMethod_LoadsSoftwareTagWithCorrectValue_IfTestFileIsExampleJpegImage01()
        {
            using FileStream sourceDataStream = new(_sourceImage01Path, FileMode.Open, FileAccess.Read);
            ExifSegment testObject = new(_sourceImage01ExifSegmentOffset, _sourceImage01ExifSegmentLength);

            await testObject.PopulateSegmentAsync(sourceDataStream);

            var tag = testObject.Tags.FirstOrDefault(t => t.Id == ExifTagId.Software);
            Assert.IsNotNull(tag);
            Assert.AreEqual(typeof(string), tag.Value.GetType());
            Assert.AreEqual(_sourceImage01Software, tag.Value as string);
        }

        [TestMethod]
        public async Task ExifSegmentClass_PopulateSegmentAsyncMethod_LoadsFNumberTagWithCorrectValue_IfTestFileIsExampleJpegImage01()
        {
            using FileStream sourceDataStream = new(_sourceImage01Path, FileMode.Open, FileAccess.Read);
            ExifSegment testObject = new(_sourceImage01ExifSegmentOffset, _sourceImage01ExifSegmentLength);

            await testObject.PopulateSegmentAsync(sourceDataStream);

            var tag = testObject.Tags.FirstOrDefault(t => t.Id == ExifTagId.FNumber);
            Assert.IsNotNull(tag);
            Assert.AreEqual(typeof(decimal), tag.Value.GetType());
            Assert.AreEqual(_sourceImage01FNumber, (decimal)tag.Value);
        }

        [TestMethod]
        public async Task ExifSegmentClass_PopulateSegmentAsyncMethod_LoadsSaturationTagWithCorrectValue_IfTestFileIsExampleJpegImage01()
        {
            using FileStream sourceDataStream = new(_sourceImage01Path, FileMode.Open, FileAccess.Read);
            ExifSegment testObject = new(_sourceImage01ExifSegmentOffset, _sourceImage01ExifSegmentLength);

            await testObject.PopulateSegmentAsync(sourceDataStream);

            var tag = testObject.Tags.FirstOrDefault(t => t.Id == ExifTagId.Saturation);
            Assert.IsNotNull(tag);
            Assert.AreEqual(typeof(int), tag.Value.GetType());
            Assert.AreEqual(_sourceImage01Saturation, (int)tag.Value);
        }

        [TestMethod]
        public async Task ExifSegmentClass_PopulateSegmentAsyncMethod_LoadsMakerTagWithCorrectValue_IfTestFileIsExampleJpegImage03()
        {
            using FileStream sourceDataStream = new(_sourceImage03Path, FileMode.Open, FileAccess.Read);
            ExifSegment testObject = new(_sourceImage03ExifSegmentOffset, _sourceImage03ExifSegmentLength);

            await testObject.PopulateSegmentAsync(sourceDataStream);

            var tag = testObject.Tags.FirstOrDefault(t => t.Id == ExifTagId.Make);
            Assert.IsNotNull(tag);
            Assert.AreEqual(typeof(string), tag.Value.GetType());
            Assert.AreEqual(_sourceImage03Maker, tag.Value as string);
        }

        [TestMethod]
        public async Task ExifSegmentClass_PopulateSegmentAsyncMethod_LoadsModelTagWithCorrectValue_IfTestFileIsExampleJpegImage03()
        {
            using FileStream sourceDataStream = new(_sourceImage03Path, FileMode.Open, FileAccess.Read);
            ExifSegment testObject = new(_sourceImage03ExifSegmentOffset, _sourceImage03ExifSegmentLength);

            await testObject.PopulateSegmentAsync(sourceDataStream);

            var tag = testObject.Tags.FirstOrDefault(t => t.Id == ExifTagId.Model);
            Assert.IsNotNull(tag);
            Assert.AreEqual(typeof(string), tag.Value.GetType());
            Assert.AreEqual(_sourceImage03Model, tag.Value as string);
        }

        [TestMethod]
        public async Task ExifSegmentClass_PopulateSegmentAsyncMethod_LoadsFNumberTagWithCorrectValue_IfTestFileIsExampleJpegImage03()
        {
            using FileStream sourceDataStream = new(_sourceImage03Path, FileMode.Open, FileAccess.Read);
            ExifSegment testObject = new(_sourceImage03ExifSegmentOffset, _sourceImage03ExifSegmentLength);

            await testObject.PopulateSegmentAsync(sourceDataStream);

            var tag = testObject.Tags.FirstOrDefault(t => t.Id == ExifTagId.FNumber);
            Assert.IsNotNull(tag);
            Assert.AreEqual(typeof(decimal), tag.Value.GetType());
            Assert.AreEqual(_sourceImage03FNumber, (decimal)tag.Value);
        }

        [TestMethod]
        public async Task ExifSegmentClass_PopulateSegmentAsyncMethod_LoadsSaturationTagWithCorrectValue_IfTestFileIsExampleJpegImage03()
        {
            using FileStream sourceDataStream = new(_sourceImage03Path, FileMode.Open, FileAccess.Read);
            ExifSegment testObject = new(_sourceImage03ExifSegmentOffset, _sourceImage03ExifSegmentLength);

            await testObject.PopulateSegmentAsync(sourceDataStream);

            var tag = testObject.Tags.FirstOrDefault(t => t.Id == ExifTagId.Saturation);
            Assert.IsNotNull(tag);
            Assert.AreEqual(typeof(int), tag.Value.GetType());
            Assert.AreEqual(_sourceImage03Saturation, (int)tag.Value);
        }
    }
}
