using Unicorn.Writer.Primitives;

namespace Unicorn.Writer.Structural
{
    /// <summary>
    /// Represents the items in a PDF page tree, whether they be nodes or pages.
    /// </summary>
    public abstract class PdfPageTreeItem : PdfSpecialisedDictionary
    {
        /// <summary>
        /// The parent of this tree item.  Null if this object is the root of the tree.
        /// </summary>
        public PdfPageTreeNode Parent { get; }

        /// <summary>
        /// Value-setting constructor.
        /// </summary>
        /// <param name="parent">The parent of this item.  Can be null if this item is the root node of the tree.</param>
        /// <param name="objectId">The indirect object ID of this item.</param>
        /// <param name="generation">The generation number of this item.  Defaults to zero.  As the library does not currently support rewriting existing files, this parameter should not be set.</param>
        protected PdfPageTreeItem(PdfPageTreeNode parent, int objectId, int generation = 0) : base(objectId, generation)
        {
            Parent = parent;
        }
    }
}
