using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.Base;
using Unicorn.Base.Tests.Utility;
using Unicorn.Images;

namespace Unicorn.Tests.Unit.Images
{
    [TestClass]
    public class ImageDescriptorUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private Mock<IDocumentDescriptor> _mockDocument;
        private Mock<IPdfInternalReference> _mockStreamReference;
        private string _mockFingerprint;
        private RightAngleRotation _mockRightAngleRotation;

        private ImageDescriptor _testObject;

        [TestInitialize]
        public void SetUpTest()
        {
            _mockDocument = new();
            _mockStreamReference = new();
            _mockFingerprint = _rnd.NextHexString(32);
            _mockRightAngleRotation = _rnd.NextRightAngleRotation();

            _testObject = new(_mockDocument.Object, _mockStreamReference.Object, _mockFingerprint, _mockRightAngleRotation);
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void ImageDescriptorClass_Constructor_SetsDocumentPropertyToValueOfFirstParameter()
        {
            IDocumentDescriptor testParam0 = new Mock<IDocumentDescriptor>().Object;
            IPdfInternalReference testParam1 = new Mock<IPdfInternalReference>().Object;
            string testParam2 = _rnd.NextHexString(32);
            RightAngleRotation testParam3 = _rnd.NextRightAngleRotation();

            ImageDescriptor testOutput = new(testParam0, testParam1, testParam2, testParam3);

            Assert.AreSame(testParam0, testOutput.Document);
        }

        [TestMethod]
        public void ImageDescriptorClass_Constructor_SetsDataStreamPropertyToValueOfSecondParameter()
        {
            IDocumentDescriptor testParam0 = new Mock<IDocumentDescriptor>().Object;
            IPdfInternalReference testParam1 = new Mock<IPdfInternalReference>().Object;
            string testParam2 = _rnd.NextHexString(32);
            RightAngleRotation testParam3 = _rnd.NextRightAngleRotation();

            ImageDescriptor testOutput = new(testParam0, testParam1, testParam2, testParam3);

            Assert.AreSame(testParam1, testOutput.DataStream);
        }

        [TestMethod]
        public void ImageDescriptorClass_Constructor_SetsImageFingerprintPropertyToValueOfThirdParameter()
        {
            IDocumentDescriptor testParam0 = new Mock<IDocumentDescriptor>().Object;
            IPdfInternalReference testParam1 = new Mock<IPdfInternalReference>().Object;
            string testParam2 = _rnd.NextHexString(32);
            RightAngleRotation testParam3 = _rnd.NextRightAngleRotation();

            ImageDescriptor testOutput = new(testParam0, testParam1, testParam2, testParam3);

            Assert.AreEqual(testParam2, testOutput.ImageFingerprint);
        }

#pragma warning disable CA5394 // Do not use insecure randomness

        [TestMethod]
        public void ImageDescriptorClass_UseOnPageMethod_ReturnsNull_IfFirstParameterIsNull()
        {
            IPageDescriptor testParam0 = null;
            string testParam1 = _rnd.NextString(_rnd.Next(100));

            string testOutput = _testObject.UseOnPage(testParam0, testParam1);

            Assert.IsNull(testOutput);
        }

        [TestMethod]
        public void IamgeDescriptorClass_UseOnPageMethod_ReturnsSecondParameter_WhenCalledForTheFirstTime_IfFirstParameterIsNotNull()
        {
            IPageDescriptor testParam0 = new Mock<IPageDescriptor>().Object;
            string testParam1 = _rnd.NextString(_rnd.Next(100));

            string testOutput = _testObject.UseOnPage(testParam0, testParam1);

            Assert.AreEqual(testParam1, testOutput);
        }

        [TestMethod]
        public void ImageDescriptorClass_UseOnPageMethod_ReturnsSecondParameter_WhenCalledForTheFirstTimeWithTheSpecificFirstParameter_IfFirstParameterIsNotNull()
        {
            IPageDescriptor testParam0 = new Mock<IPageDescriptor>().Object;
            string testParam1 = _rnd.NextString(_rnd.Next(100));
            _testObject.UseOnPage(new Mock<IPageDescriptor>().Object, _rnd.NextString(_rnd.Next(100)));

            string testOutput = _testObject.UseOnPage(testParam0, testParam1);

            Assert.AreEqual(testParam1, testOutput);
        }

        [TestMethod]
        public void ImageDescriptorClass_UseOnPageMethod_ReturnsSecondParameterOfFirstCall_WhenCalledMultipleTimesWithTheSameFirstParameter_IfFirstParameterIsNotNull()
        {
            IPageDescriptor testParam0 = new Mock<IPageDescriptor>().Object;
            string expectedOutput = _rnd.NextString(_rnd.Next(100));
            string testParam1;
            do
            {
                testParam1 = _rnd.NextString(_rnd.Next(100));
            } while (testParam1 == expectedOutput);
            int callCount = _rnd.Next(5);
            _testObject.UseOnPage(testParam0, expectedOutput);
            for (int i = 0; i < callCount; i++)
            {
                _testObject.UseOnPage(testParam0, _rnd.NextString(_rnd.Next(100)));
            }

            string testOutput = _testObject.UseOnPage(testParam0, testParam1);

            Assert.AreEqual(expectedOutput, testOutput);
        }

        [TestMethod]
        public void ImageDescriptorClass_GetNameOnPageMethod_ReturnsNull_IfParameterIsNull()
        {
            IPageDescriptor testParam = null;

            string testOutput = _testObject.GetNameOnPage(testParam);

            Assert.IsNull(testOutput);
        }

        [TestMethod]
        public void ImageDescriptorClass_GetNameOnPageMethod_ReturnsNull_IfUseOnPageMethodHasNeverBeenCalledWithSameObjectAsParameter()
        {
            IPageDescriptor testParam = new Mock<IPageDescriptor>().Object;
            _testObject.UseOnPage(new Mock<IPageDescriptor>().Object, _rnd.NextString(_rnd.Next(50)));

            string testOutput = _testObject.GetNameOnPage(testParam);

            Assert.IsNull(testOutput);
        }

        [TestMethod]
        public void ImageDescriptorClass_GetNameOnPageMethod_ReturnsValuePassedToFirstCallOfUseOnPageMethodWithSameParameter()
        {
            IPageDescriptor testParam = new Mock<IPageDescriptor>().Object;
            string expectedResult = _rnd.NextString(_rnd.Next(50));
            _testObject.UseOnPage(testParam, expectedResult);
            int extraCallCount = _rnd.Next(5);
            for (int i = 0; i < extraCallCount; ++i)
            {
                _testObject.UseOnPage(testParam, _rnd.NextString(_rnd.Next(50)));
            }

            string testOutput = _testObject.GetNameOnPage(testParam);

            Assert.AreEqual(expectedResult, testOutput);
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
