using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Tests.Utility.Providers;
using Unicorn.CoreTypes;
using Unicorn.CoreTypes.Tests.Utility.Extensions;
using Unicorn.Writer.Extensions;
using Unicorn.Writer.Primitives;
using Unicorn.Writer.Tests.Unit.TestHelpers;

namespace Unicorn.Writer.Tests.Unit.Primitives
{
    [TestClass]
    public class PdfOperatorUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_AppendRectangleMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            PdfNumber testParam0 = null;
            PdfNumber testParam1 = _rnd.NextPdfNumber();
            PdfNumber testParam2 = _rnd.NextPdfNumber();
            PdfNumber testParam3 = _rnd.NextPdfNumber();

            _ = PdfOperator.AppendRectangle(testParam0, testParam1, testParam2, testParam3);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_AppendRectangleMethod_ThrowsArgumentNullException_IfSecondParameterIsNull()
        {
            PdfNumber testParam0 = _rnd.NextPdfNumber();
            PdfNumber testParam1 = null;
            PdfNumber testParam2 = _rnd.NextPdfNumber();
            PdfNumber testParam3 = _rnd.NextPdfNumber();

            _ = PdfOperator.AppendRectangle(testParam0, testParam1, testParam2, testParam3);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_AppendRectangleMethod_ThrowsArgumentNullException_IfThirdParameterIsNull()
        {
            PdfNumber testParam0 = _rnd.NextPdfNumber();
            PdfNumber testParam1 = _rnd.NextPdfNumber();
            PdfNumber testParam2 = null;
            PdfNumber testParam3 = _rnd.NextPdfNumber();

            _ = PdfOperator.AppendRectangle(testParam0, testParam1, testParam2, testParam3);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_AppendRectangleMethod_ThrowsArgumentNullException_IfFourthParameterIsNull()
        {
            PdfNumber testParam0 = _rnd.NextPdfNumber();
            PdfNumber testParam1 = _rnd.NextPdfNumber();
            PdfNumber testParam2 = _rnd.NextPdfNumber();
            PdfNumber testParam3 = null;

            _ = PdfOperator.AppendRectangle(testParam0, testParam1, testParam2, testParam3);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfOperatorClass_AppendRectangleMethod_CreatesObjectWithCorrectValueProperty()
        {
            PdfNumber testParam0 = _rnd.NextPdfNumber();
            PdfNumber testParam1 = _rnd.NextPdfNumber();
            PdfNumber testParam2 = _rnd.NextPdfNumber();
            PdfNumber testParam3 = _rnd.NextPdfNumber();

            PdfOperator testOutput = PdfOperator.AppendRectangle(testParam0, testParam1, testParam2, testParam3);

            Assert.AreEqual("re", testOutput.Value);
        }

        [TestMethod]
        public void PdfOperatorClass_AppendRectangleMethod_CreatesObjectWithCorrectByteLengthProperty()
        {
            PdfNumber testParam0 = _rnd.NextPdfNumber();
            PdfNumber testParam1 = _rnd.NextPdfNumber();
            PdfNumber testParam2 = _rnd.NextPdfNumber();
            PdfNumber testParam3 = _rnd.NextPdfNumber();

            PdfOperator testOutput = PdfOperator.AppendRectangle(testParam0, testParam1, testParam2, testParam3);

            // The ByteLength of a "re" operator is the lengths of the operands, two chars for the operator, and a space.
            Assert.AreEqual(testParam0.ByteLength + testParam1.ByteLength + testParam2.ByteLength + testParam3.ByteLength + 3, testOutput.ByteLength);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_AppendRectangleMethod_WriteToMethodWithListParameter_ThrowsExceptionIfParameterOfSecondMethodIsNull()
        {
            PdfNumber testParam0 = _rnd.NextPdfNumber();
            PdfNumber testParam1 = _rnd.NextPdfNumber();
            PdfNumber testParam2 = _rnd.NextPdfNumber();
            PdfNumber testParam3 = _rnd.NextPdfNumber();
            List<byte> testParam4 = null;

            PdfOperator testOutput0 = PdfOperator.AppendRectangle(testParam0, testParam1, testParam2, testParam3);
            _ = testOutput0.WriteTo(testParam4);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfOperatorClass_AppendRectangleMethod_WriteToMethodWithListParameter_WritesCorrectValueToList()
        {
            PdfNumber testParam0 = _rnd.NextPdfNumber();
            PdfNumber testParam1 = _rnd.NextPdfNumber();
            PdfNumber testParam2 = _rnd.NextPdfNumber();
            PdfNumber testParam3 = _rnd.NextPdfNumber();
            List<byte> testParam4 = new List<byte>();
            List<byte> expected = new List<byte>();
            testParam0.WriteTo(expected);
            testParam1.WriteTo(expected);
            testParam2.WriteTo(expected);
            testParam3.WriteTo(expected);
            expected.AddRange(new byte[] { 0x72, 0x65, 0x20 });

            PdfOperator testOutput0 = PdfOperator.AppendRectangle(testParam0, testParam1, testParam2, testParam3);
            _ = testOutput0.WriteTo(testParam4);

            AssertionHelpers.AssertSameElements(expected, testParam4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_AppendRectangleMethod_WriteToMethodWithStreamParameter_ThrowsArgumentNullException_IfParameterOfSecondMethodIsNull()
        {
            PdfNumber testParam0 = _rnd.NextPdfNumber();
            PdfNumber testParam1 = _rnd.NextPdfNumber();
            PdfNumber testParam2 = _rnd.NextPdfNumber();
            PdfNumber testParam3 = _rnd.NextPdfNumber();
            Stream testParam4 = null;

            PdfOperator testOutput0 = PdfOperator.AppendRectangle(testParam0, testParam1, testParam2, testParam3);
            _ = testOutput0.WriteTo(testParam4);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfOperatorClass_AppendRectangleMethod_WriteToMethodWithStreamParameter_WritesCorrectValueToStream()
        {
            PdfNumber testParam0 = _rnd.NextPdfNumber();
            PdfNumber testParam1 = _rnd.NextPdfNumber();
            PdfNumber testParam2 = _rnd.NextPdfNumber();
            PdfNumber testParam3 = _rnd.NextPdfNumber();
            using MemoryStream testParam4 = new MemoryStream();
            using MemoryStream expected = new MemoryStream();
            testParam0.WriteTo(expected);
            testParam1.WriteTo(expected);
            testParam2.WriteTo(expected);
            testParam3.WriteTo(expected);
            expected.Write(new byte[] { 0x72, 0x65, 0x20 }, 0, 3);

            PdfOperator testOutput0 = PdfOperator.AppendRectangle(testParam0, testParam1, testParam2, testParam3);
            _ = testOutput0.WriteTo(testParam4);

            AssertionHelpers.AssertSameElements(expected, testParam4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_AppendRectangleMethod_WriteToMethodWithPdfStreamParameter_ThrowsArgumentNullException_IfParameterToSecondMethodIsNull()
        {
            PdfNumber testParam0 = _rnd.NextPdfNumber();
            PdfNumber testParam1 = _rnd.NextPdfNumber();
            PdfNumber testParam2 = _rnd.NextPdfNumber();
            PdfNumber testParam3 = _rnd.NextPdfNumber();
            PdfStream testParam4 = null;

            PdfOperator testOutput0 = PdfOperator.AppendRectangle(testParam0, testParam1, testParam2, testParam3);
            _ = testOutput0.WriteTo(testParam4);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfOperatorClass_AppendRectangleMethod_WriteToMethodWithPdfStreamParameter_WritesCorrectValueToStream()
        {
            PdfNumber testParam0 = _rnd.NextPdfNumber();
            PdfNumber testParam1 = _rnd.NextPdfNumber();
            PdfNumber testParam2 = _rnd.NextPdfNumber();
            PdfNumber testParam3 = _rnd.NextPdfNumber();
            PdfStream testParam4 = new PdfStream(_rnd.Next(1, int.MaxValue));
            List<byte> expected = new List<byte>();
            testParam0.WriteTo(expected);
            testParam1.WriteTo(expected);
            testParam2.WriteTo(expected);
            testParam3.WriteTo(expected);
            expected.AddRange(new byte[] { 0x72, 0x65, 0x20 });

            PdfOperator testOutput0 = PdfOperator.AppendRectangle(testParam0, testParam1, testParam2, testParam3);
            _ = testOutput0.WriteTo(testParam4);

            AssertionHelpers.AssertSameElements(expected, testParam4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_AppendStraightLineMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            PdfNumber testParam0 = null;
            PdfNumber testParam1 = _rnd.NextPdfNumber();

            _ = PdfOperator.AppendStraightLine(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_AppendStraightLineMethod_ThrowsArgumentNullException_IfSecondParameterIsNull()
        {
            PdfNumber testParam0 = _rnd.NextPdfNumber();
            PdfNumber testParam1 = null;

            _ = PdfOperator.AppendStraightLine(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfOperatorClass_AppendStraightLineMethod_CreatesObjectWithCorrectValueProperty()
        {
            PdfNumber testParam0 = _rnd.NextPdfNumber();
            PdfNumber testParam1 = _rnd.NextPdfNumber();

            PdfOperator testOutput = PdfOperator.AppendStraightLine(testParam0, testParam1);

            Assert.AreEqual("l", testOutput.Value);
        }

        [TestMethod]
        public void PdfOperatorClass_AppendStraightLineMethod_CreatesObjectWithCorrectByteLengthProperty()
        {
            PdfNumber testParam0 = _rnd.NextPdfNumber();
            PdfNumber testParam1 = _rnd.NextPdfNumber();

            PdfOperator testOutput = PdfOperator.AppendStraightLine(testParam0, testParam1);

            // The ByteLength of an "l" operator is the lengths of the operands, one char for the operator, and a space.
            Assert.AreEqual(testParam0.ByteLength + testParam1.ByteLength + 2, testOutput.ByteLength);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_AppendStraightLineMethod_WriteToMethodWithListParameter_ThrowsExceptionIfParameterOfSecondMethodIsNull()
        {
            PdfNumber testParam0 = _rnd.NextPdfNumber();
            PdfNumber testParam1 = _rnd.NextPdfNumber();
            List<byte> testParam2 = null;

            PdfOperator testOutput0 = PdfOperator.AppendStraightLine(testParam0, testParam1);
            _ = testOutput0.WriteTo(testParam2);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfOperatorClass_AppendStraightLineMethod_WriteToMethodWithListParameter_WritesCorrectValueToList()
        {
            PdfNumber testParam0 = _rnd.NextPdfNumber();
            PdfNumber testParam1 = _rnd.NextPdfNumber();
            List<byte> testParam2 = new List<byte>();
            List<byte> expected = new List<byte>();
            testParam0.WriteTo(expected);
            testParam1.WriteTo(expected);
            expected.AddRange(new byte[] { 0x6c, 0x20 });

            PdfOperator testOutput0 = PdfOperator.AppendStraightLine(testParam0, testParam1);
            _ = testOutput0.WriteTo(testParam2);

            AssertionHelpers.AssertSameElements(expected, testParam2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_AppendStraightLineMethod_WriteToMethodWithStreamParameter_ThrowsArgumentNullException_IfParameterOfSecondMethodIsNull()
        {
            PdfNumber testParam0 = _rnd.NextPdfNumber();
            PdfNumber testParam1 = _rnd.NextPdfNumber();
            Stream testParam2 = null;

            PdfOperator testOutput0 = PdfOperator.AppendStraightLine(testParam0, testParam1);
            _ = testOutput0.WriteTo(testParam2);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfOperatorClass_AppendStraightLineMethod_WriteToMethodWithStreamParameter_WritesCorrectValueToStream()
        {
            PdfNumber testParam0 = _rnd.NextPdfNumber();
            PdfNumber testParam1 = _rnd.NextPdfNumber();
            using MemoryStream testParam4 = new MemoryStream();
            using MemoryStream expected = new MemoryStream();
            testParam0.WriteTo(expected);
            testParam1.WriteTo(expected);
            expected.Write(new byte[] { 0x6c, 0x20 }, 0, 2);

            PdfOperator testOutput0 = PdfOperator.AppendStraightLine(testParam0, testParam1);
            _ = testOutput0.WriteTo(testParam4);

            AssertionHelpers.AssertSameElements(expected, testParam4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_AppendStraightLineMethod_WriteToMethodWithPdfStreamParameter_ThrowsArgumentNullException_IfParameterToSecondMethodIsNull()
        {
            PdfNumber testParam0 = _rnd.NextPdfNumber();
            PdfNumber testParam1 = _rnd.NextPdfNumber();
            PdfStream testParam2 = null;

            PdfOperator testOutput0 = PdfOperator.AppendStraightLine(testParam0, testParam1);
            _ = testOutput0.WriteTo(testParam2);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfOperatorClass_AppendStraightLineMethod_WriteToMethodWithPdfStreamParameter_WritesCorrectValueToStream()
        {
            PdfNumber testParam0 = _rnd.NextPdfNumber();
            PdfNumber testParam1 = _rnd.NextPdfNumber();
            PdfStream testParam2 = new PdfStream(_rnd.Next(1, int.MaxValue));
            List<byte> expected = new List<byte>();
            testParam0.WriteTo(expected);
            testParam1.WriteTo(expected);
            expected.AddRange(new byte[] { 0x6c, 0x20 });

            PdfOperator testOutput0 = PdfOperator.AppendStraightLine(testParam0, testParam1);
            _ = testOutput0.WriteTo(testParam2);

            AssertionHelpers.AssertSameElements(expected, testParam2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_LineDashPatternMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            PdfArray testParam0 = null;
            PdfInteger testParam1 = _rnd.NextPdfInteger();

            _ = PdfOperator.LineDashPattern(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_LineDashPatternMethod_ThrowsArgumentNullException_IfSecondParameterIsNull()
        {
            PdfArray testParam0 = _rnd.NextPdfArrayOfNumber();
            PdfInteger testParam1 = null;

            _ = PdfOperator.LineDashPattern(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PdfOperatorClass_LineDashPatternMethod_ThrowsArgumentException_IfFirstParameterContainsElementsThatAreNotPdfNumberInstances()
        {
            PdfArray testParam0;
            do
            {
                testParam0 = _rnd.NextPdfArray();
            } while (testParam0.Length == 0 || testParam0.All(e => e is PdfNumber));
            PdfInteger testParam1 = new PdfInteger(_rnd.Next(testParam0.Length));

            _ = PdfOperator.LineDashPattern(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PdfOperatorClass_LineDashPatternMethod_ThrowsArgumentException_IfSecondParameterIsLargerThanLengthOfFirstParameter()
        {
            PdfArray testParam0 = _rnd.NextPdfArrayOfNumber();
            PdfInteger testParam1 = new PdfInteger(_rnd.Next(testParam0.Length + 1, int.MaxValue));

            _ = PdfOperator.LineDashPattern(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfOperatorClass_LineDashPatternMethod_CreatesObjectWithCorrectValueProperty()
        {
            PdfArray testParam0 = _rnd.NextPdfArrayOfNumber();
            PdfInteger testParam1 = new PdfInteger(testParam0.Length == 0 ? 0 : _rnd.Next(testParam0.Length));

            PdfOperator testOutput = PdfOperator.LineDashPattern(testParam0, testParam1);

            Assert.AreEqual("d", testOutput.Value);
        }

        [TestMethod]
        public void PdfOperatorClass_LineDashPatternMethod_CreatesObjectWithCorrectByteLengthProperty()
        {
            PdfArray testParam0 = _rnd.NextPdfArrayOfNumber();
            PdfInteger testParam1 = new PdfInteger(testParam0.Length == 0 ? 0 : _rnd.Next(testParam0.Length));

            PdfOperator testOutput = PdfOperator.LineDashPattern(testParam0, testParam1);

            // The ByteLength of a "d" operator is the lengths of the operands, one char for the operator, and a space.
            Assert.AreEqual(testParam0.ByteLength + testParam1.ByteLength + 2, testOutput.ByteLength);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_LineDashPatternMethod_WriteToMethodWithListParameter_ThrowsExceptionIfParameterOfSecondMethodIsNull()
        {
            PdfArray testParam0 = _rnd.NextPdfArrayOfNumber();
            PdfInteger testParam1 = new PdfInteger(testParam0.Length == 0 ? 0 : _rnd.Next(testParam0.Length));
            List<byte> testParam2 = null;

            PdfOperator testOutput0 = PdfOperator.LineDashPattern(testParam0, testParam1);
            _ = testOutput0.WriteTo(testParam2);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfOperatorClass_LineDashPatternMethod_WriteToMethodWithListParameter_WritesCorrectValueToList()
        {
            PdfArray testParam0 = _rnd.NextPdfArrayOfNumber();
            PdfInteger testParam1 = new PdfInteger(testParam0.Length == 0 ? 0 : _rnd.Next(testParam0.Length));
            List<byte> testParam4 = new List<byte>();
            List<byte> expected = new List<byte>();
            testParam0.WriteTo(expected);
            testParam1.WriteTo(expected);
            expected.AddRange(new byte[] { 0x64, 0x20 });

            PdfOperator testOutput0 = PdfOperator.LineDashPattern(testParam0, testParam1);
            _ = testOutput0.WriteTo(testParam4);

            AssertionHelpers.AssertSameElements(expected, testParam4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_LineDashPatternMethod_WriteToMethodWithStreamParameter_ThrowsArgumentNullException_IfParameterOfSecondMethodIsNull()
        {
            PdfArray testParam0 = _rnd.NextPdfArrayOfNumber();
            PdfInteger testParam1 = new PdfInteger(testParam0.Length == 0 ? 0 : _rnd.Next(testParam0.Length));
            Stream testParam2 = null;

            PdfOperator testOutput0 = PdfOperator.LineDashPattern(testParam0, testParam1);
            _ = testOutput0.WriteTo(testParam2);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfOperatorClass_LineDashPatternMethod_WriteToMethodWithStreamParameter_WritesCorrectValueToStream()
        {
            PdfArray testParam0 = _rnd.NextPdfArrayOfNumber();
            PdfInteger testParam1 = new PdfInteger(testParam0.Length == 0 ? 0 : _rnd.Next(testParam0.Length));
            using MemoryStream testParam4 = new MemoryStream();
            using MemoryStream expected = new MemoryStream();
            testParam0.WriteTo(expected);
            testParam1.WriteTo(expected);
            expected.Write(new byte[] { 0x64, 0x20 }, 0, 2);

            PdfOperator testOutput0 = PdfOperator.LineDashPattern(testParam0, testParam1);
            _ = testOutput0.WriteTo(testParam4);

            AssertionHelpers.AssertSameElements(expected, testParam4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_LineDashPatternMethod_WriteToMethodWithPdfStreamParameter_ThrowsArgumentNullException_IfParameterToSecondMethodIsNull()
        {
            PdfArray testParam0 = _rnd.NextPdfArrayOfNumber();
            PdfInteger testParam1 = new PdfInteger(testParam0.Length == 0 ? 0 : _rnd.Next(testParam0.Length));
            PdfStream testParam2 = null;

            PdfOperator testOutput0 = PdfOperator.LineDashPattern(testParam0, testParam1);
            _ = testOutput0.WriteTo(testParam2);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfOperatorClass_LineDashPatternMethod_WriteToMethodWithPdfStreamParameter_WritesCorrectValueToStream()
        {
            PdfArray testParam0 = _rnd.NextPdfArrayOfNumber();
            PdfInteger testParam1 = new PdfInteger(testParam0.Length == 0 ? 0 : _rnd.Next(testParam0.Length));
            PdfStream testParam2 = new PdfStream(_rnd.Next(1, int.MaxValue));
            List<byte> expected = new List<byte>();
            testParam0.WriteTo(expected);
            testParam1.WriteTo(expected);
            expected.AddRange(new byte[] { 0x64, 0x20 });

            PdfOperator testOutput0 = PdfOperator.LineDashPattern(testParam0, testParam1);
            _ = testOutput0.WriteTo(testParam2);

            AssertionHelpers.AssertSameElements(expected, testParam2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_LineWidthMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            PdfNumber testParam = null;

            _ = PdfOperator.LineWidth(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfOperatorClass_LineWidthMethod_CreatesObjectWithCorrectValueProperty()
        {
            PdfNumber testParam = _rnd.NextPdfNumber();

            PdfOperator testOutput = PdfOperator.LineWidth(testParam);

            Assert.AreEqual("w", testOutput.Value);
        }

        [TestMethod]
        public void PdfOperatorClass_LineWidthMethod_CreatesObjectWithCorrectByteLengthProperty()
        {
            PdfNumber testParam = _rnd.NextPdfNumber();

            PdfOperator testOutput = PdfOperator.LineWidth(testParam);

            // The ByteLength of a "w" operator is the length of the operand, one char for the operator, and a space.
            Assert.AreEqual(testParam.ByteLength + 2, testOutput.ByteLength);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_LineWidthMethod_WriteToMethodWithListParameter_ThrowsExceptionIfParameterOfSecondMethodIsNull()
        {
            PdfNumber testParam0 = _rnd.NextPdfNumber();
            List<byte> testParam1 = null;

            PdfOperator testOutput0 = PdfOperator.LineWidth(testParam0);
            _ = testOutput0.WriteTo(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfOperatorClass_LineWidthMethod_WriteToMethodWithListParameter_WritesCorrectValueToList()
        {
            PdfNumber testParam0 = _rnd.NextPdfNumber();
            List<byte> testParam1 = new List<byte>();
            List<byte> expected = new List<byte>();
            testParam0.WriteTo(expected);
            expected.AddRange(new byte[] { 0x77, 0x20 });

            PdfOperator testOutput0 = PdfOperator.LineWidth(testParam0);
            _ = testOutput0.WriteTo(testParam1);

            AssertionHelpers.AssertSameElements(expected, testParam1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_LineWidthMethod_WriteToMethodWithStreamParameter_ThrowsArgumentNullException_IfParameterOfSecondMethodIsNull()
        {
            PdfNumber testParam0 = _rnd.NextPdfNumber();
            Stream testParam1 = null;

            PdfOperator testOutput0 = PdfOperator.LineWidth(testParam0);
            _ = testOutput0.WriteTo(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfOperatorClass_LineWidthMethod_WriteToMethodWithStreamParameter_WritesCorrectValueToStream()
        {
            PdfNumber testParam0 = _rnd.NextPdfNumber();
            using MemoryStream testParam1 = new MemoryStream();
            using MemoryStream expected = new MemoryStream();
            testParam0.WriteTo(expected);
            expected.Write(new byte[] { 0x77, 0x20 }, 0, 2);

            PdfOperator testOutput0 = PdfOperator.LineWidth(testParam0);
            _ = testOutput0.WriteTo(testParam1);

            AssertionHelpers.AssertSameElements(expected, testParam1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_LineWidthMethod_WriteToMethodWithPdfStreamParameter_ThrowsArgumentNullException_IfParameterToSecondMethodIsNull()
        {
            PdfNumber testParam0 = _rnd.NextPdfNumber();
            PdfStream testParam1 = null;

            PdfOperator testOutput0 = PdfOperator.LineWidth(testParam0);
            _ = testOutput0.WriteTo(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfOperatorClass_LineWidthMethod_WriteToMethodWithPdfStreamParameter_WritesCorrectValueToStream()
        {
            PdfNumber testParam0 = _rnd.NextPdfNumber();
            PdfStream testParam1 = new PdfStream(_rnd.Next(1, int.MaxValue));
            List<byte> expected = new List<byte>();
            testParam0.WriteTo(expected);
            expected.AddRange(new byte[] { 0x77, 0x20 });

            PdfOperator testOutput0 = PdfOperator.LineWidth(testParam0);
            _ = testOutput0.WriteTo(testParam1);

            AssertionHelpers.AssertSameElements(expected, testParam1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_StartPathLineMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            PdfNumber testParam0 = null;
            PdfNumber testParam1 = _rnd.NextPdfNumber();

            _ = PdfOperator.StartPath(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_StartPathLineMethod_ThrowsArgumentNullException_IfSecondParameterIsNull()
        {
            PdfNumber testParam0 = _rnd.NextPdfNumber();
            PdfNumber testParam1 = null;

            _ = PdfOperator.StartPath(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfOperatorClass_StartPathMethod_CreatesObjectWithCorrectValueProperty()
        {
            PdfNumber testParam0 = _rnd.NextPdfNumber();
            PdfNumber testParam1 = _rnd.NextPdfNumber();

            PdfOperator testOutput = PdfOperator.StartPath(testParam0, testParam1);

            Assert.AreEqual("m", testOutput.Value);
        }

        [TestMethod]
        public void PdfOperatorClass_StartPathMethod_CreatesObjectWithCorrectByteLengthProperty()
        {
            PdfNumber testParam0 = _rnd.NextPdfNumber();
            PdfNumber testParam1 = _rnd.NextPdfNumber();

            PdfOperator testOutput = PdfOperator.StartPath(testParam0, testParam1);

            // The ByteLength of an "m" operator is the lengths of the operands, one char for the operator, and a space.
            Assert.AreEqual(testParam0.ByteLength + testParam1.ByteLength + 2, testOutput.ByteLength);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_StartPathMethod_WriteToMethodWithListParameter_ThrowsExceptionIfParameterOfSecondMethodIsNull()
        {
            PdfNumber testParam0 = _rnd.NextPdfNumber();
            PdfNumber testParam1 = _rnd.NextPdfNumber();
            List<byte> testParam2 = null;

            PdfOperator testOutput0 = PdfOperator.StartPath(testParam0, testParam1);
            _ = testOutput0.WriteTo(testParam2);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfOperatorClass_StartPathMethod_WriteToMethodWithListParameter_WritesCorrectValueToList()
        {
            PdfNumber testParam0 = _rnd.NextPdfNumber();
            PdfNumber testParam1 = _rnd.NextPdfNumber();
            List<byte> testParam4 = new List<byte>();
            List<byte> expected = new List<byte>();
            testParam0.WriteTo(expected);
            testParam1.WriteTo(expected);
            expected.AddRange(new byte[] { 0x6d, 0x20 });

            PdfOperator testOutput0 = PdfOperator.StartPath(testParam0, testParam1);
            _ = testOutput0.WriteTo(testParam4);

            AssertionHelpers.AssertSameElements(expected, testParam4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_StartPathMethod_WriteToMethodWithStreamParameter_ThrowsArgumentNullException_IfParameterOfSecondMethodIsNull()
        {
            PdfNumber testParam0 = _rnd.NextPdfNumber();
            PdfNumber testParam1 = _rnd.NextPdfNumber();
            Stream testParam2 = null;

            PdfOperator testOutput0 = PdfOperator.StartPath(testParam0, testParam1);
            _ = testOutput0.WriteTo(testParam2);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfOperatorClass_StartPathMethod_WriteToMethodWithStreamParameter_WritesCorrectValueToStream()
        {
            PdfNumber testParam0 = _rnd.NextPdfNumber();
            PdfNumber testParam1 = _rnd.NextPdfNumber();
            using MemoryStream testParam2 = new MemoryStream();
            using MemoryStream expected = new MemoryStream();
            testParam0.WriteTo(expected);
            testParam1.WriteTo(expected);
            expected.Write(new byte[] { 0x6d, 0x20 }, 0, 2);

            PdfOperator testOutput0 = PdfOperator.StartPath(testParam0, testParam1);
            _ = testOutput0.WriteTo(testParam2);

            AssertionHelpers.AssertSameElements(expected, testParam2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_StartPathMethod_WriteToMethodWithPdfStreamParameter_ThrowsArgumentNullException_IfParameterToSecondMethodIsNull()
        {
            PdfNumber testParam0 = _rnd.NextPdfNumber();
            PdfNumber testParam1 = _rnd.NextPdfNumber();
            PdfStream testParam2 = null;

            PdfOperator testOutput0 = PdfOperator.StartPath(testParam0, testParam1);
            _ = testOutput0.WriteTo(testParam2);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfOperatorClass_StartPathMethod_WriteToMethodWithPdfStreamParameter_WritesCorrectValueToStream()
        {
            PdfNumber testParam0 = _rnd.NextPdfNumber();
            PdfNumber testParam1 = _rnd.NextPdfNumber();
            PdfStream testParam2 = new PdfStream(_rnd.Next(1, int.MaxValue));
            List<byte> expected = new List<byte>();
            testParam0.WriteTo(expected);
            testParam1.WriteTo(expected);
            expected.AddRange(new byte[] { 0x6d, 0x20 });

            PdfOperator testOutput0 = PdfOperator.StartPath(testParam0, testParam1);
            _ = testOutput0.WriteTo(testParam2);

            AssertionHelpers.AssertSameElements(expected, testParam2);
        }

        [TestMethod]
        public void PdfOperatorClass_StrokePathMethod_CreatesObjectWithCorrectValueProperty()
        {
            PdfOperator testOutput = PdfOperator.StrokePath();

            Assert.AreEqual("S", testOutput.Value);
        }

        [TestMethod]
        public void PdfOperatorClass_StrokePathMethod_CreatesObjectWithCorrectByteLengthProperty()
        {
            PdfOperator testOutput = PdfOperator.StrokePath();

            // The ByteLength of an "S" operator is one character for the operator and one for a space.
            Assert.AreEqual(2, testOutput.ByteLength);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_StrokePathMethod_WriteToMethodWithListParameter_ThrowsExceptionIfParameterOfSecondMethodIsNull()
        {
            List<byte> testParam = null;

            PdfOperator testOutput0 = PdfOperator.StrokePath();
            _ = testOutput0.WriteTo(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfOperatorClass_StrokePathMethod_WriteToMethodWithListParameter_WritesCorrectValueToList()
        {
            List<byte> testParam = new List<byte>();
            List<byte> expected = new List<byte> { 0x53, 0x20 };

            PdfOperator testOutput0 = PdfOperator.StrokePath();
            _ = testOutput0.WriteTo(testParam);

            AssertionHelpers.AssertSameElements(expected, testParam);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_StrokePathMethod_WriteToMethodWithStreamParameter_ThrowsArgumentNullException_IfParameterOfSecondMethodIsNull()
        {
            Stream testParam = null;

            PdfOperator testOutput0 = PdfOperator.StrokePath();
            _ = testOutput0.WriteTo(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfOperatorClass_StrokePathMethod_WriteToMethodWithStreamParameter_WritesCorrectValueToStream()
        {
            using MemoryStream testParam = new MemoryStream();
            using MemoryStream expected = new MemoryStream();
            expected.Write(new byte[] { 0x53, 0x20 }, 0, 2);

            PdfOperator testOutput0 = PdfOperator.StrokePath();
            _ = testOutput0.WriteTo(testParam);

            AssertionHelpers.AssertSameElements(expected, testParam);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_StrokePathMethod_WriteToMethodWithPdfStreamParameter_ThrowsArgumentNullException_IfParameterToSecondMethodIsNull()
        {
            PdfStream testParam = null;

            PdfOperator testOutput0 = PdfOperator.StrokePath();
            _ = testOutput0.WriteTo(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfOperatorClass_StrokePathMethod_WriteToMethodWithPdfStreamParameter_WritesCorrectValueToStream()
        {
            PdfStream testParam = new PdfStream(_rnd.Next(1, int.MaxValue));
            List<byte> expected = new List<byte>();
            expected.AddRange(new byte[] { 0x53, 0x20 });

            PdfOperator testOutput0 = PdfOperator.StrokePath();
            _ = testOutput0.WriteTo(testParam);

            AssertionHelpers.AssertSameElements(expected, testParam);
        }

        [TestMethod]
        public void PdfOperatorClass_StartTextMethod_CreatesObjectWithCorrectValueProperty()
        {
            PdfOperator testOutput = PdfOperator.StartText();

            Assert.AreEqual("BT", testOutput.Value);
        }

        [TestMethod]
        public void PdfOperatorClass_StartTextMethod_CreatesObjectWithCorrectByteLengthProperty()
        {
            PdfOperator testOutput = PdfOperator.StartText();

            // The ByteLength of a "BT" operator is two characters for the operator and one for a space.
            Assert.AreEqual(3, testOutput.ByteLength);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_StartTextMethod_WriteToMethodWithListParameter_ThrowsExceptionIfParameterOfSecondMethodIsNull()
        {
            List<byte> testParam = null;

            PdfOperator testOutput0 = PdfOperator.StartText();
            _ = testOutput0.WriteTo(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfOperatorClass_StartTextMethod_WriteToMethodWithListParameter_WritesCorrectValueToList()
        {
            List<byte> testParam = new List<byte>();
            List<byte> expected = new List<byte> { 0x42, 0x54, 0x20 };

            PdfOperator testOutput0 = PdfOperator.StartText();
            _ = testOutput0.WriteTo(testParam);

            AssertionHelpers.AssertSameElements(expected, testParam);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_StartTextMethod_WriteToMethodWithStreamParameter_ThrowsArgumentNullException_IfParameterOfSecondMethodIsNull()
        {
            Stream testParam = null;

            PdfOperator testOutput0 = PdfOperator.StartText();
            _ = testOutput0.WriteTo(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfOperatorClass_StartTextMethod_WriteToMethodWithStreamParameter_WritesCorrectValueToStream()
        {
            using MemoryStream testParam = new MemoryStream();
            using MemoryStream expected = new MemoryStream();
            expected.Write(new byte[] { 0x42, 0x54, 0x20 }, 0, 3);

            PdfOperator testOutput0 = PdfOperator.StartText();
            _ = testOutput0.WriteTo(testParam);

            AssertionHelpers.AssertSameElements(expected, testParam);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_StartTextMethod_WriteToMethodWithPdfStreamParameter_ThrowsArgumentNullException_IfParameterToSecondMethodIsNull()
        {
            PdfStream testParam = null;

            PdfOperator testOutput0 = PdfOperator.StartText();
            _ = testOutput0.WriteTo(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfOperatorClass_StartTextMethod_WriteToMethodWithPdfStreamParameter_WritesCorrectValueToStream()
        {
            PdfStream testParam = new PdfStream(_rnd.Next(1, int.MaxValue));
            List<byte> expected = new List<byte>();
            expected.AddRange(new byte[] { 0x42, 0x54, 0x20 });

            PdfOperator testOutput0 = PdfOperator.StartText();
            _ = testOutput0.WriteTo(testParam);

            AssertionHelpers.AssertSameElements(expected, testParam);
        }

        [TestMethod]
        public void PdfOperatorClass_EndTextMethod_CreatesObjectWithCorrectValueProperty()
        {
            PdfOperator testOutput = PdfOperator.EndText();

            Assert.AreEqual("ET", testOutput.Value);
        }

        [TestMethod]
        public void PdfOperatorClass_EndTextMethod_CreatesObjectWithCorrectByteLengthProperty()
        {
            PdfOperator testOutput = PdfOperator.EndText();

            // The ByteLength of a "ET" operator is two characters for the operator and one for a space.
            Assert.AreEqual(3, testOutput.ByteLength);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_EndTextMethod_WriteToMethodWithListParameter_ThrowsExceptionIfParameterOfSecondMethodIsNull()
        {
            List<byte> testParam = null;

            PdfOperator testOutput0 = PdfOperator.EndText();
            _ = testOutput0.WriteTo(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfOperatorClass_EndTextMethod_WriteToMethodWithListParameter_WritesCorrectValueToList()
        {
            List<byte> testParam = new List<byte>();
            List<byte> expected = new List<byte> { 0x45, 0x54, 0x20 };

            PdfOperator testOutput0 = PdfOperator.EndText();
            _ = testOutput0.WriteTo(testParam);

            AssertionHelpers.AssertSameElements(expected, testParam);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_EndTextMethod_WriteToMethodWithStreamParameter_ThrowsArgumentNullException_IfParameterOfSecondMethodIsNull()
        {
            Stream testParam = null;

            PdfOperator testOutput0 = PdfOperator.EndText();
            _ = testOutput0.WriteTo(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfOperatorClass_EndTextMethod_WriteToMethodWithStreamParameter_WritesCorrectValueToStream()
        {
            using MemoryStream testParam = new MemoryStream();
            using MemoryStream expected = new MemoryStream();
            expected.Write(new byte[] { 0x45, 0x54, 0x20 }, 0, 3);

            PdfOperator testOutput0 = PdfOperator.EndText();
            _ = testOutput0.WriteTo(testParam);

            AssertionHelpers.AssertSameElements(expected, testParam);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_EndTextMethod_WriteToMethodWithPdfStreamParameter_ThrowsArgumentNullException_IfParameterToSecondMethodIsNull()
        {
            PdfStream testParam = null;

            PdfOperator testOutput0 = PdfOperator.EndText();
            _ = testOutput0.WriteTo(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfOperatorClass_EndTextMethod_WriteToMethodWithPdfStreamParameter_WritesCorrectValueToStream()
        {
            PdfStream testParam = new PdfStream(_rnd.Next(1, int.MaxValue));
            List<byte> expected = new List<byte>();
            expected.AddRange(new byte[] { 0x45, 0x54, 0x20 });

            PdfOperator testOutput0 = PdfOperator.EndText();
            _ = testOutput0.WriteTo(testParam);

            AssertionHelpers.AssertSameElements(expected, testParam);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_SetTextFontMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            PdfName testParam0 = null;
            PdfNumber testParam1 = _rnd.NextPdfNumber();

            _ = PdfOperator.SetTextFont(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_SetTextFontMethod_ThrowsArgumentNullException_IfSecondParameterIsNull()
        {
            PdfName testParam0 = _rnd.NextPdfName();
            PdfNumber testParam1 = null;

            _ = PdfOperator.SetTextFont(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfOperatorClass_SetTextFontMethod_CreatesObjectWithCorrectValueProperty()
        {
            PdfName testParam0 = _rnd.NextPdfName();
            PdfNumber testParam1 = _rnd.NextPdfNumber();

            PdfOperator testOutput = PdfOperator.SetTextFont(testParam0, testParam1);

            Assert.AreEqual("Tf", testOutput.Value);
        }

        [TestMethod]
        public void PdfOperatorClass_SetTextFontMethod_CreatesObjectWithCorrectByteLengthProperty()
        {
            PdfName testParam0 = _rnd.NextPdfName();
            PdfNumber testParam1 = _rnd.NextPdfNumber();

            PdfOperator testOutput = PdfOperator.SetTextFont(testParam0, testParam1);

            // The ByteLength of a "Tf" operator is the lengths of the operands, two chars for the operator, and a space.
            Assert.AreEqual(testParam0.ByteLength + testParam1.ByteLength + 3, testOutput.ByteLength);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_SetTextFontMethod_WriteToMethodWithListParameter_ThrowsExceptionIfParameterOfSecondMethodIsNull()
        {
            PdfName testParam0 = _rnd.NextPdfName();
            PdfNumber testParam1 = _rnd.NextPdfNumber();
            List<byte> testParam2 = null;

            PdfOperator testOutput0 = PdfOperator.SetTextFont(testParam0, testParam1);
            _ = testOutput0.WriteTo(testParam2);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfOperatorClass_SetTextFontMethod_WriteToMethodWithListParameter_WritesCorrectValueToList()
        {
            PdfName testParam0 = _rnd.NextPdfName();
            PdfNumber testParam1 = _rnd.NextPdfNumber();
            List<byte> testParam2 = new List<byte>();
            List<byte> expected = new List<byte>();
            testParam0.WriteTo(expected);
            testParam1.WriteTo(expected);
            expected.AddRange(new byte[] { 0x54, 0x66, 0x20 });

            PdfOperator testOutput0 = PdfOperator.SetTextFont(testParam0, testParam1);
            _ = testOutput0.WriteTo(testParam2);

            AssertionHelpers.AssertSameElements(expected, testParam2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_SetTextFontMethod_WriteToMethodWithStreamParameter_ThrowsArgumentNullException_IfParameterOfSecondMethodIsNull()
        {
            PdfName testParam0 = _rnd.NextPdfName();
            PdfNumber testParam1 = _rnd.NextPdfNumber();
            Stream testParam2 = null;

            PdfOperator testOutput0 = PdfOperator.SetTextFont(testParam0, testParam1);
            _ = testOutput0.WriteTo(testParam2);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfOperatorClass_SetTextFontMethod_WriteToMethodWithStreamParameter_WritesCorrectValueToStream()
        {
            PdfName testParam0 = _rnd.NextPdfName();
            PdfNumber testParam1 = _rnd.NextPdfNumber();
            using MemoryStream testParam4 = new MemoryStream();
            using MemoryStream expected = new MemoryStream();
            testParam0.WriteTo(expected);
            testParam1.WriteTo(expected);
            expected.Write(new byte[] { 0x54, 0x66, 0x20 }, 0, 3);

            PdfOperator testOutput0 = PdfOperator.SetTextFont(testParam0, testParam1);
            _ = testOutput0.WriteTo(testParam4);

            AssertionHelpers.AssertSameElements(expected, testParam4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_SetTextFontMethod_WriteToMethodWithPdfStreamParameter_ThrowsArgumentNullException_IfParameterToSecondMethodIsNull()
        {
            PdfName testParam0 = _rnd.NextPdfName();
            PdfNumber testParam1 = _rnd.NextPdfNumber();
            PdfStream testParam2 = null;

            PdfOperator testOutput0 = PdfOperator.SetTextFont(testParam0, testParam1);
            _ = testOutput0.WriteTo(testParam2);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfOperatorClass_SetTextFontMethod_WriteToMethodWithPdfStreamParameter_WritesCorrectValueToStream()
        {
            PdfName testParam0 = _rnd.NextPdfName();
            PdfNumber testParam1 = _rnd.NextPdfNumber();
            PdfStream testParam2 = new PdfStream(_rnd.Next(1, int.MaxValue));
            List<byte> expected = new List<byte>();
            testParam0.WriteTo(expected);
            testParam1.WriteTo(expected);
            expected.AddRange(new byte[] { 0x54, 0x66, 0x20 });

            PdfOperator testOutput0 = PdfOperator.SetTextFont(testParam0, testParam1);
            _ = testOutput0.WriteTo(testParam2);

            AssertionHelpers.AssertSameElements(expected, testParam2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_SetTextLocationMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            PdfNumber testParam0 = null;
            PdfNumber testParam1 = _rnd.NextPdfNumber();

            _ = PdfOperator.SetTextLocation(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_SetTextLocationMethod_ThrowsArgumentNullException_IfSecondParameterIsNull()
        {
            PdfNumber testParam0 = _rnd.NextPdfNumber();
            PdfNumber testParam1 = null;

            _ = PdfOperator.SetTextLocation(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfOperatorClass_SetTextLocationMethod_CreatesObjectWithCorrectValueProperty()
        {
            PdfNumber testParam0 = _rnd.NextPdfNumber();
            PdfNumber testParam1 = _rnd.NextPdfNumber();

            PdfOperator testOutput = PdfOperator.SetTextLocation(testParam0, testParam1);

            Assert.AreEqual("Td", testOutput.Value);
        }

        [TestMethod]
        public void PdfOperatorClass_SetTextLocationMethod_CreatesObjectWithCorrectByteLengthProperty()
        {
            PdfNumber testParam0 = _rnd.NextPdfNumber();
            PdfNumber testParam1 = _rnd.NextPdfNumber();

            PdfOperator testOutput = PdfOperator.SetTextLocation(testParam0, testParam1);

            // The ByteLength of a "Td" operator is the lengths of the operands, two chars for the operator, and a space.
            Assert.AreEqual(testParam0.ByteLength + testParam1.ByteLength + 3, testOutput.ByteLength);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_SetTextLocationMethod_WriteToMethodWithListParameter_ThrowsExceptionIfParameterOfSecondMethodIsNull()
        {
            PdfNumber testParam0 = _rnd.NextPdfNumber();
            PdfNumber testParam1 = _rnd.NextPdfNumber();
            List<byte> testParam2 = null;

            PdfOperator testOutput0 = PdfOperator.SetTextLocation(testParam0, testParam1);
            _ = testOutput0.WriteTo(testParam2);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfOperatorClass_SetTextLocationeMethod_WriteToMethodWithListParameter_WritesCorrectValueToList()
        {
            PdfNumber testParam0 = _rnd.NextPdfNumber();
            PdfNumber testParam1 = _rnd.NextPdfNumber();
            List<byte> testParam2 = new List<byte>();
            List<byte> expected = new List<byte>();
            testParam0.WriteTo(expected);
            testParam1.WriteTo(expected);
            expected.AddRange(new byte[] { 0x54, 0x64, 0x20 });

            PdfOperator testOutput0 = PdfOperator.SetTextLocation(testParam0, testParam1);
            _ = testOutput0.WriteTo(testParam2);

            AssertionHelpers.AssertSameElements(expected, testParam2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_SetTextLocationMethod_WriteToMethodWithStreamParameter_ThrowsArgumentNullException_IfParameterOfSecondMethodIsNull()
        {
            PdfNumber testParam0 = _rnd.NextPdfNumber();
            PdfNumber testParam1 = _rnd.NextPdfNumber();
            Stream testParam2 = null;

            PdfOperator testOutput0 = PdfOperator.SetTextLocation(testParam0, testParam1);
            _ = testOutput0.WriteTo(testParam2);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfOperatorClass_SetTextLocationMethod_WriteToMethodWithStreamParameter_WritesCorrectValueToStream()
        {
            PdfNumber testParam0 = _rnd.NextPdfNumber();
            PdfNumber testParam1 = _rnd.NextPdfNumber();
            using MemoryStream testParam4 = new MemoryStream();
            using MemoryStream expected = new MemoryStream();
            testParam0.WriteTo(expected);
            testParam1.WriteTo(expected);
            expected.Write(new byte[] { 0x54, 0x64, 0x20 }, 0, 3);

            PdfOperator testOutput0 = PdfOperator.SetTextLocation(testParam0, testParam1);
            _ = testOutput0.WriteTo(testParam4);

            AssertionHelpers.AssertSameElements(expected, testParam4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_SetTextLocationMethod_WriteToMethodWithPdfStreamParameter_ThrowsArgumentNullException_IfParameterToSecondMethodIsNull()
        {
            PdfNumber testParam0 = _rnd.NextPdfNumber();
            PdfNumber testParam1 = _rnd.NextPdfNumber();
            PdfStream testParam2 = null;

            PdfOperator testOutput0 = PdfOperator.SetTextLocation(testParam0, testParam1);
            _ = testOutput0.WriteTo(testParam2);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfOperatorClass_SetTextLocationMethod_WriteToMethodWithPdfStreamParameter_WritesCorrectValueToStream()
        {
            PdfNumber testParam0 = _rnd.NextPdfNumber();
            PdfNumber testParam1 = _rnd.NextPdfNumber();
            PdfStream testParam2 = new PdfStream(_rnd.Next(1, int.MaxValue));
            List<byte> expected = new List<byte>();
            testParam0.WriteTo(expected);
            testParam1.WriteTo(expected);
            expected.AddRange(new byte[] { 0x54, 0x64, 0x20 });

            PdfOperator testOutput0 = PdfOperator.SetTextLocation(testParam0, testParam1);
            _ = testOutput0.WriteTo(testParam2);

            AssertionHelpers.AssertSameElements(expected, testParam2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_DrawTextMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            PdfByteString testParam = null;

            _ = PdfOperator.DrawText(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfOperatorClass_DrawTextMethod_CreatesObjectWithCorrectValueProperty()
        {
            PdfByteString testParam = _rnd.NextPdfByteString(_rnd.Next(128));

            PdfOperator testOutput = PdfOperator.DrawText(testParam);

            Assert.AreEqual("Tj", testOutput.Value);
        }

        [TestMethod]
        public void PdfOperatorClass_DrawTextMethod_CreatesObjectWithCorrectByteLengthProperty()
        {
            PdfByteString testParam = _rnd.NextPdfByteString(_rnd.Next(128));

            PdfOperator testOutput = PdfOperator.DrawText(testParam);

            // The ByteLength of a "Tj" operator is the length of the operand, two chars for the operator, and a space.
            Assert.AreEqual(testParam.ByteLength + 3, testOutput.ByteLength);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_DrawTextMethod_WriteToMethodWithListParameter_ThrowsExceptionIfParameterOfSecondMethodIsNull()
        {
            PdfByteString testParam0 = _rnd.NextPdfByteString(_rnd.Next(128));
            List<byte> testParam1 = null;

            PdfOperator testOutput0 = PdfOperator.DrawText(testParam0);
            _ = testOutput0.WriteTo(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfOperatorClass_DrawTextMethod_WriteToMethodWithListParameter_WritesCorrectValueToList()
        {
            PdfByteString testParam0 = _rnd.NextPdfByteString(_rnd.Next(128));
            List<byte> testParam1 = new List<byte>();
            List<byte> expected = new List<byte>();
            testParam0.WriteTo(expected);
            expected.AddRange(new byte[] { 0x54, 0x6a, 0x20 });

            PdfOperator testOutput0 = PdfOperator.DrawText(testParam0);
            _ = testOutput0.WriteTo(testParam1);

            AssertionHelpers.AssertSameElements(expected, testParam1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_DrawTextMethod_WriteToMethodWithStreamParameter_ThrowsArgumentNullException_IfParameterOfSecondMethodIsNull()
        {
            PdfByteString testParam0 = _rnd.NextPdfByteString(_rnd.Next(128));
            Stream testParam1 = null;

            PdfOperator testOutput0 = PdfOperator.DrawText(testParam0);
            _ = testOutput0.WriteTo(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfOperatorClass_DrawTextMethod_WriteToMethodWithStreamParameter_WritesCorrectValueToStream()
        {
            PdfByteString testParam0 = _rnd.NextPdfByteString(_rnd.Next(128));
            using MemoryStream testParam1 = new MemoryStream();
            using MemoryStream expected = new MemoryStream();
            testParam0.WriteTo(expected);
            expected.Write(new byte[] { 0x54, 0x6a, 0x20 }, 0, 3);

            PdfOperator testOutput0 = PdfOperator.DrawText(testParam0);
            _ = testOutput0.WriteTo(testParam1);

            AssertionHelpers.AssertSameElements(expected, testParam1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_DrawTextMethod_WriteToMethodWithPdfStreamParameter_ThrowsArgumentNullException_IfParameterToSecondMethodIsNull()
        {
            PdfByteString testParam0 = _rnd.NextPdfByteString(_rnd.Next(128));
            PdfStream testParam1 = null;

            PdfOperator testOutput0 = PdfOperator.DrawText(testParam0);
            _ = testOutput0.WriteTo(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfOperatorClass_DrawTextMethod_WriteToMethodWithPdfStreamParameter_WritesCorrectValueToStream()
        {
            PdfByteString testParam0 = _rnd.NextPdfByteString(_rnd.Next(128));
            PdfStream testParam1 = new PdfStream(_rnd.Next(1, int.MaxValue));
            List<byte> expected = new List<byte>();
            testParam0.WriteTo(expected);
            expected.AddRange(new byte[] { 0x54, 0x6a, 0x20 });

            PdfOperator testOutput0 = PdfOperator.DrawText(testParam0);
            _ = testOutput0.WriteTo(testParam1);

            AssertionHelpers.AssertSameElements(expected, testParam1);
        }

        [TestMethod]
        public void PdfOperatorClass_ApplyTransformationMethod_CreatesObjectWithCorrectValueProperty()
        {
            UniMatrix testParam = _rnd.NextUniMatrix();

            PdfOperator testOutput = PdfOperator.ApplyTransformation(testParam);

            Assert.AreEqual("cm", testOutput.Value);
        }

        [TestMethod]
        public void PdfOperatorClass_ApplyTransformationMethod_CreatesObjectWithCorrectByteLengthProperty()
        {
            UniMatrix testParam = _rnd.NextUniMatrix();

            PdfOperator testOutput = PdfOperator.ApplyTransformation(testParam);

            // The ByteLength of a "cm" operator is the byte lengths of its parameters, two characters for the operator and one for a space.
            Assert.AreEqual(3 + testParam.ToPdfRealArray().Sum(r => r.ByteLength), testOutput.ByteLength);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_ApplyTransformationMethod_WriteToMethodWithListParameter_ThrowsExceptionIfParameterOfSecondMethodIsNull()
        {
            UniMatrix testParam0 = _rnd.NextUniMatrix();
            List<byte> testParam1 = null;

            PdfOperator testOutput = PdfOperator.ApplyTransformation(testParam0);
            _ = testOutput.WriteTo(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfOperatorClass_ApplyTransformationMethod_WriteToMethodWithListParameter_WritesCorrectValueToList()
        {
            UniMatrix testParam0 = _rnd.NextUniMatrix();
            List<byte> expected = new List<byte>();
            _ = testParam0.ToPdfRealArray().Select(r => r.WriteTo(expected)).ToArray();
            expected.AddRange(new byte[] { 0x63, 0x6d, 0x20 });
            List<byte> testParam1 = new List<byte>();

            PdfOperator testOutput = PdfOperator.ApplyTransformation(testParam0);
            _ = testOutput.WriteTo(testParam1);

            AssertionHelpers.AssertSameElements(expected, testParam1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_ApplyTransformationMethod_WriteToMethodWithStreamParameter_ThrowsArgumentNullException_IfParameterOfSecondMethodIsNull()
        {
            UniMatrix testParam0 = _rnd.NextUniMatrix();
            Stream testParam1 = null;

            PdfOperator testOutput = PdfOperator.ApplyTransformation(testParam0);
            _ = testOutput.WriteTo(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfOperatorClass_ApplyTransformationMethod_WriteToMethodWithStreamParameter_WritesCorrectValueToStream()
        {
            UniMatrix testParam0 = _rnd.NextUniMatrix();
            using MemoryStream testParam1 = new MemoryStream();
            using MemoryStream expected = new MemoryStream();
            _ = testParam0.ToPdfRealArray().Select(r => r.WriteTo(expected)).ToArray();
            expected.Write(new byte[] { 0x63, 0x6d, 0x20 }, 0, 3);

            PdfOperator testOutput = PdfOperator.ApplyTransformation(testParam0);
            _ = testOutput.WriteTo(testParam1);

            AssertionHelpers.AssertSameElements(expected, testParam1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_ApplyTransformationMethod_WriteToMethodWithPdfStreamParameter_ThrowsArgumentNullException_IfParameterToSecondMethodIsNull()
        {
            UniMatrix testParam0 = _rnd.NextUniMatrix();
            Stream testParam1 = null;

            PdfOperator testOutput = PdfOperator.ApplyTransformation(testParam0);
            _ = testOutput.WriteTo(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfOperatorClass_ApplyTransformationMethod_WriteToMethodWithPdfStreamParameter_WritesCorrectValueToStream()
        {
            UniMatrix testParam0 = _rnd.NextUniMatrix();
            List<byte> expected = new List<byte>();
            _ = testParam0.ToPdfRealArray().Select(r => r.WriteTo(expected)).ToArray();
            expected.AddRange(new byte[] { 0x63, 0x6d, 0x20 });
            PdfStream testParam1 = new PdfStream(_rnd.Next(1, int.MaxValue));

            PdfOperator testOutput = PdfOperator.ApplyTransformation(testParam0);
            _ = testOutput.WriteTo(testParam1);

            AssertionHelpers.AssertSameElements(expected, testParam1);
        }

        [TestMethod]
        public void PdfOperatorClass_PushStateMethod_CreatesObjectWithCorrectValueProperty()
        {
            PdfOperator testOutput = PdfOperator.PushState();

            Assert.AreEqual("q", testOutput.Value);
        }

        [TestMethod]
        public void PdfOperatorClass_PushStateMethod_CreatesObjectWithCorrectByteLengthProperty()
        {
            PdfOperator testOutput = PdfOperator.PushState();

            // The ByteLength of a "q" operator is one character for the operator and one for a space.
            Assert.AreEqual(2, testOutput.ByteLength);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_PushStateMethod_WriteToMethodWithListParameter_ThrowsExceptionIfParameterOfSecondMethodIsNull()
        {
            List<byte> testParam = null;

            PdfOperator testOutput0 = PdfOperator.PushState();
            _ = testOutput0.WriteTo(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfOperatorClass_PushStateMethod_WriteToMethodWithListParameter_WritesCorrectValueToList()
        {
            List<byte> testParam = new List<byte>();
            List<byte> expected = new List<byte> { 0x71, 0x20 };

            PdfOperator testOutput0 = PdfOperator.PushState();
            _ = testOutput0.WriteTo(testParam);

            AssertionHelpers.AssertSameElements(expected, testParam);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_PushStateMethod_WriteToMethodWithStreamParameter_ThrowsArgumentNullException_IfParameterOfSecondMethodIsNull()
        {
            Stream testParam = null;

            PdfOperator testOutput0 = PdfOperator.PushState();
            _ = testOutput0.WriteTo(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfOperatorClass_PushStateMethod_WriteToMethodWithStreamParameter_WritesCorrectValueToStream()
        {
            using MemoryStream testParam = new MemoryStream();
            using MemoryStream expected = new MemoryStream();
            expected.Write(new byte[] { 0x71, 0x20 }, 0, 2);

            PdfOperator testOutput0 = PdfOperator.PushState();
            _ = testOutput0.WriteTo(testParam);

            AssertionHelpers.AssertSameElements(expected, testParam);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_PushStateMethod_WriteToMethodWithPdfStreamParameter_ThrowsArgumentNullException_IfParameterToSecondMethodIsNull()
        {
            PdfStream testParam = null;

            PdfOperator testOutput0 = PdfOperator.PushState();
            _ = testOutput0.WriteTo(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfOperatorClass_PushStateMethod_WriteToMethodWithPdfStreamParameter_WritesCorrectValueToStream()
        {
            PdfStream testParam = new PdfStream(_rnd.Next(1, int.MaxValue));
            List<byte> expected = new List<byte>();
            expected.AddRange(new byte[] { 0x71, 0x20 });

            PdfOperator testOutput0 = PdfOperator.PushState();
            _ = testOutput0.WriteTo(testParam);

            AssertionHelpers.AssertSameElements(expected, testParam);
        }

        [TestMethod]
        public void PdfOperatorClass_PopStateMethod_CreatesObjectWithCorrectValueProperty()
        {
            PdfOperator testOutput = PdfOperator.PopState();

            Assert.AreEqual("Q", testOutput.Value);
        }

        [TestMethod]
        public void PdfOperatorClass_PopStateMethod_CreatesObjectWithCorrectByteLengthProperty()
        {
            PdfOperator testOutput = PdfOperator.PopState();

            // The ByteLength of a "Q" operator is one character for the operator and one for a space.
            Assert.AreEqual(2, testOutput.ByteLength);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_PopStateMethod_WriteToMethodWithListParameter_ThrowsExceptionIfParameterOfSecondMethodIsNull()
        {
            List<byte> testParam = null;

            PdfOperator testOutput0 = PdfOperator.PopState();
            _ = testOutput0.WriteTo(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfOperatorClass_PopStateMethod_WriteToMethodWithListParameter_WritesCorrectValueToList()
        {
            List<byte> testParam = new List<byte>();
            List<byte> expected = new List<byte> { 0x51, 0x20 };

            PdfOperator testOutput0 = PdfOperator.PopState();
            _ = testOutput0.WriteTo(testParam);

            AssertionHelpers.AssertSameElements(expected, testParam);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_PopStateMethod_WriteToMethodWithStreamParameter_ThrowsArgumentNullException_IfParameterOfSecondMethodIsNull()
        {
            Stream testParam = null;

            PdfOperator testOutput0 = PdfOperator.PopState();
            _ = testOutput0.WriteTo(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfOperatorClass_PopStateMethod_WriteToMethodWithStreamParameter_WritesCorrectValueToStream()
        {
            using MemoryStream testParam = new MemoryStream();
            using MemoryStream expected = new MemoryStream();
            expected.Write(new byte[] { 0x51, 0x20 }, 0, 2);

            PdfOperator testOutput0 = PdfOperator.PopState();
            _ = testOutput0.WriteTo(testParam);

            AssertionHelpers.AssertSameElements(expected, testParam);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfOperatorClass_PopStateMethod_WriteToMethodWithPdfStreamParameter_ThrowsArgumentNullException_IfParameterToSecondMethodIsNull()
        {
            PdfStream testParam = null;

            PdfOperator testOutput0 = PdfOperator.PopState();
            _ = testOutput0.WriteTo(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfOperatorClass_PopStateMethod_WriteToMethodWithPdfStreamParameter_WritesCorrectValueToStream()
        {
            PdfStream testParam = new PdfStream(_rnd.Next(1, int.MaxValue));
            List<byte> expected = new List<byte>();
            expected.AddRange(new byte[] { 0x51, 0x20 });

            PdfOperator testOutput0 = PdfOperator.PopState();
            _ = testOutput0.WriteTo(testParam);

            AssertionHelpers.AssertSameElements(expected, testParam);
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
