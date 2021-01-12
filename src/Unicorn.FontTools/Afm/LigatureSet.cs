using System;

namespace Unicorn.FontTools.Afm
{
    /// <summary>
    /// A struct representing a pair of characters that combine to produce a ligature character
    /// </summary>
    public struct LigatureSet : IEquatable<LigatureSet>
    {
        /// <summary>
        /// The first character of the pair.
        /// </summary>
        public Character First { get; private set; }

        /// <summary>
        /// The second character of the pair.
        /// </summary>
        public Character Second { get; private set; }

        /// <summary>
        /// The resulting ligature character that should be displayed.
        /// </summary>
        public Character Ligature { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="first">The first character of the ligature pair.</param>
        /// <param name="second">The second character of the ligature pair.</param>
        /// <param name="resultingLigature">The resulting ligature character.</param>
        public LigatureSet(Character first, Character second, Character resultingLigature)
        {
            if (first is null)
            {
                throw new ArgumentNullException(nameof(first));
            }
            if (second is null)
            {
                throw new ArgumentNullException(nameof(second));
            }
            if (resultingLigature is null)
            {
                throw new ArgumentNullException(nameof(resultingLigature));
            }

            First = first;
            Second = second;
            Ligature = resultingLigature;
        }

        /// <summary>
        /// Equality-testing method.
        /// </summary>
        /// <param name="other">Another <see cref="LigatureSet" /> value.</param>
        /// <returns><c>true</c> if both values are equal, <c>false</c> if not.</returns>
        public bool Equals(LigatureSet other)
        {
            return this == other;
        }

        /// <summary>
        /// Equality-testing method.
        /// </summary>
        /// <param name="obj">Any object.</param>
        /// <returns><c>true</c> if the parameter is a <see cref="LigatureSet" /> value that is equal to this one, <c>false</c> otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is LigatureSet other))
            {
                return false;
            }
            return Equals(other);
        }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="a">A <see cref="LigatureSet" /> value.</param>
        /// <param name="b">A <see cref="LigatureSet" /> value.</param>
        /// <returns><c>true</c> if all of the properties of both operands are respectively equal, <c>false</c> if not.</returns>
        public static bool operator ==(LigatureSet a, LigatureSet b)
        {
            return a.First == b.First && a.Second == b.Second && a.Ligature == b.Ligature;
        }

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="a">A <see cref="LigatureSet" /> value.</param>
        /// <param name="b">A <see cref="LigatureSet" /> value.</param>
        /// <returns><c>true</c> if any of the properties of the operands differ respectively from each other, <c>false</c> if all properties are respectively 
        /// equal.</returns>
        public static bool operator !=(LigatureSet a, LigatureSet b)
        {
            return a.First != b.First || a.Second != b.Second || a.Ligature != b.Ligature;
        }

        /// <summary>
        /// Computes a hash code for this value.
        /// </summary>
        /// <returns>An <c>int</c> which can be used as a hash code for this value.</returns>
        public override int GetHashCode()
        {
            return First.GetHashCode() ^ Second.GetHashCode() ^ Ligature.GetHashCode();
        }
    }
}
