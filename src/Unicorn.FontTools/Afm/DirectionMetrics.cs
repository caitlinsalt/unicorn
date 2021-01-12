using System;
using System.Collections.Generic;

namespace Unicorn.FontTools.Afm
{
    /// <summary>
    /// Font metrics that are specific to a writing direction.
    /// </summary>
    public struct DirectionMetrics : IEquatable<DirectionMetrics>
    {
        /// <summary>
        /// Underline displacement from the font baseline.
        /// </summary>
        public decimal? UnderlinePosition { get; private set; }

        /// <summary>
        /// Underline stroke thickness.
        /// </summary>
        public decimal? UnderlineThickness { get; private set; }

        /// <summary>
        /// Italic stroke angle (anticlockwise from vertical)
        /// </summary>
        public decimal? ItalicAngle { get; private set; }

        /// <summary>
        /// Character width vector for monospaced fonts.
        /// </summary>
        public Vector? CharWidth { get; private set; }

        /// <summary>
        /// Whether or not this font is a monospaced font.
        /// </summary>
        public bool IsFixedPitch { get; private set; }

        internal DirectionMetrics(decimal? underlinePos, decimal? underlineThickness, decimal? italicAngle, Vector? charWidth, bool? fixedPitch)
        {
            UnderlinePosition = underlinePos;
            UnderlineThickness = underlineThickness;
            ItalicAngle = italicAngle;
            CharWidth = charWidth;
            IsFixedPitch = fixedPitch ?? CharWidth.HasValue;
        }

        /// <summary>
        /// Equality-testing method.
        /// </summary>
        /// <param name="other">Another <see cref="DirectionMetrics" /> value to compare against.</param>
        /// <returns><c>true</c> if all properties of the two values are equal, <c>false</c> if not.</returns>
        public bool Equals(DirectionMetrics other)
        {
            return this == other;
        }

        /// <summary>
        /// Equality-testing method.
        /// </summary>
        /// <param name="obj">Another object or value.</param>
        /// <returns><c>true</c> if the parameter is another <see cref="DirectionMetrics" /> value that is equal to this one; <c>false</c> otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is DirectionMetrics other))
            {
                return false;
            }
            return Equals(other);
        }

        /// <summary>
        /// Generate a hash code for this value.
        /// </summary>
        /// <returns>A hash code derived from this value.</returns>
        public override int GetHashCode()
        {
            return UnderlinePosition.GetHashCode() ^ UnderlineThickness.GetHashCode() ^ ItalicAngle.GetHashCode() ^ CharWidth.GetHashCode() ^ IsFixedPitch.GetHashCode();
        }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="a">A <see cref="DirectionMetrics"/> value.</param>
        /// <param name="b">Another <see cref="DirectionMetrics" /> value.</param>
        /// <returns><c>true</c> if the operands are equal, <c>false</c> otherwise.</returns>
        public static bool operator ==(DirectionMetrics a, DirectionMetrics b)
        {
            return a.UnderlineThickness == b.UnderlineThickness && a.UnderlinePosition == b.UnderlinePosition && a.ItalicAngle == b.ItalicAngle && 
                a.CharWidth == b.CharWidth && a.IsFixedPitch == b.IsFixedPitch;
        }

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="a">A <see cref="DirectionMetrics" /> value.</param>
        /// <param name="b">Another <see cref="DirectionMetrics"/> value.</param>
        /// <returns><c>true</c> if the operands are not equal, <c>false</c> if they are.</returns>
        public static bool operator !=(DirectionMetrics a, DirectionMetrics b)
        {
            return a.UnderlineThickness != b.UnderlineThickness || a.UnderlinePosition != b.UnderlinePosition || a.ItalicAngle != b.ItalicAngle ||
                a.CharWidth != b.CharWidth || a.IsFixedPitch != b.IsFixedPitch;
        }

        /// <summary>
        /// Create a <see cref="DirectionMetrics" /> value from a set of lines each consisting of a key and a value.
        /// </summary>
        /// <param name="lines">The input lines to read the value from.</param>
        /// <returns>A <see cref="DirectionMetrics" /> value derived from the input lines.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the parameter is null.</exception>
        /// <exception cref="AfmFormatException">Thrown if any of the lines contained invalid data, for example a known key without its correct parameters, 
        /// or a key having a parameter of the wrong type.</exception>
        public static DirectionMetrics FromLines(IEnumerable<string> lines)
        {
            if (lines is null)
            {
                throw new ArgumentNullException(nameof(lines));
            }

            const string underlinePosKey = "UnderlinePosition";
            const string underlineStrokeKey = "UnderlineThickness";
            const string italicAngleKey = "ItalicAngle";
            const string charWidthKey = "CharWidth";
            const string fixedWidthKey = "IsFixedPitch";

            decimal? underlinePos = null;
            decimal? underlineStroke = null;
            decimal? italicAngle = null;
            Vector? charWidth = null;
            bool? fixedWidth = null;
            foreach (string line in lines)
            {
                if (line.StartsWith(underlinePosKey, StringComparison.InvariantCulture))
                {
                    underlinePos = LoadingHelpers.LoadKeyedDecimal(line, underlinePosKey);
                }
                else if (line.StartsWith(underlineStrokeKey, StringComparison.InvariantCulture))
                {
                    underlineStroke = LoadingHelpers.LoadKeyedDecimal(line, underlineStrokeKey);
                }
                else if (line.StartsWith(italicAngleKey, StringComparison.InvariantCulture))
                {
                    italicAngle = LoadingHelpers.LoadKeyedDecimal(line, italicAngleKey);
                }
                else if (line.StartsWith(charWidthKey, StringComparison.InvariantCulture))
                {
                    charWidth = LoadingHelpers.LoadKeyedVector(line, charWidthKey);
                }
                else if (line.StartsWith(fixedWidthKey, StringComparison.InvariantCulture))
                {
                    fixedWidth = LoadingHelpers.LoadKeyedBool(line, fixedWidthKey);
                }
            }
            if (charWidth.HasValue && fixedWidth.HasValue && !fixedWidth.Value)
            {
                throw new AfmFormatException(Resources.DirectionMetrics_FromLines_CharWidthClashesWithIsFixedWidth);
            }
            return new DirectionMetrics(underlinePos, underlineStroke, italicAngle, charWidth, fixedWidth);
        }
    }
}
