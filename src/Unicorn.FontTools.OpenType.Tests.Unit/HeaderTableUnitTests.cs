using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.FontTools.OpenType.Tests.Utility.Extensions;

namespace Unicorn.FontTools.OpenType.Tests.Unit
{
    [TestClass]
    public class HeaderTableUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void HeaderTableClass_Constructor_SetsTableTagPropertyToHead()
        {
            ushort testParam0 = _rnd.NextUShort();
            ushort testParam1 = _rnd.NextUShort();
            decimal testParam2 = _rnd.NextDecimal();
            uint testParam3 = _rnd.NextUInt();
            uint testParam4 = _rnd.NextUInt();
            FontProperties testParam5 = _rnd.NextFontFlags();
            ushort testParam6 = _rnd.NextUShort();
            DateTime testParam7 = _rnd.NextDateTime();
            DateTime testParam8 = _rnd.NextDateTime();
            short testParam9 = _rnd.NextShort();
            short testParam10 = _rnd.NextShort();
            short testParam11 = _rnd.NextShort();
            short testParam12 = _rnd.NextShort();
            MacStyleProperties testParam13 = _rnd.NextMacStyleFlags();
            ushort testParam14 = _rnd.NextUShort();
            FontDirectionHint testParam15 = _rnd.NextFontDirectionHint();
            bool testParam16 = _rnd.NextBoolean();
            short testParam17 = _rnd.NextShort();

            HeaderTable testOutput = new HeaderTable(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8,
                testParam9, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17);

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
            FontProperties testParam5 = _rnd.NextFontFlags();
            ushort testParam6 = _rnd.NextUShort();
            DateTime testParam7 = _rnd.NextDateTime();
            DateTime testParam8 = _rnd.NextDateTime();
            short testParam9 = _rnd.NextShort();
            short testParam10 = _rnd.NextShort();
            short testParam11 = _rnd.NextShort();
            short testParam12 = _rnd.NextShort();
            MacStyleProperties testParam13 = _rnd.NextMacStyleFlags();
            ushort testParam14 = _rnd.NextUShort();
            FontDirectionHint testParam15 = _rnd.NextFontDirectionHint();
            bool testParam16 = _rnd.NextBoolean();
            short testParam17 = _rnd.NextShort();

            HeaderTable testOutput = new HeaderTable(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8,
                testParam9, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17);

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
            FontProperties testParam5 = _rnd.NextFontFlags();
            ushort testParam6 = _rnd.NextUShort();
            DateTime testParam7 = _rnd.NextDateTime();
            DateTime testParam8 = _rnd.NextDateTime();
            short testParam9 = _rnd.NextShort();
            short testParam10 = _rnd.NextShort();
            short testParam11 = _rnd.NextShort();
            short testParam12 = _rnd.NextShort();
            MacStyleProperties testParam13 = _rnd.NextMacStyleFlags();
            ushort testParam14 = _rnd.NextUShort();
            FontDirectionHint testParam15 = _rnd.NextFontDirectionHint();
            bool testParam16 = _rnd.NextBoolean();
            short testParam17 = _rnd.NextShort();

            HeaderTable testOutput = new HeaderTable(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8,
                testParam9, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17);

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
            FontProperties testParam5 = _rnd.NextFontFlags();
            ushort testParam6 = _rnd.NextUShort();
            DateTime testParam7 = _rnd.NextDateTime();
            DateTime testParam8 = _rnd.NextDateTime();
            short testParam9 = _rnd.NextShort();
            short testParam10 = _rnd.NextShort();
            short testParam11 = _rnd.NextShort();
            short testParam12 = _rnd.NextShort();
            MacStyleProperties testParam13 = _rnd.NextMacStyleFlags();
            ushort testParam14 = _rnd.NextUShort();
            FontDirectionHint testParam15 = _rnd.NextFontDirectionHint();
            bool testParam16 = _rnd.NextBoolean();
            short testParam17 = _rnd.NextShort();

