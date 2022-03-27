using System;
using System.Collections.Generic;
using Unicorn.Base;
using Unicorn.Helpers;
using Unicorn.Writer.Primitives;

namespace Unicorn
{
    /// <summary>
    /// Represents a colour in the device-dependent greyscale colour space.
    /// </summary>
    public class GreyscaleColour : IColour
    {
        /// <summary>
        /// The name of the colour space of this colour, "/DeviceGrayscale".
        /// </summary>
        public string ColourSpaceName => "DeviceGrayscale";

        /// <summary>
        /// The grey level of this colour, with 0.0 representing black and 1.0 representing white.
        /// </summary>
        public double GreyLevel { get; private set; }

        /// <summary>
        /// In general, in a PDF, the components of a colour are treated as continuous ranges between 0 and 1 inclusive.  The exception to this is when handling
        /// rasterised image data, when the components are treated as unsigned integers.  When an instance of this colour is used in rasterised image data,
        /// it is represented as an 8 bit integer.
        /// </summary>
        public int BitsPerComponent => 8;

        /// <summary>
        /// In general, in a PDF, the components of a colour are treated as continuous ranges between 0 and 1 inclusive.  The exception to this is when handling
        /// rasterised image data, when the components are treated as unsigned integers.  This property returns the value of this colour as an array of one
        /// element, that being its greyscale value quantised over the range 0 to 255 inclusive.
        /// </summary>
        public IEnumerable<byte> ComponentData => new[] { GreyLevel.ScaleToByte() };

        private static readonly Lazy<GreyscaleColour> _black = new Lazy<GreyscaleColour>(() => new GreyscaleColour(0));

        /// <summary>
        /// A predefined black greyscale colour.
        /// </summary>
        public static GreyscaleColour Black => _black.Value;

        private static readonly Lazy<GreyscaleColour> _white = new Lazy<GreyscaleColour>(() => new GreyscaleColour(1));

        /// <summary>
        /// A predefined white greyscale colour.
        /// </summary>
        public static GreyscaleColour White => _white.Value;

        /// <summary>
        /// Create an immutable greyscale colour object.
        /// </summary>
        /// <param name="grey">The grey level of the colour, with 0.0 representing black and 1.0 representing white</param>
        /// <exception cref="ArgumentOutOfRangeException"><c>grey</c> is less than 0 or greater than 1.</exception>
        public GreyscaleColour(double grey)
        {
            ParameterValidationHelper.CheckDoubleValueBetweenZeroAndOne(grey, nameof(grey), GeneralResources.GreyscaleColour_Error_ValueOutOfRange);

            GreyLevel = grey;
        }

        /// <summary>
        /// Generate a sequence of <see cref="PdfOperator" />s to change the stroking colour from <c>currentColour</c> to this colour.  This could be an empty sequence,
        /// or a sequence containing a single space-and-colour selection operator.
        /// </summary>
        /// <param name="currentColour">The current stroking colour.</param>
        /// <returns>A sequence of either zero or one <see cref="PdfOperator" />s which will change the stroking colour from the current colour to this colour.</returns>
        public IEnumerable<PdfOperator> StrokeSelectionOperators(IUniColour currentColour)
        {
            if (this == currentColour)
            {
                return Array.Empty<PdfOperator>();
            }
            return new[] { PdfOperator.SetDeviceGreyscaleStrokingColour(new PdfReal(GreyLevel)) };
        }

        /// <summary>
        /// Generate a sequence of <see cref="PdfOperator" />s to change the non-stroking colour from <c>currentColour</c> to this colour.  This could be an empty 
        /// sequence, or a sequence containing a single space-and-colour selection operator.
        /// </summary>
        /// <param name="currentColour">The current non-stroking colour.</param>
        /// <returns>
        /// A sequence of either zero or one <see cref="PdfOperator" />s which will change the non-stroking colour from the current colour to this colour.
        /// </returns>
        public IEnumerable<PdfOperator> NonStrokeSelectionOperators(IUniColour currentColour)
        {
            if (this == currentColour)
            {
                return Array.Empty<PdfOperator>();
            }
            return new[] { PdfOperator.SetDeviceGreyscaleNonStrokingColour(new PdfReal(GreyLevel)) };
        }

