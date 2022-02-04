using System;
using System.Collections.Generic;
using Unicorn.Base;
using Unicorn.Helpers;
using Unicorn.Writer.Primitives;

namespace Unicorn
{
    /// <summary>
    /// Represents a colour in the device-dependent RGB colour space.
    /// </summary>
    public class RgbColour : IColour
    {
        /// <summary>
        /// The name of the colour's colour space, "/DeviceRGB".
        /// </summary>
        public string ColourSpaceName => "DeviceRGB";

        /// <summary>
        /// The red component of the colour, from 0.0 (repesenting no red component) to 1.0 (representing maximal red).
        /// </summary>
        public double Red { get; private set; }

        /// <summary>
        /// The green component of the colour, from 0.0 (representing no green component) to 1.0 (representing maximal green).
        /// </summary>
        public double Green { get; private set; }

        /// <summary>
        /// The blue component of the colour, from 0.0 (representing no blue component) to 1.0 (representing maximal blue).
        /// </summary>
        public double Blue { get; private set; }

        /// <summary>
        /// Construct an immutable <see cref="RgbColour" /> instance.
        /// </summary>
        /// <param name="red">The red component.</param>
        /// <param name="green">The green component.</param>
        /// <param name="blue">The blue component.</param>
        /// <exception cref="ArgumentOutOfRangeException">Any of <c>red</c>, <c>green</c> or <c>blue</c> is less than zero or greater than one.</exception>
        public RgbColour(double red, double green, double blue)
        {
            ParameterValidationHelper.CheckDoubleValueBetweenZeroAndOne(red, nameof(red), GeneralResources.RgbColour_Error_ValueOutOfRange);
            ParameterValidationHelper.CheckDoubleValueBetweenZeroAndOne(green, nameof(green), GeneralResources.RgbColour_Error_ValueOutOfRange);
            ParameterValidationHelper.CheckDoubleValueBetweenZeroAndOne(blue, nameof(blue), GeneralResources.RgbColour_Error_ValueOutOfRange);

            Red = red;
            Green = green;
            Blue = blue;
        }

        /// <summary>
        /// Generate a sequence of <see cref="PdfOperator" />s to change the selected stroke colour from <c>currentColour</c> to this colour.  This could be an empty
        /// sequence (if this colour and <c>currentColour</c> are equal) or a single space-and-colour combined selection operator.
        /// </summary>
        /// <param name="currentColour">The current stroking colour.</param>
        /// <returns>A sequence of zero or one <see cref="PdfOperator" />s.</returns>
        public IEnumerable<PdfOperator> StrokeSelectionOperators(IUniColour currentColour)
            => ColourSelectionOperators(currentColour, PdfOperator.SetDeviceRgbStrokingColour);

        /// <summary>
        /// Generate a sequence of <see cref="PdfOperator" />s to change the selected non-stroke colour from <c>currentColour</c> to this colour.  This could be an empty
        /// sequence (if this colour and <c>currentColour</c> are equal) or a single space-and-colour combined selection operator.
        /// </summary>
        /// <param name="currentColour">The current non-stroking colour.</param>
        /// <returns>A sequence of zero or one <see cref="PdfOperator" />s.</returns>
        public IEnumerable<PdfOperator> NonStrokeSelectionOperators(IUniColour currentColour) 
            => ColourSelectionOperators(currentColour, PdfOperator.SetDeviceRgbNonStrokingColour);

        private IEnumerable<PdfOperator> ColourSelectionOperators(IUniColour currentColour, Func<PdfNumber, PdfNumber, PdfNumber, PdfOperator> operatorGenerator)
        {
            if (this == currentColour)
            {
                return Array.Empty<PdfOperator>();
            }
            return new[] { operatorGenerator(new PdfReal(Red), new PdfReal(Green), new PdfReal(Blue)) };
        }

