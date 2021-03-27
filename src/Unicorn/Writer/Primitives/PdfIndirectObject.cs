using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Unicorn.Writer.Extensions;
using Unicorn.Writer.Interfaces;

namespace Unicorn.Writer.Primitives
{
    /// <summary>
    /// General implementation of an indirect object.  A PDF indirect object is a top-level object in the file, can be uniquely identified among the indirect objects in the file by
    /// its combination of object ID and generation number, and is indexed in the file's cross-reference table.  It consists of a direct object wrapped with a prologue and epilogue.  This
    /// general implementation wraps an arbitrary direct object.
    /// </summary>
    public class PdfIndirectObject : IPdfPrimitiveObject, IPdfIndirectObject
    {
        private readonly IPdfPrimitiveObject _contents;
        private readonly bool _nonCacheable;
        private PdfReference _reference;

        /// <summary>
        /// The indirect object prologue as a list of bytes.
        /// </summary>
        protected IList<byte> CachedPrologue { get; private set; }

        /// <summary>
        /// The indirect object epilogue as a list of bytes.
        /// </summary>
        protected IList<byte> CachedEpilogue { get; private set; }
        
        /// <summary>
        /// The ID number of this object.
        /// </summary>
        public int ObjectId { get; }

        /// <summary>
        /// The generation number of this object.  As the library does not currently support rewriting existing PDF files, at present this property is always zero.
        /// </summary>
        public int Generation { get; }

        /// <summary>
        /// The length of this object when converted into a stream of bytes.
        /// </summary>
        public virtual int ByteLength
        {
            get
            {
                if (CachedPrologue == null)
                {
                    GeneratePrologueAndEpilogue();
                }
                int val = CachedPrologue.Count + CachedEpilogue.Count + _contents.ByteLength;
                if (_nonCacheable)
                {
                    CachedPrologue = null;
                    CachedEpilogue = null;
                }
                return val;
            }
        }

        /// <summary>
        /// Constructor which only sets object ID and generation number.  This constructor should only be called by the constructors of derived classes which maintain their own contents.
        /// </summary>
        /// <param name="objectId">The object ID of this object.  This should be an ID number obtained from the file's cross-reference table."/></param>
        /// <param name="generation">The generation number of this object.  As the library does not currently support rewriting existing files, this parameter should normally be zero.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the object ID is equal to or less than zero, or the generation number is less than zero.</exception>
        protected PdfIndirectObject(int objectId, int generation)
        {
            if (objectId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(objectId), Resources.Primitives_PdfIndirectObject_Invalid_ObjectId_Error);
            }
            if (generation < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(generation), Resources.Primitives_PdfIndirectObject_Invalid_Generation_Error);
            }

