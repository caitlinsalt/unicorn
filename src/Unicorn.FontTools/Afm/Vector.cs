using System;
using System.Globalization;

namespace Unicorn.FontTools.Afm
{
    /// <summary>
    /// Defines a two-element vector as used in font metrics defnitions.
    /// </summary>
    public struct Vector : IEquatable<Vector>
    {
        /// <summary>
        /// The X component of the vector.
        /// </summary>
        public decimal X { get; private set; }

        /// <summary>
        /// The Y component of the vector.
        /// </summary>
        public decimal Y { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="x">The X component of the vector.</param>
        /// <param name="y">The Y component of the vector.</param>
        public Vector(decimal x, decimal y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Equality-test method.
        /// </summary>
        /// <param name="other">Another <see cref="Vector" /> value.</param>
        /// <returns><c>true</c> if the values are equal, <c>false</c> if not.</returns>
        public bool Equals(Vector other)
        {
            return this == other;
        }

        /// <summary>
        /// Equality-test method.
        /// </summary>
        /// <param name="obj">Another object or value.</param>
        /// <returns><c>true</c> if the parameter is a <see cref="Vector" /> value equal to this one, <c>false</c> otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Vector vector))
            {
                return false;
            }
            return Equals(vector);
        }

        /// <summary>
        /// Returns a hash code value.
        /// </summary>
        /// <returns>An integer representing a hash of this value.</returns>
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ (2 * Y).GetHashCode();
        }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="a">A <see cref="Vector" /> value.</param>
        /// <param name="b">A <see cref="Vector" /> value.</param>
        /// <returns><c>true</c> if the two values are equal, false if not.</returns>
        public static bool operator ==(Vector a, Vector b)
        {
            return a.X == b.X && a.Y == b.Y;
        }

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="a">A <see cref="Vector" /> value.</param>
        /// <param name="b">A <see cref="Vector" /> value.</param>
        /// <returns><c>true</c> if the two values are not equal, <c>false</c> if they are.</returns>
        public static bool operator !=(Vector a, Vector b)
        {
            return a.X != b.X || a.Y != b.Y;
        }

        /// <summary>
        /// Convert two input strings into a <see cref="Vector" /> value.
        /// </summary>
        /// <param name="x">The X component of the vector.</param>
        /// <param name="y">The Y component of the vector.</param>
        /// <returns>A <see cref="Vector" /> value whose components are the parameters converted to numbers.</returns>
        /// <exception cref="AfmFormatException">Thrown if either parameter cannot be converted to a number.</exception>
        public static Vector FromStrings(string x, string y)
        {
            if (!decimal.TryParse(x, out decimal valx))
            {
                throw new AfmFormatException($"Could not parse {x} as a number.");
            }
            if (!decimal.TryParse(y, out decimal valy))
            {
                throw new AfmFormatException($"Could not parse {y} as a number.");
            }
            return new Vector(valx, valy);
        }

        /// <summary>
        /// Convert an input string into a <see cref="Vector" /> value, with the string as the vector's X component.  The Y component will be zero.
        /// </summary>
        /// <param name="x">The X component of the vector.</param>
        /// <returns>A <see cref="Vector" /> whose X component is converted from the parameter, and whose Y component is zero.</returns>
        /// <exception cref="AfmFormatException">Thrown if the parameter cannot be converted to a number.</exception>
        public static Vector FromXString(string x)
        {
            if (!decimal.TryParse(x, out decimal valx))
            {
                throw new AfmFormatException($"Could not parse {x} as a number.");
            }
            return new Vector(valx, 0m);
        }

        /// <summary>
        /// Convert an input string into a <see cref="Vector" /> value, with the string as the vector's Y component.  The X component will be zero.
        /// </summary>
        /// <param name="y">The Y component of the vector.</param>
        /// <returns>A <see cref="Vector"/> whose Y component is converted from the parameter, and whose X component is zero.</returns>
        /// <exception cref="AfmFormatException">Thrown if the parameter cannot be converted to a number.</exception>
        public static Vector FromYString(string y)
        {
            if (!decimal.TryParse(y, out decimal valy))
            {
                throw new AfmFormatException($"Could not parse {y} as a number.");
            }
            return new Vector(0m, valy);
        }

        /// <summary>
        /// Convert this value to a string.
        /// </summary>
        /// <returns>A string containing a representation of this value.</returns>
        public override string ToString()
        {
            return $"{X.ToString(CultureInfo.InvariantCulture)} {Y.ToString(CultureInfo.InvariantCulture)}";
        }
    }
}
