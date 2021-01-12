using System;
using System.Collections.Generic;

namespace Unicorn.FontTools.OpenType
{
    /// <summary>
    /// The OS/2 table contains 16 bytes (split into 4 unsigned 32-bit integers) which are defined as a bitfield describing which Unicode blocks the font supports.
    /// This class contains properties representing each bit in that field.  Note that not every Unicode block is covered by the available bits, and the bits in
    /// the bitfield do not occur in exactly the same order as the codepoint ranges they represent.  The highest six bits of the bitfield are at present unused, 
    /// reserved, and should be set to zero in a font file; they are therefore not covered here.
    /// </summary>
    public class UnicodeRanges : LargeBitfield
    {
        /// <summary>
        /// Bit 0: Block 0000-007F.
        /// </summary>
        public bool BasicLatin { get; private set; }

        /// <summary>
        /// Bit 1: Block 0080-00FF.
        /// </summary>
        public bool Latin1Supplement { get; private set; }

        /// <summary>
        /// Bit 2: Block 0100-017F.
        /// </summary>
        public bool LatinExtendedA { get; private set; }

        /// <summary>
        /// Bit 3: Block 0180-024F.
        /// </summary>
        public bool LatinExtendedB { get; private set; }

        /// <summary>
        /// Bit 4: Block 0250-02AF.
        /// </summary>
        public bool IPAExtensions { get; private set; }

        /// <summary>
        /// Bit 5: Spacing Modifier Letters - block 02B0-02FF.
        /// </summary>
        public bool SpacingModifiers { get; private set; }

        /// <summary>
        /// Bit 6: Block 0300-036F.
        /// </summary>
        public bool CombiningDiacriticalMarks { get; private set; }

        /// <summary>
        /// Bit 7: Block 0370-03FF.
        /// </summary>
        public bool GreekAndCoptic { get; private set; }

        /// <summary>
        /// Bit 8: Block 2C80-2CFF.
        /// </summary>
        public bool Coptic { get; private set; }

        /// <summary>
        /// Bit 9: Block 0400-04FF.
        /// </summary>
        public bool Cyrillic { get; private set; }

        /// <summary>
        /// Bit 10: Block 0530-058F.
        /// </summary>
        public bool Armenian { get; private set; }

        /// <summary>
        /// Bit 11: Block 0590-05FF.
        /// </summary>
        public bool Hebrew { get; private set; }

        /// <summary>
        /// Bit 12: Block A500-A63F.
        /// </summary>
        public bool Vai { get; private set; }

        /// <summary>
        /// Bit 13: Block 0600-06FF.
        /// </summary>
        public bool Arabic { get; private set; }

        /// <summary>
        /// Bit 14: Block 07C0-07FF.
        /// </summary>
        public bool NKo { get; private set; }

        /// <summary>
        /// Bit 15: Block 0900-097F.
        /// </summary>
        public bool Devanagari { get; private set; }

        /// <summary>
        /// Bit 16: Block 0980-09FF.
        /// </summary>
        public bool Bengali { get; private set; }

        /// <summary>
        /// Bit 17: Block 0A00-0A7F.
        /// </summary>
        public bool Gurmukhi { get; private set; }

        /// <summary>
        /// Bit 18: Block 0A80-0AFF.
        /// </summary>
        public bool Gujurati { get; private set; }

        /// <summary>
        /// Bit 19: Block 0B00-0B7F.
        /// </summary>
        public bool Oriya { get; private set; }

        /// <summary>
        /// Bit 20: Block 0B80-0BFF.
        /// </summary>
        public bool Tamil { get; private set; }

        /// <summary>
        /// Bit 21: Block 0C00-0C7F.
        /// </summary>
        public bool Telugu { get; private set; }

        /// <summary>
        /// Bit 22: Block 0C80-0CFF.
        /// </summary>
        public bool Kannada { get; private set; }

        /// <summary>
        /// Bit 23: Block 0D00-0D7F.
        /// </summary>
        public bool Malayalam { get; private set; }

        /// <summary>
        /// Bit 24: Block 0E00-0E7F.
        /// </summary>
        public bool Thai { get; private set; }

