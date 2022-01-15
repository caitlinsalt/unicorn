using System;
using System.Diagnostics.CodeAnalysis;

namespace Tests.Utility.Exceptions
{
    /// <summary>
    /// A utility exception class for use where a generic exception instance is needed, but using <see cref="Exception" /> triggers code quality warnings.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class TestException : Exception
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public TestException() { }

        /// <summary>
        /// Constructor which takes an error message.
        /// </summary>
        /// <param name="message">The exception's error message.</param>
        public TestException(string message) : base(message) { }

        /// <summary>
        /// Constructor which takes an error message and an underlying exception.
        /// </summary>
        /// <param name="message">The exception's error message.</param>
        /// <param name="innerException">The underlying exception.</param>
        public TestException(string message, Exception innerException) : base(message, innerException) { }
    }
}