        /// <summary>
        /// Equality operator between <see cref="RgbColour" /> and <see cref="IUniColour" />.
        /// </summary>
        /// <param name="rgb">An <see cref="RgbColour" /> instance.</param>
        /// <param name="other">An <see cref="IUniColour" /> instance.</param>
        /// <returns>
        /// <c>true</c> if the second operand is an <see cref="RgbColour" /> instance with the same colour levels as the first operand or both operands are <c>null</c>;
        /// <c>false</c> otherwise.
        /// </returns>
        public static bool operator ==(RgbColour rgb, IUniColour other)
        {
            if (rgb is null)
            {
                return other is null;
            }
            if (!(other is RgbColour otherRgb))
            {
                return false;
            }
            return rgb.Red == otherRgb.Red && rgb.Green == otherRgb.Green && rgb.Blue == otherRgb.Blue;
        }

        /// <summary>
        /// Equality operator between <see cref="IUniColour" /> and <see cref="RgbColour" />.
        /// </summary>
        /// <param name="rgb">An <see cref="RgbColour" /> instance.</param>
        /// <param name="other">An <see cref="IUniColour" /> instance.</param>
        /// <returns>
        /// <c>true</c> if the first operand is an <see cref="RgbColour" /> instance with the same colour levels as the second operand or both operands are <c>null</c>;
        /// <c>false</c> otherwise.
        /// </returns>
        public static bool operator ==(IUniColour other, RgbColour rgb) => rgb == other;

        /// <summary>
        /// Inequality operator between <see cref="RgbColour" /> and <see cref="IUniColour" />.
        /// </summary>
        /// <param name="rgb">An <see cref="RgbColour" /> instance.</param>
        /// <param name="other">An <see cref="IUniColour" /> instance.</param>
        /// <returns>
        /// <c>true</c> if the second operand is not an <see cref="RgbColour" /> instance, is an <see cref="RgbColour" /> instance with different colour levels to the
        /// first operand, or one and only one operand is <c>null</c>.  <c>false</c> if the second operand is an <see cref="RgbColour" /> instance with the same colour
        /// levels as the first operand, or both operands are <c>null</c>.
        /// </returns>
        public static bool operator !=(RgbColour rgb, IUniColour other)
        {
            if (rgb is null)
            {
                return !(other is null);
            }
            if (!(other is RgbColour otherRgb))
            {
                return true;
            }
            return rgb.Red != otherRgb.Red || rgb.Green != otherRgb.Green || rgb.Blue != otherRgb.Blue;
        }

        /// <summary>
        /// Inequality operator between <see cref="IUniColour" /> and <see cref="RgbColour" />.
        /// </summary>
        /// <param name="rgb">An <see cref="RgbColour" /> instance.</param>
        /// <param name="other">An <see cref="IUniColour" /> instance.</param>
        /// <returns>
        /// <c>true</c> if the first operand is not an <see cref="RgbColour" /> instance, is an <see cref="RgbColour" /> instance with different colour levels to the
        /// second operand, or one and only one operand is <c>null</c>.  <c>false</c> if the first operand is an <see cref="RgbColour" /> instance with the same colour
        /// levels as the second operand, or both operands are <c>null</c>.
        /// </returns>
        public static bool operator !=(IUniColour other, RgbColour rgb) => rgb != other;

        /// <summary>
        /// Equality-testing method.
        /// </summary>
        /// <param name="other">An <see cref="IUniColour" /> instance.</param>
        /// <returns><c>true</c> if the parameter is an <see cref="RgbColour" /> instance with the same colour levels as this object, <c>false</c> otherwise.</returns>
        public bool Equals(IUniColour other) => this == other;

        /// <summary>
        /// Equality-testing method.
        /// </summary>
        /// <param name="obj">Any object or value.</param>
        /// <returns><c>true</c> if the parameter is an <see cref="RgbColour" /> instance with the same colour levels as this object, <c>false</c> otherwise.</returns>
        public override bool Equals(object obj) => obj is IUniColour other && Equals(other);

        /// <summary>
        /// Generate a hash code for this object.
        /// </summary>
        /// <returns>A hash code representing this object.</returns>
        public override int GetHashCode() => ((Red * 13).GetHashCode()) ^ ((Blue * 17).GetHashCode()) ^ (Green.GetHashCode());
    }
}
