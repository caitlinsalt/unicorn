using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Unicorn.Writer.Interfaces;

namespace Unicorn.Writer.Structural
{
    /// <summary>
    /// Class representing a PDF cross-reference table.  In this implementation, the cross-reference table object is responsible for issuing and tracking all indirect object reference numbers
    /// required in the file.
    /// </summary>
    public class PdfCrossRefTable : IPdfCrossRefTable
    {
        private readonly List<PdfCrossRefTableEntry> _contents = new List<PdfCrossRefTableEntry>() { null };

        /// <summary>
        /// The number of objects allocated by this object, including both free and occupied object slots.
        /// </summary>
        public int Count => _contents.Count;

        /// <summary>
        /// Allocate a new slot in the cross-reference table and return its object ID.  The slot will be allocated as a free slot, and will not be marked as an occupied slot unless a later call
        /// to <see cref="ClaimSlot" /> is made with an object whose ID matches that returned by this method.
        /// </summary>
        /// <returns>A newly-allocated object ID.</returns>
        public int ClaimSlot()
        {
            lock (_contents)
            {
                _contents.Add(null);
                return _contents.Count - 1;
            }
        }

        /// <summary>
        /// Mark a slot in the cross-reference table as occupied by an object that has been written to a particular address in the output stream.
        /// </summary>
        /// <param name="value">The object to be listed in the table.  Its ID must be an ID previously allocated by a call to <see cref="ClaimSlot" />.</param>
        /// <param name="offset">The address of the object within the output, as a zero-based offset in bytes from the start of the strean.</param>
        /// <exception cref="ArgumentException">Thrown if the object ID of the value parameter is out of range for this cross-ref table.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the value parameter is null.</exception>
        public void SetSlot(IPdfIndirectObject value, int offset)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            if (value.ObjectId >= _contents.Count || value.ObjectId < 0)
            {
                throw new ArgumentException(Resources.Structural_PdfCrossRefTable_SetSlot_Invalid_ObjectId_Error, nameof(value));
            }
            PdfCrossRefTableEntry entry = new PdfCrossRefTableEntry(value, offset);
            _contents[value.ObjectId] = entry;
        }

        /// <summary>
        /// Write this table to a <see cref="Stream" />.
        /// </summary>
        /// <param name="stream">The strean to write to.</param>
        /// <returns>The number of bytes written.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the stream parameter is null.</exception>
        public int WriteTo(Stream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }
            int written = 0;
            lock (_contents)
            {
                byte[] prologueLineOne = new byte[] { 0x78, 0x72, 0x65, 0x66, 0xa };
                string prologueLineTwoStr = $"0 {_contents.Count - 1}\xa";
                byte[] prologueLineTwo = Encoding.ASCII.GetBytes(prologueLineTwoStr);
                stream.Write(prologueLineOne, 0, prologueLineOne.Length);
                written += prologueLineOne.Length;
                stream.Write(prologueLineTwo, 0, prologueLineTwo.Length);
                written += prologueLineTwo.Length;
                for (int i = 0; i < _contents.Count; ++i)
                {
                    if (_contents[i] == null)
                    {
                        written += WriteNullEntry(i, stream);
                    }
                    else
                    {
                        written += WriteEntry(_contents[i], stream);
                    }
                }
                return written;
            }
        }

        private static int WriteEntry(PdfCrossRefTableEntry entry, Stream stream)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(string.Format(CultureInfo.InvariantCulture, "{0:d10} {1:d5} n \xa", entry.Offset, entry.Value.Generation));
            stream.Write(bytes, 0, bytes.Length);
            return bytes.Length;
        }

        private int WriteNullEntry(int i, Stream stream)
        {
            int nextItem = i < _contents.Count - 1 ? _contents.FindIndex(i + 1, e => e == null) : 0;
            if (nextItem < 0)
            {
                nextItem = 0;
            }
            byte[] bytes = Encoding.ASCII.GetBytes(string.Format(CultureInfo.InvariantCulture, "{0:d10} {1:d5} f \xa", nextItem, i == 0 ? 65535 : 0));
            stream.Write(bytes, 0, bytes.Length);
            return bytes.Length;
        }
    }
}
