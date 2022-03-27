using System;

namespace Unicorn.Base.Helpers.Extensions
{
    /// <summary>
    /// Extension methods for converting arrays of bytes into integer values.
    /// </summary>
    /// <remarks>
    /// <para>
    /// These methods are used in two key places within Unicorn, both primarily concerned with parsing binary data:
    /// loading OpenType font programs, and loading images.  Methods used for the latter are generally provided in
    /// both big-endian (higher-value bytes have lower array indices) and little-endian (higher-value bytes have higher 
    /// array indices) versions.  Methods used solely in the OpenType font program parsing code may only have big-endian
    /// versions.
    /// </para>
    /// <param>
    /// Methods which do not specify their endianness are big-endian, and return the exact type described by their
    /// name.  If the method's return type is not a CLS type, the method is marked as non-CLS-compliant.
    /// </param>
    /// <para>
    /// Methods which do specify their endianness are all CLS-compliant, and return the smallest CLS type which can store
    /// the necessary range of values.  For example, <see cref="ReadBigEndianUShort(byte[], int)"/> returns an <see cref="int"/>
    /// value, as <see cref="int"/> is the smallest CLS type which can store <see cref="ushort.MaxValue"/>.
    /// </para>
    /// </remarks>
    public static class ByteArrayExtensions
    {
        /// <summary>
        /// Convert a big-endian pair of bytes into a <see cref="short" /> value.
        /// </summary>
        /// <param name="arr">An array of at least two bytes.</param>
        /// <param name="offset">Starting offset of the bytes to be converted.</param>
        /// <returns>A <see cref="short" /> value loaded from the first two members of the parameter.</returns>
        /// <exception cref="NullReferenceException">The <c>arr</c> parameter is null.</exception>
        /// <exception cref="InvalidOperationException">The <c>arr</c> parameter contains less than two elements.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// The <c>idx</c> parameter is less than zero, or greater than the index of the penultimate item in the <c>arr</c> parameter.
        /// </exception>
        public static short ReadBigEndianShort(this byte[] arr, int offset = 0)
        {
            if (arr is null)
            {
                throw new ArgumentNullException(nameof(arr));
            }
            if (arr.Length< 2)
            {
                throw new InvalidOperationException();
            }
            if (offset < 0 || arr.Length < offset + 2)
            {
                throw new ArgumentOutOfRangeException(nameof(offset));
            }
            return unchecked((short)((arr[offset] << 8) | arr[offset + 1]));
        }

        /// <summary>
        /// Convert a big-endian pair of bytes into a <see cref="short" /> value.
        /// </summary>
        /// <param name="arr">An array of at least two bytes.</param>
        /// <param name="offset">Starting offset of the bytes to be converted.</param>
        /// <returns>A <see cref="short" /> value loaded from the first two members of the parameter.</returns>
        /// <exception cref="NullReferenceException">The <c>arr</c> parameter is null.</exception>
        /// <exception cref="InvalidOperationException">The <c>arr</c> parameter contains less than two elements.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// The <c>offset</c> parameter is less than zero, or greater than the index of the penultimate item in the <c>arr</c> parameter.
        /// </exception>
        public static short ToShort(this byte[] arr, int offset = 0) => ReadBigEndianShort(arr, offset);

        /// <summary>
        /// Convert a big-endian pair of bytes into am <see cref="int"/> value that is within the valid range of a <see cref="ushort" /> value.
        /// </summary>
        /// <param name="arr">An array of at least two bytes.</param>
        /// <param name="offset">Starting offset of the bytes to be converted.</param>
        /// <returns>A <see cref="ushort" /> value loaded from the first two members of the parameter.</returns>
        /// <exception cref="NullReferenceException">The first parameter is null.</exception>
        /// <exception cref="InvalidOperationException">The first parameter contains less than two elements.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// The <c>offset</c> parameter is less than zero, greater than the length of the first parameter, or too close to the
        /// end of the array
        /// </exception>
        public static int ReadBigEndianUShort(this byte[] arr, int offset = 0)
        {
            if (arr is null)
            {
                throw new ArgumentNullException(nameof(arr));
            }
            if (arr.Length < 2)
            {
                throw new InvalidOperationException();
            }
            if (offset < 0 || offset > arr.Length - 2)
            {
                throw new ArgumentOutOfRangeException(nameof(offset));
            }
            return (arr[offset] << 8) | arr[offset + 1];
        }

        /// <summary>
        /// Convert a big-endian pair of bytes into a <see cref="ushort" /> value.
        /// </summary>
        /// <param name="arr">An array of at least two bytes.</param>
        /// <param name="offset">Starting offset of the bytes to be converted.</param>
        /// <returns>A <see cref="ushort" /> value loaded from the first two members of the parameter.</returns>
        /// <exception cref="NullReferenceException">The first parameter is null.</exception>
        /// <exception cref="InvalidOperationException">The first parameter contains less than two elements.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// The <c>offset</c> parameter is less than zero, greater than the length of the first parameter, or too close to the
        /// end of the array
        /// </exception>
        [CLSCompliant(false)]
        public static ushort ToUShort(this byte[] arr, int offset = 0) => (ushort) ReadBigEndianUShort(arr, offset);

