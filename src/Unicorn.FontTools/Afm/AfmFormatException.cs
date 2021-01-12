using System;

namespace Unicorn.FontTools.Afm
{
    /// <summary>
    /// Exception type thrown when an attempt is made to load a malformed AFM file.
    /// </summary>
    public class AfmFormatException : Exception
    {
        /// <summary>
        /// Parameterless constructor.
        /// </summary>
        public AfmFormatException()
        {
        }

        /// <summary>
        /// Constructor with error message.
        /// </summary>
        /// <param name="message">The error message.</param>
        public AfmFormatException(string message) : base(message)
        {
        }

        /// <summary>
        /// Constructor with error message and inner exception.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="innerException">The exception which caused this one to be thrown.</param>
        public AfmFormatException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
