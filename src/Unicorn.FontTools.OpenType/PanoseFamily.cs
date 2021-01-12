using System;

namespace Unicorn.FontTools.OpenType
{
    /// <summary>
    /// A struct to represent Panose font classification information.
    /// </summary>
    public struct PanoseFamily : IEquatable<PanoseFamily>
    {
        /// <summary>
        /// Font family type value.
        /// </summary>
        public byte FamilyType { get; private set; }

        /// <summary>
        /// Font serif style.
        /// </summary>
        public byte SerifStyle { get; private set; }

        /// <summary>
        /// Font weight.
        /// </summary>
        public byte Weight { get; private set; }

        /// <summary>
        /// Font proportions.
        /// </summary>
        public byte Proportion { get; private set; }

        /// <summary>
        /// Font stroke contrast.
        /// </summary>
        public byte Contrast { get; private set; }

        /// <summary>
        /// Font stroke variation.
        /// </summary>
        public byte StrokeVariation { get; private set; }

        /// <summary>
        /// Font arm style.
        /// </summary>
        public byte ArmStyle { get; private set; }

        /// <summary>
        /// Font letterform.
        /// </summary>
        public byte Letterform { get; private set; }

        /// <summary>
        /// Font midline position.
        /// </summary>
        public byte Midline { get; private set; }

        /// <summary>
        /// Font x-height.
        /// </summary>
        public byte XHeight { get; private set; }

        /// <summary>
        /// Constructor with individual property values.
        /// </summary>
        /// <param name="famType">The <see cref="FamilyType"/> property.</param>
        /// <param name="serifStyle">The <see cref="SerifStyle"/> property.</param>
        /// <param name="weight">The <see cref="Weight"/> property.</param>
        /// <param name="proportion">The <see cref="Proportion"/> property.</param>
        /// <param name="contrast">The <see cref="Contrast"/> property.</param>
        /// <param name="strokeVar">The <see cref="StrokeVariation"/> property.</param>
        /// <param name="armStyle">The <see cref="ArmStyle"/> property.</param>
        /// <param name="letterform">The <see cref="Letterform"/> property.</param>
        /// <param name="midline">The <see cref="Midline"/> property.</param>
        /// <param name="xHeight">The <see cref="XHeight"/> property.</param>
        public PanoseFamily(byte famType, byte serifStyle, byte weight, byte proportion, byte contrast, byte strokeVar, byte armStyle, byte letterform,
            byte midline, byte xHeight)
        {
            FamilyType = famType;
            SerifStyle = serifStyle;
            Weight = weight;
            Proportion = proportion;
            Contrast = contrast;
            StrokeVariation = strokeVar;
            ArmStyle = armStyle;
            Letterform = letterform;
            Midline = midline;
            XHeight = xHeight;
        }

        /// <summary>
        /// Constructor which takes an array of bytes, and takes the ten consecutive byte values starting at the offset element as the property values for the struct.
        /// </summary>
        /// <param name="arr">Array of source data.</param>
        /// <param name="offset">Location of the first relevant item in the array</param>
        public PanoseFamily(byte[] arr, int offset) : this(arr?[offset] ?? 0, arr[offset + 1], arr[offset + 2], arr[offset + 3], arr[offset + 4], arr[offset + 5], 
            arr[offset + 6], arr[offset + 7], arr[offset + 8], arr[offset + 9])
        {
        }

        /// <summary>
        /// Convert this structure to a string.
        /// </summary>
        /// <returns>A string consisting of the value of each property, separated by white space.</returns>
        public override string ToString()
        {
            return $"{FamilyType} {SerifStyle} {Weight} {Proportion} {Contrast} {StrokeVariation} {ArmStyle} {Letterform} {Midline} {XHeight}";
        }

        /// <summary>
        /// Equality-test method.
        /// </summary>
        /// <param name="other">Another <see cref="PanoseFamily"/> value to compare against.</param>
        /// <returns><c>true</c> if the parameter is equal to this value, <c>false</c> if not.</returns>
        public bool Equals(PanoseFamily other) => this == other;

        /// <summary>
        /// Equality-test method.
        /// </summary>
        /// <param name="obj">Another object or value.</param>
        /// <returns><c>true</c> if the parameter is another <see cref="PanoseFamily" /> value that is equal to this one; <c>false</c> otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (obj is PanoseFamily other)
            {
                return Equals(other);
            }
            return false;
        }

        /// <summary>
        /// Hash code method.
        /// </summary>
        /// <returns>A hash code for this value.</returns>
        public override int GetHashCode()
        {
            return FamilyType.GetHashCode() ^ SerifStyle.GetHashCode() ^ Weight.GetHashCode() ^ Proportion.GetHashCode() ^ Contrast.GetHashCode() ^
                StrokeVariation.GetHashCode() ^ ArmStyle.GetHashCode() ^ Letterform.GetHashCode() ^ Midline.GetHashCode() ^ XHeight.GetHashCode();
        }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="a">A <see cref="PanoseFamily" /> value.</param>
        /// <param name="b">A <see cref="PanoseFamily" /> value.</param>
        /// <returns><c>true</c> if the parameters are equal, <c>false</c> if not.</returns>
        public static bool operator ==(PanoseFamily a, PanoseFamily b) =>
            a.FamilyType == b.FamilyType && a.SerifStyle == b.SerifStyle && a.Weight == b.Weight && a.Proportion == b.Proportion && a.Contrast == b.Contrast &&
                a.StrokeVariation == b.StrokeVariation && a.ArmStyle == b.ArmStyle && a.Letterform == b.Letterform && a.Midline == b.Midline && a.XHeight == b.XHeight;

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="a">A <see cref="PanoseFamily" /> value.</param>
        /// <param name="b">A <see cref="PanoseFamily" /> value.</param>
        /// <returns><c>true</c> if the parameters are not equal, <c>false</c> if they are equal.</returns>
        public static bool operator !=(PanoseFamily a, PanoseFamily b) =>
            a.FamilyType != b.FamilyType || a.SerifStyle != b.SerifStyle || a.Weight != b.Weight || a.Proportion != b.Proportion || a.Contrast != b.Contrast ||
                a.StrokeVariation != b.StrokeVariation || a.ArmStyle != b.ArmStyle || a.Letterform != b.Letterform || a.Midline != b.Midline || a.XHeight != b.XHeight;
    }
}
