using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.FontTools.Afm;
using Unicorn.FontTools.Tests.Utility;

namespace Unicorn.FontTools.Tests.Unit.Afm
{
    [TestClass]
    public class AfmFontMetricsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void AfmFontMetricsClass_ConstructorWithTwentyFourParameters_SetsFontNamePropertyToValueOfFirstParameter()
        {
            string testParam00 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam01 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam02 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam03 = _rnd.NextString(_rnd.Next(1, 10));
            BoundingBox testParam04 = _rnd.NextAfmBoundingBox();
            string testParam05 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam06 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam07 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam08 = _rnd.NextNullableInt();
            int? testParam09 = _rnd.NextNullableInt();
            string testParam10 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam11 = _rnd.NextNullableInt();
            bool? testParam12 = _rnd.NextNullableBoolean();
            Vector? testParam13 = _rnd.NextNullableAfmVector();
            bool? testParam14 = _rnd.NextNullableBoolean();
            bool? testParam15 = _rnd.NextNullableBoolean();
            decimal? testParam16 = _rnd.NextNullableDecimal();
            decimal? testParam17 = _rnd.NextNullableDecimal();
            decimal? testParam18 = _rnd.NextNullableDecimal();
            decimal? testParam19 = _rnd.NextNullableDecimal();
            decimal? testParam20 = _rnd.NextNullableDecimal();
            decimal? testParam21 = _rnd.NextNullableDecimal();
            DirectionMetrics? testParam22 = _rnd.NextNullableAfmDirectionMetrics();
            DirectionMetrics? testParam23 = _rnd.NextNullableAfmDirectionMetrics();

            AfmFontMetrics testOutput = new AfmFontMetrics(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07,
                testParam08, testParam09, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17, testParam18,
                testParam19, testParam20, testParam21, testParam22, testParam23);

            Assert.AreEqual(testParam00, testOutput.FontName);
        }

        [TestMethod]
        public void AfmFontMetricsClass_ConstructorWithTwentyFourParameters_SetsFullNamePropertyToValueOfSecondParameter()
        {
            string testParam00 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam01 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam02 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam03 = _rnd.NextString(_rnd.Next(1, 10));
            BoundingBox testParam04 = _rnd.NextAfmBoundingBox();
            string testParam05 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam06 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam07 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam08 = _rnd.NextNullableInt();
            int? testParam09 = _rnd.NextNullableInt();
            string testParam10 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam11 = _rnd.NextNullableInt();
            bool? testParam12 = _rnd.NextNullableBoolean();
            Vector? testParam13 = _rnd.NextNullableAfmVector();
            bool? testParam14 = _rnd.NextNullableBoolean();
            bool? testParam15 = _rnd.NextNullableBoolean();
            decimal? testParam16 = _rnd.NextNullableDecimal();
            decimal? testParam17 = _rnd.NextNullableDecimal();
            decimal? testParam18 = _rnd.NextNullableDecimal();
            decimal? testParam19 = _rnd.NextNullableDecimal();
            decimal? testParam20 = _rnd.NextNullableDecimal();
            decimal? testParam21 = _rnd.NextNullableDecimal();
            DirectionMetrics? testParam22 = _rnd.NextNullableAfmDirectionMetrics();
            DirectionMetrics? testParam23 = _rnd.NextNullableAfmDirectionMetrics();

            AfmFontMetrics testOutput = new AfmFontMetrics(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07,
                testParam08, testParam09, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17, testParam18,
                testParam19, testParam20, testParam21, testParam22, testParam23);

            Assert.AreEqual(testParam01, testOutput.FullName);
        }

        [TestMethod]
        public void AfmFontMetricsClass_ConstructorWithTwentyFourParameters_SetsFamilyNamePropertyToValueOfThirdParameter()
        {
            string testParam00 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam01 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam02 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam03 = _rnd.NextString(_rnd.Next(1, 10));
            BoundingBox testParam04 = _rnd.NextAfmBoundingBox();
            string testParam05 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam06 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam07 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam08 = _rnd.NextNullableInt();
            int? testParam09 = _rnd.NextNullableInt();
            string testParam10 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam11 = _rnd.NextNullableInt();
            bool? testParam12 = _rnd.NextNullableBoolean();
            Vector? testParam13 = _rnd.NextNullableAfmVector();
            bool? testParam14 = _rnd.NextNullableBoolean();
            bool? testParam15 = _rnd.NextNullableBoolean();
            decimal? testParam16 = _rnd.NextNullableDecimal();
            decimal? testParam17 = _rnd.NextNullableDecimal();
            decimal? testParam18 = _rnd.NextNullableDecimal();
            decimal? testParam19 = _rnd.NextNullableDecimal();
            decimal? testParam20 = _rnd.NextNullableDecimal();
            decimal? testParam21 = _rnd.NextNullableDecimal();
            DirectionMetrics? testParam22 = _rnd.NextNullableAfmDirectionMetrics();
            DirectionMetrics? testParam23 = _rnd.NextNullableAfmDirectionMetrics();

            AfmFontMetrics testOutput = new AfmFontMetrics(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07,
                testParam08, testParam09, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17, testParam18,
                testParam19, testParam20, testParam21, testParam22, testParam23);

            Assert.AreEqual(testParam02, testOutput.FamilyName);
        }

        [TestMethod]
        public void AfmFontMetricsClass_ConstructorWithTwentyFourParameters_SetsWeightPropertyToValueOfFourthParameter()
        {
            string testParam00 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam01 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam02 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam03 = _rnd.NextString(_rnd.Next(1, 10));
            BoundingBox testParam04 = _rnd.NextAfmBoundingBox();
            string testParam05 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam06 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam07 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam08 = _rnd.NextNullableInt();
            int? testParam09 = _rnd.NextNullableInt();
            string testParam10 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam11 = _rnd.NextNullableInt();
            bool? testParam12 = _rnd.NextNullableBoolean();
            Vector? testParam13 = _rnd.NextNullableAfmVector();
            bool? testParam14 = _rnd.NextNullableBoolean();
            bool? testParam15 = _rnd.NextNullableBoolean();
            decimal? testParam16 = _rnd.NextNullableDecimal();
            decimal? testParam17 = _rnd.NextNullableDecimal();
            decimal? testParam18 = _rnd.NextNullableDecimal();
            decimal? testParam19 = _rnd.NextNullableDecimal();
            decimal? testParam20 = _rnd.NextNullableDecimal();
            decimal? testParam21 = _rnd.NextNullableDecimal();
            DirectionMetrics? testParam22 = _rnd.NextNullableAfmDirectionMetrics();
            DirectionMetrics? testParam23 = _rnd.NextNullableAfmDirectionMetrics();

            AfmFontMetrics testOutput = new AfmFontMetrics(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07,
                testParam08, testParam09, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17, testParam18,
                testParam19, testParam20, testParam21, testParam22, testParam23);

            Assert.AreEqual(testParam03, testOutput.Weight);
        }

        [TestMethod]
        public void AfmFontMetricsClass_ConstructorWithTwentyFourParameters_SetsFontBoundingBoxPropertyToValueOfFifthParameter()
        {
            string testParam00 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam01 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam02 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam03 = _rnd.NextString(_rnd.Next(1, 10));
            BoundingBox testParam04 = _rnd.NextAfmBoundingBox();
            string testParam05 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam06 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam07 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam08 = _rnd.NextNullableInt();
            int? testParam09 = _rnd.NextNullableInt();
            string testParam10 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam11 = _rnd.NextNullableInt();
            bool? testParam12 = _rnd.NextNullableBoolean();
            Vector? testParam13 = _rnd.NextNullableAfmVector();
            bool? testParam14 = _rnd.NextNullableBoolean();
            bool? testParam15 = _rnd.NextNullableBoolean();
            decimal? testParam16 = _rnd.NextNullableDecimal();
            decimal? testParam17 = _rnd.NextNullableDecimal();
            decimal? testParam18 = _rnd.NextNullableDecimal();
            decimal? testParam19 = _rnd.NextNullableDecimal();
            decimal? testParam20 = _rnd.NextNullableDecimal();
            decimal? testParam21 = _rnd.NextNullableDecimal();
            DirectionMetrics? testParam22 = _rnd.NextNullableAfmDirectionMetrics();
            DirectionMetrics? testParam23 = _rnd.NextNullableAfmDirectionMetrics();

            AfmFontMetrics testOutput = new AfmFontMetrics(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07,
                testParam08, testParam09, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17, testParam18,
                testParam19, testParam20, testParam21, testParam22, testParam23);

            Assert.AreEqual(testParam04, testOutput.FontBoundingBox);
        }

        [TestMethod]
        public void AfmFontMetricsClass_ConstructorWithTwentyFourParameters_SetsVersionPropertyToValueOfSixthParameter()
        {
            string testParam00 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam01 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam02 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam03 = _rnd.NextString(_rnd.Next(1, 10));
            BoundingBox testParam04 = _rnd.NextAfmBoundingBox();
            string testParam05 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam06 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam07 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam08 = _rnd.NextNullableInt();
            int? testParam09 = _rnd.NextNullableInt();
            string testParam10 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam11 = _rnd.NextNullableInt();
            bool? testParam12 = _rnd.NextNullableBoolean();
            Vector? testParam13 = _rnd.NextNullableAfmVector();
            bool? testParam14 = _rnd.NextNullableBoolean();
            bool? testParam15 = _rnd.NextNullableBoolean();
            decimal? testParam16 = _rnd.NextNullableDecimal();
            decimal? testParam17 = _rnd.NextNullableDecimal();
            decimal? testParam18 = _rnd.NextNullableDecimal();
            decimal? testParam19 = _rnd.NextNullableDecimal();
            decimal? testParam20 = _rnd.NextNullableDecimal();
            decimal? testParam21 = _rnd.NextNullableDecimal();
            DirectionMetrics? testParam22 = _rnd.NextNullableAfmDirectionMetrics();
            DirectionMetrics? testParam23 = _rnd.NextNullableAfmDirectionMetrics();

            AfmFontMetrics testOutput = new AfmFontMetrics(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07,
                testParam08, testParam09, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17, testParam18,
                testParam19, testParam20, testParam21, testParam22, testParam23);

            Assert.AreEqual(testParam05, testOutput.Version);
        }

