using System.Collections.Generic;
using Unicorn.Base;
using Unicorn.Writer.Primitives;

namespace Unicorn
{
    /// <summary>
    /// Represents a colour in a PDF document, including knowledge of the colour space it is in.  This interface extends the <see cref="IUniColour" /> interface by
    /// requiring implementations to provide methods for generating the low-level PDF stroke and non-stroke colour selection operators to select this colour.  These
    /// methods are required by the Unicorn drawing operations.
    /// </summary>
    public interface IColour : IUniColour
    {
        /// <summary>
        /// Return a sequence of <see cref="PdfOperator"/>s to change the selected stroke colour from <c>currentColour</c> to this.  This may be an empty sequence
        /// (if <c>currentColour</c> equals this colour), two operators (a colour space selection operator followed by a colour selection operator) or one (a 
        /// colour selection operator alone, or a combined space-and-colour selection operator).
        /// </summary>
        /// <param name="currentColour">The currently-selected stroke colour.</param>
        /// <returns>A sequence of either zero, one or two <see cref="PdfOperator" /> objects.</returns>
        IEnumerable<PdfOperator> StrokeSelectionOperators(IUniColour currentColour);

        /// <summary>
        /// Return a sequence of <see cref="PdfOperator"/>s to change the selected non-stroke colour from <c>currentColour</c> to this.  This may be an empty sequence
        /// (if <c>currentColour</c> equals this colour), two operators (a colour space selection operator followed by a colour selection operator) or one (a 
        /// colour selection operator alone, or a combined space-and-colour selection operator).
        /// </summary>
        /// <param name="currentColour">The currently-selected non-stroke colour.</param>
        /// <returns>A sequence of either zero, one or two <see cref="PdfOperator" /> objects.</returns>
        IEnumerable<PdfOperator> NonStrokeSelectionOperators(IUniColour currentColour);
    }
}
