using Unicorn.FontTools.OpenType;
using Unicorn.FontTools.OpenType.Utility;

namespace Unicorn.FontTools.Tests.Unit.TestHelpers.Mocks
{
    internal class MockTable : Table
    {
        public MockTable(Tag tag) : base(tag) { }

        public MockTable(string tag) : base(tag) { }

        public override DumpBlock Dump() => new("Mock table", null, null, null);
    }
}