        [TestMethod]
        public void AfmFontMetricsClass_ConstructorWithTwentyFourParameters_SetsNoticePropertyToValueOfSeventhParameter()
        {
            string testParam00 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam01 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam02 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam03 = _rnd.NextString(_rnd.Next(1, 10));
            BoundingBox testParam04 = _rnd.NextAfmBoundingBox();
            string testParam05 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam06 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam07 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam08 = _rnd.NextNullableInt();
            int? testParam09 = _rnd.NextNullableInt();
            string testParam10 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam11 = _rnd.NextNullableInt();
            bool? testParam12 = _rnd.NextNullableBoolean();
            Vector? testParam13 = _rnd.NextNullableAfmVector();
            bool? testParam14 = _rnd.NextNullableBoolean();
            bool? testParam15 = _rnd.NextNullableBoolean();
            decimal? testParam16 = _rnd.NextNullableDecimal();
            decimal? testParam17 = _rnd.NextNullableDecimal();
            decimal? testParam18 = _rnd.NextNullableDecimal();
            decimal? testParam19 = _rnd.NextNullableDecimal();
            decimal? testParam20 = _rnd.NextNullableDecimal();
            decimal? testParam21 = _rnd.NextNullableDecimal();
            DirectionMetrics? testParam22 = _rnd.NextNullableAfmDirectionMetrics();
            DirectionMetrics? testParam23 = _rnd.NextNullableAfmDirectionMetrics();

            AfmFontMetrics testOutput = new AfmFontMetrics(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07,
                testParam08, testParam09, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17, testParam18,
                testParam19, testParam20, testParam21, testParam22, testParam23);

            Assert.AreEqual(testParam06, testOutput.Notice);
        }

        [TestMethod]
        public void AfmFontMetricsClass_ConstructorWithTwentyFourParameters_SetsEncodingSchemePropertyToValueOfEighthParameter()
        {
            string testParam00 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam01 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam02 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam03 = _rnd.NextString(_rnd.Next(1, 10));
            BoundingBox testParam04 = _rnd.NextAfmBoundingBox();
            string testParam05 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam06 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam07 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam08 = _rnd.NextNullableInt();
            int? testParam09 = _rnd.NextNullableInt();
            string testParam10 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam11 = _rnd.NextNullableInt();
            bool? testParam12 = _rnd.NextNullableBoolean();
            Vector? testParam13 = _rnd.NextNullableAfmVector();
            bool? testParam14 = _rnd.NextNullableBoolean();
            bool? testParam15 = _rnd.NextNullableBoolean();
            decimal? testParam16 = _rnd.NextNullableDecimal();
            decimal? testParam17 = _rnd.NextNullableDecimal();
            decimal? testParam18 = _rnd.NextNullableDecimal();
            decimal? testParam19 = _rnd.NextNullableDecimal();
            decimal? testParam20 = _rnd.NextNullableDecimal();
            decimal? testParam21 = _rnd.NextNullableDecimal();
            DirectionMetrics? testParam22 = _rnd.NextNullableAfmDirectionMetrics();
            DirectionMetrics? testParam23 = _rnd.NextNullableAfmDirectionMetrics();

            AfmFontMetrics testOutput = new AfmFontMetrics(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07,
                testParam08, testParam09, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17, testParam18,
                testParam19, testParam20, testParam21, testParam22, testParam23);

            Assert.AreEqual(testParam07, testOutput.EncodingScheme);
        }

        [TestMethod]
        public void AfmFontMetricsClass_ConstructorWithTwentyFourParameters_SetsMappingSchemePropertyToValueOfNinthParameter()
        {
            string testParam00 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam01 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam02 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam03 = _rnd.NextString(_rnd.Next(1, 10));
            BoundingBox testParam04 = _rnd.NextAfmBoundingBox();
            string testParam05 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam06 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam07 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam08 = _rnd.NextNullableInt();
            int? testParam09 = _rnd.NextNullableInt();
            string testParam10 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam11 = _rnd.NextNullableInt();
            bool? testParam12 = _rnd.NextNullableBoolean();
            Vector? testParam13 = _rnd.NextNullableAfmVector();
            bool? testParam14 = _rnd.NextNullableBoolean();
            bool? testParam15 = _rnd.NextNullableBoolean();
            decimal? testParam16 = _rnd.NextNullableDecimal();
            decimal? testParam17 = _rnd.NextNullableDecimal();
            decimal? testParam18 = _rnd.NextNullableDecimal();
            decimal? testParam19 = _rnd.NextNullableDecimal();
            decimal? testParam20 = _rnd.NextNullableDecimal();
            decimal? testParam21 = _rnd.NextNullableDecimal();
            DirectionMetrics? testParam22 = _rnd.NextNullableAfmDirectionMetrics();
            DirectionMetrics? testParam23 = _rnd.NextNullableAfmDirectionMetrics();

            AfmFontMetrics testOutput = new AfmFontMetrics(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07,
                testParam08, testParam09, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17, testParam18,
                testParam19, testParam20, testParam21, testParam22, testParam23);

            Assert.AreEqual(testParam08, testOutput.MappingScheme);
        }

        [TestMethod]
        public void AfmFontMetricsClass_ConstructorWithTwentyFourParameters_SetsEscapeCharacterPropertyToValueOfTenthParameter()
        {
            string testParam00 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam01 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam02 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam03 = _rnd.NextString(_rnd.Next(1, 10));
            BoundingBox testParam04 = _rnd.NextAfmBoundingBox();
            string testParam05 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam06 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam07 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam08 = _rnd.NextNullableInt();
            int? testParam09 = _rnd.NextNullableInt();
            string testParam10 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam11 = _rnd.NextNullableInt();
            bool? testParam12 = _rnd.NextNullableBoolean();
            Vector? testParam13 = _rnd.NextNullableAfmVector();
            bool? testParam14 = _rnd.NextNullableBoolean();
            bool? testParam15 = _rnd.NextNullableBoolean();
            decimal? testParam16 = _rnd.NextNullableDecimal();
            decimal? testParam17 = _rnd.NextNullableDecimal();
            decimal? testParam18 = _rnd.NextNullableDecimal();
            decimal? testParam19 = _rnd.NextNullableDecimal();
            decimal? testParam20 = _rnd.NextNullableDecimal();
            decimal? testParam21 = _rnd.NextNullableDecimal();
            DirectionMetrics? testParam22 = _rnd.NextNullableAfmDirectionMetrics();
            DirectionMetrics? testParam23 = _rnd.NextNullableAfmDirectionMetrics();

            AfmFontMetrics testOutput = new AfmFontMetrics(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07,
                testParam08, testParam09, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17, testParam18,
                testParam19, testParam20, testParam21, testParam22, testParam23);

            Assert.AreEqual(testParam09, testOutput.EscapeCharacter);
        }

        [TestMethod]
        public void AfmFontMetricsClass_ConstructorWithTwentyFourParameters_SetsCharacterSetPropertyToValueOfEleventhParameter()
        {
            string testParam00 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam01 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam02 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam03 = _rnd.NextString(_rnd.Next(1, 10));
            BoundingBox testParam04 = _rnd.NextAfmBoundingBox();
            string testParam05 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam06 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam07 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam08 = _rnd.NextNullableInt();
            int? testParam09 = _rnd.NextNullableInt();
            string testParam10 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam11 = _rnd.NextNullableInt();
            bool? testParam12 = _rnd.NextNullableBoolean();
            Vector? testParam13 = _rnd.NextNullableAfmVector();
            bool? testParam14 = _rnd.NextNullableBoolean();
            bool? testParam15 = _rnd.NextNullableBoolean();
            decimal? testParam16 = _rnd.NextNullableDecimal();
            decimal? testParam17 = _rnd.NextNullableDecimal();
            decimal? testParam18 = _rnd.NextNullableDecimal();
            decimal? testParam19 = _rnd.NextNullableDecimal();
            decimal? testParam20 = _rnd.NextNullableDecimal();
            decimal? testParam21 = _rnd.NextNullableDecimal();
            DirectionMetrics? testParam22 = _rnd.NextNullableAfmDirectionMetrics();
            DirectionMetrics? testParam23 = _rnd.NextNullableAfmDirectionMetrics();

            AfmFontMetrics testOutput = new AfmFontMetrics(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07,
                testParam08, testParam09, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17, testParam18,
                testParam19, testParam20, testParam21, testParam22, testParam23);

            Assert.AreEqual(testParam10, testOutput.CharacterSet);
        }

        [TestMethod]
        public void AfmFontMetricsClass_ConstructorWithTwentyFourParameters_SetsCharacterCountPropertyToValueOfTwelfthParameter()
        {
            string testParam00 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam01 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam02 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam03 = _rnd.NextString(_rnd.Next(1, 10));
            BoundingBox testParam04 = _rnd.NextAfmBoundingBox();
            string testParam05 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam06 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam07 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam08 = _rnd.NextNullableInt();
            int? testParam09 = _rnd.NextNullableInt();
            string testParam10 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam11 = _rnd.NextNullableInt();
            bool? testParam12 = _rnd.NextNullableBoolean();
            Vector? testParam13 = _rnd.NextNullableAfmVector();
            bool? testParam14 = _rnd.NextNullableBoolean();
            bool? testParam15 = _rnd.NextNullableBoolean();
            decimal? testParam16 = _rnd.NextNullableDecimal();
            decimal? testParam17 = _rnd.NextNullableDecimal();
            decimal? testParam18 = _rnd.NextNullableDecimal();
            decimal? testParam19 = _rnd.NextNullableDecimal();
            decimal? testParam20 = _rnd.NextNullableDecimal();
            decimal? testParam21 = _rnd.NextNullableDecimal();
            DirectionMetrics? testParam22 = _rnd.NextNullableAfmDirectionMetrics();
            DirectionMetrics? testParam23 = _rnd.NextNullableAfmDirectionMetrics();

            AfmFontMetrics testOutput = new AfmFontMetrics(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07,
                testParam08, testParam09, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17, testParam18,
                testParam19, testParam20, testParam21, testParam22, testParam23);

            Assert.AreEqual(testParam11, testOutput.CharacterCount);
        }

