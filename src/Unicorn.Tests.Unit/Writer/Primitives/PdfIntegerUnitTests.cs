using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Tests.Utility.Providers;
using Unicorn.Tests.Unit.TestHelpers;
using Unicorn.Writer.Primitives;

namespace Unicorn.Tests.Unit.Writer.Primitives
{
    [TestClass]
    public class PdfIntegerUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void PdfIntegerClass_Constructor_CreatesObjectWithValuePropertyEqualToParameter()
        {
            int testParam = _rnd.Next(int.MinValue, int.MaxValue);

            PdfInteger testOutput = PdfInteger.Create(testParam);

            Assert.AreEqual(testParam, testOutput.Value);
        }

        [TestMethod]
        public void PdfIntegerClass_ByteLengthProperty_EqualsLengthOfValueDisplayedAsStringPlusOne()
        {
            int testObjectValue = _rnd.Next(int.MinValue, int.MaxValue);
            PdfInteger testObject = PdfInteger.Create(testObjectValue);
            int expectedResult = testObjectValue.ToString("d", CultureInfo.InvariantCulture).Length + 1;

            int testOutput = testObject.ByteLength;

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfIntegerClass_WriteToMethodWithListParameter_ThrowsExceptionIfParameterIsNull()
        {
            int testObjectValue = _rnd.Next(int.MinValue, int.MaxValue);
            PdfInteger testObject = PdfInteger.Create(testObjectValue);
            List<byte> testParam0 = null;

            testObject.WriteTo(testParam0);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfIntegerClass_WriteToMethodWithListParameter_WritesCorrectValueToList()
        {
            int testObjectValue = _rnd.Next(int.MinValue, int.MaxValue);
            PdfInteger testObject = PdfInteger.Create(testObjectValue);
            List<byte> testParam0 = new();

            testObject.WriteTo(testParam0);

            List<byte> expected = Encoding.ASCII.GetBytes(testObjectValue.ToString("d", CultureInfo.InvariantCulture) + " ").ToList();
            AssertionHelpers.AssertSameElements(expected, testParam0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfIntegerClass_WriteToMethodWithStreamParameter_ThrowsExceptionIfParameterIsNull()
        {
            int testObjectValue = _rnd.Next(int.MinValue, int.MaxValue);
            PdfInteger testObject = PdfInteger.Create(testObjectValue);
            Stream testParam0 = null;

            testObject.WriteTo(testParam0);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfIntegerClass_WriteToMethodWithStreamParameter_WritesCorrectValueToParameter()
        {
            int testObjectValue = _rnd.Next(int.MinValue, int.MaxValue);
            PdfInteger testObject = PdfInteger.Create(testObjectValue);
            using MemoryStream testParam0 = new();

            testObject.WriteTo(testParam0);

            using MemoryStream expected = new(Encoding.ASCII.GetBytes(testObjectValue.ToString("d", CultureInfo.InvariantCulture) + " "));
            AssertionHelpers.AssertSameElements(expected, testParam0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfIntegerClass_WriteToMethodWithPdfStreamParameter_ThrowsArgumentNullExceptionIfParameterIsNull()
        {
            int testObjectValue = _rnd.Next(int.MinValue, int.MaxValue);
            PdfInteger testObject = PdfInteger.Create(testObjectValue);
            PdfStream testParam0 = null;

            testObject.WriteTo(testParam0);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfIntegerClass_WriteToMethodWithPdfStreamParameter_WritesCorrectValueToParameter()
        {
            int testObjectValue = _rnd.Next(int.MinValue, int.MaxValue);
            PdfInteger testObject = PdfInteger.Create(testObjectValue);
            PdfStream testParam0 = new(1);

            testObject.WriteTo(testParam0);

            List<byte> expected = Encoding.ASCII.GetBytes(testObjectValue.ToString("d", CultureInfo.InvariantCulture) + " ").ToList();
            AssertionHelpers.AssertSameElements(expected, testParam0);
        }

#pragma warning disable CA1508 // Avoid dead conditional code

        [TestMethod]
        public void PdfIntegerClass_EqualsMethodWithPdfIntegerParameter_ReturnsFalseWhenParameterIsNull()
        {
            int testObjectValue = _rnd.Next(int.MinValue, int.MaxValue);
            PdfInteger testObject = PdfInteger.Create(testObjectValue);
            PdfInteger testParam = null;

            bool testOutput = testObject.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

#pragma warning restore CA1508 // Avoid dead conditional code

        [TestMethod]
        public void PdfIntegerClass_EqualsMethodWithPdfIntegerParameter_ReturnsTrueWhenParameterIsSameObject()
        {
            int testObjectValue = _rnd.Next(int.MinValue, int.MaxValue);
            PdfInteger testObject = PdfInteger.Create(testObjectValue);
            PdfInteger testParam = testObject;

            bool testOutput = testObject.Equals(testParam);

            Assert.IsTrue(testOutput);
        }

        // FIXME This test currently doesn't do what it says because PdfInteger.Create() will cache and return an object with the same value, unless we turn that off.
        [TestMethod]
        public void PdfIntegerClass_EqualsMethodWithPdfIntegerParameter_ReturnsTrueWhenParameterIsDifferentObjectWithSameValue()
        {
            int testObjectValue = _rnd.Next(int.MinValue, int.MaxValue);
            PdfInteger testObject = PdfInteger.Create(testObjectValue);
            PdfInteger testParam = PdfInteger.Create(testObjectValue);

            bool testOutput = testObject.Equals(testParam);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void PdfIntegerClass_EqualsMethodWithPdfIntegerParameter_ReturnsFalseWhenParameterIsObjectWithDifferentValue()
        {
            int testObjectValue = _rnd.Next(int.MinValue, int.MaxValue);
            int testParamValue;
            do
            {
                testParamValue = _rnd.Next(int.MinValue, int.MaxValue);
            } while (testParamValue == testObjectValue);
            PdfInteger testObject = PdfInteger.Create(testObjectValue);
            PdfInteger testParam = PdfInteger.Create(testParamValue);

            bool testOutput = testObject.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

#pragma warning disable CA1508 // Avoid dead conditional code

        [TestMethod]
        public void PdfIntegerClass_EqualsMethodWithObjectParameter_ReturnsFalseWhenParameterIsNull()
        {
            int testObjectValue = _rnd.Next(int.MinValue, int.MaxValue);
            PdfInteger testObject = PdfInteger.Create(testObjectValue);
            object testParam = null;

            bool testOutput = testObject.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

#pragma warning restore CA1508 // Avoid dead conditional code

        [TestMethod]
        public void PdfIntegerClass_EqualsMethodWithObjectParameter_ReturnsFalseWhenParameterIsOfDifferentType()
        {
            int testObjectValue = _rnd.Next(int.MinValue, int.MaxValue);
            PdfInteger testObject = PdfInteger.Create(testObjectValue);
            object testParam = new PdfString("test");

            bool testOutput = testObject.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void PdfIntegerClass_EqualsMethodWithObjectParameter_ReturnsTrueWhenParameterIsSameObject()
        {
            int testObjectValue = _rnd.Next(int.MinValue, int.MaxValue);
            PdfInteger testObject = PdfInteger.Create(testObjectValue);
            object testParam = testObject;

            bool testOutput = testObject.Equals(testParam);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void PdfIntegerClass_EqualsMethodWithObjectParameter_ReturnsTrueWhenParameterIsDifferentObjectWithSameValue()
        {
            int testObjectValue = _rnd.Next(int.MinValue, int.MaxValue);
            PdfInteger testObject = PdfInteger.Create(testObjectValue);
            object testParam = PdfInteger.Create(testObjectValue);

            bool testOutput = testObject.Equals(testParam);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void PdfIntegerClass_EqualsMethodWithObjectParameter_ReturnsFalseWhenParameterIsObjectWithDifferentValue()
        {
            int testObjectValue = _rnd.Next(int.MinValue, int.MaxValue);
            int testParamValue;
            do
            {
                testParamValue = _rnd.Next(int.MinValue, int.MaxValue);
            } while (testParamValue == testObjectValue);
            PdfInteger testObject = PdfInteger.Create(testObjectValue);
            object testParam = PdfInteger.Create(testParamValue);

            bool testOutput = testObject.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void PdfIntegerClass_GetHashCodeMethod_ReturnsSameValueWhenCalledTwiceOnSameObject()
        {
            int testObjectValue = _rnd.Next(int.MinValue, int.MaxValue);
            PdfInteger testObject = PdfInteger.Create(testObjectValue);

            int testOutput0 = testObject.GetHashCode();
            int testOutput1 = testObject.GetHashCode();

            Assert.AreEqual(testOutput0, testOutput1);
        }

        [TestMethod]
        public void PdfIntegerClass_GetHashCodeMethod_ReturnsSameValueWhenCalledOnObjectsWithSameValue()
        {
            int testObjectValue = _rnd.Next(int.MinValue, int.MaxValue);
            PdfInteger testObject0 = PdfInteger.Create(testObjectValue);
            PdfInteger testObject1 = PdfInteger.Create(testObjectValue);

            int testOutput0 = testObject0.GetHashCode();
            int testOutput1 = testObject1.GetHashCode();

            Assert.AreEqual(testOutput0, testOutput1);
        }

        [TestMethod]
        public void PdfIntegerClass_GetHashCodeMethod_ProbablyReturnsDifferentValueWhenCalledOnObjectsWithDifferentValue()
        {
            for (int i = 0; i < 1_000_000; ++i)
            {
                int testObjectValue0 = _rnd.Next(int.MinValue, int.MaxValue);
                int testObjectValue1;
                do
                {
                    testObjectValue1 = _rnd.Next(int.MinValue, int.MaxValue);
                } while (testObjectValue1 == testObjectValue0);
                PdfInteger testObject0 = PdfInteger.Create(testObjectValue0);
                PdfInteger testObject1 = PdfInteger.Create(testObjectValue1);

                int testOutput0 = testObject0.GetHashCode();
                int testOutput1 = testObject1.GetHashCode();

                Assert.AreNotEqual(testOutput0, testOutput1);
            }
        }

        [TestMethod]
        public void PdfIntegerClass_EqualityOperator_ReturnsTrueIfBothOperandsAreSame()
        {
            int testObjectValue = _rnd.Next(int.MinValue, int.MaxValue);
            PdfInteger testObject0 = PdfInteger.Create(testObjectValue);
            PdfInteger testObject1 = testObject0;

            bool testOutput = testObject0 == testObject1;

            Assert.IsTrue(testOutput);
        }

#pragma warning disable CA1508 // Avoid dead conditional code

        [TestMethod]
        public void PdfIntegerClass_EqualityOperator_ReturnsTrueIfBothOperandsAreNull()
        {
            PdfInteger testObject0 = null;
            PdfInteger testObject1 = null;

            bool testOutput = testObject0 == testObject1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void PdfIntegerClass_EqualityOperator_ReturnsFalseIfFirstOperandIsNullAndSecondOperandIsNotNull()
        {
            int testObjectValue = _rnd.Next(int.MinValue, int.MaxValue);
            PdfInteger testObject0 = null;
            PdfInteger testObject1 = PdfInteger.Create(testObjectValue);

            bool testOutput = testObject0 == testObject1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void PdfIntegerClass_EqualityOperator_ReturnsFalseIfFirstOperandIsNotNullAndSecondOperandIsNull()
        {
            int testObjectValue = _rnd.Next(int.MinValue, int.MaxValue);
            PdfInteger testObject0 = PdfInteger.Create(testObjectValue); 
            PdfInteger testObject1 = null;

            bool testOutput = testObject0 == testObject1;

            Assert.IsFalse(testOutput);
        }

#pragma warning restore CA1508 // Avoid dead conditional code

        [TestMethod]
        public void PdfIntegerClass_EqualityOperator_ReturnsTrueIfFirstOperandAndSecondOperandAreDifferentInstancesWithSameValue()
        {
            int testObjectValue = _rnd.Next(int.MinValue, int.MaxValue);
            PdfInteger testObject0 = PdfInteger.Create(testObjectValue);
            PdfInteger testObject1 = PdfInteger.Create(testObjectValue);

            bool testOutput = testObject0 == testObject1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void PdfIntegerClass_EqualityOperator_ReturnsFalseIfFirstOperandAndSecondOperandHaveDifferentValues()
        {
            int testObjectValue0 = _rnd.Next(int.MinValue, int.MaxValue);
            int testObjectValue1;
            do
            {
                testObjectValue1 = _rnd.Next(int.MinValue, int.MaxValue);
            } while (testObjectValue1 == testObjectValue0);
            PdfInteger testObject0 = PdfInteger.Create(testObjectValue0);
            PdfInteger testObject1 = PdfInteger.Create(testObjectValue1);

            bool testOutput = testObject0 == testObject1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void PdfIntegerClass_InequalityOperator_ReturnsFalseIfBothOperandsAreSame()
        {
            int testObjectValue = _rnd.Next(int.MinValue, int.MaxValue);
            PdfInteger testObject0 = PdfInteger.Create(testObjectValue);
            PdfInteger testObject1 = testObject0;

            bool testOutput = testObject0 != testObject1;

            Assert.IsFalse(testOutput);
        }

#pragma warning disable CA1508 // Avoid dead conditional code

        [TestMethod]
        public void PdfIntegerClass_InequalityOperator_ReturnsFalseIfBothOperandsAreNull()
        {
            PdfInteger testObject0 = null;
            PdfInteger testObject1 = null;

            bool testOutput = testObject0 != testObject1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void PdfIntegerClass_InequalityOperator_ReturnsTrueIfFirstOperandIsNullAndSecondOperandIsNotNull()
        {
            int testObjectValue = _rnd.Next(int.MinValue, int.MaxValue);
            PdfInteger testObject0 = null;
            PdfInteger testObject1 = PdfInteger.Create(testObjectValue);

            bool testOutput = testObject0 != testObject1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void PdfIntegerClass_InequalityOperator_ReturnsTrueIfFirstOperandIsNotNullAndSecondOperandIsNull()
        {
            int testObjectValue = _rnd.Next(int.MinValue, int.MaxValue);
            PdfInteger testObject0 = PdfInteger.Create(testObjectValue);
            PdfInteger testObject1 = null;

            bool testOutput = testObject0 != testObject1;

            Assert.IsTrue(testOutput);
        }

#pragma warning restore CA1508 // Avoid dead conditional code

        [TestMethod]
        public void PdfIntegerClass_InequalityOperator_ReturnsFalseIfFirstOperandAndSecondOperandAreDifferentInstancesWithSameValue()
        {
            int testObjectValue = _rnd.Next(int.MinValue, int.MaxValue);
            PdfInteger testObject0 = PdfInteger.Create(testObjectValue);
            PdfInteger testObject1 = PdfInteger.Create(testObjectValue);

            bool testOutput = testObject0 != testObject1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void PdfIntegerClass_InequalityOperator_ReturnsTrueIfFirstOperandAndSecondOperandHaveDifferentValues()
        {
            int testObjectValue0 = _rnd.Next(int.MinValue, int.MaxValue);
            int testObjectValue1;
            do
            {
                testObjectValue1 = _rnd.Next(int.MinValue, int.MaxValue);
            } while (testObjectValue1 == testObjectValue0);
            PdfInteger testObject0 = PdfInteger.Create(testObjectValue0);
            PdfInteger testObject1 = PdfInteger.Create(testObjectValue1);

            bool testOutput = testObject0 != testObject1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void PdfIntegerClass_ZeroProperty_HasCorrectValue()
        {
            PdfInteger testOutput = PdfInteger.Zero;

            Assert.AreEqual(0, testOutput.Value);
        }

        [TestMethod]
        public void PdfIntegerClass_ZeroProperty_ReturnsSameObjectWhenCalledTwice()
        {
            PdfInteger testOutput0 = PdfInteger.Zero;
            PdfInteger testOutput1 = PdfInteger.Zero;

            Assert.AreSame(testOutput0, testOutput1);
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
