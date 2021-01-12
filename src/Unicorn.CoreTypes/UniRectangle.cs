using System;

namespace Unicorn.CoreTypes
{
    /// <summary>
    /// An immutable struct describing the dimensions and position of a rectangular area.
    /// </summary>
    public struct UniRectangle : IEquatable<UniRectangle>
    {
        /// <summary>
        /// The X-coordinate of the left edge of the rectangle.
        /// </summary>
        public double MinX { get; private set; }

        /// <summary>
        /// The lowest Y-coordinate of the an edge of the rectangle (the top edge in the context of a page with Y increasing downwards).
        /// </summary>
        public double MinY { get; private set; }

        /// <summary>
        /// The size of this rectangle.
        /// </summary>
        public UniSize Size { get; private set; }

        /// <summary>
        /// The width of this rectangle.
        /// </summary>
        public double Width => Size.Width;

        /// <summary>
        /// The height of this rectangle.
        /// </summary>
        public double Height => Size.Height;
        
        /// <summary>
        /// Constructor with separate width and height parameters.
        /// </summary>
        /// <param name="minX">Lowest X-coordinate of an edge of the rectangle.</param>
        /// <param name="minY">Lowest Y-coordinate of an edge of the rectangle.</param>
        /// <param name="width">Width of the rectangle.</param>
        /// <param name="height">Height of the rectangle.</param>
        public UniRectangle(double minX, double minY, double width, double height)
        {
            Size = new UniSize(width, height);
            MinX = minX;
            MinY = minY;
        }

        /// <summary>
        /// Constructor with separate width and height decimal parameters.
        /// </summary>
        /// <param name="minX">Lowest X-coordinate of an edge of the rectangle.</param>
        /// <param name="minY">Lowest Y-coordinate of an edge of the rectangle.</param>
        /// <param name="width">Width of the rectangle.</param>
        /// <param name="height">Height of the rectangle.</param>
        public UniRectangle(decimal minX, decimal minY, decimal width, decimal height)
        {
            Size = new UniSize(width, height);
            MinX = (double)minX;
            MinY = (double)minY;
        }

        /// <summary>
        /// Constructor with single size parameter.
        /// </summary>
        /// <param name="minX">Lowest X-coordinate of an edge of the rectangle.</param>
        /// <param name="minY">Lowest Y-coordinate of an edge of the rectangle.</param>
        /// <param name="size">Size of the rectangle.</param>
        public UniRectangle(double minX, double minY, UniSize size)
        {
            Size = size;
            MinX = minX;
            MinY = minY;
        }

        /// <summary>
        /// Equality-test method.
        /// </summary>
        /// <param name="other">Another <see cref="UniRectangle" /> value to compare.</param>
        /// <returns><c>true</c> if the parameter is equal to this value; <c>false</c> otherwise.</returns>
        public bool Equals(UniRectangle other) => this == other;

        /// <summary>
        /// Equality-test method.
        /// </summary>
        /// <param name="obj">Another object or value.</param>
        /// <returns><c>true</c> if the parameter is another <see cref="UniRectangle" /> value that is equal to this; <c>false</c> otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (obj is UniRectangle other)
            {
                return Equals(other);
            }
            return false;
        }

        /// <summary>
        /// Hash code method.
        /// </summary>
        /// <returns>A hash code derived from this value.</returns>
        public override int GetHashCode()
        {
            return MinX.GetHashCode() ^ (MinY * 3).GetHashCode() ^ Size.GetHashCode();
        }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="a">A <see cref="UniRectangle" /> value.</param>
        /// <param name="b">A <see cref="UniRectangle" /> value.</param>
        /// <returns><c>true</c> if the operands are equal across all properties; <c>false</c> otherwise.</returns>
        public static bool operator ==(UniRectangle a, UniRectangle b) => a.MinX == b.MinX && a.MinY == b.MinY && a.Size == b.Size;

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="a">A <see cref="UniRectangle" /> value.</param>
        /// <param name="b">A <see cref="UniRectangle" /> value.</param>
        /// <returns><c>true</c> if the operands differ by any property; <c>false</c> if they are equal.</returns>
        public static bool operator !=(UniRectangle a, UniRectangle b) => a.MinX != b.MinX || a.MinY != b.MinY || a.Size != b.Size;
    }
}
