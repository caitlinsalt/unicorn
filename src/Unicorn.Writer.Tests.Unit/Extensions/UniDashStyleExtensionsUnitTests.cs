using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Providers;
using Unicorn.CoreTypes;
using Unicorn.CoreTypes.Tests.Utility.Extensions;
using Unicorn.Writer.Extensions;
using Unicorn.Writer.Interfaces;
using Unicorn.Writer.Primitives;

namespace Unicorn.Writer.Tests.Unit.Extensions
{
    [TestClass]
    public class UniDashStyleExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void UniDashStyleExtensionsClass_ToPdfObjectsMethod_ReturnsArrayOfTwoMembers()
        {
            UniDashStyle testParam0 = _rnd.NextUniDashStyle();
            double testParam1 = _rnd.NextDouble() * 5;

            IPdfPrimitiveObject[] testOutput = testParam0.ToPdfObjects(testParam1);

            Assert.IsNotNull(testOutput);
            Assert.AreEqual(2, testOutput.Length);
        }

        [TestMethod]
        public void UniDashStyleExtensionsClass_ToPdfObjectsMethod_ReturnsArrayWhoseFirstMemberIsPdfArray()
        {
            UniDashStyle testParam0 = _rnd.NextUniDashStyle();
            double testParam1 = _rnd.NextDouble() * 5;

            IPdfPrimitiveObject[] testOutput = testParam0.ToPdfObjects(testParam1);

            Assert.IsTrue(testOutput[0] is PdfArray);
        }

        [TestMethod]
        public void UniDashStyleExtensionsClass_ToPdfObjectsMethod_ReturnsArrayWhoseSecondMemberIsPdfInteger()
        {
            UniDashStyle testParam0 = _rnd.NextUniDashStyle();
            double testParam1 = _rnd.NextDouble() * 5;

            IPdfPrimitiveObject[] testOutput = testParam0.ToPdfObjects(testParam1);

            Assert.IsTrue(testOutput[1] is PdfInteger);
        }

        [TestMethod]
        public void UniDashStyleExtensionsClass_ToPdfObjectsMethod_ReturnsArrayWhoseSecondMemberHasValueZero()
        {
            UniDashStyle testParam0 = _rnd.NextUniDashStyle();
            double testParam1 = _rnd.NextDouble() * 5;

            IPdfPrimitiveObject[] testOutput = testParam0.ToPdfObjects(testParam1);

            PdfInteger testItem = testOutput[1] as PdfInteger;
            Assert.IsNotNull(testItem);
            Assert.AreEqual(0, testItem.Value);
        }

        [TestMethod]
        public void UniDashStyleExtensionsClass_ToPdfObjectsMethod_ReturnsArrayWhoseFirstMemberIsPdfArrayWithNoMembers_IfFirstParameterValueIsSolid()
        {
            UniDashStyle testParam0 = UniDashStyle.Solid;
            double testParam1 = _rnd.NextDouble() * 5;

            IPdfPrimitiveObject[] testOutput = testParam0.ToPdfObjects(testParam1);

            PdfArray testItem = testOutput[0] as PdfArray;
            Assert.AreEqual(0, testItem.Length);
        }

        [TestMethod]
        public void UniDashStyleExtensionsClass_ToPdfObjectsMethod_ReturnsArrayWhoseFirstMemberIsPdfArrayWithTwoMembers_IfFirstParameterValueIsDash()
        {
            UniDashStyle testParam0 = UniDashStyle.Dash;
            double testParam1 = _rnd.NextDouble() * 5;

            IPdfPrimitiveObject[] testOutput = testParam0.ToPdfObjects(testParam1);

            PdfArray testItem = testOutput[0] as PdfArray;
            Assert.AreEqual(2, testItem.Length);
        }

