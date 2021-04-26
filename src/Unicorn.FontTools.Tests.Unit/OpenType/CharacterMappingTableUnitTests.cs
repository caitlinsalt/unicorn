using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.FontTools.OpenType;
using Unicorn.FontTools.Tests.Unit.TestHelpers.Mocks;
using Unicorn.FontTools.Tests.Utility;

namespace Unicorn.FontTools.Tests.Unit.OpenType
{
    [TestClass]
    public class CharacterMappingTableUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness

        private static MockCharacterMapping[] GetMockSubtables(int minCount = 0)
        {
            int count = _rnd.Next(minCount, 10);
            MockCharacterMapping[] output = new MockCharacterMapping[count];
            for (int i = 0; i < count; ++i)
            {
                ushort nextEncoding;
                do
                {
                    nextEncoding = _rnd.NextUShort();
                } while (output.Any(o => o?.Encoding == nextEncoding));
                output[i] = new MockCharacterMapping(_rnd.NextPlatformId(), nextEncoding, _rnd.NextUShort());
            }
            return output;
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void CharacterMappingTableClass_Constructor_SetsTableTagPropertyToCorrectValue()
        {
            IEnumerable<CharacterMapping> testParam0 = GetMockSubtables();

            CharacterMappingTable testOutput = new(testParam0);

            Assert.AreEqual("cmap", testOutput.TableTag.Value);
        }

        [TestMethod]
        public void CharacterMappingTableClass_Constructor_SetsMappingsPropertyToSameSizeAsNumberOfElementsInParameter()
        {
            MockCharacterMapping[] testParam0 = GetMockSubtables();

            CharacterMappingTable testOutput = new(testParam0);

            Assert.AreEqual(testParam0.Length, testOutput.Mappings.Count);
        }

        [TestMethod]
        public void CharacterMappingTableClass_Constructor_SetsMappingsPropertyToCorrectContent()
        {
            MockCharacterMapping[] testParam0 = GetMockSubtables();

            CharacterMappingTable testOutput = new(testParam0);

            for (int i = 0; i < testParam0.Length; ++i)
            {
                Assert.AreSame(testParam0[i], testOutput.Mappings[i]);
            }
        }

        [TestMethod]
        public void CharacterMappingTableClass_SelectExactMappingMethod_ReturnsNull_IfNoMappingWithCorrectPlatformIdExists()
        {
            MockCharacterMapping[] constrParam0 = GetMockSubtables(1);
            MockCharacterMapping targetedMapping = constrParam0[_rnd.Next(constrParam0.Length)];
            PlatformId testParam0;
            do
            {
                testParam0 = _rnd.NextPlatformId();
            } while (testParam0 == targetedMapping.Platform);
            int testParam1 = targetedMapping.Encoding;
            CharacterMappingTable testObject = new(constrParam0);

            CharacterMapping testOutput = testObject.SelectExactMapping(testParam0, testParam1);

            Assert.IsNull(testOutput);
        }

        [TestMethod]
        public void CharacterMappingTableClass_SelectExactMappingMethod_ReturnsNull_IfNoMappingWithCorrectEncodingExists()
        {
            MockCharacterMapping[] constrParam0 = GetMockSubtables(1);
            PlatformId[] knownIds = constrParam0.Select(m => m.Platform).Distinct().ToArray();
            PlatformId testParam0 = knownIds[_rnd.Next(knownIds.Length)];
            int testParam1;
            do
            {
                testParam1 = _rnd.NextUShort();
            } while (constrParam0.Any(m => m.Encoding == testParam1));
            CharacterMappingTable testObject = new(constrParam0);

            CharacterMapping testOutput = testObject.SelectExactMapping(testParam0, testParam1);

            Assert.IsNull(testOutput);
        }

        [TestMethod]
        public void CharacterMappingTableClass_SelectExactMappingMethod_ReturnsCorrectMapping_IfMappingWithCorrectPlatformAndEncodingExists()
        {
            MockCharacterMapping[] constrParam0 = GetMockSubtables(1);
            CharacterMapping expectedResult = constrParam0[_rnd.Next(constrParam0.Length)];
            CharacterMappingTable testObject = new(constrParam0);
            PlatformId testParam0 = expectedResult.Platform;
            int testParam1 = expectedResult.Encoding;

            CharacterMapping testOutput = testObject.SelectExactMapping(testParam0, testParam1);

            Assert.AreSame(expectedResult, testOutput);
        }

        [TestMethod]
        public void CharacterMappingTableClass_SelectExactMappingMethod_ReturnsFirstMatchingMapping_IfMultipleMappingsWithCorrectPlatformAndEncodingExist()
        {
            List<MockCharacterMapping> constrParam0 = GetMockSubtables(1).ToList();
            int targetIdx = _rnd.Next(constrParam0.Count);
            PlatformId testParam0 = constrParam0[targetIdx].Platform;
            int testParam1 = constrParam0[targetIdx].Encoding;
            MockCharacterMapping duplicateMatch = new(testParam0, (ushort)testParam1, _rnd.NextUShort());
            if (targetIdx == constrParam0.Count - 1)
            {
                constrParam0.Add(duplicateMatch);
            }
            else
            {
                constrParam0.Insert(_rnd.Next(targetIdx + 1, constrParam0.Count - 1), duplicateMatch);
            }
            CharacterMappingTable testObject = new(constrParam0);

            CharacterMapping testOutput = testObject.SelectExactMapping(testParam0, testParam1);

            Assert.AreSame(constrParam0[targetIdx], testOutput);
        }

        [TestMethod]
        public void CharacterMappingTableClass_DumpMethod_ReturnsNonNullObject()
        {
            IEnumerable<CharacterMapping> constrParam0 = GetMockSubtables();
            CharacterMappingTable testObject = new(constrParam0);

            var testOutput = testObject.Dump();

            Assert.IsNotNull(testOutput);
        }

        [TestMethod]
        public void CharacterMappingTableClass_DumpMethod_ReturnsObjectWithInfoPropertyContainingNameOfTableType()
        {
            IEnumerable<CharacterMapping> constrParam0 = GetMockSubtables();
            CharacterMappingTable testObject = new(constrParam0);

            var testOutput = testObject.Dump();

            Assert.IsTrue(testOutput.Info.Contains("cmap", StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void CharacterMappingTableClass_DumpMethod_ReturnsObjectWithInfoPropertyContainingNumberOfMappings()
        {
            IEnumerable<CharacterMapping> constrParam0 = GetMockSubtables();
            CharacterMappingTable testObject = new(constrParam0);

            var testOutput = testObject.Dump();

            Assert.IsTrue(testOutput.Info.Contains(testObject.Mappings.Count.ToString(CultureInfo.InvariantCulture), StringComparison.InvariantCulture));
        }

        [TestMethod]
        public void CharacterMappingTableClass_DumpMethod_CallsDumpMethodOfEachMapping()
        {
            IEnumerable<CharacterMapping> constrParam0 = GetMockSubtables();
            CharacterMappingTable testObject = new(constrParam0);

            _ = testObject.Dump();

            foreach (var mapping in testObject.Mappings)
            {
                Assert.IsTrue(mapping is MockCharacterMapping mockMapping && mockMapping.DumpCallCounts == 1);
            }
        }

        [TestMethod]
        public void CharacterMappingTableClass_DumpMethod_ReturnsObjectWithNoBlockData()
        {
            IEnumerable<CharacterMapping> constrParam0 = GetMockSubtables();
            CharacterMappingTable testObject = new(constrParam0);

            var testOutput = testObject.Dump();

            Assert.AreEqual(0, testOutput.BlockData.Count);
        }

        [TestMethod]
        public void CharacterMappingTableClass_DumpMethod_ReturnsObjectWithNestedBlocksPropertyContainingObjectsReturnedByDumpMethodsOfEachMappingInCorrectOrder()
        {
            IEnumerable<CharacterMapping> constrParam0 = GetMockSubtables();
            CharacterMappingTable testObject = new(constrParam0);

            var testOutput = testObject.Dump();

            var nestedBlocks = testOutput.NestedData.ToList();
            Assert.AreEqual(testObject.Mappings.Count, nestedBlocks.Count);
            for (int i = 0; i < nestedBlocks.Count; ++i)
            {
                var mockMapping = testObject.Mappings[i] as MockCharacterMapping;
                Assert.AreSame(mockMapping.LastOutputDumpBlock, nestedBlocks[i]);
            }
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
