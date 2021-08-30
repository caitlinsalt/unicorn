namespace Unicorn
{
    /// <summary>
    /// Whether or not "widows and orphans" (partial paragraphs containing a single line) should be allowed or prevented by text layout routines within the library,
    /// for example when splitting paragraphs across page boundaries.
    /// </summary>
    public enum WidowsAndOrphans
    {
        /// <summary>
        /// Prevent creation of widows or orphans.
        /// </summary>
        Prevent,

        /// <summary>
        /// Try to avoid creating widows or orphans.
        /// </summary>
        Avoid,

        /// <summary>
        /// Allow the creation of widows or orphans.
        /// </summary>
        Allow
    }
}