            HeaderTable testOutput = new HeaderTable(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8,
                testParam9, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17);

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
            FontProperties testParam5 = _rnd.NextFontFlags();
            ushort testParam6 = _rnd.NextUShort();
            DateTime testParam7 = _rnd.NextDateTime();
            DateTime testParam8 = _rnd.NextDateTime();
            short testParam9 = _rnd.NextShort();
            short testParam10 = _rnd.NextShort();
            short testParam11 = _rnd.NextShort();
            short testParam12 = _rnd.NextShort();
            MacStyleProperties testParam13 = _rnd.NextMacStyleFlags();
            ushort testParam14 = _rnd.NextUShort();
            FontDirectionHint testParam15 = _rnd.NextFontDirectionHint();
            bool testParam16 = _rnd.NextBoolean();
            short testParam17 = _rnd.NextShort();

            HeaderTable testOutput = new HeaderTable(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8,
                testParam9, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17);

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
            FontProperties testParam5 = _rnd.NextFontFlags();
            ushort testParam6 = _rnd.NextUShort();
            DateTime testParam7 = _rnd.NextDateTime();
            DateTime testParam8 = _rnd.NextDateTime();
            short testParam9 = _rnd.NextShort();
            short testParam10 = _rnd.NextShort();
            short testParam11 = _rnd.NextShort();
            short testParam12 = _rnd.NextShort();
            MacStyleProperties testParam13 = _rnd.NextMacStyleFlags();
            ushort testParam14 = _rnd.NextUShort();
            FontDirectionHint testParam15 = _rnd.NextFontDirectionHint();
            bool testParam16 = _rnd.NextBoolean();
            short testParam17 = _rnd.NextShort();

            HeaderTable testOutput = new HeaderTable(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8,
                testParam9, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17);

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
            FontProperties testParam5 = _rnd.NextFontFlags();
            ushort testParam6 = _rnd.NextUShort();
            DateTime testParam7 = _rnd.NextDateTime();
            DateTime testParam8 = _rnd.NextDateTime();
            short testParam9 = _rnd.NextShort();
            short testParam10 = _rnd.NextShort();
            short testParam11 = _rnd.NextShort();
            short testParam12 = _rnd.NextShort();
            MacStyleProperties testParam13 = _rnd.NextMacStyleFlags();
            ushort testParam14 = _rnd.NextUShort();
            FontDirectionHint testParam15 = _rnd.NextFontDirectionHint();
            bool testParam16 = _rnd.NextBoolean();
            short testParam17 = _rnd.NextShort();

            HeaderTable testOutput = new HeaderTable(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8,
                testParam9, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17);

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
            FontProperties testParam5 = _rnd.NextFontFlags();
            ushort testParam6 = _rnd.NextUShort();
            DateTime testParam7 = _rnd.NextDateTime();
            DateTime testParam8 = _rnd.NextDateTime();
            short testParam9 = _rnd.NextShort();
            short testParam10 = _rnd.NextShort();
            short testParam11 = _rnd.NextShort();
            short testParam12 = _rnd.NextShort();
            MacStyleProperties testParam13 = _rnd.NextMacStyleFlags();
            ushort testParam14 = _rnd.NextUShort();
            FontDirectionHint testParam15 = _rnd.NextFontDirectionHint();
            bool testParam16 = _rnd.NextBoolean();
            short testParam17 = _rnd.NextShort();

            HeaderTable testOutput = new HeaderTable(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8,
                testParam9, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17);

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
            FontProperties testParam5 = _rnd.NextFontFlags();
            ushort testParam6 = _rnd.NextUShort();
            DateTime testParam7 = _rnd.NextDateTime();
            DateTime testParam8 = _rnd.NextDateTime();
            short testParam9 = _rnd.NextShort();
            short testParam10 = _rnd.NextShort();
            short testParam11 = _rnd.NextShort();
            short testParam12 = _rnd.NextShort();
            MacStyleProperties testParam13 = _rnd.NextMacStyleFlags();
            ushort testParam14 = _rnd.NextUShort();
            FontDirectionHint testParam15 = _rnd.NextFontDirectionHint();
            bool testParam16 = _rnd.NextBoolean();
            short testParam17 = _rnd.NextShort();

