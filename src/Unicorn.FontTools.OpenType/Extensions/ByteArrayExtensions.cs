using System;

namespace Unicorn.FontTools.OpenType.Extensions
{
    /// <summary>
    /// Helper methods for loading OpenType fonts.
    /// </summary>
    public static class ByteArrayExtensions
    {
        /// <summary>
        /// Convert a pair of bytes into a <see cref="ushort" /> value.
        /// </summary>
        /// <param name="arr">An array of at least two bytes.</param>
        /// <param name="idx">Starting offset of the bytes to be converted.</param>
        /// <returns>A <see cref="ushort" /> value loaded from the first two members of the parameter.</returns>
        /// <exception cref="NullReferenceException">Thrown if the parameter is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the parameter contains less than two elements.</exception>
        /// <exception cref="IndexOutOfRangeException">Throw if the idx parameter is less than zero.</exception>
        [CLSCompliant(false)]
        public static ushort ToUShort(this byte[] arr, int idx = 0)
        {
            if (arr is null)
            {
                throw new ArgumentNullException(nameof(arr));
            }
            if (arr.Length < idx + 2)
            {
                throw new InvalidOperationException();
            }
            return (ushort)((arr[idx] << 8) | arr[idx + 1]);
        }

        /// <summary>
        /// Convert a pair of bytes into a <see cref="short" /> value.
        /// </summary>
        /// <param name="arr">An array of at least two bytes.</param>
        /// <param name="idx">Starting offset of the bytes to be converted.</param>
        /// <returns>A <see cref="short" /> value loaded from the first two members of the parameter.</returns>
        /// <exception cref="NullReferenceException">Thrown if the parameter is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the parameter contains less than two elements.</exception>
        public static short ToShort(this byte[] arr, int idx = 0)
        {
            if (arr is null)
            {
                throw new ArgumentNullException(nameof(arr));
            }
            if (arr.Length < idx + 2)
            {
                throw new InvalidOperationException();
            }
            return unchecked((short)((arr[idx] << 8) | arr[idx + 1]));
        }

        /// <summary>
        /// Convert four bytes into a <see cref="uint" /> value.
        /// </summary>
        /// <param name="arr">An array of at least four bytes.</param>
        /// <param name="idx">Starting offset of the bytes to be converted.</param>
        /// <returns>A <see cref="uint" /> value loded from the first four elements of the parameter</returns>
        /// <exception cref="NullReferenceException">Thrown if the parameter is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the parameter's length is less than four.</exception>
        [CLSCompliant(false)]
        public static uint ToUInt(this byte[] arr, int idx = 0)
        {
            if (arr is null)
            {
                throw new ArgumentNullException(nameof(arr));
            }
            if (arr.Length < idx + 4)
            {
                throw new InvalidOperationException();
            }
            return ((uint)arr[idx] << 24) | ((uint)arr[idx + 1] << 16) | ((uint)arr[idx + 2] << 8) | arr[idx + 3];
        }

        /// <summary>
        /// Convert four bytes into a <see cref="int" /> value.
        /// </summary>
        /// <param name="arr">An array of at least four bytes.</param>
        /// <param name="idx">Starting offset of the bytes to be converted.</param>
        /// <returns>A <see cref="int" /> value loded from the first four elements of the parameter</returns>
        /// <exception cref="NullReferenceException">Thrown if the parameter is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the parameter's length is less than four.</exception>
        public static int ToInt(this byte[] arr, int idx = 0)
        {
            return unchecked((int)ToUInt(arr, idx));
        }

        /// <summary>
        /// Convert four bytes to a "fixed" value, returned as decimal.  The fixed format is a signed 32-bit fixed-point format with 16 bits for the integral part and 
        /// 16 bits for the fractional part.
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="idx">Starting offset of the bytes to be converted.</param>
        /// <returns></returns>
        public static decimal ToFixed(this byte[] arr, int idx = 0)
        {
            if (arr is null)
            {
                throw new ArgumentNullException(nameof(arr));
            }
            if (arr.Length < idx + 4)
            {
                throw new InvalidOperationException();
            }
            
            return unchecked((arr[idx] << 24) | (arr[idx + 1] << 16) | (arr[idx + 2] << 8) | arr[idx + 3]) / 65536m;
        }

        /// <summary>
        /// Convert 8 bytes to an <see cref="long" /> value.
        /// </summary>
        /// <param name="arr">The array to convert.</param>
        /// <param name="idx">Starting offset of the bytes to be converted.</param>
        /// <returns>The value converted from the first 8 bytes of the array.</returns>
        /// <exception cref="NullReferenceException">Thrown if the parameter is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the parameter contains fewer than 8 elements.</exception>
        public static long ToLong(this byte[] arr, int idx = 0)
        {
            if (arr is null)
            {
                throw new ArgumentNullException(nameof(arr));
            }
            if (arr.Length < idx + 8)
            {
                throw new InvalidOperationException();
            }

            return unchecked(((long)arr[idx] << 56) | ((long)arr[idx + 1] << 48) | ((long)arr[idx + 2] << 40) | ((long)arr[idx + 3] << 32) | 
                ((long)arr[idx + 4] << 24) | ((long)arr[idx + 5] << 16) | ((long)arr[idx + 6] << 8) | arr[idx + 7]);
        }

        /// <summary>
        /// Convert 8 bytes to a <see cref="DateTime" /> value, by interpreting it as the number of seconds since the start of 1904.
        /// </summary>
        /// <param name="arr">The array of bytes to convert.</param>
        /// <param name="idx">Starting offset of the bytes to be converted.</param>
        /// <returns>A <see cref="DateTime" /> converted from the first 8 bytes of the parameter array.</returns>
        /// <exception cref="NullReferenceException">Thrown if the parameter is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the parameter has fewer than 8 elements.</exception>
        public static DateTime ToDateTime(this byte[] arr, int idx = 0)
        {
            long offset = ToLong(arr, idx);
            // This is the number of seconds from 1st January 1904 (the epoch for the OpenType format) to 31st December 1999 
            // (the largest value representable by DateTime)
            if (offset > 255_485_232_000)
            {
                throw new ArgumentOutOfRangeException(Resources.Extensions_ByteArrayExtensions_ToDateTime_OutOfRangeError);
            }
            return new DateTime(1904, 1, 1).AddTicks(offset * 10_000_000);
        }
    }
}
