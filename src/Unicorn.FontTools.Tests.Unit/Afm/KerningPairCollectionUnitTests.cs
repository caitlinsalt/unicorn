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
    public class KerningPairCollectionUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness

        private static IList<KerningPair> GetTestData()
        {
            int count = _rnd.Next(1, 20);
            KerningPair[] output = new KerningPair[count];
            List<string> secondPropertyNames = new List<string>();
            for (int i = 0; i < count; ++i)
            {
                output[i] = _rnd.NextAfmKerningPair(secondPropertyNames);
                secondPropertyNames.Add(output[i].Second.Name);
            }
            return output;
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void KerningPairCollection_ParameterlessConstructor_CreatesObjectWithCountPropertyEqualToZero()
        {
            KerningPairCollection testObject = new KerningPairCollection();

            Assert.AreEqual(0, testObject.Count);
        }

        [TestMethod]
        public void KerningPairCollection_ConstructorWithIEnumerableOfKerningPairParameter_CreatesObjectWithCountPropertyEqualToZero_IfParameterIsNull()
        {
            IEnumerable<KerningPair> testParam = null;

            KerningPairCollection testObject = new KerningPairCollection(testParam);

            Assert.AreEqual(0, testObject.Count);
        }

        [TestMethod]
        public void KerningPairCollection_ConstructorWithIEnumerableOfKerningPairParameter_CreatesObjectWithCountPropertyEqualToNumberOfItemsInParameter_IfParameterIsNotNull()
        {
            IList<KerningPair> testParam = GetTestData();

            KerningPairCollection testObject = new KerningPairCollection(testParam);

            Assert.AreEqual(testParam.Count, testObject.Count);
        }

        [TestMethod]
        public void KerningPairCollection_IndexerWithIntParameter_ReturnsExpectedItems()
        {
            IList<KerningPair> constrParam = GetTestData();
            KerningPairCollection testObject = new KerningPairCollection(constrParam);

            for (int i = 0; i < constrParam.Count; ++i)
            {
                Assert.AreEqual(constrParam[i], testObject[i]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void KerningPairCollectionClass_IndexerWithIntParameter_ThrowsArgumentOutOfRangeException_IfParameterIsNegative()
        {
            IList<KerningPair> constrParam = GetTestData();
            KerningPairCollection testObject = new KerningPairCollection(constrParam);
            int testParam0 = -_rnd.Next();

            _ = testObject[testParam0];

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void KerningPairCollectionClass_IndexerWithIntParameter_ThrowsArgumentOutOfRangeException_IfParameterEqualsCountProperty()
        {
            IList<KerningPair> constrParam = GetTestData();
            KerningPairCollection testObject = new KerningPairCollection(constrParam);

            _ = testObject[testObject.Count];

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void KerningPairCollectionClass_IndexerWithIntParameter_ThrowsArgumentOutOfRangeException_IfParameterIsGreaterThanCountProperty()
        {
            IList<KerningPair> constrParam = GetTestData();
            KerningPairCollection testObject = new KerningPairCollection(constrParam);
            int testParam0 = _rnd.Next(testObject.Count + 1, int.MaxValue);

            _ = testObject[testParam0];

            Assert.Fail();
        }

        [TestMethod]
        public void KerningPairCollectionClass_GetEnumeratorMethod_ReturnsEnumeratorWhichReturnsItemsInCorrectSequence()
        {
            IList<KerningPair> constrParam = GetTestData();
            KerningPairCollection testObject = new KerningPairCollection(constrParam);

            IEnumerator<KerningPair> testOutput = testObject.GetEnumerator();

            int i = 0;
            while (testOutput.MoveNext())
            {
                Assert.AreEqual(constrParam[i++], testOutput.Current);
            }
        }

        [TestMethod]
        public void KerningPairCollectionClass_IndexerWithStringParameter_ReturnsExpectedItem_IfItemWithSecondPropertyWithNamePropertyEqualToParameterExistsInCollection()
        {
            IList<KerningPair> constrParam = GetTestData();
            KerningPairCollection testObject = new KerningPairCollection(constrParam);
            int selectedIndex = _rnd.Next(constrParam.Count);
            string testParam = constrParam[selectedIndex].Second.Name;

            KerningPair? testOutput = testObject[testParam];

            Assert.AreEqual(constrParam[selectedIndex], testOutput.Value);
        }

        [TestMethod]
        public void KerningPairCollectionClass_IndexerWithStringParameter_ReturnsNull_IfNoItemsWithSecondPropertyWithNamePropertyEqualToParameterExistInCollection()
        {
            IList<KerningPair> constrParam = GetTestData();
            KerningPairCollection testObject = new KerningPairCollection(constrParam);
            string testParam;
            do
            {
                testParam = _rnd.NextString(_rnd.Next(1, 20));
            } while (constrParam.Any(s => s.Second.Name == testParam));

            KerningPair? testOutput = testObject[testParam];

            Assert.IsNull(testOutput);
        }

        [TestMethod]
        public void KerningPairCollectionClass_AddMethod_IncreasesCountPropertyByOne()
        {
            IList<KerningPair> constrParam = GetTestData();
            KerningPairCollection testObject = new KerningPairCollection(constrParam);
            int expectedValue = testObject.Count + 1;
            KerningPair testParam = _rnd.NextAfmKerningPair(null);

            testObject.Add(testParam);

            Assert.AreEqual(expectedValue, testObject.Count);
        }

        [TestMethod]
        public void KerningPairCollectionClass_AddMethod_AddsItemToEndOfCollection()
        {
            IList<KerningPair> constrParam = GetTestData();
            KerningPairCollection testObject = new KerningPairCollection(constrParam);
            KerningPair testParam = _rnd.NextAfmKerningPair(null);

            testObject.Add(testParam);

            Assert.AreEqual(testParam, testObject[^1]);
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
