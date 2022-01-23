using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Tests.Utility.Providers;
using Unicorn.Tests.Unit.TestHelpers;
using Unicorn.Tests.Unit.TestHelpers.Mocks;

namespace Unicorn.Tests.Unit
{
    [TestClass]
    public class AreaUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private Area _testObject;
        private List<MockPositionedFixedSizeDrawable> _mockContents;

#pragma warning disable CA5394 // Do not use insecure randomness

        [TestInitialize]
        public void SetUpTest()
        {
            int itemCount = _rnd.Next(1, 20);
            _mockContents = new List<MockPositionedFixedSizeDrawable>();
            for (int i = 0; i < itemCount; i++)
            {
                _mockContents.Add(_rnd.NextMockPositionedFixedSizeDrawable());
            }
            _testObject = new Area(_mockContents);
        }

#pragma warning restore CA5394 // Do not use insecure randomness

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void AreaClass_ContentHeightProperty_EqualsLowestPointOfAnyContentItem()
        {
            double expectedResult = _mockContents.Select(d => d.Y + d.Height).Max();

            double actualResult = _testObject.ContentHeight;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void AreaClass_ContentHeightProperty_EqualsZero_IfAreaHasNoContent()
        {
            Area teatObject = new Area();
            double expectedResult = 0;

            double actualResult = teatObject.ContentHeight;

            Assert.AreEqual(expectedResult, actualResult);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
