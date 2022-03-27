using System;

namespace Unicorn.Base
{
    /// <summary>
    /// Represents a 3x3 matrix in which the values in the third column are hardcoded to zero, zero and one respectively.  Such a matrix can be used for
    /// coordinate transforms in a 2D space.
    /// </summary>
    public struct UniMatrix : IEquatable<UniMatrix>
    {
        /// <summary>
        /// Matrix member row 0, column 0.
        /// </summary>
        public double R0C0 { get; private set; }

        /// <summary>
        /// Matrix member row 0, column 1.
        /// </summary>
        public double R0C1 { get; private set; }

        /// <summary>
        /// Matrix member row 1, column 0.
        /// </summary>
        public double R1C0 { get; private set; }

        /// <summary>
        /// Matrix member row 1, column 1.
        /// </summary>
        public double R1C1 { get; private set; }

        /// <summary>
        /// Matrix member row 2, column 0.
        /// </summary>
        public double R2C0 { get; private set; }

        /// <summary>
        /// Matrix member row 2, column 1.
        /// </summary>
        public double R2C1 { get; private set; }

        /// <summary>
        /// The identity matrix, representing a no-operation transformation.
        /// </summary>
        public static UniMatrix Identity => new UniMatrix(1, 0, 0, 1, 0, 0);

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="a">Value for the <see cref="R0C0" /> property.</param>
        /// <param name="b">Value for the <see cref="R0C1" /> property.</param>
        /// <param name="c">Value for the <see cref="R1C0" /> property.</param>
        /// <param name="d">Value for the <see cref="R1C1" /> property.</param>
        /// <param name="e">Value for the <see cref="R2C0" /> property.</param>
        /// <param name="f">Value for the <see cref="R2C1" /> property.</param>
        public UniMatrix(double a, double b, double c, double d, double e, double f)
        {
            R0C0 = a;
            R0C1 = b;
            R1C0 = c;
            R1C1 = d;
            R2C0 = e;
            R2C1 = f;
        }

        /// <summary>
        /// Equality-test method.
        /// </summary>
        /// <param name="other">Another <see cref="UniMatrix" /> value.</param>
        /// <returns><c>true</c> if the equivalent element of each matrix is equal, <c>false</c> otherwise.</returns>
        public bool Equals(UniMatrix other) => this == other;

        /// <summary>
        /// Equality-test method.
        /// </summary>
        /// <param name="obj">Another object or value.</param>
        /// <returns><c>true</c> if the parameter is a <see cref="UniMatrix" /> value that is equal to this, <c>false</c> otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (obj is UniMatrix other)
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
            return R0C0.GetHashCode() ^ (R0C1 * 2).GetHashCode() ^ (R1C0 / 2).GetHashCode() ^ (R1C1 * 3).GetHashCode() ^ (R2C0 / 3).GetHashCode() ^
                (R2C1 * 5).GetHashCode();
        }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="a">A <see cref="UniMatrix" /> value.</param>
        /// <param name="b">A <see cref="UniMatrix" /> value.</param>
        /// <returns><c>true</c> if the equivalent element of each matrix is equal, <c>false</c> if not.</returns>
        public static bool operator ==(UniMatrix a, UniMatrix b)
            => a.R0C0 == b.R0C0 && a.R0C1 == b.R0C1 && a.R1C0 == b.R1C0 && a.R1C1 == b.R1C1 && a.R2C0 == b.R2C0 && a.R2C1 == b.R2C1;

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="a">A <see cref="UniMatrix" /> value.</param>
        /// <param name="b">A <see cref="UniMatrix" /> value.</param>
        /// <returns><c>true</c> if any member of one matrix differs from the equivalent member of the other, <c>false</c> if the matrixes are equal.</returns>
        public static bool operator !=(UniMatrix a, UniMatrix b)
            => a.R0C0 != b.R0C0 || a.R0C1 != b.R0C1 || a.R1C0 != b.R1C0 || a.R1C1 != b.R1C1 || a.R2C0 != b.R2C0 || a.R2C1 != b.R2C1;

        /// <summary>
        /// Multiplication operator.  Note that matrix multiplication is not commutative.
        /// </summary>
        /// <param name="a">A <see cref="UniMatrix" /> value.</param>
        /// <param name="b">A <see cref="UniMatrix" /> value.</param>
        /// <returns>The matrix product of the operands.</returns>
        public static UniMatrix operator *(UniMatrix a, UniMatrix b)
            => new UniMatrix(
                a.R0C0 * b.R0C0 + a.R0C1 * b.R1C0, a.R0C0 * b.R0C1 + a.R0C1 * b.R1C1, 
                a.R1C0 * b.R0C0 + a.R1C1 * b.R1C0, a.R1C0 * b.R0C1 + a.R1C1 * b.R1C1, 
                a.R2C0 * b.R0C0 + a.R2C1 * b.R1C0 + b.R2C0, a.R2C0 * b.R0C1 + a.R2C1 * b.R1C1 + b.R2C1);

