using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.FontTools.Afm;
using Unicorn.FontTools.Tests.Utility;

namespace Unicorn.FontTools.Tests.Unit.Afm
{
    [TestClass]
    public class CharacterUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness

        private static IList<InitialLigatureSet> GetInitialLigatureSets(int? count = null)
        {
            if (count is null)
            {
                count = _rnd.Next(5);
            }
            InitialLigatureSet[] output = new InitialLigatureSet[count.Value];
            for (int i = 0; i < count; ++i)
            {
                output[i] = new InitialLigatureSet(_rnd.NextString(_rnd.Next(1, 20)), _rnd.NextString(_rnd.Next(1, 20)));
            }
            return output;
        }

        private static IList<InitialLigatureSet> GetInitialLigatureSets(IEnumerable<string> validNames)
        {
            string[] names = validNames.ToArray();
            List<string> usedSecondNames = new();
            if (names.Length == 0)
            {
                return Array.Empty<InitialLigatureSet>();
            }
            int count = _rnd.Next(1, names.Length);
            InitialLigatureSet[] output = new InitialLigatureSet[count];
            for (int i = 0; i < count; ++i)
            {
                string second;
                do
                {
                    second = names[_rnd.Next(names.Length)];
                } while (usedSecondNames.Contains(second));
                output[i] = new InitialLigatureSet(second, names[_rnd.Next(names.Length)]);
            }
            return output;
        }

