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
    public class LigatureSetCollectionUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness

        private static IList<LigatureSet> GetTestData()
        {
            int count = _rnd.Next(1, 20);
            LigatureSet[] output = new LigatureSet[count];
            List<string> secondPropertyNames = new List<string>();
            for (int i = 0; i < count; ++i)
            {
                output[i] = _rnd.NextAfmLigatureSet(secondPropertyNames);
                secondPropertyNames.Add(output[i].Second.Name);
            }
            return output;
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void LigatureSetCollectionClass_Constructor_CreatesObjectWithCountPropertyEqualToZero_IfParameterIsNull()
        {
            LigatureSetCollection testOutput = new LigatureSetCollection(null);

            Assert.AreEqual(0, testOutput.Count);
        }

        [TestMethod]
        public void LigatureSetCollectionClass_Constructor_CreatesObjectWithCountPropertyEqualToCountPropertyOfParameterPassedToConstructor_IfParameterIsNotNull()
        {
            IList<LigatureSet> testParam0 = GetTestData();

            LigatureSetCollection testOutput = new LigatureSetCollection(testParam0);

            Assert.AreEqual(testParam0.Count, testOutput.Count);
        }

        [TestMethod]
        public void LigatureSetCollectionClass_IndexerWithIntParameter_ReturnsExpectedItems()
        {
            IList<LigatureSet> constrParam = GetTestData();
            LigatureSetCollection testObject = new LigatureSetCollection(constrParam);

            for (int i = 0; i < testObject.Count; ++i)
            {
                Assert.AreEqual(constrParam[i], testObject[i]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void LigatureSetCollectionClass_IndexerWithIntParameter_ThrowsIndexOutOfRangeException_IfParameterIsNegative()
        {
            IList<LigatureSet> constrParam = GetTestData();
            LigatureSetCollection testObject = new LigatureSetCollection(constrParam);
            int testParam0 = -_rnd.Next();
            
            _ = testObject[testParam0];

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void LigatureSetCollectionClass_IndexerWithIntParameter_ThrowsIndexOutOfRangeException_IfParameterEqualsCountProperty()
        {
            IList<LigatureSet> constrParam = GetTestData();
            LigatureSetCollection testObject = new LigatureSetCollection(constrParam);

            _ = testObject[testObject.Count];

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void LigatureSetCollectionClass_IndexerWithIntParameter_ThrowsIndexOutOfRangeException_IfParameterIsGreaterThanCountProperty()
        {
            IList<LigatureSet> constrParam = GetTestData();
            LigatureSetCollection testObject = new LigatureSetCollection(constrParam);
            int testParam0 = _rnd.Next(testObject.Count + 1, int.MaxValue);

            _ = testObject[testParam0];

            Assert.Fail();
        }

        [TestMethod]
        public void LigatureSetCollectionClass_GetEnumeratorMethod_ReturnsEnumeratorWhichReturnsItemsInCorrectSequence()
        {
            IList<LigatureSet> constrParam = GetTestData();
            LigatureSetCollection testObject = new LigatureSetCollection(constrParam);

            IEnumerator<LigatureSet> testOutput = testObject.GetEnumerator();

            int i = 0;
            while (testOutput.MoveNext())
            {
                Assert.AreEqual(constrParam[i++], testOutput.Current);
            }
        }

        [TestMethod]
        public void LigatureSetCollectionClass_IndexerWithStringParameter_ReturnsExpectedItem_IfItemWithSecondPropertyWithNamePropertyEqualToParameterExistsInCollection()
        {
            IList<LigatureSet> constrParam = GetTestData();
            LigatureSetCollection testObject = new LigatureSetCollection(constrParam);
            int selectedIndex = _rnd.Next(constrParam.Count);
            string testParam = constrParam[selectedIndex].Second.Name;

            LigatureSet? testOutput = testObject[testParam];

            Assert.AreEqual(constrParam[selectedIndex], testOutput.Value);
        }

        [TestMethod]
        public void LigatureSetCollectionClass_IndexerWithStringParameter_ReturnsNull_IfNoItemsWithSecondPropertyWithNamePropertyEqualToParameterExistInCollection()
        {
            IList<LigatureSet> constrParam = GetTestData();
            LigatureSetCollection testObject = new LigatureSetCollection(constrParam);
            string testParam;
            do
            {
                testParam = _rnd.NextString(_rnd.Next(1, 20));
            } while (constrParam.Any(s => s.Second.Name == testParam));

            LigatureSet? testOutput = testObject[testParam];

            Assert.IsNull(testOutput);
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
