namespace Unicorn.Images.Jpeg
{
    internal class ImageDataBlock
    {
        internal long StartOffset { get; }

        internal int Length { get; }   

        internal ImageDataBlockType BlockType { get; }

        internal ImageDataBlock(long startOffset, int length, ImageDataBlockType kind)
        {
            StartOffset = startOffset;
            Length = length;
            BlockType = kind;
        }
    }
}
