using System;
using System.IO;

namespace Unicorn.FontTools.OpenType.Tests.Unit.Mocks
{
    internal class MockTable : Table
    {
        public MockTable(Tag tag) : base(tag)
        {
        }

        public MockTable(string tag) : base(tag)
        {
        }

        public override void Dump(TextWriter writer)
        {
            throw new NotImplementedException(TestResources.Mocks_MockTable_NotImplementedError);
        }
    }
}
