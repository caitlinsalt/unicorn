using ICSharpCode.SharpZipLib.Zip.Compression;
using Unicorn.CoreTypes;

namespace Unicorn.Writer.Extensions
{
    /// <summary>
    /// Extension methods for the <see cref="FlateCompressionLevel" /> type.
    /// </summary>
    public static class FlateCompressionLevelExtensions
    {
        /// <summary>
        /// Convert a <see cref="FlateCompressionLevel" /> value to one of the integer values used by the SharpZipLibrary.  The SharpZipLib library does define an
        /// enum for this, but its API expects an integer rather than an enum.
        /// </summary>
        /// <param name="level">The value to convert.</param>
        /// <returns>An integer representing a SharpZipLib compression level.</returns>
        public static int ToSharpZipLibInt(this FlateCompressionLevel level)
        {
            switch (level)
            {
                case FlateCompressionLevel.None:
                    return (int)Deflater.CompressionLevel.NO_COMPRESSION;
                case FlateCompressionLevel.Fastest:
                    return (int)Deflater.CompressionLevel.BEST_SPEED;
                case FlateCompressionLevel.Default:
                default:
                    return (int)Deflater.CompressionLevel.DEFLATED;
                case FlateCompressionLevel.Best:
                    return (int)Deflater.CompressionLevel.BEST_COMPRESSION;
            }
        }
    }
}
