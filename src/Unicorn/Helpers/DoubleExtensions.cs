namespace Unicorn.Helpers
{
    /// <summary>
    /// Extension methods for the <see cref="double"/> type.
    /// </summary>
    public static class DoubleExtensions
    {
        /// <summary>
        /// Quantise a <see cref="double"/> value to the range of a <see cref="byte"/>, 
        /// assuming the double lies in the range 0.0 to 1.0 inclusive.
        /// </summary>
        /// <param name="d">The value to be quantised.</param>
        /// <returns>
        /// A <see cref="byte"/> value approximately equal to the parameter multiplied by 256.
        /// If the parameter is less than zero, zero is returned; if the parameter is 1 or greater,
        /// 255 is returned.
        /// </returns>
        public static byte ScaleToByte(this double d)
        {
            if (d >= 1)
            {
                return 255;
            }
            if (d <= 0)
            {
                return 0;
            }
            int b = (int)(d * 256);
            if (b >= 256)
            {
                b = 255;
            }
            return (byte)b;
        }
    }
}
