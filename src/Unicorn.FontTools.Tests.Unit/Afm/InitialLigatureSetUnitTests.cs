using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.FontTools.Afm;

namespace Unicorn.FontTools.Tests.Unit.Afm
{
    [TestClass]
    public class InitialLigatureSetUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void InitialLigatureSetStruct_ParameterlessConstructor_SetsSecondPropertyToNull()
        {
            InitialLigatureSet testOutput = new InitialLigatureSet();

            Assert.IsNull(testOutput.Second);
        }

        [TestMethod]
        public void InitialLigatureSetStructor_ParameterlessConstructor_SetsLigaturePropertyToNull()
        {
            InitialLigatureSet testOutput = new InitialLigatureSet();

            Assert.IsNull(testOutput.Ligature);
        }

#pragma warning disable CA5394 // Do not use insecure randomness

        [TestMethod]
        public void InitialLigatureSetStruct_ConstructorWithTwoStringParameters_SetsSecondPropertyToValueOfFirstParameter()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(1, 20));
            string testParam1 = _rnd.NextString(_rnd.Next(1, 20));

            InitialLigatureSet testOutput = new InitialLigatureSet(testParam0, testParam1);

            Assert.AreEqual(testParam0, testOutput.Second);
        }

        [TestMethod]
        public void InitialLigatureSetStruct_ConstructorWithTwoStringParameters_SetsLigaturePropertyToValueOfSecondParameter()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(1, 20));
            string testParam1 = _rnd.NextString(_rnd.Next(1, 20));

            InitialLigatureSet testOutput = new InitialLigatureSet(testParam0, testParam1);

            Assert.AreEqual(testParam1, testOutput.Ligature);
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
