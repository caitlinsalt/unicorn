namespace Unicorn.Images.Jpeg
{
    internal static class ExifOrientationExtensions
    {
        internal static bool IsQuarterRotated(this ExifOrientation orientation)
        {
            switch (orientation)
            {
                case ExifOrientation.RotatedAnticlockwiseThenFlippedVertically:
                case ExifOrientation.RotatedClockwise:
                case ExifOrientation.RotatedClockwiseThenFlippedVertically:
                case ExifOrientation.RotatedAnticlockwise:
                    return true;
                default:
                    return false;
            }
        }
    }
}
