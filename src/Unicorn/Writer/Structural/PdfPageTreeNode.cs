using System;
using System.Collections.Generic;
using System.Linq;
using Unicorn.Writer.Interfaces;
using Unicorn.Writer.Primitives;

namespace Unicorn.Writer.Structural
{
    /// <summary>
    /// Represents an intermediate node in a PDF page tree.  Each document contains a page tree, and each tree contains at least one <see cref="PdfPageTreeNode" /> object, which is the root
    /// of the page tree.  The documents' pages are the leaves of the tree.
    /// </summary>
    public class PdfPageTreeNode : PdfPageTreeItem
    {
        /// <summary>
        /// The children of this node; the name matches the name when the object is written.
        /// </summary>
        public IList<PdfPageTreeItem> Kids { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="parent">The parent node of this node (null if this is the root of the page tree).</param>
        /// <param name="objectId">The indirect object ID of the node.</param>
        /// <param name="generation">The generation number of this object.  Defaults to 0.  As the library does not support rewriting existing files, should not be set.</param>
        public PdfPageTreeNode(PdfPageTreeNode parent, int objectId, int generation = 0) : base(parent, objectId, generation)
        {
            Kids = new List<PdfPageTreeItem>();
        }

        /// <summary>
        /// Add an item to the tree, either a node or a page.
        /// </summary>
        /// <param name="child">The item to be added to the tree.</param>
        /// <exception cref="ArgumentNullException">Thrown if the child parameter is null.</exception>
        public void Add(PdfPageTreeItem child)
        {
            if (child == null)
            {
                throw new ArgumentNullException(nameof(child));
            }
            Kids.Add(child);
        }

        /// <summary>
        /// Construct the dictionary which will be written to the output to represent this object.
        /// </summary>
        /// <returns>A <see cref="PdfDictionary" /> containing the properties of this object in the correct format.</returns>
        protected override PdfDictionary MakeDictionary()
        {
            PdfDictionary dictionary = new PdfDictionary();
            dictionary.Add(CommonPdfNames.Type, CommonPdfNames.Pages);
            dictionary.Add(CommonPdfNames.Count, new PdfInteger(Kids.Count));
            if (Parent != null)
            {
                dictionary.Add(CommonPdfNames.Parent, Parent.GetReference());
            }
            dictionary.Add(CommonPdfNames.Kids, new PdfArray(Kids.Select(item => (IPdfPrimitiveObject)item.GetReference())));
            return dictionary;
        }
    }
}
