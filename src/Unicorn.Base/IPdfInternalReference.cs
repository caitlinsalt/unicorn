namespace Unicorn.Base
{
    /// <summary>
    /// The internal address of an object inside a PDF file, consisting of an ID and a versiob number.
    /// </summary>
    /// <remarks>
    /// Unicorn is intended to expose the inner workings of a PDF file as much as is possible.  However,
    /// it is useful for, say, an <see cref="IImageDescriptor"/> to advertise that it contains the internal
    /// address of the referenced image (which is naturally needed elsewhere in Unicorn) without Unicorn itself
    /// needing to convert all references back to their concrete implementations.  You can use an <see cref="IPdfInternalReference"/>
    /// instance to confirm uniqueness of an item within a file, as only one object within a PDF file can have
    /// a given ID-and-version tuple, but are otherwise encouraged to treat it as opaque.
    /// </remarks>
    public interface IPdfInternalReference
    {
        /// <summary>
        /// The ID of the object.
        /// </summary>
        int ObjectId { get; }

        /// <summary>
        /// The version number of the object.
        /// </summary>
        int Version { get; }
    }
}
