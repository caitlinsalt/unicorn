namespace Unicorn.Writer.Primitives
{
    /// <summary>
    /// Defines a number of commonly-used <see cref="PdfName" /> objects which are (or are likely to be) used in all PDF files at least once, to encourage 
    /// callers to reuse these objects instead of creating new instances.
    /// </summary>
    public static class CommonPdfNames
    {
        /// <summary>
        /// The /BaseFont name.
        /// </summary>
        public static readonly PdfName BaseFont = new PdfName("BaseFont");

        /// <summary>
        /// The /Catalog name.
        /// </summary>
        public static readonly PdfName Catalog = new PdfName("Catalog");

        /// <summary>
        /// The /Contents name.
        /// </summary>
        public static readonly PdfName Contents = new PdfName("Contents");

        /// <summary>
        /// The /Count name.
        /// </summary>
        public static readonly PdfName Count = new PdfName("Count");

        /// <summary>
        /// The /Filter name.
        /// </summary>
        public static readonly PdfName Filter = new PdfName("Filter");

        /// <summary>
        /// The /Font name.
        /// </summary>
        public static readonly PdfName Font = new PdfName("Font");

        /// <summary>
        /// The /Kids name.
        /// </summary>
        public static readonly PdfName Kids = new PdfName("Kids");

        /// <summary>
        /// The /Length name.
        /// </summary>
        public static readonly PdfName Length = new PdfName("Length");

        /// <summary>
        /// The /MediaBox name.
        /// </summary>
        public static readonly PdfName MediaBox = new PdfName("MediaBox");

        /// <summary>
        /// The /Page name.
        /// </summary>
        public static readonly PdfName Page = new PdfName("Page");

        /// <summary>
        /// The /Pages name.
        /// </summary>
        public static readonly PdfName Pages = new PdfName("Pages");

        /// <summary>
        /// The /Parent name.
        /// </summary>
        public static readonly PdfName Parent = new PdfName("Parent");

        /// <summary>
        /// The /Resources name.
        /// </summary>
        public static readonly PdfName Resources = new PdfName("Resources");

        /// <summary>
        /// The /Root name.
        /// </summary>
        public static readonly PdfName Root = new PdfName("Root");

        /// <summary>
        /// The /Size name.
        /// </summary>
        public static readonly PdfName Size = new PdfName("Size");

        /// <summary>
        /// The /Subtype name.
        /// </summary>
        public static readonly PdfName Subtype = new PdfName("Subtype");

        /// <summary>
        /// The /Type name.
        /// </summary>
        public static readonly PdfName Type = new PdfName("Type");
    }
}
