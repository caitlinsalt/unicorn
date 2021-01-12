using System;

using System.Diagnostics.CodeAnalysis;

namespace Tests.Utility.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class ByteArrayExtensions
    {
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
