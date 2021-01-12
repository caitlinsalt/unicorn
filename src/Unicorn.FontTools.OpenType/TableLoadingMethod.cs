namespace Unicorn.FontTools.OpenType
{
    /// <summary>
    /// A delegate type describing a method that loads a <see cref="Table" /> instance from an array of bytes.
    /// </summary>
    /// <param name="arr">The array to load from.</param>
    /// <param name="offset">The index at which the data to load starts.</param>
    /// <param name="len">The length of the data to load.</param>
    /// <returns>A <see cref="Table" />-derived instance containing data loaded from the array.</returns>
    public delegate Table TableLoadingMethod(byte[] arr, int offset, int len);
}
