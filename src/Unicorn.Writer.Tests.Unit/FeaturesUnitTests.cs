using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unicorn.Writer.Tests.Unit
{
    [TestClass]
    public class FeaturesUnitTests
    {

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void FeaturesClass_SelectedStreamFeaturesProperty_DefaultValueHasAsciiEncodeBinaryStreamsFlagSet()
        {
            Assert.IsTrue(Features.SelectedStreamFeatures.HasFlag(Features.StreamFeatures.AsciiEncodeBinaryStreams));
        }

        [TestMethod]
        public void FeaturesClass_SelectedStreamFeaturesProperty_DefaultValueHasCompressBinaryStreamsFlagSet()
        {
            Assert.IsTrue(Features.SelectedStreamFeatures.HasFlag(Features.StreamFeatures.CompressBinaryStreams));
        }

        [TestMethod]
        public void FeaturesClass_SelectedStreamFeaturesProperty_DefaultValueHasCompressPageContentStreamsFlagSet()
        {
            Assert.IsTrue(Features.SelectedStreamFeatures.HasFlag(Features.StreamFeatures.CompressPageContentStreams));
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
