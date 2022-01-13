using System;

namespace Unicorn.Exceptions
{
    /// <summary>
    /// An <see cref="Exception" /> thrown when trying to split drawables for layout reasons.
    /// </summary>
    public class DrawableSplitException : Exception
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public DrawableSplitException() : base() { }

        /// <summary>
        /// Constructor with error message.
        /// </summary>
        /// <param name="message">An error message.</param>
        public DrawableSplitException(string message) : base(message) { }

        /// <summary>
        /// Constructor with error message and inner exception.
        /// </summary>
        /// <param name="message">An error message.</param>
        /// <param name="innerException">The exception which triggered this one.</param>
        public DrawableSplitException(string message, Exception innerException) : base(message, innerException) { }
    }
}