        /// <summary>
        /// Equality operator between <see cref="GreyscaleColour" /> and any <see cref="IUniColour" />.
        /// </summary>
        /// <param name="g">A <see cref="GreyscaleColour" /> instance.</param>
        /// <param name="other">An <see cref="IUniColour" /> instance.</param>
        /// <returns>
        /// <c>true</c> if the second operand is a <see cref="GreyscaleColour" /> instance with the same grey level as the first operand, <c>false</c> otherwise.
        /// </returns>
        public static bool operator ==(GreyscaleColour g, IUniColour other)
        {
            if (g is null)
            {
                return other is null;
            }
            if (!(other is GreyscaleColour otherGrey))
            {
                return false;
            }
            return g.GreyLevel == otherGrey.GreyLevel;
        }

        /// <summary>
        /// Equality operator between <see cref="IUniColour" /> and <see cref="GreyscaleColour" />.
        /// </summary>
        /// <param name="other">An <see cref="IUniColour" /> instance.</param>
        /// <param name="g">A <see cref="GreyscaleColour" /> instance.</param>
        /// <returns>
        /// <c>true</c> if the first operand is a <see cref="GreyscaleColour" /> instance with the same grey level as the second operand of if both
        /// operands are <c>null</c>; <c>false</c> otherwise.
        /// </returns>
        public static bool operator ==(IUniColour other, GreyscaleColour g) => g == other;

        /// <summary>
        /// Inequality operator between <see cref="GreyscaleColour" /> and <see cref="IUniColour" />.
        /// </summary>
        /// <param name="g">A <see cref="GreyscaleColour" /> instance.</param>
        /// <param name="other">An <see cref="IUniColour" /> instance.</param>
        /// <returns>
        /// <c>true</c> if the second operand is not a <see cref="GreyscaleColour" /> instance or is a <see cref="GreyscaleColour" /> instance with a different grey 
        /// level to the first operand; <c>false</c> if the second operand is a <see cref="GreyscaleColour" /> instance with the same grey level as the first operand,
        /// or if both operands are <c>null</c>.
        /// </returns>
        public static bool operator !=(GreyscaleColour g, IUniColour other)
        {
            if (g is null)
            {
                return !(other is null);
            }
            if (!(other is GreyscaleColour otherGrey))
            {
                return true;
            }
            return g.GreyLevel != otherGrey.GreyLevel;
        }

        /// <summary>
        /// Inequality operator between <see cref="IUniColour" /> and <see cref="GreyscaleColour" />.
        /// </summary>
        /// <param name="other">An <see cref="IUniColour" /> instance.</param>
        /// <param name="g">A <see cref="GreyscaleColour" /> instance.</param>
        /// <returns>
        /// <c>true</c> if the first operand is not a <see cref="GreyscaleColour" /> instance or is a <see cref="GreyscaleColour" /> instance with a different grey
        /// level to the second operand; <c>false</c> if the first operand is a <see cref="GreyscaleColour" /> instance with the same grey level as the second operand,
        /// or if both operands are <c>null</c>.
        /// </returns>
        public static bool operator !=(IUniColour other, GreyscaleColour g) => g != other;

        /// <summary>
        /// Equality-testing method.
        /// </summary>
        /// <param name="other">An <see cref="IUniColour" /> instance.</param>
        /// <returns><c>true</c> if <c>other</c> is a <see cref="GreyscaleColour" /> instance with the same grey level as <c>this</c>, <c>false</c> otherwise.</returns>
        public bool Equals(IUniColour other) => this == other;

        /// <summary>
        /// Equality-testing method.
        /// </summary>
        /// <param name="obj">Any object or value.</param>
        /// <returns><c>true</c> if <c>obj</c> is a <see cref="GreyscaleColour" /> intance with the same grey level as <c>this</c>, <c>false</c> otherwise.</returns>
        public override bool Equals(object obj) => obj is IUniColour other && Equals(other);

        /// <summary>
        /// Generate a hash code for this object.
        /// </summary>
        /// <returns>A hash code representing this object.</returns>
        public override int GetHashCode() => GreyLevel.GetHashCode() ^ 8339;
    }
}
