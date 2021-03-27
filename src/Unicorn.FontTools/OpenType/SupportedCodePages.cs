using System;
using System.Collections.Generic;

namespace Unicorn.FontTools.OpenType
{
    /// <summary>
    /// Code pages supported by a font.
    /// </summary>
    public class SupportedCodePages : LargeBitfield
    {
        /// <summary>
        /// Bit 0: Code page 1252.
        /// </summary>
        public bool Latin1 { get; private set; }

        /// <summary>
        /// Bit 1: Code page 1250.
        /// </summary>
        public bool Latin2 { get; private set; }

        /// <summary>
        /// Bit 2: Code page 1251.
        /// </summary>
        public bool Cyrillic { get; private set; }

        /// <summary>
        /// Bit 3: Code page 1253.
        /// </summary>
        public bool Greek { get; private set; }

        /// <summary>
        /// Bit 4: Code page 1254.
        /// </summary>
        public bool Turkish { get; private set; }

        /// <summary>
        /// Bit 5: Code page 1255.
        /// </summary>
        public bool Hebrew { get; private set; }

        /// <summary>
        /// Bit 6: Code page 1256.
        /// </summary>
        public bool Arabic { get; private set; }

        /// <summary>
        /// Bit 7: Code page 1257.
        /// </summary>
        public bool WindowsBaltic { get; private set; }

        /// <summary>
        /// Bit 8: Code page 1258.
        /// </summary>
        public bool Vietnamese { get; private set; }

        /// <summary>
        /// Bit 16: Code page 874.
        /// </summary>
        public bool Thai { get; private set; }

        /// <summary>
        /// Bit 17: Code page 932.
        /// </summary>
        public bool JIS { get; private set; }

        /// <summary>
        /// Bit 18: Code page 936.
        /// </summary>
        public bool ChineseSimplified { get; private set; }

        /// <summary>
        /// Bit 19: Code page 949.
        /// </summary>
        public bool KoreanWansung { get; private set; }

        /// <summary>
        /// Bit 20: Code page 950.
        /// </summary>
        public bool ChineseTraditional { get; private set; }

        /// <summary>
        /// Bit 21: Code page 1361.
        /// </summary>
        public bool KoreanJohab { get; private set; }

        /// <summary>
        /// Bit 29: Macintosh US Roman
        /// </summary>
        public bool MacRoman { get; private set; }

        /// <summary>
        /// Bit 30: OEM character set.
        /// </summary>
        public bool OEM { get; private set; }

        /// <summary>
        /// Bit 31: Symbol character set.
        /// </summary>
        public bool Symbol { get; private set; }

        /// <summary>
        /// Bit 48: Code page 869.
        /// </summary>
        public bool IBMGreek { get; private set; }

        /// <summary>
        /// Bit 49: Code page 866.
        /// </summary>
        public bool MSDosRussian { get; private set; }

        /// <summary>
        /// Bit 50: Code page 865.
        /// </summary>
        public bool MSDosNordic { get; private set; }

        /// <summary>
        /// Bit 51: Code page 864.
        /// </summary>
        public bool MSDosArabic { get; private set; }

        /// <summary>
        /// Bit 52: Code page 863.
        /// </summary>
        public bool MSDosCanadianFrench { get; private set; }

        /// <summary>
        /// Bit 53: Code page 862.
        /// </summary>
        public bool MSDosHebrew { get; private set; }

        /// <summary>
        /// Bit 54: Code page 861.
        /// </summary>
        public bool MSDosIslensk { get; private set; }

        /// <summary>
        /// Bit 55: Code page 860.
        /// </summary>
        public bool MSDosPortuguese { get; private set; }

        /// <summary>
        /// Bit 56: Code page 857.
        /// </summary>
        public bool IBMTurkish { get; private set; }

        /// <summary>
        /// Bit 57: Code page 855.
        /// </summary>
        public bool IBMCyrillic { get; private set; }

        /// <summary>
        /// Bit 58: Code page 852.
        /// </summary>
        public bool MSDosLatin2 { get; private set; }

        /// <summary>
        /// Bit 59: Code page 775.
        /// </summary>
        public bool MSDosBaltic { get; private set; }

        /// <summary>
        /// Bit 60: Code page 737 (formerly 437G).
        /// </summary>
        public bool Greek737 { get; private set; }

        /// <summary>
        /// Bit 61: Code page 708.
        /// </summary>
        public bool Arabic708 { get; private set; }

        /// <summary>
        /// Bit 62 Code page 850.
        /// </summary>
        public bool WELatin1 { get; private set; }