            HeaderTable testOutput = new HeaderTable(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8,
                testParam9, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17);

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
            FontProperties testParam5 = _rnd.NextFontFlags();
            ushort testParam6 = _rnd.NextUShort();
            DateTime testParam7 = _rnd.NextDateTime();
            DateTime testParam8 = _rnd.NextDateTime();
            short testParam9 = _rnd.NextShort();
            short testParam10 = _rnd.NextShort();
            short testParam11 = _rnd.NextShort();
            short testParam12 = _rnd.NextShort();
            MacStyleProperties testParam13 = _rnd.NextMacStyleFlags();
            ushort testParam14 = _rnd.NextUShort();
            FontDirectionHint testParam15 = _rnd.NextFontDirectionHint();
            bool testParam16 = _rnd.NextBoolean();
            short testParam17 = _rnd.NextShort();

            HeaderTable testOutput = new HeaderTable(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8,
                testParam9, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17);

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
            FontProperties testParam5 = _rnd.NextFontFlags();
            ushort testParam6 = _rnd.NextUShort();
            DateTime testParam7 = _rnd.NextDateTime();
            DateTime testParam8 = _rnd.NextDateTime();
            short testParam9 = _rnd.NextShort();
            short testParam10 = _rnd.NextShort();
            short testParam11 = _rnd.NextShort();
            short testParam12 = _rnd.NextShort();
            MacStyleProperties testParam13 = _rnd.NextMacStyleFlags();
            ushort testParam14 = _rnd.NextUShort();
            FontDirectionHint testParam15 = _rnd.NextFontDirectionHint();
            bool testParam16 = _rnd.NextBoolean();
            short testParam17 = _rnd.NextShort();

            HeaderTable testOutput = new HeaderTable(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8,
                testParam9, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17);

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
            FontProperties testParam5 = _rnd.NextFontFlags();
            ushort testParam6 = _rnd.NextUShort();
            DateTime testParam7 = _rnd.NextDateTime();
            DateTime testParam8 = _rnd.NextDateTime();
            short testParam9 = _rnd.NextShort();
            short testParam10 = _rnd.NextShort();
            short testParam11 = _rnd.NextShort();
            short testParam12 = _rnd.NextShort();
            MacStyleProperties testParam13 = _rnd.NextMacStyleFlags();
            ushort testParam14 = _rnd.NextUShort();
            FontDirectionHint testParam15 = _rnd.NextFontDirectionHint();
            bool testParam16 = _rnd.NextBoolean();
            short testParam17 = _rnd.NextShort();

            HeaderTable testOutput = new HeaderTable(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8,
                testParam9, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17);

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
            FontProperties testParam5 = _rnd.NextFontFlags();
            ushort testParam6 = _rnd.NextUShort();
            DateTime testParam7 = _rnd.NextDateTime();
            DateTime testParam8 = _rnd.NextDateTime();
            short testParam9 = _rnd.NextShort();
            short testParam10 = _rnd.NextShort();
            short testParam11 = _rnd.NextShort();
            short testParam12 = _rnd.NextShort();
            MacStyleProperties testParam13 = _rnd.NextMacStyleFlags();
            ushort testParam14 = _rnd.NextUShort();
            FontDirectionHint testParam15 = _rnd.NextFontDirectionHint();
            bool testParam16 = _rnd.NextBoolean();
            short testParam17 = _rnd.NextShort();

            HeaderTable testOutput = new HeaderTable(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8,
                testParam9, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17);

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
            FontProperties testParam5 = _rnd.NextFontFlags();
            ushort testParam6 = _rnd.NextUShort();
            DateTime testParam7 = _rnd.NextDateTime();
            DateTime testParam8 = _rnd.NextDateTime();
            short testParam9 = _rnd.NextShort();
            short testParam10 = _rnd.NextShort();
            short testParam11 = _rnd.NextShort();
            short testParam12 = _rnd.NextShort();
            MacStyleProperties testParam13 = _rnd.NextMacStyleFlags();
            ushort testParam14 = _rnd.NextUShort();
            FontDirectionHint testParam15 = _rnd.NextFontDirectionHint();
            bool testParam16 = _rnd.NextBoolean();
            short testParam17 = _rnd.NextShort();

