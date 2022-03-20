﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Unicorn.Writer.Interfaces;
using Unicorn.Writer.Primitives;

namespace Unicorn.Writer.Streams
{

#pragma warning disable CA1711 // Identifiers should not have incorrect suffix.  This is a "stream" in the PDF sense if not in the .NET sense.

    /// <summary>
    /// A class to represent a PDF stream.  These have to be stored as indirect objects, and consist of a dictionary containing stream metadata followed by the 
    /// stream content itself.
    /// </summary>
    public class PdfStream : PdfIndirectObject
    {
        
        private readonly List<byte> _contents = new List<byte>();
        private readonly PdfDictionary _additionalMetadata;

        // Filter encoders in encoding order.
        private readonly List<IPdfFilterEncoder> _filterEncodingChain = new List<IPdfFilterEncoder>();

        private static readonly byte[] _streamStart = new byte[] { 0x73, 0x74, 0x72, 0x65, 0x61, 0x6d, 0xa };
        private static readonly byte[] _streamEnd = new byte[] { 0xa, 0x65, 0x6e, 0x64, 0x73, 0x74, 0x72, 0x65, 0x61, 0x6d, 0xa };

        /// <summary>
        /// The stream contents, exposed to descendent classes.
        /// </summary>
        protected IList<byte> InternalContents => _contents;

        /// <summary>
        /// A read-only copy of the stream contents.
        /// </summary>
        public IList<byte> Contents => InternalContents.ToList();

        /// <summary>
        /// The stream metadata.
        /// </summary>
        protected PdfDictionary MetaDictionary { get; set; }

        /// <summary>
        /// Indicate whether or not the stream supports the addition of further data.
        /// </summary>
        public virtual bool CanAddData { get; private set; } = true;

        /// <summary>
        /// Constructor, with indirect object parameters.
        /// </summary>
        /// <param name="objectId">An indirect object ID obtained from a cross-reference table.</param>
        /// <param name="generation">The generation number of this stream.  Defaults to 0.</param>
        /// <param name="filters">The sequence of filters to apply to the stream data.  As Unicorn is focused on writing output, these are in encoding order.</param>
        /// <param name="additionalMetadata">A dictionary of additional metadata to include in the stream metadata dictionary.  This must not contain any of 
        /// the standard metadata keys that may appear in the dictionary, such as <c>/Length</c> or <c>/Filter</c>, or an exception will be thrown either in
        /// this method or at any point later in execution.  Note: this is not to be confused with the "/Metadata" property of "/XObject" streams.</param>
        public PdfStream(int objectId, IEnumerable<IPdfFilterEncoder> filters = null, PdfDictionary additionalMetadata = null, int generation = 0) 
            : base(objectId, generation)
        {
            _additionalMetadata = additionalMetadata;
            MetaDictionary = new PdfDictionary { { CommonPdfNames.Length, PdfInteger.Zero } };
            if (_additionalMetadata != null)
            {
                MetaDictionary.AddRange(_additionalMetadata);
            }
            if (filters != null)
            {
                _filterEncodingChain.AddRange(filters);
                if (_filterEncodingChain.Any())
                {
                    MetaDictionary.Add(CommonPdfNames.Filter, FilterNames());
                }
            }
        }

        /// <summary>
        /// The length of this object when converted into a stream of bytes.
        /// </summary>
        public override int ByteLength
        {
            get
            {
                if (CachedPrologue == null)
                {
                    GeneratePrologueAndEpilogue();
                }
                IList<byte> encodedContent = EncodeContents().ToList();
                UpdateMetaDictionary(encodedContent);
                return CachedPrologue.Count + CachedEpilogue.Count + MetaDictionary.ByteLength + encodedContent.Count + _streamStart.Length + _streamEnd.Length;
            }
        }

        private void UpdateMetaDictionary(IEnumerable<byte> encodedContent)
        {
            int len = encodedContent.Count();
            if ((MetaDictionary[CommonPdfNames.Length] as PdfInteger).Value != len)
            {
                MetaDictionary[CommonPdfNames.Length] = new PdfInteger(len);
            }
        }

