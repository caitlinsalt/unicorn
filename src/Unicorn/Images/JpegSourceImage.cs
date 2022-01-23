using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Unicorn.CoreTypes;

namespace Unicorn.Images
{
    public class JpegSourceImage : BaseSourceImage
    {
        private Stream _dataStream;

        public override int DotWidth => throw new NotImplementedException();

        public override int DotHeight => throw new NotImplementedException();

        public JpegSourceImage(Stream stream)
        {
            if (stream is null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            _dataStream = stream;
            stream.Seek(7, SeekOrigin.Begin);

        }
    }
}
