namespace Unicorn.CoreTypes
{
    /// <summary>
    /// A drawable object of known size.
    /// </summary>
    public interface IKnownSizeDrawable : IDrawable
    {
        /// <summary>
        /// The width of this drawable.
        /// </summary>
        double Width { get; }

        /// <summary>
        /// The height of this drawable.
        /// </summary>
        double Height { get; }
    }
}
