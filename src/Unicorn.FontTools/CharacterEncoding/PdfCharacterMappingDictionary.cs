using System;
using System.Collections;
using System.Collections.Generic;

namespace Unicorn.FontTools.CharacterEncoding
{
    /// <summary>
    /// Character mappings used by PDF files when handling non-CID TrueType fonts.
    /// </summary>
    /// <remarks>
    /// When a PDF consumes a non-CID TrueType font, the text to display in that font must use one of two single-byte extended ASCII encodings which are defined in the 
    /// PDF standard with the names <c>/WinAnsiEncoding</c> and <c>/MacRomanEncding</c>.  If the font contains a "Windows Unicode" character mapping subtable, a PDF 
    /// reader should use these encodings in combination with the Adobe Glyph List - https://github.com/adobe-type-tools/agl-aglfn/ - to map the strings of text in the 
    /// PDF file to Unicode codepoints, and use those codepoints for glyph selection.
    /// 
    /// If the font does not contain a "Windows Unicode" character mapping subtable, but does contain a "Macintosh Roman" character mapping subtable, the PDF reader
    /// should use that table directly for glyph selection if the PDF file uses the <c>/MacRomanEncoding</c>.  If the PDF file uses the <c>/WinAnsiEncoding</c>
    /// the reader should map directly from that encoding to <c>MacRomanEncoding</c> and then use the "Macintosh Roman" subtable directly.  However, Unicorn does not
    /// currently support doing this.  At present the mappings given in this class map directly from the PDF encoding to Unicode, so can only be used with fonts
    /// containing a "Windows Unicode" character mapping subtable.
    /// </remarks>
    public class PdfCharacterMappingDictionary : IReadOnlyDictionary<byte, int>
    {
        /// <summary>
        /// Which type of encoding this character mapping dictionary caters for. 
        /// </summary>
        public enum DataSet
        {
            /// <summary>
            /// The "Windows ANSI" encoding, which is essentially as per code page 1252.
            /// </summary>
            WinAnsiEncoding,

            /// <summary>
            /// The "Macintosh Roman" encoding.
            /// </summary>
            MacRomanEncoding,
        };

        private static readonly Lazy<PdfCharacterMappingDictionary> _winEncoding = 
            new Lazy<PdfCharacterMappingDictionary>(() => new PdfCharacterMappingDictionary(DataSet.WinAnsiEncoding));
        private static readonly Lazy<PdfCharacterMappingDictionary> _macEncoding = 
            new Lazy<PdfCharacterMappingDictionary>(() => new PdfCharacterMappingDictionary(DataSet.MacRomanEncoding));

        /// <summary>
        /// The instance of this class for the PDF <c>/WinAnsiEncding</c>.
        /// </summary>
        public static PdfCharacterMappingDictionary WinAnsiEncoding => _winEncoding.Value;

        /// <summary>
        /// The instance of this class for the PDF <c>/MacRomanEncoding</c>.
        /// </summary>
        public static PdfCharacterMappingDictionary MacRomanEncoding => _macEncoding.Value;

        private readonly Dictionary<byte, int> _conts = new Dictionary<byte, int>();

#pragma warning disable CA1043 // Use Integral Or String Argument For Indexers

        /// <summary>
        /// Get the target codepoint for a given byte.
        /// </summary>
        /// <param name="key">The byte to look up.</param>
        /// <returns>The codepoint mapped to by the given byte.</returns>
        /// <exception cref="KeyNotFoundException">There is no mapping for the given byte.</exception>
        public int this[byte key] => _conts[key];

#pragma warning restore CA1043 // Use Integral Or String Argument For Indexers

        /// <summary>
        /// Get all of the bytes that have a mapping.
        /// </summary>
        public IEnumerable<byte> Keys => _conts.Keys;

        /// <summary>
        /// Get all of the target codepoints that are mapped to.
        /// </summary>
        public IEnumerable<int> Values => _conts.Values;

