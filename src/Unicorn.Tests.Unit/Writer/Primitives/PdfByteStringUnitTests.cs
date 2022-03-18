﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Tests.Utility.Providers;
using Unicorn.Tests.Unit.TestHelpers;
using Unicorn.Writer.Primitives;
using Unicorn.Writer.Streams;

namespace Unicorn.Tests.Unit.Writer.Primitives
{
    [TestClass]
    public class PdfByteStringUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void PdfByteStringClass_ConstructorWithIEnumerableParameter_SetsByteLengthPropertyToValueEqualToDoubleTheLengthOfTheEnumerationPlusThree()
        {
            byte[] testData = new byte[_rnd.Next(54)];
            int expectedValue = testData.Length * 2 + 3;
            _rnd.NextBytes(testData);
            List<byte> testParam = testData.ToList();

            PdfByteString testObject = new(testParam);
            int testOutput = testObject.ByteLength;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        public void PdfByteStringClass_ConstructorWithArrayOfByteParameter_SetsByteLengthPropertyToValueEqualToDoubleTheLengthOfTheEnumerationPlusThree()
        {
            byte[] testParam = new byte[_rnd.Next(54)];
            int expectedValue = testParam.Length * 2 + 3;
            _rnd.NextBytes(testParam);

            PdfByteString testObject = new(testParam);
            int testOutput = testObject.ByteLength;

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfByteStringClass_WriteToMethodWithListParameter_ThrowsArgumentNullException_IfParameterIsNull()
        {
            byte[] testData = new byte[_rnd.Next(54)];
            _rnd.NextBytes(testData);
            PdfByteString testObject = new(testData);
            List<byte> testParam = null;

            _ = testObject.WriteTo(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfByteStringClass_WriteToMethodWithListParameter_WritesCorrectDataToParameter_IfParameterIsNotNullAndObjectWasConstructedByConstructorWithArrayOfByteParameter()
        {
            byte[] testData = new byte[_rnd.Next(54)];
            _rnd.NextBytes(testData);
            PdfByteString testObject = new(testData);
            List<byte> testParam = new();

            _ = testObject.WriteTo(testParam);

            string expectedString = "<" + string.Join("", testData.Select(b => b.ToString("X2", CultureInfo.InvariantCulture))) + "> ";
            List<byte> expectedValue = Encoding.ASCII.GetBytes(expectedString).ToList();
            AssertionHelpers.AssertSameElements(expectedValue, testParam);
        }

        [TestMethod]
        public void PdfByteStringClass_WriteToMethodWithListParameter_WritesCorrectDataToParameter_IfParameterIsNotNullAndObjectWasConstructedByConstructorWithIEnumerableOfByteParameter()
        {
            byte[] testData = new byte[_rnd.Next(54)];
            _rnd.NextBytes(testData);
            PdfByteString testObject = new(testData.ToList());
            List<byte> testParam = new();

            _ = testObject.WriteTo(testParam);

            List<byte> expectedValue
                = Encoding.ASCII.GetBytes("<" + string.Join("", testData.Select(b => b.ToString("X2", CultureInfo.InvariantCulture))) + "> ").ToList();
            AssertionHelpers.AssertSameElements(expectedValue, testParam);
        }

        [TestMethod]
        public void PdfByteStringClass_WriteToMethodWithListParameter_ReturnsCorrectValue_IfParameterIsNotNullAndObjectWasConstructedByConstructorWithIEnumerableOfByteParameter()
        {
            byte[] testData = new byte[_rnd.Next(54)];
            _rnd.NextBytes(testData);
            PdfByteString testObject = new(testData.ToList());
            List<byte> testParam = new();

            int testOutput = testObject.WriteTo(testParam);

            Assert.AreEqual(testData.Length * 2 + 3, testOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfByteStringClass_WriteToMethodWithStreamParameter_ThrowsArgumentNullException_IfParameterIsNull()
        {
            byte[] testData = new byte[_rnd.Next(54)];
            _rnd.NextBytes(testData);
            PdfByteString testObject = new(testData);
            Stream testParam = null;

            _ = testObject.WriteTo(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfByteStringClass_WriteToMethodWithStreamParameter_WritesCorrectDataToParameter_IfParameterIsNotNullAndObjectWasConstructedByConstructorWithArrayOfByteParameter()
        {
            byte[] testData = new byte[_rnd.Next(54)];
            _rnd.NextBytes(testData);
            PdfByteString testObject = new(testData);
            using MemoryStream testParam = new();

            _ = testObject.WriteTo(testParam);

            string expectedString = "<" + string.Join("", testData.Select(b => b.ToString("X2", CultureInfo.InvariantCulture))) + "> ";
            using MemoryStream expectedValue = new(Encoding.ASCII.GetBytes(expectedString));
            AssertionHelpers.AssertSameElements(expectedValue, testParam);
        }

        [TestMethod]
        public void PdfByteStringClass_WriteToMethodWithStreamParameter_WritesCorrectDataToParameter_IfParameterIsNotNullAndObjectWasConstructedByConstructorWithIEnumerableOfByteParameter()
        {
            byte[] testData = new byte[_rnd.Next(54)];
            _rnd.NextBytes(testData);
            PdfByteString testObject = new(testData.ToList());
            using MemoryStream testParam = new();

            _ = testObject.WriteTo(testParam);

            using MemoryStream expectedValue 
                = new(Encoding.ASCII.GetBytes("<" + string.Join("", testData.Select(b => b.ToString("X2", CultureInfo.InvariantCulture))) + "> "));
            AssertionHelpers.AssertSameElements(expectedValue, testParam);
        }

        [TestMethod]
        public void PdfByteStringClass_WriteToMethodWithStreamParameter_ReturnsCorrectValue_IfParameterIsNotNullAndObjectWasConstructedByConstructorWithIEnumerableOfByteParameter()
        {
            byte[] testData = new byte[_rnd.Next(54)];
            _rnd.NextBytes(testData);
            PdfByteString testObject = new(testData.ToList());
            using MemoryStream testParam = new();

            int testOutput = testObject.WriteTo(testParam);

            Assert.AreEqual(testData.Length * 2 + 3, testOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfByteStringClass_WriteToMethodWithPdfStreamParameter_ThrowsArgumentNullException_IfParameterIsNull()
        {
            byte[] testData = new byte[_rnd.Next(54)];
            _rnd.NextBytes(testData);
            PdfByteString testObject = new(testData);
            PdfStream testParam = null;

            _ = testObject.WriteTo(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfByteStringClass_WriteToMethodWithPdfStreamParameter_WritesCorrectDataToParameter_IfParameterIsNotNullAndObjectWasConstructedByConstructorWithArrayOfByteParameter()
        {
            byte[] testData = new byte[_rnd.Next(54)];
            _rnd.NextBytes(testData);
            PdfByteString testObject = new(testData);
            PdfStream testParam = new(_rnd.Next(1, int.MaxValue));

            _ = testObject.WriteTo(testParam);

            List<byte> expectedValue
                = Encoding.ASCII.GetBytes("<" + string.Join("", testData.Select(b => b.ToString("X2", CultureInfo.InvariantCulture))) + "> ").ToList();
            AssertionHelpers.AssertSameElements(expectedValue, testParam);
        }

        [TestMethod]
        public void PdfByteStringClass_WriteToMethodWithPdfStreamParameter_WritesCorrectDataToParameter_IfParameterIsNotNullAndObjectWasConstructedByConstructorWithIEnumerableOfByteParameter()
        {
            byte[] testData = new byte[_rnd.Next(54)];
            _rnd.NextBytes(testData);
            PdfByteString testObject = new(testData.ToList());
            PdfStream testParam = new(_rnd.Next(1, int.MaxValue));

            _ = testObject.WriteTo(testParam);

            List<byte> expectedValue
                = Encoding.ASCII.GetBytes("<" + string.Join("", testData.Select(b => b.ToString("X2", CultureInfo.InvariantCulture))) + "> ").ToList();
            AssertionHelpers.AssertSameElements(expectedValue, testParam);
        }

        [TestMethod]
        public void PdfByteStringClass_WriteToMethodWithPdfStreamParameter_ReturnsCorrectValue_IfParameterIsNotNullAndObjectWasConstructedByConstructorWithIEnumerableOfByteParameter()
        {
            byte[] testData = new byte[_rnd.Next(54)];
            _rnd.NextBytes(testData);
            PdfByteString testObject = new(testData.ToList());
            PdfStream testParam = new(_rnd.Next(1, int.MaxValue));

            int testOutput = testObject.WriteTo(testParam);

            Assert.AreEqual(testData.Length * 2 + 3, testOutput);
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
