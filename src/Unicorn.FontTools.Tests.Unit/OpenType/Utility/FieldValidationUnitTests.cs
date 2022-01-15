using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.FontTools.OpenType.Utility;

namespace Unicorn.FontTools.Tests.Unit.OpenType.Utility
{
    [TestClass]
    public class FieldValidationUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness

        private static IList<int> GetValidData()
        {
            int dataLength = _rnd.Next(1, 150);
            List<int> data = new(dataLength);
            for (int i = 0; i < dataLength; ++i)
            {
                data.Add(_rnd.Next(ushort.MaxValue));
            }
            return data;
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FieldValidationClass_ValidateAndCastIEnumerableOfUShortParameterMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            IEnumerable<int> testParam0 = null;
            string testParam1 = _rnd.NextString(_rnd.Next(1, 126));

            _ = FieldValidation.ValidateAndCastIEnumerableOfUShortParameter(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void FieldValidationClass_ValidateAndCastIEnumerableOfUShortParameterMethod_ThrowsArgumentNullExceptionWithSecondParameterAsParamName_IfFirstParameterIsNull()
        {
            IEnumerable<int> testParam0 = null;
            string testParam1 = _rnd.NextString(_rnd.Next(1, 126));

            try
            {
                _ = FieldValidation.ValidateAndCastIEnumerableOfUShortParameter(testParam0, testParam1);
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual(testParam1, ex.ParamName);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FieldValidationClass_ValidateAndCastIEnumerableOfUShortParameterMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterContainsValuesLessThanZero()
        {
            int dataLength = _rnd.Next(1, 150);
            List<int> testParam0 = new(dataLength);
            for (int i = 0; i < dataLength; ++i)
            {
                testParam0.Add(_rnd.Next(ushort.MaxValue) * (_rnd.NextBoolean() ? -1 : 1));
            }
            if (testParam0.All(v => v >= 0))
            {
                testParam0.Add(_rnd.Next(ushort.MaxValue) * -1);
            }
            string testParam1 = _rnd.NextString(_rnd.Next(1, 126));

            _ = FieldValidation.ValidateAndCastIEnumerableOfUShortParameter(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void FieldValidationClass_ValidateAndCastIEnumerableOfUShortParameterMethod_ThrowsArgumentOutOfRangeExceptionWithSecondParameterAsParamName_IfFirstParameterContainsValuesLessThanZero()
        {
            int dataLength = _rnd.Next(1, 150);
            List<int> testParam0 = new(dataLength);
            for (int i = 0; i < dataLength; ++i)
            {
                testParam0.Add(_rnd.Next(ushort.MaxValue) * (_rnd.NextBoolean() ? -1 : 1));
            }
            if (testParam0.All(v => v >= 0))
            {
                testParam0.Add(_rnd.Next(ushort.MaxValue) * -1);
            }
            string testParam1 = _rnd.NextString(_rnd.Next(1, 126));

            try
            {
                _ = FieldValidation.ValidateAndCastIEnumerableOfUShortParameter(testParam0, testParam1);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.AreEqual(testParam1, ex.ParamName);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FieldValidationClass_ValidateAndCastIEnumerableOfUShortParameterMethod_ThrowsArgumentOutOfRangeException_IfFirstParameterContainsValuesGreaterThanMaximumValueOfUShortType()
        {
            int dataLength = _rnd.Next(1, 150);
            List<int> testParam0 = new(dataLength);
            for (int i = 0; i < dataLength; ++i)
            {
                testParam0.Add(_rnd.Next());
            }
            if (testParam0.All(v => v <= ushort.MaxValue))
            {
                testParam0.Add(_rnd.Next(ushort.MaxValue + 1, int.MaxValue));
            }
            string testParam1 = _rnd.NextString(_rnd.Next(1, 126));

            _ = FieldValidation.ValidateAndCastIEnumerableOfUShortParameter(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void FieldValidationClass_ValidateAndCastIEnumerableOfUShortParameterMethod_ThrowsArgumentOutOfRangeExceptionWithSecondParameterAsParamName_IfFirstParameterContainsValuesGreaterThanMaximumValueOfUShortType()
        {
            int dataLength = _rnd.Next(1, 150);
            List<int> testParam0 = new(dataLength);
            for (int i = 0; i < dataLength; ++i)
            {
                testParam0.Add(_rnd.Next());
            }
            if (testParam0.All(v => v <= ushort.MaxValue))
            {
                testParam0.Add(_rnd.Next(ushort.MaxValue + 1, int.MaxValue));
            }
            string testParam1 = _rnd.NextString(_rnd.Next(1, 126));

            try
            {
                _ = FieldValidation.ValidateAndCastIEnumerableOfUShortParameter(testParam0, testParam1);
                Assert.Fail();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.AreEqual(testParam1, ex.ParamName);
            }
        }

        [TestMethod]
        public void FieldValidationClass_ValidateAndCastIEnumerableOFUshortParameterMethod_ReturnsObject_IfFirstParameterValuesAreWithinRangeOfUShortType()
        {
            IList<int> testParam0 = GetValidData();
            string testParam1 = _rnd.NextString(_rnd.Next(1, 126));

            ushort[] testOutput = FieldValidation.ValidateAndCastIEnumerableOfUShortParameter(testParam0, testParam1);

            Assert.IsNotNull(testOutput);
        }

        [TestMethod]
        public void FieldValidationClass_ValidateAndCastIEnumerableOFUshortParameterMethod_ReturnsObjectOfCorrectLength_IfFirstParameterValuesAreWithinRangeOfUShortType()
        {
            IList<int> testParam0 = GetValidData();
            string testParam1 = _rnd.NextString(_rnd.Next(1, 126));

            ushort[] testOutput = FieldValidation.ValidateAndCastIEnumerableOfUShortParameter(testParam0, testParam1);

            Assert.AreEqual(testParam0.Count, testOutput.Length);
        }

        [TestMethod]
        public void FieldValidationClass_ValidateAndCastIEnumerableOFUshortParameterMethod_ReturnsObjectContainingCorrectValues_IfFirstParameterValuesAreWithinRangeOfUShortType()
        {
            IList<int> testParam0 = GetValidData();
            string testParam1 = _rnd.NextString(_rnd.Next(1, 126));

            ushort[] testOutput = FieldValidation.ValidateAndCastIEnumerableOfUShortParameter(testParam0, testParam1);

            for (int i = 0; i < testParam0.Count; ++i)
            {
                Assert.AreEqual((ushort)testParam0[i], testOutput[i]);
            }
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
