using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;

namespace Tests.Utility.Mocks
{
    [ExcludeFromCodeCoverage]
    public class MockTextWriter : TextWriter
    {
        private List<string> _writtenText = new List<string>();

        public IEnumerable<string> WrittenText => _writtenText.ToArray();

        public override Encoding Encoding => Encoding.UTF8;

        public override void WriteLine(string value)
        {
            _writtenText.Add(value);
        }
    }
}
