using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.Images.Jpeg;

namespace Unicorn.Tests.Unit.Images.Jpeg
{
    [TestClass]
    public class JfifSegmentUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores
#pragma warning disable CA5394 // Do not use insecure randomness

        [TestMethod]
        public void JfifSegmentClass_Constructor_SetsStartOffsetPropertyToFirstParameter()
        {
            long testParam0 = _rnd.NextLong();
            int testParam1 = _rnd.Next();

            JfifSegment testOutput = new(testParam0, testParam1);

            Assert.AreEqual(testParam0, testOutput.StartOffset);
        }

        [TestMethod]
        public void JfifSegmentClass_Constructor_SetsLengthPropertyToSecondParameter()
        {
            long testParam0 = _rnd.NextLong();
            int testParam1 = _rnd.Next();

            JfifSegment testOutput = new(testParam0, testParam1);

            Assert.AreEqual(testParam1, testOutput.Length);
        }

        [TestMethod]
        public void JfifSegmentClass_Constructor_SetsSegmentTypePropertyToJfif()
        {
            long testParam0 = _rnd.NextLong();
            int testParam1 = _rnd.Next();

            JfifSegment testOutput = new(testParam0, testParam1);

            Assert.AreEqual(JpegDataSegmentType.Jfif, testOutput.SegmentType);
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
