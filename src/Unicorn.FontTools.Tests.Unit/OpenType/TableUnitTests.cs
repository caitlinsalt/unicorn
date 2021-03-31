﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Providers;
using Unicorn.FontTools.Tests.Unit.TestHelpers.Mocks;
using Unicorn.FontTools.Tests.Utility;

namespace Unicorn.FontTools.OpenType.Tests.Unit
{
    [TestClass]
    public class TableUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void TableClass_ConstructorWithTagParameter_SetsTableTagPropertyToValueOfParameter()
        {
            Tag testParam = _rnd.NextTag();

            MockTable testOutput = new(testParam);

            Assert.AreEqual(testParam, testOutput.TableTag);
        }

        [TestMethod]
        public void TableClass_ConstructorWithStringParameter_SetsTableTagPropertyToTagWithValueOfParameter()
        {
            Tag expectedValue = _rnd.NextTag();
            string testParam = expectedValue.Value;

            MockTable testOutput = new(testParam);

            Assert.AreEqual(expectedValue, testOutput.TableTag);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
