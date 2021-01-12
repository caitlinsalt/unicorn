using System.Linq;

namespace Unicorn
{
    /// <summary>
    /// A <see cref="TableCellCollection"/> subclass containing a column of cells all with the same width.
    /// </summary>
    public class TableColumn : TableCellCollection
    {
        /// <summary>
        /// Recompute the widths of each cell in the column.
        /// </summary>
        protected override void ComputeCellDimensions()
        {
            ComputeCellWidths();
        }

        /// <summary>
        /// The computed height of the column, consisting of the sum of all computed heights of all cells in the column plus any grid lines between and at either side of them.
        /// </summary>
        public double ComputedHeight
        {
            get
            {
                return this.Sum(c => c?.ComputedHeight ?? 0) + (Parent?.RuleWidth ?? 0) * (Count + 1);
            }
        }

        /// <summary>
        /// The computed width of the column, consisting of the largest computed width of all cells in the column.
        /// </summary>
        public double ComputedWidth
        {
            get
            {
                return this.Max(c => c?.ComputedWidth ?? 0);
            }
        }
    }
}
