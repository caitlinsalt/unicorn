using System;
using Unicorn.Writer.Primitives;

namespace Unicorn.Writer.Structural
{
    /// <summary>
    /// A class which represents a PDF catalogue.  This is the root object of every PDF file, referenced from the trailer.
    /// </summary>
    public class PdfCatalogue : PdfSpecialisedDictionary
    {
        /// <summary>
        /// The root of the document page tree.
        /// </summary>
        public PdfPageTreeNode PageRoot { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="pageRoot">The document page tree root node.</param>
        /// <param name="objectId">The indirect object ID of the catalogue.</param>
        /// <param name="generation">The generation number of the catalogue.  This defaults to zero and can effectively be ignored when creating a new document.</param>
        /// <exception cref="ArgumentNullException">Thrown if the pageRoot parameter is null.</exception>
        public PdfCatalogue(PdfPageTreeNode pageRoot, int objectId, int generation = 0) : base(objectId, generation)
        {
            PageRoot = pageRoot ?? throw new ArgumentNullException(nameof(pageRoot));
        }

        /// <summary>
        /// Construct the dictionary which will be written to the output to represent this object.
        /// </summary>
        /// <returns>A <see cref="PdfDictionary" /> containing the properties of this object in the correct format.</returns>
        protected override PdfDictionary MakeDictionary()
        {
            PdfDictionary d = new PdfDictionary
            {
                { CommonPdfNames.Type, CommonPdfNames.Catalog },
                { CommonPdfNames.Pages, PageRoot.GetReference() }
            };
            return d;
        }
    }
}
