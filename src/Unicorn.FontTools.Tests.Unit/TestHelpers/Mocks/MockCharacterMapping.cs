using System;
using Unicorn.FontTools.OpenType;
using Unicorn.FontTools.OpenType.Utility;
using Unicorn.FontTools.Tests.Unit.OpenType;

namespace Unicorn.FontTools.Tests.Unit.TestHelpers.Mocks
{
    internal class MockCharacterMapping : CharacterMapping
    {
        public int DumpCallCounts { get; private set; }

        public IDumpBlock LastOutputDumpBlock { get; private set; }

        public MockCharacterMapping(PlatformId platform, ushort encoding, ushort lang) : base(platform, encoding, lang) { }

        public override IDumpBlock Dump()
        {
            DumpCallCounts++;
            LastOutputDumpBlock = new DumpBlock("Mock character mapping", null, null, null);
            return LastOutputDumpBlock;
        }

        public override int MapCodePoint(byte codePoint) => throw new NotImplementedException(TestResources.Mocks_MockCharacterMapping_NotImplementedError);

        public override int MapCodePoint(int codePoint) => throw new NotImplementedException(TestResources.Mocks_MockCharacterMapping_NotImplementedError);

        public override int MapCodePoint(long codePoint) => throw new NotImplementedException(TestResources.Mocks_MockCharacterMapping_NotImplementedError);
    }
}
