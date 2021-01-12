namespace Unicorn
{
    /// <summary>
    /// Style to use when drawing table grid lines.
    /// </summary>
    public enum TableRuleStyle
    {
        /// <summary>
        /// No grid lines.
        /// </summary>
        None,

        /// <summary>
        /// &quot;Modern&quot; grid lines which meet at each intersection.
        /// </summary>
        LinesMeet,

        /// <summary>
        /// &quot;Vintage&quot; grid lines where the lines separating columns are solid, and the lines separating rows do not meet the column lines.
        /// </summary>
        SolidColumnsBrokenRows,

        /// <summary>
        /// &quot;Vintage&quot; grid lines where the lines separating rows are solid, and the lines separating columns do not meet the row lines.
        /// </summary>
        SolidRowsBrokenColumns,
    }
}
