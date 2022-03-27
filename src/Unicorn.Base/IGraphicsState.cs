namespace Unicorn.Base
{
    /// <summary>
    /// Encapsulates a saved state of an <see cref="IGraphicsContext" /> implementation instance. 
    /// </summary>
    public interface IGraphicsState
    {
        /// <summary>
        /// The current line drawing width.
        /// </summary>
        double LineWidth { get; }

        /// <summary>
        /// The current line drawing dash style.
        /// </summary>
        UniDashStyle DashStyle { get; }
    }
}
