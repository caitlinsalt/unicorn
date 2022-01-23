namespace Unicorn.Base
{
    /// <summary>
    /// A drawable that can be split vertically if required for layout reasons.
    /// </summary>
    public interface ISplittable : IDrawable
    {
        /// <summary>
        /// A flag to indicate whether or not this drawable fits into the height of a given container.
        /// </summary>
        bool OverspillHeight { get; }

        /// <summary>
        /// Attempt to split this item vertically into two, if it does not fit into its current container.  If a split
        /// occurs, this object will be modified in-place to only contain the first part of the split, and a new object will 
        /// be returned containing the second part of the split.
        /// </summary>
        /// <param name="maxHeight">
        /// The height of the container the newly-split-off portion will be placed into.
        /// For example, when a paragraph is split across pages, this should be the available height on the second page.
        /// </param>
        /// <param name="waoControl">Whether or not to allow the creation of small items such as single-line paragraphs when splitting.</param>
        /// <returns>
        ///   An item containing the content that has been split off the end of this object, or <c>null</c> if a split was not required
        ///   or could not be performed.
        /// </returns>
        ISplittable Split(double? maxHeight, WidowsAndOrphans waoControl);
    }

    /// <summary>
    /// A drawable that can be split vertically if required for layout reasons.
    /// </summary>
    /// <typeparam name="T">The specific type of drawable returned by the <see cref="Split(double?, WidowsAndOrphans)" /> method.</typeparam>
    public interface ISplittable<out T> : IDrawable where T : ISplittable<T>
    {
        /// <summary>
        /// A flag to indicate whether or not this drawable fits into the height of a given container.
        /// </summary>
        bool OverspillHeight { get; }

        /// <summary>
        /// Attempt to split this item vertically into two, if it does not fit into its current container.  If a split
        /// occurs, this object will be modified in-place to only contain the first part of the split, and a new object will 
        /// be returned containing the second part of the split.
        /// </summary>
        /// <param name="maxHeight">
        /// The height of the container the newly-split-off portion will be placed into.
        /// For example, when a paragraph is split across pages, this should be the available height on the second page.
        /// </param>
        /// <param name="waoControl">Whether or not to allow the creation of small items such as single-line paragraphs when splitting.</param>
        /// <returns>
        ///   An item containing the content that has been split off the end of this object, or <c>null</c> if a split was not required
        ///   or could not be performed.
        /// </returns>
        T Split(double? maxHeight, WidowsAndOrphans waoControl);
    }
}