        /// <summary>
        /// Bit 25: Block 0E80-0EFF.
        /// </summary>
        public bool Lao { get; private set; }

        /// <summary>
        /// Bit 26: Block 10A0-10FF.
        /// </summary>
        public bool Georgian { get; private set; }

        /// <summary>
        /// Bit 27: Block 1B00-1B7F.
        /// </summary>
        public bool Balinese { get; private set; }

        /// <summary>
        /// Bit 28: Block 1100-11FF.
        /// </summary>
        public bool HangulJamo { get; private set; }

        /// <summary>
        /// Bit 29: Block 1E00-1EFF.
        /// </summary>
        public bool LatinExtendedAdditional { get; private set; }

        /// <summary>
        /// Bit 30: Block 1F00-1FFF.
        /// </summary>
        public bool GreekExtended { get; private set; }

        /// <summary>
        /// Bit 31: Block 2000-206F.
        /// </summary>
        public bool GeneralPunctuation { get; private set; }

        /// <summary>
        /// Bit 32: Block 2070-209F.
        /// </summary>
        public bool SuperscriptsSubscripts { get; private set; }

        /// <summary>
        /// Bit 33: Block 20A0-20CF.
        /// </summary>
        public bool Currency { get; private set; }

        /// <summary>
        /// Bit 34: Combining Diacritical Marks for Symbols - block 20D0-20FF.
        /// </summary>
        public bool CombiningDiacriticalsForSymbols { get; private set; }

        /// <summary>
        /// Bit 35: Block 2100-214F.
        /// </summary>
        public bool LetterlikeSymbols { get; private set; }

        /// <summary>
        /// Bit 36: Block 2150-218F.
        /// </summary>
        public bool NumberForms { get; private set; }

        /// <summary>
        /// Bit 37: Block 2190-21FF.
        /// </summary>
        public bool Arrows { get; private set; }

        /// <summary>
        /// Bit 38: Mathematical Operators - block 2200-22FF.
        /// </summary>
        public bool MathsOperators { get; private set; }

        /// <summary>
        /// Bit 39: Block 2300-23FF.
        /// </summary>
        public bool MiscTechnical { get; private set; }

        /// <summary>
        /// Bit 40: Block 2400-243F.
        /// </summary>
        public bool ControlPictures { get; private set; }

        /// <summary>
        /// Bit 41: Block 2440-245F.
        /// </summary>
        public bool OCR { get; private set; }

        /// <summary>
        /// Bit 42: Block 2460-24FF.
        /// </summary>
        public bool EnclosedAlphanumerics { get; private set; }

        /// <summary>
        /// Bit 43: Block 2500-257F.
        /// </summary>
        public bool BoxDrawing { get; private set; }

        /// <summary>
        /// Bit 44: Block 2580-259F.
        /// </summary>
        public bool BlockElements { get; private set; }

        /// <summary>
        /// Bit 45: Block 25A0-25FF.
        /// </summary>
        public bool GeometricShapes { get; private set; }

        /// <summary>
        /// Bit 46: Block 2600-26FF.
        /// </summary>
        public bool MiscSymbols { get; private set; }

        /// <summary>
        /// Bit 47: Block 2700-27BF.
        /// </summary>
        public bool Dingbats { get; private set; }

        /// <summary>
        /// Bit 48: CJK Symbols and Punctuation - block 3000-303F.
        /// </summary>
        public bool CJKSymbols { get; private set; }

        /// <summary>
        /// Bit 49: Block 3040-309F.
        /// </summary>
        public bool Hiragana { get; private set; }

        /// <summary>
        /// Bit 50: Block 30A0-30FF.
        /// </summary>
        public bool Katakana { get; private set; }

        /// <summary>
        /// Bit 51: Block 3100-312F.
        /// </summary>
        public bool Bopomofo { get; private set; }

        /// <summary>
        /// Bit 52: Block 3130-318F.
        /// </summary>
        public bool HangulCompatibilityJamo { get; private set; }

        /// <summary>
        /// Bit 53: Phags-pa - block A840-A87F.
        /// </summary>
        public bool PhagsPa { get; private set; }

