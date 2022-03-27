using System;

namespace Unicorn.Exceptions
{
    /// <summary>
    /// Exception thrown when a closed page has been written to.
    /// </summary>
    public class PageClosedException : Exception
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public PageClosedException() : base()
        { }

        /// <summary>
        /// Constructor with error message.
        /// </summary>
        /// <param name="message">The error message.</param>
        public PageClosedException(string message) : base(message)
        { }

        /// <summary>
        /// Constructor with error message and inner exception.  Provided for completeness.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="innerException">The inner exception.</param>
        public PageClosedException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
