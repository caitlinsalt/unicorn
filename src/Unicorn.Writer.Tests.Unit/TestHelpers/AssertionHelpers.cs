using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unicorn.Writer.Primitives;

namespace Unicorn.Writer.Tests.Unit.TestHelpers
{
    public static class AssertionHelpers
    {
        public static void AssertSameElements(byte[] a, byte[] b)
        {
            if (ReferenceEquals(a, b))
            {
                return;
            }
            if (a is null)
            {
                throw new ArgumentNullException(nameof(a));
            }
            if (b is null)
            {
                throw new ArgumentNullException(nameof(b));
            }

            Assert.AreEqual(a.Length, b.Length);
            for (int i = 0; i < a.Length; ++i)
            {
                Assert.AreEqual(a[i], b[i]);
            }
        }

        public static void AssertSameElements(IList<byte> a, IList<byte> b)
        {
            if (ReferenceEquals(a, b))
            {
                return;
            }
            if (a is null)
            {
                throw new ArgumentNullException(nameof(a));
            }
            if (b is null)
            {
                throw new ArgumentNullException(nameof(b));
            }

            AssertSameElements(a.ToArray(), b.ToArray());
        }

        public static void AssertSameElements(MemoryStream a, MemoryStream b)
        {
            if (ReferenceEquals(a, b))
            {
                return;
            }
            if (a is null)
            {
                throw new ArgumentNullException(nameof(a));
            }
            if (b is null)
            {
                throw new ArgumentNullException(nameof(b));
            }

            Assert.AreEqual(a.Length, b.Length);
            byte[] arrA = a.ToArray();
            byte[] arrB = b.ToArray();
            AssertSameElements(arrA, arrB);
        }

        public static void AssertSameElements(IList<byte> a, PdfStream b)
        {
            if (a is null && b is null)
            {
                return;
            }
            if (a is null)
            {
                throw new ArgumentNullException(nameof(a));
            }
            if (b is null)
            {
                throw new ArgumentNullException(nameof(b));
            }

            AssertSameElements(a, b.Contents);
        }
    }
}