        [TestMethod]
        public void UniDashStyleExtensionsClass_ToPdfObjectsMethod_ReturnsArrayWhoseFirstMemberIsPdfArrayWhoseFirstMemberIsPdfRealWhoseValueIsThreeTimesSecondParameter_IfFirstParameterValueIsDash()
        {
            UniDashStyle testParam0 = UniDashStyle.Dash;
            double testParam1 = _rnd.NextDouble() * 5;

            IPdfPrimitiveObject[] testOutput = testParam0.ToPdfObjects(testParam1);

            PdfArray testItem0 = testOutput[0] as PdfArray;
            PdfReal testItem1 = testItem0[0] as PdfReal;
            Assert.AreEqual(testParam1 * 3, (double)testItem1.Value, 0.000000001);
        }

        [TestMethod]
        public void UniDashStyleExtensionsClass_ToPdfObjectsMethod_ReturnsArrayWhoseFirstMemberIsPdfArrayWhoseSecondMemberIsPdfRealWhoseValueIsEqualToSecondParameter_IfFirstParameterValueIsDash()
        {
            UniDashStyle testParam0 = UniDashStyle.Dash;
            double testParam1 = _rnd.NextDouble() * 5;

            IPdfPrimitiveObject[] testOutput = testParam0.ToPdfObjects(testParam1);

            PdfArray testItem0 = testOutput[0] as PdfArray;
            PdfReal testItem1 = testItem0[1] as PdfReal;
            Assert.AreEqual(testParam1, (double)testItem1.Value, 0.000000001);
        }

        [TestMethod]
        public void UniDashStyleExtensionsClass_ToPdfObjectsMethod_ReturnsArrayWhoseFirstMemberIsPdfArrayWithOneMember_IfFirstParameterValueIsDot()
        {
            UniDashStyle testParam0 = UniDashStyle.Dot;
            double testParam1 = _rnd.NextDouble() * 5;

            IPdfPrimitiveObject[] testOutput = testParam0.ToPdfObjects(testParam1);

            PdfArray testItem = testOutput[0] as PdfArray;
            Assert.AreEqual(1, testItem.Length);
        }

        [TestMethod]
        public void UniDashStyleExtensionsClass_ToPdfObjectsMethod_ReturnsArrayWhoseFirstMemberIsPdfArrayWhoseFirstMemberIsPdfRealWhoseValueIsEqualToSecondParameter_IfFirstParameterValueIsDot()
        {
            UniDashStyle testParam0 = UniDashStyle.Dot;
            double testParam1 = _rnd.NextDouble() * 5;

            IPdfPrimitiveObject[] testOutput = testParam0.ToPdfObjects(testParam1);

            PdfArray testItem0 = testOutput[0] as PdfArray;
            PdfReal testItem1 = testItem0[0] as PdfReal;
            Assert.AreEqual(testParam1, (double)testItem1.Value, 0.000000001);
        }

        [TestMethod]
        public void UniDashStyleExtensionsClass_ToPdfObjectsMethod_ReturnsArrayWhoseFirstMemberIsPdfArrayWithFourMembers_IfFirstParameterValueIsDashDot()
        {
            UniDashStyle testParam0 = UniDashStyle.DashDot;
            double testParam1 = _rnd.NextDouble() * 5;

            IPdfPrimitiveObject[] testOutput = testParam0.ToPdfObjects(testParam1);

            PdfArray testItem = testOutput[0] as PdfArray;
            Assert.AreEqual(4, testItem.Length);
        }

        [TestMethod]
        public void UniDashStyleExtensionsClass_ToPdfObjectsMethod_ReturnsArrayWhoseFirstMemberIsPdfArrayWhoseFirstMemberIsPdfRealWhoseValueIsThreeTimesSecondParameter_IfFirstParameterValueIsDashDot()
        {
            UniDashStyle testParam0 = UniDashStyle.DashDot;
            double testParam1 = _rnd.NextDouble() * 5;

            IPdfPrimitiveObject[] testOutput = testParam0.ToPdfObjects(testParam1);

            PdfArray testItem0 = testOutput[0] as PdfArray;
            PdfReal testItem1 = testItem0[0] as PdfReal;
            Assert.AreEqual(testParam1 * 3, (double)testItem1.Value, 0.000000001);
        }