        /// <summary>
        /// Bit 54: Enclosed CJK Letters and Months - block 3200-32FF.
        /// </summary>
        public bool EnclosedCJKLetters { get; private set; }

        /// <summary>
        /// Bit 55: Block 3300-33FF.
        /// </summary>
        public bool CJKCompatibility { get; private set; }

        /// <summary>
        /// Bit 56: Block AC00-D7AF.
        /// </summary>
        public bool HangulSyllables { get; private set; }

        /// <summary>
        /// Bit 57: Font provides at least one character in the range 10000-10FFFF.  A number of other bits imply this bit must be set.
        /// </summary>
        public bool NonPlane0 { get; private set; }

        /// <summary>
        /// Bit 58: Block 10900-1091F
        /// </summary>
        public bool Phoenician { get; private set; }

        /// <summary>
        /// Bit 59: Block 4E00-9FFF.
        /// </summary>
        public bool CJKUnifiedIdeographs { get; private set; }

        /// <summary>
        /// Bit 60: Plane 0 Private Use Area - block E000-F8FF.
        /// </summary>
        public bool PrivateUseArea0 { get; private set; }

        /// <summary>
        /// Bit 61: Block 31C0-31EF (note out of order).
        /// </summary>
        public bool CJKStrokes { get; private set; }

        /// <summary>
        /// Bit 62: Block FB00-FB4F.
        /// </summary>
        public bool AlphabeticPresentationForms { get; private set; }

        /// <summary>
        /// Bit 63: Block FB50-FDFF.
        /// </summary>
        public bool ArabicPresentationFormsA { get; private set; }

        /// <summary>
        /// Bit 64: Block FE20-FE2F.
        /// </summary>
        public bool CombiningHalfMarks { get; private set; }

        /// <summary>
        /// Bit 65: Block FE10-FE1F.
        /// </summary>
        public bool VerticalForms { get; private set; }

        /// <summary>
        /// Bit 66: Block FE50-FE6F.
        /// </summary>
        public bool SmallFormVariants { get; private set; }

        /// <summary>
        /// Bit 67: Block FE70-FEFF.
        /// </summary>
        public bool ArabicPresentationFormsB { get; private set; }

        /// <summary>
        /// Bit 68: Halfwidth And Fullwidth Forms - block FF00-FFEF.
        /// </summary>
        public bool HalfAndFullWidthForms { get; private set; }

        /// <summary>
        /// Bit 69: Block FFF0-FFFF.
        /// </summary>
        public bool Specials { get; private set; }

        /// <summary>
        /// Bit 70: Block 0F00-0FFF.
        /// </summary>
        public bool Tibetan { get; private set; }

        /// <summary>
        /// Bit 71: Block 0700-074F.
        /// </summary>
        public bool Syriac { get; private set; }

        /// <summary>
        /// Bit 72: Block 0780-07BF.
        /// </summary>
        public bool Thaana { get; private set; }

        /// <summary>
        /// Bit 73: Block 0D80-0DFF.
        /// </summary>
        public bool Sinhala { get; private set; }

        /// <summary>
        /// Bit 74: Block 1000-109F.
        /// </summary>
        public bool Myanmar { get; private set; }

        /// <summary>
        /// Bit 75: Block 1200-137F.
        /// </summary>
        public bool Ethiopic { get; private set; }

        /// <summary>
        /// Bit 76: Block 13A0-13FF.
        /// </summary>
        public bool Cherokee { get; private set; }

        /// <summary>
        /// Bit 77: Block 1400-167F.
        /// </summary>
        public bool UnifiedCanadianAboriginalSyllabics { get; private set; }

        /// <summary>
        /// Bit 78: Block 1680-169F.
        /// </summary>
        public bool Ogham { get; private set; }

        /// <summary>
        /// Bit 79: Block 16A0-16FF.
        /// </summary>
        public bool Runic { get; private set; }

        /// <summary>
        /// Bit 80: Block 1780-17FF.  Does not include Khmer Symbols.
        /// </summary>
        public bool Khmer { get; private set; }

