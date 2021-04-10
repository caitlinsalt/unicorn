using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Providers;
using Tests.Utility.Extensions;
using System.Linq;
using Unicorn.FontTools.OpenType;
using System.Globalization;

namespace Unicorn.FontTools.Tests.Unit.OpenType
{
    [TestClass]
    public class MaximumProfileTableUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private static MaximumProfileTable GetCffTable() => new(_rnd.NextUShort());

        private static MaximumProfileTable GetTruetypeTable()
            => new(_rnd.NextUShort(), _rnd.NextUShort(), _rnd.NextUShort(), _rnd.NextUShort(), _rnd.NextUShort(), _rnd.NextUShort(), _rnd.NextUShort(), 
                _rnd.NextUShort(), _rnd.NextUShort(), _rnd.NextUShort(), _rnd.NextUShort(), _rnd.NextUShort(), _rnd.NextUShort(), _rnd.NextUShort());

        private static MaximumProfileTable GetTable() => _rnd.NextBoolean() ? GetCffTable() : GetTruetypeTable();

#pragma warning disable CA1707 // Identifiers should not contain underscores
#pragma warning disable CA5394 // Do not use insecure randomness

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MaximumProfileTableClass_ConstructorWithOneParameter_ThrowsArgumentOutOfRangeException_IfParameterIsLessThanZero()
        {
            int testParam0 = _rnd.Next(int.MinValue, 0);

            _ = new MaximumProfileTable(testParam0);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MaximumProfileTableClass_ConstructorWithOneParameter_ThrowsArgumentOutOfRangeException_IfParameterIsTooLarge()
        {
            int testParam0 = _rnd.Next(ushort.MaxValue + 1, int.MaxValue);

            _ = new MaximumProfileTable(testParam0);

            Assert.Fail();
        }

        [TestMethod]
        public void MaximumProfileTableClass_ConstructorWithOneParameter_SetsTableTagPropertyToCorrectValue_IfParameterIsWithinRange()
        {
            int testParam0 = _rnd.NextUShort();

            MaximumProfileTable testOutput = new(testParam0);

            Assert.AreEqual("maxp", testOutput.TableTag.Value);
        }

        [TestMethod]
        public void MaximumProfileTableClass_ConstructorWithOneParameter_SetsKindPropertyToCff_IfParameterIsWithinRange()
        {
            int testParam0 = _rnd.NextUShort();

            MaximumProfileTable testOutput = new(testParam0);

            Assert.AreEqual(FontKind.Cff, testOutput.Kind);
        }

        [TestMethod]
        public void MaximumProfileTableClass_ConstructorWithOneParameter_SetsGlyphCountPropertyToValueOfParaemter_IfParameterIsWithinRange()
        {
            int testParam0 = _rnd.NextUShort();

            MaximumProfileTable testOutput = new(testParam0);

            Assert.AreEqual(testParam0, testOutput.GlyphCount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MaximumProfileTableClass_ConstructorWithFourteenParameters_ThrowsArgumentOutOfRangeException_IfFirstParameterIsLessThanZero()
        {
            int testParam00 = _rnd.Next(int.MinValue, 0);
            int testParam01 = _rnd.NextUShort();
            int testParam02 = _rnd.NextUShort();
            int testParam03 = _rnd.NextUShort();
            int testParam04 = _rnd.NextUShort();
            int testParam05 = _rnd.NextUShort();
            int testParam06 = _rnd.NextUShort();
            int testParam07 = _rnd.NextUShort();
            int testParam08 = _rnd.NextUShort();
            int testParam09 = _rnd.NextUShort();
            int testParam10 = _rnd.NextUShort();
            int testParam11 = _rnd.NextUShort();
            int testParam12 = _rnd.NextUShort();
            int testParam13 = _rnd.NextUShort();

            _ = new MaximumProfileTable(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07, testParam08,
                testParam09, testParam10, testParam11, testParam12, testParam13);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MaximumProfileTableClass_ConstructorWithFourteenParameters_ThrowsArgumentOutOfRangeException_IfFirstParameterIsTooLarge()
        {
            int testParam00 = _rnd.Next(ushort.MaxValue + 1, int.MaxValue);
            int testParam01 = _rnd.NextUShort();
            int testParam02 = _rnd.NextUShort();
            int testParam03 = _rnd.NextUShort();
            int testParam04 = _rnd.NextUShort();
            int testParam05 = _rnd.NextUShort();
            int testParam06 = _rnd.NextUShort();
            int testParam07 = _rnd.NextUShort();
            int testParam08 = _rnd.NextUShort();
            int testParam09 = _rnd.NextUShort();
            int testParam10 = _rnd.NextUShort();
            int testParam11 = _rnd.NextUShort();
            int testParam12 = _rnd.NextUShort();
            int testParam13 = _rnd.NextUShort();

            _ = new MaximumProfileTable(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07, testParam08,
                testParam09, testParam10, testParam11, testParam12, testParam13);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MaximumProfileTableClass_ConstructorWithFourteenParameters_ThrowsArgumentOutOfRangeException_IfSecondParameterIsLessThanZero()
        {
            int testParam00 = _rnd.NextUShort();
            int testParam01 = _rnd.Next(int.MinValue, 0);
            int testParam02 = _rnd.NextUShort();
            int testParam03 = _rnd.NextUShort();
            int testParam04 = _rnd.NextUShort();
            int testParam05 = _rnd.NextUShort();
            int testParam06 = _rnd.NextUShort();
            int testParam07 = _rnd.NextUShort();
            int testParam08 = _rnd.NextUShort();
            int testParam09 = _rnd.NextUShort();
            int testParam10 = _rnd.NextUShort();
            int testParam11 = _rnd.NextUShort();
            int testParam12 = _rnd.NextUShort();
            int testParam13 = _rnd.NextUShort();

            _ = new MaximumProfileTable(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07, testParam08,
                testParam09, testParam10, testParam11, testParam12, testParam13);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MaximumProfileTableClass_ConstructorWithFourteenParameters_ThrowsArgumentOutOfRangeException_IfSecondParameterIsTooLarge()
        {
            int testParam00 = _rnd.NextUShort();
            int testParam01 = _rnd.Next(ushort.MaxValue + 1, int.MaxValue);
            int testParam02 = _rnd.NextUShort();
            int testParam03 = _rnd.NextUShort();
            int testParam04 = _rnd.NextUShort();
            int testParam05 = _rnd.NextUShort();
            int testParam06 = _rnd.NextUShort();
            int testParam07 = _rnd.NextUShort();
            int testParam08 = _rnd.NextUShort();
            int testParam09 = _rnd.NextUShort();
            int testParam10 = _rnd.NextUShort();
            int testParam11 = _rnd.NextUShort();
            int testParam12 = _rnd.NextUShort();
            int testParam13 = _rnd.NextUShort();

            _ = new MaximumProfileTable(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07, testParam08,
                testParam09, testParam10, testParam11, testParam12, testParam13);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MaximumProfileTableClass_ConstructorWithFourteenParameters_ThrowsArgumentOutOfRangeException_IfThirdParameterIsLessThanZero()
        {
            int testParam00 = _rnd.NextUShort();
            int testParam01 = _rnd.NextUShort();
            int testParam02 = _rnd.Next(int.MinValue, 0);
            int testParam03 = _rnd.NextUShort();
            int testParam04 = _rnd.NextUShort();
            int testParam05 = _rnd.NextUShort();
            int testParam06 = _rnd.NextUShort();
            int testParam07 = _rnd.NextUShort();
            int testParam08 = _rnd.NextUShort();
            int testParam09 = _rnd.NextUShort();
            int testParam10 = _rnd.NextUShort();
            int testParam11 = _rnd.NextUShort();
            int testParam12 = _rnd.NextUShort();
            int testParam13 = _rnd.NextUShort();

            _ = new MaximumProfileTable(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07, testParam08,
                testParam09, testParam10, testParam11, testParam12, testParam13);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MaximumProfileTableClass_ConstructorWithFourteenParameters_ThrowsArgumentOutOfRangeException_IfThirdParameterIsTooLarge()
        {
            int testParam00 = _rnd.NextUShort();
            int testParam01 = _rnd.NextUShort();
            int testParam02 = _rnd.Next(ushort.MaxValue + 1, int.MaxValue);
            int testParam03 = _rnd.NextUShort();
            int testParam04 = _rnd.NextUShort();
            int testParam05 = _rnd.NextUShort();
            int testParam06 = _rnd.NextUShort();
            int testParam07 = _rnd.NextUShort();
            int testParam08 = _rnd.NextUShort();
            int testParam09 = _rnd.NextUShort();
            int testParam10 = _rnd.NextUShort();
            int testParam11 = _rnd.NextUShort();
            int testParam12 = _rnd.NextUShort();
            int testParam13 = _rnd.NextUShort();

            _ = new MaximumProfileTable(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07, testParam08,
                testParam09, testParam10, testParam11, testParam12, testParam13);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MaximumProfileTableClass_ConstructorWithFourteenParameters_ThrowsArgumentOutOfRangeException_IfFourthParameterIsLessThanZero()
        {
            int testParam00 = _rnd.NextUShort();
            int testParam01 = _rnd.NextUShort();
            int testParam02 = _rnd.NextUShort();
            int testParam03 = _rnd.Next(int.MinValue, 0);
            int testParam04 = _rnd.NextUShort();
            int testParam05 = _rnd.NextUShort();
            int testParam06 = _rnd.NextUShort();
            int testParam07 = _rnd.NextUShort();
            int testParam08 = _rnd.NextUShort();
            int testParam09 = _rnd.NextUShort();
            int testParam10 = _rnd.NextUShort();
            int testParam11 = _rnd.NextUShort();
            int testParam12 = _rnd.NextUShort();
            int testParam13 = _rnd.NextUShort();

            _ = new MaximumProfileTable(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07, testParam08,
                testParam09, testParam10, testParam11, testParam12, testParam13);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MaximumProfileTableClass_ConstructorWithFourteenParameters_ThrowsArgumentOutOfRangeException_IfFourthParameterIsTooLarge()
        {
            int testParam00 = _rnd.NextUShort();
            int testParam01 = _rnd.NextUShort();
            int testParam02 = _rnd.NextUShort();
            int testParam03 = _rnd.Next(ushort.MaxValue + 1, int.MaxValue);
            int testParam04 = _rnd.NextUShort();
            int testParam05 = _rnd.NextUShort();
            int testParam06 = _rnd.NextUShort();
            int testParam07 = _rnd.NextUShort();
            int testParam08 = _rnd.NextUShort();
            int testParam09 = _rnd.NextUShort();
            int testParam10 = _rnd.NextUShort();
            int testParam11 = _rnd.NextUShort();
            int testParam12 = _rnd.NextUShort();
            int testParam13 = _rnd.NextUShort();

            _ = new MaximumProfileTable(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07, testParam08,
                testParam09, testParam10, testParam11, testParam12, testParam13);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MaximumProfileTableClass_ConstructorWithFourteenParameters_ThrowsArgumentOutOfRangeException_IfFifthParameterIsLessThanZero()
        {
            int testParam00 = _rnd.NextUShort();
            int testParam01 = _rnd.NextUShort();
            int testParam02 = _rnd.NextUShort();
            int testParam03 = _rnd.NextUShort();
            int testParam04 = _rnd.Next(int.MinValue, 0);
            int testParam05 = _rnd.NextUShort();
            int testParam06 = _rnd.NextUShort();
            int testParam07 = _rnd.NextUShort();
            int testParam08 = _rnd.NextUShort();
            int testParam09 = _rnd.NextUShort();
            int testParam10 = _rnd.NextUShort();
            int testParam11 = _rnd.NextUShort();
            int testParam12 = _rnd.NextUShort();
            int testParam13 = _rnd.NextUShort();

            _ = new MaximumProfileTable(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07, testParam08,
                testParam09, testParam10, testParam11, testParam12, testParam13);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MaximumProfileTableClass_ConstructorWithFourteenParameters_ThrowsArgumentOutOfRangeException_IfFifthParameterIsTooLarge()
        {
            int testParam00 = _rnd.NextUShort();
            int testParam01 = _rnd.NextUShort();
            int testParam02 = _rnd.NextUShort();
            int testParam03 = _rnd.NextUShort();
            int testParam04 = _rnd.Next(ushort.MaxValue + 1, int.MaxValue);
            int testParam05 = _rnd.NextUShort();
            int testParam06 = _rnd.NextUShort();
            int testParam07 = _rnd.NextUShort();
            int testParam08 = _rnd.NextUShort();
            int testParam09 = _rnd.NextUShort();
            int testParam10 = _rnd.NextUShort();
            int testParam11 = _rnd.NextUShort();
            int testParam12 = _rnd.NextUShort();
            int testParam13 = _rnd.NextUShort();

            _ = new MaximumProfileTable(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07, testParam08,
                testParam09, testParam10, testParam11, testParam12, testParam13);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MaximumProfileTableClass_ConstructorWithFourteenParameters_ThrowsArgumentOutOfRangeException_IfSixthParameterIsLessThanZero()
        {
            int testParam00 = _rnd.NextUShort();
            int testParam01 = _rnd.NextUShort();
            int testParam02 = _rnd.NextUShort();
            int testParam03 = _rnd.NextUShort();
            int testParam04 = _rnd.NextUShort();
            int testParam05 = _rnd.Next(int.MinValue, 0);
            int testParam06 = _rnd.NextUShort();
            int testParam07 = _rnd.NextUShort();
            int testParam08 = _rnd.NextUShort();
            int testParam09 = _rnd.NextUShort();
            int testParam10 = _rnd.NextUShort();
            int testParam11 = _rnd.NextUShort();
            int testParam12 = _rnd.NextUShort();
            int testParam13 = _rnd.NextUShort();

            _ = new MaximumProfileTable(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07, testParam08,
                testParam09, testParam10, testParam11, testParam12, testParam13);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MaximumProfileTableClass_ConstructorWithFourteenParameters_ThrowsArgumentOutOfRangeException_IfSixthParameterIsTooLarge()
        {
            int testParam00 = _rnd.NextUShort();
            int testParam01 = _rnd.NextUShort();
            int testParam02 = _rnd.NextUShort();
            int testParam03 = _rnd.NextUShort();
            int testParam04 = _rnd.NextUShort();
            int testParam05 = _rnd.Next(ushort.MaxValue + 1, int.MaxValue);
            int testParam06 = _rnd.NextUShort();
            int testParam07 = _rnd.NextUShort();
            int testParam08 = _rnd.NextUShort();
            int testParam09 = _rnd.NextUShort();
            int testParam10 = _rnd.NextUShort();
            int testParam11 = _rnd.NextUShort();
            int testParam12 = _rnd.NextUShort();
            int testParam13 = _rnd.NextUShort();

            _ = new MaximumProfileTable(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07, testParam08,
                testParam09, testParam10, testParam11, testParam12, testParam13);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MaximumProfileTableClass_ConstructorWithFourteenParameters_ThrowsArgumentOutOfRangeException_IfSeventhParameterIsLessThanZero()
        {
            int testParam00 = _rnd.NextUShort();
            int testParam01 = _rnd.NextUShort();
            int testParam02 = _rnd.NextUShort();
            int testParam03 = _rnd.NextUShort();
            int testParam04 = _rnd.NextUShort();
            int testParam05 = _rnd.NextUShort();
            int testParam06 = _rnd.Next(int.MinValue, 0);
            int testParam07 = _rnd.NextUShort();
            int testParam08 = _rnd.NextUShort();
            int testParam09 = _rnd.NextUShort();
            int testParam10 = _rnd.NextUShort();
            int testParam11 = _rnd.NextUShort();
            int testParam12 = _rnd.NextUShort();
            int testParam13 = _rnd.NextUShort();

            _ = new MaximumProfileTable(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07, testParam08,
                testParam09, testParam10, testParam11, testParam12, testParam13);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MaximumProfileTableClass_ConstructorWithFourteenParameters_ThrowsArgumentOutOfRangeException_IfSeventhParameterIsTooLarge()
        {
            int testParam00 = _rnd.NextUShort();
            int testParam01 = _rnd.NextUShort();
            int testParam02 = _rnd.NextUShort();
            int testParam03 = _rnd.NextUShort();
            int testParam04 = _rnd.NextUShort();
            int testParam05 = _rnd.NextUShort();
            int testParam06 = _rnd.Next(ushort.MaxValue + 1, int.MaxValue);
            int testParam07 = _rnd.NextUShort();
            int testParam08 = _rnd.NextUShort();
            int testParam09 = _rnd.NextUShort();
            int testParam10 = _rnd.NextUShort();
            int testParam11 = _rnd.NextUShort();
            int testParam12 = _rnd.NextUShort();
            int testParam13 = _rnd.NextUShort();

            _ = new MaximumProfileTable(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07, testParam08,
                testParam09, testParam10, testParam11, testParam12, testParam13);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MaximumProfileTableClass_ConstructorWithFourteenParameters_ThrowsArgumentOutOfRangeException_IfEighthParameterIsLessThanZero()
        {
            int testParam00 = _rnd.NextUShort();
            int testParam01 = _rnd.NextUShort();
            int testParam02 = _rnd.NextUShort();
            int testParam03 = _rnd.NextUShort();
            int testParam04 = _rnd.NextUShort();
            int testParam05 = _rnd.NextUShort();
            int testParam06 = _rnd.NextUShort();
            int testParam07 = _rnd.Next(int.MinValue, 0);
            int testParam08 = _rnd.NextUShort();
            int testParam09 = _rnd.NextUShort();
            int testParam10 = _rnd.NextUShort();
            int testParam11 = _rnd.NextUShort();
            int testParam12 = _rnd.NextUShort();
            int testParam13 = _rnd.NextUShort();

            _ = new MaximumProfileTable(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07, testParam08,
                testParam09, testParam10, testParam11, testParam12, testParam13);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MaximumProfileTableClass_ConstructorWithFourteenParameters_ThrowsArgumentOutOfRangeException_IfEighthParameterIsTooLarge()
        {
            int testParam00 = _rnd.NextUShort();
            int testParam01 = _rnd.NextUShort();
            int testParam02 = _rnd.NextUShort();
            int testParam03 = _rnd.NextUShort();
            int testParam04 = _rnd.NextUShort();
            int testParam05 = _rnd.NextUShort();
            int testParam06 = _rnd.NextUShort();
            int testParam07 = _rnd.Next(ushort.MaxValue + 1, int.MaxValue);
            int testParam08 = _rnd.NextUShort();
            int testParam09 = _rnd.NextUShort();
            int testParam10 = _rnd.NextUShort();
            int testParam11 = _rnd.NextUShort();
            int testParam12 = _rnd.NextUShort();
            int testParam13 = _rnd.NextUShort();

            _ = new MaximumProfileTable(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07, testParam08,
                testParam09, testParam10, testParam11, testParam12, testParam13);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MaximumProfileTableClass_ConstructorWithFourteenParameters_ThrowsArgumentOutOfRangeException_IfNinthParameterIsLessThanZero()
        {
            int testParam00 = _rnd.NextUShort();
            int testParam01 = _rnd.NextUShort();
            int testParam02 = _rnd.NextUShort();
            int testParam03 = _rnd.NextUShort();
            int testParam04 = _rnd.NextUShort();
            int testParam05 = _rnd.NextUShort();
            int testParam06 = _rnd.NextUShort();
            int testParam07 = _rnd.NextUShort();
            int testParam08 = _rnd.Next(int.MinValue, 0);
            int testParam09 = _rnd.NextUShort();
            int testParam10 = _rnd.NextUShort();
            int testParam11 = _rnd.NextUShort();
            int testParam12 = _rnd.NextUShort();
            int testParam13 = _rnd.NextUShort();

            _ = new MaximumProfileTable(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07, testParam08,
                testParam09, testParam10, testParam11, testParam12, testParam13);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MaximumProfileTableClass_ConstructorWithFourteenParameters_ThrowsArgumentOutOfRangeException_IfNinthParameterIsTooLarge()
        {
            int testParam00 = _rnd.NextUShort();
            int testParam01 = _rnd.NextUShort();
            int testParam02 = _rnd.NextUShort();
            int testParam03 = _rnd.NextUShort();
            int testParam04 = _rnd.NextUShort();
            int testParam05 = _rnd.NextUShort();
            int testParam06 = _rnd.NextUShort();
            int testParam07 = _rnd.NextUShort();
            int testParam08 = _rnd.Next(ushort.MaxValue + 1, int.MaxValue);
            int testParam09 = _rnd.NextUShort();
            int testParam10 = _rnd.NextUShort();
            int testParam11 = _rnd.NextUShort();
            int testParam12 = _rnd.NextUShort();
            int testParam13 = _rnd.NextUShort();

            _ = new MaximumProfileTable(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07, testParam08,
                testParam09, testParam10, testParam11, testParam12, testParam13);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MaximumProfileTableClass_ConstructorWithFourteenParameters_ThrowsArgumentOutOfRangeException_IfTenthParameterIsLessThanZero()
        {
            int testParam00 = _rnd.NextUShort();
            int testParam01 = _rnd.NextUShort();
            int testParam02 = _rnd.NextUShort();
            int testParam03 = _rnd.NextUShort();
            int testParam04 = _rnd.NextUShort();
            int testParam05 = _rnd.NextUShort();
            int testParam06 = _rnd.NextUShort();
            int testParam07 = _rnd.NextUShort();
            int testParam08 = _rnd.NextUShort();
            int testParam09 = _rnd.Next(int.MinValue, 0);
            int testParam10 = _rnd.NextUShort();
            int testParam11 = _rnd.NextUShort();
            int testParam12 = _rnd.NextUShort();
            int testParam13 = _rnd.NextUShort();

            _ = new MaximumProfileTable(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07, testParam08,
                testParam09, testParam10, testParam11, testParam12, testParam13);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MaximumProfileTableClass_ConstructorWithFourteenParameters_ThrowsArgumentOutOfRangeException_IfTenthParameterIsTooLarge()
        {
            int testParam00 = _rnd.NextUShort();
            int testParam01 = _rnd.NextUShort();
            int testParam02 = _rnd.NextUShort();
            int testParam03 = _rnd.NextUShort();
            int testParam04 = _rnd.NextUShort();
            int testParam05 = _rnd.NextUShort();
            int testParam06 = _rnd.NextUShort();
            int testParam07 = _rnd.NextUShort();
            int testParam08 = _rnd.NextUShort();
            int testParam09 = _rnd.Next(ushort.MaxValue + 1, int.MaxValue);
            int testParam10 = _rnd.NextUShort();
            int testParam11 = _rnd.NextUShort();
            int testParam12 = _rnd.NextUShort();
            int testParam13 = _rnd.NextUShort();

            _ = new MaximumProfileTable(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07, testParam08,
                testParam09, testParam10, testParam11, testParam12, testParam13);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MaximumProfileTableClass_ConstructorWithFourteenParameters_ThrowsArgumentOutOfRangeException_IfEleventhParameterIsLessThanZero()
        {
            int testParam00 = _rnd.NextUShort();
            int testParam01 = _rnd.NextUShort();
            int testParam02 = _rnd.NextUShort();
            int testParam03 = _rnd.NextUShort();
            int testParam04 = _rnd.NextUShort();
            int testParam05 = _rnd.NextUShort();
            int testParam06 = _rnd.NextUShort();
            int testParam07 = _rnd.NextUShort();
            int testParam08 = _rnd.NextUShort();
            int testParam09 = _rnd.NextUShort();
            int testParam10 = _rnd.Next(int.MinValue, 0);
            int testParam11 = _rnd.NextUShort();
            int testParam12 = _rnd.NextUShort();
            int testParam13 = _rnd.NextUShort();

            _ = new MaximumProfileTable(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07, testParam08,
                testParam09, testParam10, testParam11, testParam12, testParam13);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MaximumProfileTableClass_ConstructorWithFourteenParameters_ThrowsArgumentOutOfRangeException_IfEleventhParameterIsTooLarge()
        {
            int testParam00 = _rnd.NextUShort();
            int testParam01 = _rnd.NextUShort();
            int testParam02 = _rnd.NextUShort();
            int testParam03 = _rnd.NextUShort();
            int testParam04 = _rnd.NextUShort();
            int testParam05 = _rnd.NextUShort();
            int testParam06 = _rnd.NextUShort();
            int testParam07 = _rnd.NextUShort();
            int testParam08 = _rnd.NextUShort();
            int testParam09 = _rnd.NextUShort();
            int testParam10 = _rnd.Next(ushort.MaxValue + 1, int.MaxValue);
            int testParam11 = _rnd.NextUShort();
            int testParam12 = _rnd.NextUShort();
            int testParam13 = _rnd.NextUShort();

            _ = new MaximumProfileTable(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07, testParam08,
                testParam09, testParam10, testParam11, testParam12, testParam13);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MaximumProfileTableClass_ConstructorWithFourteenParameters_ThrowsArgumentOutOfRangeException_IfTwelfthParameterIsLessThanZero()
        {
            int testParam00 = _rnd.NextUShort();
            int testParam01 = _rnd.NextUShort();
            int testParam02 = _rnd.NextUShort();
            int testParam03 = _rnd.NextUShort();
            int testParam04 = _rnd.NextUShort();
            int testParam05 = _rnd.NextUShort();
            int testParam06 = _rnd.NextUShort();
            int testParam07 = _rnd.NextUShort();
            int testParam08 = _rnd.NextUShort();
            int testParam09 = _rnd.NextUShort();
            int testParam10 = _rnd.NextUShort();
            int testParam11 = _rnd.Next(int.MinValue, 0);
            int testParam12 = _rnd.NextUShort();
            int testParam13 = _rnd.NextUShort();

            _ = new MaximumProfileTable(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07, testParam08,
                testParam09, testParam10, testParam11, testParam12, testParam13);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MaximumProfileTableClass_ConstructorWithFourteenParameters_ThrowsArgumentOutOfRangeException_IfTwelfthParameterIsTooLarge()
        {
            int testParam00 = _rnd.NextUShort();
            int testParam01 = _rnd.NextUShort();
            int testParam02 = _rnd.NextUShort();
            int testParam03 = _rnd.NextUShort();
            int testParam04 = _rnd.NextUShort();
            int testParam05 = _rnd.NextUShort();
            int testParam06 = _rnd.NextUShort();
            int testParam07 = _rnd.NextUShort();
            int testParam08 = _rnd.NextUShort();
            int testParam09 = _rnd.NextUShort();
            int testParam10 = _rnd.NextUShort();
            int testParam11 = _rnd.Next(ushort.MaxValue + 1, int.MaxValue);
            int testParam12 = _rnd.NextUShort();
            int testParam13 = _rnd.NextUShort();

            _ = new MaximumProfileTable(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07, testParam08,
                testParam09, testParam10, testParam11, testParam12, testParam13);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MaximumProfileTableClass_ConstructorWithFourteenParameters_ThrowsArgumentOutOfRangeException_IfThirteenthParameterIsLessThanZero()
        {
            int testParam00 = _rnd.NextUShort();
            int testParam01 = _rnd.NextUShort();
            int testParam02 = _rnd.NextUShort();
            int testParam03 = _rnd.NextUShort();
            int testParam04 = _rnd.NextUShort();
            int testParam05 = _rnd.NextUShort();
            int testParam06 = _rnd.NextUShort();
            int testParam07 = _rnd.NextUShort();
            int testParam08 = _rnd.NextUShort();
            int testParam09 = _rnd.NextUShort();
            int testParam10 = _rnd.NextUShort();
            int testParam11 = _rnd.NextUShort();
            int testParam12 = _rnd.Next(int.MinValue, 0);
            int testParam13 = _rnd.NextUShort();

            _ = new MaximumProfileTable(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07, testParam08,
                testParam09, testParam10, testParam11, testParam12, testParam13);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MaximumProfileTableClass_ConstructorWithFourteenParameters_ThrowsArgumentOutOfRangeException_IfThirteenthParameterIsTooLarge()
        {
            int testParam00 = _rnd.NextUShort();
            int testParam01 = _rnd.NextUShort();
            int testParam02 = _rnd.NextUShort();
            int testParam03 = _rnd.NextUShort();
            int testParam04 = _rnd.NextUShort();
            int testParam05 = _rnd.NextUShort();
            int testParam06 = _rnd.NextUShort();
            int testParam07 = _rnd.NextUShort();
            int testParam08 = _rnd.NextUShort();
            int testParam09 = _rnd.NextUShort();
            int testParam10 = _rnd.NextUShort();
            int testParam11 = _rnd.NextUShort();
            int testParam12 = _rnd.Next(ushort.MaxValue + 1, int.MaxValue);
            int testParam13 = _rnd.NextUShort();

            _ = new MaximumProfileTable(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07, testParam08,
                testParam09, testParam10, testParam11, testParam12, testParam13);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MaximumProfileTableClass_ConstructorWithFourteenParameters_ThrowsArgumentOutOfRangeException_IfFourteenthParameterIsLessThanZero()
        {
            int testParam00 = _rnd.NextUShort();
            int testParam01 = _rnd.NextUShort();
            int testParam02 = _rnd.NextUShort();
            int testParam03 = _rnd.NextUShort();
            int testParam04 = _rnd.NextUShort();
            int testParam05 = _rnd.NextUShort();
            int testParam06 = _rnd.NextUShort();
            int testParam07 = _rnd.NextUShort();
            int testParam08 = _rnd.NextUShort();
            int testParam09 = _rnd.NextUShort();
            int testParam10 = _rnd.NextUShort();
            int testParam11 = _rnd.NextUShort();
            int testParam12 = _rnd.NextUShort();
            int testParam13 = _rnd.Next(int.MinValue, 0);

            _ = new MaximumProfileTable(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07, testParam08,
                testParam09, testParam10, testParam11, testParam12, testParam13);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MaximumProfileTableClass_ConstructorWithFourteenParameters_ThrowsArgumentOutOfRangeException_IfFourteenthParameterIsTooLarge()
        {
            int testParam00 = _rnd.NextUShort();
            int testParam01 = _rnd.NextUShort();
            int testParam02 = _rnd.NextUShort();
            int testParam03 = _rnd.NextUShort();
            int testParam04 = _rnd.NextUShort();
            int testParam05 = _rnd.NextUShort();
            int testParam06 = _rnd.NextUShort();
            int testParam07 = _rnd.NextUShort();
            int testParam08 = _rnd.NextUShort();
            int testParam09 = _rnd.NextUShort();
            int testParam10 = _rnd.NextUShort();
            int testParam11 = _rnd.NextUShort();
            int testParam12 = _rnd.NextUShort();
            int testParam13 = _rnd.Next(ushort.MaxValue + 1, int.MaxValue);

            _ = new MaximumProfileTable(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07, testParam08,
                testParam09, testParam10, testParam11, testParam12, testParam13);

            Assert.Fail();
        }

        [TestMethod]
        public void MaximumProfileTableClass_ConstructorWithFourteenParameters_SetsTableTagPropertyToCorrectValue_IfParametersAreWithinRange()
        {
            int testParam00 = _rnd.NextUShort();
            int testParam01 = _rnd.NextUShort();
            int testParam02 = _rnd.NextUShort();
            int testParam03 = _rnd.NextUShort();
            int testParam04 = _rnd.NextUShort();
            int testParam05 = _rnd.NextUShort();
            int testParam06 = _rnd.NextUShort();
            int testParam07 = _rnd.NextUShort();
            int testParam08 = _rnd.NextUShort();
            int testParam09 = _rnd.NextUShort();
            int testParam10 = _rnd.NextUShort();
            int testParam11 = _rnd.NextUShort();
            int testParam12 = _rnd.NextUShort();
            int testParam13 = _rnd.NextUShort();

            MaximumProfileTable testOutput = new(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07, testParam08,
                testParam09, testParam10, testParam11, testParam12, testParam13);

            Assert.AreEqual("maxp", testOutput.TableTag.Value);
        }

        [TestMethod]
        public void MaximumProfileTableClass_ConstructorWithFourteenParameters_SetsKindPropertyToTruetype_IfParametersAreWithinRange()
        {
            int testParam00 = _rnd.NextUShort();
            int testParam01 = _rnd.NextUShort();
            int testParam02 = _rnd.NextUShort();
            int testParam03 = _rnd.NextUShort();
            int testParam04 = _rnd.NextUShort();
            int testParam05 = _rnd.NextUShort();
            int testParam06 = _rnd.NextUShort();
            int testParam07 = _rnd.NextUShort();
            int testParam08 = _rnd.NextUShort();
            int testParam09 = _rnd.NextUShort();
            int testParam10 = _rnd.NextUShort();
            int testParam11 = _rnd.NextUShort();
            int testParam12 = _rnd.NextUShort();
            int testParam13 = _rnd.NextUShort();

            MaximumProfileTable testOutput = new(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07, testParam08,
                testParam09, testParam10, testParam11, testParam12, testParam13);

            Assert.AreEqual(FontKind.TrueType, testOutput.Kind);
        }

        [TestMethod]
        public void MaximumProfileTableClass_ConstructorWithFourteenParameters_SetsGlyphCountPropertyToValueOfFirstParameter_IfParametersAreWithinRange()
        {
            int testParam00 = _rnd.NextUShort();
            int testParam01 = _rnd.NextUShort();
            int testParam02 = _rnd.NextUShort();
            int testParam03 = _rnd.NextUShort();
            int testParam04 = _rnd.NextUShort();
            int testParam05 = _rnd.NextUShort();
            int testParam06 = _rnd.NextUShort();
            int testParam07 = _rnd.NextUShort();
            int testParam08 = _rnd.NextUShort();
            int testParam09 = _rnd.NextUShort();
            int testParam10 = _rnd.NextUShort();
            int testParam11 = _rnd.NextUShort();
            int testParam12 = _rnd.NextUShort();
            int testParam13 = _rnd.NextUShort();

            MaximumProfileTable testOutput = new(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07, testParam08,
                testParam09, testParam10, testParam11, testParam12, testParam13);

            Assert.AreEqual(testParam00, testOutput.GlyphCount);
        }

        [TestMethod]
        public void MaximumProfileTableClass_ConstructorWithFourteenParameters_SetsMaxPointsPropertyToValueOfSecondParameter_IfParametersAreWithinRange()
        {
            int testParam00 = _rnd.NextUShort();
            int testParam01 = _rnd.NextUShort();
            int testParam02 = _rnd.NextUShort();
            int testParam03 = _rnd.NextUShort();
            int testParam04 = _rnd.NextUShort();
            int testParam05 = _rnd.NextUShort();
            int testParam06 = _rnd.NextUShort();
            int testParam07 = _rnd.NextUShort();
            int testParam08 = _rnd.NextUShort();
            int testParam09 = _rnd.NextUShort();
            int testParam10 = _rnd.NextUShort();
            int testParam11 = _rnd.NextUShort();
            int testParam12 = _rnd.NextUShort();
            int testParam13 = _rnd.NextUShort();

            MaximumProfileTable testOutput = new(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07, testParam08,
                testParam09, testParam10, testParam11, testParam12, testParam13);

            Assert.AreEqual(testParam01, testOutput.MaxPoints);
        }

        [TestMethod]
        public void MaximumProfileTableClass_ConstructorWithFourteenParameters_SetsMaxContoursPropertyToValueOfThirdParameter_IfParametersAreWithinRange()
        {
            int testParam00 = _rnd.NextUShort();
            int testParam01 = _rnd.NextUShort();
            int testParam02 = _rnd.NextUShort();
            int testParam03 = _rnd.NextUShort();
            int testParam04 = _rnd.NextUShort();
            int testParam05 = _rnd.NextUShort();
            int testParam06 = _rnd.NextUShort();
            int testParam07 = _rnd.NextUShort();
            int testParam08 = _rnd.NextUShort();
            int testParam09 = _rnd.NextUShort();
            int testParam10 = _rnd.NextUShort();
            int testParam11 = _rnd.NextUShort();
            int testParam12 = _rnd.NextUShort();
            int testParam13 = _rnd.NextUShort();

            MaximumProfileTable testOutput = new(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07, testParam08,
                testParam09, testParam10, testParam11, testParam12, testParam13);

            Assert.AreEqual(testParam02, testOutput.MaxContours);
        }

        [TestMethod]
        public void MaximumProfileTableClass_ConstructorWithFourteenParameters_SetsMaxCompositePointsPropertyToValueOfFourthParameter_IfParametersAreWithinRange()
        {
            int testParam00 = _rnd.NextUShort();
            int testParam01 = _rnd.NextUShort();
            int testParam02 = _rnd.NextUShort();
            int testParam03 = _rnd.NextUShort();
            int testParam04 = _rnd.NextUShort();
            int testParam05 = _rnd.NextUShort();
            int testParam06 = _rnd.NextUShort();
            int testParam07 = _rnd.NextUShort();
            int testParam08 = _rnd.NextUShort();
            int testParam09 = _rnd.NextUShort();
            int testParam10 = _rnd.NextUShort();
            int testParam11 = _rnd.NextUShort();
            int testParam12 = _rnd.NextUShort();
            int testParam13 = _rnd.NextUShort();

            MaximumProfileTable testOutput = new(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07, testParam08,
                testParam09, testParam10, testParam11, testParam12, testParam13);

            Assert.AreEqual(testParam03, testOutput.MaxCompositePoints);
        }

        [TestMethod]
        public void MaximumProfileTableClass_ConstructorWithFourteenParameters_SetsMaxCompositeContoursPropertyToValueOfFifthParameter_IfParametersAreWithinRange()
        {
            int testParam00 = _rnd.NextUShort();
            int testParam01 = _rnd.NextUShort();
            int testParam02 = _rnd.NextUShort();
            int testParam03 = _rnd.NextUShort();
            int testParam04 = _rnd.NextUShort();
            int testParam05 = _rnd.NextUShort();
            int testParam06 = _rnd.NextUShort();
            int testParam07 = _rnd.NextUShort();
            int testParam08 = _rnd.NextUShort();
            int testParam09 = _rnd.NextUShort();
            int testParam10 = _rnd.NextUShort();
            int testParam11 = _rnd.NextUShort();
            int testParam12 = _rnd.NextUShort();
            int testParam13 = _rnd.NextUShort();

            MaximumProfileTable testOutput = new(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07, testParam08,
                testParam09, testParam10, testParam11, testParam12, testParam13);

            Assert.AreEqual(testParam04, testOutput.MaxCompositeContours);
        }

        [TestMethod]
        public void MaximumProfileTableClass_ConstructorWithFourteenParameters_SetsMaxZonesPropertyToValueOfSixthParameter_IfParametersAreWithinRange()
        {
            int testParam00 = _rnd.NextUShort();
            int testParam01 = _rnd.NextUShort();
            int testParam02 = _rnd.NextUShort();
            int testParam03 = _rnd.NextUShort();
            int testParam04 = _rnd.NextUShort();
            int testParam05 = _rnd.NextUShort();
            int testParam06 = _rnd.NextUShort();
            int testParam07 = _rnd.NextUShort();
            int testParam08 = _rnd.NextUShort();
            int testParam09 = _rnd.NextUShort();
            int testParam10 = _rnd.NextUShort();
            int testParam11 = _rnd.NextUShort();
            int testParam12 = _rnd.NextUShort();
            int testParam13 = _rnd.NextUShort();

            MaximumProfileTable testOutput = new(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07, testParam08,
                testParam09, testParam10, testParam11, testParam12, testParam13);

            Assert.AreEqual(testParam05, testOutput.MaxZones);
        }

        [TestMethod]
        public void MaximumProfileTableClass_ConstructorWithFourteenParameters_SetsMaxTwilightZonePointsPropertyToValueOfSeventhParameter_IfParametersAreWithinRange()
        {
            int testParam00 = _rnd.NextUShort();
            int testParam01 = _rnd.NextUShort();
            int testParam02 = _rnd.NextUShort();
            int testParam03 = _rnd.NextUShort();
            int testParam04 = _rnd.NextUShort();
            int testParam05 = _rnd.NextUShort();
            int testParam06 = _rnd.NextUShort();
            int testParam07 = _rnd.NextUShort();
            int testParam08 = _rnd.NextUShort();
            int testParam09 = _rnd.NextUShort();
            int testParam10 = _rnd.NextUShort();
            int testParam11 = _rnd.NextUShort();
            int testParam12 = _rnd.NextUShort();
            int testParam13 = _rnd.NextUShort();

            MaximumProfileTable testOutput = new(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07, testParam08,
                testParam09, testParam10, testParam11, testParam12, testParam13);

            Assert.AreEqual(testParam06, testOutput.MaxTwilightZonePoints);
        }

        [TestMethod]
        public void MaximumProfileTableClass_ConstructorWithFourteenParameters_SetsMaxStoragePropertyToValueOfEighthParameter_IfParametersAreWithinRange()
        {
            int testParam00 = _rnd.NextUShort();
            int testParam01 = _rnd.NextUShort();
            int testParam02 = _rnd.NextUShort();
            int testParam03 = _rnd.NextUShort();
            int testParam04 = _rnd.NextUShort();
            int testParam05 = _rnd.NextUShort();
            int testParam06 = _rnd.NextUShort();
            int testParam07 = _rnd.NextUShort();
            int testParam08 = _rnd.NextUShort();
            int testParam09 = _rnd.NextUShort();
            int testParam10 = _rnd.NextUShort();
            int testParam11 = _rnd.NextUShort();
            int testParam12 = _rnd.NextUShort();
            int testParam13 = _rnd.NextUShort();

            MaximumProfileTable testOutput = new(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07, testParam08,
                testParam09, testParam10, testParam11, testParam12, testParam13);

            Assert.AreEqual(testParam07, testOutput.MaxStorage);
        }

        [TestMethod]
        public void MaximumProfileTableClass_ConstructorWithFourteenParameters_SetsMaxFunctionDefsPropertyToValueOfNinthParameter_IfParametersAreWithinRange()
        {
            int testParam00 = _rnd.NextUShort();
            int testParam01 = _rnd.NextUShort();
            int testParam02 = _rnd.NextUShort();
            int testParam03 = _rnd.NextUShort();
            int testParam04 = _rnd.NextUShort();
            int testParam05 = _rnd.NextUShort();
            int testParam06 = _rnd.NextUShort();
            int testParam07 = _rnd.NextUShort();
            int testParam08 = _rnd.NextUShort();
            int testParam09 = _rnd.NextUShort();
            int testParam10 = _rnd.NextUShort();
            int testParam11 = _rnd.NextUShort();
            int testParam12 = _rnd.NextUShort();
            int testParam13 = _rnd.NextUShort();

            MaximumProfileTable testOutput = new(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07, testParam08,
                testParam09, testParam10, testParam11, testParam12, testParam13);

            Assert.AreEqual(testParam08, testOutput.MaxFunctionDefs);
        }

        [TestMethod]
        public void MaximumProfileTableClass_ConstructorWithFourteenParameters_SetsMaxInstructionDefsPropertyToValueOfTenthParameter_IfParametersAreWithinRange()
        {
            int testParam00 = _rnd.NextUShort();
            int testParam01 = _rnd.NextUShort();
            int testParam02 = _rnd.NextUShort();
            int testParam03 = _rnd.NextUShort();
            int testParam04 = _rnd.NextUShort();
            int testParam05 = _rnd.NextUShort();
            int testParam06 = _rnd.NextUShort();
            int testParam07 = _rnd.NextUShort();
            int testParam08 = _rnd.NextUShort();
            int testParam09 = _rnd.NextUShort();
            int testParam10 = _rnd.NextUShort();
            int testParam11 = _rnd.NextUShort();
            int testParam12 = _rnd.NextUShort();
            int testParam13 = _rnd.NextUShort();

            MaximumProfileTable testOutput = new(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07, testParam08,
                testParam09, testParam10, testParam11, testParam12, testParam13);

            Assert.AreEqual(testParam09, testOutput.MaxInstructionDefs);
        }

        [TestMethod]
        public void MaximumProfileTableClass_ConstructorWithFourteenParameters_SetsMaxStackElementsPropertyToValueOfEleventhParameter_IfParametersAreWithinRange()
        {
            int testParam00 = _rnd.NextUShort();
            int testParam01 = _rnd.NextUShort();
            int testParam02 = _rnd.NextUShort();
            int testParam03 = _rnd.NextUShort();
            int testParam04 = _rnd.NextUShort();
            int testParam05 = _rnd.NextUShort();
            int testParam06 = _rnd.NextUShort();
            int testParam07 = _rnd.NextUShort();
            int testParam08 = _rnd.NextUShort();
            int testParam09 = _rnd.NextUShort();
            int testParam10 = _rnd.NextUShort();
            int testParam11 = _rnd.NextUShort();
            int testParam12 = _rnd.NextUShort();
            int testParam13 = _rnd.NextUShort();

            MaximumProfileTable testOutput = new(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07, testParam08,
                testParam09, testParam10, testParam11, testParam12, testParam13);

            Assert.AreEqual(testParam10, testOutput.MaxStackElements);
        }

        [TestMethod]
        public void MaximumProfileTableClass_ConstructorWithFourteenParameters_SetsMaxSizeOfInstructionsPropertyToValueOfTwelfthParameter_IfParametersAreWithinRange()
        {
            int testParam00 = _rnd.NextUShort();
            int testParam01 = _rnd.NextUShort();
            int testParam02 = _rnd.NextUShort();
            int testParam03 = _rnd.NextUShort();
            int testParam04 = _rnd.NextUShort();
            int testParam05 = _rnd.NextUShort();
            int testParam06 = _rnd.NextUShort();
            int testParam07 = _rnd.NextUShort();
            int testParam08 = _rnd.NextUShort();
            int testParam09 = _rnd.NextUShort();
            int testParam10 = _rnd.NextUShort();
            int testParam11 = _rnd.NextUShort();
            int testParam12 = _rnd.NextUShort();
            int testParam13 = _rnd.NextUShort();

            MaximumProfileTable testOutput = new(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07, testParam08,
                testParam09, testParam10, testParam11, testParam12, testParam13);

            Assert.AreEqual(testParam11, testOutput.MaxSizeOfInstructions);
        }

        [TestMethod]
        public void MaximumProfileTableClass_ConstructorWithFourteenParameters_SetsMaxComponentElementsPropertyToValueOfThirteenthParameter_IfParametersAreWithinRange()
        {
            int testParam00 = _rnd.NextUShort();
            int testParam01 = _rnd.NextUShort();
            int testParam02 = _rnd.NextUShort();
            int testParam03 = _rnd.NextUShort();
            int testParam04 = _rnd.NextUShort();
            int testParam05 = _rnd.NextUShort();
            int testParam06 = _rnd.NextUShort();
            int testParam07 = _rnd.NextUShort();
            int testParam08 = _rnd.NextUShort();
            int testParam09 = _rnd.NextUShort();
            int testParam10 = _rnd.NextUShort();
            int testParam11 = _rnd.NextUShort();
            int testParam12 = _rnd.NextUShort();
            int testParam13 = _rnd.NextUShort();

            MaximumProfileTable testOutput = new(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07, testParam08,
                testParam09, testParam10, testParam11, testParam12, testParam13);

            Assert.AreEqual(testParam12, testOutput.MaxComponentElements);
        }

        [TestMethod]
        public void MaximumProfileTableClass_ConstructorWithFourteenParameters_SetsMaxComponentDepthPropertyToValueOfFourteenthParameter_IfParametersAreWithinRange()
        {
            int testParam00 = _rnd.NextUShort();
            int testParam01 = _rnd.NextUShort();
            int testParam02 = _rnd.NextUShort();
            int testParam03 = _rnd.NextUShort();
            int testParam04 = _rnd.NextUShort();
            int testParam05 = _rnd.NextUShort();
            int testParam06 = _rnd.NextUShort();
            int testParam07 = _rnd.NextUShort();
            int testParam08 = _rnd.NextUShort();
            int testParam09 = _rnd.NextUShort();
            int testParam10 = _rnd.NextUShort();
            int testParam11 = _rnd.NextUShort();
            int testParam12 = _rnd.NextUShort();
            int testParam13 = _rnd.NextUShort();

            MaximumProfileTable testOutput = new(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07, testParam08,
                testParam09, testParam10, testParam11, testParam12, testParam13);

            Assert.AreEqual(testParam13, testOutput.MaxComponentDepth);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MaximumProfileTableClass_FromBytesMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            byte[] testParam0 = null;
            int testParam1 = _rnd.Next();
            int testParam2 = _rnd.Next();

            _ = MaximumProfileTable.FromBytes(testParam0, testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MaximumProfileTableClass_FromBytesMethod_ThrowsArgumentOutOfRangeException_IfSecondParameterIsNegative()
        {
            int paramLen = _rnd.Next(32, 64);
            byte[] testParam0 = new byte[paramLen];
            int testParam1 = -_rnd.Next(1, testParam0.Length - 32);
            int testParam2 = testParam0.Length + testParam1;

            _ = MaximumProfileTable.FromBytes(testParam0, testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MaximumProfileTableClass_FromBytesMethod_ThrowsArgumentOutOfRangeException_IfThirdParameterIsNegative()
        {
            int paramLen = _rnd.Next(32, 64);
            byte[] testParam0 = new byte[paramLen];
            int testParam1 = _rnd.Next(testParam0.Length - 32);
            int testParam2 = -testParam0.Length + testParam1;

            _ = MaximumProfileTable.FromBytes(testParam0, testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MaximumProfileTableClass_FromBytesMethod_ThrowsArgumentOutOfRangeException_IfThirdParameterIsLessThanFour()
        {
            int paramLen = _rnd.Next(32, 64);
            byte[] testParam0 = new byte[paramLen];
            int testParam1 = _rnd.Next(testParam0.Length - 32);
            int testParam2 = _rnd.Next(4);

            _ = MaximumProfileTable.FromBytes(testParam0, testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void MaximumProfileTableClass_FromBytesMethod_ThrowsInvalidOperationException_IfFirstFourBytesDoNotConsistOfEither20480Or65536()
        {
            int paramLen = _rnd.Next(32, 64);
            byte[] testParam0 = new byte[paramLen];
            _rnd.NextBytes(testParam0);
            int testParam1 = _rnd.Next(testParam0.Length - 32);
            int testParam2 = _rnd.Next(32, testParam0.Length - testParam1);
            int testVersion;
            do
            {
                testVersion = _rnd.Next();
            } while (testVersion == 20480 || testVersion == 65536);
            testParam0.WriteIntAt(testParam1, testVersion);

            _ = MaximumProfileTable.FromBytes(testParam0, testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void MaximumProfileTableClass_FromBytesMethod_ThrowsInvalidOperationException_IfFirstFourBytesEqual20480AndThirdParameterIsLessThan6()
        {
            int paramLen = _rnd.Next(32, 64);
            byte[] testParam0 = new byte[paramLen];
            _rnd.NextBytes(testParam0);
            int testParam1 = _rnd.Next(testParam0.Length - 32);
            int testParam2 = _rnd.Next(4, 6);
            testParam0.WriteIntAt(testParam1, 20480);

            _ = MaximumProfileTable.FromBytes(testParam0, testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void MaximumProfileTableClass_FromBytesMethod_ThrowsInvalidOperationException_IfFirstFourBytesEqual65536AndThirdParameterIsLessThan32()
        {
            int paramLen = _rnd.Next(32, 64);
            byte[] testParam0 = new byte[paramLen];
            _rnd.NextBytes(testParam0);
            int testParam1 = _rnd.Next(testParam0.Length - 32);
            int testParam2 = _rnd.Next(4, 32);
            testParam0.WriteIntAt(testParam1, 65536);

            _ = MaximumProfileTable.FromBytes(testParam0, testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        public void MaximumProfileTableClass_FromBytesMethod_ReturnsObjectWithCorrectTableTagProperty_IfFirstFourBytesEqual20480()
        {
            int paramLen = _rnd.Next(32, 64);
            byte[] testParam0 = new byte[paramLen];
            _rnd.NextBytes(testParam0);
            int testParam1 = _rnd.Next(testParam0.Length - 32);
            int testParam2 = _rnd.Next(32, testParam0.Length - testParam1);
            testParam0.WriteIntAt(testParam1, 20480);

            MaximumProfileTable testOutput = MaximumProfileTable.FromBytes(testParam0, testParam1, testParam2);

            Assert.AreEqual("maxp", testOutput.TableTag.Value);
        }

        [TestMethod]
        public void MaximumProfileTableClass_FromBytesMethod_ReturnsObjectWithKindPropertyEqualToCff_IfFirstFourBytesEqual20480()
        {
            int paramLen = _rnd.Next(32, 64);
            byte[] testParam0 = new byte[paramLen];
            _rnd.NextBytes(testParam0);
            int testParam1 = _rnd.Next(testParam0.Length - 32);
            int testParam2 = _rnd.Next(32, testParam0.Length - testParam1);
            testParam0.WriteIntAt(testParam1, 20480);

            MaximumProfileTable testOutput = MaximumProfileTable.FromBytes(testParam0, testParam1, testParam2);

            Assert.AreEqual(FontKind.Cff, testOutput.Kind);
        }

        [TestMethod]
        public void MaximumProfileTableClass_FromBytesMethod_ReturnsObjectWithCorrectGlyphCountProperty_IfFirstFourBytesEqual20480()
        {
            int paramLen = _rnd.Next(32, 64);
            byte[] testParam0 = new byte[paramLen];
            _rnd.NextBytes(testParam0);
            int testParam1 = _rnd.Next(testParam0.Length - 32);
            int testParam2 = _rnd.Next(32, testParam0.Length - testParam1);
            ushort expectedValue = _rnd.NextUShort();
            testParam0.WriteIntAt(testParam1, 20480);
            testParam0.WriteUShortAt(testParam1 + 4, expectedValue);

            MaximumProfileTable testOutput = MaximumProfileTable.FromBytes(testParam0, testParam1, testParam2);

            Assert.AreEqual(expectedValue, testOutput.GlyphCount);
        }

        [TestMethod]
        public void MaximumProfileTableClass_FromBytesMethod_ReturnsObjectWithCorrectTableTagProperty_IfFirstFourBytesEqual65536()
        {
            int paramLen = _rnd.Next(32, 64);
            byte[] testParam0 = new byte[paramLen];
            _rnd.NextBytes(testParam0);
            int testParam1 = _rnd.Next(testParam0.Length - 32);
            int testParam2 = _rnd.Next(32, testParam0.Length - testParam1);
            testParam0.WriteIntAt(testParam1, 65536);

            MaximumProfileTable testOutput = MaximumProfileTable.FromBytes(testParam0, testParam1, testParam2);

            Assert.AreEqual("maxp", testOutput.TableTag.Value);
        }

        [TestMethod]
        public void MaximumProfileTableClass_FromBytesMethod_ReturnsObjectWithKindPropertyEqualToTrueType_IfFirstFourBytesEqual65536()
        {
            int paramLen = _rnd.Next(32, 64);
            byte[] testParam0 = new byte[paramLen];
            _rnd.NextBytes(testParam0);
            int testParam1 = _rnd.Next(testParam0.Length - 32);
            int testParam2 = _rnd.Next(32, testParam0.Length - testParam1);
            testParam0.WriteIntAt(testParam1, 65536);

            MaximumProfileTable testOutput = MaximumProfileTable.FromBytes(testParam0, testParam1, testParam2);

            Assert.AreEqual(FontKind.TrueType, testOutput.Kind);
        }

        [TestMethod]
        public void MaximumProfileTableClass_FromBytesMethod_ReturnsObjectWithCorrectGlyphCountProperty_IfFirstFourBytesEqual65536()
        {
            int paramLen = _rnd.Next(32, 64);
            byte[] testParam0 = new byte[paramLen];
            _rnd.NextBytes(testParam0);
            int testParam1 = _rnd.Next(testParam0.Length - 32);
            int testParam2 = _rnd.Next(32, testParam0.Length - testParam1);
            ushort expectedValue = _rnd.NextUShort();
            testParam0.WriteIntAt(testParam1, 65536);
            testParam0.WriteUShortAt(testParam1 + 4, expectedValue);

            MaximumProfileTable testOutput = MaximumProfileTable.FromBytes(testParam0, testParam1, testParam2);

            Assert.AreEqual(expectedValue, testOutput.GlyphCount);
        }

        [TestMethod]
        public void MaximumProfileTableClass_FromBytesMethod_ReturnsObjectWithCorrectMaxPointsProperty_IfFirstFourBytesEqual65536()
        {
            int paramLen = _rnd.Next(32, 64);
            byte[] testParam0 = new byte[paramLen];
            _rnd.NextBytes(testParam0);
            int testParam1 = _rnd.Next(testParam0.Length - 32);
            int testParam2 = _rnd.Next(32, testParam0.Length - testParam1);
            ushort expectedValue = _rnd.NextUShort();
            testParam0.WriteIntAt(testParam1, 65536);
            testParam0.WriteUShortAt(testParam1 + 6, expectedValue);

            MaximumProfileTable testOutput = MaximumProfileTable.FromBytes(testParam0, testParam1, testParam2);

            Assert.AreEqual(expectedValue, testOutput.MaxPoints);
        }

        [TestMethod]
        public void MaximumProfileTableClass_FromBytesMethod_ReturnsObjectWithCorrectMaxContoursProperty_IfFirstFourBytesEqual65536()
        {
            int paramLen = _rnd.Next(32, 64);
            byte[] testParam0 = new byte[paramLen];
            _rnd.NextBytes(testParam0);
            int testParam1 = _rnd.Next(testParam0.Length - 32);
            int testParam2 = _rnd.Next(32, testParam0.Length - testParam1);
            ushort expectedValue = _rnd.NextUShort();
            testParam0.WriteIntAt(testParam1, 65536);
            testParam0.WriteUShortAt(testParam1 + 8, expectedValue);

            MaximumProfileTable testOutput = MaximumProfileTable.FromBytes(testParam0, testParam1, testParam2);

            Assert.AreEqual(expectedValue, testOutput.MaxContours);
        }

        [TestMethod]
        public void MaximumProfileTableClass_FromBytesMethod_ReturnsObjectWithCorrectMaxCompositePointsProperty_IfFirstFourBytesEqual65536()
        {
            int paramLen = _rnd.Next(32, 64);
            byte[] testParam0 = new byte[paramLen];
            _rnd.NextBytes(testParam0);
            int testParam1 = _rnd.Next(testParam0.Length - 32);
            int testParam2 = _rnd.Next(32, testParam0.Length - testParam1);
            ushort expectedValue = _rnd.NextUShort();
            testParam0.WriteIntAt(testParam1, 65536);
            testParam0.WriteUShortAt(testParam1 + 10, expectedValue);

            MaximumProfileTable testOutput = MaximumProfileTable.FromBytes(testParam0, testParam1, testParam2);

            Assert.AreEqual(expectedValue, testOutput.MaxCompositePoints);
        }

        [TestMethod]
        public void MaximumProfileTableClass_FromBytesMethod_ReturnsObjectWithCorrectMaxCompositeContoursProperty_IfFirstFourBytesEqual65536()
        {
            int paramLen = _rnd.Next(32, 64);
            byte[] testParam0 = new byte[paramLen];
            _rnd.NextBytes(testParam0);
            int testParam1 = _rnd.Next(testParam0.Length - 32);
            int testParam2 = _rnd.Next(32, testParam0.Length - testParam1);
            ushort expectedValue = _rnd.NextUShort();
            testParam0.WriteIntAt(testParam1, 65536);
            testParam0.WriteUShortAt(testParam1 + 12, expectedValue);

            MaximumProfileTable testOutput = MaximumProfileTable.FromBytes(testParam0, testParam1, testParam2);

            Assert.AreEqual(expectedValue, testOutput.MaxCompositeContours);
        }

        [TestMethod]
        public void MaximumProfileTableClass_FromBytesMethod_ReturnsObjectWithCorrectMaxZonesProperty_IfFirstFourBytesEqual65536()
        {
            int paramLen = _rnd.Next(32, 64);
            byte[] testParam0 = new byte[paramLen];
            _rnd.NextBytes(testParam0);
            int testParam1 = _rnd.Next(testParam0.Length - 32);
            int testParam2 = _rnd.Next(32, testParam0.Length - testParam1);
            ushort expectedValue = _rnd.NextUShort();
            testParam0.WriteIntAt(testParam1, 65536);
            testParam0.WriteUShortAt(testParam1 + 14, expectedValue);

            MaximumProfileTable testOutput = MaximumProfileTable.FromBytes(testParam0, testParam1, testParam2);

            Assert.AreEqual(expectedValue, testOutput.MaxZones);
        }

        [TestMethod]
        public void MaximumProfileTableClass_FromBytesMethod_ReturnsObjectWithCorrectMaxTwilightZonePointsProperty_IfFirstFourBytesEqual65536()
        {
            int paramLen = _rnd.Next(32, 64);
            byte[] testParam0 = new byte[paramLen];
            _rnd.NextBytes(testParam0);
            int testParam1 = _rnd.Next(testParam0.Length - 32);
            int testParam2 = _rnd.Next(32, testParam0.Length - testParam1);
            ushort expectedValue = _rnd.NextUShort();
            testParam0.WriteIntAt(testParam1, 65536);
            testParam0.WriteUShortAt(testParam1 + 16, expectedValue);

            MaximumProfileTable testOutput = MaximumProfileTable.FromBytes(testParam0, testParam1, testParam2);

            Assert.AreEqual(expectedValue, testOutput.MaxTwilightZonePoints);
        }

        [TestMethod]
        public void MaximumProfileTableClass_FromBytesMethod_ReturnsObjectWithCorrectMaxStorageProperty_IfFirstFourBytesEqual65536()
        {
            int paramLen = _rnd.Next(32, 64);
            byte[] testParam0 = new byte[paramLen];
            _rnd.NextBytes(testParam0);
            int testParam1 = _rnd.Next(testParam0.Length - 32);
            int testParam2 = _rnd.Next(32, testParam0.Length - testParam1);
            ushort expectedValue = _rnd.NextUShort();
            testParam0.WriteIntAt(testParam1, 65536);
            testParam0.WriteUShortAt(testParam1 + 18, expectedValue);

            MaximumProfileTable testOutput = MaximumProfileTable.FromBytes(testParam0, testParam1, testParam2);

            Assert.AreEqual(expectedValue, testOutput.MaxStorage);
        }

        [TestMethod]
        public void MaximumProfileTableClass_FromBytesMethod_ReturnsObjectWithCorrectMaxFunctionDefsProperty_IfFirstFourBytesEqual65536()
        {
            int paramLen = _rnd.Next(32, 64);
            byte[] testParam0 = new byte[paramLen];
            _rnd.NextBytes(testParam0);
            int testParam1 = _rnd.Next(testParam0.Length - 32);
            int testParam2 = _rnd.Next(32, testParam0.Length - testParam1);
            ushort expectedValue = _rnd.NextUShort();
            testParam0.WriteIntAt(testParam1, 65536);
            testParam0.WriteUShortAt(testParam1 + 20, expectedValue);

            MaximumProfileTable testOutput = MaximumProfileTable.FromBytes(testParam0, testParam1, testParam2);

            Assert.AreEqual(expectedValue, testOutput.MaxFunctionDefs);
        }

        [TestMethod]
        public void MaximumProfileTableClass_FromBytesMethod_ReturnsObjectWithCorrectMaxInstructionDefsProperty_IfFirstFourBytesEqual65536()
        {
            int paramLen = _rnd.Next(32, 64);
            byte[] testParam0 = new byte[paramLen];
            _rnd.NextBytes(testParam0);
            int testParam1 = _rnd.Next(testParam0.Length - 32);
            int testParam2 = _rnd.Next(32, testParam0.Length - testParam1);
            ushort expectedValue = _rnd.NextUShort();
            testParam0.WriteIntAt(testParam1, 65536);
            testParam0.WriteUShortAt(testParam1 + 22, expectedValue);

            MaximumProfileTable testOutput = MaximumProfileTable.FromBytes(testParam0, testParam1, testParam2);

            Assert.AreEqual(expectedValue, testOutput.MaxInstructionDefs);
        }

        [TestMethod]
        public void MaximumProfileTableClass_FromBytesMethod_ReturnsObjectWithCorrectMaxStackElementsProperty_IfFirstFourBytesEqual65536()
        {
            int paramLen = _rnd.Next(32, 64);
            byte[] testParam0 = new byte[paramLen];
            _rnd.NextBytes(testParam0);
            int testParam1 = _rnd.Next(testParam0.Length - 32);
            int testParam2 = _rnd.Next(32, testParam0.Length - testParam1);
            ushort expectedValue = _rnd.NextUShort();
            testParam0.WriteIntAt(testParam1, 65536);
            testParam0.WriteUShortAt(testParam1 + 24, expectedValue);

            MaximumProfileTable testOutput = MaximumProfileTable.FromBytes(testParam0, testParam1, testParam2);

            Assert.AreEqual(expectedValue, testOutput.MaxStackElements);
        }

        [TestMethod]
        public void MaximumProfileTableClass_FromBytesMethod_ReturnsObjectWithCorrectMaxSizeOfInstructionsProperty_IfFirstFourBytesEqual65536()
        {
            int paramLen = _rnd.Next(32, 64);
            byte[] testParam0 = new byte[paramLen];
            _rnd.NextBytes(testParam0);
            int testParam1 = _rnd.Next(testParam0.Length - 32);
            int testParam2 = _rnd.Next(32, testParam0.Length - testParam1);
            ushort expectedValue = _rnd.NextUShort();
            testParam0.WriteIntAt(testParam1, 65536);
            testParam0.WriteUShortAt(testParam1 + 26, expectedValue);

            MaximumProfileTable testOutput = MaximumProfileTable.FromBytes(testParam0, testParam1, testParam2);

            Assert.AreEqual(expectedValue, testOutput.MaxSizeOfInstructions);
        }

        [TestMethod]
        public void MaximumProfileTableClass_FromBytesMethod_ReturnsObjectWithCorrectMaxComponentElementsProperty_IfFirstFourBytesEqual65536()
        {
            int paramLen = _rnd.Next(32, 64);
            byte[] testParam0 = new byte[paramLen];
            _rnd.NextBytes(testParam0);
            int testParam1 = _rnd.Next(testParam0.Length - 32);
            int testParam2 = _rnd.Next(32, testParam0.Length - testParam1);
            ushort expectedValue = _rnd.NextUShort();
            testParam0.WriteIntAt(testParam1, 65536);
            testParam0.WriteUShortAt(testParam1 + 28, expectedValue);

            MaximumProfileTable testOutput = MaximumProfileTable.FromBytes(testParam0, testParam1, testParam2);

            Assert.AreEqual(expectedValue, testOutput.MaxComponentElements);
        }

        [TestMethod]
        public void MaximumProfileTableClass_FromBytesMethod_ReturnsObjectWithCorrectMaxComponentDepthProperty_IfFirstFourBytesEqual65536()
        {
            int paramLen = _rnd.Next(32, 64);
            byte[] testParam0 = new byte[paramLen];
            _rnd.NextBytes(testParam0);
            int testParam1 = _rnd.Next(testParam0.Length - 32);
            int testParam2 = _rnd.Next(32, testParam0.Length - testParam1);
            ushort expectedValue = _rnd.NextUShort();
            testParam0.WriteIntAt(testParam1, 65536);
            testParam0.WriteUShortAt(testParam1 + 30, expectedValue);

            MaximumProfileTable testOutput = MaximumProfileTable.FromBytes(testParam0, testParam1, testParam2);

            Assert.AreEqual(expectedValue, testOutput.MaxComponentDepth);
        }

        [TestMethod]
        public void MaximumProfileTableClass_DumpMethod_ReturnsObject()
        {
            var testObject = GetTable();

            var testOutput = testObject.Dump();

            Assert.IsNotNull(testOutput);
        }

        [TestMethod]
        public void MaximumProfileTableClass_DumpMethod_ReturnsObjectWhichContainsTableNameInInfoProperty()
        {
            var testObject = GetTable();

            var testOutput = testObject.Dump();

            Assert.IsTrue(testOutput.Info.Contains("maxp", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void MaximumProfileTableClass_DumpMethod_ReturnsObjectWithBlockHeaderPropertyWithTwoColumns()
        {
            var testObject = GetTable();

            var testOutput = testObject.Dump();

            Assert.AreEqual(2, testOutput.BlockHeader.Count);
        }

        [TestMethod]
        public void MaximumProfileTableClass_DumpMethod_ReturnsObjectWithBlockHeaderPropertyWithFirstColumnCalledField()
        {
            var testObject = GetTable();

            var testOutput = testObject.Dump();

            Assert.AreEqual("Field", testOutput.BlockHeader[0].HeaderText);
        }

        [TestMethod]
        public void MaximumProfileTableClass_DumpMethod_ReturnsObjectWithBlockHeaderPropertyWithSecondColumnCalledValue()
        {
            var testObject = GetTable();

            var testOutput = testObject.Dump();

            Assert.AreEqual("Value", testOutput.BlockHeader[1].HeaderText);
        }

        [TestMethod]
        public void MaximumProfileTableClass_DumpMethod_ReturnsObjectWithDataWithCorrectGlyphCountRecord()
        {
            var testObject = GetTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "GlyphCount");
            Assert.AreEqual(testObject.GlyphCount.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void MaximumProfileTableClass_DumpMethod_ReturnsObjectWithDataWithOneRecord_IfFontTypeIsCff()
        {
            var testObject = GetCffTable();

            var testOutput = testObject.Dump();

            Assert.AreEqual(1, testOutput.BlockData.Count);
        }

        [TestMethod]
        public void MaximumProfileTableClass_DumpMethod_ReturnsObjectWithDataWithCorrectMaxPointsRecord_IfFontTypeIsTruetype()
        {
            var testObject = GetTruetypeTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "MaxPoints");
            Assert.AreEqual(testObject.MaxPoints.Value.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void MaximumProfileTableClass_DumpMethod_ReturnsObjectWithDataWithCorrectMaxContoursRecord_IfFontTypeIsTruetype()
        {
            var testObject = GetTruetypeTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "MaxContours");
            Assert.AreEqual(testObject.MaxContours.Value.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void MaximumProfileTableClass_DumpMethod_ReturnsObjectWithDataWithCorrectMaxCompositePointsRecord_IfFontTypeIsTruetype()
        {
            var testObject = GetTruetypeTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "MaxCompositePoints");
            Assert.AreEqual(testObject.MaxCompositePoints.Value.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void MaximumProfileTableClass_DumpMethod_ReturnsObjectWithDataWithCorrectMaxCompositeContoursRecord_IfFontTypeIsTruetype()
        {
            var testObject = GetTruetypeTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "MaxCompositeContours");
            Assert.AreEqual(testObject.MaxCompositeContours.Value.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void MaximumProfileTableClass_DumpMethod_ReturnsObjectWithDataWithCorrectMaxZonesRecord_IfFontTypeIsTruetype()
        {
            var testObject = GetTruetypeTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "MaxZones");
            Assert.AreEqual(testObject.MaxZones.Value.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void MaximumProfileTableClass_DumpMethod_ReturnsObjectWithDataWithCorrectMaxTwilightZonePointsRecord_IfFontTypeIsTruetype()
        {
            var testObject = GetTruetypeTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "MaxTwilightZonePoints");
            Assert.AreEqual(testObject.MaxTwilightZonePoints.Value.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void MaximumProfileTableClass_DumpMethod_ReturnsObjectWithDataWithCorrectMaxStorageRecord_IfFontTypeIsTruetype()
        {
            var testObject = GetTruetypeTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "MaxStorage");
            Assert.AreEqual(testObject.MaxStorage.Value.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void MaximumProfileTableClass_DumpMethod_ReturnsObjectWithDataWithCorrectMaxFunctionDefsRecord_IfFontTypeIsTruetype()
        {
            var testObject = GetTruetypeTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "MaxFunctionDefs");
            Assert.AreEqual(testObject.MaxFunctionDefs.Value.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void MaximumProfileTableClass_DumpMethod_ReturnsObjectWithDataWithCorrectMaxInstructionDefsRecord_IfFontTypeIsTruetype()
        {
            var testObject = GetTruetypeTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "MaxInstructionDefs");
            Assert.AreEqual(testObject.MaxInstructionDefs.Value.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void MaximumProfileTableClass_DumpMethod_ReturnsObjectWithDataWithCorrectMaxStackElementsRecord_IfFontTypeIsTruetype()
        {
            var testObject = GetTruetypeTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "MaxStackElements");
            Assert.AreEqual(testObject.MaxStackElements.Value.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void MaximumProfileTableClass_DumpMethod_ReturnsObjectWithDataWithCorrectMaxSizeOfInstructionsRecord_IfFontTypeIsTruetype()
        {
            var testObject = GetTruetypeTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "MaxSizeOfInstructions");
            Assert.AreEqual(testObject.MaxSizeOfInstructions.Value.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void MaximumProfileTableClass_DumpMethod_ReturnsObjectWithDataWithCorrectMaxComponentElementsRecord_IfFontTypeIsTruetype()
        {
            var testObject = GetTruetypeTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "MaxComponentElements");
            Assert.AreEqual(testObject.MaxComponentElements.Value.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void MaximumProfileTableClass_DumpMethod_ReturnsObjectWithDataWithCorrectMaxComponentDepthRecord_IfFontTypeIsTruetype()
        {
            var testObject = GetTruetypeTable();

            var testOutput = testObject.Dump();

            var testRecord = testOutput.BlockData.Single(r => r[0] == "MaxComponentDepth");
            Assert.AreEqual(testObject.MaxComponentDepth.Value.ToString(CultureInfo.CurrentCulture), testRecord[1]);
        }

        [TestMethod]
        public void MaximumProfileTableClass_DumpMethod_ReturnsObjectWithDataWithFourteenRecords_IfFontTypeIsTruetype()
        {
            var testObject = GetTruetypeTable();

            var testOutput = testObject.Dump();

            Assert.AreEqual(14, testOutput.BlockData.Count);
        }

        [TestMethod]
        public void MaximumProfileTableClass_DumpMethod_ReturnsObjectWithNoNestedBlocks()
        {
            var testObject = GetTable();

            var testOutput = testObject.Dump();

            Assert.AreEqual(0, testOutput.NestedData.Count());
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores
#pragma warning restore CA5394 // Do not use insecure randomness

    }
}
