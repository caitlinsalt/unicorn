using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.FontTools.OpenType.Tests.Utility.Extensions;

namespace Unicorn.FontTools.OpenType.Tests.Unit
{
    [TestClass]
    public class EncodingMapRecordUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private static readonly Encoding[] _someEncodings = new[] { Encoding.ASCII, Encoding.Unicode, Encoding.BigEndianUnicode, Encoding.UTF8 };

#pragma warning disable CA5394 // Do not use insecure randomness

        private static Encoding GetRandomEncoding()
        {
            return _someEncodings[_rnd.Next(_someEncodings.Length)];
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void EncodingMapRecord_Constructor_SetsPlatformPropertyToValueOfFirstParameter()
        {
            PlatformId testParam0 = _rnd.NextPlatformId();
            ushort testParam1 = _rnd.NextUShort();
            Encoding testParam2 = GetRandomEncoding();

            EncodingMapRecord testOutput = new EncodingMapRecord(testParam0, testParam1, testParam2);

            Assert.AreEqual(testParam0, testOutput.Platform);
        }

        [TestMethod]
        public void EncodingMapRecord_Constructor_SetsEncodingIdPropertyToValueOfSecondParameter()
        {
            PlatformId testParam0 = _rnd.NextPlatformId();
            ushort testParam1 = _rnd.NextUShort();
            Encoding testParam2 = GetRandomEncoding();

            EncodingMapRecord testOutput = new EncodingMapRecord(testParam0, testParam1, testParam2);

            Assert.AreEqual(testParam1, testOutput.EncodingId);
        }

        [TestMethod]
        public void EncodingMapRecord_Constructor_SetsEncodingPropertyToValueOfThirdParameter()
        {
            PlatformId testParam0 = _rnd.NextPlatformId();
            ushort testParam1 = _rnd.NextUShort();
            Encoding testParam2 = GetRandomEncoding();

            EncodingMapRecord testOutput = new EncodingMapRecord(testParam0, testParam1, testParam2);

            Assert.AreEqual(testParam2, testOutput.Encoding);
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
