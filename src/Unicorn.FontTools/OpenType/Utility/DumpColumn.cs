using System;

namespace Unicorn.FontTools.OpenType.Utility
{
    /// <summary>
    /// Column definition for dumped tabular data, consisting of a column name and alignment.
    /// </summary>
    public struct DumpColumn : IEquatable<DumpColumn>
    {
        /// <summary>
        /// The column display name.
        /// </summary>
        public string HeaderText { get; private set; }

        /// <summary>
        /// The column alignment.
        /// </summary>
        public DumpAlignment Alignment { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">Column display name.</param>
        /// <param name="align">Column alignment.</param>
        public DumpColumn(string name, DumpAlignment align)
        {
            HeaderText = name;
            Alignment = align;
        }

        /// <summary>
        /// Constructor for a column with default left alignment.
        /// </summary>
        /// <param name="name">Column display name.</param>
        public DumpColumn(string name) : this(name, DumpAlignment.Left) { }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="a">A <see cref="DumpColumn" /> value.</param>
        /// <param name="b">A <see cref="DumpColumn" /> value.</param>
        /// <returns><c>true</c> if the operands are equal, <c>false</c> if not.</returns>
        public static bool operator ==(DumpColumn a, DumpColumn b) => a.HeaderText == b.HeaderText && a.Alignment == b.Alignment;

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="a">A <see cref="DumpColumn" /> value.</param>
        /// <param name="b">A <see cref="DumpColumn" /> value.</param>
        /// <returns><c>true</c> if the operands are not equal, <c>false</c> if they are.</returns>
        public static bool operator !=(DumpColumn a, DumpColumn b) => a.HeaderText != b.HeaderText || a.Alignment != b.Alignment;

        /// <summary>
        /// Equality-test method.
        /// </summary>
        /// <param name="other">Another <see cref="DumpColumn" /> value.</param>
        /// <returns><c>true</c> if the parameter is equal to this value, <c>false</c> if not.</returns>
        public bool Equals(DumpColumn other) => this == other;

        /// <summary>
        /// Equality-test method.
        /// </summary>
        /// <param name="obj">Any object or value.</param>
        /// <returns><c>true</c> if the parameter is a <see cref="DumpColumn" /> value equal to this one, <c>false</c> if not.</returns>
        public override bool Equals(object obj) => obj is DumpColumn other && this == other;

        /// <summary>
        /// Generate a hash code for this value.
        /// </summary>
        /// <returns>A hash code for this value.</returns>
        public override int GetHashCode() => HeaderText.GetHashCode() ^ Alignment.GetHashCode();
    }
}
