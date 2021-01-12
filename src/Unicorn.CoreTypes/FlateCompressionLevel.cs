namespace Unicorn.CoreTypes
{
    /// <summary>
    /// The compression level to use when using the Flate algorithm with a PDF stream compression filter.
    /// </summary>
    public enum FlateCompressionLevel
    {
        /// <summary>
        /// Do not compress.
        /// </summary>
        None,

        /// <summary>
        /// Tune the algorithm for the fastest compression.
        /// </summary>
        Fastest,

        /// <summary>
        /// Tune the algorithm to balance speed and compression size.
        /// </summary>
        Default,

        /// <summary>
        /// Tune the algorithm to try to produce the best compression ratio.
        /// </summary>
        Best
    }
}
