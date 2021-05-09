using System;

namespace Unicorn.Base
{
    /// <summary>
    /// Represents a colour in a PDF document, including knowledge of the colour space it exists in.
    /// </summary>
    /// <remarks>
    /// Developers wishing to implement this interface should consider instead implementing the <c>Unicorn.IColour</c> interface, which extends this interface 
    /// with methods for generating low-level PDF colour selection operators.  Many Unicorn methods which expect an <see cref="IUniColour" /> parameter will fail
    /// (either silently or loudly, depending on settings) if passed an object that does not implement <c>IColour</c>.
    /// </remarks>
    public interface IUniColour : IEquatable<IUniColour>
    {
        /// <summary>
        /// The name of the colour space which this colour is a member of.
        /// </summary>
        string ColourSpaceName { get; }
    }
}
