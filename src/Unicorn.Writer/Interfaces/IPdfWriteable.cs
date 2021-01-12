using System.IO;

namespace Unicorn.Writer.Interfaces
{
    /// <summary>
    /// An interface representing any PDF data type which can be written to a <see cref="Stream" />, including both direct and indirect objects.
    /// </summary>
    public interface IPdfWriteable
    {
        /// <summary>
        /// Write the object to a <see cref="Stream" />.
        /// </summary>
        /// <param name="stream">The stream to write the object to.</param>
        /// <returns>The number of bytes written.</returns>
        int WriteTo(Stream stream);
    }
}
