using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unicorn.Writer.Extensions;
using Unicorn.Writer.Interfaces;

namespace Unicorn.Writer.Primitives
{

#pragma warning disable CA1711 // This is a dictionary in the PDF sense, even if it is not in the .NET sense.

    /// <summary>
    /// The class representing a PDF dictionary.  Unlike most of the classes in the Unicorn.Writer.Primitives namespace, this one is mutable.  The keys to the dictionary are 
    /// <see cref="PdfName" /> instances; the values can be any <see cref="IPdfPrimitiveObject" />.
    /// </summary>
    public class PdfDictionary : IPdfPrimitiveObject, IEnumerable<KeyValuePair<PdfName, IPdfPrimitiveObject>>
    {
        private readonly Dictionary<PdfName, IPdfPrimitiveObject> _contents = new Dictionary<PdfName, IPdfPrimitiveObject>();
        private byte[] cachedBytes;

        /// <summary>
        /// The length of the object when converted into bytes.
        /// </summary>
        public int ByteLength
        {
            get
            {
                lock (_contents)
                {
                    if (cachedBytes == null)
                    {
                        GenerateBytes();
                    }
                    return cachedBytes.Length;
                }
            }
        }

        /// <summary>
        /// Dictionary indexer.
        /// </summary>
        /// <param name="key">The key.  This must be a string that is valid to use as a <see cref="PdfName" />.</param>
        /// <returns>The <see cref="IPdfPrimitiveObject" /> stored with the given key.</returns>
        public IPdfPrimitiveObject this[string key]
        {
            get
            {
                return this[new PdfName(key)];
            }
            set
            {
                this[new PdfName(key)] = value;
            }
        }

#pragma warning disable CA1043 // Use Integral Or String Argument For Indexers

        /// <summary>
        /// Dictionary indexer.
        /// </summary>
        /// <param name="key">The <see cref="PdfName" /> key.</param>
        /// <returns>The <see cref="IPdfPrimitiveObject" /> stored with the given key.</returns>
        public IPdfPrimitiveObject this[PdfName key]
        {
            get
            {
                if (key is null)
                {
                    throw new ArgumentNullException(nameof(key));
                }
                lock(_contents)
                {
                    if (_contents.ContainsKey(key))
                    {
                        return _contents[key];
                    }
                    throw new KeyNotFoundException(Resources.Primitives_PdfDictionary_Indexer_Key_Not_Found_Error);
                }
            }
            set
            {
                if (key == null)
                {
                    throw new ArgumentNullException(nameof(key));
                }
                if (value == null)
                {
                    value = PdfNull.Value;
                }
                lock (_contents)
                {
                    if (_contents.ContainsKey(key))
                    {
                        _contents[key] = value;
                    }
                    else
                    {
                        _contents.Add(key, value);
                    }
                }
            }
        }

#pragma warning restore CA1043 // Use Integral Or String Argument For Indexers

        /// <summary>
        /// The number of items (and keys) in the dictionary.
        /// </summary>
        public int Count => _contents.Count;
        
        /// <summary>
        /// Add a new entry to the dictionary.
        /// </summary>
        /// <param name="key">The name to be used as the key for the new dictionary entry.</param>
        /// <param name="value">The value of the new dictionary entry.  If this parameter is null, a <see cref="PdfNull" /> instance will be used for the entry value.</param>
        /// <exception cref="ArgumentNullException">Thrown if the key parameter is null.</exception>
        /// <exception cref="ArgumentException">Thrown if the dictionary already contains an entry with an equal key.</exception>
        public void Add(PdfName key, IPdfPrimitiveObject value)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (value == null)
            {
                value = PdfNull.Value;
            }
            lock(_contents)
            {
                if (_contents.ContainsKey(key))
                {
                    throw new ArgumentException(Resources.Primitives_PdfDictionary_Add_Duplicate_Key_Error, nameof(key));
                }
                _contents.Add(key, value);
            }
        }

