using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.Images.Jpeg;
using Unicorn.Tests.Unit.TestHelpers;

namespace Unicorn.Tests.Unit.Images.Jpeg
{
    [TestClass]
    public class JpegDataSegmentUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores
#pragma warning disable CA5394 // Do not use insecure randomness

        [TestMethod]
        public void JpegDataSegmentClass_Constructor_SetsStartOffsetPropertyToValueOfFirstParameter()
        {
            long testParam0 = _rnd.NextLong();
            int testParam1 = _rnd.Next();
            JpegDataSegmentType testParam2 = _rnd.NextJpegDataSegmentType();

            JpegDataSegment testOutput = new(testParam0, testParam1, testParam2);

            Assert.AreEqual(testParam0, testOutput.StartOffset);
        }

        [TestMethod]
        public void JpegDataSegmentClass_Constructor_SetsLengthPropertyToValueOfSecondParameter()
        {
            long testParam0 = _rnd.NextLong();
            int testParam1 = _rnd.Next();
            JpegDataSegmentType testParam2 = _rnd.NextJpegDataSegmentType();

            JpegDataSegment testOutput = new(testParam0, testParam1, testParam2);

            Assert.AreEqual(testParam1, testOutput.Length);
        }

        [TestMethod]
        public void JpegDataSegmentClass_Constructor_SetsBlockTypePropertyToValueOfThirdParameter()
        {
            long testParam0 = _rnd.NextLong();
            int testParam1 = _rnd.Next();
            JpegDataSegmentType testParam2 = _rnd.NextJpegDataSegmentType();

            JpegDataSegment testOutput = new(testParam0, testParam1, testParam2);

            Assert.AreEqual(testParam2, testOutput.SegmentType);
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
