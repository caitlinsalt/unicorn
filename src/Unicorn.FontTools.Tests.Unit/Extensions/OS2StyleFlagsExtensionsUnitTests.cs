using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.FontTools.OpenType;
using Unicorn.FontTools.Extensions;
using Unicorn.FontTools.Tests.Utility;

namespace Unicorn.FontTools.Tests.Unit.Extensions
{
    [TestClass]
    public class OS2StyleFlagsExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void OS2StyleFlagsExtensionsClass_ToFontDescriptorFlagsMethod_ReturnsValueWithSymbolicBitSet_IfSecondParameterIsTrue()
        {
            OS2StyleProperties testParam0 = _rnd.NextOpenTypeOS2StyleFlags();
            bool testParam1 = true;
            bool testParam2 = _rnd.NextBoolean();

            Base.FontProperties testOutput = testParam0.ToFontDescriptorFlags(testParam1, testParam2);

            Assert.IsTrue(testOutput.HasFlag(Base.FontProperties.Symbolic));
        }

        [TestMethod]
        public void OS2StyleFlagsExtensionsClass_ToFontDescriptorFlagsMethod_ReturnsValueWithNonsymbolicBitNotSet_IfSecondParameterIsTrue()
        {
            OS2StyleProperties testParam0 = _rnd.NextOpenTypeOS2StyleFlags();
            bool testParam1 = true;
            bool testParam2 = _rnd.NextBoolean();

            Base.FontProperties testOutput = testParam0.ToFontDescriptorFlags(testParam1, testParam2);

            Assert.IsFalse(testOutput.HasFlag(Base.FontProperties.Nonsymbolic));
        }

        [TestMethod]
        public void OS2StyleFlagsExtensionsClass_ToFontDescriptorFlagsMethod_ReturnsValueWithNonsymbolicBitSet_IfSecondParameterIsFalse()
        {
            OS2StyleProperties testParam0 = _rnd.NextOpenTypeOS2StyleFlags();
            bool testParam1 = false;
            bool testParam2 = _rnd.NextBoolean();

            Base.FontProperties testOutput = testParam0.ToFontDescriptorFlags(testParam1, testParam2);

            Assert.IsTrue(testOutput.HasFlag(Base.FontProperties.Nonsymbolic));
        }

        [TestMethod]
        public void OS2StyleFlagsExtensionsClass_ToFontDescriptorFlagsMethod_ReturnsValueWithSymbolicBitNotSet_IfSecondParameterIsFalse()
        {
            OS2StyleProperties testParam0 = _rnd.NextOpenTypeOS2StyleFlags();
            bool testParam1 = false;
            bool testParam2 = _rnd.NextBoolean();

            Base.FontProperties testOutput = testParam0.ToFontDescriptorFlags(testParam1, testParam2);

            Assert.IsFalse(testOutput.HasFlag(Base.FontProperties.Symbolic));
        }

        [TestMethod]
        public void OS2StyleFlagsExtensionsClass_ToFontDescriptorFlagsMethod_ReturnsValueWithFixedPitchFlagSet_IfThirdParameterIsTrue()
        {
            OS2StyleProperties testParam0 = _rnd.NextOpenTypeOS2StyleFlags();
            bool testParam1 = _rnd.NextBoolean();
            bool testParam2 = true;

            Base.FontProperties testOutput = testParam0.ToFontDescriptorFlags(testParam1, testParam2);

            Assert.IsTrue(testOutput.HasFlag(Base.FontProperties.FixedPitch));
        }

        [TestMethod]
        public void OS2StyleFlagsExtensionsClass_ToFontDescriptorFlagsMethod_ReturnsValueWithFixedPitchFlagNotSet_IfThirdParameterIsFalse()
        {
            OS2StyleProperties testParam0 = _rnd.NextOpenTypeOS2StyleFlags();
            bool testParam1 = _rnd.NextBoolean();
            bool testParam2 = false;

            Base.FontProperties testOutput = testParam0.ToFontDescriptorFlags(testParam1, testParam2);

            Assert.IsFalse(testOutput.HasFlag(Base.FontProperties.FixedPitch));
        }

        [TestMethod]
        public void OS2StyleFlagsExtensionsClass_ToFontDescriptorFlagsMethod_ReturnsValueWithItalicFlagSet_IfFirstParameterHasItalicFlagSetAndObliqueFlagNotSet()
        {
            OS2StyleProperties testParam0 = _rnd.NextOpenTypeOS2StyleFlags();
            testParam0 |= OS2StyleProperties.Italic;
            testParam0 &= ~OS2StyleProperties.Oblique;
            bool testParam1 = _rnd.NextBoolean();
            bool testParam2 = _rnd.NextBoolean(); ;

            Base.FontProperties testOutput = testParam0.ToFontDescriptorFlags(testParam1, testParam2);

            Assert.IsTrue(testOutput.HasFlag(Base.FontProperties.Italic));
        }

        [TestMethod]
        public void OS2StyleFlagsExtensionsClass_ToFontDescriptorFlagsMethod_ReturnsValueWithItalicFlagSet_IfFirstParameterHasItalicFlagNotSetAndObliqueFlagSet()
        {
            OS2StyleProperties testParam0 = _rnd.NextOpenTypeOS2StyleFlags();
            testParam0 &= ~OS2StyleProperties.Italic;
            testParam0 |= OS2StyleProperties.Oblique;
            bool testParam1 = _rnd.NextBoolean();
            bool testParam2 = _rnd.NextBoolean(); ;

            Base.FontProperties testOutput = testParam0.ToFontDescriptorFlags(testParam1, testParam2);

            Assert.IsTrue(testOutput.HasFlag(Base.FontProperties.Italic));
        }

        [TestMethod]
        public void OS2StyleFlagsExtensionsClass_ToFontDescriptorFlagsMethod_ReturnsValueWithItalicFlagSet_IfFirstParameterHasItalicFlagSetAndObliqueFlagSet()
        {
            OS2StyleProperties testParam0 = _rnd.NextOpenTypeOS2StyleFlags();
            testParam0 |= OS2StyleProperties.Italic;
            testParam0 |= OS2StyleProperties.Oblique;
            bool testParam1 = _rnd.NextBoolean();
            bool testParam2 = _rnd.NextBoolean(); ;

            Base.FontProperties testOutput = testParam0.ToFontDescriptorFlags(testParam1, testParam2);

            Assert.IsTrue(testOutput.HasFlag(Base.FontProperties.Italic));
        }

        [TestMethod]
        public void OS2StyleFlagsExtensionsClass_ToFontDescriptorFlagsMethod_ReturnsValueWithItalicFlagNotSet_IfFirstParameterHasItalicFlagNotSetAndObliqueFlagNotSet()
        {
            OS2StyleProperties testParam0 = _rnd.NextOpenTypeOS2StyleFlags();
            testParam0 &= ~OS2StyleProperties.Italic;
            testParam0 &= ~OS2StyleProperties.Oblique;
            bool testParam1 = _rnd.NextBoolean();
            bool testParam2 = _rnd.NextBoolean(); ;

            Base.FontProperties testOutput = testParam0.ToFontDescriptorFlags(testParam1, testParam2);

            Assert.IsFalse(testOutput.HasFlag(Base.FontProperties.Italic));
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