        /// <summary>
        /// Multiplication method.  Note that matrix multiplication is not commutative.
        /// </summary>
        /// <param name="a">A <see cref="UniMatrix" /> value.</param>
        /// <param name="b">A <see cref="UniMatrix" /> value.</param>
        /// <returns>The matrix product of the parameters.</returns>
        public static UniMatrix Multiply(UniMatrix a, UniMatrix b) => a * b;

        /// <summary>
        /// Multiplication operator.  Treats a <see cref="UniPoint" /> value as a single-row matrix with an implied third element equal to 1.
        /// </summary>
        /// <param name="a">A <see cref="UniPoint" /> value.</param>
        /// <param name="b">A <see cref="UniMatrix" /> value.</param>
        /// <returns>The matrix product of <c>a</c> and <b>b</b>, as a <see cref="UniPoint" /> value.</returns>
        public static UniPoint operator *(UniPoint a, UniMatrix b)
            => new UniPoint(a.X * b.R0C0 + a.Y * b.R1C0 + b.R2C0, a.X * b.R0C1 + a.Y * b.R1C1 + b.R2C1);

        /// <summary>
        /// Multiplication operator.  Treats a <see cref="UniPoint" /> value as a single-row matrix with an implied third element equal to 1.
        /// </summary>
        /// <param name="a">A <see cref="UniPoint" /> value.</param>
        /// <param name="b">A <see cref="UniMatrix" /> value.</param>
        /// <returns>The matrix product of <c>a</c> and <b>b</b>, as a <see cref="UniPoint" /> value.</returns>
        public static UniPoint Multiply(UniPoint a, UniMatrix b) => a * b;

        /// <summary>
        /// Create a transformation matrix representing a translation.  The <see cref="UniPoint" /> parameter represents the vector of translation; in other words,
        /// the point that the origin will be translated to.
        /// </summary>
        /// <param name="vector">The translation vector.</param>
        /// <returns>A <see cref="UniMatrix" /> value which represents a translation by the given vector.</returns>
        public static UniMatrix Translation(UniPoint vector) => Translation(vector.X, vector.Y);

        /// <summary>
        /// Create a transformation matrix representing a Cartesian translation.  The parameters represent the X and Y componnts of the translation.
        /// </summary>
        /// <param name="x">The X component of the translation.</param>
        /// <param name="y">The Y component of the translation.</param>
        /// <returns>A <see cref="UniMatrix"/> value which represents a translation by the given vectors.</returns>
        public static UniMatrix Translation(double x, double y) => new UniMatrix(1, 0, 0, 1, x, y);

        /// <summary>
        /// Create a transformation matrix representing a rotation around the origin.
        /// </summary>
        /// <param name="theta">The angle to rotate by (in radians).</param>
        /// <returns>A <see cref="UniMatrix" /> value which represents a rotation around the origin.</returns>
        public static UniMatrix Rotation(double theta)
        {
            double cos = Math.Cos(theta);
            double sin = Math.Sin(theta);

            return new UniMatrix(cos, sin, -sin, cos, 0, 0);
        }

        /// <summary>
        /// Create a transformation matrix representing a scaling transformation.  The parameter is a uniform scaling factor.
        /// </summary>
        /// <param name="factor">The scaling factor.</param>
        /// <returns>A <see cref="UniMatrix"/> value representing scaling about the origin by the given factor.</returns>
        public static UniMatrix Scale(double factor) => Scale(factor, factor);

        /// <summary>
        /// Creste a transformation matrix representing a scaling transformation by different factors on each axis.
        /// </summary>
        /// <param name="xFactor">The horizontal scaling factor.</param>
        /// <param name="yFactor">The vertical scaling factor.</param>
        /// <returns>A <see cref="UniMatrix"/> value representing scaing about the origin by the given factors.</returns>
        public static UniMatrix Scale(double xFactor, double yFactor) => new UniMatrix(xFactor, 0, 0, yFactor, 0, 0);

        /// <summary>
        /// Create a transformation matrix representing a rotation around an arbitrary point.  Consists of a translation to the origin, a rotation, and then a
        /// translation that is the inverse of the first, but transformed by the rotation matrix.
        /// </summary>
        /// <param name="theta">The angle to rotate by (in radians).</param>
        /// <param name="origin">The point to rotate about.</param>
        /// <returns>A <see cref="UniMatrix" /> value which represents a rotation around a specific point.</returns>
        public static UniMatrix RotationAt(double theta, UniPoint origin)
        {
            UniMatrix rotation = Rotation(theta);
            return rotation * Translation(origin - origin * rotation);
        }
    }
}
