using System;
using System.IO;
using Unicorn.FontTools.OpenType;
using Unicorn.FontTools.OpenType.Tests.Unit;

namespace Unicorn.FontTools.Tests.Unit.TestHelpers.Mocks
{
    internal class MockTable : Table
    {
        public MockTable(Tag tag) : base(tag) { }

        public MockTable(string tag) : base(tag) { }

        public override void Dump(TextWriter writer) => throw new NotImplementedException(TestResources.Mocks_MockTable_NotImplementedError);
    }
}
