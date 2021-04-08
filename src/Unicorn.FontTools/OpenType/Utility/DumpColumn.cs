namespace Unicorn.FontTools.OpenType.Utility
{
    /// <summary>
    /// Column definition for dumped tabular data, consisting of a column name and alignment.
    /// </summary>
    public class DumpColumn
    {
        /// <summary>
        /// The column display name.
        /// </summary>
        public string HeaderText { get; private set; }

        /// <summary>
        /// The column alignment.
        /// </summary>
        public DumpAlignment Alignment { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">Column display name.</param>
        /// <param name="align">Column alignment.</param>
        public DumpColumn(string name, DumpAlignment align)
        {
            HeaderText = name;
            Alignment = align;
        }

        /// <summary>
        /// Constructor for a column with default left alignment.
        /// </summary>
        /// <param name="name">Column display name.</param>
        public DumpColumn(string name) : this(name, DumpAlignment.Left) { }
    }
}
