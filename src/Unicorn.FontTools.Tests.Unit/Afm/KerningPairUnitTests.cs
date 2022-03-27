using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TestUtilities = Tests.Utility;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.FontTools.Afm;
using Unicorn.FontTools.Tests.Utility;
using System.Globalization;
using System.Linq;

namespace Unicorn.FontTools.Tests.Unit.Afm
{
    [TestClass]
    public class KerningPairUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness

        private static string GenerateRandomValidStringInput(string code = null, string char1 = null, string char2 = null, string x = null, string y = null)
        {
            string[] validCodes = new[] { "KP", "KPH", "KPX", "KPY" };
            if (code is null)
            {
                code = validCodes[_rnd.Next(validCodes.Length)];
            }
            if (code != "KPH")
            {
                if (char1 is null)
                {
                    char1 = _rnd.NextString(TestUtilities.Extensions.RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));
                }
                if (char2 is null)
                {
                    char2 = _rnd.NextString(TestUtilities.Extensions.RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));
                }
            }
            else
            {
                if (char1 is null)
                {
                    char1 = HexCode(_rnd.NextShort());
                }
                if (char2 is null)
                {
                    char2 = HexCode(_rnd.NextShort());
                }
            }
            if (x is null)
            {
                x = _rnd.NextDecimal().ToString(CultureInfo.InvariantCulture);
            }
            if (code == "KPH" || code == "KP")
            {
                if (y is null)
                {
                    y = _rnd.NextDecimal().ToString(CultureInfo.InvariantCulture);
                }
                return $"{code} {char1} {char2} {x} {y}";
            }
            return $"{code} {char1} {char2} {x}";
        }

        private static string HexCode(short val) => $"<{val.ToString("X4", CultureInfo.InvariantCulture)}>";

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void KerningPairStruct_ParameterlessConstructor_SetsFirstPropertyToNull()
        {
            KerningPair testOutput = new();

            Assert.IsNull(testOutput.First);
        }

        [TestMethod]
        public void KerningPairStruct_ParameterlessConstructor_SetsSecondPropertyToNull()
        {
            KerningPair testOutput = new();

            Assert.IsNull(testOutput.Second);
        }

        [TestMethod]
        public void KerningPairStruct_ParameterlessConstructor_SetsKerningVectorPropertyToDefaultValue()
        {
            KerningPair testOutput = new();

            Assert.AreEqual(default, testOutput.KerningVector);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void KerningPairStruct_ConstructorWithCharacterCharacterAndVectorParameters_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            Character testParam0 = null;
            Character testParam1 = _rnd.NextAfmCharacter();
            Vector testParam2 = _rnd.NextAfmVector();

            _ = new KerningPair(testParam0, testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void KerningPairStruct_ConstructorWithCharacterCharacterAndVectorParameters_ThrowsArgumentNullException_IfSecondParameterIsNull()
        {
            Character testParam0 = _rnd.NextAfmCharacter();
            Character testParam1 = null;
            Vector testParam2 = _rnd.NextAfmVector();

            _ = new KerningPair(testParam0, testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        public void KerningPairStruct_ConstructorWithCharacterCharacterAndVectorParameters_SetsFirstPropertyToValueOfFirstParameter()
        {
            Character testParam0 = _rnd.NextAfmCharacter();
            Character testParam1 = _rnd.NextAfmCharacter();
            Vector testParam2 = _rnd.NextAfmVector();

            KerningPair testOutput = new(testParam0, testParam1, testParam2);

            Assert.AreSame(testParam0, testOutput.First);
        }

        [TestMethod]
        public void KerningPairStruct_ConstructorWithCharacterCharacterAndVectorParameters_SetsSecondPropertyToValueOfSecondParameter()
        {
            Character testParam0 = _rnd.NextAfmCharacter();
            Character testParam1 = _rnd.NextAfmCharacter();
            Vector testParam2 = _rnd.NextAfmVector();

            KerningPair testOutput = new(testParam0, testParam1, testParam2);

            Assert.AreSame(testParam1, testOutput.Second);
        }

        [TestMethod]
        public void KerningPairStruct_ConstructorWithCharacterCharacterAndVectorParameters_SetsKerningVectorPropertyToValueOfThirdParameter()
        {
            Character testParam0 = _rnd.NextAfmCharacter();
            Character testParam1 = _rnd.NextAfmCharacter();
            Vector testParam2 = _rnd.NextAfmVector();

            KerningPair testOutput = new(testParam0, testParam1, testParam2);

            Assert.AreEqual(testParam2, testOutput.KerningVector);
        }

        [TestMethod]
        public void KerningPairStruct_EqualsMethodWithKerningPairParameter_ReturnsTrue_IfParameterIsThis()
        {
            Character constrParam0 = _rnd.NextAfmCharacter();
            Character constrParam1 = _rnd.NextAfmCharacter();
            Vector constrParam2 = _rnd.NextAfmVector();
            KerningPair testObject = new(constrParam0, constrParam1, constrParam2);

            bool testOutput = testObject.Equals(testObject);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void KerningPairStruct_EqualsMethodWithKerningPairParameter_ReturnsTrue_IfParameterWasConstructedFromSameData()
        {
            Character constrParam0 = _rnd.NextAfmCharacter();
            Character constrParam1 = _rnd.NextAfmCharacter();
            Vector constrParam2 = _rnd.NextAfmVector();
            KerningPair testObject = new(constrParam0, constrParam1, constrParam2);
            KerningPair testParam = new(testObject.First, testObject.Second, testObject.KerningVector);

            bool testOutput = testObject.Equals(testParam);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void KerningPairStruct_EqualsMethodWithKerningPairParameter_ReturnsFalse_IfParameterDiffersByFirstProperty()
        {
            Character constrParam0 = _rnd.NextAfmCharacter();
            Character constrParam1 = _rnd.NextAfmCharacter();
            Vector constrParam2 = _rnd.NextAfmVector();
            KerningPair testObject = new(constrParam0, constrParam1, constrParam2);
            KerningPair testParam = new(_rnd.NextAfmCharacter(), testObject.Second, testObject.KerningVector);

            bool testOutput = testObject.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void KerningPairStruct_EqualsMethodWithKerningPairParameter_ReturnsFalse_IfParameterDiffersBySecondProperty()
        {
            Character constrParam0 = _rnd.NextAfmCharacter();
            Character constrParam1 = _rnd.NextAfmCharacter();
            Vector constrParam2 = _rnd.NextAfmVector();
            KerningPair testObject = new(constrParam0, constrParam1, constrParam2);
            KerningPair testParam = new(testObject.First, _rnd.NextAfmCharacter(), testObject.KerningVector);

            bool testOutput = testObject.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void KerningPairStruct_EqualsMethodWithKerningPairParameter_ReturnsFalse_IfParameterDiffersByKerningVectorProperty()
        {
            Character constrParam0 = _rnd.NextAfmCharacter();
            Character constrParam1 = _rnd.NextAfmCharacter();
            Vector constrParam2 = _rnd.NextAfmVector();
            KerningPair testObject = new(constrParam0, constrParam1, constrParam2);
            Vector constrParam3;
            do
            {
                constrParam3 = _rnd.NextAfmVector();
            } while (constrParam3 == testObject.KerningVector);
            KerningPair testParam = new(testObject.First, testObject.Second, constrParam3);

            bool testOutput = testObject.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void KerningPairStruct_EqualsMethodWithObjectParameter_ReturnsTrue_IfParameterIsThis()
        {
            Character constrParam0 = _rnd.NextAfmCharacter();
            Character constrParam1 = _rnd.NextAfmCharacter();
            Vector constrParam2 = _rnd.NextAfmVector();
            KerningPair testObject = new(constrParam0, constrParam1, constrParam2);

            bool testOutput = testObject.Equals((object)testObject);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void KerningPairStruct_EqualsMethodWithObjectParameter_ReturnsTrue_IfParameterWasConstructedFromSameData()
        {
            Character constrParam0 = _rnd.NextAfmCharacter();
            Character constrParam1 = _rnd.NextAfmCharacter();
            Vector constrParam2 = _rnd.NextAfmVector();
            KerningPair testObject = new(constrParam0, constrParam1, constrParam2);
            KerningPair testParam = new(testObject.First, testObject.Second, testObject.KerningVector);

            bool testOutput = testObject.Equals((object)testParam);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void KerningPairStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterDiffersByFirstProperty()
        {
            Character constrParam0 = _rnd.NextAfmCharacter();
            Character constrParam1 = _rnd.NextAfmCharacter();
            Vector constrParam2 = _rnd.NextAfmVector();
            KerningPair testObject = new(constrParam0, constrParam1, constrParam2);
            KerningPair testParam = new(_rnd.NextAfmCharacter(), testObject.Second, testObject.KerningVector);

            bool testOutput = testObject.Equals((object)testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void KerningPairStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterDiffersBySecondProperty()
        {
            Character constrParam0 = _rnd.NextAfmCharacter();
            Character constrParam1 = _rnd.NextAfmCharacter();
            Vector constrParam2 = _rnd.NextAfmVector();
            KerningPair testObject = new(constrParam0, constrParam1, constrParam2);
            KerningPair testParam = new(testObject.First, _rnd.NextAfmCharacter(), testObject.KerningVector);

            bool testOutput = testObject.Equals((object)testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void KerningPairStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterDiffersByKerningVectorProperty()
        {
            Character constrParam0 = _rnd.NextAfmCharacter();
            Character constrParam1 = _rnd.NextAfmCharacter();
            Vector constrParam2 = _rnd.NextAfmVector();
            KerningPair testObject = new(constrParam0, constrParam1, constrParam2);
            Vector constrParam3;
            do
            {
                constrParam3 = _rnd.NextAfmVector();
            } while (constrParam3 == testObject.KerningVector);
            KerningPair testParam = new(testObject.First, testObject.Second, constrParam3);

            bool testOutput = testObject.Equals((object)testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void KerningPairStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterIsString()
        {
            Character constrParam0 = _rnd.NextAfmCharacter();
            Character constrParam1 = _rnd.NextAfmCharacter();
            Vector constrParam2 = _rnd.NextAfmVector();
            KerningPair testObject = new(constrParam0, constrParam1, constrParam2);
            string testParam = _rnd.NextString(_rnd.Next(20));

            bool testOutput = testObject.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void KerningPairStruct_GetHashCodeMethod_ReturnsSameValue_IfCalledTwiceWithSameValue()
        {
            Character constrParam0 = _rnd.NextAfmCharacter();
            Character constrParam1 = _rnd.NextAfmCharacter();
            Vector constrParam2 = _rnd.NextAfmVector();
            KerningPair testObject0 = new(constrParam0, constrParam1, constrParam2);
            KerningPair testObject1 = new(constrParam0, constrParam1, constrParam2);

            int testOutput0 = testObject0.GetHashCode();
            int testOutput1 = testObject1.GetHashCode();

            Assert.AreEqual(testOutput0, testOutput1);
        }

        [TestMethod]
        public void KerningPairStruct_EqualityOperator_ReturnsTrue_IfBothOperandsAreSameValue()
        {
            Character constrParam0 = _rnd.NextAfmCharacter();
            Character constrParam1 = _rnd.NextAfmCharacter();
            Vector constrParam2 = _rnd.NextAfmVector();
            KerningPair testOperand0 = new(constrParam0, constrParam1, constrParam2);

#pragma warning disable CS1718 // Comparison made to same variable
            bool testOutput = testOperand0 == testOperand0;
#pragma warning restore CS1718 // Comparison made to same variable

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void KerningPairStruct_EqualityOperator_ReturnsTrue_IfOperandsHaveSameProperties()
        {
            Character constrParam0 = _rnd.NextAfmCharacter();
            Character constrParam1 = _rnd.NextAfmCharacter();
            Vector constrParam2 = _rnd.NextAfmVector();
            KerningPair testOperand0 = new(constrParam0, constrParam1, constrParam2);
            KerningPair testOperand1 = new(constrParam0, constrParam1, constrParam2);

            bool testOutput = testOperand0 == testOperand1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void KerningPairStruct_EqualityOperator_ReturnsTrue_IfOperandsDifferByFirstProperty()
        {
            Character constrParam0 = _rnd.NextAfmCharacter();
            Character constrParam1 = _rnd.NextAfmCharacter();
            Vector constrParam2 = _rnd.NextAfmVector();
            Character constrParam3 = _rnd.NextAfmCharacter();
            KerningPair testOperand0 = new(constrParam0, constrParam1, constrParam2);
            KerningPair testOperand1 = new(constrParam3, constrParam1, constrParam2);

            bool testOutput = testOperand0 == testOperand1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void KerningPairStruct_EqualityOperator_ReturnsTrue_IfOperandsDifferBySecondProperty()
        {
            Character constrParam0 = _rnd.NextAfmCharacter();
            Character constrParam1 = _rnd.NextAfmCharacter();
            Vector constrParam2 = _rnd.NextAfmVector();
            Character constrParam3 = _rnd.NextAfmCharacter();
            KerningPair testOperand0 = new(constrParam0, constrParam1, constrParam2);
            KerningPair testOperand1 = new(constrParam0, constrParam3, constrParam2);

            bool testOutput = testOperand0 == testOperand1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void KerningPairStruct_EqualityOperator_ReturnsTrue_IfOperandsDifferByKerningVectorProperty()
        {
            Character constrParam0 = _rnd.NextAfmCharacter();
            Character constrParam1 = _rnd.NextAfmCharacter();
            Vector constrParam2 = _rnd.NextAfmVector();
            Vector constrParam3;
            do
            {
                constrParam3 = _rnd.NextAfmVector();
            } while (constrParam3 == constrParam2);
            KerningPair testOperand0 = new(constrParam0, constrParam1, constrParam2);
            KerningPair testOperand1 = new(constrParam0, constrParam1, constrParam3);

            bool testOutput = testOperand0 == testOperand1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void KerningPairStruct_InequalityOperator_ReturnsFalse_IfBothOperandsAreSameValue()
        {
            Character constrParam0 = _rnd.NextAfmCharacter();
            Character constrParam1 = _rnd.NextAfmCharacter();
            Vector constrParam2 = _rnd.NextAfmVector();
            KerningPair testOperand0 = new(constrParam0, constrParam1, constrParam2);

#pragma warning disable CS1718 // Comparison made to same variable
            bool testOutput = testOperand0 != testOperand0;
#pragma warning restore CS1718 // Comparison made to same variable

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void KerningPairStruct_InequalityOperator_ReturnsFalse_IfOperandsHaveSameProperties()
        {
            Character constrParam0 = _rnd.NextAfmCharacter();
            Character constrParam1 = _rnd.NextAfmCharacter();
            Vector constrParam2 = _rnd.NextAfmVector();
            KerningPair testOperand0 = new(constrParam0, constrParam1, constrParam2);
            KerningPair testOperand1 = new(constrParam0, constrParam1, constrParam2);

            bool testOutput = testOperand0 != testOperand1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void KerningPairStruct_InequalityOperator_ReturnsFalse_IfOperandsDifferByFirstProperty()
        {
            Character constrParam0 = _rnd.NextAfmCharacter();
            Character constrParam1 = _rnd.NextAfmCharacter();
            Vector constrParam2 = _rnd.NextAfmVector();
            Character constrParam3 = _rnd.NextAfmCharacter();
            KerningPair testOperand0 = new(constrParam0, constrParam1, constrParam2);
            KerningPair testOperand1 = new (constrParam3, constrParam1, constrParam2);

            bool testOutput = testOperand0 != testOperand1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void KerningPairStruct_InequalityOperator_ReturnsFalse_IfOperandsDifferBySecondProperty()
        {
            Character constrParam0 = _rnd.NextAfmCharacter();
            Character constrParam1 = _rnd.NextAfmCharacter();
            Vector constrParam2 = _rnd.NextAfmVector();
            Character constrParam3 = _rnd.NextAfmCharacter();
            KerningPair testOperand0 = new(constrParam0, constrParam1, constrParam2);
            KerningPair testOperand1 = new(constrParam0, constrParam3, constrParam2);

            bool testOutput = testOperand0 != testOperand1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void KerningPairStruct_InequalityOperator_ReturnsFalse_IfOperandsDifferByKerningVectorProperty()
        {
            Character constrParam0 = _rnd.NextAfmCharacter();
            Character constrParam1 = _rnd.NextAfmCharacter();
            Vector constrParam2 = _rnd.NextAfmVector();
            Vector constrParam3;
            do
            {
                constrParam3 = _rnd.NextAfmVector();
            } while (constrParam3 == constrParam2);
            KerningPair testOperand0 = new(constrParam0, constrParam1, constrParam2);
            KerningPair testOperand1 = new(constrParam0, constrParam1, constrParam3);

            bool testOutput = testOperand0 != testOperand1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void KerningPairStruct_FromStringMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            string testParam0 = null;
            IDictionary<string, Character> testParam1 = new Dictionary<string, Character>();
            IDictionary<short, Character> testParam2 = new Dictionary<short, Character>();

            _ = KerningPair.FromString(testParam0, testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void KerningPairStruct_FromStringMethod_ThrowsArgumentNullException_IfSecondParameterIsNull()
        {
            string testParam0 = GenerateRandomValidStringInput();
            IDictionary<string, Character> testParam1 = null;
            IDictionary<short, Character> testParam2 = new Dictionary<short, Character>();

            _ = KerningPair.FromString(testParam0, testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void KerningPairStruct_FromStringMethod_ThrowsArgumentNullException_IfThirdParameterIsNull()
        {
            string testParam0 = GenerateRandomValidStringInput();
            IDictionary<string, Character> testParam1 = new Dictionary<string, Character>();
            IDictionary<short, Character> testParam2 = null;

            _ = KerningPair.FromString(testParam0, testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void KerningPairStruct_FromStringMethod_ThrowsAfmFormatException_IfFirstParameterIsEmptyString()
        {
            string testParam0 = "";
            IDictionary<string, Character> testParam1 = new Dictionary<string, Character>();
            IDictionary<short, Character> testParam2 = new Dictionary<short, Character>();

            _ = KerningPair.FromString(testParam0, testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void KerningPairStruct_FromStringMethod_ThrowsAfmFormatException_IfFirstPartOfStringIsNotRecognised()
        {
            var charNameSet = _rnd.NextStringSet(() => _rnd.Next(1, 10), 2).ToArray();
            string charName0 = charNameSet[0];
            string charName1 = charNameSet[1];
            Character char0 = _rnd.NextAfmCharacter(charName0);
            Character char1 = _rnd.NextAfmCharacter(charName1);
            string testParam0 = GenerateRandomValidStringInput(_rnd.NextString("ABCDEFGHIJLMNOPQRSTUVWXYZ", _rnd.Next(1, 3)), charName0, charName1);
            IDictionary<string, Character> testParam1 = new Dictionary<string, Character> { { charName0, char0 }, { charName1, char1 } };
            IDictionary<short, Character> testParam2 = new Dictionary<short, Character>();

            _ = KerningPair.FromString(testParam0, testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void KerningPairStruct_FromStringMethod_ThrowsAfmFormatException_IfCodeIsKPAndFirstCharacterIsNotListedInSecondParameter()
        {
            var charNameSet = _rnd.NextStringSet(() => _rnd.Next(1, 10), 2).ToArray();
            string charName0 = charNameSet[0];
            string charName1 = charNameSet[1];
            Character char1 = _rnd.NextAfmCharacter(charName1);
            string testParam0 = GenerateRandomValidStringInput("KP", charName0, charName1);
            IDictionary<string, Character> testParam1 = new Dictionary<string, Character> { { charName1, char1 } };
            IDictionary<short, Character> testParam2 = new Dictionary<short, Character>();

            _ = KerningPair.FromString(testParam0, testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void KerningPairStruct_FromtStringMethod_ThrowsAfmFormatException_IfCodeIsKPAndSecondPartOfVectorIsMissing()
        {
            var charNameSet = _rnd.NextStringSet(() => _rnd.Next(1, 10), 2).ToArray();
            string charName0 = charNameSet[0];
            string charName1 = charNameSet[1];
            Character char0 = _rnd.NextAfmCharacter(charName0);
            Character char1 = _rnd.NextAfmCharacter(charName1);
            string testParam0 = GenerateRandomValidStringInput("KP", charName0, charName1, null, "");
            IDictionary<string, Character> testParam1 = new Dictionary<string, Character> { { charName0, char0 }, { charName1, char1 } };
            IDictionary<short, Character> testParam2 = new Dictionary<short, Character>();

            _ = KerningPair.FromString(testParam0, testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void KerningPairStruct_FromStringMethod_ThrowsAfmFormatException_IfCodeIsKPAndSecondCharacterIsNotListedInSecondParameter()
        {
            var charNameSet = _rnd.NextStringSet(() => _rnd.Next(1, 10), 2).ToArray();
            string charName0 = charNameSet[0];
            string charName1 = charNameSet[1];
            Character char0 = _rnd.NextAfmCharacter(charName0);
            string testParam0 = GenerateRandomValidStringInput("KP", charName0, charName1);
            IDictionary<string, Character> testParam1 = new Dictionary<string, Character> { { charName0, char0 } };
            IDictionary<short, Character> testParam2 = new Dictionary<short, Character>();

            _ = KerningPair.FromString(testParam0, testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void KerningPairStruct_FromStringMethod_ThrowsAfmFormatException_IfCodeIsKPAndFirstPartOfVectorIsNotANumber()
        {
            var charNameSet = _rnd.NextStringSet(() => _rnd.Next(1, 10), 2).ToArray();
            string charName0 = charNameSet[0];
            string charName1 = charNameSet[1];
            Character char0 = _rnd.NextAfmCharacter(charName0);
            Character char1 = _rnd.NextAfmCharacter(charName1);
            string testParam0 = GenerateRandomValidStringInput("KP", charName0, charName1, 
                _rnd.NextString(TestUtilities.Extensions.RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10)));
            IDictionary<string, Character> testParam1 = new Dictionary<string, Character> { { charName0, char0 }, { charName1, char1 } };
            IDictionary<short, Character> testParam2 = new Dictionary<short, Character>();

            _ = KerningPair.FromString(testParam0, testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void KerningPairStruct_FromStringMethod_ThrowsAfmFormatException_IfCodeIsKPAndSecondPartOfVectorIsNotANumber()
        {
            var charNameSet = _rnd.NextStringSet(() => _rnd.Next(1, 10), 2).ToArray();
            string charName0 = charNameSet[0];
            string charName1 = charNameSet[1];
            Character char0 = _rnd.NextAfmCharacter(charName0);
            Character char1 = _rnd.NextAfmCharacter(charName1);
            string testParam0 = GenerateRandomValidStringInput("KP", charName0, charName1, null,
                _rnd.NextString(TestUtilities.Extensions.RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10)));
            IDictionary<string, Character> testParam1 = new Dictionary<string, Character> { { charName0, char0 }, { charName1, char1 } };
            IDictionary<short, Character> testParam2 = new Dictionary<short, Character>();

            _ = KerningPair.FromString(testParam0, testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        public void KerningPairStruct_FromStringMethod_ReturnsValueWithCorrectFirstProperty_IfCodeIsKPAndDataIsValid()
        {
            var charNameSet = _rnd.NextStringSet(() => _rnd.Next(1, 10), 2).ToArray();
            string charName0 = charNameSet[0];
            string charName1 = charNameSet[1];
            Character char0 = _rnd.NextAfmCharacter(charName0);
            Character char1 = _rnd.NextAfmCharacter(charName1);
            decimal xVector = _rnd.NextDecimal();
            decimal yVector = _rnd.NextDecimal();
            string testParam0 = GenerateRandomValidStringInput("KP", charName0, charName1, xVector.ToString(CultureInfo.InvariantCulture),
                yVector.ToString(CultureInfo.InvariantCulture));
            IDictionary<string, Character> testParam1 = new Dictionary<string, Character> { { charName0, char0 }, { charName1, char1 } };
            IDictionary<short, Character> testParam2 = new Dictionary<short, Character>();

            KerningPair testOutput = KerningPair.FromString(testParam0, testParam1, testParam2);

            Assert.AreSame(char0, testOutput.First);
        }

        [TestMethod]
        public void KerningPairStruct_FromStringMethod_ReturnsValueWithCorrectSecondProperty_IfCodeIsKPAndDataIsValid()
        {
            var charNameSet = _rnd.NextStringSet(() => _rnd.Next(1, 10), 2).ToArray();
            string charName0 = charNameSet[0];
            string charName1 = charNameSet[1];
            Character char0 = _rnd.NextAfmCharacter(charName0);
            Character char1 = _rnd.NextAfmCharacter(charName1);
            decimal xVector = _rnd.NextDecimal();
            decimal yVector = _rnd.NextDecimal();
            string testParam0 = GenerateRandomValidStringInput("KP", charName0, charName1, xVector.ToString(CultureInfo.InvariantCulture),
                yVector.ToString(CultureInfo.InvariantCulture));
            IDictionary<string, Character> testParam1 = new Dictionary<string, Character> { { charName0, char0 }, { charName1, char1 } };
            IDictionary<short, Character> testParam2 = new Dictionary<short, Character>();

            KerningPair testOutput = KerningPair.FromString(testParam0, testParam1, testParam2);

            Assert.AreSame(char1, testOutput.Second);
        }

        [TestMethod]
        public void KerningPairStruct_FromStringMethod_ReturnsValueWithKerningVectorPropertyWithCorrectXProperty_IfCodeIsKPAndDataIsValid()
        {
            var charNameSet = _rnd.NextStringSet(() => _rnd.Next(1, 10), 2).ToArray();
            string charName0 = charNameSet[0];
            string charName1 = charNameSet[1];
            Character char0 = _rnd.NextAfmCharacter(charName0);
            Character char1 = _rnd.NextAfmCharacter(charName1);
            decimal xVector = _rnd.NextDecimal();
            decimal yVector = _rnd.NextDecimal();
            string testParam0 = GenerateRandomValidStringInput("KP", charName0, charName1, xVector.ToString(CultureInfo.InvariantCulture),
                yVector.ToString(CultureInfo.InvariantCulture));
            IDictionary<string, Character> testParam1 = new Dictionary<string, Character> { { charName0, char0 }, { charName1, char1 } };
            IDictionary<short, Character> testParam2 = new Dictionary<short, Character>();

            KerningPair testOutput = KerningPair.FromString(testParam0, testParam1, testParam2);

            Assert.AreEqual(xVector, testOutput.KerningVector.X);
        }

        [TestMethod]
        public void KerningPairStruct_FromStringMethod_ReturnsValueWithKerningVectorPropertyWithCorrectYProperty_IfCodeIsKPAndDataIsValid()
        {
            var charNameSet = _rnd.NextStringSet(() => _rnd.Next(1, 10), 2).ToArray();
            string charName0 = charNameSet[0];
            string charName1 = charNameSet[1];
            Character char0 = _rnd.NextAfmCharacter(charName0);
            Character char1 = _rnd.NextAfmCharacter(charName1);
            decimal xVector = _rnd.NextDecimal();
            decimal yVector = _rnd.NextDecimal();
            string testParam0 = GenerateRandomValidStringInput("KP", charName0, charName1, xVector.ToString(CultureInfo.InvariantCulture),
                yVector.ToString(CultureInfo.InvariantCulture));
            IDictionary<string, Character> testParam1 = new Dictionary<string, Character> { { charName0, char0 }, { charName1, char1 } };
            IDictionary<short, Character> testParam2 = new Dictionary<short, Character>();

            KerningPair testOutput = KerningPair.FromString(testParam0, testParam1, testParam2);

            Assert.AreEqual(yVector, testOutput.KerningVector.Y);
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void KerningPairStruct_FromStringMethod_ThrowsAfmFormatException_IfCodeIsKPXAndFirstCharacterIsNotListedInSecondParameter()
        {
            var charNameSet = _rnd.NextStringSet(() => _rnd.Next(1, 10), 2).ToArray();
            string charName0 = charNameSet[0];
            string charName1 = charNameSet[1];
            Character char1 = _rnd.NextAfmCharacter(charName1);
            string testParam0 = GenerateRandomValidStringInput("KPX", charName0, charName1);
            IDictionary<string, Character> testParam1 = new Dictionary<string, Character> { { charName1, char1 } };
            IDictionary<short, Character> testParam2 = new Dictionary<short, Character>();

            _ = KerningPair.FromString(testParam0, testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void KerningPairStruct_FromStringMethod_ThrowsAfmFormatException_IfCodeIsKPXAndSecondCharacterIsNotListedInSecondParameter()
        {
            var charNameSet = _rnd.NextStringSet(() => _rnd.Next(1, 10), 2).ToArray();
            string charName0 = charNameSet[0];
            string charName1 = charNameSet[1];
            Character char0 = _rnd.NextAfmCharacter(charName0);
            string testParam0 = GenerateRandomValidStringInput("KPX", charName0, charName1);
            IDictionary<string, Character> testParam1 = new Dictionary<string, Character> { { charName0, char0 } };
            IDictionary<short, Character> testParam2 = new Dictionary<short, Character>();

            _ = KerningPair.FromString(testParam0, testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void KerningPairStruct_FromStringMethod_ThrowsAfmFormatException_IfCodeIsKPXAndVectorIsNotANumber()
        {
            var charNameSet = _rnd.NextStringSet(() => _rnd.Next(1, 10), 2).ToArray();
            string charName0 = charNameSet[0];
            string charName1 = charNameSet[1];
            Character char0 = _rnd.NextAfmCharacter(charName0);
            Character char1 = _rnd.NextAfmCharacter(charName1);
            string testParam0 = GenerateRandomValidStringInput("KPX", charName0, charName1,
                _rnd.NextString(TestUtilities.Extensions.RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10)));
            IDictionary<string, Character> testParam1 = new Dictionary<string, Character> { { charName0, char0 }, { charName1, char1 } };
            IDictionary<short, Character> testParam2 = new Dictionary<short, Character>();

            _ = KerningPair.FromString(testParam0, testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        public void KerningPairStruct_FromStringMethod_ReturnsValueWithCorrectFirstProperty_IfCodeIsKPXAndDataIsValid()
        {
            var charNameSet = _rnd.NextStringSet(() => _rnd.Next(1, 10), 2).ToArray();
            string charName0 = charNameSet[0];
            string charName1 = charNameSet[1];
            Character char0 = _rnd.NextAfmCharacter(charName0);
            Character char1 = _rnd.NextAfmCharacter(charName1);
            decimal xVector = _rnd.NextDecimal();
            string testParam0 = GenerateRandomValidStringInput("KPX", charName0, charName1, xVector.ToString(CultureInfo.InvariantCulture));
            IDictionary<string, Character> testParam1 = new Dictionary<string, Character> { { charName0, char0 }, { charName1, char1 } };
            IDictionary<short, Character> testParam2 = new Dictionary<short, Character>();

            KerningPair testOutput = KerningPair.FromString(testParam0, testParam1, testParam2);

            Assert.AreSame(char0, testOutput.First);
        }

        [TestMethod]
        public void KerningPairStruct_FromStringMethod_ReturnsValueWithCorrectSecondProperty_IfCodeIsKPXAndDataIsValid()
        {
            var charNameSet = _rnd.NextStringSet(() => _rnd.Next(1, 10), 2).ToArray();
            string charName0 = charNameSet[0];
            string charName1 = charNameSet[1];
            Character char0 = _rnd.NextAfmCharacter(charName0);
            Character char1 = _rnd.NextAfmCharacter(charName1);
            decimal xVector = _rnd.NextDecimal();
            string testParam0 = GenerateRandomValidStringInput("KPX", charName0, charName1, xVector.ToString(CultureInfo.InvariantCulture));
            IDictionary<string, Character> testParam1 = new Dictionary<string, Character> { { charName0, char0 }, { charName1, char1 } };
            IDictionary<short, Character> testParam2 = new Dictionary<short, Character>();

            KerningPair testOutput = KerningPair.FromString(testParam0, testParam1, testParam2);

            Assert.AreSame(char1, testOutput.Second);
        }

        [TestMethod]
        public void KerningPairStruct_FromStringMethod_ReturnsValueWithKerningVectorPropertyWithCorrectXProperty_IfCodeIsKPXAndDataIsValid()
        {
            var charNameSet = _rnd.NextStringSet(() => _rnd.Next(1, 10), 2).ToArray();
            string charName0 = charNameSet[0];
            string charName1 = charNameSet[1];
            Character char0 = _rnd.NextAfmCharacter(charName0);
            Character char1 = _rnd.NextAfmCharacter(charName1);
            decimal xVector = _rnd.NextDecimal();
            string testParam0 = GenerateRandomValidStringInput("KPX", charName0, charName1, xVector.ToString(CultureInfo.InvariantCulture));
            IDictionary<string, Character> testParam1 = new Dictionary<string, Character> { { charName0, char0 }, { charName1, char1 } };
            IDictionary<short, Character> testParam2 = new Dictionary<short, Character>();

            KerningPair testOutput = KerningPair.FromString(testParam0, testParam1, testParam2);

            Assert.AreEqual(xVector, testOutput.KerningVector.X);
        }

        [TestMethod]
        public void KerningPairStruct_FromStringMethod_ReturnsValueWithKerningVectorPropertyWithYPropertyEqualToZero_IfCodeIsKPXAndDataIsValid()
        {
            var charNameSet = _rnd.NextStringSet(() => _rnd.Next(1, 10), 2).ToArray();
            string charName0 = charNameSet[0];
            string charName1 = charNameSet[1];
            Character char0 = _rnd.NextAfmCharacter(charName0);
            Character char1 = _rnd.NextAfmCharacter(charName1);
            decimal xVector = _rnd.NextDecimal();
            string testParam0 = GenerateRandomValidStringInput("KPX", charName0, charName1, xVector.ToString(CultureInfo.InvariantCulture));
            IDictionary<string, Character> testParam1 = new Dictionary<string, Character> { { charName0, char0 }, { charName1, char1 } };
            IDictionary<short, Character> testParam2 = new Dictionary<short, Character>();

            KerningPair testOutput = KerningPair.FromString(testParam0, testParam1, testParam2);

            Assert.AreEqual(0m, testOutput.KerningVector.Y);
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void KerningPairStruct_FromStringMethod_ThrowsAfmFormatException_IfCodeIsKPYAndFirstCharacterIsNotListedInSecondParameter()
        {
            var charNameSet = _rnd.NextStringSet(() => _rnd.Next(1, 10), 2).ToArray();
            string charName0 = charNameSet[0];
            string charName1 = charNameSet[1];
            Character char1 = _rnd.NextAfmCharacter(charName1);
            string testParam0 = GenerateRandomValidStringInput("KPY", charName0, charName1);
            IDictionary<string, Character> testParam1 = new Dictionary<string, Character> { { charName1, char1 } };
            IDictionary<short, Character> testParam2 = new Dictionary<short, Character>();

            _ = KerningPair.FromString(testParam0, testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void KerningPairStruct_FromStringMethod_ThrowsAfmFormatException_IfCodeIsKPYAndSecondCharacterIsNotListedInSecondParameter()
        {
            var charNameSet = _rnd.NextStringSet(() => _rnd.Next(1, 10), 2).ToArray();
            string charName0 = charNameSet[0];
            string charName1 = charNameSet[1];
            Character char0 = _rnd.NextAfmCharacter(charName0);
            string testParam0 = GenerateRandomValidStringInput("KPY", charName0, charName1);
            IDictionary<string, Character> testParam1 = new Dictionary<string, Character> { { charName0, char0 } };
            IDictionary<short, Character> testParam2 = new Dictionary<short, Character>();

            _ = KerningPair.FromString(testParam0, testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void KerningPairStruct_FromStringMethod_ThrowsAfmFormatException_IfCodeIsKPYAndFirstPartOfVectorIsNotANumber()
        {
            var charNameSet = _rnd.NextStringSet(() => _rnd.Next(1, 10), 2).ToArray();
            string charName0 = charNameSet[0];
            string charName1 = charNameSet[1];
            Character char0 = _rnd.NextAfmCharacter(charName0);
            Character char1 = _rnd.NextAfmCharacter(charName1);
            string testParam0 = GenerateRandomValidStringInput("KPY", charName0, charName1,
                _rnd.NextString(TestUtilities.Extensions.RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10)));
            IDictionary<string, Character> testParam1 = new Dictionary<string, Character> { { charName0, char0 }, { charName1, char1 } };
            IDictionary<short, Character> testParam2 = new Dictionary<short, Character>();

            _ = KerningPair.FromString(testParam0, testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        public void KerningPairStruct_FromStringMethod_ReturnsValueWithCorrectFirstProperty_IfCodeIsKPYAndDataIsValid()
        {
            var charNameSet = _rnd.NextStringSet(() => _rnd.Next(1, 10), 2).ToArray();
            string charName0 = charNameSet[0];
            string charName1 = charNameSet[1];
            Character char0 = _rnd.NextAfmCharacter(charName0);
            Character char1 = _rnd.NextAfmCharacter(charName1);
            decimal yVector = _rnd.NextDecimal();
            string testParam0 = GenerateRandomValidStringInput("KPY", charName0, charName1, yVector.ToString(CultureInfo.InvariantCulture));
            IDictionary<string, Character> testParam1 = new Dictionary<string, Character> { { charName0, char0 }, { charName1, char1 } };
            IDictionary<short, Character> testParam2 = new Dictionary<short, Character>();

            KerningPair testOutput = KerningPair.FromString(testParam0, testParam1, testParam2);

            Assert.AreSame(char0, testOutput.First);
        }

        [TestMethod]
        public void KerningPairStruct_FromStringMethod_ReturnsValueWithCorrectSecondProperty_IfCodeIsKPYAndDataIsValid()
        {
            var charNameSet = _rnd.NextStringSet(() => _rnd.Next(1, 10), 2).ToArray();
            string charName0 = charNameSet[0];
            string charName1 = charNameSet[1];
            Character char0 = _rnd.NextAfmCharacter(charName0);
            Character char1 = _rnd.NextAfmCharacter(charName1);
            decimal yVector = _rnd.NextDecimal();
            string testParam0 = GenerateRandomValidStringInput("KPY", charName0, charName1, yVector.ToString(CultureInfo.InvariantCulture));
            IDictionary<string, Character> testParam1 = new Dictionary<string, Character> { { charName0, char0 }, { charName1, char1 } };
            IDictionary<short, Character> testParam2 = new Dictionary<short, Character>();

            KerningPair testOutput = KerningPair.FromString(testParam0, testParam1, testParam2);

            Assert.AreSame(char1, testOutput.Second);
        }

        [TestMethod]
        public void KerningPairStruct_FromStringMethod_ReturnsValueWithKerningVectorPropertyWithXPropertyEqualToZero_IfCodeIsKPYAndDataIsValid()
        {
            var charNameSet = _rnd.NextStringSet(() => _rnd.Next(1, 10), 2).ToArray();
            string charName0 = charNameSet[0];
            string charName1 = charNameSet[1];
            Character char0 = _rnd.NextAfmCharacter(charName0);
            Character char1 = _rnd.NextAfmCharacter(charName1);
            decimal yVector = _rnd.NextDecimal();
            string testParam0 = GenerateRandomValidStringInput("KPY", charName0, charName1, yVector.ToString(CultureInfo.InvariantCulture));
            IDictionary<string, Character> testParam1 = new Dictionary<string, Character> { { charName0, char0 }, { charName1, char1 } };
            IDictionary<short, Character> testParam2 = new Dictionary<short, Character>();

            KerningPair testOutput = KerningPair.FromString(testParam0, testParam1, testParam2);

            Assert.AreEqual(0m, testOutput.KerningVector.X);
        }

        [TestMethod]
        public void KerningPairStruct_FromStringMethod_ReturnsValueWithKerningVectorPropertyWithCorrectYProperty_IfCodeIsKPYAndDataIsValid()
        {
            var charNameSet = _rnd.NextStringSet(() => _rnd.Next(1, 10), 2).ToArray();
            string charName0 = charNameSet[0];
            string charName1 = charNameSet[1];
            Character char0 = _rnd.NextAfmCharacter(charName0);
            Character char1 = _rnd.NextAfmCharacter(charName1);
            decimal yVector = _rnd.NextDecimal();
            string testParam0 = GenerateRandomValidStringInput("KPY", charName0, charName1, yVector.ToString(CultureInfo.InvariantCulture));
            IDictionary<string, Character> testParam1 = new Dictionary<string, Character> { { charName0, char0 }, { charName1, char1 } };
            IDictionary<short, Character> testParam2 = new Dictionary<short, Character>();

            KerningPair testOutput = KerningPair.FromString(testParam0, testParam1, testParam2);

            Assert.AreEqual(yVector, testOutput.KerningVector.Y);
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void KerningPairStruct_FromStringMethod_ThrowsAfmFormatException_IfCodeIsKPHAndFirstCharacterIsNotListedInThirdParameter()
        {
            short charCode0 = _rnd.NextShort();
            short charCode1;
            do
            {
                charCode1 = _rnd.NextShort();
            } while (charCode1 == charCode0);
            Character char1 = _rnd.NextAfmCharacter(charCode1);
            string testParam0 = GenerateRandomValidStringInput("KPH", HexCode(charCode0), HexCode(charCode1));
            IDictionary<string, Character> testParam1 = new Dictionary<string, Character>();
            IDictionary<short, Character> testParam2 = new Dictionary<short, Character> { { charCode1, char1 } };

            _ = KerningPair.FromString(testParam0, testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void KerningPairStruct_FromStringMethod_ThrowsAfmFormatException_IfCodeIsKPHAndSecondCharacterIsNotListedInThirdParameter()
        {
            short charCode0 = _rnd.NextShort();
            short charCode1;
            do
            {
                charCode1 = _rnd.NextShort();
            } while (charCode1 == charCode0);
            Character char0 = _rnd.NextAfmCharacter(charCode0);
            string testParam0 = GenerateRandomValidStringInput("KPH", HexCode(charCode0), HexCode(charCode1));
            IDictionary<string, Character> testParam1 = new Dictionary<string, Character>();
            IDictionary<short, Character> testParam2 = new Dictionary<short, Character> { { charCode0, char0 } };

            _ = KerningPair.FromString(testParam0, testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void KerningPairStruct_FromStringMethod_ThrowsAfmFormatException_IfCodeIsKPHAndFirstCharacterIsNotValidHexCode()
        {
            short charCode0 = _rnd.NextShort(); 
            short charCode1;
            do
            {
                charCode1 = _rnd.NextShort();
            } while (charCode1 == charCode0);
            string charName = _rnd.NextString(TestUtilities.Extensions.RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));
            Character char0 = _rnd.NextAfmCharacter(charName, charCode0);
            Character char1 = _rnd.NextAfmCharacter(charCode1);
            string testParam0 = GenerateRandomValidStringInput("KPH", charName, HexCode(charCode1));
            IDictionary<string, Character> testParam1 = new Dictionary<string, Character>();
            IDictionary<short, Character> testParam2 = new Dictionary<short, Character> { { charCode0, char0 }, { charCode1, char1 } };

            _ = KerningPair.FromString(testParam0, testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void KerningPairStruct_FromStringMethod_ThrowsAfmFormatException_IfCodeIsKPHAndFirstCharacterIsNotValidHexCodeButHasAngleBrackets()
        {
            short charCode0 = _rnd.NextShort();
            short charCode1;
            do
            {
                charCode1 = _rnd.NextShort();
            } while (charCode1 == charCode0);
            string charName = "<" + _rnd.NextString(TestUtilities.Extensions.RandomExtensions.NonHexAlphabeticalCharacters, _rnd.Next(1, 10)) + ">";
            Character char0 = _rnd.NextAfmCharacter(charName, charCode0);
            Character char1 = _rnd.NextAfmCharacter(charCode1);
            string testParam0 = GenerateRandomValidStringInput("KPH", charName, HexCode(charCode1));
            IDictionary<string, Character> testParam1 = new Dictionary<string, Character>();
            IDictionary<short, Character> testParam2 = new Dictionary<short, Character> { { charCode0, char0 }, { charCode1, char1 } };

            _ = KerningPair.FromString(testParam0, testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void KerningPairStruct_FromStringMethod_ThrowsAfmFormatException_IfCodeIsKPHAndSecondCharacterIsNotValidHexCode()
        {
            short charCode0 = _rnd.NextShort();
            short charCode1;
            do
            {
                charCode1 = _rnd.NextShort();
            } while (charCode1 == charCode0);
            string charName = _rnd.NextString(TestUtilities.Extensions.RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));
            Character char0 = _rnd.NextAfmCharacter(charCode0);
            Character char1 = _rnd.NextAfmCharacter(charName, charCode1);
            string testParam0 = GenerateRandomValidStringInput("KPH", HexCode(charCode0), charName);
            IDictionary<string, Character> testParam1 = new Dictionary<string, Character>();
            IDictionary<short, Character> testParam2 = new Dictionary<short, Character> { { charCode0, char0 }, { charCode1, char1 } };

            _ = KerningPair.FromString(testParam0, testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void KerningPairStruct_FromStringMethod_ThrowsAfmFormatException_IfCodeIsKPHAndSecondCharacterIsNotValidHexCodeButHasAngleBrackets()
        {
            short charCode0 = _rnd.NextShort();
            short charCode1;
            do
            {
                charCode1 = _rnd.NextShort();
            } while (charCode1 == charCode0);
            string charName = "<" + _rnd.NextString(TestUtilities.Extensions.RandomExtensions.NonHexAlphabeticalCharacters, _rnd.Next(1, 10)) + ">";
            Character char0 = _rnd.NextAfmCharacter(charCode0);
            Character char1 = _rnd.NextAfmCharacter(charName, charCode1);
            string testParam0 = GenerateRandomValidStringInput("KPH", HexCode(charCode0), charName);
            IDictionary<string, Character> testParam1 = new Dictionary<string, Character>();
            IDictionary<short, Character> testParam2 = new Dictionary<short, Character> { { charCode0, char0 }, { charCode1, char1 } };

            _ = KerningPair.FromString(testParam0, testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void KerningPairStruct_FromStringMethod_ThrowsAfmFormatException_IfCodeIsKPHAndFirstPartOfVectorIsNotANumber()
        {
            short charCode0 = _rnd.NextShort();
            short charCode1;
            do
            {
                charCode1 = _rnd.NextShort();
            } while (charCode1 == charCode0);
            Character char0 = _rnd.NextAfmCharacter(charCode0);
            Character char1 = _rnd.NextAfmCharacter(charCode1);
            string testParam0 = GenerateRandomValidStringInput("KPH", HexCode(charCode0), HexCode(charCode1),
                _rnd.NextString(TestUtilities.Extensions.RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10)));
            IDictionary<string, Character> testParam1 = new Dictionary<string, Character>();
            IDictionary<short, Character> testParam2 = new Dictionary<short, Character> { { charCode0, char0 }, { charCode1, char1 } };

            _ = KerningPair.FromString(testParam0, testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void KerningPairStruct_FromStringMethod_ThrowsAfmFormatException_IfCodeIsKPHAndSecondPartOfVectorIsNotANumber()
        {
            short charCode0 = _rnd.NextShort();
            short charCode1;
            do
            {
                charCode1 = _rnd.NextShort();
            } while (charCode1 == charCode0);
            Character char0 = _rnd.NextAfmCharacter(charCode0);
            Character char1 = _rnd.NextAfmCharacter(charCode1);
            string testParam0 = GenerateRandomValidStringInput("KPH", HexCode(charCode0), HexCode(charCode1), null,
                _rnd.NextString(TestUtilities.Extensions.RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10)));
            IDictionary<string, Character> testParam1 = new Dictionary<string, Character>();
            IDictionary<short, Character> testParam2 = new Dictionary<short, Character> { { charCode0, char0 }, { charCode1, char1 } };

            _ = KerningPair.FromString(testParam0, testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void KerningPairStruct_FromStringMethod_ThrowsAfmFormatException_IfCodeIsKPHAndSecondPartOfVectorIsMissing()
        {
            short charCode0 = _rnd.NextShort();
            short charCode1;
            do
            {
                charCode1 = _rnd.NextShort();
            } while (charCode1 == charCode0);
            Character char0 = _rnd.NextAfmCharacter(charCode0);
            Character char1 = _rnd.NextAfmCharacter(charCode1);
            string testParam0 = GenerateRandomValidStringInput("KPH", HexCode(charCode0), HexCode(charCode1), null, "");
            IDictionary<string, Character> testParam1 = new Dictionary<string, Character>();
            IDictionary<short, Character> testParam2 = new Dictionary<short, Character> { { charCode0, char0 }, { charCode1, char1 } };

            _ = KerningPair.FromString(testParam0, testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        public void KerningPairStruct_FromStringMethod_ReturnsValueWithCorrectFirstProperty_IfCodeIsKPHAndDataIsValid()
        {
            short charCode0 = _rnd.NextShort();
            short charCode1;
            do
            {
                charCode1 = _rnd.NextShort();
            } while (charCode1 == charCode0);
            Character char0 = _rnd.NextAfmCharacter(charCode0);
            Character char1 = _rnd.NextAfmCharacter(charCode1);
            decimal xVector = _rnd.NextDecimal();
            decimal yVector = _rnd.NextDecimal();
            string testParam0 = GenerateRandomValidStringInput("KPH", HexCode(charCode0), HexCode(charCode1), xVector.ToString(CultureInfo.InvariantCulture),
                yVector.ToString(CultureInfo.InvariantCulture));
            IDictionary<string, Character> testParam1 = new Dictionary<string, Character>();
            IDictionary<short, Character> testParam2 = new Dictionary<short, Character> { { charCode0, char0 }, { charCode1, char1 } };

            KerningPair testOutput = KerningPair.FromString(testParam0, testParam1, testParam2);

            Assert.AreSame(char0, testOutput.First);
        }

        [TestMethod]
        public void KerningPairStruct_FromStringMethod_ReturnsValueWithCorrectSecondProperty_IfCodeIsKPHAndDataIsValid()
        {
            short charCode0 = _rnd.NextShort();
            short charCode1;
            do
            {
                charCode1 = _rnd.NextShort();
            } while (charCode1 == charCode0);
            Character char0 = _rnd.NextAfmCharacter(charCode0);
            Character char1 = _rnd.NextAfmCharacter(charCode1);
            decimal xVector = _rnd.NextDecimal();
            decimal yVector = _rnd.NextDecimal();
            string testParam0 = GenerateRandomValidStringInput("KPH", HexCode(charCode0), HexCode(charCode1), xVector.ToString(CultureInfo.InvariantCulture),
                yVector.ToString(CultureInfo.InvariantCulture));
            IDictionary<string, Character> testParam1 = new Dictionary<string, Character>();
            IDictionary<short, Character> testParam2 = new Dictionary<short, Character> { { charCode0, char0 }, { charCode1, char1 } };

            KerningPair testOutput = KerningPair.FromString(testParam0, testParam1, testParam2);

            Assert.AreSame(char1, testOutput.Second);
        }

        [TestMethod]
        public void KerningPairStruct_FromStringMethod_ReturnsValueWithKerningVectorPropertyWithCorrectXProperty_IfCodeIsKPHAndDataIsValid()
        {
            short charCode0 = _rnd.NextShort();
            short charCode1;
            do
            {
                charCode1 = _rnd.NextShort();
            } while (charCode1 == charCode0);
            Character char0 = _rnd.NextAfmCharacter(charCode0);
            Character char1 = _rnd.NextAfmCharacter(charCode1);
            decimal xVector = _rnd.NextDecimal();
            decimal yVector = _rnd.NextDecimal();
            string testParam0 = GenerateRandomValidStringInput("KPH", HexCode(charCode0), HexCode(charCode1), xVector.ToString(CultureInfo.InvariantCulture),
                yVector.ToString(CultureInfo.InvariantCulture));
            IDictionary<string, Character> testParam1 = new Dictionary<string, Character>();
            IDictionary<short, Character> testParam2 = new Dictionary<short, Character> { { charCode0, char0 }, { charCode1, char1 } };

            KerningPair testOutput = KerningPair.FromString(testParam0, testParam1, testParam2);

            Assert.AreEqual(xVector, testOutput.KerningVector.X);
        }

        [TestMethod]
        public void KerningPairStruct_FromStringMethod_ReturnsValueWithKerningVectorPropertyWithCorrectYProperty_IfCodeIsKPHAndDataIsValid()
        {
            short charCode0 = _rnd.NextShort();
            short charCode1;
            do
            {
                charCode1 = _rnd.NextShort();
            } while (charCode1 == charCode0);
            Character char0 = _rnd.NextAfmCharacter(charCode0);
            Character char1 = _rnd.NextAfmCharacter(charCode1);
            decimal xVector = _rnd.NextDecimal();
            decimal yVector = _rnd.NextDecimal();
            string testParam0 = GenerateRandomValidStringInput("KPH", HexCode(charCode0), HexCode(charCode1), xVector.ToString(CultureInfo.InvariantCulture),
                yVector.ToString(CultureInfo.InvariantCulture));
            IDictionary<string, Character> testParam1 = new Dictionary<string, Character>();
            IDictionary<short, Character> testParam2 = new Dictionary<short, Character> { { charCode0, char0 }, { charCode1, char1 } };

            KerningPair testOutput = KerningPair.FromString(testParam0, testParam1, testParam2);

            Assert.AreEqual(yVector, testOutput.KerningVector.Y);
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
