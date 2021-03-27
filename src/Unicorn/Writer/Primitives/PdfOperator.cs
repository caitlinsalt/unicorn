using System;
using System.Collections.Generic;
using System.Text;
using Unicorn.CoreTypes;
using Unicorn.Writer.Extensions;

namespace Unicorn.Writer.Primitives
{
    /// <summary>
    /// Immutable class representing a PDF operator.  Operators are similar to names, but are not preceded by a slash when output.
    /// </summary>
    public class PdfOperator : PdfName, IEquatable<PdfOperator>
    {
        /// <summary>
        /// Create an instance of the "re" operator, for appending a rectangle to a path.
        /// </summary>
        /// <param name="xBottomLeft">The X coordinate of the bottom-left corner of the rectangle.</param>
        /// <param name="yBottomLeft">The Y coordinate of the bottom-left corner of the rectangle.</param>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        /// <returns>A <see cref="PdfOperator" /> instance which contains the specified operator.</returns>
        public static PdfOperator AppendRectangle(PdfNumber xBottomLeft, PdfNumber yBottomLeft, PdfNumber width, PdfNumber height)
        {
            if (xBottomLeft is null)
            {
                throw new ArgumentNullException(nameof(xBottomLeft));
            }
            if (yBottomLeft is null)
            {
                throw new ArgumentNullException(nameof(yBottomLeft));
            }
            if (width is null)
            {
                throw new ArgumentNullException(nameof(width));
            }
            if (height is null)
            {
                throw new ArgumentNullException(nameof(height));
            }
            PdfOperator op = new PdfOperator("re");
            op._operands.Add(xBottomLeft);
            op._operands.Add(yBottomLeft);
            op._operands.Add(width);
            op._operands.Add(height);
            return op;
        }

        /// <summary>
        /// Create an instance of the "l" operator, for appending a straight line segment to a path.
        /// </summary>
        /// <param name="x">The X coordinate of the end of the line segment.</param>
        /// <param name="y">The Y coordinate of the end of the line segment.</param>
        /// <returns>A <see cref="PdfOperator" /> instance which contains the specified operator.</returns>
        public static PdfOperator AppendStraightLine(PdfNumber x, PdfNumber y)
        {
            if (x is null)
            {
                throw new ArgumentNullException(nameof(x));
            }
            if (y is null)
            {
                throw new ArgumentNullException(nameof(y));
            }
            PdfOperator op = new PdfOperator("l");
            op._operands.Add(x);
            op._operands.Add(y);
            return op;
        }

        /// <summary>
        /// Creates an instance of the "d" operator, for setting the current line dash pattern.
        /// </summary>
        /// <param name="pattern">An array containing the dash pattern.</param>
        /// <param name="start">The element of the pattern array to use at the start of the line.</param>
        /// <returns>A <see cref="PdfOperator" /> instance containign the specified operator.</returns>
        public static PdfOperator LineDashPattern(PdfArray pattern, PdfInteger start)
        {
            if (pattern is null)
            {
                throw new ArgumentNullException(nameof(pattern));
            }
            if (start is null)
            {
                throw new ArgumentNullException(nameof(start));
            }
            for (int i = 0; i < pattern.Length; ++i)
            {
                if (!(pattern[i] is PdfNumber))
                {
                    throw new ArgumentException(Resources.Primitives_PdfOperator_LineDashPattern_Content_Error, nameof(pattern));
                }
            }
            if (start.Value > pattern.Length)
            {
                throw new ArgumentException(Resources.Primitives_PdfOperator_LineDashPattern_Index_Too_High_Error);
            }

            PdfOperator op = new PdfOperator("d");
            op._operands.Add(pattern);
            op._operands.Add(start);
            return op;
        }

        /// <summary>
        /// Create an instance of the "w" operator, for setting the current line width.
        /// </summary>
        /// <param name="width">The value to set as the current line width.</param>
        /// <returns>A <see cref="PdfOperator" /> instance for setting the current line width.</returns>
        public static PdfOperator LineWidth(PdfNumber width)
        {
            if (width is null)
            {
                throw new ArgumentNullException(nameof(width));
            }
            PdfOperator op = new PdfOperator("w");
            op._operands.Add(width);
            return op;
        }

