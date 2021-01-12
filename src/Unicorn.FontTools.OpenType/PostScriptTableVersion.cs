namespace Unicorn.FontTools.OpenType
{
    /// <summary>
    /// The valid version numbers of a PostScript table.  The numerical values are the version number multiplied by 10.  In general Version 2 is the most likely
    /// to be seen in the wild, as it is the only non-deprecated format that supports the Euro.
    /// </summary>
    public enum PostScriptTableVersion
    {
        /// <summary>
        /// No valid version.
        /// </summary>
        None = 0,

        /// <summary>
        /// Version 1.
        /// </summary>
        One = 10,

        /// <summary>
        /// Version 2.
        /// </summary>
        Two = 20,

        /// <summary>
        /// Version 2.5.  Deprecated.
        /// </summary>
        TwoPointFive = 25,

        /// <summary>
        /// Version 3.  "Recommended against" by Apple.
        /// </summary>
        Three = 30,

        /// <summary>
        /// Version 4.  Only defined by Apple, who also specify that it "should be avoided".
        /// </summary>
        Four = 40,
    }
}
