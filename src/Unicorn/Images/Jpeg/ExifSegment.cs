using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Unicorn.Exceptions;
using Unicorn.Helpers;

namespace Unicorn.Images.Jpeg
{
    internal class ExifSegment : ImageDataBlock
    {
        private readonly List<ExifTag> _tags = new List<ExifTag>();
        private Func<byte[], int, long> _readUInt;
        private Func<byte[], int, long> _readInt;
        private Func<byte[], int, int> _readUShort;
        private Func<Stream, int> _readUShortFromStream;

        private long _exifOffset = -1;
        private long _gpsOffset = -1;

        internal IEnumerable<ExifTag> Tags => _tags.ToArray();

        internal ExifSegment(long startOffset, int length) : base(startOffset, length, ImageDataBlockType.Exif) { }

        internal async Task PopulateSegmentAsync(Stream dataStream, long exifOffset)
        {
            long tiffHeaderBase = exifOffset + 10;
            long initialIfdAddress = await PopulateTiffHeaderDataAsync(dataStream, tiffHeaderBase).ConfigureAwait(false);
            await ReadIfdAsync(dataStream, initialIfdAddress, tiffHeaderBase).ConfigureAwait(false);
            if (_exifOffset > 0)
            {
                await ReadIfdAsync(dataStream, tiffHeaderBase + _exifOffset, tiffHeaderBase).ConfigureAwait(false);
            }
            if (_gpsOffset > 0)
            {
                await ReadIfdAsync(dataStream, tiffHeaderBase + _gpsOffset, tiffHeaderBase).ConfigureAwait(false);
            }
        }

        private async Task<long> PopulateTiffHeaderDataAsync(Stream dataStream, long headerAddress)
        {
            const int TIFF_HEADER_LENGTH = 8;
            dataStream.Seek(headerAddress, SeekOrigin.Begin);
            byte[] headerBuffer = new byte[TIFF_HEADER_LENGTH];
            await dataStream.ReadAsync(headerBuffer, 0, TIFF_HEADER_LENGTH).ConfigureAwait(false);

            if (headerBuffer[0] == 0x49 && headerBuffer[1] == 0x49)
            {
                SetUpLittleEndianMethods();
            }
            else if (headerBuffer[0] == 0x4d && headerBuffer[1] == 0x4d)
            {
                SetUpBigEndianMethods();
            }
            else
            {
                throw new InvalidImageException(ImageLoadResources.ExifSegment_EndiannessMarkerNotFound);
            }

            if (!((headerBuffer[2] == 0 && headerBuffer[3] == 42) || (headerBuffer[2] == 42 && headerBuffer[3] == 0)))
            {
                throw new InvalidImageException(ImageLoadResources.ExifSegment_AnswerToEverythingNotFound);
            }

            return _readUInt(headerBuffer, 4) + headerAddress;
        }

        private async Task ReadIfdAsync(Stream dataStream, long startAddress, long addressBase)
        {
            dataStream.Seek(startAddress, SeekOrigin.Begin);
            int fieldCount = _readUShortFromStream(dataStream);
            const int FIELD_SIZE = 12;
            byte[] tagBuffer = new byte[FIELD_SIZE * fieldCount];
            await dataStream.ReadAsync(tagBuffer, 0, FIELD_SIZE * fieldCount).ConfigureAwait(false);
            for (int i = 0; i < fieldCount; i++)
            {
                await LoadTagAsync(tagBuffer, i * FIELD_SIZE, dataStream, addressBase).ConfigureAwait(false);
            }
        }

