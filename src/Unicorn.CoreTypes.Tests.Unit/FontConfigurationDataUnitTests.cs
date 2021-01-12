using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.CoreTypes.Tests.Utility.Extensions;

namespace Unicorn.CoreTypes.Tests.Unit
{
    [TestClass]
    public class FontConfigurationDataUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private static FontConfigurationData GetTestValue()
        {
            return new FontConfigurationData(_rnd.NextString(_rnd.Next(20)), _rnd.NextUniFontStyles(), _rnd.NextString(_rnd.Next(128)));
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void FontConfigurationDataStruct_ParameterlessConstructor_SetsNamePropertyToNull()
        {
            FontConfigurationData testOutput = new FontConfigurationData();

            Assert.IsNull(testOutput.Name);
        }

        [TestMethod]
        public void FontConfigurationDataStruct_ParameterlessConstructor_SetsStylePropertyToZero()
        {
            FontConfigurationData testOutput = new FontConfigurationData();

            Assert.AreEqual((UniFontStyles)0, testOutput.Style);
        }

        [TestMethod]
        public void FontConfigurationDataStruct_ParameterlessConstructor_SetsFilenamePropertyToNull()
        {
            FontConfigurationData testOutput = new FontConfigurationData();

            Assert.IsNull(testOutput.Filename);
        }

        [TestMethod]
        public void FontConfigurationDataStruct_ConstructorWithStringUniFontStylesAndStringParameters_SetsNamePropertyToValueOfFirstParameter()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(20));
            UniFontStyles testParam1 = _rnd.NextUniFontStyles();
            string testParam2 = _rnd.NextString(_rnd.Next(128));

            FontConfigurationData testOutput = new FontConfigurationData(testParam0, testParam1, testParam2);

