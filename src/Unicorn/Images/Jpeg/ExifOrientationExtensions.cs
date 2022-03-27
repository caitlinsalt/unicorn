using Unicorn.Base;

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

        internal static RightAngleRotation ToRightAngleRotation(this ExifOrientation orientation)
        {
            switch (orientation)
            {
                case ExifOrientation.RotatedClockwise:
                case ExifOrientation.RotatedClockwiseThenFlippedVertically:
                    return RightAngleRotation.Clockwise90;
                case ExifOrientation.RotatedAnticlockwise:
                case ExifOrientation.RotatedAnticlockwiseThenFlippedVertically:
                    return RightAngleRotation.Anticlockwise90;
                case ExifOrientation.Rotated180:
                    return RightAngleRotation.Full180;
                default:
                    return RightAngleRotation.None;
            }
        }
    }
}
