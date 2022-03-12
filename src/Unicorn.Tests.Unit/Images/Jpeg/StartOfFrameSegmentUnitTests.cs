using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.Images.Jpeg;

namespace Unicorn.Tests.Unit.Images.Jpeg
{
    [TestClass]
    public class StartOfFrameSegmentUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores
#pragma warning disable CA5394 // Do not use insecure randomness

        [TestMethod]
        public void StartOfFrameSegmentClass_Constructor_SetsStartOffsetPropertyToValueOfFirstParameter()
        {
            long testParam0 = _rnd.NextLong();
            int testParam1 = _rnd.Next();

            StartOfFrameSegment testOutput = new(testParam0, testParam1);

            Assert.AreEqual(testParam0, testOutput.StartOffset);
        }

        [TestMethod]
        public void StartOfFrameSegmentClass_Constructor_SetsLengthPropertyToValueOfSecondParameter()
        {
            long testParam0 = _rnd.NextLong();
            int testParam1 = _rnd.Next();

            StartOfFrameSegment testOutput = new(testParam0, testParam1);

            Assert.AreEqual(testParam1, testOutput.Length);
        }

        [TestMethod]
        public void StartOfFrameSegmentClass_Constructor_SetsSegmentTypePropertyToStartOfFrame()
        {
            long testParam0 = _rnd.NextLong();
            int testParam1 = _rnd.Next();

            StartOfFrameSegment testOutput = new(testParam0, testParam1);

            Assert.AreEqual(JpegDataSegmentType.StartOfFrame, testOutput.SegmentType);
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
