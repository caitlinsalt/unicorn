namespace Unicorn.FontTools.OpenType
{
    /// <summary>
    /// Whether the library should try to do metrics calculations more like the Windows operating system, or more like the Macintosh operating system. 
    /// This affects which font tables are used as the source of data for some purposes, for example such as measuring typographical ascent.
    /// </summary>
    public enum CalculationStyle
    {
        /// <summary>
        /// Prefer data from the "OS/2" metrics table.
        /// </summary>
        Windows,

        /// <summary>
        /// Prefer data from the "head" metrics table.
        /// </summary>
        Macintosh
    }
}