        /// <summary>
        /// Convert a little-endian pair of bytes into a <see cref="ushort" /> value.
        /// </summary>
        /// <param name="arr">An array of at least two bytes.</param>
        /// <param name="offset">Starting offset of the bytes to be converted.</param>
        /// <returns>A <see cref="ushort" /> value loaded from the first two members of the parameter.</returns>
        /// <exception cref="NullReferenceException">The first parameter is null.</exception>
        /// <exception cref="InvalidOperationException">The first parameter contains less than two elements.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// The <c>offset</c> parameter is less than zero, greater than the length of the first parameter, or too close to the
        /// end of the array
        /// </exception>
        public static int ReadLittleEndianUShort(this byte[] arr, int offset)
        {
            if (arr is null)
            {
                throw new ArgumentNullException(nameof(arr));
            }
            if (arr.Length < 2)
            {
                throw new InvalidOperationException();
            }
            if (offset < 0 || offset > arr.Length - 2)
            {
                throw new ArgumentOutOfRangeException(nameof(offset));
            }
            return (arr[offset + 1] << 8) | arr[offset];
        }

        /// <summary>
        /// Convert four big-endian bytes into a <see cref="long"/> value within the range of a <see cref="uint" /> value.
        /// </summary>
        /// <param name="arr">An array of at least four bytes.</param>
        /// <param name="offset">Starting offset of the bytes to be converted.</param>
        /// <returns>A <see cref="long" /> value loded from the first four elements of the parameter</returns>
        /// <exception cref="NullReferenceException">The <c>arr</c> parameter is null.</exception>
        /// <exception cref="InvalidOperationException">The <c>arr</c> parameter's length is less than four.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// The <c>offset</c> parameter is less than zero, or is greater than the index of the fourth byte from the end of 
        /// the <c>arr</c> parameter.
        /// </exception>
        public static long ReadBigEndianUInt(this byte[] arr, int offset)
        {
            if (arr is null)
            {
                throw new ArgumentNullException(nameof(arr));
            }
            if (arr.Length < 4)
            {
                throw new InvalidOperationException();
            }
            if (offset < 0 || offset > arr.Length - 4)
            {
                throw new ArgumentOutOfRangeException(nameof(offset));
            }
            return ((long)arr[offset] << 24) | ((long)arr[offset + 1] << 16) | ((long)arr[offset + 2] << 8) | arr[offset + 3];
        }

        /// <summary>
        /// Convert four big-endian bytes into a <see cref="uint" /> value.
        /// </summary>
        /// <param name="arr">An array of at least four bytes.</param>
        /// <param name="offset">Starting offset of the bytes to be converted.</param>
        /// <returns>A <see cref="long" /> value loded from the first four elements of the parameter</returns>
        /// <exception cref="NullReferenceException">The <c>arr</c> parameter is null.</exception>
        /// <exception cref="InvalidOperationException">The <c>arr</c> parameter's length is less than four.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// The <c>offset</c> parameter is less than zero, or is greater than the index of the fourth byte from the end of 
        /// the <c>arr</c> parameter.
        /// </exception>
        [CLSCompliant(false)]
        public static uint ToUInt(this byte[] arr, int offset = 0) => (uint)ReadBigEndianUInt(arr, offset);

        /// <summary>
        /// Convert four little-endian bytes into a <see cref="uint" /> value.
        /// </summary>
        /// <param name="arr">An array of at least four bytes.</param>
        /// <param name="offset">Starting offset of the bytes to be converted.</param>
        /// <returns>A <see cref="long" /> value loded from the first four elements of the parameter</returns>
        /// <exception cref="NullReferenceException">The <c>arr</c> parameter is null.</exception>
        /// <exception cref="InvalidOperationException">The <c>arr</c> parameter's length is less than four.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// The <c>offset</c> parameter is less than zero, or is greater than the index of the fourth byte from the end of 
        /// the <c>arr</c> parameter.
        /// </exception>
        public static long ReadLittleEndianUInt(this byte[] arr, int offset)
        {
            if (arr is null)
            {
                throw new ArgumentNullException(nameof(arr));
            }
            if (arr.Length < 4)
            {
                throw new InvalidOperationException();
            }
            if (offset < 0 || offset > arr.Length - 4)
            {
                throw new ArgumentOutOfRangeException(nameof(offset));
            }
            return ((long)arr[offset + 3] << 24) | ((long)arr[offset + 2] << 16) | ((long)arr[offset + 1] << 8) | arr[offset];
        }