        /// <summary>
        /// Bit 81: Block 1800-18AF.
        /// </summary>
        public bool Mongolian { get; private set; }

        /// <summary>
        /// Bit 82: Braille Patterns - block 2800-28FF.
        /// </summary>
        public bool Braille { get; private set; }

        /// <summary>
        /// Bit 83: Block A000-A48F.
        /// </summary>
        public bool YiSyllables { get; private set; }

        /// <summary>
        /// Bit 84: Block 1700-171F.
        /// </summary>
        public bool Tagalog { get; private set; }

        /// <summary>
        /// Bit 85: Block 10300-1032F.
        /// </summary>
        public bool OldItalic { get; private set; }

        /// <summary>
        /// Bit 86: Block 10330-1034F.
        /// </summary>
        public bool Gothic { get; private set; }

        /// <summary>
        /// Bit 87: Block 10400-1044F.
        /// </summary>
        public bool Deseret { get; private set; }

        /// <summary>
        /// Bit 88: Byzantine Musical Symbols - block 1D000-1D0FF.  Don't ask why this block is included but "Musical Symbols" isn't.
        /// </summary>
        public bool ByzantineMusic { get; private set; }

        /// <summary>
        /// Bit 89: Block 1D400-1D7FF.
        /// </summary>
        public bool MathsAlphanumericalSymbols { get; private set; }

        /// <summary>
        /// Bit 90: Plane 15 Private Use - block F0000-FFFFD.
        /// </summary>
        public bool PrivatePlane15 { get; private set; }

        /// <summary>
        /// Bit 91: Block FE00-FE0F.
        /// </summary>
        public bool VariationSelectors { get; private set; }

        /// <summary>
        /// Bit 92: Block E0000-E007F.
        /// </summary>
        public bool Tags { get; private set; }

        /// <summary>
        /// Bit 93: Block 1900-194F.
        /// </summary>
        public bool Limbu { get; private set; }

        /// <summary>
        /// Bit 94: Block 1950-197F.
        /// </summary>
        public bool TaiLe { get; private set; }

        /// <summary>
        /// Bit 95: Block 1980-19DF.
        /// </summary>
        public bool NewTaiLue { get; private set; }

        /// <summary>
        /// Bit 96: Block 1A00-1A1F.
        /// </summary>
        public bool Buginese { get; private set; }

        /// <summary>
        /// Bit 97: Block 2C00-2C5F.
        /// </summary>
        public bool Glagolitic { get; private set; }

        /// <summary>
        /// Bit 98: Block 2D30-2D7F.
        /// </summary>
        public bool Tifinagh { get; private set; }

        /// <summary>
        /// Bit 99: Block 4DC0-4DFF.
        /// </summary>
        public bool YijingHexagrams { get; private set; }

        /// <summary>
        /// Bit 100: Block A800-A82F.
        /// </summary>
        public bool SylotiNagri { get; private set; }

        /// <summary>
        /// Bit 101: Block 10000-1007F.  Linear B ideograms not included.
        /// </summary>
        public bool LinearBSyllables { get; private set; }

        /// <summary>
        /// Bit 102: Block 10140-1018F.
        /// </summary>
        public bool AncientGreekNumbers { get; private set; }

        /// <summary>
        /// Bit 103: Block 10380-1039F.
        /// </summary>
        public bool Ugaritic { get; private set; }

        /// <summary>
        /// Bit 104: Block 103A0-103DF.
        /// </summary>
        public bool OldPersian { get; private set; }

        /// <summary>
        /// Bit 105: Block 10450-1047F.
        /// </summary>
        public bool Shavian { get; private set; }

        /// <summary>
        /// Bit 106: Block 10480-104AF.
        /// </summary>
        public bool Osmanya { get; private set; }

        /// <summary>
        /// Bit 107: Block 10800-1083F.
        /// </summary>
        public bool CypriotSyllables { get; private set; }

        /// <summary>
        /// Bit 108: Block 10A00-10A5F.
        /// </summary>
        public bool Kharoshthi { get; private set; }

