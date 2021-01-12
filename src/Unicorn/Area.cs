using System.Collections.Generic;
using System.Linq;
using Unicorn.CoreTypes;

namespace Unicorn
{
    /// <summary>
    /// Represents a drawable container which contains drawable objects at fixed coordinates within the container.
    /// </summary>
    public class Area : IKnownSizeDrawable
    {
        /// <summary>
        /// The contents of the container.
        /// </summary>
        public IList<IPositionedKnownSizeDrawable> Contents { get; private set; }

        /// <summary>
        /// The width of the area, computed from the coordinates and widths of the area's contents.
        /// </summary>
        public double Width
        {
            get
            {
                return Contents.Count > 0 ? Contents.Select(c => c.X + c.Width).Max() : 0;
            }
        }

        /// <summary>
        /// The height of the area, computed from the coordinates and heights of the area's contents.
        /// </summary>
        public double Height
        {
            get
            {
                return Contents.Count > 0 ? Contents.Select(c => c.Y + c.Height).Max() : 0;
            }
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Area()
        {
            Contents = new List<IPositionedKnownSizeDrawable>();
        }

        /// <summary>
        /// Constructor which sets initial contents of the area.
        /// </summary>
        /// <param name="contents">The drawable contents of the area.</param>
        public Area(IEnumerable<IPositionedKnownSizeDrawable> contents)
        {
            Contents = contents.ToList();
        }

        /// <summary>
        /// Draw the area at a given location on a graphics context.
        /// </summary>
        /// <param name="context">The context to use for drawing.</param>
        /// <param name="x">The context-relative X coordinate of the top left corner of the area.</param>
        /// <param name="y">The context-relative Y coordinate of the top left corner of the area.</param>
        public void DrawAt(IGraphicsContext context, double x, double y)
        {
            foreach (var item in Contents)
            {
                item.DrawAt(context, x + item.X, y + item.Y);
            }
        }
    }
}
