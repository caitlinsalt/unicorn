namespace Unicorn.Base
{
    /// <summary>
    /// An object that can be drawn onto a graphics context.
    /// </summary>
    public interface IDrawable
    {
        /// <summary>
        /// The height of this drawable.  For some hypothetical drawables this may potentially change if the 
        /// drawable's other properties change.
        /// </summary>
        double ContentHeight { get; }

        /// <summary>
        /// Draw this object.
        /// </summary>
        /// <param name="context">The context to use for drawing.</param>
        /// <param name="x">The X-coordinate of the top left corner of the object.</param>
        /// <param name="y">The Y-coordinate of the top left corner of the object.</param>
        void DrawAt(IGraphicsContext context, double x, double y);
    }
}
