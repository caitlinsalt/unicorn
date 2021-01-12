namespace Unicorn.CoreTypes
{
    /// <summary>
    /// Dash style for drawing lines.  Currently has the same values as System.Drawing.Drawing2D.DashStyle, with the exception that DashStyle.Custom is omitted as being unimplemented.
    /// </summary>
    public enum UniDashStyle
    {
        /// <summary>
        /// Solid line.
        /// </summary>
        Solid = 0,

        /// <summary>
        /// Dashed line.
        /// </summary>
        Dash = 1,

        /// <summary>
        /// Dotted line.
        /// </summary>
        Dot = 2,

        /// <summary>
        /// Line with a repeating dash-dot pattern.
        /// </summary>
        DashDot = 3,

        /// <summary>
        /// Line with a repeating dash-dot-dot pattern.
        /// </summary>
        DashDotDot = 4,
    }
}