        /// <summary>
        /// Get the size of the mapping.
        /// </summary>
        public int Count => _conts.Count;

        /// <summary>
        /// Determine whether or not a given byte is mapped.
        /// </summary>
        /// <param name="key">The byte to be mapped.</param>
        /// <returns><c>true</c> if a mapping exists for the given byte, <c>false</c> if not.</returns>
        public bool ContainsKey(byte key) => _conts.ContainsKey(key);

        /// <summary>
        /// Get an enumerator for this mapping.
        /// </summary>
        /// <returns>An enumerator over the key-value pairs that make up the mapping.</returns>
        public IEnumerator<KeyValuePair<byte, int>> GetEnumerator() => _conts.GetEnumerator();

        /// <summary>
        /// Safely map a byte.
        /// </summary>
        /// <param name="key">The byte to be mapped.</param>
        /// <param name="value">The variable into which to place the mapped codepoint.</param>
        /// <returns><c>true</c> if the byte could be mapped successfully, <c>false</c> if not.</returns>
        public bool TryGetValue(byte key, out int value)
        {
            return _conts.TryGetValue(key, out value);
        }

        /// <summary>
        /// Safely map a byte, returning zero if no mapping is available.
        /// </summary>
        /// <param name="b">The byte to be mapped.</param>
        /// <returns>The codepoint that the parameter maps to, or zero if there is no mapping for the given byte.</returns>
        public int Transform(byte b)
        {
            if (_conts.TryGetValue(b, out int v))
            {
                return v;
            }
            return 0;
        }

        IEnumerator IEnumerable.GetEnumerator() => _conts.GetEnumerator();

        internal PdfCharacterMappingDictionary(DataSet set)
        {
            switch (set)
            {
                case DataSet.WinAnsiEncoding:
                default:
                    InitialiseWindowsData();
                    break;
                case DataSet.MacRomanEncoding:
                    InitialiseMacData();
                    break;
            }
        }

