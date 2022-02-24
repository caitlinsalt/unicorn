using System.Linq;

namespace Unicorn.Images.Jpeg
{
    internal class ImageDataBlock
    {
        internal long StartOffset { get; }

        internal int MarkerTypeByte { get; }

        internal int Length { get; }   

        internal byte[] ConfirmationBytes { get; }

        internal ImageDataBlockType BlockType { get; }

        internal ImageDataBlock(long startOffset, int typeByte, int length, byte[] confirmationData)
        {
            StartOffset = startOffset;
            MarkerTypeByte = typeByte;
            Length = length;
            ConfirmationBytes = confirmationData;
            BlockType = GetBlockType();
        }

        private ImageDataBlockType GetBlockType()
        {
            int[] startOfFrameMarkers = { 0xc0, 0xc1, 0xc2, 0xc3, 0xc5, 0xc6, 0xc7, 0xc8, 0xc9, 0xca, 0xcb, 0xcd, 0xce, 0xcf };
            const int jfifMarker = 0xe0;
            byte[] jfifConfirmationBytes = { 0x4a, 0x46, 0x49, 0x46, 0 };
            
            if (startOfFrameMarkers.Contains(MarkerTypeByte))
            {
                return ImageDataBlockType.StartOfFrame;
            }
            if (MarkerTypeByte == jfifMarker)
            {
                return CompareArrays(ConfirmationBytes, jfifConfirmationBytes) ? ImageDataBlockType.Jfif : ImageDataBlockType.Unknown;
            }

            return ImageDataBlockType.Unknown;
        }

        private static bool CompareArrays(byte[] a0, byte[] a1)
        {
            if (a0.Length != a1.Length)
            {
                return false;
            }
            for (int i = 0; i < a0.Length; i++)
            {
                if (a0[i] != a1[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
