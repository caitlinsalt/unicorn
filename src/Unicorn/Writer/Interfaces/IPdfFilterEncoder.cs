using System.Collections.Generic;
using Unicorn.Writer.Primitives;

namespace Unicorn.Writer.Interfaces
{
    /// <summary>
    /// An interface representing a PDF stream filter encoder.
    /// </summary>
    public interface IPdfFilterEncoder
    {
        /// <summary>
        /// The name of this filter.
        /// </summary>
        PdfName FilterName { get; }

        /// <summary>
        /// Encode a stream of data using this filter.
        /// </summary>
        /// <param name="data">The data to be encoded.</param>
        /// <returns>The encoded stream of data.</returns>
        IEnumerable<byte> Encode(IEnumerable<byte> data);
    }
}
