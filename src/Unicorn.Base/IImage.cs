namespace Unicorn.CoreTypes
{
    public interface IImage
    {
        int DotWidth { get; }

        int DotHeight { get; }

        double AspectRatio { get; }
    }
}
