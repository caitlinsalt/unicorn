using System.Text;

namespace Unicorn.FontTools.OpenType
{
    internal class EncodingMapRecord
    {
        internal PlatformId Platform { get; }

        internal ushort EncodingId { get; }

        internal Encoding Encoding { get; }

        internal EncodingMapRecord(PlatformId platform, ushort encodingId, Encoding encoding)
        {
            Platform = platform;
            EncodingId = encodingId;
            Encoding = encoding;
        }
    }
}
