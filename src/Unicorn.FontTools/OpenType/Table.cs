using System.IO;

namespace Unicorn.FontTools.OpenType
{
    /// <summary>
    /// Abstract ancestor of tables - collections of data referred to by a four-character "tag".
    /// </summary>
    public abstract class Table
    {
        /// <summary>
        /// The tag for this table.
        /// </summary>
        public Tag TableTag { get; protected set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="tag">The tag for this table.</param>
        protected Table(Tag tag)
        {
            TableTag = tag;
        }

        /// <summary>
        /// Convenience constructor.
        /// </summary>
        /// <param name="tag">The name of the tag of this table.</param>
        protected Table(string tag) : this(new Tag(tag))
        {
        }

        /// <summary>
        /// Dump this table's content to a <see cref="TextWriter" /> in whatever way is appropriate.
        /// </summary>
        /// <param name="writer">The destination to dump the data to.</param>
        public abstract void Dump(TextWriter writer);
    }
}
