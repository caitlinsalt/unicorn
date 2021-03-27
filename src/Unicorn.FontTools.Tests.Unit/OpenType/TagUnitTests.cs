using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;

namespace Unicorn.FontTools.OpenType.Tests.Unit
{
    [TestClass]
    public class TagUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void TagStruct_ParameterlessConstructor_CreatesValueWithValuePropertyNull()
        {
            Tag testOutput = new Tag();

            Assert.IsNull(testOutput.Value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TagStruct_ConstructorWithArrayOfByteParameter_ThrowsArgumentNullException_IfParameterIsNull()
        {
            byte[] testParam = null;

            _ = new Tag(testParam);

            Assert.Fail();
        }

#pragma warning disable CA5394 // Do not use insecure randomness

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TagStruct_ConstructorWithArrayOfByteParameter_ThrowsArgumentException_IfParameterIsTooShort()
        {
            string testData = _rnd.NextString(_rnd.Next(3));
            byte[] testParam = Encoding.ASCII.GetBytes(testData);

            _ = new Tag(testParam);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TagStruct_ConstructorWithArrayOfByteParameter_ThrowsArgumentException_IfParameterIsTooLong()
        {
            string testData = _rnd.NextString(_rnd.Next(5, 20));
            byte[] testParam = Encoding.ASCII.GetBytes(testData);

            _ = new Tag(testParam);

            Assert.Fail();
        }

#pragma warning restore CA5394 // Do not use insecure randomness

        [TestMethod]
        public void TagStruct_ConstructorWithArrayOfByteParameter_ReturnsValueWithCorrectValueProperty_IfParameterIsCorrectLength()
        {
            string testData = _rnd.NextString(4);
            byte[] testParam = Encoding.ASCII.GetBytes(testData);

            Tag testOutput = new Tag(testParam);

            Assert.AreEqual(testData, testOutput.Value);
        }

        [TestMethod]
        public void TagStruct_EqualsMethodWithTagParameter_ReturnsTrue_IfParameterIsThis()
        {
            string testData = _rnd.NextString(4);
            byte[] constrParam = Encoding.ASCII.GetBytes(testData);
            Tag testObject = new Tag(constrParam);

            bool testOutput = testObject.Equals(testObject);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void TagStruct_EqualsMethodWithTagParameter_ReturnsTrue_IfParameterIsConstructedFromSameData()
        {
            string testData = _rnd.NextString(4);
            byte[] constrParam = Encoding.ASCII.GetBytes(testData);
            Tag testObject = new Tag(constrParam);
            Tag testParam = new Tag(constrParam);

            bool testOutput = testObject.Equals(testParam);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void TagStruct_EqualsMethodWithTagParameter_ReturnsFalse_IfParameterIsConstructedFromDifferentData()
        {
            string testData0 = _rnd.NextString(4);
            string testData1;
            do
            {
                testData1 = _rnd.NextString(4);
            } while (testData1 == testData0);
            Tag testObject = new Tag(Encoding.ASCII.GetBytes(testData0));
            Tag testParam = new Tag(Encoding.ASCII.GetBytes(testData1));

            bool testOutput = testObject.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TagStruct_EqualsMethodWithObjectParameter_ReturnsTrue_IfParameterIsThis()
        {
            string testData = _rnd.NextString(4);
            byte[] constrParam = Encoding.ASCII.GetBytes(testData);
            Tag testObject = new Tag(constrParam);

            bool testOutput = testObject.Equals((object)testObject);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void TagStruct_EqualsMethodWithObjectParameter_ReturnsTrue_IfParameterIsConstructedFromSameData()
        {
            string testData = _rnd.NextString(4);
            byte[] constrParam = Encoding.ASCII.GetBytes(testData);
            Tag testObject = new Tag(constrParam);
            Tag testParam = new Tag(constrParam);

            bool testOutput = testObject.Equals((object)testParam);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void TagStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterIsConstructedFromDifferentData()
        {
            string testData0 = _rnd.NextString(4);
            string testData1;
            do
            {
                testData1 = _rnd.NextString(4);
            } while (testData1 == testData0);
            Tag testObject = new Tag(Encoding.ASCII.GetBytes(testData0));
            Tag testParam = new Tag(Encoding.ASCII.GetBytes(testData1));

            bool testOutput = testObject.Equals((object)testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TagStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterIsString()
        {
            string testData = _rnd.NextString(4);
            byte[] constrParam = Encoding.ASCII.GetBytes(testData);
            Tag testObject = new Tag(constrParam);

            bool testOutput = testObject.Equals(testData);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TagStruct_GetHashCodeMethod_ReturnsSameValue_IfCalledTwiceWithSameValue()
        {
            string testData = _rnd.NextString(4);
            byte[] constrParam = Encoding.ASCII.GetBytes(testData);
            Tag testObject0 = new Tag(constrParam);
            Tag testObject1 = new Tag(constrParam);

            int testOutput0 = testObject0.GetHashCode();
            int testOutput1 = testObject1.GetHashCode();

            Assert.AreEqual(testOutput0, testOutput1);
        }

        [TestMethod]
        public void TagStruct_EqualityOperator_ReturnsTrue_IfBothOperandsAreSameValue()
        {
            string testData = _rnd.NextString(4);
            byte[] constrParam = Encoding.ASCII.GetBytes(testData);
            Tag testObject = new Tag(constrParam);

#pragma warning disable CS1718 // Comparison made to same variable
            bool testOutput = testObject == testObject;
#pragma warning restore CS1718 // Comparison made to same variable

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void TagStruct_EqualityOperator_ReturnsTrue_IfBothOperandsAreConstructedFromSameData()
        {
            string testData = _rnd.NextString(4);
            byte[] constrParam = Encoding.ASCII.GetBytes(testData);
            Tag testObject0 = new Tag(constrParam);
            Tag testObject1 = new Tag(constrParam);

            bool testOutput = testObject0 == testObject1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void TagStruct_EqualityOperator_ReturnsFalse_IfOperandsAreConstructedFromDifferentData()
        {
            string testData0 = _rnd.NextString(4);
            string testData1;
            do
            {
                testData1 = _rnd.NextString(4);
            } while (testData1 == testData0);
            Tag testObject0 = new Tag(Encoding.ASCII.GetBytes(testData0));
            Tag testObject1 = new Tag(Encoding.ASCII.GetBytes(testData1));

            bool testOutput = testObject0 == testObject1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TagStruct_InequalityOperator_ReturnsFalse_IfBothOperandsAreSameValue()
        {
            string testData = _rnd.NextString(4);
            byte[] constrParam = Encoding.ASCII.GetBytes(testData);
            Tag testObject = new Tag(constrParam);

#pragma warning disable CS1718 // Comparison made to same variable
            bool testOutput = testObject != testObject;
#pragma warning restore CS1718 // Comparison made to same variable

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TagStruct_InequalityOperator_ReturnsFalse_IfBothOperandsAreConstructedFromSameData()
        {
            string testData = _rnd.NextString(4);
            byte[] constrParam = Encoding.ASCII.GetBytes(testData);
            Tag testObject0 = new Tag(constrParam);
            Tag testObject1 = new Tag(constrParam);

            bool testOutput = testObject0 != testObject1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TagStruct_InequalityOperator_ReturnsTrue_IfOperandsAreConstructedFromDifferentData()
        {
            string testData0 = _rnd.NextString(4);
            string testData1;
            do
            {
                testData1 = _rnd.NextString(4);
            } while (testData1 == testData0);
            Tag testObject0 = new Tag(Encoding.ASCII.GetBytes(testData0));
            Tag testObject1 = new Tag(Encoding.ASCII.GetBytes(testData1));

            bool testOutput = testObject0 != testObject1;

            Assert.IsTrue(testOutput);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