        /// <summary>
        /// Bit 63: Code page 437.
        /// </summary>
        public bool US { get; private set; }

        // According to the OpenType spec, the input data for this routine consists of 8 bytes to be interpreted as a bitfield; however, the final two bytes
        // are specified as containing unused bits, so this routine only cares about the first 6.
        // Byte 0  :: bits 24-31
        // Byte 1  :: bits 16-23
        // Byte 2  :: bits 8-15
        // Byte 3  :: bits 0-7
        // Byte 4  :: bits 56-63
        // Byte 5  :: bits 48-55
        // [Byte 6  :: bits 40-47 (not used)]
        // [Byte 7  :: bits 32-39 (not used)]

        /// <summary>
        /// Returns an array of methods which set the properties of this instance.
        /// </summary>
        protected override Action<bool[]>[] SetterMethods() => new Action<bool[]>[] { SetByte0, SetByte1, SetByte2, SetByte3, SetByte4, SetByte5, };

        /// <summary>
        /// Create a new <see cref="SupportedCodePages" /> object from an array of at least 6 bytes, as stored i a font.
        /// </summary>
        /// <param name="data">The data to create the object from.</param>
        /// <param name="offset">The index of the first byte of the block of 16 bytes from which the object should be constructed.</param>
        /// <returns>A <see cref="SupportedCodePages" /> object with properties as encoded in the <c>data</c>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <c>data</c> parameter is <c>null</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the <c>offset</c> parameter is less than 0 or is not an valid index to a block of 6 bytes within 
        ///   the <c>data</c> array</exception>
        public static SupportedCodePages FromBytes(byte[] data, int offset)
        {
            SupportedCodePages output = new SupportedCodePages();
            output.PopulateFromBytes(data, offset);
            return output;
        }

        private void SetByte3(bool[] data)
        {
            Latin1 = data[0];
            Latin2 = data[1];
            Cyrillic = data[2];
            Greek = data[3];
            Turkish = data[4];
            Hebrew = data[5];
            Arabic = data[6];
            WindowsBaltic = data[7];
        }

        private void SetByte2(bool[] data)
        {
            Vietnamese = data[0];
        }

        private void SetByte1(bool[] data)
        {
            Thai = data[0];
            JIS = data[1];
            ChineseSimplified = data[2];
            KoreanWansung = data[3];
            ChineseTraditional = data[4];
            KoreanJohab = data[5];
        }

        private void SetByte0(bool[] data)
        {
            MacRoman = data[5];
            OEM = data[6];
            Symbol = data[7];
        }

        private void SetByte5(bool[] data)
        {
            IBMGreek = data[0];
            MSDosRussian = data[1];
            MSDosNordic = data[2];
            MSDosArabic = data[3];
            MSDosCanadianFrench = data[4];
            MSDosHebrew = data[5];
            MSDosIslensk = data[6];
            MSDosPortuguese = data[7];
        }

        private void SetByte4(bool[] data)
        {
            IBMTurkish = data[0];
            IBMCyrillic = data[1];
            MSDosLatin2 = data[2];
            MSDosBaltic = data[3];
            Greek737 = data[4];
            Arabic708 = data[5];
            WELatin1 = data[6];
            US = data[7];
        }

        /// <summary>
        /// The properties used by <see cref="LargeBitfield.ToString" /> to generate a string representation of this instance.
        /// </summary>
        /// <returns>An array of property names.</returns>
        protected override IEnumerable<string> StringificationProperties() => new[]
        {
            nameof(Latin1), nameof(Latin2), nameof(Cyrillic), nameof(Greek), nameof(Turkish), nameof(Hebrew), nameof(Arabic), nameof(WindowsBaltic), nameof(Vietnamese),
            nameof(Thai), nameof(JIS), nameof(ChineseSimplified), nameof(KoreanWansung), nameof(ChineseTraditional), nameof(KoreanJohab), nameof(MacRoman), nameof(OEM),
            nameof(Symbol), nameof(IBMGreek), nameof(MSDosRussian), nameof(MSDosNordic), nameof(MSDosArabic), nameof(MSDosCanadianFrench), nameof(MSDosHebrew),
            nameof(MSDosIslensk), nameof(MSDosPortuguese), nameof(IBMTurkish), nameof(IBMCyrillic), nameof(MSDosLatin2), nameof(MSDosBaltic), nameof(Greek737),
            nameof(Arabic708), nameof(WELatin1), nameof(US),
        };
    }
}
