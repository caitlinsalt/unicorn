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
        public TestException() { }

        public TestException(string message) : base(message) { }

        public TestException(string message, Exception innerException) : base(message, innerException) { }
    }
}
