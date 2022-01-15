using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.FontTools.Afm;

namespace Unicorn.FontTools.Tests.Unit.Afm
{
    [TestClass]
    public class LoadingHelpersUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness

        private static string WhiteSpace(int minLength = 1) => _rnd.NextString(" ", _rnd.Next(minLength, 10));

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadingHelpersClass_LoadKeyedDecimalMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            string testParam0 = null;
            string testParam1 = _rnd.NextString(_rnd.Next(1, 10));

            _ = LoadingHelpers.LoadKeyedDecimal(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadingHelpersClass_LoadKeyedDecimalMethod_ThrowsArgumentNullException_IfSecondParameterIsNull()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam1 = null;

            _ = LoadingHelpers.LoadKeyedDecimal(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void LoadingHelpersClass_LoadKeyedDecimalMethod_ThrowsAfmFormatException_IfFirstParameterIsShorterThanSecondParameter()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam1 = _rnd.NextString(_rnd.Next(testParam0.Length + 1, testParam0.Length + 11));

            _ = LoadingHelpers.LoadKeyedDecimal(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void LoadingHelpersClass_LoadKeyedDecimalMethod_ThrowsAfmFormatException_IfFirstParameterIsSameLengthAsSecondParameter()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam1 = _rnd.NextString(testParam0.Length);

            _ = LoadingHelpers.LoadKeyedDecimal(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void LoadingHelpersClass_LoadKeyedDecimalMethod_ThrowsAfmFormatException_IfFirstParameterConsistsOfSecondParameterPlusWhiteSpace()
        {
            string testParam1 = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));
            string testParam0 = testParam1 + WhiteSpace();

            _ = LoadingHelpers.LoadKeyedDecimal(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void LoadingHelpersClass_LoadKeyedDecimalMethod_ThrowsAfmFormatException_IfFirstParameterDataIsNotValidNumber()
        {
            string testParam1 = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));
            string testParam0 = testParam1 + WhiteSpace() + _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));

            _ = LoadingHelpers.LoadKeyedDecimal(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void LoadingHelpersClass_LoadKeyedDecimalMethod_ReturnsExpectedValue_IfDataIsValid()
        {
            decimal expectedValue = _rnd.NextDecimal();
            string testParam1 = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));
            string testParam0 = testParam1 + WhiteSpace() + expectedValue.ToString(CultureInfo.InvariantCulture);

            decimal testOutput = LoadingHelpers.LoadKeyedDecimal(testParam0, testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadingHelpersClass_LoadKeyedIntMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            string testParam0 = null;
            string testParam1 = _rnd.NextString(_rnd.Next(1, 10));

            _ = LoadingHelpers.LoadKeyedInt(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadingHelpersClass_LoadKeyedIntMethod_ThrowsArgumentNullException_IfSecondParameterIsNull()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam1 = null;

            _ = LoadingHelpers.LoadKeyedInt(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void LoadingHelpersClass_LoadKeyedIntMethod_ThrowsAfmFormatException_IfFirstParameterIsShorterThanSecondParameter()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam1 = _rnd.NextString(_rnd.Next(testParam0.Length + 1, testParam0.Length + 11));

            _ = LoadingHelpers.LoadKeyedInt(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void LoadingHelpersClass_LoadKeyedIntMethod_ThrowsAfmFormatException_IfFirstParameterIsSameLengthAsSecondParameter()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam1 = _rnd.NextString(testParam0.Length);

            _ = LoadingHelpers.LoadKeyedInt(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void LoadingHelpersClass_LoadKeyedIntMethod_ThrowsAfmFormatException_IfFirstParameterConsistsOfSecondParameterPlusWhiteSpace()
        {
            string testParam1 = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));
            string testParam0 = testParam1 + WhiteSpace();

            _ = LoadingHelpers.LoadKeyedInt(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void LoadingHelpersClass_LoadKeyedIntMethod_ThrowsAfmFormatException_IfFirstParameterDataIsNotValidNumber()
        {
            string testParam1 = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));
            string testParam0 = testParam1 + WhiteSpace() + _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));

            _ = LoadingHelpers.LoadKeyedInt(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void LoadingHelpersClass_LoadKeyedIntMethod_ReturnsExpectedValue_IfDataIsValid()
        {
            int expectedValue = _rnd.Next() - int.MaxValue / 2;
            string testParam1 = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));
            string testParam0 = testParam1 + WhiteSpace() + expectedValue.ToString(CultureInfo.InvariantCulture);

            int testOutput = LoadingHelpers.LoadKeyedInt(testParam0, testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadingHelpersClass_LoadKeyedStringMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            string testParam0 = null;
            string testParam1 = _rnd.NextString(_rnd.Next(1, 10));

            _ = LoadingHelpers.LoadKeyedString(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadingHelpersClass_LoadKeyedStringMethod_ThrowsArgumentNullException_IfSecondParameterIsNull()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam1 = null;

            _ = LoadingHelpers.LoadKeyedString(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void LoadingHelpersClass_LoadKeyedStringMethod_ThrowsAfmFormatException_IfFirstParameterIsShorterThanSecondParameter()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam1 = _rnd.NextString(_rnd.Next(testParam0.Length + 1, testParam0.Length + 11));

            _ = LoadingHelpers.LoadKeyedString(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void LoadingHelpersClass_LoadKeyedStringMethod_ThrowsAfmFormatException_IfFirstParameterIsSameLengthAsSecondParameter()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam1 = _rnd.NextString(testParam0.Length);

            _ = LoadingHelpers.LoadKeyedString(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void LoadingHelpersClass_LoadKeyedStringMethod_ThrowsAfmFormatException_IfFirstParameterConsistsOfSecondParameterPlusWhiteSpace()
        {
            string testParam1 = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));
            string testParam0 = testParam1 + WhiteSpace();

            _ = LoadingHelpers.LoadKeyedString(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void LoadingHelpersClass_LoadKeyedStringMethod_ReturnsExpectedValue_IfDataIsValid()
        {
            string expectedValue = _rnd.NextString(_rnd.Next(1, 20));
            string testParam1 = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));
            string testParam0 = testParam1 + WhiteSpace() + expectedValue;

            string testOutput = LoadingHelpers.LoadKeyedString(testParam0, testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadingHelpersClass_LoadKeyedVectorMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            string testParam0 = null;
            string testParam1 = _rnd.NextString(_rnd.Next(1, 10));

            _ = LoadingHelpers.LoadKeyedVector(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadingHelpersClass_LoadKeyedVectorMethod_ThrowsArgumentNullException_IfSecondParameterIsNull()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam1 = null;

            _ = LoadingHelpers.LoadKeyedVector(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void LoadingHelpersClass_LoadKeyedVectorMethod_ThrowsAfmFormatException_IfFirstParameterIsShorterThanSecondParameter()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam1 = _rnd.NextString(_rnd.Next(testParam0.Length + 1, testParam0.Length + 11));

            _ = LoadingHelpers.LoadKeyedVector(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void LoadingHelpersClass_LoadKeyedVectorMethod_ThrowsAfmFormatException_IfFirstParameterIsSameLengthAsSecondParameter()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam1 = _rnd.NextString(testParam0.Length);

            _ = LoadingHelpers.LoadKeyedVector(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void LoadingHelpersClass_LoadKeyedVectorMethod_ThrowsAfmFormatException_IfFirstParameterConsistsOfSecondParameterPlusWhiteSpace()
        {
            string testParam1 = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));
            string testParam0 = testParam1 + WhiteSpace();

            _ = LoadingHelpers.LoadKeyedVector(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void LoadingHelpersClass_LoadKeyedVectorMethod_ThrowsAfmFormatException_IfFirstParameterContainsSingleNumber()
        {
            decimal xVector = _rnd.NextDecimal();
            string testParam1 = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));
            string testParam0 = testParam1 + WhiteSpace() + xVector.ToString(CultureInfo.InvariantCulture);

            _ = LoadingHelpers.LoadKeyedVector(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void LoadingHelpersClass_LoadKeyedVectorMethod_ThrowsAfmFormatException_IfFirstParameterContainsDataWhereFirstPartOfVectorIsNotANumber()
        {
            decimal yVector = _rnd.NextDecimal();
            string testParam1 = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));
            string testParam0 = testParam1 + WhiteSpace() + _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10)) + WhiteSpace() + 
                yVector.ToString(CultureInfo.InvariantCulture);

            _ = LoadingHelpers.LoadKeyedVector(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void LoadingHelpersClass_LoadKeyedVectorMethod_ThrowsAfmFormatException_IfFirstParameterContainsDataWhereSecondPartOfVectorIsNotANumber()
        {
            decimal xVector = _rnd.NextDecimal();
            string testParam1 = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));
            string testParam0 = testParam1 + WhiteSpace() + xVector.ToString(CultureInfo.InvariantCulture) + WhiteSpace() + 
                _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));

            _ = LoadingHelpers.LoadKeyedVector(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void LoadingHelpersClass_LoadKeyedVectorMethod_ReturnsValueWithCorrectXProperty_IfDataIsValid()
        {
            decimal xVector = _rnd.NextDecimal();
            decimal yVector = _rnd.NextDecimal();
            string testParam1 = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));
            string testParam0 = testParam1 + WhiteSpace() + xVector.ToString(CultureInfo.InvariantCulture) + WhiteSpace() + 
                yVector.ToString(CultureInfo.InvariantCulture);

            Vector testOutput = LoadingHelpers.LoadKeyedVector(testParam0, testParam1);

            Assert.AreEqual(xVector, testOutput.X);
        }

        [TestMethod]
        public void LoadingHelpersClass_LoadKeyedVectorMethod_ReturnsValueWithCorrectYProperty_IfDataIsValid()
        {
            decimal xVector = _rnd.NextDecimal();
            decimal yVector = _rnd.NextDecimal();
            string testParam1 = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));
            string testParam0 = testParam1 + WhiteSpace() + xVector.ToString(CultureInfo.InvariantCulture) + WhiteSpace() +
                yVector.ToString(CultureInfo.InvariantCulture);

            Vector testOutput = LoadingHelpers.LoadKeyedVector(testParam0, testParam1);

            Assert.AreEqual(yVector, testOutput.Y);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadingHelpersClass_LoadKeyedBoundingBoxMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            string testParam0 = null;
            string testParam1 = _rnd.NextString(_rnd.Next(1, 10));

            _ = LoadingHelpers.LoadKeyedBoundingBox(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadingHelpersClass_LoadKeyedBoundingBoxMethod_ThrowsArgumentNullException_IfSecondParameterIsNull()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam1 = null;

            _ = LoadingHelpers.LoadKeyedBoundingBox(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void LoadingHelpersClass_LoadKeyedBoundingBoxMethod_ThrowsAfmFormatException_IfFirstParameterIsShorterThanSecondParameter()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam1 = _rnd.NextString(_rnd.Next(testParam0.Length + 1, testParam0.Length + 11));

            _ = LoadingHelpers.LoadKeyedBoundingBox(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void LoadingHelpersClass_LoadKeyedBoundingBoxMethod_ThrowsAfmFormatException_IfFirstParameterIsSameLengthAsSecondParameter()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam1 = _rnd.NextString(testParam0.Length);

            _ = LoadingHelpers.LoadKeyedBoundingBox(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void LoadingHelpersClass_LoadKeyedBoundingBoxMethod_ThrowsAfmFormatException_IfFirstParameterConsistsOfSecondParameterPlusWhiteSpace()
        {
            string testParam1 = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));
            string testParam0 = testParam1 + WhiteSpace();

            _ = LoadingHelpers.LoadKeyedBoundingBox(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void LoadingHelpersClass_LoadKeyedBoundingBoxMethod_ThrowsAfmFormatException_IfFirstParameterContainsSingleNumber()
        {
            decimal lValue = _rnd.NextDecimal();
            string testParam1 = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));
            string testParam0 = testParam1 + WhiteSpace() + lValue.ToString(CultureInfo.InvariantCulture);

            _ = LoadingHelpers.LoadKeyedBoundingBox(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void LoadingHelpersClass_LoadKeyedBoundingBoxMethod_ThrowsAfmFormatException_IfFirstParameterContainsTwoNumbers()
        {
            decimal lValue = _rnd.NextDecimal();
            decimal bValue = _rnd.NextDecimal();
            string testParam1 = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));
            string testParam0 = testParam1 + WhiteSpace() + lValue.ToString(CultureInfo.InvariantCulture) + WhiteSpace() + 
                bValue.ToString(CultureInfo.InvariantCulture);

            _ = LoadingHelpers.LoadKeyedBoundingBox(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void LoadingHelpersClass_LoadKeyedBoundingBoxMethod_ThrowsAfmFormatException_IfFirstParameterContainsThreeNumbers()
        {
            decimal lValue = _rnd.NextDecimal();
            decimal bValue = _rnd.NextDecimal();
            decimal rValue = _rnd.NextDecimal();
            string testParam1 = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));
            string testParam0 = testParam1 + WhiteSpace() + lValue.ToString(CultureInfo.InvariantCulture) + WhiteSpace() +
                bValue.ToString(CultureInfo.InvariantCulture) + WhiteSpace() + rValue.ToString(CultureInfo.InvariantCulture);

            _ = LoadingHelpers.LoadKeyedBoundingBox(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void LoadingHelpersClass_LoadKeyedBoundingBoxMethod_ThrowsAfmFormatException_IfFirstParameterContainsDataWhereFirstPartOfBoundingBoxDataIsNotANumber()
        {
            decimal bValue = _rnd.NextDecimal();
            decimal rValue = _rnd.NextDecimal();
            decimal tValue = _rnd.NextDecimal();
            string testParam1 = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));
            string testParam0 = testParam1 + WhiteSpace() + _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10)) + WhiteSpace() +
                bValue.ToString(CultureInfo.InvariantCulture) + WhiteSpace() + rValue.ToString(CultureInfo.InvariantCulture) + WhiteSpace() +
                tValue.ToString(CultureInfo.InvariantCulture);

            _ = LoadingHelpers.LoadKeyedBoundingBox(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void LoadingHelpersClass_LoadKeyedBoundingBoxMethod_ThrowsAfmFormatException_IfFirstParameterContainsDataWhereSecondPartOfBoundingBoxDataIsNotANumber()
        {
            decimal lValue = _rnd.NextDecimal();
            decimal rValue = _rnd.NextDecimal();
            decimal tValue = _rnd.NextDecimal();
            string testParam1 = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));
            string testParam0 = testParam1 + WhiteSpace() + lValue.ToString(CultureInfo.InvariantCulture) + WhiteSpace() +
                _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10)) + WhiteSpace() + rValue.ToString(CultureInfo.InvariantCulture) + WhiteSpace() +
                tValue.ToString(CultureInfo.InvariantCulture);

            _ = LoadingHelpers.LoadKeyedBoundingBox(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void LoadingHelpersClass_LoadKeyedBoundingBoxMethod_ThrowsAfmFormatException_IfFirstParameterContainsDataWhereThirdPartOfBoundingBoxDataIsNotANumber()
        {
            decimal lValue = _rnd.NextDecimal();
            decimal bValue = _rnd.NextDecimal();
            decimal tValue = _rnd.NextDecimal();
            string testParam1 = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));
            string testParam0 = testParam1 + WhiteSpace() + lValue.ToString(CultureInfo.InvariantCulture) + WhiteSpace() +
                bValue.ToString(CultureInfo.InvariantCulture) + WhiteSpace() + _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10)) + WhiteSpace() +
                tValue.ToString(CultureInfo.InvariantCulture);

            _ = LoadingHelpers.LoadKeyedBoundingBox(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void LoadingHelpersClass_LoadKeyedBoundingBoxMethod_ThrowsAfmFormatException_IfFirstParameterContainsDataWhereFourthPartOfBoundingBoxDataIsNotANumber()
        {
            decimal lValue = _rnd.NextDecimal();
            decimal bValue = _rnd.NextDecimal();
            decimal rValue = _rnd.NextDecimal();
            string testParam1 = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));
            string testParam0 = testParam1 + WhiteSpace() + lValue.ToString(CultureInfo.InvariantCulture) + WhiteSpace() +
                bValue.ToString(CultureInfo.InvariantCulture) + WhiteSpace() + rValue.ToString(CultureInfo.InvariantCulture) + WhiteSpace() +
                _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));