        /// <summary>
        /// Bit 109: Block 1D300-1D35F.
        /// </summary>
        public bool TaiXuanJingSymbols { get; private set; }

        /// <summary>
        /// Bit 110: Block 12000-123FF.  Does not include numbers and punctuation.
        /// </summary>
        public bool Cuneiform { get; private set; }

        /// <summary>
        /// Bit 111: Block 1D360-1D37F.
        /// </summary>
        public bool CountingRodNumbers { get; private set; }

        /// <summary>
        /// Bit 112: Block 1B80-1BBF.
        /// </summary>
        public bool Sundanese { get; private set; }

        /// <summary>
        /// Bit 113: Block 1C00-1C4F.
        /// </summary>
        public bool Lepcha { get; private set; }

        /// <summary>
        /// Bit 114: Block 1C50-1C7F.
        /// </summary>
        public bool OlChiki { get; private set; }

        /// <summary>
        /// Bit 115: Block A880-A8DF.
        /// </summary>
        public bool Saurashtra { get; private set; }

        /// <summary>
        /// Bit 116: Block A900-A92F.
        /// </summary>
        public bool KayahLi { get; private set; }

        /// <summary>
        /// Bit 117: Block A930-A95F.
        /// </summary>
        public bool Rejang { get; private set; }

        /// <summary>
        /// Bit 118: Block AA00-AA5F.
        /// </summary>
        public bool Cham { get; private set; }

        /// <summary>
        /// Bit 119: Block 10190-101CF.
        /// </summary>
        public bool AncientSymbols { get; private set; }

        /// <summary>
        /// Bit 120: Block 101D0-101FF.
        /// </summary>
        public bool PhaistosDisc { get; private set; }

        /// <summary>
        /// Bit 121: Block 102A0-102DF.
        /// </summary>
        public bool Carian { get; private set; }

