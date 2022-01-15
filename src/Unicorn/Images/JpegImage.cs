using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Unicorn.CoreTypes;

namespace Unicorn.Images
{
    public class JpegImage : BaseImage
    {
        private Stream _dataStream;

        public override int DotWidth => throw new NotImplementedException();

        public override int DotHeight => throw new NotImplementedException();

        public JpegImage(Stream stream)
        {
            _dataStream = stream;
            stream.Seek(7, SeekOrigin.Begin);

        }
    }
}
