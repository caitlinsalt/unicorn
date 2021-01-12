using System;

namespace Unicorn.FontTools
{
    /// <summary>
    /// A generic exception class for font-related exceptions.
    /// </summary>
    public class FontException : Exception
    {
        /// <summary>
        /// Parameterless constructor.
        /// </summary>
        public FontException()
        {
        }

        /// <summary>
        /// Constructor which sets the <see cref="Exception.Message" /> property.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public FontException(string message) : base(message)
        {
        }

        /// <summary>
        /// Constructor which sets the <see cref="Exception.Message" /> and <see cref="Exception.InnerException" /> properties.
        /// </summary>
        /// <param name="message">The exception message.</param>
        /// <param name="innerException">The inner exception.</param>
        public FontException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