        /// <summary>
        /// Create an instance of the "m" operator, for starting a new path or subpath.
        /// </summary>
        /// <param name="x">The X coordinate of the starting point.</param>
        /// <param name="y">The Y coordinate of the starting point.</param>
        /// <returns>A <see cref="PdfOperator" /> instance for starting a new subpath.</returns>
        public static PdfOperator StartPath(PdfNumber x, PdfNumber y)
        {
            if (x is null)
            {
                throw new ArgumentNullException(nameof(x));
            }
            if (y is null)
            {
                throw new ArgumentNullException(nameof(y));
            }
            PdfOperator op = new PdfOperator("m");
            op._operands.Add(x);
            op._operands.Add(y);
            return op;
        }

        private static readonly Lazy<PdfOperator> _strokeOperator = new Lazy<PdfOperator>(() => new PdfOperator("S"));

        /// <summary>
        /// Create an instance of the "S" operator, for stroking and ending a path.
        /// </summary>
        /// <returns>A <see cref="PdfOperator" /> instance representing the S operator.</returns>
        public static PdfOperator StrokePath()
        {
            return _strokeOperator.Value;
        }

        private static readonly Lazy<PdfOperator> _beginTextOperator = new Lazy<PdfOperator>(() => new PdfOperator("BT"));

        /// <summary>
        /// Get an instance of the "BT" operator, for starting a text object.
        /// </summary>
        /// <returns>A <see cref="PdfOperator" /> instance representing the BT operator.</returns>
        public static PdfOperator StartText()
        {
            return _beginTextOperator.Value;
        }

        private static readonly Lazy<PdfOperator> _endTextOperator = new Lazy<PdfOperator>(() => new PdfOperator("ET"));

        /// <summary>
        /// Get an instance of the "ET" operator, for ending a text object.
        /// </summary>
        /// <returns>A <see cref="PdfOperator" /> instance representing the ET operator.</returns>
        public static PdfOperator EndText()
        {
            return _endTextOperator.Value;
        }

        /// <summary>
        /// Create an instance of the "Tf" operator, for setting the current text font.
        /// </summary>
        /// <param name="internalFontName">The "internal name" of the font, as referenced in the resource dictionary of the current page.</param>
        /// <param name="pointSize">The point size of the font.</param>
        /// <returns>A <see cref="PdfOperator" /> instance representing a "Tf" operator and its operands.</returns>
        public static PdfOperator SetTextFont(PdfName internalFontName, PdfNumber pointSize)
        {
            if (internalFontName is null)
            {
                throw new ArgumentNullException(nameof(internalFontName));
            }
            if (pointSize is null)
            {
                throw new ArgumentNullException(nameof(pointSize));
            }
            PdfOperator op = new PdfOperator("Tf");
            op._operands.Add(internalFontName);
            op._operands.Add(pointSize);
            return op;
        }

        /// <summary>
        /// Create an instance of the "Td" operator, for setting the origin coordinates of the start of the current line of text.
        /// </summary>
        /// <param name="x">The x-coordinate operand.</param>
        /// <param name="y">The y-coordinate operand.</param>
        /// <returns>A <see cref="PdfOperator" /> instance representing a "Td" operator and its operands.</returns>
        public static PdfOperator SetTextLocation(PdfNumber x, PdfNumber y)
        {
            if (x is null)
            {
                throw new ArgumentNullException(nameof(x));
            }
            if (y is null)
            {
                throw new ArgumentNullException(nameof(y));
            }
            PdfOperator op = new PdfOperator("Td");
            op._operands.Add(x);
            op._operands.Add(y);
            return op;
        }

