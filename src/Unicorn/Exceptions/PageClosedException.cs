using System;

namespace Unicorn.Exceptions
{
    public class PageClosedException : Exception
    {
        public PageClosedException() : base()
        { }

        public PageClosedException(string message) : base(message)
        { }

        public PageClosedException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}
