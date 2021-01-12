using System;
using System.Collections.Generic;
using System.Text;

namespace Unicorn.FontTools.Afm
{
    /// <summary>
    /// A set of possible width information
    /// </summary>
    public struct WidthSet : IEquatable<WidthSet>
    {
        /// <summary>
        /// General width.
        /// </summary>
        public decimal? General { get; private set; }

        /// <summary>
        /// Width in writing direction 0.
        /// </summary>
        public decimal? Direction0 { get; private set; }

        /// <summary>
        /// Width in writing direction 1.
        /// </summary>
        public decimal? Direction1 { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="general">General width.</param>
        /// <param name="dir0">Width in writing direction 0.</param>
        /// <param name="dir1">Width in writing direction 1.</param>
        public WidthSet(decimal? general, decimal? dir0, decimal? dir1)
        {
            General = general;
            Direction0 = dir0;
            Direction1 = dir1;
        }

        /// <summary>
        /// Equality-test method.
        /// </summary>
        /// <param name="other">Another <see cref="WidthSet" /> value.</param>
        /// <returns><c>true</c> if the parameter is equal to this, <c>false</c> if not.</returns>
        public bool Equals(WidthSet other)
        {
            return this == other;
        }

        /// <summary>
        /// Equality-test method.
        /// </summary>
        /// <param name="obj">Another value or object.</param>
        /// <returns><c>true</c> if the parameter is a <see cref="WidthSet" /> value equal to this, <c>false</c> otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is WidthSet ws))
            {
                return false;
            }
            return Equals(ws);
        }

        /// <summary>
        /// Hash code generation method.
        /// </summary>
        /// <returns>An <c>int</c> hashcode.</returns>
        public override int GetHashCode()
        {
            return General.GetHashCode() ^ Direction0.GetHashCode() ^ Direction1.GetHashCode();
        }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="a">A <see cref="WidthSet" /> value.</param>
        /// <param name="b">A <see cref="WidthSet" /> value.</param>
        /// <returns><c>true</c> if the two operands are equal, <c>false</c> if not.</returns>
        public static bool operator ==(WidthSet a, WidthSet b)
        {
            return a.General == b.General && a.Direction0 == b.Direction0 && a.Direction1 == b.Direction1;
        }

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="a">A <see cref="WidthSet" /> value.</param>
        /// <param name="b">A <see cref="WidthSet" /> value.</param>
        /// <returns><c>true</c> if the two operands are not equal, <c>false</c> if they are.</returns>
        public static bool operator !=(WidthSet a, WidthSet b)
        {
            return a.General != b.General || a.Direction0 != b.Direction0 || a.Direction1 != b.Direction1;
        }
    }
}
