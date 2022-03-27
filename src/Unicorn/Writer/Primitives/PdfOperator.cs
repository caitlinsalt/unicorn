using System;
using System.Collections.Generic;
using System.Text;
using Unicorn.Base;
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
            => new PdfOperator("re")
                .AddOperand(xBottomLeft, nameof(xBottomLeft))
                .AddOperand(yBottomLeft, nameof(yBottomLeft))
                .AddOperand(width, nameof(width))
                .AddOperand(height, nameof(height));

        /// <summary>
        /// Create an instance of the "l" operator, for appending a straight line segment to a path.
        /// </summary>
        /// <param name="x">The X coordinate of the end of the line segment.</param>
        /// <param name="y">The Y coordinate of the end of the line segment.</param>
        /// <returns>A <see cref="PdfOperator" /> instance which contains the specified operator.</returns>
        public static PdfOperator AppendStraightLine(PdfNumber x, PdfNumber y) => new PdfOperator("l").AddOperand(x, nameof(x)).AddOperand(y, nameof(y));

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
                    throw new ArgumentException(WriterResources.Primitives_PdfOperator_LineDashPattern_Content_Error, nameof(pattern));
                }
            }
            if (start.Value > pattern.Length)
            {
                throw new ArgumentException(WriterResources.Primitives_PdfOperator_LineDashPattern_Index_Too_High_Error);
            }

            return new PdfOperator("d").AddOperand(pattern, nameof(pattern)).AddOperand(start, nameof(start));
        }

        /// <summary>
        /// Create an instance of the "w" operator, for setting the current line width.
        /// </summary>
        /// <param name="width">The value to set as the current line width.</param>
        /// <returns>A <see cref="PdfOperator" /> instance for setting the current line width.</returns>
        public static PdfOperator LineWidth(PdfNumber width) => new PdfOperator("w").AddOperand(width, nameof(width));

        /// <summary>
        /// Create an instance of the "m" operator, for starting a new path or subpath.
        /// </summary>
        /// <param name="x">The X coordinate of the starting point.</param>
        /// <param name="y">The Y coordinate of the starting point.</param>
        /// <returns>A <see cref="PdfOperator" /> instance for starting a new subpath.</returns>
        public static PdfOperator StartPath(PdfNumber x, PdfNumber y) => new PdfOperator("m").AddOperand(x, nameof(x)).AddOperand(y, nameof(y));

        private static readonly Lazy<PdfOperator> _strokeOperator = new Lazy<PdfOperator>(() => new PdfOperator("S"));

        /// <summary>
        /// Create an instance of the "S" operator, for stroking and ending a path.
        /// </summary>
        /// <returns>A <see cref="PdfOperator" /> instance representing the S operator.</returns>
        public static PdfOperator StrokePath() => _strokeOperator.Value;

        private static readonly Lazy<PdfOperator> _fillAndStrokeOperator = new Lazy<PdfOperator>(() => new PdfOperator("B"));

        /// <summary>
        /// Create an instance of the "B" operator, for filling, stroking and ending a path using the non-zero winding number filling rule..
        /// </summary>
        /// <returns>A <see cref="PdfOperator" /> instance representing the B operator.</returns>
        public static PdfOperator FillAndStrokePath() => _fillAndStrokeOperator.Value;

        private static readonly Lazy<PdfOperator> _beginTextOperator = new Lazy<PdfOperator>(() => new PdfOperator("BT"));

        /// <summary>
        /// Get an instance of the "BT" operator, for starting a text object.
        /// </summary>
        /// <returns>A <see cref="PdfOperator" /> instance representing the BT operator.</returns>
        public static PdfOperator StartText() => _beginTextOperator.Value;

        private static readonly Lazy<PdfOperator> _endTextOperator = new Lazy<PdfOperator>(() => new PdfOperator("ET"));

        /// <summary>
        /// Get an instance of the "ET" operator, for ending a text object.
        /// </summary>
        /// <returns>A <see cref="PdfOperator" /> instance representing the ET operator.</returns>
        public static PdfOperator EndText() => _endTextOperator.Value;

        /// <summary>
        /// Create an instance of the "Tf" operator, for setting the current text font.
        /// </summary>
        /// <param name="internalFontName">The "internal name" of the font, as referenced in the resource dictionary of the current page.</param>
        /// <param name="pointSize">The point size of the font.</param>
        /// <returns>A <see cref="PdfOperator" /> instance representing a "Tf" operator and its operands.</returns>
        public static PdfOperator SetTextFont(PdfName internalFontName, PdfNumber pointSize)
            => new PdfOperator("Tf").AddOperand(internalFontName, nameof(internalFontName)).AddOperand(pointSize, nameof(pointSize));

        /// <summary>
        /// Create an instance of the "Td" operator, for setting the origin coordinates of the start of the current line of text.
        /// </summary>
        /// <param name="x">The x-coordinate operand.</param>
        /// <param name="y">The y-coordinate operand.</param>
        /// <returns>A <see cref="PdfOperator" /> instance representing a "Td" operator and its operands.</returns>
        public static PdfOperator SetTextLocation(PdfNumber x, PdfNumber y) 
            => new PdfOperator("Td").AddOperand(x, nameof(x)).AddOperand(y, nameof(y));

        /// <summary>
        /// Create an instance of the "Tj" operator, for drawing text.
        /// </summary>
        /// <param name="str">The text to draw.</param>
        /// <returns>A <see cref="PdfOperator" /> instance representing a "Tj" operator and its operand.</returns>
        public static PdfOperator DrawText(PdfByteString str) => new PdfOperator("Tj").AddOperand(str, nameof(str));

        /// <summary>
        /// Create an instance of the "Do" operator, for drawing objects.
        /// </summary>
        /// <param name="objName">The name of the object to draw.</param>
        /// <returns>A <see cref="PdfOperator"/> instance representing a "Do" operator and its operand.</returns>
        public static PdfOperator DrawObject(PdfName objName) => new PdfOperator("Do").AddOperand(objName, nameof(objName));

        /// <summary>
        /// Create an instance of the "cm" operator, for applying a transformation matrix to the graphics state.
        /// </summary>
        /// <param name="transformationMatrix"></param>
        /// <returns></returns>
        public static PdfOperator ApplyTransformation(UniMatrix transformationMatrix) => new PdfOperator("cm").AddOperands(transformationMatrix.ToPdfRealArray());

        /// <summary>
        /// Create an instance of the "G" operator, for setting the current stroking colour to a colour in the device-dependent grey scale colour space.
        /// </summary>
        /// <param name="greyLevel">The grey level of the new colour.</param>
        /// <returns>A <see cref="PdfOperator" /> instance representing a "G" operator and its operand.</returns>
        /// <exception cref="ArgumentNullException"><c>greyLevel</c> is <c>null</c>.</exception>
        public static PdfOperator SetDeviceGreyscaleStrokingColour(PdfNumber greyLevel) => new PdfOperator("G").AddOperand(greyLevel, nameof(greyLevel));

        /// <summary>
        /// Create an instance of the "g" operator, for setting the current non-stroking colour to a colour in the device-dependent grey scale colour space.
        /// </summary>
        /// <param name="greyLevel">The grey level of the new colour.</param>
        /// <returns>A <see cref="PdfOperator" /> instance representing a "g" operator and its operand.</returns>
        /// <exception cref="ArgumentNullException"><c>greyLevel</c> is <c>null</c>.</exception>
        public static PdfOperator SetDeviceGreyscaleNonStrokingColour(PdfNumber greyLevel) => new PdfOperator("g").AddOperand(greyLevel, nameof(greyLevel));

        /// <summary>
        /// Create an instance of the "RG" operator, for setting the current stroking colour to a colour in the device-dependent RGB colour space.
        /// </summary>
        /// <param name="red">The red level of the new colour.</param>
        /// <param name="green">The green level of the new colour.</param>
        /// <param name="blue">The blue level of the new colour.</param>
        /// <returns>A <see cref="PdfOperator" /> instance representing an "RG" operator and its operands.</returns>
        /// <exception cref="ArgumentNullException">One or more of the parameters is <c>null</c>.</exception>
        public static PdfOperator SetDeviceRgbStrokingColour(PdfNumber red, PdfNumber green, PdfNumber blue) => SetDeviceRgbOperator("RG", red, green, blue);

        /// <summary>
        /// Create an instance of the "rg" operator, for setting the current non-stroking colour to a colour in the device-dependent RGB colour space.
        /// </summary>
        /// <param name="red">The red level of the new colour.</param>
        /// <param name="green">The green level of the new colour.</param>
        /// <param name="blue">The blue level of the new colour.</param>
        /// <returns>A <see cref="PdfOperator" /> instance representing an "rg" operator and its operands.</returns>
        /// <exception cref="ArgumentNullException">One or more of the parameters is <c>null</c>.</exception>
        public static PdfOperator SetDeviceRgbNonStrokingColour(PdfNumber red, PdfNumber green, PdfNumber blue) => SetDeviceRgbOperator("rg", red, green, blue);

        private static PdfOperator SetDeviceRgbOperator(string opName, PdfNumber red, PdfNumber green, PdfNumber blue)
            => new PdfOperator(opName)
                .AddOperand(red, nameof(red))
                .AddOperand(green, nameof(green))
                .AddOperand(blue, nameof(blue));

        /// <summary>
        /// Create an instance of the "K" operator, for setting the current stroking colour to a colour in the device-dependent CMYK colour space.
        /// </summary>
        /// <param name="cyan">The cyan level of the new colour.</param>
        /// <param name="magenta">The magenta level of the new colour.</param>
        /// <param name="yellow">The yellow level of the new colour.</param>
        /// <param name="black">The black level of the new colour.</param>
        /// <returns>A <see cref="PdfOperator" /> instance representing a "K" operator and its operands.</returns>
        /// <exception cref="ArgumentNullException">One or more of the parameters is <c>null</c>.</exception>
        public static PdfOperator SetDeviceCmykStrokingColour(PdfNumber cyan, PdfNumber magenta, PdfNumber yellow, PdfNumber black)
            => SetDeviceCmykOperator("K", cyan, magenta, yellow, black);

        /// <summary>
        /// Create an instance of the "k" operator, for setting the current non-stroking colour to a colour in the device-dependent CMYK colour space.
        /// </summary>
        /// <param name="cyan">The cyan level of the new colour.</param>
        /// <param name="magenta">The magenta level of the new colour.</param>
        /// <param name="yellow">The yellow level of the new colour.</param>
        /// <param name="black">The black level of the new colour.</param>
        /// <returns>A <see cref="PdfOperator" /> instance representing a "k" operator and its operands.</returns>
        /// <exception cref="ArgumentNullException">One or more of the parameters is <c>null</c>.</exception>
        public static PdfOperator SetDeviceCmykNonStrokingColour(PdfNumber cyan, PdfNumber magenta, PdfNumber yellow, PdfNumber black)
            => SetDeviceCmykOperator("k", cyan, magenta, yellow, black);

        private static PdfOperator SetDeviceCmykOperator(string opName, PdfNumber cyan, PdfNumber magenta, PdfNumber yellow, PdfNumber black)
            => new PdfOperator(opName)
                .AddOperand(cyan, nameof(cyan))
                .AddOperand(magenta, nameof(magenta))
                .AddOperand(yellow, nameof(yellow))
                .AddOperand(black, nameof(black));

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
        /// A read-only copy of this operator's current operands.
        /// </summary>
        public IReadOnlyList<PdfSimpleObject> Operands => _operands.ToArray();

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

        private PdfOperator AddOperand(PdfSimpleObject operand, string operandName)
        {
            if (operand is null)
            {
                throw new ArgumentNullException(operandName);
            }
            _operands.Add(operand);
            return this;
        }

        private PdfOperator AddOperands(IEnumerable<PdfSimpleObject> operands)
        {
            _operands.AddRange(operands);
            return this;
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