        private void InitialiseWindowsData()
        {
            _conts.Add(32 /* 040 */, 0x20);
            _conts.Add(33 /* 041 */, 0x21);
            _conts.Add(34 /* 042 */, 0x22);
            _conts.Add(35 /* 043 */, 0x23);
            _conts.Add(36 /* 044 */, 0x24);
            _conts.Add(37 /* 045 */, 0x25);
            _conts.Add(38 /* 046 */, 0x26);
            _conts.Add(39 /* 047 */, 0x27);
            _conts.Add(40 /* 050 */, 0x28);
            _conts.Add(41 /* 051 */, 0x29);
            _conts.Add(42 /* 052 */, 0x2a);
            _conts.Add(43 /* 053 */, 0x2b);
            _conts.Add(44 /* 054 */, 0x2c);
            _conts.Add(45 /* 055 */, 0x2d);
            _conts.Add(46 /* 056 */, 0x2e);
            _conts.Add(47 /* 057 */, 0x2f);
            _conts.Add(48 /* 060 */, 0x30);
            _conts.Add(49 /* 061 */, 0x31);
            _conts.Add(50 /* 062 */, 0x32);
            _conts.Add(51 /* 063 */, 0x33);
            _conts.Add(52 /* 064 */, 0x34);
            _conts.Add(53 /* 065 */, 0x35);
            _conts.Add(54 /* 066 */, 0x36);
            _conts.Add(55 /* 067 */, 0x37);
            _conts.Add(56 /* 070 */, 0x38);
            _conts.Add(57 /* 071 */, 0x39);
            _conts.Add(58 /* 072 */, 0x3a);
            _conts.Add(59 /* 073 */, 0x3b);
            _conts.Add(60 /* 074 */, 0x3c);
            _conts.Add(61 /* 075 */, 0x3d);
            _conts.Add(62 /* 076 */, 0x3e);
            _conts.Add(63 /* 077 */, 0x3f);
            _conts.Add(64 /* 100 */, 0x40);
            _conts.Add(65 /* 101 */, 0x41);
            _conts.Add(66 /* 102 */, 0x42);
            _conts.Add(67 /* 103 */, 0x43);
            _conts.Add(68 /* 104 */, 0x44);
            _conts.Add(69 /* 105 */, 0x45);
            _conts.Add(70 /* 106 */, 0x46);
            _conts.Add(71 /* 107 */, 0x47);
            _conts.Add(72 /* 110 */, 0x48);
            _conts.Add(73 /* 111 */, 0x49);
            _conts.Add(74 /* 112 */, 0x4a);
            _conts.Add(75 /* 113 */, 0x4b);
            _conts.Add(76 /* 114 */, 0x4c);
            _conts.Add(77 /* 115 */, 0x4d);
            _conts.Add(78 /* 116 */, 0x4e);
            _conts.Add(79 /* 117 */, 0x4f);
            _conts.Add(80 /* 120 */, 0x50);
            _conts.Add(81 /* 121 */, 0x51);
            _conts.Add(82 /* 122 */, 0x52);
            _conts.Add(83 /* 123 */, 0x53);
            _conts.Add(84 /* 124 */, 0x54);
            _conts.Add(85 /* 125 */, 0x55);
            _conts.Add(86 /* 126 */, 0x56);
            _conts.Add(87 /* 127 */, 0x57);
            _conts.Add(88 /* 130 */, 0x58);
            _conts.Add(89 /* 131 */, 0x59);
            _conts.Add(90 /* 132 */, 0x5a);
            _conts.Add(91 /* 133 */, 0x5b);
            _conts.Add(92 /* 134 */, 0x5c);
            _conts.Add(93 /* 135 */, 0x5d);
            _conts.Add(94 /* 136 */, 0x5e);
            _conts.Add(95 /* 137 */, 0x5f);
            _conts.Add(96 /* 140 */, 0x60);
            _conts.Add(97 /* 141 */, 0x61);
            _conts.Add(98 /* 142 */, 0x62);
            _conts.Add(99 /* 143 */, 0x63);
            _conts.Add(100 /* 144 */, 0x64);
            _conts.Add(101 /* 145 */, 0x65);
            _conts.Add(102 /* 146 */, 0x66);
            _conts.Add(103 /* 147 */, 0x67);
            _conts.Add(104 /* 150 */, 0x68);
            _conts.Add(105 /* 151 */, 0x69);
            _conts.Add(106 /* 152 */, 0x6a);
            _conts.Add(107 /* 153 */, 0x6b);
            _conts.Add(108 /* 154 */, 0x6c);
            _conts.Add(109 /* 155 */, 0x6d);
            _conts.Add(110 /* 156 */, 0x6e);
            _conts.Add(111 /* 157 */, 0x6f);
            _conts.Add(112 /* 160 */, 0x70);
            _conts.Add(113 /* 161 */, 0x71);
            _conts.Add(114 /* 162 */, 0x72);
            _conts.Add(115 /* 163 */, 0x73);
            _conts.Add(116 /* 164 */, 0x74);
            _conts.Add(117 /* 165 */, 0x75);
            _conts.Add(118 /* 166 */, 0x76);
            _conts.Add(119 /* 167 */, 0x77);
            _conts.Add(120 /* 170 */, 0x78);
            _conts.Add(121 /* 171 */, 0x79);
            _conts.Add(122 /* 172 */, 0x7a);
            _conts.Add(123 /* 173 */, 0x7b);
            _conts.Add(124 /* 174 */, 0x7c);
            _conts.Add(125 /* 175 */, 0x7d);
            _conts.Add(126 /* 176 */, 0x7e);
            _conts.Add(127 /* 177 */, 0x2022);
            _conts.Add(128 /* 200 */, 0x20ac);
            _conts.Add(129 /* 201 */, 0x2022);
            _conts.Add(130 /* 202 */, 0x201a);
            _conts.Add(131 /* 203 */, 0x192);
            _conts.Add(132 /* 204 */, 0x201e);
            _conts.Add(133 /* 205 */, 0x2026);
            _conts.Add(134 /* 206 */, 0x2020);
            _conts.Add(135 /* 207 */, 0x2021);
            _conts.Add(136 /* 210 */, 0x2c6);
            _conts.Add(137 /* 211 */, 0x2030);
            _conts.Add(138 /* 212 */, 0x160);
            _conts.Add(139 /* 213 */, 0x2039);
            _conts.Add(140 /* 214 */, 0x152);
            _conts.Add(141 /* 215 */, 0x2022);
            _conts.Add(142 /* 216 */, 0x17d);
            _conts.Add(143 /* 217 */, 0x2022);
            _conts.Add(144 /* 220 */, 0x2022);
            _conts.Add(145 /* 221 */, 0x2018);
            _conts.Add(146 /* 222 */, 0x2019);
            _conts.Add(147 /* 223 */, 0x201c);
            _conts.Add(148 /* 224 */, 0x201d);
            _conts.Add(149 /* 225 */, 0x2022);
            _conts.Add(150 /* 226 */, 0x2013);
            _conts.Add(151 /* 227 */, 0x2014);
            _conts.Add(152 /* 230 */, 0x2dc);
            _conts.Add(153 /* 231 */, 0x2122);
            _conts.Add(154 /* 232 */, 0x161);
            _conts.Add(155 /* 233 */, 0x203a);
            _conts.Add(156 /* 234 */, 0x153);
            _conts.Add(157 /* 235 */, 0x2022);
            _conts.Add(158 /* 236 */, 0x17e);
            _conts.Add(159 /* 237 */, 0x178);
            _conts.Add(160 /* 240 */, 0x20);
            _conts.Add(161 /* 241 */, 0xa1);
            _conts.Add(162 /* 242 */, 0xa2);
            _conts.Add(163 /* 243 */, 0xa3);
            _conts.Add(164 /* 244 */, 0xa4);
            _conts.Add(165 /* 245 */, 0xa5);
            _conts.Add(166 /* 246 */, 0xa6);
            _conts.Add(167 /* 247 */, 0xa7);
            _conts.Add(168 /* 250 */, 0xa8);
            _conts.Add(169 /* 251 */, 0xa9);
            _conts.Add(170 /* 252 */, 0xaa);
            _conts.Add(171 /* 253 */, 0xab);
            _conts.Add(172 /* 254 */, 0xac);
            _conts.Add(173 /* 255 */, 0x2022);
            _conts.Add(174 /* 256 */, 0xae);
            _conts.Add(175 /* 257 */, 0xaf);
            _conts.Add(176 /* 260 */, 0xb0);
            _conts.Add(177 /* 261 */, 0xb1);
            _conts.Add(178 /* 262 */, 0xb2);
            _conts.Add(179 /* 263 */, 0xb3);
            _conts.Add(180 /* 264 */, 0xb4);
            _conts.Add(181 /* 265 */, 0xb5);
            _conts.Add(182 /* 266 */, 0xb6);
            _conts.Add(183 /* 267 */, 0xb7);
            _conts.Add(184 /* 270 */, 0xb8);
            _conts.Add(185 /* 271 */, 0xb9);
            _conts.Add(186 /* 272 */, 0xba);
            _conts.Add(187 /* 273 */, 0xbb);
            _conts.Add(188 /* 274 */, 0xbc);
            _conts.Add(189 /* 275 */, 0xbd);
            _conts.Add(190 /* 276 */, 0xbe);
            _conts.Add(191 /* 277 */, 0xbf);
            _conts.Add(192 /* 300 */, 0xc0);
            _conts.Add(193 /* 301 */, 0xc1);
            _conts.Add(194 /* 302 */, 0xc2);
            _conts.Add(195 /* 303 */, 0xc3);
            _conts.Add(196 /* 304 */, 0xc4);
            _conts.Add(197 /* 305 */, 0xc5);
            _conts.Add(198 /* 306 */, 0xc6);
            _conts.Add(199 /* 307 */, 0xc7);
            _conts.Add(200 /* 310 */, 0xc8);
            _conts.Add(201 /* 311 */, 0xc9);
            _conts.Add(202 /* 312 */, 0xca);
            _conts.Add(203 /* 313 */, 0xcb);
            _conts.Add(204 /* 314 */, 0xcc);
            _conts.Add(205 /* 315 */, 0xcd);
            _conts.Add(206 /* 316 */, 0xce);
            _conts.Add(207 /* 317 */, 0xcf);
            _conts.Add(208 /* 320 */, 0xd0);
            _conts.Add(209 /* 321 */, 0xd1);
            _conts.Add(210 /* 322 */, 0xd2);
            _conts.Add(211 /* 323 */, 0xd3);
            _conts.Add(212 /* 324 */, 0xd4);
            _conts.Add(213 /* 325 */, 0xd5);
            _conts.Add(214 /* 326 */, 0xd6);
            _conts.Add(215 /* 327 */, 0xd7);
            _conts.Add(216 /* 330 */, 0xd8);
            _conts.Add(217 /* 331 */, 0xd9);
            _conts.Add(218 /* 332 */, 0xda);
            _conts.Add(219 /* 333 */, 0xdb);
            _conts.Add(220 /* 334 */, 0xdc);
            _conts.Add(221 /* 335 */, 0xdd);
            _conts.Add(222 /* 336 */, 0xde);
            _conts.Add(223 /* 337 */, 0xdf);
            _conts.Add(224 /* 340 */, 0xe0);
            _conts.Add(225 /* 341 */, 0xe1);
            _conts.Add(226 /* 342 */, 0xe2);
            _conts.Add(227 /* 343 */, 0xe3);
            _conts.Add(228 /* 344 */, 0xe4);
            _conts.Add(229 /* 345 */, 0xe5);
            _conts.Add(230 /* 346 */, 0xe6);
            _conts.Add(231 /* 347 */, 0xe7);
            _conts.Add(232 /* 350 */, 0xe8);
            _conts.Add(233 /* 351 */, 0xe9);
            _conts.Add(234 /* 352 */, 0xea);
            _conts.Add(235 /* 353 */, 0xeb);
            _conts.Add(236 /* 354 */, 0xec);
            _conts.Add(237 /* 355 */, 0xed);
            _conts.Add(238 /* 356 */, 0xee);
            _conts.Add(239 /* 357 */, 0xef);
            _conts.Add(240 /* 360 */, 0xf0);
            _conts.Add(241 /* 361 */, 0xf1);
            _conts.Add(242 /* 362 */, 0xf2);
            _conts.Add(243 /* 363 */, 0xf3);
            _conts.Add(244 /* 364 */, 0xf4);
            _conts.Add(245 /* 365 */, 0xf5);
            _conts.Add(246 /* 366 */, 0xf6);
            _conts.Add(247 /* 367 */, 0xf7);
            _conts.Add(248 /* 370 */, 0xf8);
            _conts.Add(249 /* 371 */, 0xf9);
            _conts.Add(250 /* 372 */, 0xfa);
            _conts.Add(251 /* 373 */, 0xfb);
            _conts.Add(252 /* 374 */, 0xfc);
            _conts.Add(253 /* 375 */, 0xfd);
            _conts.Add(254 /* 376 */, 0xfe);
            _conts.Add(255 /* 377 */, 0xff);
        }

