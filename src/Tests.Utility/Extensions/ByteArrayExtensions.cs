using System;

using System.Diagnostics.CodeAnalysis;

namespace Tests.Utility.Extensions
{
    /// <summary>
    /// Extension methods for arrays of bytes.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class ByteArrayExtensions
    {
        /// <summary>
        /// Write an <see cref="int" /> value into a byte array in big-endian style, overwriting the existing data.
        /// </summary>
        /// <param name="arr">The array to target.</param>
        /// <param name="offset">The index of the first byte in the array to overwrite.</param>
        /// <param name="val">The value to write into the array.</param>
        /// <exception cref="ArgumentNullException">Thrown if the array parameter is <c>null</c>.</exception>"
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the offset parameter is negative or would result in attempting to write data outside the bounds
        /// of the array.</exception>
        public static void WriteIntAt(this byte[] arr, int offset, int val)
        {
            CommonChecks(arr, offset, 4);
            unchecked
            {
                arr[offset] = (byte)((val & 0xff000000) >> 24);
                arr[offset + 1] = (byte)((val & 0xff0000) >> 16);
                arr[offset + 2] = (byte)((val & 0xff00) >> 8);
                arr[offset + 3] = (byte)(val & 0xff);
            }
        }

        /// <summary>
        /// Write a <see cref="ushort"/> value into a byte array in big-endian style, overwriting the existing data.
        /// </summary>
        /// <param name="arr">The array to target.</param>
        /// <param name="offset">The index of the first byte in the array to overwrite.</param>
        /// <param name="val">The value to write into the array.</param>
        /// <exception cref="ArgumentNullException">Thrown if the array parameter is <c>null</c>.</exception>"
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the offset parameter is negative or would result in attempting to write data outside the bounds
        /// of the array.</exception>
        [CLSCompliant(false)]
        public static void WriteUShortAt(this byte[] arr, int offset, ushort val)
        {
            CommonChecks(arr, offset, 2);
            unchecked
            {
                arr[offset] = (byte)((val & 0xff00) >> 8);
                arr[offset + 1] = (byte)(val & 0xff);
            }
        }

        private static void CommonChecks(byte[] arr, int offset, int typeLen)
        {
            if (arr is null)
            {
                throw new ArgumentNullException(nameof(arr));
            }
            if (offset < 0 || offset > arr.Length - typeLen)
            {
                throw new ArgumentOutOfRangeException(nameof(offset));
            }
        }
    }
}