            _ = LoadingHelpers.LoadKeyedBoundingBox(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void LoadingHelpersClass_LoadKeyedBoundingBoxMethod_ReturnsValueWithCorrectLeftProperty_IfDataIsValid()
        {
            decimal lValue = _rnd.NextDecimal();
            decimal bValue = _rnd.NextDecimal();
            decimal rValue = _rnd.NextDecimal();
            decimal tValue = _rnd.NextDecimal();
            string testParam1 = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));
            string testParam0 = testParam1 + WhiteSpace() + lValue.ToString(CultureInfo.InvariantCulture) + WhiteSpace() +
                bValue.ToString(CultureInfo.InvariantCulture) + WhiteSpace() + rValue.ToString(CultureInfo.InvariantCulture) + WhiteSpace() +
                tValue.ToString(CultureInfo.InvariantCulture);

            BoundingBox testOutput = LoadingHelpers.LoadKeyedBoundingBox(testParam0, testParam1);

            Assert.AreEqual(lValue, testOutput.Left);
        }

        [TestMethod]
        public void LoadingHelpersClass_LoadKeyedBoundingBoxMethod_ReturnsValueWithCorrectBottomProperty_IfDataIsValid()
        {
            decimal lValue = _rnd.NextDecimal();
            decimal bValue = _rnd.NextDecimal();
            decimal rValue = _rnd.NextDecimal();
            decimal tValue = _rnd.NextDecimal();
            string testParam1 = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));
            string testParam0 = testParam1 + WhiteSpace() + lValue.ToString(CultureInfo.InvariantCulture) + WhiteSpace() +
                bValue.ToString(CultureInfo.InvariantCulture) + WhiteSpace() + rValue.ToString(CultureInfo.InvariantCulture) + WhiteSpace() +
                tValue.ToString(CultureInfo.InvariantCulture);

            BoundingBox testOutput = LoadingHelpers.LoadKeyedBoundingBox(testParam0, testParam1);

            Assert.AreEqual(bValue, testOutput.Bottom);
        }

        [TestMethod]
        public void LoadingHelpersClass_LoadKeyedBoundingBoxMethod_ReturnsValueWithCorrectRightProperty_IfDataIsValid()
        {
            decimal lValue = _rnd.NextDecimal();
            decimal bValue = _rnd.NextDecimal();
            decimal rValue = _rnd.NextDecimal();
            decimal tValue = _rnd.NextDecimal();
            string testParam1 = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));
            string testParam0 = testParam1 + WhiteSpace() + lValue.ToString(CultureInfo.InvariantCulture) + WhiteSpace() +
                bValue.ToString(CultureInfo.InvariantCulture) + WhiteSpace() + rValue.ToString(CultureInfo.InvariantCulture) + WhiteSpace() +
                tValue.ToString(CultureInfo.InvariantCulture);

            BoundingBox testOutput = LoadingHelpers.LoadKeyedBoundingBox(testParam0, testParam1);

            Assert.AreEqual(rValue, testOutput.Right);
        }

        [TestMethod]
        public void LoadingHelpersClass_LoadKeyedBoundingBoxMethod_ReturnsValueWithCorrectTopProperty_IfDataIsValid()
        {
            decimal lValue = _rnd.NextDecimal();
            decimal bValue = _rnd.NextDecimal();
            decimal rValue = _rnd.NextDecimal();
            decimal tValue = _rnd.NextDecimal();
            string testParam1 = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));
            string testParam0 = testParam1 + WhiteSpace() + lValue.ToString(CultureInfo.InvariantCulture) + WhiteSpace() +
                bValue.ToString(CultureInfo.InvariantCulture) + WhiteSpace() + rValue.ToString(CultureInfo.InvariantCulture) + WhiteSpace() +
                tValue.ToString(CultureInfo.InvariantCulture);

            BoundingBox testOutput = LoadingHelpers.LoadKeyedBoundingBox(testParam0, testParam1);

            Assert.AreEqual(tValue, testOutput.Top);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadingHelpersClass_LoadKeyedBoolMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            string testParam0 = null;
            string testParam1 = _rnd.NextString(_rnd.Next(1, 10));

            _ = LoadingHelpers.LoadKeyedBool(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadingHelpersClass_LoadKeyedBoolMethod_ThrowsArgumentNullException_IfSecondParameterIsNull()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam1 = null;

            _ = LoadingHelpers.LoadKeyedBool(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void LoadingHelpersClass_LoadKeyedBoolMethod_ThrowsAfmFormatException_IfFirstParameterIsShorterThanSecondParameter()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam1 = _rnd.NextString(_rnd.Next(testParam0.Length + 1, testParam0.Length + 11));

            _ = LoadingHelpers.LoadKeyedBool(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void LoadingHelpersClass_LoadKeyedBoolMethod_ThrowsAfmFormatException_IfFirstParameterIsSameLengthAsSecondParameter()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam1 = _rnd.NextString(testParam0.Length);

            _ = LoadingHelpers.LoadKeyedBool(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void LoadingHelpersClass_LoadKeyedBoolMethod_ThrowsAfmFormatException_IfFirstParameterConsistsOfSecondParameterPlusWhiteSpace()
        {
            string testParam1 = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));
            string testParam0 = testParam1 + WhiteSpace();

            _ = LoadingHelpers.LoadKeyedBool(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void LoadingHelpersClass_LoadKeyedBoolMethod_ThrowsAfmFormatException_IfFirstParameterDoesNotContainTrueOrFalse()
        {
            string badData;
            do
            {
                badData = _rnd.NextString(_rnd.Next(1, 10));
            } while (badData == "true" || badData == "false");
            string testParam1 = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));
            string testParam0 = testParam1 + WhiteSpace() + badData;

            _ = LoadingHelpers.LoadKeyedBool(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void LoadingHelpersClass_LoadKeyedBoolMethod_ReturnsTrue_IfFirstParameterEndsInTrue()
        {
            string testParam1 = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));
            string testParam0 = testParam1 + WhiteSpace() + "true" + WhiteSpace(0);

            bool testOutput = LoadingHelpers.LoadKeyedBool(testParam0, testParam1);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void LoadingHelpersClass_LoadKeyedBoolMethod_ReturnsFalse_IfFirstParameterEndsInFalse()
        {
            string testParam1 = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));
            string testParam0 = testParam1 + WhiteSpace() + "false" + WhiteSpace(0);

            bool testOutput = LoadingHelpers.LoadKeyedBool(testParam0, testParam1);

            Assert.IsFalse(testOutput);
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
