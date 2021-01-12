using System;

namespace Unicorn.CoreTypes
{
    /// <summary>
    ///  Immutable struct which encapsulates the start and end of a range of locations along a dimension.
    /// </summary>
    public struct UniRange : IEquatable<UniRange>
    {
        /// <summary>
        /// Start
        /// </summary>
        public double Start { get; private set; }

        /// <summary>
        /// End
        /// </summary>
        public double End { get; private set; }

        /// <summary>
        /// Size - the distance between <see cref="Start" /> and <see cref="End" />.
        /// </summary>
        public double Size { get { return End - Start; } }

        /// <summary>
        /// Constructor, setting <see cref="Start" /> and <see cref="End" /> properties.    
        /// </summary>
        /// <param name="start">The value of the <see cref="Start" /> property.</param>
        /// <param name="end">The value of the <see cref="End" /> property.</param>
        public UniRange(double start, double end)
        {
            Start = start;
            End = end;
        }

        /// <summary>
        /// Equality-test method.
        /// </summary>
        /// <param name="other">Another <see cref="UniRange" /> value.</param>
        /// <returns><c>true</c> if the parameter is equal to this value; <c>false</c> otherwise.</returns>
        public bool Equals(UniRange other) => this == other;

        /// <summary>
        /// Equality-test method.
        /// </summary>
        /// <param name="obj">Another object or value.</param>
        /// <returns><c>true</c> if the parameter is a <see cref="UniRange" /> value that is equal to this; <c>false</c> otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (obj is UniRange other)
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
            return Start.GetHashCode() ^ (End * 7).GetHashCode();
        }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="a">A <see cref="UniRange" /> value.</param>
        /// <param name="b">A <see cref="UniRange" /> value.</param>
        /// <returns><c>true</c> if the operands are equal across both properties; <c>false</c> otherwise.</returns>
        public static bool operator ==(UniRange a, UniRange b) => a.Start == b.Start && a.End == b.End;

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="a">A <see cref="UniRange" /> value.</param>
        /// <param name="b">A <see cref="UniRange" /> value.</param>
        /// <returns><c>true></c> if the operands differ in either property; <c>false</c> if they are equal.</returns>
        public static bool operator !=(UniRange a, UniRange b) => a.Start != b.Start || a.End != b.End;
    }
}
