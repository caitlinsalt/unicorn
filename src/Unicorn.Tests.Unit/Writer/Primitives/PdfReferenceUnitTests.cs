using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Utility.Providers;
using Unicorn.Writer.Interfaces;
using Unicorn.Writer.Primitives;

namespace Unicorn.Tests.Unit.Writer.Primitives
{
    [TestClass]
    public class PdfReferenceUnitTests
    {
        private readonly Random _rnd = RandomProvider.Default;
        private int _testObjectId;
        private int _testGeneration;
        private Mock<IPdfIndirectObject> _mockTarget;

        private PdfReference _testObject;

#pragma warning disable CA5394 // Do not use insecure randomness

        [TestInitialize]
        public void SetUpTest()
        {
            _testObjectId = _rnd.Next();
            _testGeneration = _rnd.Next();
            _mockTarget = new();
            _mockTarget.Setup(t => t.ObjectId).Returns(_testObjectId);
            _mockTarget.Setup(t => t.Generation).Returns(_testGeneration);

            _testObject = new(_mockTarget.Object);
        }

#pragma warning restore CA5394 // Do not use insecure randomness

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfReferenceClass_Constructor_ThrowsArgumentNullException_IfParameterIsNull()
        {
            _ = new PdfReference(null);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfReferenceClass_Constructor_CreatesObjectWithObjectIdPropertyEqualToObjectIdPropertyOfParameter()
        {
            var testOutput = new PdfReference(_mockTarget.Object);

            Assert.AreEqual(_testObjectId, testOutput.ObjectId);
        }

        [TestMethod]
        public void PdfReferenceClass_Constructor_CreatesObjectWithGenerationPropertyEqualToGenerationPropertyOfParameter()
        {
            var testOutput = new PdfReference(_mockTarget.Object);

            Assert.AreEqual(_testGeneration, testOutput.Generation);
        }

        [TestMethod]
        public void PdfReferenceClass_EqualsMethodWithPdfReferenceParameter_ReturnsTrue_IfParameterIsThis()
        {
            var testOutput = _testObject.Equals(_testObject);

            Assert.IsTrue(testOutput);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
