﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.FontTools.OpenType;
using Unicorn.FontTools.Tests.Unit.TestHelpers.Mocks;
using Unicorn.FontTools.Tests.Utility;

namespace Unicorn.FontTools.Tests.Unit.OpenType
{
    [TestClass]
    public class CharacterMappingUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void CharacterMappingClass_Constructor_SetsPlatformPropertyToValueOfFirstParameter()
        {
            PlatformId testParam0 = _rnd.NextPlatformId();
            ushort testParam1 = _rnd.NextUShort();
            ushort testParam2 = _rnd.NextUShort();

            MockCharacterMapping testOutput = new(testParam0, testParam1, testParam2);

            Assert.AreEqual(testParam0, testOutput.Platform);
        }

        [TestMethod]
        public void CharacterMappingClass_Constructor_SetsEncodingPropertyToValueOfSecondParameter()
        {
            PlatformId testParam0 = _rnd.NextPlatformId();
            ushort testParam1 = _rnd.NextUShort();
            ushort testParam2 = _rnd.NextUShort();

            MockCharacterMapping testOutput = new(testParam0, testParam1, testParam2);

            Assert.AreEqual(testParam1, testOutput.Encoding);
        }

        [TestMethod]
        public void CharacterMappingClass_Constructor_SetsLanguagePropertyToValueOfThirdParameter()
        {
            PlatformId testParam0 = _rnd.NextPlatformId();
            ushort testParam1 = _rnd.NextUShort();
            ushort testParam2 = _rnd.NextUShort();

            MockCharacterMapping testOutput = new(testParam0, testParam1, testParam2);

            Assert.AreEqual(testParam2, testOutput.Language);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
