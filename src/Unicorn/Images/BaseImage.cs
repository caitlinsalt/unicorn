using System;
using System.Collections.Generic;
using System.Text;
using Unicorn.CoreTypes;

namespace Unicorn.Images
{
    public abstract class BaseImage : IImage
    {
        public abstract int DotWidth { get; }

        public abstract int DotHeight { get; }

        public double AspectRatio => (double)DotWidth / DotHeight;
    }
}
