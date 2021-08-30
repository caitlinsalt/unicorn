using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Providers;

namespace Unicorn.Tests.Unit
{
    [TestClass]
    public class MarginSetUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private MarginSet _testObject;

#pragma warning disable CA5394 // Do not use insecure randomness

        [TestInitialize]
        public void SetUpTest() => _testObject = new(_rnd.NextDouble() * 1000, _rnd.NextDouble() * 1000, _rnd.NextDouble() * 1000, _rnd.NextDouble() * 1000);

#pragma warning restore CA5394 // Do not use insecure randomness

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void MarginSetClass_ConstructorWithNoParameters_SetsTopPropertyToZero()
        {
            MarginSet testOutput = new();

            Assert.AreEqual(0d, testOutput.Top);
        }

        [TestMethod]
        public void MarginSetClass_ConstructorWithNoParameters_SetsRightPropertyToZero()
        {
            MarginSet testOutput = new();

            Assert.AreEqual(0d, testOutput.Right);
        }

        [TestMethod]
        public void MarginSetClass_ConstructorWithNoParameters_SetsBottomPropertyToZero()
        {
            MarginSet testOutput = new();

            Assert.AreEqual(0d, testOutput.Bottom);
        }

        [TestMethod]
        public void MarginSetClass_ConstructorWithNoParameters_SetsLeftPropertyToZero()
        {
            MarginSet testOutput = new();

            Assert.AreEqual(0d, testOutput.Left);
        }

#pragma warning disable CA5394 // Do not use insecure randomness

        [TestMethod]
        public void MarginSetClass_ConstructorWithFourParameters_SetsTopPropertyToValueOfFirstParameter()
        {
            double testParam0 = _rnd.NextDouble() * 1000;
            double testParam1 = _rnd.NextDouble() * 1000;
            double testParam2 = _rnd.NextDouble() * 1000;
            double testParam3 = _rnd.NextDouble() * 1000;

            MarginSet testOutput = new(testParam0, testParam1, testParam2, testParam3);

            Assert.AreEqual(testParam0, testOutput.Top);
        }

        [TestMethod]
        public void MarginSetClass_ConstructorWithFourParameters_SetsRightPropertyToValueOfSecondParameter()
        {
            double testParam0 = _rnd.NextDouble() * 1000;
            double testParam1 = _rnd.NextDouble() * 1000;
            double testParam2 = _rnd.NextDouble() * 1000;
            double testParam3 = _rnd.NextDouble() * 1000;

            MarginSet testOutput = new(testParam0, testParam1, testParam2, testParam3);

            Assert.AreEqual(testParam1, testOutput.Right);
        }

        [TestMethod]
        public void MarginSetClass_ConstructorWithFourParameters_SetsBottomPropertyToValueOfThirdParameter()
        {
            double testParam0 = _rnd.NextDouble() * 1000;
            double testParam1 = _rnd.NextDouble() * 1000;
            double testParam2 = _rnd.NextDouble() * 1000;
            double testParam3 = _rnd.NextDouble() * 1000;

            MarginSet testOutput = new(testParam0, testParam1, testParam2, testParam3);

            Assert.AreEqual(testParam2, testOutput.Bottom);
        }

        [TestMethod]
        public void MarginSetClass_ConstructorWithFourParameters_SetsLeftPropertyToValueOfFourthParameter()
        {
            double testParam0 = _rnd.NextDouble() * 1000;
            double testParam1 = _rnd.NextDouble() * 1000;
            double testParam2 = _rnd.NextDouble() * 1000;
            double testParam3 = _rnd.NextDouble() * 1000;

            MarginSet testOutput = new(testParam0, testParam1, testParam2, testParam3);

            Assert.AreEqual(testParam3, testOutput.Left);
        }

        [TestMethod]
        public void MarginSetClass_ConstructorWithOneParameter_SetsTopPropertyToValueOfParameter()
        {
            double testParam = _rnd.NextDouble() * 1000;

            MarginSet testOutput = new(testParam);

            Assert.AreEqual(testParam, testOutput.Top);
        }

        [TestMethod]
        public void MarginSetClass_ConstructorWithOneParameter_SetsRightPropertyToValueOfParameter()
        {
            double testParam = _rnd.NextDouble() * 1000;

            MarginSet testOutput = new(testParam);

            Assert.AreEqual(testParam, testOutput.Right);
        }

        [TestMethod]
        public void MarginSetClass_ConstructorWithOneParameter_SetsBottomPropertyToValueOfParameter()
        {
            double testParam = _rnd.NextDouble() * 1000;

            MarginSet testOutput = new(testParam);

            Assert.AreEqual(testParam, testOutput.Bottom);
        }

        [TestMethod]
        public void MarginSetClass_ConstructorWithOneParameter_SetsLeftPropertyToValueOfParameter()
        {
            double testParam = _rnd.NextDouble() * 1000;

            MarginSet testOutput = new(testParam);

            Assert.AreEqual(testParam, testOutput.Left);
        }

        [TestMethod]
        public void MarginSetClass_CloneMethod_ReturnsObjectWithTopPropertyEqualToThis()
        {
            MarginSet testOutput = _testObject.Clone();

            Assert.AreEqual(_testObject.Top, testOutput.Top);
        }

        [TestMethod]
        public void MarginSetClass_CloneMethod_ReturnsObjectWithRightPropertyEqualToThis()
        {
            MarginSet testOutput = _testObject.Clone();

            Assert.AreEqual(_testObject.Right, testOutput.Right);
        }

        [TestMethod]
        public void MarginSetClass_CloneMethod_ReturnsObjectWithBottomPropertyEqualToThis()
        {
            MarginSet testOutput = _testObject.Clone();

            Assert.AreEqual(_testObject.Bottom, testOutput.Bottom);
        }

        [TestMethod]
        public void MarginSetClass_CloneMethod_ReturnsObjectWithLeftPropertyEqualToThis()
        {
            MarginSet testOutput = _testObject.Clone();

            Assert.AreEqual(_testObject.Left, testOutput.Left);
        }



#pragma warning restore CA5394 // Do not use insecure randomness

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
