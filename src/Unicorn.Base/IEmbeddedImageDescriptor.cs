using System;
using System.Collections.Generic;
using System.Text;

namespace Unicorn.Base
{
    public interface IEmbeddedImageDescriptor
    {
        IPageDescriptor ParentPage { get; }
    }
}
