using System;

namespace Unicorn.CoreTypes
{
    /// <summary>
    /// A struct that describes a point in 2D Cartesian space.
    /// </summary>
    public struct UniPoint : IEquatable<UniPoint>
    {
        /// <summary>
        /// The X coordinate.
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// The Y coordinate.
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Constructor setting initial values of properties.
        /// </summary>
        /// <param name="x">Initial value of the <see cref="X" /> property.</param>
        /// <param name="y">Initial value of the <see cref="Y" /> property.</param>
        public UniPoint(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Equality-test method.
        /// </summary>
        /// <param name="other">Another <see cref="UniPoint" /> value.</param>
        /// <returns><c>true</c> if the parameter is equal to this value; <c>false</c> otherwise.</returns>
        public bool Equals(UniPoint other) => this == other;

        /// <summary>
        /// Equality-test method.
        /// </summary>
        /// <param name="obj">Another object or value.</param>
        /// <returns><c>true</c> if the parameter is a <see cref="UniPoint" /> value that is equal to this; <c>false</c> otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (obj is UniPoint other)
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
            return X.GetHashCode() ^ (Y * 11).GetHashCode();
        }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="a">A <see cref="UniPoint" /> value.</param>
        /// <param name="b">A <see cref="UniPoint" /> value.</param>
        /// <returns><c>true</c> if the operands are equal across both properties; <c>false</c> otherwise.</returns>
        public static bool operator ==(UniPoint a, UniPoint b) => a.X == b.X && a.Y == b.Y;

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="a">A <see cref="UniPoint" /> value.</param>
        /// <param name="b">A <see cref="UniPoint" /> value.</param>
        /// <returns><c>true</c> if the operands differ in either property, <c>false</c> if they are equal across both.</returns>
        public static bool operator !=(UniPoint a, UniPoint b) => a.X != b.X || a.Y != b.Y;

        /// <summary>
        /// Negation operator.  Returns a <see cref="UniPoint" /> value with both <see cref="X" /> and <see cref="Y" /> properties negated.
        /// </summary>
        /// <param name="val">A <see cref="UniPoint" /> value.</param>
        /// <returns>The negated value of the operand.</returns>
        public static UniPoint operator -(UniPoint val) => new UniPoint(-val.X, -val.Y);

        /// <summary>
        /// Negation method.  Returns a <see cref="UniPoint" /> value with both <see cref="X" /> and <see cref="Y" /> properties negated.
        /// </summary>
        /// <param name="val">A <see cref="UniPoint" /> value.</param>
        /// <returns>The negated value of the parameter.</returns>
        public static UniPoint Negate(UniPoint val) => -val;

        /// <summary>
        /// Subtraction operator.
        /// </summary>
        /// <param name="a">A <see cref="UniPoint" /> value.</param>
        /// <param name="b">A <see cref="UniPoint" /> value.</param>
        /// <returns>A <see cref="UniPoint" /> value which is equal to the difference between <c>a</c> and <c>b</c>.</returns>
        public static UniPoint operator -(UniPoint a, UniPoint b) => new UniPoint(a.X - b.X, a.Y - b.Y);

        /// <summary>
        /// Subtraction method.
        /// </summary>
        /// <param name="a">A <see cref="UniPoint" /> value.</param>
        /// <param name="b">A <see cref="UniPoint" /> value.</param>
        /// <returns>A <see cref="UniPoint" /> value which is equal to the difference between <c>a</c> and <c>b</c>.</returns>
        public static UniPoint Subtract(UniPoint a, UniPoint b) => a - b;
    }
}
