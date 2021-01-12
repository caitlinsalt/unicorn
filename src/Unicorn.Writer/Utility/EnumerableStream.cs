using System;
using System.Collections.Generic;
using System.IO;

namespace Unicorn.Writer.Utility
{
    internal class EnumerableStream : Stream
    {
        private readonly IEnumerator<byte> _data;

        internal EnumerableStream(IEnumerable<byte> data)
        {
            if (data is null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            _data = data.GetEnumerator();
        }

        public override bool CanRead => true;

        public override bool CanSeek => false;

        public override bool CanWrite => false;

        public override long Length => 0;

        public override long Position { get; set; }

        public override void Flush() => throw new InvalidOperationException();

        public override int Read(byte[] buffer, int offset, int count)
        {
            int i = 0;
            for (; i < count && _data.MoveNext(); ++i)
            {
                buffer[offset + i] = _data.Current;
            }
            return i;
        }

        public override long Seek(long offset, SeekOrigin origin) => throw new InvalidOperationException();

        public override void SetLength(long value) => throw new InvalidOperationException();

        public override void Write(byte[] buffer, int offset, int count) => throw new InvalidOperationException();
    }
}
