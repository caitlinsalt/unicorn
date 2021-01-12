using System.Linq;

namespace Unicorn
{
    /// <summary>
    /// A <see cref="TableCellCollection"/> subclass containing a row of cells all with the same height.
    /// </summary>
    public class TableRow : TableCellCollection
    {
        /// <summary>
        /// Recompute the heights of all cells in the row.
        /// </summary>
        protected override void ComputeCellDimensions()
        {
            ComputeCellHeights();
        }

        /// <summary>
        /// The computed height of the row, equal to the largest computed height out of all cells in the row.
        /// </summary>
        public double ComputedHeight
        {
            get
            {
                return this.Max(c => c?.ComputedHeight ?? 0);
            }
        }

        /// <summary>
        /// The computed width of the row, equal to the sum of the computed widths of all cells in the row plus the grid lines between and either side of them.
        /// </summary>
        public double ComputedWidth
        {
            get
            {
                return this.Sum(c => c?.ComputedWidth ?? 0) + (Parent?.RuleWidth ?? 0) * (Count + 1);
            }
        }
    }
}