        [TestMethod]
        public void AfmFontMetricsClass_ConstructorWithTwentyFourParameters_SetsIsBaseFontPropertyToValueOfThirteenthParameter_IfThirteenthParameterIsNotNull()
        {
            string testParam00 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam01 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam02 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam03 = _rnd.NextString(_rnd.Next(1, 10));
            BoundingBox testParam04 = _rnd.NextAfmBoundingBox();
            string testParam05 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam06 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam07 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam08 = _rnd.NextNullableInt();
            int? testParam09 = _rnd.NextNullableInt();
            string testParam10 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam11 = _rnd.NextNullableInt();
            bool? testParam12 = _rnd.NextBoolean();
            Vector? testParam13 = _rnd.NextNullableAfmVector();
            bool? testParam14 = _rnd.NextNullableBoolean();
            bool? testParam15 = _rnd.NextNullableBoolean();
            decimal? testParam16 = _rnd.NextNullableDecimal();
            decimal? testParam17 = _rnd.NextNullableDecimal();
            decimal? testParam18 = _rnd.NextNullableDecimal();
            decimal? testParam19 = _rnd.NextNullableDecimal();
            decimal? testParam20 = _rnd.NextNullableDecimal();
            decimal? testParam21 = _rnd.NextNullableDecimal();
            DirectionMetrics? testParam22 = _rnd.NextNullableAfmDirectionMetrics();
            DirectionMetrics? testParam23 = _rnd.NextNullableAfmDirectionMetrics();

            AfmFontMetrics testOutput = new AfmFontMetrics(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07,
                testParam08, testParam09, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17, testParam18,
                testParam19, testParam20, testParam21, testParam22, testParam23);

            Assert.AreEqual(testParam12, testOutput.IsBaseFont);
        }

        [TestMethod]
        public void AfmFontMetricsClass_ConstructorWithTwentyFourParameters_SetsIsBaseFontPropertyToTrue_IfThirteenthParameterIsNull()
        {
            string testParam00 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam01 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam02 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam03 = _rnd.NextString(_rnd.Next(1, 10));
            BoundingBox testParam04 = _rnd.NextAfmBoundingBox();
            string testParam05 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam06 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam07 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam08 = _rnd.NextNullableInt();
            int? testParam09 = _rnd.NextNullableInt();
            string testParam10 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam11 = _rnd.NextNullableInt();
            bool? testParam12 = null;
            Vector? testParam13 = _rnd.NextNullableAfmVector();
            bool? testParam14 = _rnd.NextNullableBoolean();
            bool? testParam15 = _rnd.NextNullableBoolean();
            decimal? testParam16 = _rnd.NextNullableDecimal();
            decimal? testParam17 = _rnd.NextNullableDecimal();
            decimal? testParam18 = _rnd.NextNullableDecimal();
            decimal? testParam19 = _rnd.NextNullableDecimal();
            decimal? testParam20 = _rnd.NextNullableDecimal();
            decimal? testParam21 = _rnd.NextNullableDecimal();
            DirectionMetrics? testParam22 = _rnd.NextNullableAfmDirectionMetrics();
            DirectionMetrics? testParam23 = _rnd.NextNullableAfmDirectionMetrics();

            AfmFontMetrics testOutput = new AfmFontMetrics(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07,
                testParam08, testParam09, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17, testParam18,
                testParam19, testParam20, testParam21, testParam22, testParam23);

            Assert.IsTrue(testOutput.IsBaseFont);
        }

        [TestMethod]
        public void AfmFontMetricsClass_ConstructorWithTwentyFourParameters_SetsVVectorPropertyToValueOfFourteenthParameter()
        {
            string testParam00 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam01 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam02 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam03 = _rnd.NextString(_rnd.Next(1, 10));
            BoundingBox testParam04 = _rnd.NextAfmBoundingBox();
            string testParam05 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam06 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam07 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam08 = _rnd.NextNullableInt();
            int? testParam09 = _rnd.NextNullableInt();
            string testParam10 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam11 = _rnd.NextNullableInt();
            bool? testParam12 = _rnd.NextNullableBoolean();
            Vector? testParam13 = _rnd.NextNullableAfmVector();
            bool? testParam14 = _rnd.NextNullableBoolean();
            bool? testParam15 = _rnd.NextNullableBoolean();
            decimal? testParam16 = _rnd.NextNullableDecimal();
            decimal? testParam17 = _rnd.NextNullableDecimal();
            decimal? testParam18 = _rnd.NextNullableDecimal();
            decimal? testParam19 = _rnd.NextNullableDecimal();
            decimal? testParam20 = _rnd.NextNullableDecimal();
            decimal? testParam21 = _rnd.NextNullableDecimal();
            DirectionMetrics? testParam22 = _rnd.NextNullableAfmDirectionMetrics();
            DirectionMetrics? testParam23 = _rnd.NextNullableAfmDirectionMetrics();

            AfmFontMetrics testOutput = new AfmFontMetrics(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07,
                testParam08, testParam09, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17, testParam18,
                testParam19, testParam20, testParam21, testParam22, testParam23);

            Assert.AreEqual(testParam13, testOutput.VVector);
        }

        [TestMethod]
        public void AfmFontMetricsClass_ConstructorWithTwentyFourParameters_SetsIsFixedVPropertyToValueOfFifteenthParameter()
        {
            string testParam00 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam01 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam02 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam03 = _rnd.NextString(_rnd.Next(1, 10));
            BoundingBox testParam04 = _rnd.NextAfmBoundingBox();
            string testParam05 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam06 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam07 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam08 = _rnd.NextNullableInt();
            int? testParam09 = _rnd.NextNullableInt();
            string testParam10 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam11 = _rnd.NextNullableInt();
            bool? testParam12 = _rnd.NextNullableBoolean();
            Vector? testParam13 = _rnd.NextNullableAfmVector();
            bool? testParam14 = _rnd.NextNullableBoolean();
            bool? testParam15 = _rnd.NextNullableBoolean();
            decimal? testParam16 = _rnd.NextNullableDecimal();
            decimal? testParam17 = _rnd.NextNullableDecimal();
            decimal? testParam18 = _rnd.NextNullableDecimal();
            decimal? testParam19 = _rnd.NextNullableDecimal();
            decimal? testParam20 = _rnd.NextNullableDecimal();
            decimal? testParam21 = _rnd.NextNullableDecimal();
            DirectionMetrics? testParam22 = _rnd.NextNullableAfmDirectionMetrics();
            DirectionMetrics? testParam23 = _rnd.NextNullableAfmDirectionMetrics();

            AfmFontMetrics testOutput = new AfmFontMetrics(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07,
                testParam08, testParam09, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17, testParam18,
                testParam19, testParam20, testParam21, testParam22, testParam23);

            Assert.AreEqual(testParam14, testOutput.IsFixedV);
        }

        [TestMethod]
        public void AfmFontMetricsClass_ConstructorWithTwentyFourParameters_SetsIsCIDFontPropertyToValueOfSixteenthParameter_IfSixteenthParameterIsNotNull()
        {
            string testParam00 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam01 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam02 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam03 = _rnd.NextString(_rnd.Next(1, 10));
            BoundingBox testParam04 = _rnd.NextAfmBoundingBox();
            string testParam05 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam06 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam07 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam08 = _rnd.NextNullableInt();
            int? testParam09 = _rnd.NextNullableInt();
            string testParam10 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam11 = _rnd.NextNullableInt();
            bool? testParam12 = _rnd.NextNullableBoolean();
            Vector? testParam13 = _rnd.NextNullableAfmVector();
            bool? testParam14 = _rnd.NextNullableBoolean();
            bool? testParam15 = _rnd.NextBoolean();
            decimal? testParam16 = _rnd.NextNullableDecimal();
            decimal? testParam17 = _rnd.NextNullableDecimal();
            decimal? testParam18 = _rnd.NextNullableDecimal();
            decimal? testParam19 = _rnd.NextNullableDecimal();
            decimal? testParam20 = _rnd.NextNullableDecimal();
            decimal? testParam21 = _rnd.NextNullableDecimal();
            DirectionMetrics? testParam22 = _rnd.NextNullableAfmDirectionMetrics();
            DirectionMetrics? testParam23 = _rnd.NextNullableAfmDirectionMetrics();

            AfmFontMetrics testOutput = new AfmFontMetrics(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07,
                testParam08, testParam09, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17, testParam18,
                testParam19, testParam20, testParam21, testParam22, testParam23);

            Assert.AreEqual(testParam15, testOutput.IsCIDFont);
        }

        [TestMethod]
        public void AfmFontMetricsClass_ConstructorWithTwentyFourParameters_SetsIsCIDFontPropertyToFalse_IfSixteenthParameterIsNull()
        {
            string testParam00 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam01 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam02 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam03 = _rnd.NextString(_rnd.Next(1, 10));
            BoundingBox testParam04 = _rnd.NextAfmBoundingBox();
            string testParam05 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam06 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam07 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam08 = _rnd.NextNullableInt();
            int? testParam09 = _rnd.NextNullableInt();
            string testParam10 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam11 = _rnd.NextNullableInt();
            bool? testParam12 = _rnd.NextNullableBoolean();
            Vector? testParam13 = _rnd.NextNullableAfmVector();
            bool? testParam14 = _rnd.NextNullableBoolean();
            bool? testParam15 = null;
            decimal? testParam16 = _rnd.NextNullableDecimal();
            decimal? testParam17 = _rnd.NextNullableDecimal();
            decimal? testParam18 = _rnd.NextNullableDecimal();
            decimal? testParam19 = _rnd.NextNullableDecimal();
            decimal? testParam20 = _rnd.NextNullableDecimal();
            decimal? testParam21 = _rnd.NextNullableDecimal();
            DirectionMetrics? testParam22 = _rnd.NextNullableAfmDirectionMetrics();
            DirectionMetrics? testParam23 = _rnd.NextNullableAfmDirectionMetrics();

            AfmFontMetrics testOutput = new AfmFontMetrics(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07,
                testParam08, testParam09, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17, testParam18,
                testParam19, testParam20, testParam21, testParam22, testParam23);

            Assert.IsFalse(testOutput.IsCIDFont);
        }

