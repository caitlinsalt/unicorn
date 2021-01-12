using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Tests.Utility.Providers;
using Unicorn.Tests.Unit.TestHelpers;

namespace Unicorn.Tests.Unit
{
    [TestClass]
    public class TableColumnUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void TableColumnClass_ComputedHeightProperty_ReturnsSumOfComputedHeightPropertiesOfContents_IfParentPropertyIsNull()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList();
            TableColumn testObject = new TableColumn { Parent = null };
            testObject.AddRange(testContents);

            double testOutput = testObject.ComputedHeight;

            Assert.AreEqual(testContents.Sum(c => c.ComputedHeight), testOutput);
        }

        [TestMethod]
        public void TableColumnClass_ComputedHeightProperty_ReturnSumOfComputedHeightPropertiesOfContentsPlusCalculatedGridLineWidths_IfParentPropertyIsNotNull()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList();
            Table testParentProperty = new Table { RuleWidth = _rnd.NextDouble() * 3 };
            TableColumn testObject = new TableColumn { Parent = testParentProperty };
            testObject.AddRange(testContents);

            double testOutput = testObject.ComputedHeight;

            double cellHeights = testContents.Sum(c => c.ComputedHeight);
            double ruleWidths = (testContents.Count + 1) * testParentProperty.RuleWidth;
            Assert.AreEqual(cellHeights + ruleWidths, testOutput);
        }

        //
        // Functionality inherited from Unicorn.TableCellCollection
        //

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TableColumnClass_IndexerSetMethod_InvalidatesEnumerator()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList(_rnd.Next(1, 32));
            TableColumn testObject = new TableColumn();
            testObject.AddRange(testContents);

            foreach (TableCell cell in testObject)
            {
                testObject[_rnd.Next(testContents.Count)] = _rnd.NextFixedSizeTableCell();
            }

            Assert.Fail();
        }

        [TestMethod]
        public void TableColumnClass_AddMethod_IncreasesCountPropertyByOne()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList();
            TableColumn testObject = new TableColumn();
            testObject.AddRange(testContents);
            TableCell testParam = _rnd.NextFixedSizeTableCell();

            testObject.Add(testParam);

            Assert.AreEqual(testContents.Count + 1, testObject.Count);
        }

        [TestMethod]
        public void TableColumnClass_AddMethod_SetsItemWithIndexEqualToCountMinus1()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList();
            TableColumn testObject = new TableColumn();
            testObject.AddRange(testContents);
            TableCell testParam = _rnd.NextFixedSizeTableCell();

            testObject.Add(testParam);

            Assert.AreSame(testParam, testObject[testObject.Count - 1]);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TableColumnClass_AddMethod_InvalidatesEnumerator()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList(_rnd.Next(1, 40));
            TableColumn testObject = new TableColumn();
            testObject.AddRange(testContents);
            TableCell testParam = _rnd.NextFixedSizeTableCell();

            foreach (TableCell cell in testObject)
            {
                testObject.Add(testParam);
            }

            Assert.Fail();
        }

        [TestMethod]
        public void TableColumnClass_AddRangeMethod_IncreasesCountPropertyByAmountEqualToCountPropertyOfParameter()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList();
            TableColumn testObject = new TableColumn();
            testObject.AddRange(testContents);
            List<TableCell> testParam = FixedSizeTableCell.GetCellList();

            testObject.AddRange(testParam);

            Assert.AreEqual(testContents.Count + testParam.Count, testObject.Count);
        }

        [TestMethod]
        public void TableColumnClass_AddRangeMethod_SetsNewElementsInCollectionToCorrectValues()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList();
            TableColumn testObject = new TableColumn();
            testObject.AddRange(testContents);
            List<TableCell> testParam = FixedSizeTableCell.GetCellList(_rnd.Next(1, 32));

            testObject.AddRange(testParam);

            for (int i = 0; i < testParam.Count; ++i)
            {
                Assert.AreSame(testParam[i], testObject[i + testContents.Count]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TableColumnClass_AddRangeMethod_InvalidatesEnumerator()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList(_rnd.Next(1, 32));
            TableColumn testObject = new TableColumn();
            testObject.AddRange(testContents);
            List<TableCell> testParam = FixedSizeTableCell.GetCellList(_rnd.Next(1, 32));

            foreach (TableCell cell in testObject)
            {
                testObject.AddRange(testParam);
            }

            Assert.Fail();
        }

        [TestMethod]
        public void TableColumnClass_ClearMethod_SetsCountPropertyToZero()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList();
            TableColumn testObject = new TableColumn();
            testObject.AddRange(testContents);

            testObject.Clear();

            Assert.AreEqual(0, testObject.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TableColumnClass_ClearMethod_InvalidatesEnumerator()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList(_rnd.Next(1, 32));
            TableColumn testObject = new TableColumn();
            testObject.AddRange(testContents);

            foreach (TableCell cell in testObject)
            {
                testObject.Clear();
            }

            Assert.Fail();
        }

        [TestMethod]
        public void TableColumnClass_GetEnumeratorMethod_ReturnsNewObjectOnEachCall()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList();
            TableColumn testObject = new TableColumn();
            testObject.AddRange(testContents);

            IEnumerator<TableCell> testOutput0 = testObject.GetEnumerator();
            IEnumerator<TableCell> testOutput1 = testObject.GetEnumerator();

            Assert.IsNotNull(testOutput0);
            Assert.IsNotNull(testOutput1);
            Assert.AreNotSame(testOutput0, testOutput1);
        }

        [TestMethod]
        public void TableColumnClass_InsertMethod_IncreasesCountPropertyBy1_IfFirstParameterIsWithinRange()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList(_rnd.Next(1, 32));
            TableColumn testObject = new TableColumn();
            testObject.AddRange(testContents);
            int testParam0 = _rnd.Next(testContents.Count);
            TableCell testParam1 = _rnd.NextFixedSizeTableCell();

            testObject.Insert(testParam0, testParam1);

            Assert.AreEqual(testContents.Count + 1, testObject.Count);
        }

        [TestMethod]
        public void TableColumnClass_InsertMethod_SetsElementAtFirstParameterToSecondParameter_IfFirstParameterIsWithinRange()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList(_rnd.Next(1, 32));
            TableColumn testObject = new TableColumn();
            testObject.AddRange(testContents);
            int testParam0 = _rnd.Next(testContents.Count);
            TableCell testParam1 = _rnd.NextFixedSizeTableCell();

            testObject.Insert(testParam0, testParam1);

            Assert.AreSame(testParam1, testObject[testParam0]);
        }

        [TestMethod]
        public void TableColummClass_InsertMethod_IncreasesIndexesOfAllElementsWhichHadAnIndexEqualToFirstParameterOrHigherBy1_IfFirstParameterIsWithinRange()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList(_rnd.Next(1, 32));
            TableColumn testObject = new TableColumn();
            testObject.AddRange(testContents);
            int testParam0 = _rnd.Next(testContents.Count);
            TableCell testParam1 = _rnd.NextFixedSizeTableCell();

            testObject.Insert(testParam0, testParam1);

            for (int i = testParam0; i < testContents.Count; ++i)
            {
                Assert.AreSame(testContents[i], testObject[i + 1]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TableColumnClass_InsertMethod_InvalidatesEnumerator_IfFirstParameterIsWithinRange()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList(_rnd.Next(1, 32));
            TableColumn testObject = new TableColumn();
            testObject.AddRange(testContents);
            int testParam0 = _rnd.Next(testContents.Count);
            TableCell testParam1 = _rnd.NextFixedSizeTableCell();

            foreach (TableCell cell in testObject)
            {
                testObject.Insert(testParam0, testParam1);
            }

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TableColumnClass_InsertMethod_ThrowsIndexOutOfRangeException_IfFirstParameterIsLessThanZero()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList(_rnd.Next(1, 32));
            TableColumn testObject = new TableColumn();
            testObject.AddRange(testContents);
            int testParam0 = _rnd.Next(1, int.MaxValue - 1) * -1;
            TableCell testParam1 = _rnd.NextFixedSizeTableCell();

            testObject.Insert(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void TableColumnClass_RemoveMethod_ReturnsFalse_IfCollectionDidNotContainParameter()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList(_rnd.Next(1, 32));
            TableColumn testObject = new TableColumn();
            testObject.AddRange(testContents);
            TableCell testParam0 = _rnd.NextFixedSizeTableCell();

            bool testOutput = testObject.Remove(testParam0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TableColumnClass_RemoveMethod_DoesNotChangeCountProperty_IfCollectionDidNotContainParameter()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList(_rnd.Next(1, 32));
            TableColumn testObject = new TableColumn();
            testObject.AddRange(testContents);
            TableCell testParam0 = _rnd.NextFixedSizeTableCell();
            int expectedValue = testObject.Count;

            _ = testObject.Remove(testParam0);

            Assert.AreEqual(expectedValue, testObject.Count);
        }

        [TestMethod]
        public void TableColumnClass_RemoveMethod_DoesNotInvalidateEnumerator_IfCollectionDidNotContainParameter()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList(_rnd.Next(1, 32));
            TableColumn testObject = new TableColumn();
            testObject.AddRange(testContents);
            TableCell testParam0 = _rnd.NextFixedSizeTableCell();

            foreach (TableCell cell in testContents)
            {
                _ = testObject.Remove(testParam0);
            }
        }

        [TestMethod]
        public void TableColumnClass_RemoveMethod_ReturnsTrue_IfCollectionContainedParameter()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList(_rnd.Next(1, 32));
            TableColumn testObject = new TableColumn();
            testObject.AddRange(testContents);
            int removeIndex = _rnd.Next(testObject.Count);
            TableCell testParam = testObject[removeIndex];

            bool testOutput = testObject.Remove(testParam);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void TableColumnClass_RemoveMethod_ReducesCountPropertyBy1_IfCollectionContainedParameter()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList(_rnd.Next(1, 32));
            TableColumn testObject = new TableColumn();
            testObject.AddRange(testContents);
            int removeIndex = _rnd.Next(testObject.Count);
            TableCell testParam = testObject[removeIndex];
            int expectedValue = testObject.Count - 1;

            _ = testObject.Remove(testParam);

            Assert.AreEqual(expectedValue, testObject.Count);
        }

        [TestMethod]
        public void TableColumnClass_RemoveMethod_RemovesParameterFromCollection_IfCollectionContainedParameter()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList(_rnd.Next(1, 32));
            TableColumn testObject = new TableColumn();
            testObject.AddRange(testContents);
            int removeIndex = _rnd.Next(testObject.Count);
            TableCell testParam = testObject[removeIndex];

            _ = testObject.Remove(testParam);

            Assert.IsFalse(testObject.Contains(testParam));
        }

        [TestMethod]
        public void TableColumnClass_RemoveMethod_ReducesIndexOfElementsInCollectionAfterParameterBy1_IfCollectionContainedParameter()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList(_rnd.Next(1, 32));
            TableColumn testObject = new TableColumn();
            testObject.AddRange(testContents);
            int removeIndex = _rnd.Next(testObject.Count);
            TableCell testParam = testObject[removeIndex];

            _ = testObject.Remove(testParam);

            for (int i = removeIndex; i < testObject.Count; ++i)
            {
                Assert.AreSame(testContents[i + 1], testObject[i]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TableColumnClass_RemoveMethod_InvalidatesEnumerator_IfCollectionContainedParameter()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList(_rnd.Next(1, 32));
            TableColumn testObject = new TableColumn();
            testObject.AddRange(testContents);
            int removeIndex = _rnd.Next(testObject.Count);
            TableCell testParam = testObject[removeIndex];

            foreach (TableCell cell in testObject)
            {
                _ = testObject.Remove(testParam);
            }

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TableColumnClass_RemoveAtMethod_ThrowsIndexOutOfRangeException_IfParameterIsLessThanZero()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList(_rnd.Next(1, 32));
            TableColumn testObject = new TableColumn();
            testObject.AddRange(testContents);
            int testParam = _rnd.Next(1, int.MaxValue - 1) * -1;

            testObject.RemoveAt(testParam);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TableColumnClass_RemoveAtMethod_ThrowsIndexOutOfRangeException_IfParameterEqualsCountProperty()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList(_rnd.Next(1, 32));
            TableColumn testObject = new TableColumn();
            testObject.AddRange(testContents);
            int testParam = testObject.Count;

            testObject.RemoveAt(testParam);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TableColumnClass_RemoveAtMethod_ThrowsIndexOutOfRangeException_IfParameterIsGreaterThanCountProperty()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList(_rnd.Next(1, 32));
            TableColumn testObject = new TableColumn();
            testObject.AddRange(testContents);
            int testParam = _rnd.Next(testObject.Count + 1, int.MaxValue);

            testObject.RemoveAt(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void TableColumnClass_RemoveAtMethod_ReducesCountPropertyBy1_IfParameterIsInRange()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList(_rnd.Next(1, 32));
            TableColumn testObject = new TableColumn();
            testObject.AddRange(testContents);
            int testParam = _rnd.Next(testObject.Count);
            int expectedValue = testObject.Count - 1;

            testObject.RemoveAt(testParam);

            Assert.AreEqual(expectedValue, testObject.Count);
        }

        [TestMethod]
        public void TableColumnClass_RemoveAtMethod_RemovesElementAtIndexEqualToParameter_IfParameterIsInRange()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList(_rnd.Next(1, 32));
            TableColumn testObject = new TableColumn();
            testObject.AddRange(testContents);
            int testParam = _rnd.Next(testObject.Count);
            TableCell removedItem = testObject[testParam];

            testObject.RemoveAt(testParam);

            Assert.IsFalse(testObject.Contains(removedItem));
        }

        [TestMethod]
        public void TableColumnClass_RemoveAtMethod_ReducedIndexesOfElementsWithIndexesGreaterThanParameterBy1_IfParameterIsInRange()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList(_rnd.Next(1, 32));
            TableColumn testObject = new TableColumn();
            testObject.AddRange(testContents);
            int testParam = _rnd.Next(testObject.Count);

            testObject.RemoveAt(testParam);

            for (int i = testParam; i < testObject.Count; ++i)
            {
                Assert.AreSame(testContents[i + 1], testObject[i]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TableColumnClass_RemoveAtMethod_InvalidatesEnumerator_IfParameterIsInRange()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList(_rnd.Next(1, 32));
            TableColumn testObject = new TableColumn();
            testObject.AddRange(testContents);
            int testParam = _rnd.Next(testObject.Count);

            foreach (TableCell cell in testObject)
            {
                testObject.RemoveAt(testParam);
            }

            Assert.Fail();
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
