using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.FontTools.Tests.Unit.TestHelpers.Mocks;
using Unicorn.FontTools.Tests.Utility;

namespace Unicorn.FontTools.OpenType.Tests.Unit
{
    [TestClass]
    public class CharacterMappingCollectionUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private static CharacterMapping[] GetTestData()
        {
            int count = _rnd.Next(1, 20);
            CharacterMapping[] data = new CharacterMapping[count];
            for (int i = 0; i < count; ++i)
            {
                data[i] = new MockCharacterMapping(_rnd.NextPlatformId(), _rnd.NextUShort(), _rnd.NextUShort());
            }
            return data;
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void CharacterMappingCollectionClass_Constructor_ReturnsObjectWithCountZero_IfParameterIsNull()
        {
            CharacterMappingCollection testOutput = new CharacterMappingCollection(null);

            Assert.AreEqual(0, testOutput.Count);
        }

        [TestMethod]
        public void CharacterMappingCollectionClass_Constructor_ReturnsObjectWithCountZero_IfParameterIsEmptyEnumeration()
        {
            CharacterMappingCollection testOutput = new CharacterMappingCollection(Array.Empty<CharacterMapping>());

            Assert.AreEqual(0, testOutput.Count);
        }

        [TestMethod]
        public void CharacterMappingCollectionClass_Constructor_ReturnsObjectWithCorrectCountProperty_IfParameterIsNotNull()
        {
            CharacterMapping[] testParam = GetTestData();

            CharacterMappingCollection testOutput = new CharacterMappingCollection(testParam);

            Assert.AreEqual(testParam.Length, testOutput.Count);
        }

        [TestMethod]
        public void CharacterMappingCollectionClass_Indexer_ReturnsCorrectItems()
        {
            CharacterMapping[] testData = GetTestData();
            CharacterMappingCollection testObject = new CharacterMappingCollection(testData);

            for(int i = 0; i < testObject.Count; ++i)
            {
                Assert.AreSame(testData[i], testObject[i]);
            }
        }

        [TestMethod]
        public void CharacterMappingCollectionClass_Enumerator_EnumeratesObjectInCorrectOrder()
        {
            CharacterMapping[] testData = GetTestData();
            CharacterMappingCollection testObject = new CharacterMappingCollection(testData);
            int idx = 0;

            IEnumerator<CharacterMapping> testEnumerator = testObject.GetEnumerator();

            while (testEnumerator.MoveNext())
            {
                Assert.AreSame(testData[idx++], testEnumerator.Current);
            }
        }

        [TestMethod]
        public void CharacterMappingCollectionClass_IEnumeratorGetEnumeratorMethod_ReturnsEnumeratorWhichEnumeratesObjectInCorrectOrder()
        {
            CharacterMapping[] testData = GetTestData();
            CharacterMappingCollection testObject = new CharacterMappingCollection(testData);
            int idx = 0;

            IEnumerator testEnumerator = ((IEnumerable)testObject).GetEnumerator();

            while (testEnumerator.MoveNext())
            {
                Assert.AreSame(testData[idx++], testEnumerator.Current);
            }
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
