using System;
using Unicorn.FontTools.OpenType.Utility;

namespace Unicorn.FontTools.OpenType
{
    /// <summary>
    /// A table index record.  An OpenType file consists of an <see cref="OffsetTable" />, a sequence of <see cref="TableIndexRecord" /> entries whose length 
    /// corresponds to the number of tables given in the offset table, followed by the data tables themselves.
    /// </summary>
    public class TableIndexRecord
    {
        /// <summary>
        /// The table's tag.
        /// </summary>
        public Tag TableTag { get; private set; }

        /// <summary>
        /// The table checksum.  Within the range of a <see cref="uint" />.
        /// </summary>
        public long Checksum { get; private set; }

        /// <summary>
        /// The address of the start of this table, as a byte offset from the start of the file.  Within the range of a <see cref="uint" />.
        /// </summary>
        public long? Offset { get; private set; }

        /// <summary>
        /// The length of the table, in bytes.  Within the range of a <see cref="uint" />.
        /// </summary>
        public long Length { get; private set; }

        /// <summary>
        /// The content of the table, if it has been loaded into memory.
        /// </summary>
        public Table Data { get; set; }

        /// <summary>
        /// A method that can load the table into memory from an array of bytes.
        /// </summary>
        public TableLoadingMethod LoadingMethod { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="tag">The value of the <see cref="TableTag" /> property.</param>
        /// <param name="checksum">The value of the <see cref="Checksum" /> property.</param>
        /// <param name="offset">The value of the <see cref="Offset"/> property.</param>
        /// <param name="len">The value of the <see cref="Length"/> property.</param>
        /// <param name="loader">The loading method, which can convert an array of bytes to a <see cref="Table" /> object.</param>
        public TableIndexRecord(Tag tag, long checksum, long? offset, long len, TableLoadingMethod loader)
        {
            FieldValidation.ValidateUIntParameter(checksum, nameof(checksum));
            if (offset.HasValue)
            {
                FieldValidation.ValidateUIntParameter(offset.Value, nameof(offset));
            }
            FieldValidation.ValidateUIntParameter(len, nameof(len));

            TableTag = tag;
            Checksum = checksum;
            Offset = offset;
            Length = len;
            LoadingMethod = loader;
        }
    }
}
