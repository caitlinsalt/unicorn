namespace Unicorn.Writer.Interfaces
{
    /// <summary>
    /// An object reference inside a PDF document.
    /// </summary>
    public interface IPdfReference : IPdfPrimitiveObject
    {
        /// <summary>
        /// The ID of the referenced object.
        /// </summary>
        int ObjectId { get; }

        /// <summary>
        /// The "generation number" of the referenced object, for documents which have
        /// version history.
        /// </summary>
        int Generation { get; }
    }
}
