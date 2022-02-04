using System;
using System.Collections.Generic;
using Unicorn.Base;
using Unicorn.Helpers;
using Unicorn.Writer.Primitives;

namespace Unicorn
{
    /// <summary>
    /// Represents a colour in the device-dependent CMYK colour space.
    /// </summary>
    public class CmykColour : IColour
    {
        /// <summary>
        /// The name of the colour space: /DeviceCMYK.
        /// </summary>
        public string ColourSpaceName => "DeviceCMYK";

        /// <summary>
        /// The cyan colour level, from 0.0 (representing no cyan component) to 1.0 (maximal cyan component).
        /// </summary>
        public double Cyan { get; private set; }

        /// <summary>
        /// The magenta colour level, from 0.0 (representing no magenta component) to 1.0 (maximal magenta component).
        /// </summary>
        public double Magenta { get; private set; }

        /// <summary>
        /// The yellow colour level, from 0.0 (representing no yellow component) to 1.0 (maximal yellow component).
        /// </summary>
        public double Yellow { get; private set; }

        /// <summary>
        /// The black colour level, from 0.0 (representing no black component) to 1.0 (maximal black component).
        /// </summary>
        public double Black { get; private set; }

        /// <summary>
        /// Construct an immutable <see cref="CmykColour" /> instance.
        /// </summary>
        /// <param name="cyan">The cyan level.</param>
        /// <param name="magenta">The magenta level.</param>
        /// <param name="yellow">The yellow level.</param>
        /// <param name="black">The black level.</param>
        /// <exception cref="ArgumentOutOfRangeException">One or more of the parameters is less than 0 or greater than 1.</exception>
        public CmykColour(double cyan, double magenta, double yellow, double black)
        {
            ParameterValidationHelper.CheckDoubleValueBetweenZeroAndOne(cyan, nameof(cyan), GeneralResources.CmykColour_Error_ValueOutOfRange);
            ParameterValidationHelper.CheckDoubleValueBetweenZeroAndOne(magenta, nameof(magenta), GeneralResources.CmykColour_Error_ValueOutOfRange);
            ParameterValidationHelper.CheckDoubleValueBetweenZeroAndOne(yellow, nameof(yellow), GeneralResources.CmykColour_Error_ValueOutOfRange);
            ParameterValidationHelper.CheckDoubleValueBetweenZeroAndOne(black, nameof(black), GeneralResources.CmykColour_Error_ValueOutOfRange);

            Cyan = cyan;
            Magenta = magenta;
            Yellow = yellow;
            Black = black;
        }

        /// <summary>
        /// Generate a sequence of <see cref="PdfOperator" />s to change the selected stroke colour from <c>currentColour</c> to this colour.  This could be an empty
        /// sequence (if this colour and <c>currentColour</c> are equal) or a single space-and-colour combined selection operator.
        /// </summary>
        /// <param name="currentColour">The current stroking colour.</param>
        /// <returns>A sequence of zero or one <see cref="PdfOperator" />s.</returns>
        public IEnumerable<PdfOperator> StrokeSelectionOperators(IUniColour currentColour) 
            => ColourSelectionOperators(currentColour, PdfOperator.SetDeviceCmykStrokingColour);

        /// <summary>
        /// Generate a sequence of <see cref="PdfOperator" />s to change the selected non-stroke colour from <c>currentColour</c> to this colour.  This could be an empty
        /// sequence (if this colour and <c>currentColour</c> are equal) or a single space-and-colour combined selection operator.
        /// </summary>
        /// <param name="currentColour">The current non-stroking colour.</param>
        /// <returns>A sequence of zero or one <see cref="PdfOperator" />s.</returns>
        public IEnumerable<PdfOperator> NonStrokeSelectionOperators(IUniColour currentColour)
            => ColourSelectionOperators(currentColour, PdfOperator.SetDeviceCmykNonStrokingColour);

        private IEnumerable<PdfOperator> ColourSelectionOperators(IUniColour currentColour, Func<PdfNumber, PdfNumber, PdfNumber, PdfNumber, PdfOperator> operatorGenerator)
        {
            if (this == currentColour)
            {
                return Array.Empty<PdfOperator>();
            }
            return new[] { operatorGenerator(new PdfReal(Cyan), new PdfReal(Magenta), new PdfReal(Yellow), new PdfReal(Black)) };
        }