        /// <summary>
        /// Convert four big-endian bytes into a <see cref="int" /> value.
        /// </summary>
        /// <param name="arr">An array of at least four bytes.</param>
        /// <param name="offset">Starting offset of the bytes to be converted.</param>
        /// <returns>A <see cref="int" /> value loded from the first four elements of the parameter</returns>
        /// <exception cref="NullReferenceException">The <c>arr</c> parameter is <c>null</c>.</exception>
        /// <exception cref="InvalidOperationException">The <c>arr</c> parameter's length is less than four.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// The <c>offset</c> parameter is less than zero, or is greater than the index of the fourth byte from the end of 
        /// the <c>arr</c> parameter.
        /// </exception>
        public static int ReadBigEndianInt(this byte[] arr, int offset) => unchecked((int)ToUInt(arr, offset));

        /// <summary>
        /// Convert four big-endian bytes into a <see cref="int" /> value.
        /// </summary>
        /// <param name="arr">An array of at least four bytes.</param>
        /// <param name="offset">Starting offset of the bytes to be converted.</param>
        /// <returns>A <see cref="int" /> value loded from the first four elements of the parameter</returns>
        /// <exception cref="NullReferenceException">The <c>arr</c> parameter is <c>null</c>.</exception>
        /// <exception cref="InvalidOperationException">The <c>arr</c> parameter's length is less than four.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// The <c>offset</c> parameter is less than zero, or is greater than the index of the fourth byte from the end of 
        /// the <c>arr</c> parameter.
        /// </exception>
        public static int ToInt(this byte[] arr, int offset = 0) => ReadBigEndianInt(arr, offset);

        /// <summary>
        /// Convert four little-endian bytes into a <see cref="int" /> value.
        /// </summary>
        /// <param name="arr">An array of at least four bytes.</param>
        /// <param name="offset">Starting offset of the bytes to be converted.</param>
        /// <returns>A <see cref="int" /> value loded from the first four elements of the parameter</returns>
        /// <exception cref="NullReferenceException">The <c>arr</c> parameter is <c>null</c>.</exception>
        /// <exception cref="InvalidOperationException">The <c>arr</c> parameter's length is less than four.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// The <c>offset</c> parameter is less than zero, or is greater than the index of the fourth byte from the end of 
        /// the <c>arr</c> parameter.
        /// </exception>
        public static int ReadLittleEndianInt(this byte[] arr, int offset)
        {
            if (arr is null)
            {
                throw new ArgumentNullException(nameof(arr));
            }
            if (arr.Length < 4)
            {
                throw new InvalidOperationException();
            }
            if (offset < 0 || offset > arr.Length - 4)
            {
                throw new ArgumentOutOfRangeException(nameof(offset));
            }
            return unchecked((int)(((uint)arr[offset + 3] << 24) | ((uint)arr[offset + 2] << 16) | ((uint)arr[offset + 1] << 8) | arr[offset]));
        }

        /// <summary>
        /// Convert 8 big-endian bytes to a <see cref="long" /> value.
        /// </summary>
        /// <param name="arr">The array to convert.</param>
        /// <param name="offset">Starting offset of the bytes to be converted.</param>
        /// <returns>The value converted from the first 8 bytes of the array.</returns>
        /// <exception cref="NullReferenceException">The <c>arr</c> parameter is null.</exception>
        /// <exception cref="InvalidOperationException">The <c>arr</c> parameter contains fewer than 8 elements.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// The <c>offset</c> parameter is less than zero, or is greater than the index of the eighth byte from the end of 
        /// the <c>arr</c> parameter.
        /// </exception>
        public static long ReadBigEndianLong(this byte[] arr, int offset = 0)
        {
            if (arr is null)
            {
                throw new ArgumentNullException(nameof(arr));
            }
            if (arr.Length < 8)
            {
                throw new InvalidOperationException();
            }
            if (arr.Length < offset + 8)
            {
                throw new ArgumentOutOfRangeException(nameof(offset));
            }

            return unchecked(((long)arr[offset] << 56) | ((long)arr[offset + 1] << 48) | ((long)arr[offset + 2] << 40) | ((long)arr[offset + 3] << 32) |
                ((long)arr[offset + 4] << 24) | ((long)arr[offset + 5] << 16) | ((long)arr[offset + 6] << 8) | arr[offset + 7]);
        }

        /// <summary>
        /// Convert 8 big-endian bytes to a <see cref="long" /> value.
        /// </summary>
        /// <param name="arr">The array to convert.</param>
        /// <param name="offset">Starting offset of the bytes to be converted.</param>
        /// <returns>The value converted from the first 8 bytes of the array.</returns>
        /// <exception cref="NullReferenceException">The <c>arr</c> parameter is null.</exception>
        /// <exception cref="InvalidOperationException">The <c>arr</c> parameter contains fewer than 8 elements.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// The <c>offset</c> parameter is less than zero, or is greater than the index of the eighth byte from the end of 
        /// the <c>arr</c> parameter.
        /// </exception>
        public static long ToLong(this byte[] arr, int offset = 0) => ReadBigEndianLong(arr, offset);
    }
}
