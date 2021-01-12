using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Utility.Providers;
using Unicorn.Tests.Unit.TestHelpers;

namespace Unicorn.Tests.Unit
{
    [TestClass]
    public class TableCellCollectionEnumeratorUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TableCellCollectionEnumeratorClass_Constructor_ThrowsArgumentNullException_IfParameterIsNull()
        {
            using TableCellCollection.Enumerator testObject = new TableCellCollection.Enumerator(null);
            
            Assert.Fail();
        }

        [TestMethod]
        public void TableCellCollectionEnumeratorClass_Constructor_SetsCurrentPropertyToNull_IfParameterIsTableColumn()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList(_rnd.Next(1, 32));
            TableColumn testParam = new TableColumn();
            testParam.AddRange(testContents);
            using TableCellCollection.Enumerator testObject = new TableCellCollection.Enumerator(testParam);
            
            Assert.IsNull(testObject.Current);
        }

        [TestMethod]
        public void TableCellCollectionEnumeratorClass_MoveNextMethod_ReturnsFalseOnFirstCall_IfObjectIsConstructedFromEmptyTableColumn()
        {
            TableColumn testParam = new TableColumn();
            using TableCellCollection.Enumerator testObject = new TableCellCollection.Enumerator(testParam);
            
            bool testOutput = testObject.MoveNext();

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TableCellCollectionEnumeratorClass_MoveNextMethod_ReturnsTrueOnFirstCall_IfObjectIsConstructedFromNonEmptyTableColumn()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList(_rnd.Next(1, 32));
            TableColumn testParam = new TableColumn();
            testParam.AddRange(testContents);
            using TableCellCollection.Enumerator testObject = new TableCellCollection.Enumerator(testParam);
            
            bool testOutput = testObject.MoveNext();

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void TableCellCollectionEnumeratorClass_MoveNextMethod_SetsCurrentPropertyToFirstElementOfCollection_IfObjectIsConstructedFromNonEmptyTableColumn()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList(_rnd.Next(1, 32));
            TableColumn testParam = new TableColumn();
            testParam.AddRange(testContents);
            using TableCellCollection.Enumerator testObject = new TableCellCollection.Enumerator(testParam);
            
            _ = testObject.MoveNext();

            Assert.AreSame(testParam[0], testObject.Current);
        }

        [TestMethod]
        public void TableCellCollectionEnumeratorClass_MoveNextMethod_SetsCurrentPropertyToEachElementInSequenceEachTimeItIsCalled_IfObjectIsConstructedFromNonEmptyTableColumn()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList(_rnd.Next(1, 32));
            TableColumn testParam = new TableColumn();
            testParam.AddRange(testContents);
            using TableCellCollection.Enumerator testObject = new TableCellCollection.Enumerator(testParam);
            for (int i = 0; i < testParam.Count; ++i)
            {
                testObject.MoveNext();

                Assert.AreSame(testParam[i], testObject.Current);
            }
        }

        [TestMethod]
        public void TableCellCollectionEnumeratorClass_MoveNextMethod_ReturnsTrue_IfNumberOfCallsIsLessThanOrEqualToCountPropertyOfObjectItWasConstructedFromAndObjectIsConstructedFromNonEmptyTableColumn()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList(_rnd.Next(1, 32));
            TableColumn testParam = new TableColumn();
            testParam.AddRange(testContents);
            using TableCellCollection.Enumerator testObject = new TableCellCollection.Enumerator(testParam);
            for (int i = 0; i < testParam.Count; ++i)
            {
                bool testOutput = testObject.MoveNext();

                Assert.IsTrue(testOutput);
            }
        }

        [TestMethod]
        public void TableCellCollectionEnumeratorClass_MoveNextMethod_ReturnsFalse_WhenNumberOfCallsExceedsCountPropertyOfObjectItWasConstructedFrom_IfObjectIsConstructedFromNonEmptyTableColumn()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList(_rnd.Next(1, 32));
            TableColumn testParam = new TableColumn();
            testParam.AddRange(testContents);
            using TableCellCollection.Enumerator testObject = new TableCellCollection.Enumerator(testParam);
            for (int i = 0; i < testParam.Count; ++i)
            {
                _ = testObject.MoveNext();
            }

            bool testOutput = testObject.MoveNext();

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TableCellCollectionEnumeratorClass_ResetMethod_SetsCurrentPropertyToNullRegardlessOfNumberOfTimesMoveNextMethodHasBeenCalled_IfObjectIsConstructedFromNonEmptyTableColumn()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList(_rnd.Next(1, 32));
            TableColumn testParam = new TableColumn();
            testParam.AddRange(testContents);
            using TableCellCollection.Enumerator testObject = new TableCellCollection.Enumerator(testParam);
            int mnCount = _rnd.Next(64);
            for (int i = 0; i < mnCount; ++i)
            {
                testObject.MoveNext();
            }

            testObject.Reset();

            Assert.IsNull(testObject.Current);
        }

        [TestMethod]
        public void TableCellCollectionEnumeratorClass_ResetMethodThenMoveNextMethod_ReturnsFalseOnFirstCall_IfObjectIsConstructedFromEmptyTableColumn()
        {
            TableColumn testParam = new TableColumn();
            using TableCellCollection.Enumerator testObject = new TableCellCollection.Enumerator(testParam);
            int mnCount = _rnd.Next(64);
            for (int i = 0; i < mnCount; ++i)
            {
                testObject.MoveNext();
            }
            
            testObject.Reset();
            bool testOutput = testObject.MoveNext();

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TableCellCollectionEnumeratorClass_MoveNextMethod_ReturnsTrueOnFirstCallAfterResetMethodCall_IfObjectIsConstructedFromNonEmptyTableColumn()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList(_rnd.Next(1, 32));
            TableColumn testParam = new TableColumn();
            testParam.AddRange(testContents);
            using TableCellCollection.Enumerator testObject = new TableCellCollection.Enumerator(testParam);
            int mnCount = _rnd.Next(64);
            for (int i = 0; i < mnCount; ++i)
            {
                testObject.MoveNext();
            }
            
            testObject.Reset();
            bool testOutput = testObject.MoveNext();

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void TableCellCollectionEnumeratorClass_MoveNextMethod_OnFirstCallAfterResetCallSetsCurrentPropertyToFirstElementOfCollection_IfObjectIsConstructedFromNonEmptyTableColumn()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList(_rnd.Next(1, 32));
            TableColumn testParam = new TableColumn();
            testParam.AddRange(testContents);
            using TableCellCollection.Enumerator testObject = new TableCellCollection.Enumerator(testParam);
            int mnCount = _rnd.Next(64);
            for (int i = 0; i < mnCount; ++i)
            {
                testObject.MoveNext();
            }
            
            testObject.Reset();
            _ = testObject.MoveNext();

            Assert.AreSame(testParam[0], testObject.Current);
        }

        [TestMethod]
        public void TableCellCollectionEnumeratorClass_MoveNextMethod_AfterResetCallSetsCurrentPropertyToEachElementInSequenceEachTimeItIsCalled_IfObjectIsConstructedFromNonEmptyTableColumn()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList(_rnd.Next(1, 32));
            TableColumn testParam = new TableColumn();
            testParam.AddRange(testContents);
            using TableCellCollection.Enumerator testObject = new TableCellCollection.Enumerator(testParam);
            int mnCount = _rnd.Next(64);
            for (int i = 0; i < mnCount; ++i)
            {
                testObject.MoveNext();
            }
            testObject.Reset();
            for (int i = 0; i < testParam.Count; ++i)
            {
                testObject.MoveNext();

                Assert.AreSame(testParam[i], testObject.Current);
            }
        }

        [TestMethod]
        public void TableCellCollectionEnumeratorClass_MoveNextMethod_ReturnsTrue_IfNumberOfCallsAfterResetCallIsLessThanOrEqualToCountPropertyOfObjectItWasConstructedFromAndObjectIsConstructedFromNonEmptyTableColumn()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList(_rnd.Next(1, 32));
            TableColumn testParam = new TableColumn();
            testParam.AddRange(testContents);
            using TableCellCollection.Enumerator testObject = new TableCellCollection.Enumerator(testParam);
            int mnCount = _rnd.Next(64);
            for (int i = 0; i < mnCount; ++i)
            {
                testObject.MoveNext();
            }
            testObject.Reset();
            for (int i = 0; i < testParam.Count; ++i)
            {
                bool testOutput = testObject.MoveNext();

                Assert.IsTrue(testOutput);
            }
        }

        [TestMethod]
        public void TableCellCollectionEnumeratorClass_MoveNextMethod_ReturnsFalse_WhenNumberOfCallsAfterResetCallExceedsCountPropertyOfObjectItWasConstructedFrom_IfObjectIsConstructedFromNonEmptyTableColumn()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList(_rnd.Next(1, 32));
            TableColumn testParam = new TableColumn();
            testParam.AddRange(testContents);
            using TableCellCollection.Enumerator testObject = new TableCellCollection.Enumerator(testParam);
            int mnCount = _rnd.Next(64);
            for (int i = 0; i < mnCount; ++i)
            {
                testObject.MoveNext();
            }
            testObject.Reset();
            for (int i = 0; i < testParam.Count; ++i)
            {
                _ = testObject.MoveNext();
            }

            bool testOutput = testObject.MoveNext();

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TableCellCollectionEnumeratorClass_Constructor_SetsCurrentPropertyToNull_IfParameterIsTableRow()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList(_rnd.Next(1, 32));
            TableRow testParam = new TableRow();
            testParam.AddRange(testContents);
            using TableCellCollection.Enumerator testObject = new TableCellCollection.Enumerator(testParam);
            
            Assert.IsNull(testObject.Current);
        }

        [TestMethod]
        public void TableCellCollectionEnumeratorClass_MoveNextMethod_ReturnsFalseOnFirstCall_IfObjectIsConstructedFromEmptyTableRow()
        {
            TableRow testParam = new TableRow();
            using TableCellCollection.Enumerator testObject = new TableCellCollection.Enumerator(testParam);
            
            bool testOutput = testObject.MoveNext();

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TableCellCollectionEnumeratorClass_MoveNextMethod_ReturnsTrueOnFirstCall_IfObjectIsConstructedFromNonEmptyTableRow()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList(_rnd.Next(1, 32));
            TableRow testParam = new TableRow();
            testParam.AddRange(testContents);
            using TableCellCollection.Enumerator testObject = new TableCellCollection.Enumerator(testParam);
            
            bool testOutput = testObject.MoveNext();

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void TableCellCollectionEnumeratorClass_MoveNextMethod_SetsCurrentPropertyToFirstElementOfCollection_IfObjectIsConstructedFromNonEmptyTableRow()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList(_rnd.Next(1, 32));
            TableRow testParam = new TableRow();
            testParam.AddRange(testContents);
            using TableCellCollection.Enumerator testObject = new TableCellCollection.Enumerator(testParam);
            
            _ = testObject.MoveNext();

            Assert.AreSame(testParam[0], testObject.Current);
        }

        [TestMethod]
        public void TableCellCollectionEnumeratorClass_MoveNextMethod_SetsCurrentPropertyToEachElementInSequenceEachTimeItIsCalled_IfObjectIsConstructedFromNonEmptyTableRow()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList(_rnd.Next(1, 32));
            TableRow testParam = new TableRow();
            testParam.AddRange(testContents);
            using TableCellCollection.Enumerator testObject = new TableCellCollection.Enumerator(testParam);
            
            for (int i = 0; i < testParam.Count; ++i)
            {
                testObject.MoveNext();

                Assert.AreSame(testParam[i], testObject.Current);
            }
        }

        [TestMethod]
        public void TableCellCollectionEnumeratorClass_MoveNextMethod_ReturnsTrue_IfNumberOfCallsIsLessThanOrEqualToCountPropertyOfObjectItWasConstructedFromAndObjectIsConstructedFromNonEmptyTableRow()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList(_rnd.Next(1, 32));
            TableRow testParam = new TableRow();
            testParam.AddRange(testContents);
            using TableCellCollection.Enumerator testObject = new TableCellCollection.Enumerator(testParam);
            
            for (int i = 0; i < testParam.Count; ++i)
            {
                bool testOutput = testObject.MoveNext();

                Assert.IsTrue(testOutput);
            }
        }

        [TestMethod]
        public void TableCellCollectionEnumeratorClass_MoveNextMethod_ReturnsFalse_WhenNumberOfCallsExceedsCountPropertyOfObjectItWasConstructedFrom_IfObjectIsConstructedFromNonEmptyTableRow()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList(_rnd.Next(1, 32));
            TableRow testParam = new TableRow();
            testParam.AddRange(testContents);
            using TableCellCollection.Enumerator testObject = new TableCellCollection.Enumerator(testParam);
            
            for (int i = 0; i < testParam.Count; ++i)
            {
                _ = testObject.MoveNext();
            }

            bool testOutput = testObject.MoveNext();

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TableCellCollectionEnumeratorClass_ResetMethod_SetsCurrentPropertyToNullRegardlessOfNumberOfTimesMoveNextMethodHasBeenCalled_IfObjectIsConstructedFromNonEmptyTableRow()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList(_rnd.Next(1, 32));
            TableRow testParam = new TableRow();
            testParam.AddRange(testContents);
            using TableCellCollection.Enumerator testObject = new TableCellCollection.Enumerator(testParam);
            int mnCount = _rnd.Next(64);
            for (int i = 0; i < mnCount; ++i)
            {
                testObject.MoveNext();
            }
            testObject.Reset();

            Assert.IsNull(testObject.Current);
        }

        [TestMethod]
        public void TableCellCollectionEnumeratorClass_ResetMethodThenMoveNextMethod_ReturnsFalseOnFirstCall_IfObjectIsConstructedFromEmptyTableRow()
        {
            TableRow testParam = new TableRow();
            using TableCellCollection.Enumerator testObject = new TableCellCollection.Enumerator(testParam);
            int mnCount = _rnd.Next(64);
            for (int i = 0; i < mnCount; ++i)
            {
                testObject.MoveNext();
            }
            
            testObject.Reset();
            bool testOutput = testObject.MoveNext();

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TableCellCollectionEnumeratorClass_MoveNextMethod_ReturnsTrueOnFirstCallAfterResetMethodCall_IfObjectIsConstructedFromNonEmptyTableRow()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList(_rnd.Next(1, 32));
            TableRow testParam = new TableRow();
            testParam.AddRange(testContents);
            using TableCellCollection.Enumerator testObject = new TableCellCollection.Enumerator(testParam);
            int mnCount = _rnd.Next(64);
            for (int i = 0; i < mnCount; ++i)
            {
                testObject.MoveNext();
            }
            
            testObject.Reset();
            bool testOutput = testObject.MoveNext();

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void TableCellCollectionEnumeratorClass_MoveNextMethod_OnFirstCallAfterResetCallSetsCurrentPropertyToFirstElementOfCollection_IfObjectIsConstructedFromNonEmptyTableRow()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList(_rnd.Next(1, 32));
            TableRow testParam = new TableRow();
            testParam.AddRange(testContents);
            using TableCellCollection.Enumerator testObject = new TableCellCollection.Enumerator(testParam);
            int mnCount = _rnd.Next(64);
            for (int i = 0; i < mnCount; ++i)
            {
                testObject.MoveNext();
            }
            
            testObject.Reset();
            _ = testObject.MoveNext();

            Assert.AreSame(testParam[0], testObject.Current);
        }

        [TestMethod]
        public void TableCellCollectionEnumeratorClass_MoveNextMethod_AfterResetCallSetsCurrentPropertyToEachElementInSequenceEachTimeItIsCalled_IfObjectIsConstructedFromNonEmptyTableRow()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList(_rnd.Next(1, 32));
            TableRow testParam = new TableRow();
            testParam.AddRange(testContents);
            using TableCellCollection.Enumerator testObject = new TableCellCollection.Enumerator(testParam);
            int mnCount = _rnd.Next(64);
            for (int i = 0; i < mnCount; ++i)
            {
                testObject.MoveNext();
            }
            
            testObject.Reset();
            for (int i = 0; i < testParam.Count; ++i)
            {
                testObject.MoveNext();

                Assert.AreSame(testParam[i], testObject.Current);
            }
        }

        [TestMethod]
        public void TableCellCollectionEnumeratorClass_MoveNextMethod_ReturnsTrue_IfNumberOfCallsAfterResetCallIsLessThanOrEqualToCountPropertyOfObjectItWasConstructedFromAndObjectIsConstructedFromNonEmptyTableRow()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList(_rnd.Next(1, 32));
            TableRow testParam = new TableRow();
            testParam.AddRange(testContents);
            using TableCellCollection.Enumerator testObject = new TableCellCollection.Enumerator(testParam);
            int mnCount = _rnd.Next(64);
            for (int i = 0; i < mnCount; ++i)
            {
                testObject.MoveNext();
            }
            
            testObject.Reset();
            for (int i = 0; i < testParam.Count; ++i)
            {
                bool testOutput = testObject.MoveNext();

                Assert.IsTrue(testOutput);
            }
        }

        [TestMethod]
        public void TableCellCollectionEnumeratorClass_MoveNextMethod_ReturnsFalse_WhenNumberOfCallsAfterResetCallExceedsCountPropertyOfObjectItWasConstructedFrom_IfObjectIsConstructedFromNonEmptyTableRow()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList(_rnd.Next(1, 32));
            TableRow testParam = new TableRow();
            testParam.AddRange(testContents);
            using TableCellCollection.Enumerator testObject = new TableCellCollection.Enumerator(testParam);
            int mnCount = _rnd.Next(64);
            for (int i = 0; i < mnCount; ++i)
            {
                testObject.MoveNext();
            }
            
            testObject.Reset();
            for (int i = 0; i < testParam.Count; ++i)
            {
                _ = testObject.MoveNext();
            }
            bool testOutput = testObject.MoveNext();

            Assert.IsFalse(testOutput);
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
