using System;

namespace Unicorn.CoreTypes
{
    /// <summary>
    /// A struct which maps a font name and font style to a filename.
    /// </summary>
    public struct FontConfigurationData : IEquatable<FontConfigurationData>
    {
        /// <summary>
        /// The name of the font family.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The style of the font.
        /// </summary>
        public UniFontStyles Style { get; private set; }

        /// <summary>
        /// The filename of the font file.
        /// </summary>
        public string Filename { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">Value for the <see cref="Name" /> property.</param>
        /// <param name="style">Value for the <see cref="Style" /> property.</param>
        /// <param name="filename">Value for the <see cref="Filename" /> property.</param>
        public FontConfigurationData(string name, UniFontStyles style, string filename)
        {
            Name = name;
            Style = style;
            Filename = filename;
        }

        /// <summary>
        /// Equality-check method.
        /// </summary>
        /// <param name="other">Another <see cref="FontConfigurationData" /> value.</param>
        /// <returns><c>true</c> if the paramter is equal to this value, <c>false</c> otherwise.</returns>
        public bool Equals(FontConfigurationData other) => this == other;

        /// <summary>
        /// Equality-check method.
        /// </summary>
        /// <param name="obj">An object or value.</param>
        /// <returns><c>true</c> if the parameter is a <see cref="FontConfigurationData" /> value that is equal to this value; <c>false</c> otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (obj is FontConfigurationData other)
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
            return Name.GetHashCode() ^ Style.GetHashCode() ^ Filename.GetHashCode();
        }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="a">A <see cref="FontConfigurationData" /> value.</param>
        /// <param name="b">A <see cref="FontConfigurationData" /> value.</param>
        /// <returns><c>true</c> if the operands are equal across all properties, <c>false</c> otherwise.</returns>
        public static bool operator ==(FontConfigurationData a, FontConfigurationData b) => a.Name == b.Name && a.Style == b.Style && a.Filename == b.Filename;

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="a">A <see cref="FontConfigurationData" /> value.</param>
        /// <param name="b">A <see cref="FontConfigurationData" /> value.</param>
        /// <returns><c>true</c> if the operands are at all different, <c>false</c> if they are equal.</returns>
        public static bool operator !=(FontConfigurationData a, FontConfigurationData b) => a.Name != b.Name || a.Style != b.Style || a.Filename != b.Filename;
    }
}
