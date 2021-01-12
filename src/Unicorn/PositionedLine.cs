using System.Collections.Generic;
using Unicorn.CoreTypes;

namespace Unicorn
{
    /// <summary>
    /// A <see cref="Line" /> of words which has a set location within its context or container.
    /// </summary>
    public class PositionedLine : Line, IPositionedKnownSizeDrawable
    {
        /// <summary>
        /// The X-coordinate of the start of the line.
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// The Y-coordinate of the start of the line.
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// The width of the line.
        /// </summary>
        public double Width => MinWidth;

        /// <summary>
        /// The height of the line.
        /// </summary>
        public double Height => ContentHeight;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public PositionedLine() : base()
        {

        }

        /// <summary>
        /// Constructor which sets initial contents.
        /// </summary>
        /// <param name="words">The words which make up the content of the line.</param>
        public PositionedLine(IEnumerable<Word> words) : base(words)
        {

        }

        /// <summary>
        /// Draw the line of words, assuming that the line's coordinates are relative to the given context.
        /// </summary>
        /// <param name="context">The <see cref="IGraphicsContext" /> to use for drawing.</param>
        public void Draw(IGraphicsContext context)
        {
            DrawAt(context, X, Y);
        }
    }
}