            HeaderTable testOutput = new HeaderTable(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8,
                testParam9, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17);

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
            FontProperties testParam5 = _rnd.NextFontFlags();
            ushort testParam6 = _rnd.NextUShort();
            DateTime testParam7 = _rnd.NextDateTime();
            DateTime testParam8 = _rnd.NextDateTime();
            short testParam9 = _rnd.NextShort();
            short testParam10 = _rnd.NextShort();
            short testParam11 = _rnd.NextShort();
            short testParam12 = _rnd.NextShort();
            MacStyleProperties testParam13 = _rnd.NextMacStyleFlags();
            ushort testParam14 = _rnd.NextUShort();
            FontDirectionHint testParam15 = _rnd.NextFontDirectionHint();
            bool testParam16 = _rnd.NextBoolean();
            short testParam17 = _rnd.NextShort();

            HeaderTable testOutput = new HeaderTable(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8,
                testParam9, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17);

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
            FontProperties testParam5 = _rnd.NextFontFlags();
            ushort testParam6 = _rnd.NextUShort();
            DateTime testParam7 = _rnd.NextDateTime();
            DateTime testParam8 = _rnd.NextDateTime();
            short testParam9 = _rnd.NextShort();
            short testParam10 = _rnd.NextShort();
            short testParam11 = _rnd.NextShort();
            short testParam12 = _rnd.NextShort();
            MacStyleProperties testParam13 = _rnd.NextMacStyleFlags();
            ushort testParam14 = _rnd.NextUShort();
            FontDirectionHint testParam15 = _rnd.NextFontDirectionHint();
            bool testParam16 = _rnd.NextBoolean();
            short testParam17 = _rnd.NextShort();

            HeaderTable testOutput = new HeaderTable(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8,
                testParam9, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17);

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
            FontProperties testParam5 = _rnd.NextFontFlags();
            ushort testParam6 = _rnd.NextUShort();
            DateTime testParam7 = _rnd.NextDateTime();
            DateTime testParam8 = _rnd.NextDateTime();
            short testParam9 = _rnd.NextShort();
            short testParam10 = _rnd.NextShort();
            short testParam11 = _rnd.NextShort();
            short testParam12 = _rnd.NextShort();
            MacStyleProperties testParam13 = _rnd.NextMacStyleFlags();
            ushort testParam14 = _rnd.NextUShort();
            FontDirectionHint testParam15 = _rnd.NextFontDirectionHint();
            bool testParam16 = _rnd.NextBoolean();
            short testParam17 = _rnd.NextShort();

            HeaderTable testOutput = new HeaderTable(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8,
                testParam9, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17);

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
            FontProperties testParam5 = _rnd.NextFontFlags();
            ushort testParam6 = _rnd.NextUShort();
            DateTime testParam7 = _rnd.NextDateTime();
            DateTime testParam8 = _rnd.NextDateTime();
            short testParam9 = _rnd.NextShort();
            short testParam10 = _rnd.NextShort();
            short testParam11 = _rnd.NextShort();
            short testParam12 = _rnd.NextShort();
            MacStyleProperties testParam13 = _rnd.NextMacStyleFlags();
            ushort testParam14 = _rnd.NextUShort();
            FontDirectionHint testParam15 = _rnd.NextFontDirectionHint();
            bool testParam16 = _rnd.NextBoolean();
            short testParam17 = _rnd.NextShort();

            HeaderTable testOutput = new HeaderTable(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8,
                testParam9, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17);

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
            FontProperties testParam5 = _rnd.NextFontFlags();
            ushort testParam6 = _rnd.NextUShort();
            DateTime testParam7 = _rnd.NextDateTime();
            DateTime testParam8 = _rnd.NextDateTime();
            short testParam9 = _rnd.NextShort();
            short testParam10 = _rnd.NextShort();
            short testParam11 = _rnd.NextShort();
            short testParam12 = _rnd.NextShort();
            MacStyleProperties testParam13 = _rnd.NextMacStyleFlags();
            ushort testParam14 = _rnd.NextUShort();
            FontDirectionHint testParam15 = _rnd.NextFontDirectionHint();
            bool testParam16 = _rnd.NextBoolean();
            short testParam17 = _rnd.NextShort();

            HeaderTable testOutput = new HeaderTable(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8,
                testParam9, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17);

            Assert.AreEqual(testParam17, testOutput.GlyphDataFormat);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