        /// <summary>
        /// Add data to the stream.
        /// </summary>
        /// <param name="bytes">The data to add to the stream.</param>
        public virtual void AddBytes(IEnumerable<byte> bytes)
        {
            _contents.AddRange(bytes);
        }

        /// <summary>
        /// Write this stream to a <see cref="Stream" />.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <returns>The number of bytes written.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the stream parameter is null.</exception>
        public override async Task<int> WriteToAsync(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            return await WriteAsync(WriteToStreamAsync, PdfDictionary.WriteToAsync, stream).ConfigureAwait(false);
        }

        /// <summary>
        /// Convert this stream to an array of bytes and append them to a <see cref="List{Byte}" />.
        /// </summary>
        /// <param name="bytes">The list to append to.</param>
        /// <returns>The number of bytes appended.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the list parameter is null.</exception>
        public override int WriteTo(IList<byte> bytes)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException(nameof(bytes));
            }
            return Write(WriteToList, PdfDictionary.WriteTo, bytes);
        }

        private int Write<T>(Action<T, byte[]> writer, Func<PdfDictionary, T, int> dictWriter, T dest)
        {
            if (CachedPrologue == null)
            {
                GeneratePrologueAndEpilogue();
            }
            writer(dest, CachedPrologue.ToArray());
            int written = CachedPrologue.Count;
            IList<byte> encodedContent = EncodeContents().ToList();
            UpdateMetaDictionary(encodedContent);
            written += dictWriter(MetaDictionary, dest);
            writer(dest, _streamStart);
            writer(dest, encodedContent.ToArray());
            writer(dest, _streamEnd);
            written += _streamStart.Length;
            written += encodedContent.Count;
            written += _streamEnd.Length;
            writer(dest, CachedEpilogue.ToArray());
            written += CachedPrologue.Count + CachedEpilogue.Count;
            return written;
        }

        private async Task<int> WriteAsync<T>(Func<T, byte[], Task> writer, Func<PdfDictionary, T, Task<int>> dictWriter, T dest)
        {
            if (CachedPrologue == null)
            {
                GeneratePrologueAndEpilogue();
            }
            await writer(dest, CachedPrologue.ToArray()).ConfigureAwait(false);
            int written = CachedPrologue.Count;
            IList<byte> encodedContent = EncodeContents().ToList();
            UpdateMetaDictionary(encodedContent);
            written += await dictWriter(MetaDictionary, dest).ConfigureAwait(false);
            await writer(dest, _streamStart).ConfigureAwait(false);
            await writer(dest, encodedContent.ToArray()).ConfigureAwait(false );
            await writer(dest, _streamEnd).ConfigureAwait(false);
            written += _streamStart.Length;
            written += encodedContent.Count;
            written += _streamEnd.Length;
            await writer(dest, CachedEpilogue.ToArray()).ConfigureAwait(false);
            written += CachedPrologue.Count + CachedEpilogue.Count;
            return written;
        }

        private IEnumerable<byte> EncodeContents()
        {
            if (_filterEncodingChain.Count == 0)
            {
                return InternalContents;
            }
            IEnumerable<byte> current = InternalContents;
            foreach (IPdfFilterEncoder encoder in _filterEncodingChain)
            {
                current = encoder.Encode(current);
            }
            return current;
        }

        private PdfSimpleObject FilterNames()
        {
            if (_filterEncodingChain.Count == 0)
            {
                return null;
            }
            if (_filterEncodingChain.Count == 1)
            {
                return _filterEncodingChain[0].FilterName;
            }
            return new PdfArray(((IEnumerable<IPdfFilterEncoder>)_filterEncodingChain).Reverse().Select(f => f.FilterName));
        }
    }

#pragma warning restore CA1711 // Identifiers should not have incorrect suffix

}