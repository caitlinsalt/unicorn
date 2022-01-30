using System;

namespace Unicorn.Exceptions
{
    /// <summary>
    /// Exception thrown when Unicorn cannot parse an image file sufficiently to embed it in a PDF.
    /// </summary>
    public class InvalidImageException : Exception
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public InvalidImageException() : base() { }

        /// <summary>
        /// Constructor with error message parameter.
        /// </summary>
        /// <param name="message">The error message.</param>
        public InvalidImageException(string message) : base(message) { }

        /// <summary>
        /// Constructor with error message and triggering exception parameters.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="innerException">The exception whose throwing triggered this one.</param>
        public InvalidImageException(string message, Exception innerException) : base(message, innerException) { }
    }
}
