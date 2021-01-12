using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Tests.Utility.Providers;
using Unicorn.CoreTypes;
using Unicorn.Tests.Unit.TestHelpers;

namespace Unicorn.Tests.Unit
{
    [TestClass]
    public class TableUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private class TableDefinition
        {
            internal Table Table { get; } = new Table();

            internal List<double> ColumnWidths { get; } = new List<double>();

            internal List<double> RowHeights { get; } = new List<double>();

            internal List<FixedSizeTableCell> Cells { get; } = new List<FixedSizeTableCell>();
        }

#pragma warning disable CA5394 // Do not use insecure randomness

        private static TableDefinition GetTestObject()
        {
            int columns = _rnd.Next(1, 6);
            int rows = _rnd.Next(1, 10);
            TableDefinition def = new TableDefinition();
            def.Table.RuleStyle = _rnd.NextTableRuleStyle();
            for (int i = 0; i < columns; ++i)
            {
                def.ColumnWidths.Add((_rnd.NextDouble() + 0.001) * 10);
            }
            for (int y = 0; y < rows; ++y)
            {
                def.RowHeights.Add((_rnd.NextDouble() + 0.001) * 10);
                List<TableCell> currentRow = new List<TableCell>();
                for (int x = 0; x < columns; ++x)
                {
                    FixedSizeTableCell cell = new FixedSizeTableCell(def.ColumnWidths[x], def.RowHeights[y])
                    {
                        ColumnIndex = x,
                        RowIndex = y,
                    };
                    def.Cells.Add(cell);
                    currentRow.Add(cell);
                }
                def.Table.AddRow(currentRow);
            }
            return def;
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TableClass_AddRowMethodWithTableRowParameter_ThrowsArgumentNullException_IfParameterIsNull()
        {
            Table testObject = new Table();
            TableRow testParam = null;

            testObject.AddRow(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void TableClass_AddRowMethodWithTableRowParameter_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfParameterIsNull()
        {
            Table testObject = new Table();
            TableRow testParam = null;

            try
            {
                testObject.AddRow(testParam);
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("row", ex.ParamName);
            }
        }

        [TestMethod]
        public void TableClass_AddRowMethodWithTableRowParameter_SetsParentPropertyOfParameterToThis_IfParameterIsNotNull()
        {
            TableDefinition testObjectDef = GetTestObject();
            TableRow testParam = new TableRow { Parent = null }; 
            testParam.AddRange(FixedSizeTableCell.GetCellList(testObjectDef.ColumnWidths.Count));

            testObjectDef.Table.AddRow(testParam);

            Assert.AreSame(testObjectDef.Table, testParam.Parent);
        }

        

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TableClass_AddColumnMethodWithTableColumnParameter_ThrowsArgumentNullException_IfParameterIsNull()
        {
            Table testObject = new Table();
            TableColumn testParam = null;

            testObject.AddColumn(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void TableClass_AddColumnMethodWithTableColumnParameter_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfParameterIsNull()
        {
            Table testObject = new Table();
            TableColumn testParam = null;

            try
            {
                testObject.AddColumn(testParam);
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("col", ex.ParamName);
            }
        }

        [TestMethod]
        public void TableClass_AddColumnMethodWithTableColumnParameter_SetsParentPropertyOfParameterToThis_IfParameterIsNotNull()
        {
            TableDefinition testObjectDef = GetTestObject();
            TableColumn testParam = new TableColumn { Parent = null };
            testParam.AddRange(FixedSizeTableCell.GetCellList(testObjectDef.RowHeights.Count));

            testObjectDef.Table.AddColumn(testParam);

            Assert.AreSame(testObjectDef.Table, testParam.Parent);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TableClass_DrawAtMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            Table testObject = new Table();

            testObject.DrawAt(null, _rnd.NextDouble() * 1000, _rnd.NextDouble() * 1000);

            Assert.Fail();
        }

        [TestMethod]
        public void TableClass_DrawAtMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfFirstParameterIsNull()
        {
            Table testObject = new Table();

            try
            {
                testObject.DrawAt(null, _rnd.NextDouble() * 1000, _rnd.NextDouble() * 1000);
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("context", ex.ParamName);
            }
        }

        [TestMethod]
        public void TableClass_DrawAtMethod_CallsDrawContentsAtMethodOfEachCellInTableOnce()
        {
            TableDefinition testObjectDef = GetTestObject();
            Table testObject = testObjectDef.Table;
            Mock<IGraphicsContext> testParam0Details = new Mock<IGraphicsContext>();
            double testParam1 = _rnd.NextDouble() * 100;
            double testParam2 = _rnd.NextDouble() * 100;

            testObject.DrawAt(testParam0Details.Object, testParam1, testParam2);

            foreach (FixedSizeTableCell cell in testObjectDef.Cells)
            {
                Assert.AreEqual(1, cell.DrawContentsAtCalls.Count);
            }
        }

        [TestMethod]
        public void TableClass_DrawAtMethod_CallsDrawContentsAtMethodOfEachCellWithCorrectFirstParameter()
        {
            TableDefinition testObjectDef = GetTestObject();
            Table testObject = testObjectDef.Table;
            Mock<IGraphicsContext> testParam0Details = new Mock<IGraphicsContext>();
            double testParam1 = _rnd.NextDouble() * 100;
            double testParam2 = _rnd.NextDouble() * 100;

            testObject.DrawAt(testParam0Details.Object, testParam1, testParam2);

            foreach (FixedSizeTableCell cell in testObjectDef.Cells)
            {
                Assert.AreSame(testParam0Details.Object, cell.DrawContentsAtCalls.First().Item1);
            }
        }

        [TestMethod]
        public void TableClass_DrawAtMethod_CallsDrawContentsAtMethodOfEachCellWithCorrectSecondParameter()
        {
            TableDefinition testObjectDef = GetTestObject();
            Table testObject = testObjectDef.Table;
            Mock<IGraphicsContext> testParam0Details = new Mock<IGraphicsContext>();
            double testParam1 = _rnd.NextDouble() * 100;
            double testParam2 = _rnd.NextDouble() * 100;

            testObject.DrawAt(testParam0Details.Object, testParam1, testParam2);

            foreach (FixedSizeTableCell cell in testObjectDef.Cells)
            {
                double expectedValue = testParam1 + testObjectDef.ColumnWidths.Take(cell.ColumnIndex).Sum() + (cell.ColumnIndex + 1) * testObject.RuleWidth;
                Assert.AreEqual(expectedValue, cell.DrawContentsAtCalls.First().Item2, 0.0000000001);
            }
        }

        [TestMethod]
        public void TableClass_DrawAtMethod_CallsDrawContentsAtMethodOfEachCellWithCorrectThirdParameter()
        {
            TableDefinition testObjectDef = GetTestObject();
            Table testObject = testObjectDef.Table;
            Mock<IGraphicsContext> testParam0Details = new Mock<IGraphicsContext>();
            double testParam1 = _rnd.NextDouble() * 100;
            double testParam2 = _rnd.NextDouble() * 100;

            testObject.DrawAt(testParam0Details.Object, testParam1, testParam2);

            foreach (FixedSizeTableCell cell in testObjectDef.Cells)
            {
                double expectedValue = testParam2 + testObjectDef.RowHeights.Take(cell.RowIndex).Sum() + (cell.RowIndex + 1) * testObject.RuleWidth;
                Assert.AreEqual(expectedValue, cell.DrawContentsAtCalls.First().Item3, 0.0000000001);
            }
        }

        [TestMethod]
        public void TableClass_DrawAtMethod_CallsIGraphicsContextImplementationDrawLineMethodCorrectNumberOfTimes_IfTableRuleStyleIsNone()
        {
            TableDefinition testObjectDetails = GetTestObject();
            Table testObject = testObjectDetails.Table;
            testObject.RuleStyle = TableRuleStyle.None;
            Mock<IGraphicsContext> testParam0Details = new Mock<IGraphicsContext>();
            double testParam1 = _rnd.NextDouble() * 100;
            double testParam2 = _rnd.NextDouble() * 100;

            testObject.DrawAt(testParam0Details.Object, testParam1, testParam2);

            testParam0Details.Verify(x => x.DrawLine(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>()),
                Times.Exactly(0));
        }

        [TestMethod]
        public void TableClass_DrawAtMethod_CallsIGraphicsContextImplementationDrawLineMethodCorrectNumberOfTimes_IfTableRuleStyleIsLinesMeet()
        {
            TableDefinition testObjectDetails = GetTestObject();
            Table testObject = testObjectDetails.Table;
            testObject.RuleStyle = TableRuleStyle.LinesMeet;
            Mock<IGraphicsContext> testParam0Details = new Mock<IGraphicsContext>();
            double testParam1 = _rnd.NextDouble() * 100;
            double testParam2 = _rnd.NextDouble() * 100;

            testObject.DrawAt(testParam0Details.Object, testParam1, testParam2);

            testParam0Details.Verify(x => x.DrawLine(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>()),
                Times.Exactly(testObjectDetails.ColumnWidths.Count + testObjectDetails.RowHeights.Count + 2));
        }

        [TestMethod]
        public void TableClass_DrawAtMethod_CallsIGraphicsContextImplementationDrawLineMethodCorrectNumberOfTimes_IfTableRuleStyleIsSolidColumnsBrokenRows()
        {
            TableDefinition testObjectDetails = GetTestObject();
            Table testObject = testObjectDetails.Table;
            testObject.RuleStyle = TableRuleStyle.SolidColumnsBrokenRows;
            Mock<IGraphicsContext> testParam0Details = new Mock<IGraphicsContext>();
            double testParam1 = _rnd.NextDouble() * 100;
            double testParam2 = _rnd.NextDouble() * 100;

            testObject.DrawAt(testParam0Details.Object, testParam1, testParam2);

            testParam0Details.Verify(x => x.DrawLine(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>()),
                Times.Exactly(testObjectDetails.ColumnWidths.Count * testObjectDetails.RowHeights.Count  + 3));
        }

        [TestMethod]
        public void TableClass_DrawAtMethod_CallsIGraphicsContextImplementationDrawLineMethodCorrectNumberOfTimes_IfTableRuleStyleIsSolidRowsBrokenColumns()
        {
            TableDefinition testObjectDetails = GetTestObject();
            Table testObject = testObjectDetails.Table;
            testObject.RuleStyle = TableRuleStyle.SolidRowsBrokenColumns;
            Mock<IGraphicsContext> testParam0Details = new Mock<IGraphicsContext>();
            double testParam1 = _rnd.NextDouble() * 100;
            double testParam2 = _rnd.NextDouble() * 100;

            testObject.DrawAt(testParam0Details.Object, testParam1, testParam2);

            testParam0Details.Verify(x => x.DrawLine(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>()),
                Times.Exactly(testObjectDetails.ColumnWidths.Count * testObjectDetails.RowHeights.Count + 3));
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
