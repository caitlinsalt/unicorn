﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Unicorn.Helpers;
using Unicorn.Writer.Extensions;
using Unicorn.Writer.Interfaces;
using Unicorn.Writer.Streams;

namespace Unicorn.Writer.Primitives
{
    /// <summary>
    /// This class represents a particular subtype of PDF direct objects, that can be represented in this library by immutable classes differing only in the underlying type of their value
    /// and the code required to represent that value as an array of bytes.
    /// </summary>
    public abstract class PdfSimpleObject : IPdfPrimitiveObject
    {
        private byte[] _cachedBytes;

        /// <summary>
        /// The number of bytes needed to represent this object.
        /// </summary>
        public int ByteLength
        {
            get
            {
                _cachedBytes = _cachedBytes ?? FormatBytes();
                return _cachedBytes.Length;
            }
        }

        /// <summary>
        /// Write this object to a <see cref="Stream" />.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <returns>The number of bytes written to the stream.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the stream parameter is null.</exception>
        public async Task<int> WriteToAsync(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            return await WriteAsync(WriteToStreamAsync, stream).ConfigureAwait(false);
        }

        /// <summary>
        /// Write this object to a <see cref="Stream" />.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <returns>The number of bytes written to the stream.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the stream parameter is null.</exception>
        public int WriteTo(Stream stream) => TaskHelper.UnwrapTask(WriteToAsync, stream);

        /// <summary>
        /// Convert this object to bytes and append them to a <see cref="List{Byte}" />.
        /// </summary>
        /// <param name="bytes">The list to append to.</param>
        /// <returns>The number of bytes appended.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the list parameter is null.</exception>
        public int WriteTo(IList<byte> bytes)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException(nameof(bytes));
            }
            return Write(WriteToList, bytes);
        }

        /// <summary>
        /// Write this object to a <see cref="PdfStream" />.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <returns>The number of bytes written to the stream.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the stream parameter is null.</exception>
        public int WriteTo(PdfStream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            return Write(WriteToPdfStream, stream);
        }

        private async Task<int> WriteAsync<T>(Func<T, byte[], Task> writer, T dest)
        {
            if (_cachedBytes == null)
            {
                _cachedBytes = FormatBytes();
            }
            await writer(dest, _cachedBytes).ConfigureAwait(false);
            return _cachedBytes.Length;
        }

        private int Write<T>(Action<T, byte[]> writer, T dest)
        {
            if (_cachedBytes == null)
            {
                _cachedBytes = FormatBytes();
            }
            writer(dest, _cachedBytes);
            return _cachedBytes.Length;
        }

        private static async Task WriteToStreamAsync(Stream str, byte[] bytes)
        {
            await str.WriteAsync(bytes, 0, bytes.Length).ConfigureAwait(false);
        }

        private static void WriteToList(IList<byte> list, byte[] bytes)
        {
            list.AddRange(bytes);
        }

        private static void WriteToPdfStream(PdfStream stream, byte[] bytes)
        {
            stream.AddBytes(bytes);
        }

        /// <summary>
        /// Convert this object into an array of bytes for writing.
        /// </summary>
        /// <returns>An array of bytes containing a representation of this object.</returns>
        protected abstract byte[] FormatBytes();
    }
}
