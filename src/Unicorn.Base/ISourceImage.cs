namespace Unicorn.CoreTypes
{
    /// <summary>
    /// A raster image which may be embedded in a PDF.
    /// </summary>
    public interface ISourceImage
    {
        /// <summary>
        /// Width of the image in pixels.
        /// </summary>
        int DotWidth { get; }

        /// <summary>
        /// Height of the image in pixels.
        /// </summary>
        int DotHeight { get; }

        /// <summary>
        /// Aspect ratio of the image, as the width divided by the height.
        /// </summary>
        double AspectRatio { get; }
    }
}
