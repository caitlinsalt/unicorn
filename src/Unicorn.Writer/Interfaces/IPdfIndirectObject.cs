using Unicorn.Writer.Primitives;

namespace Unicorn.Writer.Interfaces
{
    /// <summary>
    /// The interface which represents an "indirect object".  A PDF indirect object is a top-level object in the file, can be uniquely identified among the indirect objects in the file by
    /// its combination of object ID and generation number, and is indexed in the file's cross-reference table.  It consists of a direct object wrapped with a prologue and epilogue.
    /// </summary>
    public interface IPdfIndirectObject : IPdfWriteable
    {
        /// <summary>
        /// The object ID number of this object.
        /// </summary>
        int ObjectId { get; }

        /// <summary>
        /// The generation number of this object.  As the library currently does not support rewriting existing files, this property will always equal zero.
        /// </summary>
        int Generation { get; }

        /// <summary>
        /// Return a <see cref="PdfReference" /> which refers to this object.
        /// </summary>
        /// <returns>A <see cref="PdfReference" /> object which refers to this object.</returns>
        PdfReference GetReference();
    }
}
