using System;

namespace Unicorn.CoreTypes
{
    /// <summary>
    /// Mathematical helper methods.
    /// </summary>
    public static class MathsHelpers
    {
        /// <summary>
        /// Convert degrees to radians.
        /// </summary>
        /// <param name="a">The value to convert.</param>
        /// <returns>The parameter in degrees, converted to radians.</returns>
        public static double DegToRad(double a) => a * Math.PI / 180d;

        /// <summary>
        /// Convert radians to degrees.
        /// </summary>
        /// <param name="a">The value to convert.</param>
        /// <returns>The parameter in radians, converted to degrees.</returns>
        public static double RadToDeg(double a) => a * 180d / Math.PI;
    }
}