        [TestMethod]
        public void AfmFontMetricsClass_ConstructorWithTwentyFourParameters_SetsCapHeightPropertyToValueOfSeventeenthParameter()
        {
            string testParam00 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam01 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam02 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam03 = _rnd.NextString(_rnd.Next(1, 10));
            BoundingBox testParam04 = _rnd.NextAfmBoundingBox();
            string testParam05 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam06 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam07 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam08 = _rnd.NextNullableInt();
            int? testParam09 = _rnd.NextNullableInt();
            string testParam10 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam11 = _rnd.NextNullableInt();
            bool? testParam12 = _rnd.NextNullableBoolean();
            Vector? testParam13 = _rnd.NextNullableAfmVector();
            bool? testParam14 = _rnd.NextNullableBoolean();
            bool? testParam15 = _rnd.NextNullableBoolean();
            decimal? testParam16 = _rnd.NextNullableDecimal();
            decimal? testParam17 = _rnd.NextNullableDecimal();
            decimal? testParam18 = _rnd.NextNullableDecimal();
            decimal? testParam19 = _rnd.NextNullableDecimal();
            decimal? testParam20 = _rnd.NextNullableDecimal();
            decimal? testParam21 = _rnd.NextNullableDecimal();
            DirectionMetrics? testParam22 = _rnd.NextNullableAfmDirectionMetrics();
            DirectionMetrics? testParam23 = _rnd.NextNullableAfmDirectionMetrics();

            AfmFontMetrics testOutput = new AfmFontMetrics(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07,
                testParam08, testParam09, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17, testParam18,
                testParam19, testParam20, testParam21, testParam22, testParam23);

            Assert.AreEqual(testParam16, testOutput.CapHeight);
        }

        [TestMethod]
        public void AfmFontMetricsClass_ConstructorWithTwentyFourParameters_SetsXHeightPropertyToValueOfEighteenthParameter()
        {
            string testParam00 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam01 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam02 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam03 = _rnd.NextString(_rnd.Next(1, 10));
            BoundingBox testParam04 = _rnd.NextAfmBoundingBox();
            string testParam05 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam06 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam07 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam08 = _rnd.NextNullableInt();
            int? testParam09 = _rnd.NextNullableInt();
            string testParam10 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam11 = _rnd.NextNullableInt();
            bool? testParam12 = _rnd.NextNullableBoolean();
            Vector? testParam13 = _rnd.NextNullableAfmVector();
            bool? testParam14 = _rnd.NextNullableBoolean();
            bool? testParam15 = _rnd.NextNullableBoolean();
            decimal? testParam16 = _rnd.NextNullableDecimal();
            decimal? testParam17 = _rnd.NextNullableDecimal();
            decimal? testParam18 = _rnd.NextNullableDecimal();
            decimal? testParam19 = _rnd.NextNullableDecimal();
            decimal? testParam20 = _rnd.NextNullableDecimal();
            decimal? testParam21 = _rnd.NextNullableDecimal();
            DirectionMetrics? testParam22 = _rnd.NextNullableAfmDirectionMetrics();
            DirectionMetrics? testParam23 = _rnd.NextNullableAfmDirectionMetrics();

            AfmFontMetrics testOutput = new AfmFontMetrics(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07,
                testParam08, testParam09, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17, testParam18,
                testParam19, testParam20, testParam21, testParam22, testParam23);

            Assert.AreEqual(testParam17, testOutput.XHeight);
        }

        [TestMethod]
        public void AfmFontMetricsClass_ConstructorWithTwentyFourParameters_SetsAscenderPropertyToValueOfNineteenthParameter()
        {
            string testParam00 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam01 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam02 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam03 = _rnd.NextString(_rnd.Next(1, 10));
            BoundingBox testParam04 = _rnd.NextAfmBoundingBox();
            string testParam05 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam06 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam07 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam08 = _rnd.NextNullableInt();
            int? testParam09 = _rnd.NextNullableInt();
            string testParam10 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam11 = _rnd.NextNullableInt();
            bool? testParam12 = _rnd.NextNullableBoolean();
            Vector? testParam13 = _rnd.NextNullableAfmVector();
            bool? testParam14 = _rnd.NextNullableBoolean();
            bool? testParam15 = _rnd.NextNullableBoolean();
            decimal? testParam16 = _rnd.NextNullableDecimal();
            decimal? testParam17 = _rnd.NextNullableDecimal();
            decimal? testParam18 = _rnd.NextNullableDecimal();
            decimal? testParam19 = _rnd.NextNullableDecimal();
            decimal? testParam20 = _rnd.NextNullableDecimal();
            decimal? testParam21 = _rnd.NextNullableDecimal();
            DirectionMetrics? testParam22 = _rnd.NextNullableAfmDirectionMetrics();
            DirectionMetrics? testParam23 = _rnd.NextNullableAfmDirectionMetrics();

            AfmFontMetrics testOutput = new AfmFontMetrics(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07,
                testParam08, testParam09, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17, testParam18,
                testParam19, testParam20, testParam21, testParam22, testParam23);

            Assert.AreEqual(testParam18, testOutput.Ascender);
        }

        [TestMethod]
        public void AfmFontMetricsClass_ConstructorWithTwentyFourParameters_SetsDescenderPropertyToValueOfTwentiethParameter()
        {
            string testParam00 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam01 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam02 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam03 = _rnd.NextString(_rnd.Next(1, 10));
            BoundingBox testParam04 = _rnd.NextAfmBoundingBox();
            string testParam05 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam06 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam07 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam08 = _rnd.NextNullableInt();
            int? testParam09 = _rnd.NextNullableInt();
            string testParam10 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam11 = _rnd.NextNullableInt();
            bool? testParam12 = _rnd.NextNullableBoolean();
            Vector? testParam13 = _rnd.NextNullableAfmVector();
            bool? testParam14 = _rnd.NextNullableBoolean();
            bool? testParam15 = _rnd.NextNullableBoolean();
            decimal? testParam16 = _rnd.NextNullableDecimal();
            decimal? testParam17 = _rnd.NextNullableDecimal();
            decimal? testParam18 = _rnd.NextNullableDecimal();
            decimal? testParam19 = _rnd.NextNullableDecimal();
            decimal? testParam20 = _rnd.NextNullableDecimal();
            decimal? testParam21 = _rnd.NextNullableDecimal();
            DirectionMetrics? testParam22 = _rnd.NextNullableAfmDirectionMetrics();
            DirectionMetrics? testParam23 = _rnd.NextNullableAfmDirectionMetrics();

            AfmFontMetrics testOutput = new AfmFontMetrics(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07,
                testParam08, testParam09, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17, testParam18,
                testParam19, testParam20, testParam21, testParam22, testParam23);

            Assert.AreEqual(testParam19, testOutput.Descender);
        }

        [TestMethod]
        public void AfmFontMetricsClass_ConstructorWithTwentyFourParameters_SetsStdHWPropertyToValueOfTwentyFirstParameter()
        {
            string testParam00 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam01 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam02 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam03 = _rnd.NextString(_rnd.Next(1, 10));
            BoundingBox testParam04 = _rnd.NextAfmBoundingBox();
            string testParam05 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam06 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam07 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam08 = _rnd.NextNullableInt();
            int? testParam09 = _rnd.NextNullableInt();
            string testParam10 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam11 = _rnd.NextNullableInt();
            bool? testParam12 = _rnd.NextNullableBoolean();
            Vector? testParam13 = _rnd.NextNullableAfmVector();
            bool? testParam14 = _rnd.NextNullableBoolean();
            bool? testParam15 = _rnd.NextNullableBoolean();
            decimal? testParam16 = _rnd.NextNullableDecimal();
            decimal? testParam17 = _rnd.NextNullableDecimal();
            decimal? testParam18 = _rnd.NextNullableDecimal();
            decimal? testParam19 = _rnd.NextNullableDecimal();
            decimal? testParam20 = _rnd.NextNullableDecimal();
            decimal? testParam21 = _rnd.NextNullableDecimal();
            DirectionMetrics? testParam22 = _rnd.NextNullableAfmDirectionMetrics();
            DirectionMetrics? testParam23 = _rnd.NextNullableAfmDirectionMetrics();

            AfmFontMetrics testOutput = new AfmFontMetrics(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07,
                testParam08, testParam09, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17, testParam18,
                testParam19, testParam20, testParam21, testParam22, testParam23);

            Assert.AreEqual(testParam20, testOutput.StdHW);
        }

        [TestMethod]
        public void AfmFontMetricsClass_ConstructorWithTwentyFourParameters_SetsStdVWPropertyToValueOfTwentySecondParameter()
        {
            string testParam00 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam01 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam02 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam03 = _rnd.NextString(_rnd.Next(1, 10));
            BoundingBox testParam04 = _rnd.NextAfmBoundingBox();
            string testParam05 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam06 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam07 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam08 = _rnd.NextNullableInt();
            int? testParam09 = _rnd.NextNullableInt();
            string testParam10 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam11 = _rnd.NextNullableInt();
            bool? testParam12 = _rnd.NextNullableBoolean();
            Vector? testParam13 = _rnd.NextNullableAfmVector();
            bool? testParam14 = _rnd.NextNullableBoolean();
            bool? testParam15 = _rnd.NextNullableBoolean();
            decimal? testParam16 = _rnd.NextNullableDecimal();
            decimal? testParam17 = _rnd.NextNullableDecimal();
            decimal? testParam18 = _rnd.NextNullableDecimal();
            decimal? testParam19 = _rnd.NextNullableDecimal();
            decimal? testParam20 = _rnd.NextNullableDecimal();
            decimal? testParam21 = _rnd.NextNullableDecimal();
            DirectionMetrics? testParam22 = _rnd.NextNullableAfmDirectionMetrics();
            DirectionMetrics? testParam23 = _rnd.NextNullableAfmDirectionMetrics();

            AfmFontMetrics testOutput = new AfmFontMetrics(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07,
                testParam08, testParam09, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17, testParam18,
                testParam19, testParam20, testParam21, testParam22, testParam23);

            Assert.AreEqual(testParam21, testOutput.StdVW);
        }

