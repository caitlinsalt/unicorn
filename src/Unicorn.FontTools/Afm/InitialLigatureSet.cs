using System;

namespace Unicorn.FontTools.Afm
{
    /// <summary>
    /// An immutable struct that represents part of a ligature definition, with characters referenced by name.  This struct is used during font loading, when not all
    /// characters have been loaded into memory.  This struct is intended to be associated with the <see cref="Character" /> that is the first character of the ligature,
    /// and contains the name of the second unligatured character and the ligature character that replaces both.
    /// </summary>
    public struct InitialLigatureSet : IEquatable<InitialLigatureSet>
    {
        /// <summary>
        /// The name of a character which should trigger ligature replacement when preceded by another specific character.
        /// </summary>
        public string Second { get; private set; }

        /// <summary>
        /// The name of the character that should be used as a replacement ligatured character when two specific characters are found in sequence.
        /// </summary>
        public string Ligature { get; private set; }

        /// <summary>
        /// Property-setting constructor.
        /// </summary>
        /// <param name="second">The value of the <see cref="Second" /> property.</param>
        /// <param name="resultingLigature">The value of the <see cref="Ligature" /> property.</param>
        public InitialLigatureSet(string second, string resultingLigature)
        {
            if (second is null)
            {
                throw new ArgumentNullException(nameof(second));
            }
            if (resultingLigature is null)
            {
                throw new ArgumentNullException(nameof(resultingLigature));
            }

            Second = second;
            Ligature = resultingLigature;
        }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="a">An <see cref="InitialLigatureSet" /> value.</param>
        /// <param name="b">An <see cref="InitialLigatureSet" /> value.</param>
        /// <returns><c>true</c> if the properties of both parameters are respectively equal, <c>false</c> if not.</returns>
        public static bool operator ==(InitialLigatureSet a, InitialLigatureSet b) => a.Second == b.Second && a.Ligature == b.Ligature;

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="a">An <see cref="InitialLigatureSet" /> value.</param>
        /// <param name="b">An <see cref="InitialLigatureSet" /> value.</param>
        /// <returns><c>false</c> if the properties of both parameters are respectively equal, <c>true</c> if any are different.</returns>
        public static bool operator !=(InitialLigatureSet a, InitialLigatureSet b) => a.Second != b.Second || a.Ligature != b.Ligature;

        /// <summary>
        /// Equality-testing method.
        /// </summary>
        /// <param name="other">An <see cref="InitialLigatureSet" /> value.</param>
        /// <returns><c>true</c> if the parameter's properties are respectively equal to those of this value; <c>false</c> if either are different.</returns>
        public bool Equals(InitialLigatureSet other) => this == other;

        /// <summary>
        /// Equality-testing method.
        /// </summary>
        /// <param name="obj">Any value or object,</param>
        /// <returns><c>true</c> if the parameter is an <see cref="InitialLigatureSet" /> value whose properties are respectively equal to those of this value;
        /// <c>false</c> if not.</returns>
        public override bool Equals(object obj) => (obj is InitialLigatureSet ils) && this == ils;

        /// <summary>
        /// Generate a hashcode for this value.
        /// </summary>
        /// <returns>An integer representing this value.</returns>
        public override int GetHashCode() => Second.GetHashCode() ^ Ligature.GetHashCode();
    }
}
