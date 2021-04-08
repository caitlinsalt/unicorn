using System;
using Unicorn.FontTools.OpenType;
using Unicorn.FontTools.OpenType.Utility;
using Unicorn.FontTools.Tests.Unit.OpenType;

namespace Unicorn.FontTools.Tests.Unit.TestHelpers.Mocks
{
    internal class MockCharacterMapping : CharacterMapping
    {
        public MockCharacterMapping(PlatformId platform, ushort encoding, ushort lang) : base(platform, encoding, lang) { }

        public override DumpBlock Dump() => new("Mock character mapping", null, null, null);

        public override int MapCodePoint(byte codePoint) => throw new NotImplementedException(TestResources.Mocks_MockCharacterMapping_NotImplementedError);

        public override int MapCodePoint(int codePoint) => throw new NotImplementedException(TestResources.Mocks_MockCharacterMapping_NotImplementedError);

        public override int MapCodePoint(long codePoint) => throw new NotImplementedException(TestResources.Mocks_MockCharacterMapping_NotImplementedError);
    }
}
