using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Unicorn.Writer.Primitives;
using Unicorn.Writer.Tests.Unit.TestHelpers;

namespace Unicorn.Writer.Tests.Unit.Primitives
{
    [TestClass]
    public class PdfNullUnitTests
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void PdfNullClass_ValueProperty_ReturnsPdfNullInstance()
        {
            PdfNull testOutput = PdfNull.Value;

            Assert.IsNotNull(testOutput);
        }

        [TestMethod]
        public void PdfNullClass_ValueProperty_ReturnsSameObjectWhenCalledMultipleTimes()
        {
            PdfNull testOutput1 = PdfNull.Value;
            PdfNull testOutput2 = PdfNull.Value;

            Assert.AreSame(testOutput1, testOutput2);
        }

        [TestMethod]
        public void PdfNullClass_ByteLengthProperty_Equals5()
        {
            PdfNull testObject = PdfNull.Value;

            Assert.AreEqual(5, testObject.ByteLength);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfNullClass_WriteToMethodWithListParameter_ThrowsExceptionWhenParameterIsNull()
        {
            PdfNull testObject = PdfNull.Value;
            List<byte> testParam = null;

            testObject.WriteTo(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfNullClass_WriteToMethodWithListParameter_WritesCorrectValueToParameterWhenParameterIsNotNull()
        {
            PdfNull testObject = PdfNull.Value;
            List<byte> testParam = new List<byte>();

            testObject.WriteTo(testParam);

            List<byte> expected = Encoding.ASCII.GetBytes("null ").ToList();
            AssertionHelpers.AssertSameElements(expected, testParam);
        }

        [TestMethod]
        public void PdfNullClass_WriteToMethodWithListParameter_Returns5()
        {
            PdfNull testObject = PdfNull.Value;
            List<byte> testParam = new List<byte>();

            int testOutput = testObject.WriteTo(testParam);

            Assert.AreEqual(5, testOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfNullClass_WriteToMethodWithStreamParameter_ThrowsExceptionWhenParameterIsNull()
        {
            PdfNull testobject = PdfNull.Value;
            Stream testParam = null;

            testobject.WriteTo(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfNullClass_WriteToMethodWithStreamParameter_WritesCorrectValueToParameterWhenParameterIsNotNull()
        {
            PdfNull testObject = PdfNull.Value;
            using MemoryStream testParam = new MemoryStream();

            testObject.WriteTo(testParam);

            using MemoryStream expected = new MemoryStream(Encoding.ASCII.GetBytes("null "));
            AssertionHelpers.AssertSameElements(expected, testParam);
        }

        [TestMethod]
        public void PdfNullClass_WriteToMethodWithStreamParameter_Returns5()
        {
            using MemoryStream testParam = new MemoryStream();
            PdfNull testObject = PdfNull.Value;

            int testOutput = testObject.WriteTo(testParam);

            Assert.AreEqual(5, testOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfNullClass_WriteToMethodWithPdfStreamParameter_ThrowsExceptionWhenParameterIsNull()
        {
            PdfNull testobject = PdfNull.Value;
            PdfStream testParam = null;

            testobject.WriteTo(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfNullClass_WriteToMethodWithPdfStreamParameter_WritesCorrectValueToParameterWhenParameterIsNotNull()
        {
            PdfStream testParam0 = new PdfStream(1);
            PdfNull testObject = PdfNull.Value;

            testObject.WriteTo(testParam0);

            List<byte> expected = Encoding.ASCII.GetBytes("null ").ToList();
            AssertionHelpers.AssertSameElements(expected, testParam0);
        }

        [TestMethod]
        public void PdfNullClass_WriteToMethodWithPdfStreamParameter_Returns5()
        {
            PdfStream testParam0 = new PdfStream(1);
            PdfNull testObject = PdfNull.Value;

            int testResult = testObject.WriteTo(testParam0);

            Assert.AreEqual(5, testResult);
        }

        [TestMethod]
        public void PdfNullClass_EqualsMethod_ReturnsFalseWhenParameterIsNull()
        {
            PdfNull testObject = PdfNull.Value;

            bool testOutput = testObject.Equals(null);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void PdfNullClass_EqualsMethod_ReturnsTrueWhenParameterIsNotNull()
        {
            PdfNull testObject = PdfNull.Value;
            PdfNull testParam = PdfNull.Value;

            bool testOutput = testObject.Equals(testParam);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void PdfNullClass_GetHashCodeMethod_ReturnsSameValueWhenCalledTwice()
        {
            PdfNull testObject = PdfNull.Value;

            int firstTestOutput = testObject.GetHashCode();
            int secondTestOutput = testObject.GetHashCode();

            Assert.AreEqual(firstTestOutput, secondTestOutput);
        }

#pragma warning disable CA1508 // Avoid dead conditional code

        [TestMethod]
        public void PdfNullClass_EqualityOperator_ReturnsTrueIfBothOperandsAreNull()
        {
            PdfNull operand0 = null;
            PdfNull operand1 = null;

            bool testOutput = operand0 == operand1;

            Assert.IsTrue(testOutput);
        }

#pragma warning restore CA1508 // Avoid dead conditional code

        [TestMethod]
        public void PdfNullClass_EqualityOperator_ReturnsFalseIfFirstOperandIsNullAndSecondOperandIsNotNull()
        {
            PdfNull operand0 = null;
            PdfNull operand1 = PdfNull.Value;

            bool testOutput = operand0 == operand1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void PdfNullClass_EqualityOperator_ReturnsFalseIfFirstOperandIsNotNullAndSecondOperandIsNull()
        {
            PdfNull operand0 = PdfNull.Value;
            PdfNull operand1 = null;

            bool testOutput = operand0 == operand1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void PdfNullClass_EqualityOperator_ReturnsTrueIfBothOperandsAreNotNull()
        {
            PdfNull operand0 = PdfNull.Value;
            PdfNull operand1 = PdfNull.Value;

            bool testOutput = operand0 == operand1;

            Assert.IsTrue(testOutput);
        }

#pragma warning disable CA1508 // Avoid dead conditional code

        [TestMethod]
        public void PdfNullClass_InequalityOperator_ReturnsFalseIfBothOperandsAreNull()
        {
            PdfNull operand0 = null;
            PdfNull operand1 = null;

            bool testOutput = operand0 != operand1;

            Assert.IsFalse(testOutput);
        }

#pragma warning restore CA1508 // Avoid dead conditional code

        [TestMethod]
        public void PdfNullClass_InequalityOperator_ReturnsTrueIfFirstOperandIsNullAndSecondOperandIsNotNull()
        {
            PdfNull operand0 = null;
            PdfNull operand1 = PdfNull.Value;

            bool testOutput = operand0 != operand1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void PdfNullClass_InequalityOperator_ReturnsTrueIfFirstOperandIsNotNullAndSecondOperandIsNull()
        {
            PdfNull operand0 = PdfNull.Value;
            PdfNull operand1 = null;

            bool testOutput = operand0 != operand1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void PdfNullClass_InequalityOperator_ReturnsFalseIfBothOperandsAreNotNull()
        {
            PdfNull operand0 = PdfNull.Value;
            PdfNull operand1 = PdfNull.Value;

            bool testOutput = operand0 != operand1;

            Assert.IsFalse(testOutput);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