            Assert.AreEqual(testParam0, testOutput.Name);
        }

        [TestMethod]
        public void FontConfigurationDataStruct_ConstructorWithStringUniFontStylesAndStringParameters_SetsStylePropertyToValueOfSecondParameter()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(20));
            UniFontStyles testParam1 = _rnd.NextUniFontStyles();
            string testParam2 = _rnd.NextString(_rnd.Next(128));

            FontConfigurationData testOutput = new FontConfigurationData(testParam0, testParam1, testParam2);

            Assert.AreEqual(testParam1, testOutput.Style);
        }

        [TestMethod]
        public void FontConfigurationDataStruct_ConstructorWithStringUniFontStylesAndStringParameters_SetsFilenamePropertyToValueOfThirdParameter()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(20));
            UniFontStyles testParam1 = _rnd.NextUniFontStyles();
            string testParam2 = _rnd.NextString(_rnd.Next(128));

            FontConfigurationData testOutput = new FontConfigurationData(testParam0, testParam1, testParam2);

            Assert.AreEqual(testParam2, testOutput.Filename);
        }

        [TestMethod]
        public void FontConfigurationDataStruct_EqualsMethodWithFontConfigurationDataParameter_ReturnsTrue_IfParameterIsSameValue()
        {
            FontConfigurationData testValue = GetTestValue();

            bool testOutput = testValue.Equals(testValue);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void FontConfigurationDataStruct_EqualsMethodWithFontConfigurationDataParameter_ReturnsTrue_IfParameterIsConstructedFromSameData()
        {
            FontConfigurationData testValue = GetTestValue();
            FontConfigurationData testParam = new FontConfigurationData(testValue.Name, testValue.Style, testValue.Filename);

            bool testOutput = testValue.Equals(testParam);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void FontConfigurationDataStruct_EqualsMethodWithFontConfigurationDataParameter_ReturnsFalse_IfParameterDiffersInNameProperty()
        {
            FontConfigurationData testValue = GetTestValue();
            string constrParam;
            do
            {
                constrParam = _rnd.NextString(_rnd.Next(40));
            } while (constrParam == testValue.Name);
            FontConfigurationData testParam = new FontConfigurationData(constrParam, testValue.Style, testValue.Filename);

            bool testOutput = testValue.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void FontConfigurationDataStruct_EqualsMethodWithFontConfigurationDataParameter_ReturnsFalse_IfParameterDiffersInStyleProperty()
        {
            FontConfigurationData testValue = GetTestValue();
            UniFontStyles constrParam;
            do
            {
                constrParam = _rnd.NextUniFontStyles();
            } while (constrParam == testValue.Style);
            FontConfigurationData testParam = new FontConfigurationData(testValue.Name, constrParam, testValue.Filename);

            bool testOutput = testValue.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void FontConfigurationDataStruct_EqualsMethodWithFontConfigurationDataParameter_ReturnsFalse_IfParameterDiffersInFilenameProperty()
        {
            FontConfigurationData testValue = GetTestValue();
            string constrParam;
            do
            {
                constrParam = _rnd.NextString(_rnd.Next(40));
            } while (constrParam == testValue.Filename);
            FontConfigurationData testParam = new FontConfigurationData(testValue.Name, testValue.Style, constrParam);

            bool testOutput = testValue.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void FontConfigurationDataStruct_EqualsMethodWithObjectParameter_ReturnsTrue_IfParameterIsSameValue()
        {
            FontConfigurationData testValue = GetTestValue();

            bool testOutput = testValue.Equals((object)testValue);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void FontConfigurationDataStruct_EqualsMethodWithObjectParameter_ReturnsTrue_IfParameterIsConstructedFromSameData()
        {
            FontConfigurationData testValue = GetTestValue();
            FontConfigurationData testParam = new FontConfigurationData(testValue.Name, testValue.Style, testValue.Filename);

            bool testOutput = testValue.Equals((object)testParam);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void FontConfigurationDataStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterDiffersInNameProperty()
        {
            FontConfigurationData testValue = GetTestValue();
            string constrParam;
            do
            {
                constrParam = _rnd.NextString(_rnd.Next(40));
            } while (constrParam == testValue.Name);
            FontConfigurationData testParam = new FontConfigurationData(constrParam, testValue.Style, testValue.Filename);

            bool testOutput = testValue.Equals((object)testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void FontConfigurationDataStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterDiffersInStyleProperty()
        {
            FontConfigurationData testValue = GetTestValue();
            UniFontStyles constrParam;
            do
            {
                constrParam = _rnd.NextUniFontStyles();
            } while (constrParam == testValue.Style);
            FontConfigurationData testParam = new FontConfigurationData(testValue.Name, constrParam, testValue.Filename);

            bool testOutput = testValue.Equals((object)testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void FontConfigurationDataStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterDiffersInFilenameProperty()
        {
            FontConfigurationData testValue = GetTestValue();
            string constrParam;
            do
            {
                constrParam = _rnd.NextString(_rnd.Next(40));
            } while (constrParam == testValue.Filename);
            FontConfigurationData testParam = new FontConfigurationData(testValue.Name, testValue.Style, constrParam);

            bool testOutput = testValue.Equals((object)testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void FontConfigurationDataStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterIsString()
        {
            FontConfigurationData testValue = GetTestValue();
            string testParam = testValue.Name;

            bool testOutput = testValue.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void FontConfigurationDataStruct_GetHashCodeMethod_ReturnsSameValue_IfCalledTwiceOnSameValue()
        {
            FontConfigurationData testValue0 = GetTestValue();
            FontConfigurationData testValue1 = new FontConfigurationData(testValue0.Name, testValue0.Style, testValue0.Filename);

            int testOutput0 = testValue0.GetHashCode();
            int testOutput1 = testValue1.GetHashCode();

            Assert.AreEqual(testOutput0, testOutput1);
        }

        [TestMethod]
        public void FontConfigurationDataStruct_EqualityOperator_ReturnsTrue_IfOperandsAreSameValue()
        {
            FontConfigurationData testValue = GetTestValue();

#pragma warning disable CS1718 // Comparison made to same variable
            bool testOutput = testValue == testValue;
#pragma warning restore CS1718 // Comparison made to same variable

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void FontConfigurationDataStruct_EqualityOperator_ReturnsTrue_IfOperandsAreConstructedFromSameData()
        {
            FontConfigurationData testValue = GetTestValue();
            FontConfigurationData testParam = new FontConfigurationData(testValue.Name, testValue.Style, testValue.Filename);

            bool testOutput = testValue == testParam;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void FontConfigurationDataStruct_EqualityOperator_ReturnsFalse_IfOperandsDifferInNameProperty()
        {
            FontConfigurationData testValue = GetTestValue();
            string constrParam;
            do
            {
                constrParam = _rnd.NextString(_rnd.Next(40));
            } while (constrParam == testValue.Name);
            FontConfigurationData testParam = new FontConfigurationData(constrParam, testValue.Style, testValue.Filename);

            bool testOutput = testValue == testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void FontConfigurationDataStruct_EqualityOperator_ReturnsFalse_IfOperandsDifferInStyleProperty()
        {
            FontConfigurationData testValue = GetTestValue();
            UniFontStyles constrParam;
            do
            {
                constrParam = _rnd.NextUniFontStyles();
            } while (constrParam == testValue.Style);
            FontConfigurationData testParam = new FontConfigurationData(testValue.Name, constrParam, testValue.Filename);

            bool testOutput = testValue == testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void FontConfigurationDataStruct_EqualityOperator_ReturnsFalse_IfOperandsDifferInFilenameProperty()
        {
            FontConfigurationData testValue = GetTestValue();
            string constrParam;
            do
            {
                constrParam = _rnd.NextString(_rnd.Next(40));
            } while (constrParam == testValue.Filename);
            FontConfigurationData testParam = new FontConfigurationData(testValue.Name, testValue.Style, constrParam);

            bool testOutput = testValue == testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void FontConfigurationDataStruct_InequalityOperator_ReturnsFalse_IfOperandsAreSameValue()
        {
            FontConfigurationData testValue = GetTestValue();

#pragma warning disable CS1718 // Comparison made to same variable
            bool testOutput = testValue != testValue;
#pragma warning restore CS1718 // Comparison made to same variable

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void FontConfigurationDataStruct_InequalityOperator_ReturnsFalse_IfOperandsAreConstructedFromSameData()
        {
            FontConfigurationData testValue = GetTestValue();
            FontConfigurationData testParam = new FontConfigurationData(testValue.Name, testValue.Style, testValue.Filename);

            bool testOutput = testValue != testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void FontConfigurationDataStruct_InequalityOperator_ReturnsTrue_IfOperandsDifferInNameProperty()
        {
            FontConfigurationData testValue = GetTestValue();
            string constrParam;
            do
            {
                constrParam = _rnd.NextString(_rnd.Next(40));
            } while (constrParam == testValue.Name);
            FontConfigurationData testParam = new FontConfigurationData(constrParam, testValue.Style, testValue.Filename);

            bool testOutput = testValue != testParam;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void FontConfigurationDataStruct_InequalityOperator_ReturnsTrue_IfOperandsDifferInStyleProperty()
        {
            FontConfigurationData testValue = GetTestValue();
            UniFontStyles constrParam;
            do
            {
                constrParam = _rnd.NextUniFontStyles();
            } while (constrParam == testValue.Style);
            FontConfigurationData testParam = new FontConfigurationData(testValue.Name, constrParam, testValue.Filename);

            bool testOutput = testValue != testParam;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void FontConfigurationDataStruct_InequalityOperator_ReturnsTrue_IfOperandsDifferInFilenameProperty()
        {
            FontConfigurationData testValue = GetTestValue();
            string constrParam;
            do
            {
                constrParam = _rnd.NextString(_rnd.Next(40));
            } while (constrParam == testValue.Filename);
            FontConfigurationData testParam = new FontConfigurationData(testValue.Name, testValue.Style, constrParam);

            bool testOutput = testValue != testParam;

            Assert.IsTrue(testOutput);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
