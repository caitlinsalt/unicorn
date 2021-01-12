using System;
using System.Collections.Generic;
using System.Linq;
using Unicorn.CoreTypes;

namespace Unicorn
{
    /// <summary>
    /// A table with uniform rows and columns.
    /// </summary>
    public class Table : IDrawable
    {
        private readonly List<TableRow> _rows;
        private readonly List<TableColumn> _columns;

        /// <summary>
        /// Style to use when drawing table gridlines.
        /// </summary>
        public TableRuleStyle RuleStyle { get; set; }

        /// <summary>
        /// If a TableRuleStyle whose lines do not meet is selected, how large a gap will be left between lines.
        /// </summary>
        public double RuleGapSize { get; set; }

        /// <summary>
        /// Width of the table's lines.
        /// </summary>
        public double RuleWidth { get; set; }

        /// <summary>
        /// The width of the entire table when drawn.
        /// </summary>
        public double ComputedWidth
        {
            get
            {
                if (_rows.Count == 0)
                {
                    return 0;
                }
                return _rows.First(r => r != null).ComputedWidth;
            }
        }

        /// <summary>
        /// The height of this table when drawn.
        /// </summary>
        public double ComputedHeight
        {
            get
            {
                if (_columns.Count == 0)
                {
                    return 0;
                }
                return _columns.First(c => c != null).ComputedHeight;
            }
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Table()
        {
            _rows = new List<TableRow>();
            _columns = new List<TableColumn>();
            RuleWidth = 1.0;
        }

        /// <summary>
        /// Gets the row at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the row to get.</param>
        /// <returns>The row at the specified index.</returns>
        public TableRow this[int index]
        {
            get
            {
                return _rows[index];
            }
        }

        /// <summary>
        /// Add a <see cref="TableRow"/> to the table.
        /// </summary>
        /// <param name="row">The row to add to the table.</param>
        /// <remarks>If the added row contains more cells than the rows currently in the table, the rows currently in the table are padded on the right with null cells until they are the same
        /// width as the new row.  If the added row contains fewer cells than the rows currently in the table, it is padded on the right until it is the same with as the other rows.</remarks>
        public void AddRow(TableRow row)
        {
            if (row is null)
            {
                throw new ArgumentNullException(nameof(row));
            }

            row.Parent = this;

            // Make sure table is wide enough for the new row
            while (row.Count > _columns.Count)
            {
                _columns.Add(new TableColumn { Parent = this });
                for (int i = 0; i < _rows.Count; ++i)
                {
                    _columns[_columns.Count - 1].Add(null);
                }
            }

            _rows.Add(row);
            for (int i = 0; i < row.Count; ++i)
            {
                _columns[i].Add(row[i]);
            }
            for (int i = row.Count; i < _columns.Count; ++i)
            {
                _columns[i].Add(null);
            }
        }

        /// <summary>
        /// Add a row to the table, consisting of a list of cells.
        /// </summary>
        /// <param name="rowContents">The cells to add to the table.</param>
        /// <remarks>This method adds a new row to the table, consisting of a range of cells.  The cells are added to columns starting with column 0.  If there are fewer cells than columns,
        /// the new row is padded with null cells on the right.  If there are more cells than columns, the existing rows in the table are passed with null cells on the right.</remarks>
        public void AddRow(IEnumerable<TableCell> rowContents)
        {
            TableRow row = new TableRow { Parent = this };
            row.AddRange(rowContents);
            AddRow(row);
        }

        /// <summary>
        /// Add a row to the table, consisting of a list of cells.
        /// </summary>
        /// <param name="rowContents">The cells to add to the table.</param>
        /// <remarks>This method adds a new row to the table, consisting of a range of cells.  The cells are added to columns starting with column 0.  If there are fewer cells than columns,
        /// the new row is padded with null cells on the right.  If there are more cells than columns, the existing rows in the table are passed with null cells on the right.</remarks>
        public void AddRow(params TableCell[] rowContents)
        {
            AddRow((IEnumerable<TableCell>)rowContents);
        }

        /// <summary>
        /// Add a <see cref="TableColumn"/> to the table.
        /// </summary>
        /// <param name="col">The column to add to the table.</param>
        public void AddColumn(TableColumn col)
        {
            if (col is null)
            {
                throw new ArgumentNullException(nameof(col));
            }

            col.Parent = this;

            // Make sure table is deep enough for the new column
            while (col.Count > _rows.Count)
            {
                _rows.Add(new TableRow { Parent = this });
                for (int i = 0; i < _columns.Count; ++i)
                {
                    _rows[_rows.Count - 1].Add(null);
                }
            }

            _columns.Add(col);
            for (int i = 0; i < col.Count; ++i)
            {
                _rows[i].Add(col[i]);
            }
            for (int i = col.Count; i < _rows.Count; ++i)
            {
                _rows[i].Add(null);
            }
        }

        /// <summary>
        /// Add a new column to the table, consisting of a range of cells.
        /// </summary>
        /// <param name="columnContents">The cells to add to the table.</param>
        public void AddColumn(IEnumerable<TableCell> columnContents)
        {
            TableColumn col = new TableColumn { Parent = this };
            col.AddRange(columnContents);
            AddColumn(col);
        }

        /// <summary>
        /// Add a new column to the table, consisting of a range of cells.
        /// </summary>
        /// <param name="columnContents">The cells to add to the table.</param>
        public void AddColumn(params TableCell[] columnContents)
        {
            AddColumn((IEnumerable<TableCell>)columnContents);
        }

        /// <summary>
        /// Draw this table at the given location on the graphics context.
        /// </summary>
        /// <param name="context">The graphics context to use to draw the table.</param>
        /// <param name="x">The X coordinate of the top left corner of the table.</param>
        /// <param name="y">The Y coordinate of the top left corner of the table.</param>
        public void DrawAt(IGraphicsContext context, double x, double y)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            double ruleOffset = RuleWidth / 2;
            double yOffset = ruleOffset;
            foreach (TableRow row in _rows)
            {
                double xOffset = ruleOffset;
                foreach (TableCell cell in row)
                {
                    cell.DrawContentsAt(context, x + xOffset + ruleOffset, y + yOffset + ruleOffset);
                    xOffset += cell.ComputedWidth + RuleWidth;
                }
                if (row.Count > 0)
                {
                    yOffset += row.ComputedHeight + RuleWidth;
                }
            }
            switch (RuleStyle)
            {
                case TableRuleStyle.LinesMeet:
                    DrawFullGrid(context, x, y);
                    break;
                case TableRuleStyle.SolidColumnsBrokenRows:
                    DrawSolidColumnGrid(context, x, y);
                    break;
                case TableRuleStyle.SolidRowsBrokenColumns:
                    DrawSolidRowGrid(context, x, y);
                    break;
                case TableRuleStyle.None:
                default:
                    break;
            }
        }

