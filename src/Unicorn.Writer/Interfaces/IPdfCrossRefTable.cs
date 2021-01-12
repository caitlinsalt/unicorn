namespace Unicorn.Writer.Interfaces
{
    /// <summary>
    /// Interface representing a PDF cross-reference table.  It consists of numbered slots, each referring to an object and its offset within the output stream.
    /// </summary>
    public interface IPdfCrossRefTable : IPdfWriteable
    {
        /// <summary>
        /// Return the number of slots claimed from the table.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Request a fresh slot from the table.
        /// </summary>
        /// <returns>The ID number of the newly-claimed slot.</returns>
        int ClaimSlot();

        /// <summary>
        /// Set the stream offset of a slot entry.
        /// </summary>
        /// <param name="value">An indirect object whose ObjectId property is a slot ID number previously obtained by a call to <see cref="ClaimSlot" />.</param>
        /// <param name="offset">The byte offset of the object within the PDF stream.</param>
        void SetSlot(IPdfIndirectObject value, int offset);
    }
}
