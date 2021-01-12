using System;

namespace Unicorn.FontTools.Afm
{
    /// <summary>
    /// Represents an AFM bounding box.
    /// </summary>
    public struct BoundingBox : IEquatable<BoundingBox>
    {
        /// <summary>
        /// The lower-left X coordinate.
        /// </summary>
        public decimal Left { get; private set; }

        /// <summary>
        /// The lower-left Y coordinate.
        /// </summary>
        public decimal Bottom { get; private set; }

        /// <summary>
        /// The upper-right X coordinate.
        /// </summary>
        public decimal Right { get; private set; }

        /// <summary>
        /// The upper-right Y coordinate.
        /// </summary>
        public decimal Top { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="left">The lower-left X coordinate.</param>
        /// <param name="bottom">The lower-left Y coordinate.</param>
        /// <param name="right">The upper-right X coordinate.</param>
        /// <param name="top">The upper-right Y coordinate.</param>
        public BoundingBox(decimal left, decimal bottom, decimal right, decimal top)
        {
            Left = left;
            Bottom = bottom;
            Right = right;
            Top = top;
        }

        /// <summary>
        /// Equality-test method.
        /// </summary>
        /// <param name="other">Another <see cref="BoundingBox" /> value to compare against.</param>
        /// <returns>True if the other value is equal to this, false if not.</returns>
        public bool Equals(BoundingBox other)
        {
            return this == other;
        }

        /// <summary>
        /// Equality-test method.
        /// </summary>
        /// <param name="obj">Another object or value to compare against.</param>
        /// <returns>True if the parameter is a <see cref="BoundingBox" /> value equal to this, false if not.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is BoundingBox other))
            {
                return false;
            }
            return this == other;
        }

        /// <summary>
        /// Hash code method.
        /// </summary>
        /// <returns>Returns a hashcode derived from the properties of this value.</returns>
        public override int GetHashCode()
        {
            return Left.GetHashCode() ^ (Right * 2).GetHashCode() ^ (Top / 2).GetHashCode() ^ (Bottom * 4).GetHashCode();
        }

        /// <summary>
        /// String conversion method.
        /// </summary>
        /// <returns>A string in the format "llx lly urx ury".</returns>
        public override string ToString()
        {
            return $"{Left} {Bottom} {Right} {Top}";
        }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="a">A <see cref="BoundingBox" /> value.</param>
        /// <param name="b">A <see cref="BoundingBox" /> value.</param>
        /// <returns>True if all properties of both operands are equal, false otherwise.</returns>
        public static bool operator ==(BoundingBox a, BoundingBox b)
        {
            return a.Left == b.Left && a.Right == b.Right && a.Top == b.Top && a.Bottom == b.Bottom;
        }

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="a">A <see cref="BoundingBox" /> value.</param>
        /// <param name="b">A <see cref="BoundingBox" /> value.</param>
        /// <returns>True if any properties of either operand are different, false if all properties of both operands are equal.</returns>
        public static bool operator !=(BoundingBox a, BoundingBox b)
        {
            return a.Left != b.Left || a.Right != b.Right || a.Top != b.Top || a.Bottom != b.Bottom;
        }

        /// <summary>
        /// Convert four strings into a <see cref="BoundingBox" /> value.
        /// </summary>
        /// <param name="left">The string to convert into the <see cref="Left" /> property.</param>
        /// <param name="bottom">The string to convert into the <see cref="Bottom" /> property.</param>
        /// <param name="right">The string to convert into the <see cref="Right"/> property.</param>
        /// <param name="top">The string to convert into the <see cref="Top"/> property.</param>
        /// <returns></returns>
        public static BoundingBox FromStrings(string left, string bottom, string right, string top)
        {
            if (!decimal.TryParse(left, out decimal lv))
            {
                throw new AfmFormatException($"Could not parse {left} as a number.");
            }
            if (!decimal.TryParse(bottom, out decimal bv))
            {
                throw new AfmFormatException($"Could not parse {bottom} as a number.");
            }
            if (!decimal.TryParse(right, out decimal rv))
            {
                throw new AfmFormatException($"Could not parse {right} as a number.");
            }
            if (!decimal.TryParse(top, out decimal tv))
            {
                throw new AfmFormatException($"Could not parse {top} as a number.");
            }
            return new BoundingBox(lv, bv, rv, tv);
        }
    }
}