        private static IDictionary<string, Character> GetOtherCharacters()
        {
            int count = _rnd.Next(20, 30);
            Dictionary<string, Character> output = new();
            for (int i = 0; i < count; ++i)
            {
                string charName;
                do
                {
                    charName = _rnd.NextString(_rnd.Next(1, 20));
                } while (output.ContainsKey(charName));
                output.Add(charName, _rnd.NextAfmCharacter(charName));
            }
            return output;
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void CharacterClass_Constructor_SetsCodePropertyToValueOfFirstParameter()
        {
            short? testParam0 = _rnd.NextNullableShort();
            string testParam1 = _rnd.NextString(_rnd.Next(1, 20));
            WidthSet testParam2 = _rnd.NextAfmWidthSet();
            WidthSet testParam3 = _rnd.NextAfmWidthSet();
            Vector? testParam4 = _rnd.NextNullableAfmVector();
            BoundingBox? testParam5 = _rnd.NextNullableAfmBoundingBox();
            IEnumerable<InitialLigatureSet> testParam6 = GetInitialLigatureSets();

            Character testOutput = new(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6);

            Assert.AreEqual(testParam0, testOutput.Code);
        }

        [TestMethod]
        public void CharacterClass_Constructor_SetsNamePropertyToValueOfSecondParameter_IfSecondParameterIsNull()
        {
            short? testParam0 = _rnd.NextNullableShort();
            string testParam1 = null;
            WidthSet testParam2 = _rnd.NextAfmWidthSet();
            WidthSet testParam3 = _rnd.NextAfmWidthSet();
            Vector? testParam4 = _rnd.NextNullableAfmVector();
            BoundingBox? testParam5 = _rnd.NextNullableAfmBoundingBox();
            IEnumerable<InitialLigatureSet> testParam6 = GetInitialLigatureSets();

            Character testOutput = new(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6);

            Assert.AreEqual(testParam1, testOutput.Name);
        }
        [TestMethod]
        public void CharacterClass_Constructor_SetsNamePropertyToValueOfSecondParameter_IfSecondParameterIsNotNull()
        {
            short? testParam0 = _rnd.NextNullableShort();
            string testParam1 = _rnd.NextString(_rnd.Next(1, 20));
            WidthSet testParam2 = _rnd.NextAfmWidthSet();
            WidthSet testParam3 = _rnd.NextAfmWidthSet();
            Vector? testParam4 = _rnd.NextNullableAfmVector();
            BoundingBox? testParam5 = _rnd.NextNullableAfmBoundingBox();
            IEnumerable<InitialLigatureSet> testParam6 = GetInitialLigatureSets();

            Character testOutput = new(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6);

            Assert.AreEqual(testParam1, testOutput.Name);
        }

        [TestMethod]
        public void CharacterClass_Constructor_SetsXWidthPropertyToValueOfThirdParameter()
        {
            short? testParam0 = _rnd.NextNullableShort();
            string testParam1 = _rnd.NextString(_rnd.Next(1, 20));
            WidthSet testParam2 = _rnd.NextAfmWidthSet();
            WidthSet testParam3 = _rnd.NextAfmWidthSet();
            Vector? testParam4 = _rnd.NextNullableAfmVector();
            BoundingBox? testParam5 = _rnd.NextNullableAfmBoundingBox();
            IEnumerable<InitialLigatureSet> testParam6 = GetInitialLigatureSets();

            Character testOutput = new(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6);

            Assert.AreEqual(testParam2, testOutput.XWidth);
        }

        [TestMethod]
        public void CharacterClass_Constructor_SetsYWidthPropertyToValueOfFourthParameter()
        {
            short? testParam0 = _rnd.NextNullableShort();
            string testParam1 = _rnd.NextString(_rnd.Next(1, 20));
            WidthSet testParam2 = _rnd.NextAfmWidthSet();
            WidthSet testParam3 = _rnd.NextAfmWidthSet();
            Vector? testParam4 = _rnd.NextNullableAfmVector();
            BoundingBox? testParam5 = _rnd.NextNullableAfmBoundingBox();
            IEnumerable<InitialLigatureSet> testParam6 = GetInitialLigatureSets();

            Character testOutput = new(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6);

            Assert.AreEqual(testParam3, testOutput.YWidth);
        }

        [TestMethod]
        public void CharacterClass_Constructor_SetsVVectorPropertyToValueOfFifthParameter()
        {
            short? testParam0 = _rnd.NextNullableShort();
            string testParam1 = _rnd.NextString(_rnd.Next(1, 20));
            WidthSet testParam2 = _rnd.NextAfmWidthSet();
            WidthSet testParam3 = _rnd.NextAfmWidthSet();
            Vector? testParam4 = _rnd.NextNullableAfmVector();
            BoundingBox? testParam5 = _rnd.NextNullableAfmBoundingBox();
            IEnumerable<InitialLigatureSet> testParam6 = GetInitialLigatureSets();

            Character testOutput = new(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6);

            Assert.AreEqual(testParam4, testOutput.VVector);
        }

        [TestMethod]
        public void CharacterClass_Constructor_SetsBoundingBoxPropertyToValueOfSixthParameter()
        {
            short? testParam0 = _rnd.NextNullableShort();
            string testParam1 = _rnd.NextString(_rnd.Next(1, 20));
            WidthSet testParam2 = _rnd.NextAfmWidthSet();
            WidthSet testParam3 = _rnd.NextAfmWidthSet();
            Vector? testParam4 = _rnd.NextNullableAfmVector();
            BoundingBox? testParam5 = _rnd.NextNullableAfmBoundingBox();
            IEnumerable<InitialLigatureSet> testParam6 = GetInitialLigatureSets();

            Character testOutput = new(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6);

            Assert.AreEqual(testParam5, testOutput.BoundingBox);
        }

        [TestMethod]
        public void CharacterClass_Constructor_SetsLigaturesPropertyToNull()
        {
            short? testParam0 = _rnd.NextNullableShort();
            string testParam1 = _rnd.NextString(_rnd.Next(1, 20));
            WidthSet testParam2 = _rnd.NextAfmWidthSet();
            WidthSet testParam3 = _rnd.NextAfmWidthSet();
            Vector? testParam4 = _rnd.NextNullableAfmVector();
            BoundingBox? testParam5 = _rnd.NextNullableAfmBoundingBox();
            IEnumerable<InitialLigatureSet> testParam6 = GetInitialLigatureSets();

            Character testOutput = new(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6);

            Assert.IsNull(testOutput.Ligatures);
        }

        [TestMethod]
        public void CharacterClass_Constructor_SetsKerningPairsPropertyToEmptyCollection()
        {
            short? testParam0 = _rnd.NextNullableShort();
            string testParam1 = _rnd.NextString(_rnd.Next(1, 20));
            WidthSet testParam2 = _rnd.NextAfmWidthSet();
            WidthSet testParam3 = _rnd.NextAfmWidthSet();
            Vector? testParam4 = _rnd.NextNullableAfmVector();
            BoundingBox? testParam5 = _rnd.NextNullableAfmBoundingBox();
            IEnumerable<InitialLigatureSet> testParam6 = GetInitialLigatureSets();

            Character testOutput = new(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6);

            Assert.IsNotNull(testOutput.KerningPairs);
            Assert.AreEqual(0, testOutput.KerningPairs.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CharacterClass_ProcessLigaturesMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            Character testObject = _rnd.NextAfmCharacter();

            testObject.ProcessLigatures(null);

            Assert.Fail();
        }

        [TestMethod]
        public void CharacterClass_ProcessLigaturesMethod_SetsLigaturesPropertyToEmptyCollection_IfSeventhParameterPassedToConstructorContainedNoElements()
        {
            short? testParam0 = _rnd.NextNullableShort();
            string testParam1 = _rnd.NextString(_rnd.Next(1, 20));
            WidthSet testParam2 = _rnd.NextAfmWidthSet();
            WidthSet testParam3 = _rnd.NextAfmWidthSet();
            Vector? testParam4 = _rnd.NextNullableAfmVector();
            BoundingBox? testParam5 = _rnd.NextNullableAfmBoundingBox();
            IEnumerable<InitialLigatureSet> testParam6 = Array.Empty<InitialLigatureSet>();
            Character testObject = new(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6);
            Dictionary<string, Character> testParam = new() { { testObject.Name, testObject } };

            testObject.ProcessLigatures(testParam);

            Assert.IsNotNull(testObject.Ligatures);
            Assert.AreEqual(0, testObject.Ligatures.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void CharacterClass_ProcessLigaturesMethod_ThrowsAfmFormatException_IfSeventhParameterPassedToConstructorContainsCharacterNamesThatAreNotKeysInMethodParameter()
        {
            short? constrParam0 = _rnd.NextNullableShort();
            string constrParam1 = _rnd.NextString(_rnd.Next(1, 20));
            WidthSet constrParam2 = _rnd.NextAfmWidthSet();
            WidthSet constrParam3 = _rnd.NextAfmWidthSet();
            Vector? constrParam4 = _rnd.NextNullableAfmVector();
            BoundingBox? constrParam5 = _rnd.NextNullableAfmBoundingBox();
            IEnumerable<InitialLigatureSet> constrParam6 = GetInitialLigatureSets(_rnd.Next(1, 5));
            Character testObject = new(constrParam0, constrParam1, constrParam2, constrParam3, constrParam4, constrParam5, constrParam6);
            Dictionary<string, Character> testParam = new();

            testObject.ProcessLigatures(testParam);
        }

        [TestMethod]
        public void CharacterClass_ProcessLigaturesMethod_SetsLigaturesToCollectionOfCorrectSize_IfAllDataIsAsExpected()
        {
            IDictionary<string, Character> otherCharacters = GetOtherCharacters();
            short? constrParam0 = _rnd.NextNullableShort();
            string constrParam1;
            do
            {
                constrParam1 = _rnd.NextString(_rnd.Next(1, 20));
            } while (otherCharacters.ContainsKey(constrParam1));
            WidthSet constrParam2 = _rnd.NextAfmWidthSet();
            WidthSet constrParam3 = _rnd.NextAfmWidthSet();
            Vector? constrParam4 = _rnd.NextNullableAfmVector();
            BoundingBox? constrParam5 = _rnd.NextNullableAfmBoundingBox();
            IList<InitialLigatureSet> constrParam6 = GetInitialLigatureSets(otherCharacters.Keys);
            Character testObject = new(constrParam0, constrParam1, constrParam2, constrParam3, constrParam4, constrParam5, constrParam6);
            otherCharacters.Add(constrParam1, testObject);

            testObject.ProcessLigatures(otherCharacters);

            Assert.AreEqual(constrParam6.Count, testObject.Ligatures.Count);
        }

        [TestMethod]
        public void CharacterClass_ProcessLigaturesMethod_SetsLigaturesToCollectionOfObjectsWhoseFirstPropertyIsThis()
        {
            IDictionary<string, Character> otherCharacters = GetOtherCharacters();
            short? constrParam0 = _rnd.NextNullableShort();
            string constrParam1;
            do
            {
                constrParam1 = _rnd.NextString(_rnd.Next(1, 20));
            } while (otherCharacters.ContainsKey(constrParam1));
            WidthSet constrParam2 = _rnd.NextAfmWidthSet();
            WidthSet constrParam3 = _rnd.NextAfmWidthSet();
            Vector? constrParam4 = _rnd.NextNullableAfmVector();
            BoundingBox? constrParam5 = _rnd.NextNullableAfmBoundingBox();
            IList<InitialLigatureSet> constrParam6 = GetInitialLigatureSets(otherCharacters.Keys);
            Character testObject = new(constrParam0, constrParam1, constrParam2, constrParam3, constrParam4, constrParam5, constrParam6);
            otherCharacters.Add(constrParam1, testObject);

            testObject.ProcessLigatures(otherCharacters);

            foreach (LigatureSet item in testObject.Ligatures)
            {
                Assert.AreSame(testObject, item.First);
            }
        }

        [TestMethod]
        public void CharacterClass_ProcessLigaturesMethod_SetsLigaturesToCollectionOfObjectsWithCorrectSecondProperty()
        {
            IDictionary<string, Character> otherCharacters = GetOtherCharacters();
            short? constrParam0 = _rnd.NextNullableShort();
            string constrParam1;
            do
            {
                constrParam1 = _rnd.NextString(_rnd.Next(1, 20));
            } while (otherCharacters.ContainsKey(constrParam1));
            WidthSet constrParam2 = _rnd.NextAfmWidthSet();
            WidthSet constrParam3 = _rnd.NextAfmWidthSet();
            Vector? constrParam4 = _rnd.NextNullableAfmVector();
            BoundingBox? constrParam5 = _rnd.NextNullableAfmBoundingBox();
            IList<InitialLigatureSet> constrParam6 = GetInitialLigatureSets(otherCharacters.Keys);
            Character testObject = new(constrParam0, constrParam1, constrParam2, constrParam3, constrParam4, constrParam5, constrParam6);
            otherCharacters.Add(constrParam1, testObject);

            testObject.ProcessLigatures(otherCharacters);

            for (int i = 0; i < constrParam6.Count; ++i)
            {
                Assert.AreEqual(constrParam6[i].Second, testObject.Ligatures[i].Second.Name);
            }
        }

        [TestMethod]
        public void CharacterClass_ProcessLigaturesMethod_SetsLigaturesToCollectionOfObjectsWithCorrectLigatureProperty()
        {
            IDictionary<string, Character> otherCharacters = GetOtherCharacters();
            short? constrParam0 = _rnd.NextNullableShort();
            string constrParam1;
            do
            {
                constrParam1 = _rnd.NextString(_rnd.Next(1, 20));
            } while (otherCharacters.ContainsKey(constrParam1));
            WidthSet constrParam2 = _rnd.NextAfmWidthSet();
            WidthSet constrParam3 = _rnd.NextAfmWidthSet();
            Vector? constrParam4 = _rnd.NextNullableAfmVector();
            BoundingBox? constrParam5 = _rnd.NextNullableAfmBoundingBox();
            IList<InitialLigatureSet> constrParam6 = GetInitialLigatureSets(otherCharacters.Keys);
            Character testObject = new(constrParam0, constrParam1, constrParam2, constrParam3, constrParam4, constrParam5, constrParam6);
            otherCharacters.Add(constrParam1, testObject);

            testObject.ProcessLigatures(otherCharacters);

            for (int i = 0; i < constrParam6.Count; ++i)
            {
                Assert.AreEqual(constrParam6[i].Ligature, testObject.Ligatures[i].Ligature.Name);
            }
        }

        [TestMethod]
        public void CharacterClass_FromStringMethod_HandlesTypicalDataCorrectly()
        {
            string testParam = "C 102 ; WX 333 ; N f ; B 20 0 383 683 ; L i fi ; L l fl ;";

            Character testOutput = Character.FromString(testParam);

            Assert.IsNotNull(testOutput);
            Assert.AreEqual((short)102, testOutput.Code);
            Assert.AreEqual(333, testOutput.XWidth.General);
            Assert.IsNull(testOutput.XWidth.Direction0);
            Assert.IsNull(testOutput.XWidth.Direction1);
            Assert.AreEqual(default, testOutput.YWidth);
            Assert.AreEqual("f", testOutput.Name);
            Assert.AreEqual(20, testOutput.BoundingBox.Value.Left);
            Assert.AreEqual(0, testOutput.BoundingBox.Value.Bottom);
            Assert.AreEqual(383, testOutput.BoundingBox.Value.Right);
            Assert.AreEqual(683, testOutput.BoundingBox.Value.Top);
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
