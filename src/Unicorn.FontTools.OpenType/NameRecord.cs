using System;
using Unicorn.FontTools.OpenType.Utility;

namespace Unicorn.FontTools.OpenType
{
    /// <summary>
    /// An individual entry in the 'name' table.
    /// </summary>
    public class NameRecord
    {
        /// <summary>
        /// The OS platform for this name.
        /// </summary>
        public PlatformId PlatformId { get; private set; }

        /// <summary>
        /// The byte encoding for this name (values are platform-specific).  Within the range of a <see cref="ushort" />.
        /// </summary>
        public int EncodingId { get; private set; }

        /// <summary>
        /// The language ID for this name.  Values less than 0x8000 are platform-specific.  Values greater than 0x8000 indicate that this name is from a Version 1
        /// name table and the language is defined using a language tag record in the table.  Within the range of a <see cref="ushort" />.
        /// </summary>
        public int LanguageId { get; private set; }

        /// <summary>
        /// The kind of name stored in this record.  Values greater than 0xff are font-specific.
        /// </summary>
        public NameField NameId { get; private set; }

        /// <summary>
        /// The content of the name record, or a message if the content cannot be decoded.
        /// </summary>
        public string Content { get; private set; }

        /// <summary>
        /// Flag to indicate if the <see cref="Content" /> of this record is a filler message inserted because the encoding used by the actual content is not supported
        /// on this platform.  Records with this flag set will not be returned by the <see cref="NamingTable.Search(NameField)" /> method.
        /// </summary>
        public bool FillerContent { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="platform">The value for the <see cref="PlatformId" /> property.</param>
        /// <param name="encoding">The value for the <see cref="EncodingId" /> property. Must be within the range of a <see cref="ushort" />.</param>
        /// <param name="lang">The value for the <see cref="LanguageId" /> property. Must be within the range of a <see cref="ushort" />.</param>
        /// <param name="nameId">The value for the <see cref="NameId" /> property.</param>
        /// <param name="content">The value for the <see cref="Content" /> property.</param>
        /// <param name="fillerContent">The value for the <see cref="FillerContent" /> property.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if either the <c>encoding</c> or <c>lang</c> parameters are less than 0 or greater than 
        ///   65,535.</exception>
        public NameRecord(PlatformId platform, int encoding, int lang, NameField nameId, string content, bool fillerContent)
        {
            FieldValidation.ValidateUShortParameter(encoding, nameof(encoding));
            FieldValidation.ValidateUShortParameter(lang, nameof(lang));

            PlatformId = platform;
            EncodingId = encoding;
            LanguageId = lang;
            NameId = nameId;
            Content = content;
            FillerContent = fillerContent;
        }
    }
}
