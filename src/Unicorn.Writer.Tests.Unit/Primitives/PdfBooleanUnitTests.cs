using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.Writer.Primitives;
using Unicorn.Writer.Tests.Unit.TestHelpers;

namespace Unicorn.Writer.Tests.Unit.Primitives
{
    [TestClass]
    public class PdfBooleanUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void PdfBooleanClass_TrueProperty_ReturnsObjectWithValueEqualToTrue()
        {
            PdfBoolean testObject = PdfBoolean.True;

            Assert.AreEqual(true, testObject.Value);
        }

        [TestMethod]
        public void PdfBooleanClass_FalseProperty_ReturnsObjectWithValueEqualToFalse()
        {
            PdfBoolean testObject = PdfBoolean.False;

            Assert.AreEqual(false, testObject.Value);
        }

        [TestMethod]
        public void PdfBooleanClass_GetMethod_ReturnsObjectWithValueEqualToParameter()
        {
            bool val = _rnd.NextBoolean();

            PdfBoolean testOutput = PdfBoolean.Get(val);

            Assert.AreEqual(val, testOutput.Value);
        }

        [TestMethod]
        public void PdfBooleanClass_ByteLengthProperty_EqualsFiveWhenValueIsTrue()
        {
            PdfBoolean testObject = PdfBoolean.True;

            Assert.AreEqual(5, testObject.ByteLength);
        }

