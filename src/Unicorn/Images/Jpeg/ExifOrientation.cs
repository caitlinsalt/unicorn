namespace Unicorn.Images.Jpeg
{
    internal enum ExifOrientation
    {
        // These values are defined in the EXIF spec.
        Normal = 1,
        FlippedHorizontally = 2,
        Rotated180 = 3,
        FlippedVertically = 4,
        RotatedAnticlockwiseThenFlippedVertically = 5,
        RotatedClockwise = 6,
        RotatedClockwiseThenFlippedVertically = 7,
        RotatedAnticlockwise = 8,
    }
}
