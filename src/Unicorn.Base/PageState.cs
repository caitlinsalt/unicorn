using System;
using System.Collections.Generic;
using System.Text;

namespace Unicorn.Base
{
    /// <summary>
    /// The composition state of a page.
    /// </summary>
    public enum PageState
    {
        /// <summary>
        /// Open for drawing.
        /// </summary>
        Open,

        /// <summary>
        /// Closed, so no longer writeable.
        /// </summary>
        Closed
    }
}