        [TestMethod]
        public void PdfBooleanClass_ByteLengthProperty_EqualsSixWhenValueIsFalse()
        {
            PdfBoolean testObject = PdfBoolean.False;

            Assert.AreEqual(6, testObject.ByteLength);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfBooleanClass_WriteToMethodWithListParameter_ThrowsExceptionIfParameterIsNull()
        {
            List<byte> testParam0 = null;
            PdfBoolean testObject = PdfBoolean.Get(_rnd.NextBoolean());

            testObject.WriteTo(testParam0);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfBooleanClass_WriteToMethodWithListParameter_WritesCorrectValueToParameterIfValueIsTrue()
        {
            List<byte> testParam0 = new List<byte>();
            PdfBoolean testObject = PdfBoolean.True;

            testObject.WriteTo(testParam0);

            List<byte> expected = Encoding.ASCII.GetBytes("true ").ToList();
            AssertionHelpers.AssertSameElements(expected, testParam0);
        }

        [TestMethod]
        public void PdfBooleanClass_WriteToMethodWithListParameter_WritesCorrectValueToParameterIfValueIsFalse()
        {
            List<byte> testParam0 = new List<byte>();
            PdfBoolean testObject = PdfBoolean.False;

            testObject.WriteTo(testParam0);

            List<byte> expected = Encoding.ASCII.GetBytes("false ").ToList();
            AssertionHelpers.AssertSameElements(expected, testParam0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfBooleanClass_WriteToMethodWithStreamParameter_ThrowsExceptionIfParameterIsNull()
        {
            MemoryStream testParam0 = null;
            PdfBoolean testObject = PdfBoolean.Get(_rnd.NextBoolean());

            testObject.WriteTo(testParam0);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfBooleanClass_WriteToMethodWithStreamParameter_WritesCorrectValueToParameterIfValueIsTrue()
        {
            using (MemoryStream testParam0 = new MemoryStream())
            {
                PdfBoolean testObject = PdfBoolean.True;

                testObject.WriteTo(testParam0);

                using (MemoryStream expected = new MemoryStream(Encoding.ASCII.GetBytes("true ")))
                {
                    AssertionHelpers.AssertSameElements(expected, testParam0);
                }
            }
        }

        [TestMethod]
        public void PdfBooleanClass_WriteToMethodWithStreamParameter_WritesCorrectValueToParameterIfValueIsFalse()
        {
            using (MemoryStream testParam0 = new MemoryStream())
            {
                PdfBoolean testObject = PdfBoolean.False;

                testObject.WriteTo(testParam0);

                using (MemoryStream expected = new MemoryStream(Encoding.ASCII.GetBytes("false ")))
                {
                    AssertionHelpers.AssertSameElements(expected, testParam0);
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfBooleanClass_WriteToMethodWithPdfStreamParameter_ThrowsExceptionIfParameterIsNull()
        {
            PdfStream testParam0 = null;
            PdfBoolean testObject = PdfBoolean.Get(_rnd.NextBoolean());

            testObject.WriteTo(testParam0);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfBooleanClass_WriteToMethodWithPdfStreamParameter_WritesCorrectValueToParameterIfValueIsTrue()
        {
            PdfStream testParam0 = new PdfStream(1);
            PdfBoolean testObject = PdfBoolean.True;

            testObject.WriteTo(testParam0);

            List<byte> expected = Encoding.ASCII.GetBytes("true ").ToList();
            AssertionHelpers.AssertSameElements(expected, testParam0);
        }

        [TestMethod]
        public void PdfBooleanClass_WriteToMethodWithPdfStreamParameter_WritesCorrectValueToParameterIfValueIsFalse()
        {
            PdfStream testParam0 = new PdfStream(1);
            PdfBoolean testObject = PdfBoolean.False;

            testObject.WriteTo(testParam0);

            List<byte> expected = Encoding.ASCII.GetBytes("false ").ToList();
            AssertionHelpers.AssertSameElements(expected, testParam0);
        }

        [TestMethod]
        public void PdfBooleanClass_EqualsMethodWithPdfBooleanParameter_ReturnsFalseWhenParameterIsNull()
        {
            PdfBoolean testObject = PdfBoolean.Get(_rnd.NextBoolean());
            PdfBoolean testParameter = null;

            bool testOutput = testObject.Equals(testParameter);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void PdfBooleanClass_EqualsMethodWithPdfBooleanParameter_ReturnsFalseWhenParameterHasDifferentValue()
        {
            PdfBoolean testObject = PdfBoolean.Get(_rnd.NextBoolean());
            PdfBoolean testParameter = PdfBoolean.Get(!testObject.Value);

            bool testOutput = testObject.Equals(testParameter);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void PdfBooleanClass_EqualsMethodWithPdfBooleanParameter_ReturnsTrueWhenParameterHasSameValue()
        {
            PdfBoolean testObject = PdfBoolean.Get(_rnd.NextBoolean());
            PdfBoolean testParameter = PdfBoolean.Get(testObject.Value);

            bool testOutput = testObject.Equals(testParameter);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void PdfBooleanClass_EqualsMethodWithPdfBooleanParameter_ReturnsTrueWhenParameterIsThis()
        {
            // With the current implementation this is effectively identical to the previous test, because the PdfBoolean class maintains singleton objects for each value.
            PdfBoolean testObject = PdfBoolean.Get(_rnd.NextBoolean());

            bool testOutput = testObject.Equals(testObject);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void PdfBooleanClass_EqualsMethodWithObjectParameter_ReturnsFalseWhenParameterIsNull()
        {
            PdfBoolean testObject = PdfBoolean.Get(_rnd.NextBoolean());
            object testParameter = null;

            bool testOutput = testObject.Equals(testParameter);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void PdfBooleanClass_EqualsMethodWithObjectParameter_ReturnsFalseWhenParameterIsDifferentType()
        {
            PdfBoolean testObject = PdfBoolean.Get(_rnd.NextBoolean());
            object testParameter = new PdfString("test object");

            bool testOutput = testObject.Equals(testParameter);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void PdfBooleanClass_EqualsMethodWithObjectParameter_ReturnsFalseWhenParameterHasDifferentValue()
        {
            PdfBoolean testObject = PdfBoolean.Get(_rnd.NextBoolean());
            object testParameter = PdfBoolean.Get(!testObject.Value);

            bool testOutput = testObject.Equals(testParameter);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void PdfBooleanClass_EqualsMethodWithObjectParameter_ReturnsTrueWhenParameterHasSameValue()
        {
            PdfBoolean testObject = PdfBoolean.Get(_rnd.NextBoolean());
            object testParameter = PdfBoolean.Get(testObject.Value);

            bool testOutput = testObject.Equals(testParameter);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void PdfBooleanClass_EqualsMethodWithObjectParameter_ReturnsTrueWhenParameterIsThis()
        {
            // With the current implementation this is effectively identical to the previous test, because the PdfBoolean class maintains singleton objects for each value.
            PdfBoolean testObject = PdfBoolean.Get(_rnd.NextBoolean());
            object testParameter = testObject;

            bool testOutput = testObject.Equals(testParameter);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void PdfBooleanClass_GetHashCodeMethod_ReturnsSameValueWhenCalledTwiceOnSameObject()
        {
            PdfBoolean testObject = PdfBoolean.Get(_rnd.NextBoolean());

            int testOutput0 = testObject.GetHashCode();
            int testOutput1 = testObject.GetHashCode();

            Assert.AreEqual(testOutput0, testOutput1);
        }

        [TestMethod]
        public void PdfBooleanClass_GetHashCodeMethod_ReturnsSameValueWhenCalledOnObjectsWithSameValue()
        {
            // Strictly speaking, again as the current implementation maintains singleton objects for each value, this test is effectively identical to the previous test.
            PdfBoolean testObject0 = PdfBoolean.Get(_rnd.NextBoolean());
            PdfBoolean testObject1 = PdfBoolean.Get(testObject0.Value);

            int testOutput0 = testObject0.GetHashCode();
            int testOutput1 = testObject1.GetHashCode();

            Assert.AreEqual(testOutput0, testOutput1);
        }

        [TestMethod]
        public void PdfBooleanClass_GetHashCodeMethod_ReturnsDifferentValueWhenCalledOnObjectsWithDifferentValue()
        {
            PdfBoolean testObject0 = PdfBoolean.Get(_rnd.NextBoolean());
            PdfBoolean testObject1 = PdfBoolean.Get(!testObject0.Value);

            int testOutput0 = testObject0.GetHashCode();
            int testOutput1 = testObject1.GetHashCode();

            Assert.AreNotEqual(testOutput0, testOutput1);
        }

#pragma warning disable CA1508 // Avoid dead conditional code

        [TestMethod]
        public void PdfBooleanClass_EqualityOperator_ReturnsTrueIfBothOperandsAreNull()
        {
            PdfBoolean operand0 = null;
            PdfBoolean operand1 = null;

            bool testOutput = operand0 == operand1;

            Assert.IsTrue(testOutput);
        }

#pragma warning restore CA1508 // Avoid dead conditional code

        [TestMethod]
        public void PdfBooleanClass_EqualityOperator_ReturnsFalseIfFirstOperandIsNullAndSecondOperandIsNotNull()
        {
            PdfBoolean operand0 = null;
            PdfBoolean operand1 = PdfBoolean.Get(_rnd.NextBoolean());

            bool testOutput = operand0 == operand1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void PdfBooleanClass_EqualityOperator_ReturnsFalseIfFirstOperandIsNotNullAndSecondOperandIsNull()
        {
            PdfBoolean operand0 = PdfBoolean.Get(_rnd.NextBoolean());
            PdfBoolean operand1 = null;

            bool testOutput = operand0 == operand1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void PdfBooleanClass_EqualityOperator_ReturnsTrueIfFirstOperandAndSecondOperandAreSameObject()
        {
            PdfBoolean operand0 = PdfBoolean.Get(_rnd.NextBoolean());
            PdfBoolean operand1 = operand0;

            bool testOutput = operand0 == operand1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void PdfBooleanClass_EqualityOperator_ReturnsTrueIfFirstOperandAndSecondOperandHaveSameValue()
        {
            // As for the Equals() method, this test is with the current implementation equivalent to the previous, as the class maintains singleton objects for each potential value.
            PdfBoolean operand0 = PdfBoolean.Get(_rnd.NextBoolean());
            PdfBoolean operand1 = PdfBoolean.Get(operand0.Value);

            bool testOutput = operand0 == operand1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void PdfBooleanClass_EqualityOperator_ReturnsFalseIfFirstOperandAndSecondOperandHaveDifferentValues()
        {
            PdfBoolean operand0 = PdfBoolean.Get(_rnd.NextBoolean());
            PdfBoolean operand1 = PdfBoolean.Get(!operand0.Value);

            bool testOutput = operand0 == operand1;

            Assert.IsFalse(testOutput);
        }

#pragma warning disable CA1508 // Avoid dead conditional code

        [TestMethod]
        public void PdfBooleanClass_InequalityOperator_ReturnsFalseIfBothOperandsAreNull()
        {
            PdfBoolean operand0 = null;
            PdfBoolean operand1 = null;

            bool testOutput = operand0 != operand1;

            Assert.IsFalse(testOutput);
        }

#pragma warning restore CA1508 // Avoid dead conditional code


        [TestMethod]
        public void PdfBooleanClass_InequalityOperator_ReturnsTrueIfFirstOperandIsNullAndSecondOperandIsNotNull()
        {
            PdfBoolean operand0 = null;
            PdfBoolean operand1 = PdfBoolean.Get(_rnd.NextBoolean());

            bool testOutput = operand0 != operand1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void PdfBooleanClass_InequalityOperator_ReturnsTrueIfFirstOperandIsNotNullAndSecondOperandIsNull()
        {
            PdfBoolean operand0 = PdfBoolean.Get(_rnd.NextBoolean());
            PdfBoolean operand1 = null;

            bool testOutput = operand0 != operand1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void PdfBooleanClass_InequalityOperator_ReturnsFalseIfFirstOperandAndSecondOperandAreSameObject()
        {
            PdfBoolean operand0 = PdfBoolean.Get(_rnd.NextBoolean());
            PdfBoolean operand1 = operand0;

            bool testOutput = operand0 != operand1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void PdfBooleanClass_InequalityOperator_ReturnsFalseIfFirstOperandAndSecondOperandHaveSameValue()
        {
            // As for the Equals() method, this test is with the current implementation equivalent to the previous, as the class maintains singleton objects for each potential value.
            PdfBoolean operand0 = PdfBoolean.Get(_rnd.NextBoolean());
            PdfBoolean operand1 = PdfBoolean.Get(operand0.Value);

            bool testOutput = operand0 != operand1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void PdfBooleanClass_InequalityOperator_ReturnsTrueIfFirstOperandAndSecondOperandHaveDifferentValues()
        {
            PdfBoolean operand0 = PdfBoolean.Get(_rnd.NextBoolean());
            PdfBoolean operand1 = PdfBoolean.Get(!operand0.Value);

            bool testOutput = operand0 != operand1;

            Assert.IsTrue(testOutput);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