        [TestMethod]
        public void AfmFontMetricsClass_ConstructorWithTwentyFourParameters_SetsDirection0MetricsPropertyToValueOfTwentyThirdParameter()
        {
            string testParam00 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam01 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam02 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam03 = _rnd.NextString(_rnd.Next(1, 10));
            BoundingBox testParam04 = _rnd.NextAfmBoundingBox();
            string testParam05 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam06 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam07 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam08 = _rnd.NextNullableInt();
            int? testParam09 = _rnd.NextNullableInt();
            string testParam10 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam11 = _rnd.NextNullableInt();
            bool? testParam12 = _rnd.NextNullableBoolean();
            Vector? testParam13 = _rnd.NextNullableAfmVector();
            bool? testParam14 = _rnd.NextNullableBoolean();
            bool? testParam15 = _rnd.NextNullableBoolean();
            decimal? testParam16 = _rnd.NextNullableDecimal();
            decimal? testParam17 = _rnd.NextNullableDecimal();
            decimal? testParam18 = _rnd.NextNullableDecimal();
            decimal? testParam19 = _rnd.NextNullableDecimal();
            decimal? testParam20 = _rnd.NextNullableDecimal();
            decimal? testParam21 = _rnd.NextNullableDecimal();
            DirectionMetrics? testParam22 = _rnd.NextNullableAfmDirectionMetrics();
            DirectionMetrics? testParam23 = _rnd.NextNullableAfmDirectionMetrics();

            AfmFontMetrics testOutput = new AfmFontMetrics(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07,
                testParam08, testParam09, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17, testParam18,
                testParam19, testParam20, testParam21, testParam22, testParam23);

            Assert.AreEqual(testParam22, testOutput.Direction0Metrics);
        }