        [TestMethod]
        public void UniDashStyleExtensionsClass_ToPdfObjectsMethod_ReturnsArrayWhoseFirstMemberIsPdfArrayWhoseSecondMemberIsPdfRealWhoseValueIsEqualToSecondParameter_IfFirstParameterValueIsDashDot()
        {
            UniDashStyle testParam0 = UniDashStyle.DashDot;
            double testParam1 = _rnd.NextDouble() * 5;

            IPdfPrimitiveObject[] testOutput = testParam0.ToPdfObjects(testParam1);

            PdfArray testItem0 = testOutput[0] as PdfArray;
            PdfReal testItem1 = testItem0[1] as PdfReal;
            Assert.AreEqual(testParam1, (double)testItem1.Value, 0.000000001);
        }

        [TestMethod]
        public void UniDashStyleExtensionsClass_ToPdfObjectsMethod_ReturnsArrayWhoseFirstMemberIsPdfArrayWhoseThirdMemberIsPdfRealWhoseValueIsEqualToSecondParameter_IfFirstParameterValueIsDashDot()
        {
            UniDashStyle testParam0 = UniDashStyle.DashDot;
            double testParam1 = _rnd.NextDouble() * 5;

            IPdfPrimitiveObject[] testOutput = testParam0.ToPdfObjects(testParam1);

            PdfArray testItem0 = testOutput[0] as PdfArray;
            PdfReal testItem1 = testItem0[2] as PdfReal;
            Assert.AreEqual(testParam1, (double)testItem1.Value, 0.000000001);
        }

        [TestMethod]
        public void UniDashStyleExtensionsClass_ToPdfObjectsMethod_ReturnsArrayWhoseFirstMemberIsPdfArrayWhoseFourthMemberIsPdfRealWhoseValueIsEqualToSecondParameter_IfFirstParameterValueIsDashDot()
        {
            UniDashStyle testParam0 = UniDashStyle.DashDot;
            double testParam1 = _rnd.NextDouble() * 5;

            IPdfPrimitiveObject[] testOutput = testParam0.ToPdfObjects(testParam1);

            PdfArray testItem0 = testOutput[0] as PdfArray;
            PdfReal testItem1 = testItem0[3] as PdfReal;
            Assert.AreEqual(testParam1, (double)testItem1.Value, 0.000000001);
        }

        [TestMethod]
        public void UniDashStyleExtensionsClass_ToPdfObjectsMethod_ReturnsArrayWhoseFirstMemberIsPdfArrayWithFourMembers_IfFirstParameterValueIsDashDotDot()
        {
            UniDashStyle testParam0 = UniDashStyle.DashDotDot;
            double testParam1 = _rnd.NextDouble() * 5;

            IPdfPrimitiveObject[] testOutput = testParam0.ToPdfObjects(testParam1);

            PdfArray testItem = testOutput[0] as PdfArray;
            Assert.AreEqual(6, testItem.Length);
        }

        [TestMethod]
        public void UniDashStyleExtensionsClass_ToPdfObjectsMethod_ReturnsArrayWhoseFirstMemberIsPdfArrayWhoseFirstMemberIsPdfRealWhoseValueIsThreeTimesSecondParameter_IfFirstParameterValueIsDashDotDot()
        {
            UniDashStyle testParam0 = UniDashStyle.DashDotDot;
            double testParam1 = _rnd.NextDouble() * 5;

            IPdfPrimitiveObject[] testOutput = testParam0.ToPdfObjects(testParam1);

            PdfArray testItem0 = testOutput[0] as PdfArray;
            PdfReal testItem1 = testItem0[0] as PdfReal;
            Assert.AreEqual(testParam1 * 3, (double)testItem1.Value, 0.000000001);
        }

