using System;
using Unicorn.Writer.Interfaces;
using Unicorn.Writer.Primitives;
using Tests.Utility.Extensions;
using Unicorn.Tests.Unit.TestHelpers.Mocks;
using System.Collections.Generic;
using System.Linq;
using Unicorn.Base;

namespace Unicorn.Tests.Unit.TestHelpers
{
    internal static class RandomExtensions
    {
        private static readonly TableRuleStyle[] _validTableRuleStyles =
        {
            TableRuleStyle.None,
            TableRuleStyle.LinesMeet,
            TableRuleStyle.SolidColumnsBrokenRows,
            TableRuleStyle.SolidRowsBrokenColumns,
        };

#pragma warning disable CA5394 // Do not use insecure randomness

        internal static TableRuleStyle NextTableRuleStyle(this Random rnd) 
            => rnd is null ? throw new ArgumentNullException(nameof(rnd)) : rnd.FromSet(_validTableRuleStyles);

        internal static FixedSizeTableCell NextFixedSizeTableCell(this Random rnd)
            => rnd is null ? throw new ArgumentNullException(nameof(rnd)) : new FixedSizeTableCell(rnd.NextDouble() * 100, rnd.NextDouble() * 100);

        public static IPdfPrimitiveObject NextPdfPrimitive(this Random rnd)
        {
            if (rnd is null)
            {
                throw new ArgumentNullException(nameof(rnd));
            }
            int selector = rnd.Next(8);
            return selector switch
            {
                1 => rnd.NextPdfInteger(),
                2 => rnd.NextPdfName(),
                3 => rnd.NextPdfNull(),
                4 => rnd.NextPdfReal(),
                5 => rnd.NextPdfRectangle(),
                6 => rnd.NextPdfString(rnd.Next(32) + 1),
                7 => rnd.NextPdfByteString(rnd.Next(32)),
                _ => rnd.NextPdfBoolean(),
            };
        }

        public static PdfNumber NextPdfNumber(this Random rnd)
        {
            if (rnd is null)
            {
                throw new ArgumentNullException(nameof(rnd));
            }
            if (rnd.NextBoolean())
            {
                return rnd.NextPdfInteger();
            }
            return rnd.NextPdfReal();
        }

        public static PdfArray NextPdfArray(this Random rnd, int max = 6)
        {
            if (rnd is null)
            {
                throw new ArgumentNullException(nameof(rnd));
            }
            int count = rnd.Next(max);
            IPdfPrimitiveObject[] elements = new IPdfPrimitiveObject[count];
            for (int i = 0; i < count; ++i)
            {
                elements[i] = NextPdfPrimitive(rnd);
            }
            return new PdfArray(elements);
        }

        public static PdfArray NextPdfArrayOfNumber(this Random rnd, int max = 6)
        {
            if (rnd is null)
            {
                throw new ArgumentNullException(nameof(rnd));
            }
            int count = rnd.Next(max);
            PdfNumber[] elements = new PdfNumber[count];
            for (int i = 0; i < count; ++i)
            {
                elements[i] = NextPdfNumber(rnd);
            }
            return new PdfArray(elements);
        }

        public static PdfBoolean NextPdfBoolean(this Random rnd) => PdfBoolean.Get(rnd.NextBoolean());

        public static PdfInteger NextPdfInteger(this Random rnd) => rnd is null ? throw new ArgumentNullException(nameof(rnd)) : new PdfInteger(rnd.Next());

        public static PdfInteger NextPdfInteger(this Random rnd, int maxValue)
            => rnd is null ? throw new ArgumentNullException(nameof(rnd)) : new PdfInteger(rnd.Next(maxValue));

        public static PdfInteger NextPdfInteger(this Random rnd, int minValue, int maxValue)
            => rnd is null ? throw new ArgumentNullException(nameof(rnd)) : new PdfInteger(rnd.Next(minValue, maxValue));

        public static PdfName NextPdfName(this Random rnd)
            => rnd is null ? throw new ArgumentNullException(nameof(rnd)) : new PdfName(rnd.NextAlphabeticalString(rnd.Next(1, 17)));

#pragma warning disable IDE0060 // We're only really providing this for consistency.
        public static PdfNull NextPdfNull(this Random rnd) => PdfNull.Value;
#pragma warning restore IDE0060

        public static PdfReal NextPdfReal(this Random rnd)
        {
            if (rnd is null)
            {
                throw new ArgumentNullException(nameof(rnd));
            }

            // The offset and multiplier here are arbitrary amounts that are within the range likely to be seen on a PDF - 5,000 points is just over 176cm.
            return new PdfReal(rnd.NextDouble() * 1000 - 5000);
        }

