using System;

namespace Unicorn.CoreTypes
{
    /// <summary>
    /// Immutable struct which encapsulates the size of a 2D rectangle.
    /// </summary>
    public struct UniSize : IEquatable<UniSize>
    {
        /// <summary>
        /// Width
        /// </summary>
        public double Width { get; private set; }

        /// <summary>
        /// Height
        /// </summary>
        public double Height { get; private set; }

        /// <summary>
        /// Constructor, setting <see cref="Width" /> and <see cref="Height" /> properties.  
        /// </summary>
        /// <param name="width">The value of the <see cref="Width" /> property.</param>
        /// <param name="height">The value of the <see cref="Height" /> property.</param>
        public UniSize(double width, double height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Constructor with width and height parameters, as decimals.
        /// </summary>
        /// <param name="width">The value of the <see cref="Width" /> property.</param>
        /// <param name="height">The value of the <see cref="Height" /> property.</param>
        public UniSize(decimal width, decimal height) : this((double)width, (double)height)
        {
        }

        /// <summary>
        /// Equality test.
        /// </summary>
        /// <param name="other">Another UniSize instance to compare against.</param>
        /// <returns>True or false according to whether or not the other instance is equal to this.</returns>
        public bool Equals(UniSize other) => this == other;

        /// <summary>
        /// Equality test.
        /// </summary>
        /// <param name="obj">Another object or value to compare against.</param>
        /// <returns><c>true</c> if the obj parameter is another UniSize value that is the same as this; <c>false</c> otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is UniSize other))
            {
                return false;
            }
            return Equals(other);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32 bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            // The multiplication of the height is to avoid the generate case where all squares return a hashcode of 0.
            return Width.GetHashCode() ^ (Height * 17).GetHashCode();
        }
        
        /// <summary>
        /// Addition operator.  Returns a <see cref="UniSize" /> whose width is the sum of its operands' widths and whose height is the sum of its operands' heights.
        /// </summary>
        /// <param name="a">A <see cref="UniSize" /> value.</param>
        /// <param name="b">A <see cref="UniSize" /> value.</param>
        /// <returns>A <see cref="UniSize" /> value that equals the sum of the operands.</returns>
        public static UniSize operator +(UniSize a, UniSize b) => new UniSize(a.Width + b.Width, a.Height + b.Height);

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="a">A <see cref="UniSize" /> value.</param>
        /// <param name="b">A <see cref="UniSize" /> value.</param>
        /// <returns><c>true</c> if the operands have equal <see cref="Width" /> and <see cref="Height" /> properties; <c>false</c> if not.</returns>
        public static bool operator ==(UniSize a, UniSize b) => a.Width == b.Width && a.Height == b.Height;

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="a">A <see cref="UniSize" /> value.</param>
        /// <param name="b">A <see cref="UniSize" /> value.</param>
        /// <returns><c>true</c> if the values' properties are not equal, <c>false</c> if they are.</returns>
        public static bool operator !=(UniSize a, UniSize b) => a.Width != b.Width && a.Height != b.Height;

        /// <summary>
        /// Addition method.  Returns a <see cref="UniSize" /> whsoe width is the sum of its paremeters' widths and whose height is the sum of its parameters' heights.
        /// </summary>
        /// <param name="left">A <see cref="UniSize" /> value.</param>
        /// <param name="right">A <see cref="UniSize" /> value.</param>
        /// <returns>A new <see cref="UniSize" /> value that equals the sum of the parameters.</returns>
        public static UniSize Add(UniSize left, UniSize right) => left + right;
    }
}
