using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using System.Linq;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.FontTools.Tests.Utility;

namespace Unicorn.FontTools.OpenType.Tests.Unit
{
    [TestClass]
    public class HeaderTableUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;
        private HeaderTable _testObject;

        [TestInitialize]
        public void SetUpTest()
        {
            _testObject = new HeaderTable(_rnd.NextUShort(), _rnd.NextUShort(), _rnd.NextDecimal(), _rnd.NextUInt(), _rnd.NextUInt(), _rnd.NextFontProperties(),
                _rnd.NextUShort(), _rnd.NextDateTime(), _rnd.NextDateTime(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(), _rnd.NextShort(),
                _rnd.NextMacStyleProperties(), _rnd.NextUShort(), _rnd.NextFontDirectionHint(), _rnd.NextBoolean(), _rnd.NextShort());
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void HeaderTableClass_Constructor_SetsTableTagPropertyToHead()
        {
            ushort testParam0 = _rnd.NextUShort();
            ushort testParam1 = _rnd.NextUShort();
            decimal testParam2 = _rnd.NextDecimal();
            uint testParam3 = _rnd.NextUInt();
            uint testParam4 = _rnd.NextUInt();
            FontProperties testParam5 = _rnd.NextFontProperties();
            ushort testParam6 = _rnd.NextUShort();
            DateTime testParam7 = _rnd.NextDateTime();
            DateTime testParam8 = _rnd.NextDateTime();
            short testParam9 = _rnd.NextShort();
            short testParam10 = _rnd.NextShort();
            short testParam11 = _rnd.NextShort();
            short testParam12 = _rnd.NextShort();
            MacStyleProperties testParam13 = _rnd.NextMacStyleProperties();
            ushort testParam14 = _rnd.NextUShort();
            FontDirectionHint testParam15 = _rnd.NextFontDirectionHint();
            bool testParam16 = _rnd.NextBoolean();
            short testParam17 = _rnd.NextShort();

            HeaderTable testOutput = new(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8, testParam9, 
                testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17);

            Assert.AreEqual(new Tag("head"), testOutput.TableTag);
        }

        [TestMethod]
        public void HeaderTableClass_Constructor_SetsMajorVersionPropertyToValueOfFirstParameter()
        {
            ushort testParam0 = _rnd.NextUShort();
            ushort testParam1 = _rnd.NextUShort();
            decimal testParam2 = _rnd.NextDecimal();
            uint testParam3 = _rnd.NextUInt();
            uint testParam4 = _rnd.NextUInt();
            FontProperties testParam5 = _rnd.NextFontProperties();
            ushort testParam6 = _rnd.NextUShort();
            DateTime testParam7 = _rnd.NextDateTime();
            DateTime testParam8 = _rnd.NextDateTime();
            short testParam9 = _rnd.NextShort();
            short testParam10 = _rnd.NextShort();
            short testParam11 = _rnd.NextShort();
            short testParam12 = _rnd.NextShort();
            MacStyleProperties testParam13 = _rnd.NextMacStyleProperties();
            ushort testParam14 = _rnd.NextUShort();
            FontDirectionHint testParam15 = _rnd.NextFontDirectionHint();
            bool testParam16 = _rnd.NextBoolean();
            short testParam17 = _rnd.NextShort();

            HeaderTable testOutput = new(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8, testParam9, 
                testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17);

            Assert.AreEqual(testParam0, testOutput.MajorVersion);
        }

        [TestMethod]
        public void HeaderTableClass_Constructor_SetsMinorVersionPropertyToValueOfSecondParameter()
        {
            ushort testParam0 = _rnd.NextUShort();
            ushort testParam1 = _rnd.NextUShort();
            decimal testParam2 = _rnd.NextDecimal();
            uint testParam3 = _rnd.NextUInt();
            uint testParam4 = _rnd.NextUInt();
            FontProperties testParam5 = _rnd.NextFontProperties();
            ushort testParam6 = _rnd.NextUShort();
            DateTime testParam7 = _rnd.NextDateTime();
            DateTime testParam8 = _rnd.NextDateTime();
            short testParam9 = _rnd.NextShort();
            short testParam10 = _rnd.NextShort();
            short testParam11 = _rnd.NextShort();
            short testParam12 = _rnd.NextShort();
            MacStyleProperties testParam13 = _rnd.NextMacStyleProperties();
            ushort testParam14 = _rnd.NextUShort();
            FontDirectionHint testParam15 = _rnd.NextFontDirectionHint();
            bool testParam16 = _rnd.NextBoolean();
            short testParam17 = _rnd.NextShort();

            HeaderTable testOutput = new(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8, testParam9, 
                testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17);

            Assert.AreEqual(testParam1, testOutput.MinorVersion);
        }

        [TestMethod]
        public void HeaderTableClass_Constructor_SetsRevisionPropertyToValueOfThirdParameter()
        {
            ushort testParam0 = _rnd.NextUShort();
            ushort testParam1 = _rnd.NextUShort();
            decimal testParam2 = _rnd.NextDecimal();
            uint testParam3 = _rnd.NextUInt();
            uint testParam4 = _rnd.NextUInt();
            FontProperties testParam5 = _rnd.NextFontProperties();
            ushort testParam6 = _rnd.NextUShort();
            DateTime testParam7 = _rnd.NextDateTime();
            DateTime testParam8 = _rnd.NextDateTime();
            short testParam9 = _rnd.NextShort();
            short testParam10 = _rnd.NextShort();
            short testParam11 = _rnd.NextShort();
            short testParam12 = _rnd.NextShort();
            MacStyleProperties testParam13 = _rnd.NextMacStyleProperties();
            ushort testParam14 = _rnd.NextUShort();
            FontDirectionHint testParam15 = _rnd.NextFontDirectionHint();
            bool testParam16 = _rnd.NextBoolean();
            short testParam17 = _rnd.NextShort();

            HeaderTable testOutput = new(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8, testParam9, 
                testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17);

            Assert.AreEqual(testParam2, testOutput.Revision);
        }

        [TestMethod]
        public void HeaderTableClass_Constructor_SetsChecksubAdjustmentPropertyToValueOfFourthParameter()
        {
            ushort testParam0 = _rnd.NextUShort();
            ushort testParam1 = _rnd.NextUShort();
            decimal testParam2 = _rnd.NextDecimal();
            uint testParam3 = _rnd.NextUInt();
            uint testParam4 = _rnd.NextUInt();
            FontProperties testParam5 = _rnd.NextFontProperties();
            ushort testParam6 = _rnd.NextUShort();
            DateTime testParam7 = _rnd.NextDateTime();
            DateTime testParam8 = _rnd.NextDateTime();
            short testParam9 = _rnd.NextShort();
            short testParam10 = _rnd.NextShort();
            short testParam11 = _rnd.NextShort();
            short testParam12 = _rnd.NextShort();
            MacStyleProperties testParam13 = _rnd.NextMacStyleProperties();
            ushort testParam14 = _rnd.NextUShort();
            FontDirectionHint testParam15 = _rnd.NextFontDirectionHint();
            bool testParam16 = _rnd.NextBoolean();
            short testParam17 = _rnd.NextShort();

            HeaderTable testOutput = new(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8, testParam9, 
                testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17);

            Assert.AreEqual(testParam3, testOutput.ChecksumAdjustment);
        }

        [TestMethod]
        public void HeaderTableClass_Constructor_SetsMagicPropertyToValueOfFifthParameter()
        {
            ushort testParam0 = _rnd.NextUShort();
            ushort testParam1 = _rnd.NextUShort();
            decimal testParam2 = _rnd.NextDecimal();
            uint testParam3 = _rnd.NextUInt();
            uint testParam4 = _rnd.NextUInt();
            FontProperties testParam5 = _rnd.NextFontProperties();
            ushort testParam6 = _rnd.NextUShort();
            DateTime testParam7 = _rnd.NextDateTime();
            DateTime testParam8 = _rnd.NextDateTime();
            short testParam9 = _rnd.NextShort();
            short testParam10 = _rnd.NextShort();
            short testParam11 = _rnd.NextShort();
            short testParam12 = _rnd.NextShort();
            MacStyleProperties testParam13 = _rnd.NextMacStyleProperties();
            ushort testParam14 = _rnd.NextUShort();
            FontDirectionHint testParam15 = _rnd.NextFontDirectionHint();
            bool testParam16 = _rnd.NextBoolean();
            short testParam17 = _rnd.NextShort();

            HeaderTable testOutput = new(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8, testParam9, 
                testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17);

            Assert.AreEqual(testParam4, testOutput.Magic);
        }

        [TestMethod]
        public void HeaderTableClass_Constructor_SetsFlagsPropertyToValueOfSixthParameter()
        {
            ushort testParam0 = _rnd.NextUShort();
            ushort testParam1 = _rnd.NextUShort();
            decimal testParam2 = _rnd.NextDecimal();
            uint testParam3 = _rnd.NextUInt();
            uint testParam4 = _rnd.NextUInt();
            FontProperties testParam5 = _rnd.NextFontProperties();
            ushort testParam6 = _rnd.NextUShort();
            DateTime testParam7 = _rnd.NextDateTime();
            DateTime testParam8 = _rnd.NextDateTime();
            short testParam9 = _rnd.NextShort();
            short testParam10 = _rnd.NextShort();
            short testParam11 = _rnd.NextShort();
            short testParam12 = _rnd.NextShort();
            MacStyleProperties testParam13 = _rnd.NextMacStyleProperties();
            ushort testParam14 = _rnd.NextUShort();
            FontDirectionHint testParam15 = _rnd.NextFontDirectionHint();
            bool testParam16 = _rnd.NextBoolean();
            short testParam17 = _rnd.NextShort();

            HeaderTable testOutput = new(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8, testParam9, 
                testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17);

            Assert.AreEqual(testParam5, testOutput.Flags);
        }

        [TestMethod]
        public void HeaderTableClass_Constructor_SetsFontUnitScalePropertyToValueOfSeventhParameter()
        {
            ushort testParam0 = _rnd.NextUShort();
            ushort testParam1 = _rnd.NextUShort();
            decimal testParam2 = _rnd.NextDecimal();
            uint testParam3 = _rnd.NextUInt();
            uint testParam4 = _rnd.NextUInt();
            FontProperties testParam5 = _rnd.NextFontProperties();
            ushort testParam6 = _rnd.NextUShort();
            DateTime testParam7 = _rnd.NextDateTime();
            DateTime testParam8 = _rnd.NextDateTime();
            short testParam9 = _rnd.NextShort();
            short testParam10 = _rnd.NextShort();
            short testParam11 = _rnd.NextShort();
            short testParam12 = _rnd.NextShort();
            MacStyleProperties testParam13 = _rnd.NextMacStyleProperties();
            ushort testParam14 = _rnd.NextUShort();
            FontDirectionHint testParam15 = _rnd.NextFontDirectionHint();
            bool testParam16 = _rnd.NextBoolean();
            short testParam17 = _rnd.NextShort();

            HeaderTable testOutput = new(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8, testParam9, 
                testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17);

            Assert.AreEqual(testParam6, testOutput.FontUnitScale);
        }

        [TestMethod]
        public void HeaderTableClass_Constructor_SetsCreatedPropertyToValueOfEighthParameter()
        {
            ushort testParam0 = _rnd.NextUShort();
            ushort testParam1 = _rnd.NextUShort();
            decimal testParam2 = _rnd.NextDecimal();
            uint testParam3 = _rnd.NextUInt();
            uint testParam4 = _rnd.NextUInt();
            FontProperties testParam5 = _rnd.NextFontProperties();
            ushort testParam6 = _rnd.NextUShort();
            DateTime testParam7 = _rnd.NextDateTime();
            DateTime testParam8 = _rnd.NextDateTime();
            short testParam9 = _rnd.NextShort();
            short testParam10 = _rnd.NextShort();
            short testParam11 = _rnd.NextShort();
            short testParam12 = _rnd.NextShort();
            MacStyleProperties testParam13 = _rnd.NextMacStyleProperties();
            ushort testParam14 = _rnd.NextUShort();
            FontDirectionHint testParam15 = _rnd.NextFontDirectionHint();
            bool testParam16 = _rnd.NextBoolean();
            short testParam17 = _rnd.NextShort();

            HeaderTable testOutput = new(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8, testParam9, 
                testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17);

            Assert.AreEqual(testParam7, testOutput.Created);
        }

        [TestMethod]
        public void HeaderTableClass_Constructor_SetsModifiedPropertyToValueOfNinthParameter()
        {
            ushort testParam0 = _rnd.NextUShort();
            ushort testParam1 = _rnd.NextUShort();
            decimal testParam2 = _rnd.NextDecimal();
            uint testParam3 = _rnd.NextUInt();
            uint testParam4 = _rnd.NextUInt();
            FontProperties testParam5 = _rnd.NextFontProperties();
            ushort testParam6 = _rnd.NextUShort();
            DateTime testParam7 = _rnd.NextDateTime();
            DateTime testParam8 = _rnd.NextDateTime();
            short testParam9 = _rnd.NextShort();
            short testParam10 = _rnd.NextShort();
            short testParam11 = _rnd.NextShort();
            short testParam12 = _rnd.NextShort();
            MacStyleProperties testParam13 = _rnd.NextMacStyleProperties();
            ushort testParam14 = _rnd.NextUShort();
            FontDirectionHint testParam15 = _rnd.NextFontDirectionHint();
            bool testParam16 = _rnd.NextBoolean();
            short testParam17 = _rnd.NextShort();

            HeaderTable testOutput = new(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8, testParam9, 
                testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17);

            Assert.AreEqual(testParam8, testOutput.Modified);
        }

        [TestMethod]
        public void HeaderTableClass_Constructor_SetsXMinPropertyToValueOfTenthParameter()
        {
            ushort testParam0 = _rnd.NextUShort();
            ushort testParam1 = _rnd.NextUShort();
            decimal testParam2 = _rnd.NextDecimal();
            uint testParam3 = _rnd.NextUInt();
            uint testParam4 = _rnd.NextUInt();
            FontProperties testParam5 = _rnd.NextFontProperties();
            ushort testParam6 = _rnd.NextUShort();
            DateTime testParam7 = _rnd.NextDateTime();
            DateTime testParam8 = _rnd.NextDateTime();
            short testParam9 = _rnd.NextShort();
            short testParam10 = _rnd.NextShort();
            short testParam11 = _rnd.NextShort();
            short testParam12 = _rnd.NextShort();
            MacStyleProperties testParam13 = _rnd.NextMacStyleProperties();
            ushort testParam14 = _rnd.NextUShort();
            FontDirectionHint testParam15 = _rnd.NextFontDirectionHint();
            bool testParam16 = _rnd.NextBoolean();
            short testParam17 = _rnd.NextShort();

            HeaderTable testOutput = new(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8, testParam9, 
                testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17);

            Assert.AreEqual(testParam9, testOutput.XMin);
        }

        [TestMethod]
        public void HeaderTableClass_Constructor_SetsYMinPropertyToValueOfEleventhParameter()
        {
            ushort testParam0 = _rnd.NextUShort();
            ushort testParam1 = _rnd.NextUShort();
            decimal testParam2 = _rnd.NextDecimal();
            uint testParam3 = _rnd.NextUInt();
            uint testParam4 = _rnd.NextUInt();
            FontProperties testParam5 = _rnd.NextFontProperties();
            ushort testParam6 = _rnd.NextUShort();
            DateTime testParam7 = _rnd.NextDateTime();
            DateTime testParam8 = _rnd.NextDateTime();
            short testParam9 = _rnd.NextShort();
            short testParam10 = _rnd.NextShort();
            short testParam11 = _rnd.NextShort();
            short testParam12 = _rnd.NextShort();
            MacStyleProperties testParam13 = _rnd.NextMacStyleProperties();
            ushort testParam14 = _rnd.NextUShort();
            FontDirectionHint testParam15 = _rnd.NextFontDirectionHint();
            bool testParam16 = _rnd.NextBoolean();
            short testParam17 = _rnd.NextShort();

            HeaderTable testOutput = new(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8, testParam9, 
                testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17);

            Assert.AreEqual(testParam10, testOutput.YMin);
        }

        [TestMethod]
        public void HeaderTableClass_Constructor_SetsXMaxPropertyToValueOfTwelfthParameter()
        {
            ushort testParam0 = _rnd.NextUShort();
            ushort testParam1 = _rnd.NextUShort();
            decimal testParam2 = _rnd.NextDecimal();
            uint testParam3 = _rnd.NextUInt();
            uint testParam4 = _rnd.NextUInt();
            FontProperties testParam5 = _rnd.NextFontProperties();
            ushort testParam6 = _rnd.NextUShort();
            DateTime testParam7 = _rnd.NextDateTime();
            DateTime testParam8 = _rnd.NextDateTime();
            short testParam9 = _rnd.NextShort();
            short testParam10 = _rnd.NextShort();
            short testParam11 = _rnd.NextShort();
            short testParam12 = _rnd.NextShort();
            MacStyleProperties testParam13 = _rnd.NextMacStyleProperties();
            ushort testParam14 = _rnd.NextUShort();
            FontDirectionHint testParam15 = _rnd.NextFontDirectionHint();
            bool testParam16 = _rnd.NextBoolean();
            short testParam17 = _rnd.NextShort();

            HeaderTable testOutput = new(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8, testParam9, 
                testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17);

            Assert.AreEqual(testParam11, testOutput.XMax);
        }

        [TestMethod]
        public void HeaderTableClass_Constructor_SetsYMaxPropertyToValueOfThirteenthParameter()
        {
            ushort testParam0 = _rnd.NextUShort();
            ushort testParam1 = _rnd.NextUShort();
            decimal testParam2 = _rnd.NextDecimal();
            uint testParam3 = _rnd.NextUInt();
            uint testParam4 = _rnd.NextUInt();
            FontProperties testParam5 = _rnd.NextFontProperties();
            ushort testParam6 = _rnd.NextUShort();
            DateTime testParam7 = _rnd.NextDateTime();
            DateTime testParam8 = _rnd.NextDateTime();
            short testParam9 = _rnd.NextShort();
            short testParam10 = _rnd.NextShort();
            short testParam11 = _rnd.NextShort();
            short testParam12 = _rnd.NextShort();
            MacStyleProperties testParam13 = _rnd.NextMacStyleProperties();
            ushort testParam14 = _rnd.NextUShort();
            FontDirectionHint testParam15 = _rnd.NextFontDirectionHint();
            bool testParam16 = _rnd.NextBoolean();
            short testParam17 = _rnd.NextShort();

            HeaderTable testOutput = new(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8, testParam9, 
                testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17);

            Assert.AreEqual(testParam12, testOutput.YMax);
        }

        [TestMethod]
        public void HeaderTableClass_Constructor_SetsStyleFlagsPropertyToValueOfFourteenthParameter()
        {
            ushort testParam0 = _rnd.NextUShort();
            ushort testParam1 = _rnd.NextUShort();
            decimal testParam2 = _rnd.NextDecimal();
            uint testParam3 = _rnd.NextUInt();
            uint testParam4 = _rnd.NextUInt();
            FontProperties testParam5 = _rnd.NextFontProperties();
            ushort testParam6 = _rnd.NextUShort();
            DateTime testParam7 = _rnd.NextDateTime();
            DateTime testParam8 = _rnd.NextDateTime();
            short testParam9 = _rnd.NextShort();
            short testParam10 = _rnd.NextShort();
            short testParam11 = _rnd.NextShort();
            short testParam12 = _rnd.NextShort();
            MacStyleProperties testParam13 = _rnd.NextMacStyleProperties();
            ushort testParam14 = _rnd.NextUShort();
            FontDirectionHint testParam15 = _rnd.NextFontDirectionHint();
            bool testParam16 = _rnd.NextBoolean();
            short testParam17 = _rnd.NextShort();

            HeaderTable testOutput = new(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8, testParam9, 
                testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17);

            Assert.AreEqual(testParam13, testOutput.StyleFlags);
        }

        [TestMethod]
        public void HeaderTableClass_Constructor_SetsSmallestReadablePixelSizePropertyToValueOfFifteenthParameter()
        {
            ushort testParam0 = _rnd.NextUShort();
            ushort testParam1 = _rnd.NextUShort();
            decimal testParam2 = _rnd.NextDecimal();
            uint testParam3 = _rnd.NextUInt();
            uint testParam4 = _rnd.NextUInt();
            FontProperties testParam5 = _rnd.NextFontProperties();
            ushort testParam6 = _rnd.NextUShort();
            DateTime testParam7 = _rnd.NextDateTime();
            DateTime testParam8 = _rnd.NextDateTime();
            short testParam9 = _rnd.NextShort();
            short testParam10 = _rnd.NextShort();
            short testParam11 = _rnd.NextShort();
            short testParam12 = _rnd.NextShort();
            MacStyleProperties testParam13 = _rnd.NextMacStyleProperties();
            ushort testParam14 = _rnd.NextUShort();
            FontDirectionHint testParam15 = _rnd.NextFontDirectionHint();
            bool testParam16 = _rnd.NextBoolean();
            short testParam17 = _rnd.NextShort();

            HeaderTable testOutput = new(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8, testParam9, 
                testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17);

            Assert.AreEqual(testParam14, testOutput.SmallestReadablePixelSize);
        }

        [TestMethod]
        public void HeaderTableClass_Constructor_SetsDirectionHintPropertyToValueOfSixteenthParameter()
        {
            ushort testParam0 = _rnd.NextUShort();
            ushort testParam1 = _rnd.NextUShort();
            decimal testParam2 = _rnd.NextDecimal();
            uint testParam3 = _rnd.NextUInt();
            uint testParam4 = _rnd.NextUInt();
            FontProperties testParam5 = _rnd.NextFontProperties();
            ushort testParam6 = _rnd.NextUShort();
            DateTime testParam7 = _rnd.NextDateTime();
            DateTime testParam8 = _rnd.NextDateTime();
            short testParam9 = _rnd.NextShort();
            short testParam10 = _rnd.NextShort();
            short testParam11 = _rnd.NextShort();
            short testParam12 = _rnd.NextShort();
            MacStyleProperties testParam13 = _rnd.NextMacStyleProperties();
            ushort testParam14 = _rnd.NextUShort();
            FontDirectionHint testParam15 = _rnd.NextFontDirectionHint();
            bool testParam16 = _rnd.NextBoolean();
            short testParam17 = _rnd.NextShort();

            HeaderTable testOutput = new(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8, testParam9, 
                testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17);

            Assert.AreEqual(testParam15, testOutput.DirectionHint);
        }

        [TestMethod]
        public void HeaderTableClass_Constructor_SetsUseLongOffsetsPropertyToValueOfSeventeenthParameter()
        {
            ushort testParam0 = _rnd.NextUShort();
            ushort testParam1 = _rnd.NextUShort();
            decimal testParam2 = _rnd.NextDecimal();
            uint testParam3 = _rnd.NextUInt();
            uint testParam4 = _rnd.NextUInt();
            FontProperties testParam5 = _rnd.NextFontProperties();
            ushort testParam6 = _rnd.NextUShort();
            DateTime testParam7 = _rnd.NextDateTime();
            DateTime testParam8 = _rnd.NextDateTime();
            short testParam9 = _rnd.NextShort();
            short testParam10 = _rnd.NextShort();
            short testParam11 = _rnd.NextShort();
            short testParam12 = _rnd.NextShort();
            MacStyleProperties testParam13 = _rnd.NextMacStyleProperties();
            ushort testParam14 = _rnd.NextUShort();
            FontDirectionHint testParam15 = _rnd.NextFontDirectionHint();
            bool testParam16 = _rnd.NextBoolean();
            short testParam17 = _rnd.NextShort();

            HeaderTable testOutput = new(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8, testParam9, 
                testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17);

            Assert.AreEqual(testParam16, testOutput.UseLongOffsets);
        }

        [TestMethod]
        public void HeaderTableClass_Constructor_SetsGlyphDataFormatPropertyToValueOfEighteenthParameter()
        {
            ushort testParam0 = _rnd.NextUShort();
            ushort testParam1 = _rnd.NextUShort();
            decimal testParam2 = _rnd.NextDecimal();
            uint testParam3 = _rnd.NextUInt();
            uint testParam4 = _rnd.NextUInt();
            FontProperties testParam5 = _rnd.NextFontProperties();
            ushort testParam6 = _rnd.NextUShort();
            DateTime testParam7 = _rnd.NextDateTime();
            DateTime testParam8 = _rnd.NextDateTime();
            short testParam9 = _rnd.NextShort();
            short testParam10 = _rnd.NextShort();
            short testParam11 = _rnd.NextShort();
            short testParam12 = _rnd.NextShort();
            MacStyleProperties testParam13 = _rnd.NextMacStyleProperties();
            ushort testParam14 = _rnd.NextUShort();
            FontDirectionHint testParam15 = _rnd.NextFontDirectionHint();
            bool testParam16 = _rnd.NextBoolean();
            short testParam17 = _rnd.NextShort();

            HeaderTable testOutput = new(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8, testParam9, 
                testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17);

            Assert.AreEqual(testParam17, testOutput.GlyphDataFormat);
        }

        [TestMethod]
        public void HeaderTableClass_DumpMethod_ReturnsNonNullObject()
        {
            var testOutput = _testObject.Dump();

            Assert.IsNotNull(testOutput);
        }

        [TestMethod]
        public void HeaderTableClass_DumpMethod_ReturnsObjectWithInfoPropertyContainingNameOfTable()
        {
            var testOutput = _testObject.Dump();

            Assert.IsTrue(testOutput.Info.Contains("head", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void HeaderTableClass_DumpMethod_ReturnsObjectWithHeaderWithTwoColumns()
        {
            var testOutput = _testObject.Dump();

            Assert.AreEqual(2, testOutput.BlockHeader.Count);
        }

        [TestMethod]
        public void HeaderTableClass_DumpMethod_ReturnsObjectWithHeaderWithFirstColumnHeaderTextEqualToField()
        {
            var testOutput = _testObject.Dump();

            Assert.AreEqual("Field", testOutput.BlockHeader[0].HeaderText);
        }

        [TestMethod]
        public void HeaderTableClass_DumpMethod_ReturnsObjectWithHeaderWithSecondColumnHeaderTextEqualToValue()
        {
            var testOutput = _testObject.Dump();

            Assert.AreEqual("Value", testOutput.BlockHeader[1].HeaderText);
        }

        [TestMethod]
        public void HeaderTableClass_DumpMethod_ReturnsObjectWithDataContainingCorrectMajorVersion()
        {
            var testOutput = _testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "MajorVersion");
            Assert.AreEqual(_testObject.MajorVersion.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void HeaderTableClass_DumpMethod_ReturnsObjectWithDataContainingCorrectMinorVersion()
        {
            var testOutput = _testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "MinorVersion");
            Assert.AreEqual(_testObject.MinorVersion.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void HeaderTableClass_DumpMethod_ReturnsObjectWithDataContainingCorrectRevision()
        {
            var testOutput = _testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "Revision");
            Assert.AreEqual(_testObject.Revision.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void HeaderTableClass_DumpMethod_ReturnsObjectWithDataContainingCorrectChecksumAdjustment()
        {
            var testOutput = _testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "ChecksumAdjustment");
            Assert.AreEqual(_testObject.ChecksumAdjustment.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void HeaderTableClass_DumpMethod_ReturnsObjectWithDataContainingCorrectMagic()
        {
            var testOutput = _testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "Magic");
            Assert.AreEqual(_testObject.Magic.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void HeaderTableClass_DumpMethod_ReturnsObjectWithDataContainingCorrectFlags()
        {
            var testOutput = _testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "Flags");
            Assert.AreEqual(_testObject.Flags.ToString(), testRecord[1]);
        }

        [TestMethod]
        public void HeaderTableClass_DumpMethod_ReturnsObjectWithDataContainingCorrectFontUnitScale()
        {
            var testOutput = _testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "FontUnitScale");
            Assert.AreEqual(_testObject.FontUnitScale.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void HeaderTableClass_DumpMethod_ReturnsObjectWithDataContainingCorrectCreated()
        {
            var testOutput = _testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "Created");
            Assert.AreEqual(_testObject.Created.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void HeaderTableClass_DumpMethod_ReturnsObjectWithDataContainingCorrectModified()
        {
            var testOutput = _testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "Modified");
            Assert.AreEqual(_testObject.Modified.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void HeaderTableClass_DumpMethod_ReturnsObjectWithDataContainingCorrectXMin()
        {
            var testOutput = _testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "XMin");
            Assert.AreEqual(_testObject.XMin.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void HeaderTableClass_DumpMethod_ReturnsObjectWithDataContainingCorrectXMax()
        {
            var testOutput = _testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "XMax");
            Assert.AreEqual(_testObject.XMax.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void HeaderTableClass_DumpMethod_ReturnsObjectWithDataContainingCorrectYMin()
        {
            var testOutput = _testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "YMin");
            Assert.AreEqual(_testObject.YMin.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void HeaderTableClass_DumpMethod_ReturnsObjectWithDataContainingCorrectYMax()
        {
            var testOutput = _testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "YMax");
            Assert.AreEqual(_testObject.YMax.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void HeaderTableClass_DumpMethod_ReturnsObjectWithDataContainingCorrectStyleFlags()
        {
            var testOutput = _testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "StyleFlags");
            Assert.AreEqual(_testObject.StyleFlags.ToString(), testRecord[1]);
        }

        [TestMethod]
        public void HeaderTableClass_DumpMethod_ReturnsObjectWithDataContainingCorrectSmallestReadablePixelSize()
        {
            var testOutput = _testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "SmallestReadablePixelSize");
            Assert.AreEqual(_testObject.SmallestReadablePixelSize.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void HeaderTableClass_DumpMethod_ReturnsObjectWithDataContainingCorrectDirectionHint()
        {
            var testOutput = _testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "DirectionHint");
            Assert.AreEqual(_testObject.DirectionHint.ToString(), testRecord[1]);
        }

        [TestMethod]
        public void HeaderTableClass_DumpMethod_ReturnsObjectWithDataContainingCorrectUseLongOffsets()
        {
            var testOutput = _testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "UseLongOffsets");
            Assert.AreEqual(_testObject.UseLongOffsets.ToString(), testRecord[1]);
        }

        [TestMethod]
        public void HeaderTableClass_DumpMethod_ReturnsObjectWithDataContainingCorrectGlyphDataFormat()
        {
            var testOutput = _testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "GlyphDataFormat");
            Assert.AreEqual(_testObject.GlyphDataFormat.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void HeaderTableClass_DumpMethod_ReturnsObjectWithNoNestedBlocks()
        {
            var testOutput = _testObject.Dump();

            Assert.AreEqual(0, testOutput.NestedData.Count());
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
