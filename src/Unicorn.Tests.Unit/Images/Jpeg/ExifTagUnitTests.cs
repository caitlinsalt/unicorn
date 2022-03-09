using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Providers;
using Unicorn.Images.Jpeg;
using Unicorn.Tests.Unit.TestHelpers;

namespace Unicorn.Tests.Unit.Images.Jpeg
{
    [TestClass]
    public class ExifTagUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void ExifTagClass_Constructor_SetsValuePropertyToValueOfFirstParameter()
        {
            ExifTagId testParam1 = _rnd.NextExifTagId();
            object testParam0 = new();

            ExifTag testOutput = new(testParam0, testParam1);

            Assert.AreSame(testParam0, testOutput.Value);
        }

        [TestMethod]
        public void ExifTagClass_Constructor_SetsIdPropertyToValueOfSecondParameter()
        {
            ExifTagId testParam1 = _rnd.NextExifTagId();
            object testParam0 = new();

            ExifTag testOutput = new(testParam0, testParam1);

            Assert.AreEqual(testParam1, testOutput.Id);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