        private async Task LoadTagAsync(byte[] buffer, int tagOffset, Stream dataStream, long addressBase)
        {
            ExifTagId tagId = (ExifTagId)_readUShort(buffer, tagOffset);
            ExifStorageType fileDefinedStorageType = (ExifStorageType)_readUShort(buffer, tagOffset + 2);
            ExifStorageType specDefiinedStorageType = tagId.StorageType();
            if (specDefiinedStorageType != ExifStorageType.ReadFromFile && specDefiinedStorageType != fileDefinedStorageType)
            {
                throw new InvalidImageException(string.Format(CultureInfo.CurrentCulture, ImageLoadResources.ExifSegment_WrongTagDataType, 
                    tagId.ToString(), specDefiinedStorageType.ToString(), fileDefinedStorageType.ToString()));
            }
            long count = _readUInt(buffer, tagOffset + 4);
            if (count == 0)
            {
                return;
            }
            Type expectedDataType = tagId.DataType();
            if (expectedDataType != typeof(string) && !expectedDataType.IsArray && count > 1)
            {
                throw new InvalidImageException(string.Format(CultureInfo.CurrentCulture, ImageLoadResources.ExifSegment_WrongTagDataCount, 
                    tagId.ToString()));
            }
            ExifTag theTag = new ExifTag(await ReadTagValue(buffer, tagOffset, count, fileDefinedStorageType, expectedDataType.IsArray, dataStream, addressBase).ConfigureAwait(false), tagId);
            if (theTag.Id == ExifTagId.ExifPointer)
            {
                _exifOffset = (long)theTag.Value;
            }
            else if (theTag.Id == ExifTagId.GPSPointer)
            {
                _gpsOffset = (long)theTag.Value;
            }
            else
            {
                _tags.Add(theTag);
            }
        }

        private async Task<object> ReadTagValue(byte[] buffer, int tagOffset, long valueCount, ExifStorageType storageType, bool arrayExpected, Stream dataStream, long addressBase)
        {
            switch (storageType)
            {
                default:
                    throw new InvalidImageException(ImageLoadResources.ExifSegment_ImpossibleTagDataType);
                case ExifStorageType.Byte:
                case ExifStorageType.Undefined:
                    return await ReadTagByteValueAsync(buffer, tagOffset, valueCount, arrayExpected, dataStream, addressBase).ConfigureAwait(false);
                case ExifStorageType.Ascii:
                    return await ReadTagStringValueAsync(buffer, tagOffset, valueCount, arrayExpected, dataStream, addressBase).ConfigureAwait(false);
                case ExifStorageType.Short:
                    return await ReadTagUShortValueAsync(buffer, tagOffset, valueCount, arrayExpected, dataStream, addressBase).ConfigureAwait(false);
                case ExifStorageType.Long:
                case ExifStorageType.Slong:
                    return await ReadTagIntValueAsync(buffer, tagOffset, valueCount, storageType, arrayExpected, dataStream, addressBase).ConfigureAwait(false);
                case ExifStorageType.Rational:
                case ExifStorageType.Srational:
                    return await ReadTagRationalValueAsync(buffer, tagOffset, valueCount, storageType, arrayExpected, dataStream, addressBase).ConfigureAwait(false);
            }
        }

        private async Task<object> ReadTagByteValueAsync(byte[] buffer, int tagOffset, long valueCount, bool arrayExpected, Stream dataStream, long addressBase)
        {
            if (valueCount == 1)
            {
                if (arrayExpected)
                {
                    return new byte[] { buffer[tagOffset + 8] };
                }
                else
                {
                    return buffer[tagOffset + 8];
                }
            }
            var theBytes = new byte[valueCount];
            if (valueCount <= 4)
            {
                Array.Copy(buffer, tagOffset + 8, theBytes, 0, valueCount);
            }
            else
            {
                await PopulateSubBuffer(buffer, tagOffset, theBytes, dataStream, addressBase).ConfigureAwait(false);
            }
            return theBytes;
        }

        private async Task<object> ReadTagUShortValueAsync(byte[] buffer, int tagOffset, long valueCount, bool arrayExpected, Stream dataStream, long addressBase)
        {
            if (valueCount == 1)
            {
                int theValue = _readUShort(buffer, tagOffset + 8);
                if (arrayExpected)
                {
                    return new int[] { theValue };
                }
                else
                {
                    return theValue;
                }
            }
            if (valueCount == 2)
            {
                return new int[] { _readUShort(buffer, tagOffset + 8), _readUShort(buffer, tagOffset + 10) };
            }
            byte[] theBytes = new byte[valueCount * 2];
            int[] theOutput = new int[valueCount];
            await PopulateSubBuffer(buffer, tagOffset, theBytes, dataStream, addressBase).ConfigureAwait(false);
            for (int i = 0; i < valueCount; i++)
            {
                theOutput[i] = _readUShort(theBytes, i * 2);
            }
            return theOutput;
        }

