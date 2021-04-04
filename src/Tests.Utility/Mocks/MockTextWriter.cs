using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;

namespace Tests.Utility.Mocks
{
    /// <summary>
    /// A mock <see cref="TextWriter" /> implementation that stores the text written to it in memory, so that it can be checked later.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class MockTextWriter : TextWriter
    {
        private readonly List<string> _writtenText = new List<string>();

        /// <summary>
        /// The text that has been written to this object since it was created, as a sequence of lines.
        /// </summary>
        public IEnumerable<string> WrittenText => _writtenText.ToArray();

        /// <summary>
        /// The encoding this writer purports to use (in reality, it does no form of writing or encoding).
        /// </summary>
        public override Encoding Encoding => Encoding.UTF8;

        /// <summary>
        /// Store a line of text in the <see cref="WrittenText" /> property.
        /// </summary>
        /// <param name="value">The line of text to "write".</param>
        public override void WriteLine(string value)
        {
            _writtenText.Add(value);
        }
    }
}