        /// <summary>
        /// Add a sequence of key-value pairs to the dictionary.
        /// </summary>
        /// <param name="data">The data to be added to the dictionary.</param>
        /// <exception cref="ArgumentException">One or more of the keys in the data is already present in the dictionary.</exception>
        /// <exception cref="ArgumentNullException">The parameter is <c>null</c>.</exception>
        public void AddRange(IEnumerable<KeyValuePair<PdfName, IPdfPrimitiveObject>> data)
        {
            if (data is null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            lock (_contents)
            {
                foreach (KeyValuePair<PdfName, IPdfPrimitiveObject> item in data)
                {
                    if (_contents.ContainsKey(item.Key))
                    {
                        throw new ArgumentException(Resources.Primitives_PdfDictionary_Add_Duplicate_Key_Error, nameof(data));
                    }
                    _contents.Add(item.Key, item.Value);
                }
            }
        }

        /// <summary>
        /// Determine whether or not the <see cref="PdfDictionary" /> contains a value with the given key.
        /// </summary>
        /// <param name="key">The key to search for.</param>
        /// <returns><c>true</c> if the dictionary contains a value with the given parameter as its key, <c>false</c> if not.</returns>
        public bool ContainsKey(PdfName key)
        {
            if (key is null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            return _contents.ContainsKey(key);
        }

        /// <summary>
        /// Write the current contents of the dictionary to a <see cref="Stream" />.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <returns>The number of bytes written.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the stream parameter is null.</exception>
        public int WriteTo(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            return Write(WriteToStream, stream);
        }

        internal static int WriteTo(PdfDictionary dict, Stream stream)
        {
            return dict.WriteTo(stream);
        }

        /// <summary>
        /// Convert the current contents of the dictionary to bytes and append them to a list.
        /// </summary>
        /// <param name="bytes">The list to append to.</param>
        /// <returns>The number of bytes appended to the list.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the list parameter is null.</exception>
        public int WriteTo(IList<byte> bytes)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException(nameof(bytes));
            }
            return Write(WriteToList, bytes);
        }

        internal static int WriteTo(PdfDictionary dict, IList<byte> list)
        {
            return dict.WriteTo(list);
        }

        /// <summary>
        /// Write the current contents of the dictionary to a <see cref="PdfStream" />.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <returns>The number of bytes written.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the stream parameter is null.</exception>
        public int WriteTo(PdfStream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            return Write(WriteToPdfStream, stream);
        }

        private int Write<T>(Action<T, byte[]> writer, T dest)
        {
            byte[] currentBytes;
            lock (_contents)
            {
                if (cachedBytes == null)
                {
                    GenerateBytes();
                }
                currentBytes = cachedBytes;
            }
            writer(dest, currentBytes);
            return currentBytes.Length;
        }

        private static void WriteToStream(Stream str, byte[] bytes)
        {
            str.Write(bytes, 0, bytes.Length);
        }

        private static void WriteToList(IList<byte> list, byte[] bytes)
        {
            list.AddRange(bytes);
        }

        private static void WriteToPdfStream(PdfStream stream, byte[] bytes)
        {
            stream.AddBytes(bytes);
        }

        private void GenerateBytes()
        {
            List<byte> byteList = new List<byte>() { 0x3c, 0x3c };
            int runningCount = 2;
            foreach (KeyValuePair<PdfName, IPdfPrimitiveObject> pair in _contents)
            {
                WriteObj(ref runningCount, byteList, pair.Key);
                WriteObj(ref runningCount, byteList, pair.Value);
            }
            if (runningCount > 253)
            {
                byteList.Add(0xa);
            }
            byteList.AddRange(new byte[] { 0x3e, 0x3e, 0xa });
            cachedBytes = byteList.ToArray();
        }

        private static void WriteObj(ref int runningCount, List<byte> byteList, IPdfPrimitiveObject obj)
        {
            int objLength = obj.ByteLength;
            if (runningCount + objLength > 254)
            {
                byteList.Add(0xa);
                runningCount = 0;
            }
            obj.WriteTo(byteList);
            if (objLength > 254)
            {
                byteList.Add(0xa);
                runningCount = 0;
            }
            else
            {
                runningCount += objLength;
            }
        }

        /// <summary>
        /// Get an enumerator over the data in the dictionary.
        /// </summary>
        /// <returns>An enumeration of the key-value pairs in the dictionary.</returns>
        public IEnumerator<KeyValuePair<PdfName, IPdfPrimitiveObject>> GetEnumerator()
        {
            return _contents.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _contents.GetEnumerator();
        }
    }

#pragma warning restore CA1711 // Identifiers should not have incorrect suffix

}