        /// <summary>
        /// Bit 122: Domino Tiles - block 1F030-1F09F.
        /// </summary>
        public bool Dominos { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        protected UnicodeRanges() { }

        /// <summary>
        /// Returns an array of methods which set the properties of this instance.
        /// </summary>
        protected override Action<bool[]>[] SetterMethods() => new Action<bool[]>[]
        {
            SetByte0, SetByte1, SetByte2, SetByte3, SetByte4, SetByte5, SetByte6, SetByte7,
            SetByte8, SetByte9, SetByte10, SetByte11, SetByte12, SetByte13, SetByte14, SetByte15,
        };


        /// <summary>
        /// Create a <see cref="UnicodeRanges" /> object from an array of at least 16 bytes, as stored in a font.
        /// </summary>
        /// <param name="data">The data to create the object from.</param>
        /// <param name="offset">The index of the first byte of the block of 16 bytes from which the object should be constructed.</param>
        /// <returns>A <see cref="UnicodeRanges" /> object with properties as encoded in the <c>data</c>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <c>data</c> parameter is <c>null</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the <c>offset</c> parameter is less than 0 or is not an valid index to a block of 16 bytes within 
        ///   the <c>data</c> array</exception>
        public static UnicodeRanges FromBytes(byte[] data, int offset)
        {
            UnicodeRanges output = new UnicodeRanges();
            output.PopulateFromBytes(data, offset);
            return output;
        }

        private void SetByte0(bool[] b)
        {
            Thai = b[0];
            Lao = b[1];
            Georgian = b[2];
            Balinese = b[3];
            HangulJamo = b[4];
            LatinExtendedAdditional = b[5];
            GreekExtended = b[6];
            GeneralPunctuation = b[7];
        }

        private void SetByte1(bool[] b)
        {
            Bengali = b[0];
            Gurmukhi = b[1];
            Gujurati = b[2];
            Oriya = b[3];
            Tamil = b[4];
            Telugu = b[5];
            Kannada = b[6];
            Malayalam = b[7];
        }

        private void SetByte2(bool[] b)
        {
            Coptic = b[0];
            Cyrillic = b[1];
            Armenian = b[2];
            Hebrew = b[3];
            Vai = b[4];
            Arabic = b[5];
            NKo = b[6];
            Devanagari = b[7];
        }

        private void SetByte3(bool[] b)
        {
            BasicLatin = b[0];
            Latin1Supplement = b[1];
            LatinExtendedA = b[2];
            LatinExtendedB = b[3];
            IPAExtensions = b[4];
            SpacingModifiers = b[5];
            CombiningDiacriticalMarks = b[6];
            GreekAndCoptic = b[7];
        }

        private void SetByte4(bool[] b)
        {
            HangulSyllables = b[0];
            NonPlane0 = b[1];
            Phoenician = b[2];
            CJKUnifiedIdeographs = b[3];
            PrivateUseArea0 = b[4];
            CJKStrokes = b[5];
            AlphabeticPresentationForms = b[6];
            ArabicPresentationFormsA = b[7];
        }

        private void SetByte5(bool[] b)
        {
            CJKSymbols = b[0];
            Hiragana = b[1];
            Katakana = b[2];
            Bopomofo = b[3];
            HangulCompatibilityJamo = b[4];
            PhagsPa = b[5];
            EnclosedCJKLetters = b[6];
            CJKCompatibility = b[7];
        }

        private void SetByte6(bool[] b)
        {
            ControlPictures = b[0];
            OCR = b[1];
            EnclosedAlphanumerics = b[2];
            BoxDrawing = b[3];
            BlockElements = b[4];
            GeometricShapes = b[5];
            MiscSymbols = b[6];
            Dingbats = b[7];
        }

        private void SetByte7(bool[] b)
        {
            SuperscriptsSubscripts = b[0];
            Currency = b[1];
            CombiningDiacriticalsForSymbols = b[2];
            LetterlikeSymbols = b[3];
            NumberForms = b[4];
            Arrows = b[5];
            MathsOperators = b[6];
            MiscTechnical = b[7];
        }

        private void SetByte8(bool[] b)
        {
            ByzantineMusic = b[0];
            MathsAlphanumericalSymbols = b[1];
            PrivatePlane15 = b[2];
            VariationSelectors = b[3];
            Tags = b[4];
            Limbu = b[5];
            TaiLe = b[6];
            NewTaiLue = b[7];
        }

        private void SetByte9(bool[] b)
        {
            Khmer = b[0];
            Mongolian = b[1];
            Braille = b[2];
            YiSyllables = b[3];
            Tagalog = b[4];
            OldItalic = b[5];
            Gothic = b[6];
            Deseret = b[7];
        }

        private void SetByte10(bool[] b)
        {
            Thaana = b[0];
            Sinhala = b[1];
            Myanmar = b[2];
            Ethiopic = b[3];
            Cherokee = b[4];
            UnifiedCanadianAboriginalSyllabics = b[5];
            Ogham = b[6];
            Runic = b[7];
        }

        private void SetByte11(bool[] b)
        {
            CombiningHalfMarks = b[0];
            VerticalForms = b[1];
            SmallFormVariants = b[2];
            ArabicPresentationFormsB = b[3];
            HalfAndFullWidthForms = b[4];
            Specials = b[5];
            Tibetan = b[6];
            Syriac = b[7];
        }

        private void SetByte12(bool[] b)
        {
            PhaistosDisc = b[0];
            Carian = b[1];
            Dominos = b[2];
        }

        private void SetByte13(bool[] b)
        {
            Sundanese = b[0];
            Lepcha = b[1];
            OlChiki = b[2];
            Saurashtra = b[3];
            KayahLi = b[4];
            Rejang = b[5];
            Cham = b[6];
            AncientSymbols = b[7];
        }

        private void SetByte14(bool[] b)
        {
            OldPersian = b[0];
            Shavian = b[1];
            Osmanya = b[2];
            CypriotSyllables = b[3];
            Kharoshthi = b[4];
            TaiXuanJingSymbols = b[5];
            Cuneiform = b[6];
            CountingRodNumbers = b[7];
        }

        private void SetByte15(bool[] b)
        {
            Buginese = b[0];
            Glagolitic = b[1];
            Tifinagh = b[2];
            YijingHexagrams = b[3];
            SylotiNagri = b[4];
            LinearBSyllables = b[5];
            AncientGreekNumbers = b[6];
            Ugaritic = b[7];
        }

        /// <summary>
        /// The properties used by <see cref="LargeBitfield.ToString" /> to generate a string representation of this instance.
        /// </summary>
        /// <returns>An array of property names.</returns>
        protected override IEnumerable<string> StringificationProperties() => new[]
        {
            nameof(BasicLatin), nameof(Latin1Supplement), nameof(LatinExtendedA), nameof(LatinExtendedB), nameof(IPAExtensions), nameof(SpacingModifiers),
            nameof(CombiningDiacriticalMarks), nameof(GreekAndCoptic), nameof(Coptic), nameof(Cyrillic), nameof(Armenian), nameof(Hebrew), nameof(Vai), nameof(Arabic), 
            nameof(NKo), nameof(Devanagari), nameof(Bengali), nameof(Gurmukhi), nameof(Gujurati), nameof(Oriya), nameof(Tamil), nameof(Telugu), nameof(Kannada), 
            nameof(Malayalam), nameof(Thai), nameof(Lao), nameof(Georgian), nameof(Balinese), nameof(HangulJamo), nameof(LatinExtendedAdditional), nameof(GreekExtended), 
            nameof(GeneralPunctuation), nameof(SuperscriptsSubscripts), nameof(Currency), nameof(CombiningDiacriticalsForSymbols), nameof(LetterlikeSymbols), 
            nameof(NumberForms), nameof(Arrows), nameof(MathsOperators), nameof(MiscTechnical), nameof(ControlPictures), nameof(OCR), nameof(EnclosedAlphanumerics), 
            nameof(BoxDrawing), nameof(BlockElements), nameof(GeometricShapes), nameof(MiscSymbols), nameof(Dingbats), nameof(CJKSymbols), nameof(Hiragana), 
            nameof(Katakana), nameof(Bopomofo), nameof(HangulCompatibilityJamo), nameof(PhagsPa), nameof(EnclosedCJKLetters), nameof(CJKCompatibility), 
            nameof(HangulSyllables), nameof(NonPlane0), nameof(Phoenician), nameof(CJKUnifiedIdeographs), nameof(PrivateUseArea0), nameof(CJKStrokes), 
            nameof(AlphabeticPresentationForms), nameof(ArabicPresentationFormsA), nameof(CombiningHalfMarks), nameof(VerticalForms), nameof(SmallFormVariants), 
            nameof(ArabicPresentationFormsB), nameof(HalfAndFullWidthForms), nameof(Specials), nameof(Tibetan), nameof(Syriac), nameof(Thaana), nameof(Sinhala), 
            nameof(Myanmar), nameof(Ethiopic), nameof(Cherokee), nameof(UnifiedCanadianAboriginalSyllabics), nameof(Ogham), nameof(Runic), nameof(Khmer), 
            nameof(Mongolian), nameof(Braille), nameof(YiSyllables), nameof(Tagalog), nameof(OldItalic), nameof(Gothic), nameof(Deseret), nameof(ByzantineMusic), 
            nameof(MathsAlphanumericalSymbols), nameof(PrivatePlane15), nameof(VariationSelectors), nameof(Tags), nameof(Limbu), nameof(TaiLe), nameof(NewTaiLue), 
            nameof(Buginese), nameof(Glagolitic), nameof(Tifinagh), nameof(YijingHexagrams), nameof(SylotiNagri), nameof(LinearBSyllables), nameof(AncientGreekNumbers), 
            nameof(Ugaritic), nameof(OldPersian), nameof(Shavian), nameof(Osmanya), nameof(CypriotSyllables), nameof(Kharoshthi), nameof(TaiXuanJingSymbols), 
            nameof(Cuneiform), nameof(CountingRodNumbers), nameof(Sundanese), nameof(Lepcha), nameof(OlChiki), nameof(Saurashtra), nameof(KayahLi), nameof(Rejang), 
            nameof(Cham), nameof(AncientSymbols), nameof(PhaistosDisc), nameof(Carian), nameof(Dominos),
        };
    }
}
