namespace Unicorn.CoreTypes
{
    public interface ISourceImage
    {
        int DotWidth { get; }

        int DotHeight { get; }

        double AspectRatio { get; }
    }
}