        [TestMethod]
        public void AfmFontMetricsClass_ConstructorWithTwentyFourParameters_SetsDirection1MetricsPropertyToValueOfTwentyFourthParameter()
        {
            string testParam00 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam01 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam02 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam03 = _rnd.NextString(_rnd.Next(1, 10));
            BoundingBox testParam04 = _rnd.NextAfmBoundingBox();
            string testParam05 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam06 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam07 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam08 = _rnd.NextNullableInt();
            int? testParam09 = _rnd.NextNullableInt();
            string testParam10 = _rnd.NextString(_rnd.Next(1, 10));
            int? testParam11 = _rnd.NextNullableInt();
            bool? testParam12 = _rnd.NextNullableBoolean();
            Vector? testParam13 = _rnd.NextNullableAfmVector();
            bool? testParam14 = _rnd.NextNullableBoolean();
            bool? testParam15 = _rnd.NextNullableBoolean();
            decimal? testParam16 = _rnd.NextNullableDecimal();
            decimal? testParam17 = _rnd.NextNullableDecimal();
            decimal? testParam18 = _rnd.NextNullableDecimal();
            decimal? testParam19 = _rnd.NextNullableDecimal();
            decimal? testParam20 = _rnd.NextNullableDecimal();
            decimal? testParam21 = _rnd.NextNullableDecimal();
            DirectionMetrics? testParam22 = _rnd.NextNullableAfmDirectionMetrics();
            DirectionMetrics? testParam23 = _rnd.NextNullableAfmDirectionMetrics();

            AfmFontMetrics testOutput = new AfmFontMetrics(testParam00, testParam01, testParam02, testParam03, testParam04, testParam05, testParam06, testParam07,
                testParam08, testParam09, testParam10, testParam11, testParam12, testParam13, testParam14, testParam15, testParam16, testParam17, testParam18,
                testParam19, testParam20, testParam21, testParam22, testParam23);

            Assert.AreEqual(testParam23, testOutput.Direction1Metrics);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AfmFontMetricsClass_FromLinesMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            _ = AfmFontMetrics.FromLines(null);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void AfmFontMetricsClass_FromLinesMethod_ThrowsAfmFormatException_IfParameterHasLengthZero()
        {
            string[] testParam = Array.Empty<string>();

            _ = AfmFontMetrics.FromLines(testParam);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void AfmFontMetricsClass_FromLinesMethod_ThrowsAfmFormatException_IfParameterDoesNotStartWithCorrectLine()
        {
            string openingLine;
            do
            {
                openingLine = _rnd.NextString(_rnd.Next(50));
            } while (openingLine == "StartFontMetrics");
            string[] testParam = new[] { openingLine };

            _ = AfmFontMetrics.FromLines(testParam);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void AfmFontMetricsClass_FromLinesMethod_ThrowsAfmFormatException_IfParameterDoesNotEndWithCorrectLine()
        {
            string[] testParam = new[] { "StartFontMetrics" };

            _ = AfmFontMetrics.FromLines(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void AfmFontMetricsClass_FromLinesMethod_ReturnsNonNullObject_IfParameterContainsMinimalValidData()
        {
            string[] testParam = new[] { "StartFontMetrics", "EndFontMetrics" };

            AfmFontMetrics testOutput = AfmFontMetrics.FromLines(testParam);

            Assert.IsNotNull(testOutput);
        }

        [TestMethod]
        public void AfmFontMetricsClass_FromLinesMethod_ReturnsObjectWithFontNamePropertyEqualToNull_IfParameterContainsMinimalValidData()
        {
            string[] testParam = new[] { "StartFontMetrics", "EndFontMetrics" };

            AfmFontMetrics testOutput = AfmFontMetrics.FromLines(testParam);

            Assert.IsNull(testOutput.FontName);
        }

        [TestMethod]
        public void AfmFontMetricsClass_FromLinesMethod_ReturnsObjectWithWeightPropertyEqualToNull_IfParameterContainsMinimalValidData()
        {
            string[] testParam = new[] { "StartFontMetrics", "EndFontMetrics" };

            AfmFontMetrics testOutput = AfmFontMetrics.FromLines(testParam);

            Assert.IsNull(testOutput.Weight);
        }

        [TestMethod]
        public void AfmFontMetricsClass_FromLinesMethod_ReturnsObjectWithFamilyNamePropertyEqualToNull_IfParameterContainsMinimalValidData()
        {
            string[] testParam = new[] { "StartFontMetrics", "EndFontMetrics" };

            AfmFontMetrics testOutput = AfmFontMetrics.FromLines(testParam);

            Assert.IsNull(testOutput.FamilyName);
        }

        [TestMethod]
        public void AfmFontMetricsClass_FromLinesMethod_ReturnsObjectWithFullNamePropertyEqualToNull_IfParameterContainsMinimalValidData()
        {
            string[] testParam = new[] { "StartFontMetrics", "EndFontMetrics" };

            AfmFontMetrics testOutput = AfmFontMetrics.FromLines(testParam);

            Assert.IsNull(testOutput.FullName);
        }

        [TestMethod]
        public void AfmFontMetricsClass_FromLinesMethod_ReturnsObjectWithFontBoundingBoxPropertyEqualToDefaultValue_IfParameterContainsMinimalValidData()
        {
            string[] testParam = new[] { "StartFontMetrics", "EndFontMetrics" };

            AfmFontMetrics testOutput = AfmFontMetrics.FromLines(testParam);

            Assert.AreEqual(default, testOutput.FontBoundingBox);
        }

        [TestMethod]
        public void AfmFontMetricsClass_FromLinesMethod_ReturnsObjectWithVersionPropertyEqualToNull_IfParameterContainsMinimalValidData()
        {
            string[] testParam = new[] { "StartFontMetrics", "EndFontMetrics" };

            AfmFontMetrics testOutput = AfmFontMetrics.FromLines(testParam);

            Assert.IsNull(testOutput.Version);
        }

        [TestMethod]
        public void AfmFontMetricsClass_FromLinesMethod_ReturnsObjectWithNoticePropertyEqualToNull_IfParameterContainsMinimalValidData()
        {
            string[] testParam = new[] { "StartFontMetrics", "EndFontMetrics" };

            AfmFontMetrics testOutput = AfmFontMetrics.FromLines(testParam);

            Assert.IsNull(testOutput.Notice);
        }

        [TestMethod]
        public void AfmFontMetricsClass_FromLinesMethod_ReturnsObjectWithEncodingSchemePropertyEqualToNull_IfParameterContainsMinimalValidData()
        {
            string[] testParam = new[] { "StartFontMetrics", "EndFontMetrics" };

            AfmFontMetrics testOutput = AfmFontMetrics.FromLines(testParam);

            Assert.IsNull(testOutput.EncodingScheme);
        }

        [TestMethod]
        public void AfmFontMetricsClass_FromLinesMethod_ReturnsObjectWithMappingSchemePropertyEqualToNull_IfParameterContainsMinimalValidData()
        {
            string[] testParam = new[] { "StartFontMetrics", "EndFontMetrics" };

            AfmFontMetrics testOutput = AfmFontMetrics.FromLines(testParam);

            Assert.IsNull(testOutput.MappingScheme);
        }

        [TestMethod]
        public void AfmFontMetricsClass_FromLinesMethod_ReturnsObjectWithEscapeCharacterPropertyEqualToNull_IfParameterContainsMinimalValidData()
        {
            string[] testParam = new[] { "StartFontMetrics", "EndFontMetrics" };

            AfmFontMetrics testOutput = AfmFontMetrics.FromLines(testParam);

            Assert.IsNull(testOutput.EscapeCharacter);
        }

        [TestMethod]
        public void AfmFontMetricsClass_FromLinesMethod_ReturnsObjectWithCharacterSetPropertyEqualToNull_IfParameterContainsMinimalValidData()
        {
            string[] testParam = new[] { "StartFontMetrics", "EndFontMetrics" };

            AfmFontMetrics testOutput = AfmFontMetrics.FromLines(testParam);

            Assert.IsNull(testOutput.CharacterSet);
        }

        [TestMethod]
        public void AfmFontMetricsClass_FromLinesMethod_ReturnsObjectWithCharacterCountPropertyEqualToNull_IfParameterContainsMinimalValidData()
        {
            string[] testParam = new[] { "StartFontMetrics", "EndFontMetrics" };

            AfmFontMetrics testOutput = AfmFontMetrics.FromLines(testParam);

            Assert.IsNull(testOutput.CharacterCount);
        }

        [TestMethod]
        public void AfmFontMetricsClass_FromLinesMethod_ReturnsObjectWithIsBaseFontPropertyEqualToTrue_IfParameterContainsMinimalValidData()
        {
            string[] testParam = new[] { "StartFontMetrics", "EndFontMetrics" };

            AfmFontMetrics testOutput = AfmFontMetrics.FromLines(testParam);

            Assert.IsTrue(testOutput.IsBaseFont);
        }

        [TestMethod]
        public void AfmFontMetricsClass_FromLinesMethod_ReturnsObjectWithVVectorPropertyEqualToNull_IfParameterContainsMinimalValidData()
        {
            string[] testParam = new[] { "StartFontMetrics", "EndFontMetrics" };

            AfmFontMetrics testOutput = AfmFontMetrics.FromLines(testParam);

            Assert.IsNull(testOutput.VVector);
        }

        [TestMethod]
        public void AfmFontMetricsClass_FromLinesMethod_ReturnsObjectWithIsFixedVPropertyEqualToNull_IfParameterContainsMinimalValidData()
        {
            string[] testParam = new[] { "StartFontMetrics", "EndFontMetrics" };

            AfmFontMetrics testOutput = AfmFontMetrics.FromLines(testParam);

            Assert.IsNull(testOutput.IsFixedV);
        }

        [TestMethod]
        public void AfmFontMetricsClass_FromLinesMethod_ReturnsObjectWithIsCIDFontPropertyEqualToNull_IfParameterContainsMinimalValidData()
        {
            string[] testParam = new[] { "StartFontMetrics", "EndFontMetrics" };

            AfmFontMetrics testOutput = AfmFontMetrics.FromLines(testParam);

            Assert.IsFalse(testOutput.IsCIDFont);
        }

        [TestMethod]
        public void AfmFontMetricsClass_FromLinesMethod_ReturnsObjectWithCapHeightPropertyEqualToNull_IfParameterContainsMinimalValidData()
        {
            string[] testParam = new[] { "StartFontMetrics", "EndFontMetrics" };

            AfmFontMetrics testOutput = AfmFontMetrics.FromLines(testParam);

            Assert.IsNull(testOutput.CapHeight);
        }

        [TestMethod]
        public void AfmFontMetricsClass_FromLinesMethod_ReturnsObjectWithXHeightPropertyEqualToNull_IfParameterContainsMinimalValidData()
        {
            string[] testParam = new[] { "StartFontMetrics", "EndFontMetrics" };

            AfmFontMetrics testOutput = AfmFontMetrics.FromLines(testParam);

            Assert.IsNull(testOutput.XHeight);
        }

        [TestMethod]
        public void AfmFontMetricsClass_FromLinesMethod_ReturnsObjectWithAscenderPropertyEqualToNull_IfParameterContainsMinimalValidData()
        {
            string[] testParam = new[] { "StartFontMetrics", "EndFontMetrics" };

            AfmFontMetrics testOutput = AfmFontMetrics.FromLines(testParam);

            Assert.IsNull(testOutput.Ascender);
        }

        [TestMethod]
        public void AfmFontMetricsClass_FromLinesMethod_ReturnsObjectWithDescenderPropertyEqualToNull_IfParameterContainsMinimalValidData()
        {
            string[] testParam = new[] { "StartFontMetrics", "EndFontMetrics" };

            AfmFontMetrics testOutput = AfmFontMetrics.FromLines(testParam);

            Assert.IsNull(testOutput.Descender);
        }

        [TestMethod]
        public void AfmFontMetricsClass_FromLinesMethod_ReturnsObjectWithStdHWPropertyEqualToNull_IfParameterContainsMinimalValidData()
        {
            string[] testParam = new[] { "StartFontMetrics", "EndFontMetrics" };

            AfmFontMetrics testOutput = AfmFontMetrics.FromLines(testParam);

            Assert.IsNull(testOutput.StdHW);
        }

        [TestMethod]
        public void AfmFontMetricsClass_FromLinesMethod_ReturnsObjectWithStdVWPropertyEqualToNull_IfParameterContainsMinimalValidData()
        {
            string[] testParam = new[] { "StartFontMetrics", "EndFontMetrics" };

            AfmFontMetrics testOutput = AfmFontMetrics.FromLines(testParam);

            Assert.IsNull(testOutput.StdVW);
        }

        [TestMethod]
        public void AfmFontMetricsClass_FromLinesMethod_ReturnsObjectWithDirection0MetricsPropertyEqualToDefaultValue_IfParameterContainsMinimalValidData()
        {
            string[] testParam = new[] { "StartFontMetrics", "EndFontMetrics" };

            AfmFontMetrics testOutput = AfmFontMetrics.FromLines(testParam);

            Assert.AreEqual(default, testOutput.Direction0Metrics.Value);
        }

        [TestMethod]
        public void AfmFontMetricsClass_FromLinesMethod_ReturnsObjectWithDirection1MetricsPropertyEqualToNull_IfParameterContainsMinimalValidData()
        {
            string[] testParam = new[] { "StartFontMetrics", "EndFontMetrics" };

            AfmFontMetrics testOutput = AfmFontMetrics.FromLines(testParam);

            Assert.IsNull(testOutput.Direction1Metrics);
        }

        [TestMethod]
        public void AfmFontMetricsClass_FromLinesMethod_ReturnsObjectWithCharactersByNamePropertyWithCountPropertyEqualToZero_IfParameterContainsMinimalValidData()
        {
            string[] testParam = new[] { "StartFontMetrics", "EndFontMetrics" };

            AfmFontMetrics testOutput = AfmFontMetrics.FromLines(testParam);

            Assert.AreEqual(0, testOutput.CharactersByName.Count);
        }

        [TestMethod]
        public void AfmFontMetricsClass_FromLinesMethod_ReturnsObjectWithCharactersByCodePropertyWithCountPropertyEqualToZero_IfParameterContainsMinimalValidData()
        {
            string[] testParam = new[] { "StartFontMetrics", "EndFontMetrics" };

            AfmFontMetrics testOutput = AfmFontMetrics.FromLines(testParam);

            Assert.AreEqual(0, testOutput.CharactersByCode.Count);
        }

        [TestMethod]
        public void AfmFontMetricsClass_FromLinesMethod_ReturnsObjectWithCharactersPropertyWithCountPropertyEqualToZero_IfParameterContainsMinimalValidData()
        {
            string[] testParam = new[] { "StartFontMetrics", "EndFontMetrics" };

            AfmFontMetrics testOutput = AfmFontMetrics.FromLines(testParam);

            Assert.AreEqual(0, testOutput.Characters.Count);
        }

        [TestMethod]
        public void AfmFontMetricsClass_FromLinesMethod_ReturnsObjectWithCorrectFontNameProperty_IfParameterContainsFontNameData()
        {
            string expectedValue = _rnd.NextString(_rnd.Next(1, 20));
            string[] testParam = new[] { "StartFontMetrics", $"FontName {expectedValue}", "EndFontMetrics" };

            AfmFontMetrics testOutput = AfmFontMetrics.FromLines(testParam);

            Assert.AreEqual(expectedValue, testOutput.FontName);
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void AfmFontMetricsClass_FromLinesMethod_ThrowsAfmFormatException_IfParameterContainsIncompleteFontNameData()
        {
            string[] testParam = new[] { "StartFontMetrics", "FontName", "EndFontMetrics" };

            _ = AfmFontMetrics.FromLines(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void AfmFontMetricsClass_FromLinesMethod_ReturnsObjectWithCorrectFamilyNameProperty_IfParameterContainsFamilyNameData()
        {
            string expectedValue = _rnd.NextString(_rnd.Next(1, 20));
            string[] testParam = new[] { "StartFontMetrics", $"FamilyName {expectedValue}", "EndFontMetrics" };

            AfmFontMetrics testOutput = AfmFontMetrics.FromLines(testParam);

            Assert.AreEqual(expectedValue, testOutput.FamilyName);
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void AfmFontMetricsClass_FromLinesMethod_ThrowsAfmFormatException_IfParameterContainsIncompleteFamilyNameData()
        {
            string[] testParam = new[] { "StartFontMetrics", "FamilyName", "EndFontMetrics" };

            _ = AfmFontMetrics.FromLines(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void AfmFontMetricsClass_FromLinesMethod_ReturnsObjectWithCorrectFullNameProperty_IfParameterContainsFullNameData()
        {
            string expectedValue = _rnd.NextString(_rnd.Next(1, 20));
            string[] testParam = new[] { "StartFontMetrics", $"FullName {expectedValue}", "EndFontMetrics" };

            AfmFontMetrics testOutput = AfmFontMetrics.FromLines(testParam);

            Assert.AreEqual(expectedValue, testOutput.FullName);
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void AfmFontMetricsClass_FromLinesMethod_ThrowsAfmFormatException_IfParameterContainsIncompleteFullNameData()
        {
            string[] testParam = new[] { "StartFontMetrics", "FullName", "EndFontMetrics" };

            _ = AfmFontMetrics.FromLines(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void AfmFontMetricsClass_FromLinesMethod_ReturnsObjectWithCorrectWeightProperty_IfParameterContainsWeightData()
        {
            string expectedValue = _rnd.NextString(_rnd.Next(1, 20));
            string[] testParam = new[] { "StartFontMetrics", $"Weight {expectedValue}", "EndFontMetrics" };

            AfmFontMetrics testOutput = AfmFontMetrics.FromLines(testParam);

            Assert.AreEqual(expectedValue, testOutput.Weight);
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void AfmFontMetricsClass_FromLinesMethod_ThrowsAfmFormatException_IfParameterContainsIncompleteWeightData()
        {
            string[] testParam = new[] { "StartFontMetrics", "Weight", "EndFontMetrics" };

            _ = AfmFontMetrics.FromLines(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void AfmFontMetricsClass_FromLinesMethod_ReturnsObjectWithCorrectFontBoundingBoxProperty_IfParameterContainsFontBBoxData()
        {
            BoundingBox expectedValue = _rnd.NextAfmBoundingBox();
            string[] testParam = new[] { "StartFontMetrics", $"FontBBox {expectedValue}", "EndFontMetrics" };

            AfmFontMetrics testOutput = AfmFontMetrics.FromLines(testParam);

            Assert.AreEqual(expectedValue, testOutput.FontBoundingBox);
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void AfmFontMetricsClass_FromLinesMethod_ThrowsAfmFormatException_IfParameterContainsIncompleteFontBBoxData()
        {
            string[] testParam = new[] { "StartFontMetrics", "FontBBox", "EndFontMetrics" };

            _ = AfmFontMetrics.FromLines(testParam);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void AfmFontMetricsClass_FromLinesMethod_ThrowsAfmFormatException_IfParameterContainsInvalidFontBBoxData()
        {
            string invalidBoundingBox = _rnd.NextString("abcdefghijkmnopqrstuvwxyz", _rnd.Next(1, 20));
            string[] testParam = new[] { "StartFontMetrics", $"FontBBox {invalidBoundingBox}", "EndFontMetrics" };

            _ = AfmFontMetrics.FromLines(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void AfmFontMetricsClass_FromLinesMethod_ReturnsObjectWithCorrectVersionProperty_IfParameterContainsVersionData()
        {
            string expectedValue = _rnd.NextString(_rnd.Next(1, 20));
            string[] testParam = new[] { "StartFontMetrics", $"Version {expectedValue}", "EndFontMetrics" };

            AfmFontMetrics testOutput = AfmFontMetrics.FromLines(testParam);

            Assert.AreEqual(expectedValue, testOutput.Version);
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void AfmFontMetricsClass_FromLinesMethod_ThrowsAfmFormatException_IfParameterContainsIncompleteVersionData()
        {
            string[] testParam = new[] { "StartFontMetrics", "Version", "EndFontMetrics" };

            _ = AfmFontMetrics.FromLines(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void AfmFontMetricsClass_FromLinesMethod_ReturnsObjectWithCorrectNoticeProperty_IfParameterContainsNoticeData()
        {
            string expectedValue = _rnd.NextString(_rnd.Next(1, 20));
            string[] testParam = new[] { "StartFontMetrics", $"Notice {expectedValue}", "EndFontMetrics" };

            AfmFontMetrics testOutput = AfmFontMetrics.FromLines(testParam);

            Assert.AreEqual(expectedValue, testOutput.Notice);
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void AfmFontMetricsClass_FromLinesMethod_ThrowsAfmFormatException_IfParameterContainsIncompleteNoticeData()
        {
            string[] testParam = new[] { "StartFontMetrics", "Notice", "EndFontMetrics" };

            _ = AfmFontMetrics.FromLines(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void AfmFontMetricsClass_FromLinesMethod_ReturnsObjectWithCorrectEncodingSchemeProperty_IfParameterContainsEncodingSchemeData()
        {
            string expectedValue = _rnd.NextString(_rnd.Next(1, 20));
            string[] testParam = new[] { "StartFontMetrics", $"EncodingScheme {expectedValue}", "EndFontMetrics" };

            AfmFontMetrics testOutput = AfmFontMetrics.FromLines(testParam);

            Assert.AreEqual(expectedValue, testOutput.EncodingScheme);
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void AfmFontMetricsClass_FromLinesMethod_ThrowsAfmFormatException_IfParameterContainsIncompleteEncodingSchemeData()
        {
            string[] testParam = new[] { "StartFontMetrics", "EncodingScheme", "EndFontMetrics" };

            _ = AfmFontMetrics.FromLines(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void AfmFontMetricsClass_FromLinesMethod_ReturnsObjectWithCorrectMappingSchemeProperty_IfParameterContainsMappingSchemeData()
        {
            int expectedValue = _rnd.Next();
            string[] testParam = new[] { "StartFontMetrics", $"MappingScheme {expectedValue}", "EndFontMetrics" };

            AfmFontMetrics testOutput = AfmFontMetrics.FromLines(testParam);

            Assert.AreEqual(expectedValue, testOutput.MappingScheme.Value);
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void AfmFontMetricsClass_FromLinesMethod_ThrowsAfmFormatException_IfParameterContainsIncompleteMappingSchemeData()
        {
            string[] testParam = new[] { "StartFontMetrics", "MappingScheme", "EndFontMetrics" };

            _ = AfmFontMetrics.FromLines(testParam);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void AfmFontMetricsClass_FromLinesMethod_ThrowsAfmFormatException_IfParameterContainsInvalidMappingSchemeData()
        {
            string invalidData = _rnd.NextString("abcdefghijklmnopqrstuvwyxz", _rnd.Next(1, 10));
            string[] testParam = new[] { "StartFontMetrics", $"MappingScheme {invalidData}", "EndFontMetrics" };

            _ = AfmFontMetrics.FromLines(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void AfmFontMetricsClass_FromLinesMethod_ReturnsObjectWithCorrectEscapeCharacterProperty_IfParameterContainsEscCharData()
        {
            int expectedValue = _rnd.Next();
            string[] testParam = new[] { "StartFontMetrics", $"EscChar {expectedValue}", "EndFontMetrics" };

            AfmFontMetrics testOutput = AfmFontMetrics.FromLines(testParam);

            Assert.AreEqual(expectedValue, testOutput.EscapeCharacter.Value);
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void AfmFontMetricsClass_FromLinesMethod_ThrowsAfmFormatException_IfParameterContainsIncompleteEscCharData()
        {
            string[] testParam = new[] { "StartFontMetrics", "EscChar", "EndFontMetrics" };

            _ = AfmFontMetrics.FromLines(testParam);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void AfmFontMetricsClass_FromLinesMethod_ThrowsAfmFormatException_IfParameterContainsInvalidEscCharData()
        {
            string invalidData = _rnd.NextString("abcdefghijklmnopqrstuvwyxz", _rnd.Next(1, 10));
            string[] testParam = new[] { "StartFontMetrics", $"EscChar {invalidData}", "EndFontMetrics" };

            _ = AfmFontMetrics.FromLines(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void AfmFontMetricsClass_FromLinesMethod_ReturnsObjectWithCorrectCharacterSetProperty_IfParameterContainsCharacterSetData()
        {
            string expectedValue = _rnd.NextString(_rnd.Next(1, 20));
            string[] testParam = new[] { "StartFontMetrics", $"CharacterSet {expectedValue}", "EndFontMetrics" };

            AfmFontMetrics testOutput = AfmFontMetrics.FromLines(testParam);

            Assert.AreEqual(expectedValue, testOutput.CharacterSet);
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void AfmFontMetricsClass_FromLinesMethod_ThrowsAfmFormatException_IfParameterContainsIncompleteCharacterSetData()
        {
            string[] testParam = new[] { "StartFontMetrics", "CharacterSet", "EndFontMetrics" };

            _ = AfmFontMetrics.FromLines(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void AfmFontMetricsClass_FromLinesMethod_ReturnsObjectWithCorrectCharacterCountProperty_IfParameterContainsCharactersData()
        {
            int expectedValue = _rnd.Next();
            string[] testParam = new[] { "StartFontMetrics", $"Characters {expectedValue}", "EndFontMetrics" };

            AfmFontMetrics testOutput = AfmFontMetrics.FromLines(testParam);

            Assert.AreEqual(expectedValue, testOutput.CharacterCount.Value);
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void AfmFontMetricsClass_FromLinesMethod_ThrowsAfmFormatException_IfParameterContainsIncompleteCharactersData()
        {
            string[] testParam = new[] { "StartFontMetrics", "Characters", "EndFontMetrics" };

            _ = AfmFontMetrics.FromLines(testParam);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void AfmFontMetricsClass_FromLinesMethod_ThrowsAfmFormatException_IfParameterContainsInvalidCharactersData()
        {
            string invalidData = _rnd.NextString("abcdefghijklmnopqrstuvwyxz", _rnd.Next(1, 10));
            string[] testParam = new[] { "StartFontMetrics", $"Characters {invalidData}", "EndFontMetrics" };

            _ = AfmFontMetrics.FromLines(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void AfmFontMetricsClass_FromLinesMethod_ReturnsObjectWithIsBaseFontPropertyEqualToTrue_IfParameterContainsIsBaseFontTrue()
        {
            string[] testParam = new[] { "StartFontMetrics", "IsBaseFont true", "EndFontMetrics" };

            AfmFontMetrics testOutput = AfmFontMetrics.FromLines(testParam);

            Assert.IsTrue(testOutput.IsBaseFont);
        }

        [TestMethod]
        public void AfmFontMetricsClass_FromLinesMethod_ReturnsObjectWithIsBaseFontPropertyEqualToFalse_IfParameterContainsIsBaseFontFalse()
        {
            string[] testParam = new[] { "StartFontMetrics", "IsBaseFont false", "EndFontMetrics" };

            AfmFontMetrics testOutput = AfmFontMetrics.FromLines(testParam);

            Assert.IsFalse(testOutput.IsBaseFont);
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void AfmFontMetricsClass_FromLinesMethod_ThrowsAfmFormatException_IfParameterContainsIncompleteIsBaseFontData()
        {
            string[] testParam = new[] { "StartFontMetrics", "IsBaseFont", "EndFontMetrics" };

            _ = AfmFontMetrics.FromLines(testParam);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void AfmFontMetricsClass_FromLinesMethod_ThrowsAfmFormatException_IfParameterContainsInvalidIsBaseFontData()
        {
            string invalidData = _rnd.NextString("abcdfghijklmnopqrstuvwyxz", _rnd.Next(1, 10));
            string[] testParam = new[] { "StartFontMetrics", $"IsBaseFont {invalidData}", "EndFontMetrics" };

            _ = AfmFontMetrics.FromLines(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void AfmFontMetricsClass_FromLinesMethod_ReturnsObjectWithCorrectVVectorProperty_IfParameterContainsVVectorData()
        {
            Vector expectedValue = _rnd.NextAfmVector();
            string[] testParam = new[] { "StartFontMetrics", $"VVector {expectedValue}", "EndFontMetrics" };

            AfmFontMetrics testOutput = AfmFontMetrics.FromLines(testParam);

            Assert.AreEqual(expectedValue, testOutput.VVector);
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void AfmFontMetricsClass_FromLinesMethod_ThrowsAfmFormatException_IfParameterContainsIncompleteVVectorData()
        {
            string[] testParam = new[] { "StartFontMetrics", "VVector", "EndFontMetrics" };

            _ = AfmFontMetrics.FromLines(testParam);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void AfmFontMetricsClass_FromLinesMethod_ThrowsAfmFormatException_IfParameterContainsInvalidVVectorData()
        {
            string invalidData = _rnd.NextString(_rnd.Next(1, 10));
            string[] testParam = new[] { "StartFontMetrics", $"VVector {invalidData}", "EndFontMetrics" };

            _ = AfmFontMetrics.FromLines(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void AfmFontMetricsClass_FromLinesMethod_ReturnsObjectWithIsFixedVPropertyEqualToTrue_IfParameterContainsIsIsFixedVTrue()
        {
            string[] testParam = new[] { "StartFontMetrics", "IsFixedV true", "EndFontMetrics" };

            AfmFontMetrics testOutput = AfmFontMetrics.FromLines(testParam);

            Assert.IsTrue(testOutput.IsFixedV.Value);
        }

        [TestMethod]
        public void AfmFontMetricsClass_FromLinesMethod_ReturnsObjectWithIsFixedVPropertyEqualToFalse_IfParameterContainsIsFixedVFalse()
        {
            string[] testParam = new[] { "StartFontMetrics", "IsFixedV false", "EndFontMetrics" };

            AfmFontMetrics testOutput = AfmFontMetrics.FromLines(testParam);

            Assert.IsFalse(testOutput.IsFixedV.Value);
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void AfmFontMetricsClass_FromLinesMethod_ThrowsAfmFormatException_IfParameterContainsIncompleteIsFixedVData()
        {
            string[] testParam = new[] { "StartFontMetrics", "IsFixedV", "EndFontMetrics" };

            _ = AfmFontMetrics.FromLines(testParam);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void AfmFontMetricsClass_FromLinesMethod_ThrowsAfmFormatException_IfParameterContainsInvalidIsFixedVData()
        {
            string invalidData = _rnd.NextString("abcdfghijklmnopqrstuvwyxz", _rnd.Next(1, 10));
            string[] testParam = new[] { "StartFontMetrics", $"IsFixedV {invalidData}", "EndFontMetrics" };

            _ = AfmFontMetrics.FromLines(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void AfmFontMetricsClass_FromLinesMethod_ReturnsObjectWithIsCIDFontPropertyEqualToTrue_IfParameterContainsIsCIDFontTrue()
        {
            string[] testParam = new[] { "StartFontMetrics", "IsCIDFont true", "EndFontMetrics" };

            AfmFontMetrics testOutput = AfmFontMetrics.FromLines(testParam);

            Assert.IsTrue(testOutput.IsCIDFont);
        }

        [TestMethod]
        public void AfmFontMetricsClass_FromLinesMethod_ReturnsObjectWithIsCIDFontPropertyEqualToFalse_IfParameterContainsIsCIDFontFalse()
        {
            string[] testParam = new[] { "StartFontMetrics", "IsCIDFont false", "EndFontMetrics" };

            AfmFontMetrics testOutput = AfmFontMetrics.FromLines(testParam);

            Assert.IsFalse(testOutput.IsCIDFont);
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void AfmFontMetricsClass_FromLinesMethod_ThrowsAfmFormatException_IfParameterContainsIncompleteIsCIDFontData()
        {
            string[] testParam = new[] { "StartFontMetrics", "IsCIDFont", "EndFontMetrics" };

            _ = AfmFontMetrics.FromLines(testParam);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void AfmFontMetricsClass_FromLinesMethod_ThrowsAfmFormatException_IfParameterContainsInvalidIsCIDFontData()
        {
            string invalidData = _rnd.NextString("abcdfghijklmnopqrstuvwyxz", _rnd.Next(1, 10));
            string[] testParam = new[] { "StartFontMetrics", $"IsCIDFont {invalidData}", "EndFontMetrics" };

            _ = AfmFontMetrics.FromLines(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void AfmFontMetricsClass_FromLinesMethod_ReturnsObjectWithCorrectCapHeightProperty_IfParameterContainsCapHeightData()
        {
            decimal expectedValue = _rnd.Next();
            string[] testParam = new[] { "StartFontMetrics", $"CapHeight {expectedValue.ToString(CultureInfo.InvariantCulture)}", "EndFontMetrics" };

            AfmFontMetrics testOutput = AfmFontMetrics.FromLines(testParam);

            Assert.AreEqual(expectedValue, testOutput.CapHeight.Value);
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void AfmFontMetricsClass_FromLinesMethod_ThrowsAfmFormatException_IfParameterContainsIncompleteCapHeightData()
        {
            string[] testParam = new[] { "StartFontMetrics", "CapHeight", "EndFontMetrics" };

            _ = AfmFontMetrics.FromLines(testParam);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void AfmFontMetricsClass_FromLinesMethod_ThrowsAfmFormatException_IfParameterContainsInvalidCapHeightData()
        {
            string invalidData = _rnd.NextString("abcdefghijklmnopqrstuvwyxz", _rnd.Next(1, 10));
            string[] testParam = new[] { "StartFontMetrics", $"CapHeight {invalidData}", "EndFontMetrics" };

            _ = AfmFontMetrics.FromLines(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void AfmFontMetricsClass_FromLinesMethod_ReturnsObjectWithCorrectAscenderProperty_IfParameterContainsAscenderData()
        {
            decimal expectedValue = _rnd.Next();
            string[] testParam = new[] { "StartFontMetrics", $"Ascender {expectedValue.ToString(CultureInfo.InvariantCulture)}", "EndFontMetrics" };

            AfmFontMetrics testOutput = AfmFontMetrics.FromLines(testParam);

            Assert.AreEqual(expectedValue, testOutput.Ascender.Value);
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void AfmFontMetricsClass_FromLinesMethod_ThrowsAfmFormatException_IfParameterContainsIncompleteAscenderData()
        {
            string[] testParam = new[] { "StartFontMetrics", "Ascender", "EndFontMetrics" };

            _ = AfmFontMetrics.FromLines(testParam);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void AfmFontMetricsClass_FromLinesMethod_ThrowsAfmFormatException_IfParameterContainsInvalidAscenderData()
        {
            string invalidData = _rnd.NextString("abcdefghijklmnopqrstuvwyxz", _rnd.Next(1, 10));
            string[] testParam = new[] { "StartFontMetrics", $"Ascender {invalidData}", "EndFontMetrics" };

            _ = AfmFontMetrics.FromLines(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void AfmFontMetricsClass_FromLinesMethod_ReturnsObjectWithCorrectDescenderProperty_IfParameterContainsDescenderData()
        {
            decimal expectedValue = _rnd.Next();
            string[] testParam = new[] { "StartFontMetrics", $"Descender {expectedValue.ToString(CultureInfo.InvariantCulture)}", "EndFontMetrics" };

            AfmFontMetrics testOutput = AfmFontMetrics.FromLines(testParam);

            Assert.AreEqual(expectedValue, testOutput.Descender.Value);
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void AfmFontMetricsClass_FromLinesMethod_ThrowsAfmFormatException_IfParameterContainsIncompleteDescenderData()
        {
            string[] testParam = new[] { "StartFontMetrics", "Descender", "EndFontMetrics" };

            _ = AfmFontMetrics.FromLines(testParam);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void AfmFontMetricsClass_FromLinesMethod_ThrowsAfmFormatException_IfParameterContainsInvalidDescenderData()
        {
            string invalidData = _rnd.NextString("abcdefghijklmnopqrstuvwyxz", _rnd.Next(1, 10));
            string[] testParam = new[] { "StartFontMetrics", $"Descender {invalidData}", "EndFontMetrics" };

            _ = AfmFontMetrics.FromLines(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void AfmFontMetricsClass_FromLinesMethod_ReturnsObjectWithCorrectXHeightProperty_IfParameterContainsXHeightData()
        {
            decimal expectedValue = _rnd.Next();
            string[] testParam = new[] { "StartFontMetrics", $"XHeight {expectedValue.ToString(CultureInfo.InvariantCulture)}", "EndFontMetrics" };

            AfmFontMetrics testOutput = AfmFontMetrics.FromLines(testParam);

            Assert.AreEqual(expectedValue, testOutput.XHeight.Value);
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void AfmFontMetricsClass_FromLinesMethod_ThrowsAfmFormatException_IfParameterContainsIncompleteXHeightData()
        {
            string[] testParam = new[] { "StartFontMetrics", "XHeight", "EndFontMetrics" };

            _ = AfmFontMetrics.FromLines(testParam);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void AfmFontMetricsClass_FromLinesMethod_ThrowsAfmFormatException_IfParameterContainsInvalidXHeightData()
        {
            string invalidData = _rnd.NextString("abcdefghijklmnopqrstuvwyxz", _rnd.Next(1, 10));
            string[] testParam = new[] { "StartFontMetrics", $"XHeight {invalidData}", "EndFontMetrics" };

            _ = AfmFontMetrics.FromLines(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void AfmFontMetricsClass_FromLinesMethod_ReturnsObjectWithCorrectStdHWProperty_IfParameterContainsStdHWData()
        {
            decimal expectedValue = _rnd.Next();
            string[] testParam = new[] { "StartFontMetrics", $"StdHW {expectedValue.ToString(CultureInfo.InvariantCulture)}", "EndFontMetrics" };

            AfmFontMetrics testOutput = AfmFontMetrics.FromLines(testParam);

            Assert.AreEqual(expectedValue, testOutput.StdHW.Value);
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void AfmFontMetricsClass_FromLinesMethod_ThrowsAfmFormatException_IfParameterContainsIncompleteStdHWData()
        {
            string[] testParam = new[] { "StartFontMetrics", "StdHW", "EndFontMetrics" };

            _ = AfmFontMetrics.FromLines(testParam);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void AfmFontMetricsClass_FromLinesMethod_ThrowsAfmFormatException_IfParameterContainsInvalidStdHWData()
        {
            string invalidData = _rnd.NextString("abcdefghijklmnopqrstuvwyxz", _rnd.Next(1, 10));
            string[] testParam = new[] { "StartFontMetrics", $"StdHW {invalidData}", "EndFontMetrics" };

            _ = AfmFontMetrics.FromLines(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void AfmFontMetricsClass_FromLinesMethod_ReturnsObjectWithCorrectStdVWProperty_IfParameterContainsStdVWData()
        {
            decimal expectedValue = _rnd.Next();
            string[] testParam = new[] { "StartFontMetrics", $"StdVW {expectedValue.ToString(CultureInfo.InvariantCulture)}", "EndFontMetrics" };

            AfmFontMetrics testOutput = AfmFontMetrics.FromLines(testParam);

            Assert.AreEqual(expectedValue, testOutput.StdVW.Value);
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void AfmFontMetricsClass_FromLinesMethod_ThrowsAfmFormatException_IfParameterContainsIncompleteStdVWData()
        {
            string[] testParam = new[] { "StartFontMetrics", "StdVW", "EndFontMetrics" };

            _ = AfmFontMetrics.FromLines(testParam);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void AfmFontMetricsClass_FromLinesMethod_ThrowsAfmFormatException_IfParameterContainsInvalidStdVWData()
        {
            string invalidData = _rnd.NextString("abcdefghijklmnopqrstuvwyxz", _rnd.Next(1, 10));
            string[] testParam = new[] { "StartFontMetrics", $"StdVW {invalidData}", "EndFontMetrics" };

            _ = AfmFontMetrics.FromLines(testParam);

            Assert.Fail();
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
