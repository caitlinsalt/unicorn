using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.FontTools.OpenType.Tests.Utility.Extensions;

namespace Unicorn.FontTools.OpenType.Tests.Unit
{
    [TestClass]
    public class OffsetTableUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void OffsetTableClass_Constructor_SetsFontKindPropertyToValueOfFirstParameter()
        {
            FontKind testParam0 = _rnd.NextFontKind();
            ushort testParam1 = _rnd.NextUShort();
            ushort testParam2 = _rnd.NextUShort();
            ushort testParam3 = _rnd.NextUShort();
            ushort testParam4 = _rnd.NextUShort();

            OffsetTable testOutput = new OffsetTable(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.AreEqual(testParam0, testOutput.FontKind);
        }

        [TestMethod]
        public void OffsetTableClass_Constructor_SetsTableCountPropertyToValueOfSecondParameter()
        {
            FontKind testParam0 = _rnd.NextFontKind();
            ushort testParam1 = _rnd.NextUShort();
            ushort testParam2 = _rnd.NextUShort();
            ushort testParam3 = _rnd.NextUShort();
            ushort testParam4 = _rnd.NextUShort();

            OffsetTable testOutput = new OffsetTable(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.AreEqual(testParam1, testOutput.TableCount);
        }

        [TestMethod]
        public void OffsetTableClass_Constructor_SetsSearchRangePropertyToValueOfThirdParameter()
        {
            FontKind testParam0 = _rnd.NextFontKind();
            ushort testParam1 = _rnd.NextUShort();
            ushort testParam2 = _rnd.NextUShort();
            ushort testParam3 = _rnd.NextUShort();
            ushort testParam4 = _rnd.NextUShort();

            OffsetTable testOutput = new OffsetTable(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.AreEqual(testParam2, testOutput.SearchRange);
        }

        [TestMethod]
        public void OffsetTableClass_Constructor_SetsEntrySelectorPropertyToValueOfFourthParameter()
        {
            FontKind testParam0 = _rnd.NextFontKind();
            ushort testParam1 = _rnd.NextUShort();
            ushort testParam2 = _rnd.NextUShort();
            ushort testParam3 = _rnd.NextUShort();
            ushort testParam4 = _rnd.NextUShort();

            OffsetTable testOutput = new OffsetTable(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.AreEqual(testParam3, testOutput.EntrySelector);
        }

        [TestMethod]
        public void OffsetTableClass_Constructor_SetsRangeShiftPropertyToValueOfFifthParameter()
        {
            FontKind testParam0 = _rnd.NextFontKind();
            ushort testParam1 = _rnd.NextUShort();
            ushort testParam2 = _rnd.NextUShort();
            ushort testParam3 = _rnd.NextUShort();
            ushort testParam4 = _rnd.NextUShort();

            OffsetTable testOutput = new OffsetTable(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.AreEqual(testParam4, testOutput.RangeShift);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