        /// <summary>
        /// Equality operator between <see cref="CmykColour" /> and <see cref="IUniColour" />.
        /// </summary>
        /// <param name="cmyk">A <see cref="CmykColour" /> instance.</param>
        /// <param name="other">An <see cref="IUniColour" /> instance.</param>
        /// <returns>
        /// <c>true</c> if the second operand is a <see cref="CmykColour" /> instance with the same colour levels as the first operand or both operands are <c>null</c>;
        /// <c>false</c> otherwise.
        /// </returns>
        public static bool operator ==(CmykColour cmyk, IUniColour other)
        {
            if (cmyk is null)
            {
                return other is null;
            }
            if (!(other is CmykColour otherCmyk))
            {
                return false;
            }
            return cmyk.Cyan == otherCmyk.Cyan && cmyk.Magenta == otherCmyk.Magenta && cmyk.Yellow == otherCmyk.Yellow && cmyk.Black == otherCmyk.Black;
        }

        /// <summary>
        /// Equality operator between <see cref="IUniColour" /> and <see cref="CmykColour" />.
        /// </summary>
        /// <param name="cmyk">A <see cref="CmykColour" /> instance.</param>
        /// <param name="other">An <see cref="IUniColour" /> instance.</param>
        /// <returns>
        /// <c>true</c> if the first operand is a <see cref="CmykColour" /> instance with the same colour levels as the second operand or both operands are <c>null</c>;
        /// <c>false</c> otherwise.
        /// </returns>
        public static bool operator ==(IUniColour other, CmykColour cmyk) => cmyk == other;

        /// <summary>
        /// Inequality operator between <see cref="CmykColour" /> and <see cref="IUniColour" />.
        /// </summary>
        /// <param name="cmyk">An <see cref="CmykColour" /> instance.</param>
        /// <param name="other">An <see cref="IUniColour" /> instance.</param>
        /// <returns>
        /// <c>true</c> if the second operand is not a <see cref="CmykColour" /> instance, is a <see cref="CmykColour" /> instance with different colour levels to the
        /// first operand, or one and only one operand is <c>null</c>.  <c>false</c> if the second operand is a <see cref="CmykColour" /> instance with the same colour
        /// levels as the first operand, or both operands are <c>null</c>.
        /// </returns>
        public static bool operator !=(CmykColour cmyk, IUniColour other)
        {
            if (cmyk is null)
            {
                return !(other is null);
            }
            if (!(other is CmykColour otherCmyk))
            {
                return true;
            }
            return cmyk.Cyan != otherCmyk.Cyan || cmyk.Magenta != otherCmyk.Magenta || cmyk.Yellow != otherCmyk.Yellow || cmyk.Black != otherCmyk.Black;
        }

        /// <summary>
        /// Inequality operator between <see cref="IUniColour" /> and <see cref="CmykColour" />.
        /// </summary>
        /// <param name="cmyk">An <see cref="CmykColour" /> instance.</param>
        /// <param name="other">An <see cref="IUniColour" /> instance.</param>
        /// <returns>
        /// <c>true</c> if the first operand is not a <see cref="CmykColour" /> instance, is a <see cref="CmykColour" /> instance with different colour levels to the
        /// second operand, or one and only one operand is <c>null</c>.  <c>false</c> if the first operand is a <see cref="CmykColour" /> instance with the same colour
        /// levels as the second operand, or both operands are <c>null</c>.
        /// </returns>
        public static bool operator !=(IUniColour other, CmykColour cmyk) => cmyk != other;

        /// <summary>
        /// Equality-testing method.
        /// </summary>
        /// <param name="other">An <see cref="IUniColour" /> instance.</param>
        /// <returns><c>true</c> if the parameter is a <see cref="CmykColour" /> instance with the same colour levels as this object, <c>false</c> otherwise.</returns>
        public bool Equals(IUniColour other) => this == other;

        /// <summary>
        /// Equality-testing method.
        /// </summary>
        /// <param name="obj">Any object or value.</param>
        /// <returns><c>true</c> if the parameter is a <see cref="CmykColour" /> instance with the same colour levels as this object, <c>false</c> otherwise.</returns>
        public override bool Equals(object obj) => obj is IUniColour other && Equals(other);

        /// <summary>
        /// Generate a hash code for this object.
        /// </summary>
        /// <returns>A hash code representing this object.</returns>
        public override int GetHashCode() => ((Cyan * 11).GetHashCode()) ^ ((Magenta * 13).GetHashCode()) ^ ((Yellow * 17).GetHashCode()) ^ (Black.GetHashCode());
    }
}