        private void InitialiseMacData()
        {
            _conts.Add(32 /* 040 */, 0x20);
            _conts.Add(33 /* 041 */, 0x21);
            _conts.Add(34 /* 042 */, 0x22);
            _conts.Add(35 /* 043 */, 0x23);
            _conts.Add(36 /* 044 */, 0x24);
            _conts.Add(37 /* 045 */, 0x25);
            _conts.Add(38 /* 046 */, 0x26);
            _conts.Add(39 /* 047 */, 0x27);
            _conts.Add(40 /* 050 */, 0x28);
            _conts.Add(41 /* 051 */, 0x29);
            _conts.Add(42 /* 052 */, 0x2a);
            _conts.Add(43 /* 053 */, 0x2b);
            _conts.Add(44 /* 054 */, 0x2c);
            _conts.Add(45 /* 055 */, 0x2d);
            _conts.Add(46 /* 056 */, 0x2e);
            _conts.Add(47 /* 057 */, 0x2f);
            _conts.Add(48 /* 060 */, 0x30);
            _conts.Add(49 /* 061 */, 0x31);
            _conts.Add(50 /* 062 */, 0x32);
            _conts.Add(51 /* 063 */, 0x33);
            _conts.Add(52 /* 064 */, 0x34);
            _conts.Add(53 /* 065 */, 0x35);
            _conts.Add(54 /* 066 */, 0x36);
            _conts.Add(55 /* 067 */, 0x37);
            _conts.Add(56 /* 070 */, 0x38);
            _conts.Add(57 /* 071 */, 0x39);
            _conts.Add(58 /* 072 */, 0x3a);
            _conts.Add(59 /* 073 */, 0x3b);
            _conts.Add(60 /* 074 */, 0x3c);
            _conts.Add(61 /* 075 */, 0x3d);
            _conts.Add(62 /* 076 */, 0x3e);
            _conts.Add(63 /* 077 */, 0x3f);
            _conts.Add(64 /* 100 */, 0x40);
            _conts.Add(65 /* 101 */, 0x41);
            _conts.Add(66 /* 102 */, 0x42);
            _conts.Add(67 /* 103 */, 0x43);
            _conts.Add(68 /* 104 */, 0x44);
            _conts.Add(69 /* 105 */, 0x45);
            _conts.Add(70 /* 106 */, 0x46);
            _conts.Add(71 /* 107 */, 0x47);
            _conts.Add(72 /* 110 */, 0x48);
            _conts.Add(73 /* 111 */, 0x49);
            _conts.Add(74 /* 112 */, 0x4a);
            _conts.Add(75 /* 113 */, 0x4b);
            _conts.Add(76 /* 114 */, 0x4c);
            _conts.Add(77 /* 115 */, 0x4d);
            _conts.Add(78 /* 116 */, 0x4e);
            _conts.Add(79 /* 117 */, 0x4f);
            _conts.Add(80 /* 120 */, 0x50);
            _conts.Add(81 /* 121 */, 0x51);
            _conts.Add(82 /* 122 */, 0x52);
            _conts.Add(83 /* 123 */, 0x53);
            _conts.Add(84 /* 124 */, 0x54);
            _conts.Add(85 /* 125 */, 0x55);
            _conts.Add(86 /* 126 */, 0x56);
            _conts.Add(87 /* 127 */, 0x57);
            _conts.Add(88 /* 130 */, 0x58);
            _conts.Add(89 /* 131 */, 0x59);
            _conts.Add(90 /* 132 */, 0x5a);
            _conts.Add(91 /* 133 */, 0x5b);
            _conts.Add(92 /* 134 */, 0x5c);
            _conts.Add(93 /* 135 */, 0x5d);
            _conts.Add(94 /* 136 */, 0x5e);
            _conts.Add(95 /* 137 */, 0x5f);
            _conts.Add(96 /* 140 */, 0x60);
            _conts.Add(97 /* 141 */, 0x61);
            _conts.Add(98 /* 142 */, 0x62);
            _conts.Add(99 /* 143 */, 0x63);
            _conts.Add(100 /* 144 */, 0x64);
            _conts.Add(101 /* 145 */, 0x65);
            _conts.Add(102 /* 146 */, 0x66);
            _conts.Add(103 /* 147 */, 0x67);
            _conts.Add(104 /* 150 */, 0x68);
            _conts.Add(105 /* 151 */, 0x69);
            _conts.Add(106 /* 152 */, 0x6a);
            _conts.Add(107 /* 153 */, 0x6b);
            _conts.Add(108 /* 154 */, 0x6c);
            _conts.Add(109 /* 155 */, 0x6d);
            _conts.Add(110 /* 156 */, 0x6e);
            _conts.Add(111 /* 157 */, 0x6f);
            _conts.Add(112 /* 160 */, 0x70);
            _conts.Add(113 /* 161 */, 0x71);
            _conts.Add(114 /* 162 */, 0x72);
            _conts.Add(115 /* 163 */, 0x73);
            _conts.Add(116 /* 164 */, 0x74);
            _conts.Add(117 /* 165 */, 0x75);
            _conts.Add(118 /* 166 */, 0x76);
            _conts.Add(119 /* 167 */, 0x77);
            _conts.Add(120 /* 170 */, 0x78);
            _conts.Add(121 /* 171 */, 0x79);
            _conts.Add(122 /* 172 */, 0x7a);
            _conts.Add(123 /* 173 */, 0x7b);
            _conts.Add(124 /* 174 */, 0x7c);
            _conts.Add(125 /* 175 */, 0x7d);
            _conts.Add(126 /* 176 */, 0x7e);
            _conts.Add(128 /* 200 */, 0xc4);
            _conts.Add(129 /* 201 */, 0xc5);
            _conts.Add(130 /* 202 */, 0xc7);
            _conts.Add(131 /* 203 */, 0xc9);
            _conts.Add(132 /* 204 */, 0xd1);
            _conts.Add(133 /* 205 */, 0xd6);
            _conts.Add(134 /* 206 */, 0xdc);
            _conts.Add(135 /* 207 */, 0xe1);
            _conts.Add(136 /* 210 */, 0xe0);
            _conts.Add(137 /* 211 */, 0xe2);
            _conts.Add(138 /* 212 */, 0xe4);
            _conts.Add(139 /* 213 */, 0xe3);
            _conts.Add(140 /* 214 */, 0xe5);
            _conts.Add(141 /* 215 */, 0xe7);
            _conts.Add(142 /* 216 */, 0xe9);
            _conts.Add(143 /* 217 */, 0xe8);
            _conts.Add(144 /* 220 */, 0xea);
            _conts.Add(145 /* 221 */, 0xeb);
            _conts.Add(146 /* 222 */, 0xed);
            _conts.Add(147 /* 223 */, 0xec);
            _conts.Add(148 /* 224 */, 0xee);
            _conts.Add(149 /* 225 */, 0xef);
            _conts.Add(150 /* 226 */, 0xf1);
            _conts.Add(151 /* 227 */, 0xf3);
            _conts.Add(152 /* 230 */, 0xf2);
            _conts.Add(153 /* 231 */, 0xf4);
            _conts.Add(154 /* 232 */, 0xf6);
            _conts.Add(155 /* 233 */, 0xf5);
            _conts.Add(156 /* 234 */, 0xfa);
            _conts.Add(157 /* 235 */, 0xf9);
            _conts.Add(158 /* 236 */, 0xfb);
            _conts.Add(159 /* 237 */, 0xfc);
            _conts.Add(160 /* 240 */, 0x2020);
            _conts.Add(161 /* 241 */, 0xb0);
            _conts.Add(162 /* 242 */, 0xa2);
            _conts.Add(163 /* 243 */, 0xa3);
            _conts.Add(164 /* 244 */, 0xa7);
            _conts.Add(165 /* 245 */, 0x2022);
            _conts.Add(166 /* 246 */, 0xb6);
            _conts.Add(167 /* 247 */, 0xdf);
            _conts.Add(168 /* 250 */, 0xae);
            _conts.Add(169 /* 251 */, 0xa9);
            _conts.Add(170 /* 252 */, 0x2122);
            _conts.Add(171 /* 253 */, 0xb4);
            _conts.Add(172 /* 254 */, 0xa8);
            _conts.Add(174 /* 256 */, 0xc6);
            _conts.Add(175 /* 257 */, 0xd8);
            _conts.Add(177 /* 261 */, 0xb1);
            _conts.Add(180 /* 264 */, 0xa5);
            _conts.Add(181 /* 265 */, 0xb5);
            _conts.Add(187 /* 273 */, 0xaa);
            _conts.Add(188 /* 274 */, 0xba);
            _conts.Add(190 /* 276 */, 0xe6);
            _conts.Add(191 /* 277 */, 0xf8);
            _conts.Add(192 /* 300 */, 0xbf);
            _conts.Add(193 /* 301 */, 0xa1);
            _conts.Add(194 /* 302 */, 0xac);
            _conts.Add(196 /* 304 */, 0x192);
            _conts.Add(199 /* 307 */, 0xab);
            _conts.Add(200 /* 310 */, 0xbb);
            _conts.Add(201 /* 311 */, 0x2026);
            _conts.Add(202 /* 312 */, 0x20);
            _conts.Add(203 /* 313 */, 0xc0);
            _conts.Add(204 /* 314 */, 0xc3);
            _conts.Add(205 /* 315 */, 0xd5);
            _conts.Add(206 /* 316 */, 0x152);
            _conts.Add(207 /* 317 */, 0x153);
            _conts.Add(208 /* 320 */, 0x2013);
            _conts.Add(209 /* 321 */, 0x2014);
            _conts.Add(210 /* 322 */, 0x201c);
            _conts.Add(211 /* 323 */, 0x201d);
            _conts.Add(212 /* 324 */, 0x2018);
            _conts.Add(213 /* 325 */, 0x2019);
            _conts.Add(214 /* 326 */, 0xf7);
            _conts.Add(216 /* 330 */, 0xff);
            _conts.Add(217 /* 331 */, 0x178);
            _conts.Add(218 /* 332 */, 0x2044);
            _conts.Add(219 /* 333 */, 0xa4);
            _conts.Add(220 /* 334 */, 0x2039);
            _conts.Add(221 /* 335 */, 0x203a);
            _conts.Add(222 /* 336 */, 0xfb01);
            _conts.Add(223 /* 337 */, 0xfb02);
            _conts.Add(224 /* 340 */, 0x2021);
            _conts.Add(225 /* 341 */, 0xb7);
            _conts.Add(226 /* 342 */, 0x201a);
            _conts.Add(227 /* 343 */, 0x201e);
            _conts.Add(228 /* 344 */, 0x2030);
            _conts.Add(229 /* 345 */, 0xc2);
            _conts.Add(230 /* 346 */, 0xca);
            _conts.Add(231 /* 347 */, 0xc1);
            _conts.Add(232 /* 350 */, 0xcb);
            _conts.Add(233 /* 351 */, 0xc8);
            _conts.Add(234 /* 352 */, 0xcd);
            _conts.Add(235 /* 353 */, 0xce);
            _conts.Add(236 /* 354 */, 0xcf);
            _conts.Add(237 /* 355 */, 0xcc);
            _conts.Add(238 /* 356 */, 0xd3);
            _conts.Add(239 /* 357 */, 0xd4);
            _conts.Add(241 /* 361 */, 0xd2);
            _conts.Add(242 /* 362 */, 0xda);
            _conts.Add(243 /* 363 */, 0xdb);
            _conts.Add(244 /* 364 */, 0xd9);
            _conts.Add(245 /* 365 */, 0x131);
            _conts.Add(246 /* 366 */, 0x2c6);
            _conts.Add(247 /* 367 */, 0x2dc);
            _conts.Add(248 /* 370 */, 0xaf);
            _conts.Add(249 /* 371 */, 0x2d8);
            _conts.Add(250 /* 372 */, 0x2d9);
            _conts.Add(251 /* 373 */, 0x2da);
            _conts.Add(252 /* 374 */, 0xb8);
            _conts.Add(253 /* 375 */, 0x2dd);
            _conts.Add(254 /* 376 */, 0x2db);
            _conts.Add(255 /* 377 */, 0x2c7);
        }
    }
}
