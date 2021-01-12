using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Unicorn.FontTools.OpenType.Extensions;
using Unicorn.FontTools.OpenType.Utility;

namespace Unicorn.FontTools.OpenType
{
    /// <summary>
    /// The 'name' table, containing descriptive strings.  The strings are encoded in platform-specific formats.  This class does not currently support strings stored
    /// in encodings that are not supported by .NET Core, which effectively means that names encoded for use on Apple computers cannot be loaded.
    /// </summary>
    public class NamingTable : Table
    {
        private static readonly List<EncodingMapRecord> _encodingMap = new List<EncodingMapRecord>();

        /// <summary>
        /// The table version.  Version 0 only supports names in certain fixed languages using platform-specific codes.  Version 1 supports arbitrary languages.
        /// This code does not currently support loading the language names for Version 1, and requires the user to know the language identification codes for each
        /// platform. 
        /// </summary>
        public int Version { get; private set; }

        /// <summary>
        /// The collection of strings in this table.
        /// </summary>
        public NameRecordCollection Names { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="version">The table version format.</param>
        /// <param name="data">The content of the table.</param>
        public NamingTable(int version, IEnumerable<NameRecord> data) : base("name")
        {
            FieldValidation.ValidateUShortParameter(version, nameof(version));

            Version = version;
            Names = new NameRecordCollection(data);
        }

        /// <summary>
        /// Dump the content of this table to a <see cref="TextWriter" />.  Returns silently if the parameter is <c>null</c>.
        /// </summary>
        /// <param name="writer">The writer to dump output to.</param>
        public override void Dump(TextWriter writer)
        {
            if (writer is null)
            {
                return;
            }
            writer.WriteLine("name table content:");
            writer.WriteLine($"Version {Version}");
            writer.WriteLine($"{Names.Count} names.");
            writer.WriteLine("Platform  | Encoding | Language | Name                   | Text");
            writer.WriteLine("----------|----------|----------|------------------------|------------------------------");
            foreach (NameRecord name in Names)
            {
                writer.WriteLine($"{name.PlatformId,9} |   {name.EncodingId,6} |   {name.LanguageId,6} | {name.NameId,22} | {name.Content}");
            }
        }

        /// <summary>
        /// Load a 'name' table from an array of bytes.
        /// </summary>
        /// <param name="arr">The array to load from.</param>
        /// <param name="offset">The starting position of the table in the array.</param>
        /// <param name="tableLen">The length of the data making up the table, in bytes.</param>
        /// <returns></returns>
        public static NamingTable FromBytes(byte[] arr, int offset, int tableLen)
        {
            FieldValidation.ValidateNonNegativeIntegerParameter(tableLen, nameof(tableLen));
            if (tableLen < 6)
            {
                throw new ArgumentException(Resources.NamingTable_FromBytes_InsufficientDataError);
            }
            ushort version = arr.ToUShort(offset);
            ushort count = arr.ToUShort(offset + 2);
            ushort stringStoreOffset = arr.ToUShort(offset + 4);
            List<NameRecord> names = new List<NameRecord>(count);
            for (int i = 0; i < count; ++i)
            {
                int nrOffset = offset + 6 + i * 12;
                PlatformId platform = (PlatformId)arr.ToUShort(nrOffset);
                ushort encoding = arr.ToUShort(nrOffset + 2);
                ushort language = arr.ToUShort(nrOffset + 4);
                NameField nameKind = (NameField)arr.ToUShort(nrOffset + 6);
                int len = arr.ToUShort(nrOffset + 8);
                int strOffset = arr.ToUShort(nrOffset + 10);
                Encoding stringEncoding = GetEncoding(platform, encoding);
                string content = Resources.NamingTable_FromBytes_EncodingNotSupportedMessage;
                bool filler = true;
                if (stringEncoding != null)
                {
                    content = stringEncoding.GetString(arr, offset + stringStoreOffset + strOffset, len);
                    filler = false;
                }
                names.Add(new NameRecord(platform, encoding, language, nameKind, content, filler));

            }
            return new NamingTable(version, names);
        }

        /// <summary>
        /// Search for all the name records in this table that match a particular <see cref="NameField" /> (if any).  Does not return any name records with the
        /// <see cref="NameRecord.FillerContent" /> flag set to indicate they could not be loaded on this platform due to an unsupported encoding.
        /// </summary>
        /// <param name="field">The kind of name record to return.</param>
        /// <returns>A sequence of <see cref="NameRecord" /> instances of the given kind (which may be an empty sequence).</returns>
        public IEnumerable<NameRecord> Search(NameField field)
        {
            return Names.Where(n => !n.FillerContent && n.NameId == field);
        }

        private static Encoding GetEncoding(PlatformId platform, ushort encodingId)
        {
            EncodingMapRecord cachedEncoding = _encodingMap.FirstOrDefault(e => e.Platform == platform && e.EncodingId == encodingId);
            if (cachedEncoding != null)
            {
                return cachedEncoding.Encoding;
            }

            Encoding foundEncoding = null;
            if (platform == PlatformId.Macintosh)
            {
                try
                {
                    foundEncoding = Encoding.GetEncoding(encodingId + 10000);
                }
                catch (NotSupportedException)
                {
                }
            }
            else
            {
                foundEncoding = Encoding.BigEndianUnicode;
            }
            _encodingMap.Add(new EncodingMapRecord(platform, encodingId, foundEncoding));
            return foundEncoding;
        }
    }
}