        private async Task<object> ReadTagIntValueAsync(byte[] buffer, int tagOffset, long valueCount, ExifStorageType storageType, bool arrayExpected, Stream dataStream, long addressBase)
        {
            Func<byte[], int, long> readerMethod = (storageType == ExifStorageType.Slong) ? _readInt : _readUInt;
            if (valueCount == 1)
            {
                long theValue = readerMethod(buffer, tagOffset + 8);
                if (arrayExpected)
                {
                    return new long[] { theValue };
                }
                else
                {
                    return theValue;
                }
            }
            byte[] theBytes = new byte[valueCount * 4];
            long[] theOutput = new long[valueCount];
            await PopulateSubBuffer(buffer, tagOffset, theBytes, dataStream, addressBase).ConfigureAwait(false);
            for (int i = 0; i < valueCount; i++)
            {
                theOutput[i] = readerMethod(theBytes, i * 2);
            }
            return theOutput;
        }

        private async Task<object> ReadTagRationalValueAsync(byte[] buffer, int tagOffset, long valueCount, ExifStorageType storageType, bool arrayExpected, Stream dataStream, long addressBase)
        {
            Func<byte[], int, long> readerMethod = (storageType == ExifStorageType.Srational) ? _readInt : _readUInt;
            byte[] theBytes = new byte[valueCount * 8];
            decimal[] theOutput = new decimal[valueCount];
            await PopulateSubBuffer(buffer, tagOffset, theBytes, dataStream, addressBase).ConfigureAwait(false);
            for (int i = 0; i < valueCount; ++i)
            {
                theOutput[i] = readerMethod(theBytes, i * 8) / (decimal)readerMethod(theBytes, i * 8 + 4);
            }
            if (arrayExpected)
            {
                return theOutput;
            }
            return theOutput[0];
        }

        private async Task<object> ReadTagStringValueAsync(byte[] buffer, int tagOffset, long valueCount, bool arrayExpected, Stream dataStream, long addressBase)
        {
            byte[] bytes = new byte[valueCount];
            if (valueCount <= 4)
            {
                Array.Copy(buffer, tagOffset + 8, bytes, 0, valueCount);
            }
            else
            {
                await PopulateSubBuffer(buffer, tagOffset, bytes, dataStream, addressBase).ConfigureAwait(false);
            }
            return Encoding.ASCII.GetString(bytes);
        }

        private async Task PopulateSubBuffer(byte[] mainBuffer, int offset, byte[] subBuffer, Stream dataStream, long addressBase)
        {
            const int DATA_ADDRESS_OFFSET = 8;
            long subBufferOffset = _readUInt(mainBuffer, offset + DATA_ADDRESS_OFFSET);
            dataStream.Seek(addressBase + subBufferOffset, SeekOrigin.Begin);
            await dataStream.ReadAsync(subBuffer, 0, subBuffer.Length).ConfigureAwait(false);
        }

        private void SetUpBigEndianMethods()
        {
            _readInt = ByteArrayExtensions.ReadBigEndianInt;
            _readUInt = ByteArrayExtensions.ReadBigEndianUInt;
            _readUShort = ByteArrayExtensions.ReadBigEndianUShort;
            _readUShortFromStream = StreamExtensions.ReadBigEndianUShort;
        }

        private void SetUpLittleEndianMethods()
        {
            _readInt = ByteArrayExtensions.ReadLittleEndianInt;
            _readUInt = ByteArrayExtensions.ReadLittleEndianUInt;
            _readUShort = ByteArrayExtensions.ReadLittleEndianUShort;
            _readUShortFromStream = StreamExtensions.ReadLittleEndianUShort;
        }
    }
}
