using System;
using Unicorn.Base.Helpers.Extensions;

namespace Unicorn.FontTools.Extensions
{
    /// <summary>
    /// Helper methods for converting byte arrays into numerical values.  These methods are for those data types specific to OpenType: 
    /// 32-bit fixed-point decimals, and one-second-precision timestamps represented as a 64-bit number of seconds since midnight, 1st January 1904.
    /// </summary>
    public static class ByteArrayExtensions
    {
        /// <summary>
        /// Convert four bytes to a "fixed" value, returned as decimal.  The fixed format is a signed 32-bit fixed-point format with 16 bits for the integral part and 
        /// 16 bits for the fractional part.
        /// </summary>
        /// <param name="arr">The bytes to be converted.</param>
        /// <param name="offset">Starting offset of the bytes to be converted.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">The <c>arr</c> parameter is null.</exception>
        /// <exception cref="InvalidOperationException">The <c>arr</c> parameter's length is less than four.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// The <c>offset</c> parameter is less than zero, or is greater than the index of the fourth byte from the end of 
        /// the <c>arr</c> parameter.
        /// </exception>
        public static decimal ToFixed(this byte[] arr, int offset = 0)
        {
            if (arr is null)
            {
                throw new ArgumentNullException(nameof(arr));
            }
            if (arr.Length < 4)
            {
                throw new InvalidOperationException();
            }
            if (arr.Length < offset + 4)
            {
                throw new ArgumentOutOfRangeException(nameof(offset));
            }
            
            return unchecked((arr[offset] << 24) | (arr[offset + 1] << 16) | (arr[offset + 2] << 8) | arr[offset + 3]) / 65536m;
        }

        /// <summary>
        /// Convert 8 bytes to a <see cref="DateTime" /> value, by interpreting it as the number of seconds since the start of 1904.
        /// </summary>
        /// <param name="arr">The array of bytes to convert.</param>
        /// <param name="offset">Starting offset of the bytes to be converted.</param>
        /// <returns>A <see cref="DateTime" /> converted from the first 8 bytes of the parameter array.</returns>
        /// <exception cref="ArgumentNullException">The <c>arr</c> parameter is null.</exception>
        /// <exception cref="InvalidOperationException">The <c>arr</c> parameter's length is less than eight.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// The <c>offset</c> parameter is less than zero, or is greater than the index of the eighth byte from the end of 
        /// the <c>arr</c> parameter, or the converted value is too far into the future to be stored in a <see cref="DateTime" /> value.
        /// </exception>
        public static DateTime ToDateTime(this byte[] arr, int offset = 0)
        {
            long seconds = arr.ReadBigEndianLong(offset);
            // This is the number of seconds from 1st January 1904 CE (the epoch for the OpenType format) to 31st December 9999 CE
            // (the largest value representable by DateTime)
            if (seconds > 255_485_232_000)
            {
                throw new ArgumentOutOfRangeException(Resources.Extensions_ByteArrayExtensions_ToDateTime_OutOfRangeError);
            }
            return new DateTime(1904, 1, 1).AddTicks(seconds * 10_000_000);
        }
    }
}
