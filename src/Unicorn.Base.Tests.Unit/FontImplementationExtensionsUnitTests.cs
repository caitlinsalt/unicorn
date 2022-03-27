using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Tests.Utility.Providers;

namespace Unicorn.Base.Tests.Unit
{
    [TestClass]
    public class FontImplementationExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void FontImplementationExtensionsClass_ToSubtypeNameMethod_ReturnsType1_WhenValueIsType1()
        {
            FontImplementation testInput = FontImplementation.Type1;

            string testOutput = testInput.ToSubtypeName();

            Assert.AreEqual("Type1", testOutput);
        }

        [TestMethod]
        public void FontImplementationExtensionsClass_ToSubtypeNameMethod_ReturnsType1_WhenValueIsStandardType1()
        {
            FontImplementation testInput = FontImplementation.StandardType1;

            string testOutput = testInput.ToSubtypeName();

            Assert.AreEqual("Type1", testOutput);
        }

        [TestMethod]
        public void FontImplementationExtensionsClass_ToSubtypeNameMethod_ReturnsTrueType_WhenValueIsOpenType()
        {
            FontImplementation testInput = FontImplementation.OpenType;

            string testOutput = testInput.ToSubtypeName();

            Assert.AreEqual("TrueType", testOutput);
        }

        [TestMethod]
        public void FontImplementationExtensionsClass_ToSubtypeNameMethod_ReturnsNull_WhenValueIsOther()
        {
            FontImplementation testInput = FontImplementation.Other;

            string testOutput = testInput.ToSubtypeName();

            Assert.IsNull(testOutput);
        }

#pragma warning disable CA5394 // Do not use insecure randomness

        [TestMethod]
        public void FontImplementationExtensionsClass_ToSubtypeNameMethod_ReturnsNull_WhenValueIsNotAValidFontImplementation()
        {
            FontImplementation[] validValues = new[]
            {
                FontImplementation.StandardType1,
                FontImplementation.Type1,
                FontImplementation.OpenType,
                FontImplementation.Other
            };
            int testInputRaw;
            do
            {
                testInputRaw = _rnd.Next();
            } while (validValues.Contains((FontImplementation)testInputRaw));
            FontImplementation testInput = (FontImplementation)testInputRaw;

            string testOutput = testInput.ToSubtypeName();

            Assert.IsNull(testOutput);
        }

#pragma warning restore CA5394 // Do not use insecure randomness

        [TestMethod]
        public void FontImplementationExtensionsClass_IsStandardFontMethod_ReturnsFalse_WhenValueIsType1()
        {
            FontImplementation testInput = FontImplementation.Type1;

            bool testOutput = testInput.IsStandardFont();

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void FontImplementationExtensionsClass_IsStandardFontMethod_ReturnsTrue_WhenValueIsStandardType1()
        {
            FontImplementation testInput = FontImplementation.StandardType1;

            bool testOutput = testInput.IsStandardFont();

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void FontImplementationExtensionsClass_IsStandardFontMethod_ReturnsFalse_WhenValueIsOpenType()
        {
            FontImplementation testInput = FontImplementation.OpenType;

            bool testOutput = testInput.IsStandardFont();

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void FontImplementationExtensionsClass_IsStandardFontMethod_ReturnsFalse_WhenValueIsOther()
        {
            FontImplementation testInput = FontImplementation.Other;

            bool testOutput = testInput.IsStandardFont();

            Assert.IsFalse(testOutput);
        }

#pragma warning disable CA5394 // Do not use insecure randomness

        [TestMethod]
        public void FontImplementationExtensionsClass_IsStandardFontMethod_ReturnsFalse_WhenValueIsNotAValidFontImplementationValue()
        {
            FontImplementation[] validValues = new[]
            {
                FontImplementation.StandardType1,
                FontImplementation.Type1,
                FontImplementation.OpenType,
                FontImplementation.Other
            };
            int testInputRaw;
            do
            {
                testInputRaw = _rnd.Next();
            } while (validValues.Contains((FontImplementation)testInputRaw));
            FontImplementation testInput = (FontImplementation)testInputRaw;

            bool testOutput = testInput.IsStandardFont();

            Assert.IsFalse(testOutput);
        }

#pragma warning restore CA5394 // Do not use insecure randomness

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
