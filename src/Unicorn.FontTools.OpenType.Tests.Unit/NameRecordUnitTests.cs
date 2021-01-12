using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.FontTools.OpenType.Tests.Utility.Extensions;

namespace Unicorn.FontTools.OpenType.Tests.Unit
{
    [TestClass]
    public class NameRecordUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void NameRecordClass_Constructor_SetsPlatformIdPropertyToValueOfFirstParameter()
        {
            PlatformId testParam0 = _rnd.NextPlatformId();
            ushort testParam1 = _rnd.NextUShort();
            ushort testParam2 = _rnd.NextUShort();
            NameField testParam3 = _rnd.NextNameField();
            string testParam4 = _rnd.NextString(_rnd.Next(100));
            bool testParam5 = _rnd.NextBoolean();

            NameRecord testOutput = new NameRecord(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);

            Assert.AreEqual(testParam0, testOutput.PlatformId);
        }

        [TestMethod]
        public void NameRecordClass_Constructor_SetsEncodingIdPropertyToValueOfSecondParameter()
        {
            PlatformId testParam0 = _rnd.NextPlatformId();
            ushort testParam1 = _rnd.NextUShort();
            ushort testParam2 = _rnd.NextUShort();
            NameField testParam3 = _rnd.NextNameField();
            string testParam4 = _rnd.NextString(_rnd.Next(100));
            bool testParam5 = _rnd.NextBoolean();

            NameRecord testOutput = new NameRecord(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);

            Assert.AreEqual(testParam1, testOutput.EncodingId);
        }

        [TestMethod]
        public void NameRecordClass_Constructor_SetsLanguageIdPropertyToValueOfThirdParameter()
        {
            PlatformId testParam0 = _rnd.NextPlatformId();
            ushort testParam1 = _rnd.NextUShort();
            ushort testParam2 = _rnd.NextUShort();
            NameField testParam3 = _rnd.NextNameField();
            string testParam4 = _rnd.NextString(_rnd.Next(100));
            bool testParam5 = _rnd.NextBoolean();

            NameRecord testOutput = new NameRecord(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);

            Assert.AreEqual(testParam2, testOutput.LanguageId);
        }

        [TestMethod]
        public void NameRecordClass_Constructor_SetsNameIdPropertyToValueOfFourthParameter()
        {
            PlatformId testParam0 = _rnd.NextPlatformId();
            ushort testParam1 = _rnd.NextUShort();
            ushort testParam2 = _rnd.NextUShort();
            NameField testParam3 = _rnd.NextNameField();
            string testParam4 = _rnd.NextString(_rnd.Next(100));
            bool testParam5 = _rnd.NextBoolean();

            NameRecord testOutput = new NameRecord(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);

            Assert.AreEqual(testParam3, testOutput.NameId);
        }

        [TestMethod]
        public void NameRecordClass_Constructor_SetsContentPropertyToValueOfFifthParameter()
        {
            PlatformId testParam0 = _rnd.NextPlatformId();
            ushort testParam1 = _rnd.NextUShort();
            ushort testParam2 = _rnd.NextUShort();
            NameField testParam3 = _rnd.NextNameField();
            string testParam4 = _rnd.NextString(_rnd.Next(100));
            bool testParam5 = _rnd.NextBoolean();

            NameRecord testOutput = new NameRecord(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);

            Assert.AreEqual(testParam4, testOutput.Content);
        }

        [TestMethod]
        public void NameRecordClass_Constructor_SetsFillerContentPropertyToValueOfSixthParameter()
        {
            PlatformId testParam0 = _rnd.NextPlatformId();
            ushort testParam1 = _rnd.NextUShort();
            ushort testParam2 = _rnd.NextUShort();
            NameField testParam3 = _rnd.NextNameField();
            string testParam4 = _rnd.NextString(_rnd.Next(100));
            bool testParam5 = _rnd.NextBoolean();

            NameRecord testOutput = new NameRecord(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5);

            Assert.AreEqual(testParam5, testOutput.FillerContent);
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
