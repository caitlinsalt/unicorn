using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.Helpers;

namespace Unicorn.Tests.Unit.Helpers
{
    [TestClass]
    public class ParameterValidationHelperUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private string _param1;
        private string _param2;

#pragma warning disable CA5394 // Do not use insecure randomness

        [TestInitialize]
        public void SetUpTest()
        {
            _param1 = _rnd.NextString(_rnd.Next(50));
            _param2 = _rnd.NextString(_rnd.Next(50));
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ParameterValidationHelperClass_CheckDoubleValueBetweenZeroAndOne_ThrowsArgumentOutOfRangeException_IfFirstParameterIsLessThanZero()
        {
            double param0 = (_rnd.NextDouble() + 0.0001) * -1000;

            ParameterValidationHelper.CheckDoubleValueBetweenZeroAndOne(param0, _param1, _param2);

            Assert.Fail();
        }

        [TestMethod]
        public void ParameterValidationHelperClass_CheckDoubleValueBetweenZeroAndOne_ThrowsArgumentOutOfRangeExceptionWithParamNamePropertyEqualToSecondParameter_IfFirstParameterIsLessThanZero()
        {
            double param0 = (_rnd.NextDouble() + 0.0001) * -1000;

            try
            {
                ParameterValidationHelper.CheckDoubleValueBetweenZeroAndOne(param0, _param1, _param2);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException testOutput)
            {
                Assert.AreEqual(_param1, testOutput.ParamName);
            }
        }

        [TestMethod]
        public void ParameterValidationHelperClass_CheckDoubleValueBetweenZeroAndOne_ThrowsArgumentOutOfRangeExceptionWithMessagePropertyStartingWithThirdParameter_IfFirstParameterIsLessThanZero()
        {
            double param0 = (_rnd.NextDouble() + 0.0001) * -1000;

            try
            {
                ParameterValidationHelper.CheckDoubleValueBetweenZeroAndOne(param0, _param1, _param2);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException testOutput)
            {
                Assert.IsTrue(testOutput.Message.StartsWith(_param2, StringComparison.InvariantCulture));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ParameterValidationHelperClass_CheckDoubleValueBetweenZeroAndOne_ThrowsArgumentOutOfRangeException_IfFirstParameterIsGreaterThanOne()
        {
            double param0 = (_rnd.NextDouble() + 0.001) * 1000;

            ParameterValidationHelper.CheckDoubleValueBetweenZeroAndOne(param0, _param1, _param2);

            Assert.Fail();
        }

        [TestMethod]
        public void ParameterValidationHelperClass_CheckDoubleValueBetweenZeroAndOne_ThrowsArgumentOutOfRangeExceptionWithParamNamePropertyEqualToSecondParameter_IfFirstParameterIsGreaterThanOne()
        {
            double param0 = (_rnd.NextDouble() + 0.001) * 1000;

            try
            {
                ParameterValidationHelper.CheckDoubleValueBetweenZeroAndOne(param0, _param1, _param2);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException testOutput)
            {
                Assert.AreEqual(_param1, testOutput.ParamName);
            }
        }

        [TestMethod]
        public void ParameterValidationHelperClass_CheckDoubleValueBetweenZeroAndOne_ThrowsArgumentOutOfRangeExceptionWithMessagePropertyStartingWithThirdParameter_IfFirstParameterIsGreaterThanOne()
        {
            double param0 = (_rnd.NextDouble() + 0.001) * 1000;

            try
            {
                ParameterValidationHelper.CheckDoubleValueBetweenZeroAndOne(param0, _param1, _param2);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException testOutput)
            {
                Assert.IsTrue(testOutput.Message.StartsWith(_param2, StringComparison.InvariantCulture));
            }
        }

        [TestMethod]
        public void ParameterValidationHelpersClass_CheckBitCountIsValidMethod_DoesNotThrowException_IfParameterIsValid()
        {
            int[] validValues = new[] { 1, 2, 4, 8 };
            int param0 = _rnd.FromSet(validValues);

            ParameterValidationHelper.CheckBitCountIsValid(param0, _param1, _param2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ParameterValidationHelperClass_CheckBitCountIsValidMethod_ThrowsArgumentOutOfRangeException_IfParameterIsNotValid()
        {
            int param0;
            do
            {
                param0 = _rnd.Next();
            } while (param0 == 1 || param0 == 2 || param0 == 4 || param0 == 8);

            ParameterValidationHelper.CheckBitCountIsValid(param0, _param1, _param2);

            Assert.Fail();
        }

        [TestMethod]
        public void ParameterValidationHelperClass_CheckBitCountIsValidMethod_ThrowsArgumentOutOfRangeExceptionWithParamNamePropertyEqualToSecondParameter_IfParameterIsNotValid()
        {
            int param0;
            do
            {
                param0 = _rnd.Next();
            } while (param0 == 1 || param0 == 2 || param0 == 4 || param0 == 8);

            try
            {
                ParameterValidationHelper.CheckBitCountIsValid(param0, _param1, _param2);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException testOutput)
            {
                Assert.AreEqual(_param1, testOutput.ParamName);
            }
        }

        [TestMethod]
        public void ParameterValidationHelperClass_CheckBitCountIsValidMethod_ThrowsArgumentOutOfRangeExceptionWithMessagePropertyStartingWithThirdParameter_IfParameterIsNotValid()
        {
            int param0;
            do
            {
                param0 = _rnd.Next();
            } while (param0 == 1 || param0 == 2 || param0 == 4 || param0 == 8);

            try
            {
                ParameterValidationHelper.CheckBitCountIsValid(param0, _param1, _param2);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException testOutput)
            {
                Assert.IsTrue(testOutput.Message.StartsWith(_param2, StringComparison.InvariantCulture));
            }
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
