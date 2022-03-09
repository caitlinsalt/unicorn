using System;

namespace Unicorn.Helpers
{
    internal static class ByteArrayExtensions
    {
        internal static int ReadBigEndianUShort(this byte[] arr, int offset)
        {
            if (arr is null)
            {
                throw new ArgumentNullException(nameof(arr));
            }
            if (offset < 0 || offset > arr.Length - 2)
            {
                throw new ArgumentOutOfRangeException(nameof(offset));
            }
            return (arr[offset] << 8) | arr[offset + 1];
        }

        internal static int ReadLittleEndianUShort(this byte[] arr, int offset)
        {
            if (arr is null)
            {
                throw new ArgumentNullException(nameof(arr));
            }
            if (offset < 0 || offset > arr.Length - 2)
            {
                throw new ArgumentOutOfRangeException(nameof(offset));
            }
            return (arr[offset + 1] << 8) | arr[offset];
        }

        internal static long ReadBigEndianUInt(this byte[] arr, int offset)
        {
            if (arr is null)
            {
                throw new ArgumentNullException(nameof(arr));
            }
            if (offset < 0 || offset > arr.Length - 4)
            {
                throw new ArgumentOutOfRangeException(nameof(offset));
            }
            return ((long)arr[offset] << 24) | ((long)arr[offset + 1] << 16) | ((long)arr[offset + 2] << 8) | arr[offset + 3];
        }

        internal static long ReadLittleEndianUInt(this byte[] arr, int offset)
        {
            if (arr is null)
            {
                throw new ArgumentNullException(nameof(arr));
            }
            if (offset < 0 || offset > arr.Length - 4)
            {
                throw new ArgumentOutOfRangeException(nameof(offset));
            }
            return ((long)arr[offset + 3] << 24) | ((long)arr[offset + 2] << 16) | ((long)arr[offset + 1] << 8) | arr[offset];
        }

        internal static long ReadBigEndianInt(this byte[] arr, int offset)
        {
            if (arr is null)
            {
                throw new ArgumentNullException(nameof(arr));
            }
            if (offset < 0 || offset > arr.Length - 4)
            {
                throw new ArgumentOutOfRangeException(nameof(offset));
            }
            return unchecked((int)(((uint)arr[offset] << 24) | ((uint)arr[offset + 1] << 16) | ((uint)arr[offset + 2] << 8) | arr[offset + 3]));
        }

        internal static long ReadLittleEndianInt(this byte[] arr, int offset)
        {
            if (arr is null)
            {
                throw new ArgumentNullException(nameof(arr));
            }
            if (offset < 0 || offset > arr.Length - 4)
            {
                throw new ArgumentOutOfRangeException(nameof(offset));
            }
            return unchecked((int)(((uint)arr[offset + 3] << 24) | ((uint)arr[offset + 2] << 16) | ((uint)arr[offset + 1] << 8) | arr[offset]));
        }
    }
}