        [TestMethod]
        public void UniDashStyleExtensionsClass_ToPdfObjectsMethod_ReturnsArrayWhoseFirstMemberIsPdfArrayWhoseSecondMemberIsPdfRealWhoseValueIsEqualToSecondParameter_IfFirstParameterValueIsDashDotDot()
        {
            UniDashStyle testParam0 = UniDashStyle.DashDotDot;
            double testParam1 = _rnd.NextDouble() * 5;

            IPdfPrimitiveObject[] testOutput = testParam0.ToPdfObjects(testParam1);

            PdfArray testItem0 = testOutput[0] as PdfArray;
            PdfReal testItem1 = testItem0[1] as PdfReal;
            Assert.AreEqual(testParam1, (double)testItem1.Value, 0.000000001);
        }

        [TestMethod]
        public void UniDashStyleExtensionsClass_ToPdfObjectsMethod_ReturnsArrayWhoseFirstMemberIsPdfArrayWhoseThirdMemberIsPdfRealWhoseValueIsEqualToSecondParameter_IfFirstParameterValueIsDashDotDot()
        {
            UniDashStyle testParam0 = UniDashStyle.DashDotDot;
            double testParam1 = _rnd.NextDouble() * 5;

            IPdfPrimitiveObject[] testOutput = testParam0.ToPdfObjects(testParam1);

            PdfArray testItem0 = testOutput[0] as PdfArray;
            PdfReal testItem1 = testItem0[2] as PdfReal;
            Assert.AreEqual(testParam1, (double)testItem1.Value, 0.000000001);
        }

        [TestMethod]
        public void UniDashStyleExtensionsClass_ToPdfObjectsMethod_ReturnsArrayWhoseFirstMemberIsPdfArrayWhoseFourthMemberIsPdfRealWhoseValueIsEqualToSecondParameter_IfFirstParameterValueIsDashDotDot()
        {
            UniDashStyle testParam0 = UniDashStyle.DashDotDot;
            double testParam1 = _rnd.NextDouble() * 5;

            IPdfPrimitiveObject[] testOutput = testParam0.ToPdfObjects(testParam1);

            PdfArray testItem0 = testOutput[0] as PdfArray;
            PdfReal testItem1 = testItem0[3] as PdfReal;
            Assert.AreEqual(testParam1, (double)testItem1.Value, 0.000000001);
        }

        [TestMethod]
        public void UniDashStyleExtensionsClass_ToPdfObjectsMethod_ReturnsArrayWhoseFirstMemberIsPdfArrayWhoseFifthMemberIsPdfRealWhoseValueIsEqualToSecondParameter_IfFirstParameterValueIsDashDotDot()
        {
            UniDashStyle testParam0 = UniDashStyle.DashDotDot;
            double testParam1 = _rnd.NextDouble() * 5;

            IPdfPrimitiveObject[] testOutput = testParam0.ToPdfObjects(testParam1);

            PdfArray testItem0 = testOutput[0] as PdfArray;
            PdfReal testItem1 = testItem0[4] as PdfReal;
            Assert.AreEqual(testParam1, (double)testItem1.Value, 0.000000001);
        }

        [TestMethod]
        public void UniDashStyleExtensionsClass_ToPdfObjectsMethod_ReturnsArrayWhoseFirstMemberIsPdfArrayWhoseSixthMemberIsPdfRealWhoseValueIsEqualToSecondParameter_IfFirstParameterValueIsDashDotDot()
        {
            UniDashStyle testParam0 = UniDashStyle.DashDotDot;
            double testParam1 = _rnd.NextDouble() * 5;

            IPdfPrimitiveObject[] testOutput = testParam0.ToPdfObjects(testParam1);

            PdfArray testItem0 = testOutput[0] as PdfArray;
            PdfReal testItem1 = testItem0[5] as PdfReal;
            Assert.AreEqual(testParam1, (double)testItem1.Value, 0.000000001);
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