            ObjectId = objectId;
            Generation = generation;
        }

        /// <summary>
        /// Constructor which sets object ID, generation number and contents.
        /// </summary>
        /// <param name="objectId">The object ID of this object.  This should be an ID number obtained from the file's cross-reference table.</param>
        /// <param name="contents">The direct primitive object which makes up the contents of the indirect object.</param>
        /// <param name="generation">The generation nyumber of this object.  Defaults to 0.  As the library does not currently support rewriting existing files, this parameter should
        /// not be supplied.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the object ID is equal to or less than zero, or the generation number is less than zero.</exception>
        /// <exception cref="ArgumentException">Thrown if the contents paraemter is an indirect object.</exception>
        public PdfIndirectObject(int objectId, IPdfPrimitiveObject contents, int generation = 0) : this(objectId, generation)
        {
            if (contents is IPdfIndirectObject)
            {
                throw new ArgumentException(Resources.Primitives_PdfIndirectObject_Nest_PdfIndirectObject_Error, nameof(contents));
            }
            if (contents == null)
            {
                contents = PdfNull.Value;
            }

            _contents = contents;
            _nonCacheable = contents is PdfDictionary;
        }

        /// <summary>
        /// Write this object to a <see cref="Stream" />.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <returns>The number of bytes written to the stream.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the stream parameter is null.</exception>
        public virtual int WriteTo(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            return Write(WriteToStream, _contents.WriteTo, stream);
        }

        /// <summary>
        /// Convert this object to a series of bytes and append them to an existing list.
        /// </summary>
        /// <param name="bytes">The list to append to.</param>
        /// <returns>The number of bytes appended.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the list parameter is null.</exception>
        public virtual int WriteTo(IList<byte> bytes)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException(nameof(bytes));
            }
            return Write(WriteToList, _contents.WriteTo, bytes);
        }

        /// <summary>
        /// Attempt to write this object to a <see cref="PdfStream" />.  This is implemented due to interface inheritance but is an invalid operation, as PDF streams can only contain direct objects.
        /// </summary>
        /// <param name="stream">The stream to attempt to write to.</param>
        /// <returns>This method does not return.</returns>
        /// <exception cref="InvalidOperationException">This exception is always thrown.</exception>
        public virtual int WriteTo(PdfStream stream)
        {
            throw new InvalidOperationException(Resources.Primitives_PdfIndirectObject_Write_To_PdfStream_Error);
        }

        /// <summary>
        /// Write this object to a destination using a pair of writer methods.  This is largely intended to be used internally, but is exposed to derived classes.
        /// </summary>
        /// <typeparam name="T">The type of the destination object.</typeparam>
        /// <param name="writer">The writer method used to write the prologue and epilogue parts of the object.</param>
        /// <param name="contentWriter">The writer method used to write the content of the object - an instance method of the content itself.</param>
        /// <param name="dest">The destination object, to which the object will be written.</param>
        /// <returns>The number of bytes written to the destination.</returns>
        protected int Write<T>(Action<T, byte[]> writer, Func<T, int> contentWriter, T dest)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }
            if (contentWriter is null)
            {
                throw new ArgumentNullException(nameof(contentWriter));
            }
            if (CachedPrologue == null)
            {
                GeneratePrologueAndEpilogue();
            }
            writer(dest, CachedPrologue.ToArray());
            int written = contentWriter(dest);
            writer(dest, CachedEpilogue.ToArray());
            written += CachedPrologue.Count + CachedEpilogue.Count;
            if (_nonCacheable)
            {
                CachedPrologue = null;
            }
            return written;
        }

        /// <summary>
        /// Helper method that writes the array given as the second parameter to the stream given as the first parameter.
        /// </summary>
        /// <param name="str">Stream to write to.</param>
        /// <param name="bytes">Array to write.</param>
        /// <exception cref="ArgumentNullException">Thrown if either parameter is null.</exception>
        protected static void WriteToStream(Stream str, byte[] bytes)
        {
            if (str == null)
            {
                throw new ArgumentNullException(nameof(str));
            }
            if (bytes == null)
            {
                throw new ArgumentNullException(nameof(bytes));
            }
            str.Write(bytes, 0, bytes.Length);
        }

        /// <summary>
        /// Helper method that appends the second parameter to the first parameter.
        /// </summary>
        /// <param name="list">The list that will be appended to.</param>
        /// <param name="bytes">The bytes to append.</param>
        protected static void WriteToList(IList<byte> list, byte[] bytes)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }
            list.AddRange(bytes);
        }

        /// <summary>
        /// Get a <see cref="PdfReference" /> instance that refers to this object.
        /// </summary>
        /// <returns>A <see cref="PdfReference" /></returns>
        public PdfReference GetReference()
        {
            return _reference ?? (_reference = new PdfReference(this));
        }

        /// <summary>
        /// Populate the <see cref="CachedPrologue" /> and <see cref="CachedEpilogue" /> properties.
        /// </summary>
        protected void GeneratePrologueAndEpilogue()
        {
            int contentLen = _contents?.ByteLength ?? 2;            
            string prologueString = $"{ObjectId} {Generation} obj ";
            if (contentLen + prologueString.Length > 253)
            {
                prologueString += "\xa";
            }
            if (contentLen + prologueString.Length > 247)
            {
                CachedEpilogue = new List<byte> { 0xa, 0x65, 0x6e, 0x64, 0x6f, 0x62, 0x6a, 0xa };
            }
            else
            {
                CachedEpilogue = new List<byte> { 0x65, 0x6e, 0x64, 0x6f, 0x62, 0x6a, 0xa };
            }
            CachedPrologue = Encoding.ASCII.GetBytes(prologueString).ToList();
        }
    }
}