        /// <summary>
        /// Create an instance of the "Tj" operator, for drawing text.
        /// </summary>
        /// <param name="str">The text to draw.</param>
        /// <returns>A <see cref="PdfOperator" /> instance representing a "Tj" operator and its operand.</returns>
        public static PdfOperator DrawText(PdfByteString str)
        {
            if (str is null)
            {
                throw new ArgumentNullException(nameof(str));
            }
            PdfOperator op = new PdfOperator("Tj");
            op._operands.Add(str);
            return op;
        }

        /// <summary>
        /// Create an instance of the "cm" operator, for applying a transformation matrix to the graphics state.
        /// </summary>
        /// <param name="transformationMatrix"></param>
        /// <returns></returns>
        public static PdfOperator ApplyTransformation(UniMatrix transformationMatrix)
        {
            PdfOperator op = new PdfOperator("cm");
            op._operands.AddRange(transformationMatrix.ToPdfRealArray());
            return op;
        }

        private static readonly Lazy<PdfOperator> _pushStateOperator = new Lazy<PdfOperator>(() => new PdfOperator("q"));

        /// <summary>
        /// Create an instance of the "q" operator, for pushing the current graphics state.
        /// </summary>
        /// <returns></returns>
        public static PdfOperator PushState() => _pushStateOperator.Value;

        private static readonly Lazy<PdfOperator> _popStateOperator = new Lazy<PdfOperator>(() => new PdfOperator("Q"));

        /// <summary>
        /// Create an instance of the "Q" operator, for popping the current graphics state.
        /// </summary>
        /// <returns></returns>
        public static PdfOperator PopState() => _popStateOperator.Value;

        /// <summary>
        /// Value-setting constructor.
        /// </summary>
        /// <param name="op">The value of the new object.</param>
        /// <exception cref="ArgumentNullException">Thrown if the parameter is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the parameter contains whitespace characters, or characters classed as "delimiters" by the PDF standard.</exception>
        private PdfOperator(string op) : base(op)
        {
            _operands = new List<PdfSimpleObject>();
        }

        private readonly List<PdfSimpleObject> _operands;

        /// <summary>
        /// Convert this object to an array of bytes.
        /// </summary>
        /// <returns>An array of bytes representing this object.</returns>
        protected override byte[] FormatBytes()
        {
            List<byte> output = new List<byte>();
            foreach (PdfSimpleObject operand in _operands)
            {
                operand.WriteTo(output);
            }
            output.AddRange(Encoding.UTF8.GetBytes($"{Value} "));
            return output.ToArray();
        }

        /// <summary>
        /// Equality test method.
        /// </summary>
        /// <param name="other">The object to test against.</param>
        /// <returns>True if the other object has the same value as this; false otherwise.</returns>
        public bool Equals(PdfOperator other)
        {
            if (other is null)
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return Value == other.Value;
        }

        /// <summary>
        /// Equality test method.
        /// </summary>
        /// <param name="obj">The object to test against.</param>
        /// <returns>True if the other object is a <see cref="PdfName" /> instance with the same value as this; false otherwise.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as PdfOperator);
        }

        /// <summary>
        /// Generate a hashcode for this object.
        /// </summary>
        /// <returns>The hashcode of the value of this object.</returns>
        public override int GetHashCode()
        {
            return $"{Value} ".GetHashCode();
        } 

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="a">A <see cref="PdfOperator" /> instance.</param>
        /// <param name="b">Another <see cref="PdfOperator" /> instance.</param>
        /// <returns>True if the parameters are equal; false otherwise.</returns>
        public static bool operator ==(PdfOperator a, PdfOperator b)
        {
            if (ReferenceEquals(a, b))
            {
                return true;
            }
            if (a is null || b is null)
            {
                return false;
            }
            return a.Value == b.Value;
        }

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="a">A <see cref="PdfOperator" /> instance.</param>
        /// <param name="b">Another <see cref="PdfOperator" /> instance.</param>
        /// <returns>True if the parameters are unequal; false otherwise.</returns>
        public static bool operator !=(PdfOperator a, PdfOperator b)
        {
            if (ReferenceEquals(a, b))
            {
                return false;
            }
            if (a == null || b == null)
            {
                return true;
            }
            return a.Value != b.Value;
        }
    }
}
