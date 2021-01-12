namespace Unicorn.CoreTypes
{
    /// <summary>
    /// A drawable object with a known location on the page.
    /// </summary>
    public interface IPositionedDrawable : IDrawable
    {
        /// <summary>
        /// The X-coordinate of the top left corner of this object.
        /// </summary>
        double X { get; set; }

        /// <summary>
        /// The Y-coordinate of the top left corner of this object.
        /// </summary>
        double Y { get; set; }

        /// <summary>
        /// Draw the object.
        /// </summary>
        /// <param name="context">The context to use to draw the object.</param>
        void Draw(IGraphicsContext context);
    }
}
