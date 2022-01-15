using Unicorn.FontTools.OpenType.Utility;

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
        { }

        /// <summary>
        /// Dump this table's content.
        /// </summary>
        public abstract IDumpBlock Dump();
    }
}