        private void DrawFullGrid(IGraphicsContext graphicsContext, double x, double y)
        {
            double lineWidthOffset = RuleWidth / 2;

            // Left border.
            graphicsContext.DrawLine(x + lineWidthOffset, y, x + lineWidthOffset, y + ComputedHeight, RuleWidth);

            // Right edges of columns.
            double xOffset = lineWidthOffset;
            foreach (TableColumn column in _columns)
            {
                xOffset += column.ComputedWidth + RuleWidth;
                graphicsContext.DrawLine(x + xOffset, y, x + xOffset, y + ComputedHeight, RuleWidth);
            }

            // Top border.
            graphicsContext.DrawLine(x, y + lineWidthOffset, x + ComputedWidth, y + lineWidthOffset, RuleWidth);

            // Bottom edges of rows.
            double yOffset = lineWidthOffset;
            foreach (TableRow row in _rows)
            {
                yOffset += row.ComputedHeight + RuleWidth;
                graphicsContext.DrawLine(x, y + yOffset, x + ComputedWidth, y + yOffset, RuleWidth);
            }
        }

        private void DrawSolidColumnGrid(IGraphicsContext graphicsContext, double x, double y)
        {
            double lineWidthOffset = RuleWidth / 2;

            // Left border.
            graphicsContext.DrawLine(x + lineWidthOffset, y, x + lineWidthOffset, y + ComputedHeight, RuleWidth);

            // Lines at right-hand edges of columns.
            double xOffset = lineWidthOffset;
            for (int i = 0; i < _columns.Count; ++i)
            {
                double rgs = RuleGapSize + RuleWidth;
                if (i == _columns.Count - 1)
                {
                    rgs = 0d;
                }
                xOffset += _columns[i].ComputedWidth + RuleWidth;
                graphicsContext.DrawLine(x + xOffset, y + rgs, x + xOffset, y + ComputedHeight - rgs, RuleWidth);
            }

            // Top border
            graphicsContext.DrawLine(x, y + lineWidthOffset, x + ComputedWidth, y + lineWidthOffset, RuleWidth);

            // Lines between rows
            double yOffset = lineWidthOffset;
            for (int i = 0; i < _rows.Count - 1; ++i)
            {
                yOffset += _rows[i].ComputedHeight + RuleWidth;
                xOffset = RuleWidth;
                foreach (TableColumn column in _columns)
                {
                    graphicsContext.DrawLine(x + xOffset + RuleGapSize, y + yOffset, x + xOffset + column.ComputedWidth - RuleGapSize, y + yOffset, RuleWidth);
                    xOffset += column.ComputedWidth + RuleWidth;
                }
            }

            // Bottom border
            graphicsContext.DrawLine(x, y + ComputedHeight - lineWidthOffset, x + ComputedWidth, y + ComputedHeight - lineWidthOffset, RuleWidth);
        }

        private void DrawSolidRowGrid(IGraphicsContext graphicsContext, double x, double y)
        {
            double lineWidthOffset = RuleWidth / 2;

            // Top border.
            graphicsContext.DrawLine(x, y + lineWidthOffset, x + ComputedWidth, y + lineWidthOffset, RuleWidth);

            // Lines underneath rows.
            double yOffset = lineWidthOffset;
            for (int i = 0; i < _rows.Count; ++i)
            {
                double rgs = RuleGapSize + RuleWidth;
                if (i == _rows.Count - 1)
                {
                    rgs = 0d;
                }
                yOffset += _rows[i].ComputedHeight + RuleWidth;
                graphicsContext.DrawLine(x + rgs, y + yOffset, x + ComputedWidth - rgs, y + yOffset, RuleWidth);
            }

            // Left border.
            graphicsContext.DrawLine(x + lineWidthOffset, y, x + lineWidthOffset, y + ComputedHeight, RuleWidth);

            // Lines between columns.
            double xOffset = lineWidthOffset;
            for (int i = 0; i < _columns.Count - 1; ++i)
            {
                xOffset += _columns[i].ComputedWidth + RuleWidth;
                yOffset = RuleWidth;
                foreach (TableRow row in _rows)
                {
                    graphicsContext.DrawLine(x + xOffset, y + yOffset + RuleGapSize, x + xOffset, y + yOffset + row.ComputedHeight - RuleGapSize, RuleWidth);
                    yOffset += row.ComputedHeight + RuleWidth;
                }
            }

            // Right border.
            graphicsContext.DrawLine(x + ComputedWidth - lineWidthOffset, y, x + ComputedWidth - lineWidthOffset, y + ComputedHeight, RuleWidth);
        }
    }
}
