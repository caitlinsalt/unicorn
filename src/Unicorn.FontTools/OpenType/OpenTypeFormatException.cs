using System;

namespace Unicorn.FontTools.OpenType
{
    /// <summary>
    /// Exception type for any OpenType font loading issues.
    /// </summary>
    public class OpenTypeFormatException : Exception
    {
        /// <summary>
        /// Parameterless constructor.
        /// </summary>
        public OpenTypeFormatException()
        {
        }

        /// <summary>
        /// Constructor with message parameter.
        /// </summary>
        /// <param name="message">Error message.</param>
        public OpenTypeFormatException(string message) : base(message)
        {
        }

        /// <summary>
        /// Constructor with message and underlying cause parameters.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <param name="innerException">The underlying cause of this exception being thrown.</param>
        public OpenTypeFormatException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