        public static PdfRectangle NextPdfRectangle(this Random rnd)
        {
            if (rnd is null)
            {
                throw new ArgumentNullException(nameof(rnd));
            }

            // See NextPdfReal() for a note on why these multipliers and offsets were chosen.
            double leftX = rnd.NextDouble() * 1000 - 5000;
            double bottomY = rnd.NextDouble() * 1000 - 5000;
            double width = rnd.NextDouble() * 500;
            double height = rnd.NextDouble() * 500;
            return new PdfRectangle(leftX, bottomY, leftX + width, bottomY + height);
        }

        public static PdfString NextPdfString(this Random rnd, int len) => new(rnd.NextString(len));

        public static PdfByteString NextPdfByteString(this Random rnd, int len)
        {
            if (rnd is null)
            {
                throw new ArgumentNullException(nameof(rnd));
            }
            byte[] data = new byte[len];
            rnd.NextBytes(data);
            return new PdfByteString(data);
        }

        public static RgbColour NextRgbColour(this Random rnd)
            => rnd is null ? throw new ArgumentNullException(nameof(rnd)) : new RgbColour(rnd.NextDouble(), rnd.NextDouble(), rnd.NextDouble());

        public static GreyscaleColour NextGreyscaleColour(this Random rnd)
            => rnd is null ? throw new ArgumentNullException(nameof(rnd)) : new GreyscaleColour(rnd.NextDouble());

        public static CmykColour NextCmykColour(this Random rnd)
            => rnd is null ? throw new ArgumentNullException(nameof(rnd)) : new CmykColour(rnd.NextDouble(), rnd.NextDouble(), rnd.NextDouble(), rnd.NextDouble());

        private static Orientation[] _validOrientations = 
            new[] { Orientation.Normal, Orientation.RotatedLeft, Orientation.RotatedRight, Orientation.UpsideDown, Orientation.Freestyle };

        public static Orientation NextOrientation(this Random rnd)
            => rnd is null ? throw new ArgumentNullException(nameof(rnd)) : rnd.FromSet(_validOrientations);

        public static MarginSet NextMarginSet(this Random rnd)
            => rnd is null ? throw new ArgumentNullException(nameof(rnd)) : new(rnd.NextDouble(10), rnd.NextDouble(10), rnd.NextDouble(10), rnd.NextDouble(10));

        public static MockWord NextMockWord(this Random rnd)
        {
            if (rnd is null)
            {
                throw new ArgumentNullException(nameof(rnd));
            }
            double contentWidth = rnd.NextDouble(20);
            double postSpace = rnd.NextDouble(10);
            return new(contentWidth, contentWidth + postSpace, rnd.NextDouble(10), rnd.NextDouble(10));
        }

        public static Line NextLineUnderWidth(this Random rnd, double maxWidth)
        {
            if (rnd is null)
            {
                throw new ArgumentNullException(nameof(rnd));
            }
            if (maxWidth <= 0)
            {
                throw new ArgumentException("Maximum width cannot be zero or negative", nameof(maxWidth));
            }
            List<IWord> mockWords = new();
            while (true)
            {
                IWord word = rnd.NextMockWord();
                if (mockWords.Sum(w => w.MinWidth) + word.MinWidth > maxWidth)
                {
                    if (mockWords.Any())
                    {
                        return new Line(mockWords);
                    }
                }
                else
                {
                    mockWords.Add(word);
                }
            }
        }

        public static Line NextLineOverWidth(this Random rnd, double minWidth)
        {
            if (rnd is null)
            {
                throw new ArgumentNullException(nameof(rnd));
            }
            List<IWord> mockWords = new();
            do
            {
                mockWords.Add(rnd.NextMockWord());
            } while (mockWords.Take(mockWords.Count - 1).Sum(w => w.MinWidth) + mockWords.Last().ContentWidth < minWidth);
            return new Line(mockWords);
        }

        public static MockPositionedKnownSizeDrawable NextMockPositionedKnownSizeDrawable(this Random rnd)
        {
            if (rnd is null)
            {
                throw new ArgumentNullException(nameof(rnd));
            }
            return new MockPositionedKnownSizeDrawable(rnd.NextDouble(50), rnd.NextDouble(50), rnd.NextDouble(50), rnd.NextDouble(50));
        }

#pragma warning restore CA5394 // Do not use insecure randomness

    }
}
