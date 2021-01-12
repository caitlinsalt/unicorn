using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Unicorn.FontTools.OpenType.Extensions;
using Unicorn.FontTools.OpenType.Utility;

namespace Unicorn.FontTools.OpenType
{
    /// <summary>
    /// The 'post' table, containing some PostScript-relevant metrics information, and potentially the PostScript glyph names of each glyph.  If the latter is nt
    /// present, the font is assumed to contain 257 glyphs with standard indexes.
    /// </summary>
    public class PostScriptTable : Table
    {
        /// <summary>
        /// The version number of this table.  Only versions 2 and 2.5 permit non-standard glyph indexes.
        /// </summary>
        public PostScriptTableVersion Version { get; private set; }

        /// <summary>
        /// Italic angle in degrees from vertical, anticlockwise.
        /// </summary>
        public decimal ItalicAngle { get; private set; }

        /// <summary>
        /// Distance from the baseline to the top of the underline stroke, in font design units (positive above baseline, negative below).
        /// </summary>
        public short UnderlinePosition { get; private set; }

        /// <summary>
        /// Thickness of the underline stroke in font design units.
        /// </summary>
        public short UnderlineThickness { get; private set; }

        /// <summary>
        /// True if this font is monospace, false otherwise.
        /// </summary>
        public bool IsFixedPitch { get; private set; }

        /// <summary>
        /// Minimum virtual memory required if this font is downloaded as a TrueType font, if known.
        /// </summary>
        public long MinMemoryType42 { get; private set; }

        /// <summary>
        /// Maximum virtual memory required if this font is downloaded as a TrueType font, if known.
        /// </summary>
        public long MaxMemoryType42 { get; private set; }

        /// <summary>
        /// Minimum virtual memory required if this font is downloaded as a Type 1 font, if known.
        /// </summary>
        public long MinMemoryType1 { get; private set; }

        /// <summary>
        /// Maximum virtual memory required if this font is downloaded as a Type 1 font, if known.
        /// </summary>
        public long MaxMemoryType1 { get; private set; }

        private static readonly string[] _standardGlyphsByIndex = new[]
        {
            ".notdef",
            ".null",
            "nonmarkingreturn",
            "space",
            "exclam",
            "quotedbl",
            "numbersign",
            "dollar",
            "percent",
            "ampersand",
            "quotesingle",
            "parenleft",
            "parenright",
            "asterisk",
            "plus",
            "comma",
            "hyphen",
            "period",
            "slash",
            "zero", "one", "two", "three", "four", "five", "six", "seven", "eight",  "nine",
            "colon",
            "semicolon",
            "less",
            "equal",
            "greater",
            "question",
            "at",
            "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",
            "bracketleft",
            "backslash",
            "bracketright",
            "asciicircum",
            "underscore",
            "grave",
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
            "braceleft",
            "bar",
            "braceright",
            "asciitilde",
            "Adieresis",
            "Aring",
            "Ccedilla",
            "Eacute",
            "Ntilde",
            "Odieresis",
            "Udieresis",
            "aacute",
            "agrave",
            "acircumflex",
            "adieresis",
            "atilde",
            "aring",
            "ccedilla",
            "eacute",
            "egrave",
            "ecircumflex",
            "edieresis",
            "iacute",
            "igrave",
            "icircumflex",
            "idieresis",
            "ntilde",
            "oacute",
            "ograve",
            "ocircumflex",
            "odieresis",
            "otilde",
            "uacute",
            "ugrave",
            "ucircumflex",
            "udieresis",
            "dagger",
            "degree",
            "cent",
            "sterling",
            "section",
            "bullet",
            "paragraph",
            "germandbls",
            "registered",
            "copyright",
            "trademark",
            "acute",
            "dieresis",
            "notequal",
            "AE",
            "Oslash",
            "infinity",
            "plusminus",
            "lessequal",
            "greaterequal",
            "yen",
            "mu",
            "partialdiff",
            "summation",
            "product",
            "pi",
            "integral",
            "ordfeminine",
            "ordmasculine",
            "Omega",
            "ae",
            "oslash",
            "questiondown",
            "exclamdown",
            "logicalnot",
            "radical",
            "florin",
            "approxequal",
            "Delta",
            "guillemotleft",
            "guillemotright",
            "ellipsis",
            "nonbreakingspace",
            "Agrave",
            "Atilde",
            "Otilde",
            "OE",
            "oe",
            "endash",
            "emdash",
            "quotedblleft",
            "quotedblright",
            "quoteleft",
            "quoteright",
            "divide",
            "lozenge",
            "ydieresis",
            "Ydieresis",
            "fraction",
            "currency",
            "guilsinglleft",
            "guilsinglright",
            "fi",
            "fl",
            "daggerdbl",
            "periodcentered",
            "quotesinglbase",
            "quotedblbase",
            "perthousand",
            "Acircumflex",
            "Ecircumflex",
            "Aacute",
            "Edieresis",
            "Egrave",
            "Iacute",
            "Icircumflex",
            "Idieresis",
            "Igrave",
            "Oacute",
            "Ocircumflex",
            "apple",
            "Ograve",
            "Uacute",
            "Ucircumflex",
            "Ugrave",
            "dotlessi",
            "circumflex",
            "tilde",
            "macron",
            "breve",
            "dotaccent",
            "ring",
            "cedilla",
            "hungarumlaut",
            "ogonek",
            "caron",
            "Lslash",
            "lslash",
            "Scaron",
            "scaron",
            "Zcaron",
            "zcaron",
            "brokenbar",
            "Eth",
            "eth",
            "Yacute",
            "yacute",
            "Thorn",
            "thorn",
            "minus",
            "multiply",
            "onesuperior",
            "twosuperior",
            "threesuperior",
            "onehalf",
            "onequarter",
            "threequarters",
            "franc",
            "Gbreve",
            "gbreve",
            "Idotaccent",
            "Scedilla",
            "scedilla",
            "Cacute",
            "cacute",
            "Ccaron",
            "ccaron",
            "dcroat",
        };

        private static readonly IReadOnlyDictionary<string, int> _standardGlyphsByName = new Dictionary<string, int>()
        {
            { ".notdef", 0 },
            { ".null", 1 },
            { "nonmarkingreturn", 2 },
            { "space", 3 },
            { "exclam", 4 },
            { "quotedbl", 5 },
            { "numbersign", 6 },
            { "dollar", 7 },
            { "percent", 8 },
            { "ampersand", 9 },
            { "quotesingle", 10 },
            { "parenleft", 11 },
            { "parenright", 12 },
            { "asterisk", 13 },
            { "plus", 14 },
            { "comma", 15 },
            { "hyphen", 16 },
            { "period", 17 },
            { "slash", 18 },
            { "zero", 19 }, { "one", 20 }, { "two", 21 }, { "three", 22 }, { "four", 23 }, { "five", 24 }, { "six", 25 }, { "seven", 26 }, { "eight", 27 }, { "nine", 28 },
            { "colon", 29 },
            { "semicolon", 30 },
            { "less", 31 },
            { "equal", 32 },
            { "greater", 33 },
            { "question", 34 },
            { "at", 35 },
            { "A", 36 }, { "B", 37 }, { "C", 38 }, { "D", 39 }, { "E", 40 }, { "F", 41 }, { "G", 42 }, { "H", 43 }, { "I", 44 }, { "J", 45 }, { "K", 46 },
            { "L", 47 }, { "M", 48 }, { "N", 49 }, { "O", 50 }, { "P", 51 }, { "Q", 52 }, { "R", 53 }, { "S", 54 }, { "T", 55 }, { "U", 56 }, { "V", 57 },
            { "W", 58 }, { "X", 59 }, { "Y", 60 }, { "Z", 61 },
            { "bracketleft", 62 },
            { "backslash", 63 },
            { "bracketright", 64 },
            { "asciicircum", 65 },
            { "underscore", 66 },
            { "grave", 67 },
            { "a", 68 }, { "b", 69 }, { "c", 70 }, { "d", 71 }, { "e", 72 }, { "f", 73 }, { "g", 74 }, { "h", 75 }, { "i", 76 }, { "j", 77 }, { "k", 78 }, 
            { "l", 79 }, { "m", 80 }, { "n", 81 }, { "o", 82 }, { "p", 83 }, { "q", 84 }, { "r", 85 }, { "s", 86 }, { "t", 87 }, { "u", 88 }, { "v", 89 },
            { "w", 90 }, { "x", 91 }, { "y", 92 }, { "z", 93 },
            { "braceleft", 94 },
            { "bar", 95 },
            { "braceright", 96 },
            { "asciitilde", 97 },
            { "Adieresis", 98 },
            { "Aring", 99 },
            { "Ccedilla", 100 },
            { "Eacute", 101 },
            { "Ntilde", 102 },
            { "Odieresis", 103 },
            { "Udieresis", 104 },
            { "aacute", 105 },
            { "agrave", 106 },
            { "acircumflex", 107 },
            { "adieresis", 108 },
            { "atilde", 109 },
            { "aring", 110 },
            { "ccedilla", 111 },
            { "eacute", 112 },
            { "egrave", 113 },
            { "ecircumflex", 114 },
            { "edieresis", 115 },
            { "iacute",116 },
            { "igrave", 117 },
            { "icircumflex", 118 },
            { "idieresis", 119 },
            { "ntilde", 120 },
            { "oacute", 121 },
            { "ograve", 122 },
            { "ocircumflex", 123 },
            { "odieresis", 124 },
            { "otilde", 125 },
            { "uacute", 126 },
            { "ugrave", 127 },
            { "ucircumflex", 128 },
            { "udieresis", 129 },
            { "dagger", 130 },
            { "degree", 131 },
            { "cent", 132 },
            { "sterling", 133 },
            { "section", 134 },
            { "bullet", 135 },
            { "paragraph", 136 },
            { "germandbls", 137 },
            { "registered", 138 },
            { "copyright", 139 },
            { "trademark", 140 },
            { "acute", 141 },
            { "dieresis", 142 },
            { "notequal", 143 },
            { "AE", 144 },
            { "Oslash", 145 },
            { "infinity", 146 },
            { "plusminus", 147 },
            { "lessequal", 148 },
            { "greaterequal", 149 },
            { "yen", 150 },
            { "mu", 151 },
            { "partialdiff", 152 },
            { "summation", 153 },
            { "product", 154 },
            { "pi", 155 },
            { "integral", 156 },
            { "ordfeminine", 157 },
            { "ordmasculine", 158 },
            { "Omega", 159 },
            { "ae", 160 },
            { "oslash", 161 },
            { "questiondown", 162 },
            { "exclamdown", 163 },
            { "logicalnot", 164 },
            { "radical", 165 },
            { "florin", 166 },
            { "approxequal", 167 },
            { "Delta", 168 },
            { "guillemotleft", 169 },
            { "guillemotright", 170 },
            { "ellipsis", 171 },
            { "nonbreakingspace", 172 },
            { "Agrave", 173 },
            { "Atilde", 174 },
            { "Otilde", 175 },
            { "OE", 176 },
            { "oe", 177 },
            { "endash", 178 },
            { "emdash", 179 },
            { "quotedblleft", 180 },
            { "quotedblright", 181 },
            { "quoteleft", 182 },
            { "quoteright", 183 },
            { "divide", 184 },
            { "lozenge", 185 },
            { "ydieresis", 186 },
            { "Ydieresis", 187 },
            { "fraction", 188 },
            { "currency", 189 },
            { "guilsinglleft", 190 },
            { "guilsinglright", 191 },
            { "fi", 192 },
            { "fl", 193 },
            { "daggerdbl", 194 },
            { "periodcentered", 195 },
            { "quotesinglbase", 196 },
            { "quotedblbase", 197 },
            { "perthousand", 198 },
            { "Acircumflex", 199 },
            { "Ecircumflex", 200 },
            { "Aacute", 201 },
            { "Edieresis", 202 },
            { "Egrave", 203 },
            { "Iacute", 204 },
            { "Icircumflex", 205 },
            { "Idieresis", 206 },
            { "Igrave", 207 },
            { "Oacute", 208 },
            { "Ocircumflex", 209 },
            { "apple", 210 },
            { "Ograve", 211 },
            { "Uacute", 212 },
            { "Ucircumflex", 213 },
            { "Ugrave", 214 },
            { "dotlessi", 215 },
            { "circumflex", 216 },
            { "tilde", 217 },
            { "macron", 218 },
            { "breve", 219 },
            { "dotaccent", 220 },
            { "ring", 221 },
            { "cedilla", 222 },
            { "hungarumlaut", 223 },
            { "ogonek", 224 },
            { "caron", 225 },
            { "Lslash", 226 },
            { "lslash", 227 },
            { "Scaron", 228 },
            { "scaron", 229 },
            { "Zcaron", 230 },
            { "zcaron", 231 },
            { "brokenbar", 232 },
            { "Eth", 233 },
            { "eth", 234 },
            { "Yacute", 235 },
            { "yacute", 236 },
            { "Thorn", 237 },
            { "thorn", 238 },
            { "minus", 239 },
            { "multiply", 240 },
            { "onesuperior", 241 },
            { "twosuperior", 242 },
            { "threesuperior", 243 },
            { "onehalf", 244 },
            { "onequarter", 245 },
            { "threequarters", 246 },
            { "franc", 247 },
            { "Gbreve", 248 },
            { "gbreve", 249 },
            { "Idotaccent", 250 },
            { "Scedilla", 251 },
            { "scedilla", 252 },
            { "Cacute", 253 },
            { "cacute", 254 },
            { "Ccaron", 255 },
            { "ccaron", 256 },
            { "dcroat", 257 },
        };

        private readonly IDictionary<string, int> _overriddenGlyphsByName = new Dictionary<string, int>();

        /// <summary>
        /// Constructor for table versions 1, 3 and 4.
        /// </summary>
        /// <param name="version">Value for the <see cref="Version" /> property.</param>
        /// <param name="italicAngle">Value for the <see cref="ItalicAngle" /> property.</param>
        /// <param name="underlinePos">Value for the <see cref="UnderlinePosition" /> property.</param>
        /// <param name="underlineThickness">Value for the <see cref="UnderlineThickness" /> property.</param>
        /// <param name="isFixedPitch">Value for the <see cref="IsFixedPitch" /> property.</param>
        /// <param name="minMem42">Value for the <see cref="MinMemoryType42" /> property.</param>
        /// <param name="maxMem42">Value for the <see cref="MaxMemoryType42" /> property.</param>
        /// <param name="minMem1">Value for the <see cref="MinMemoryType1" /> property.</param>
        /// <param name="maxMem1">Value for the <see cref="MaxMemoryType1" /> property.</param>
        public PostScriptTable(PostScriptTableVersion version, decimal italicAngle, short underlinePos, short underlineThickness, bool isFixedPitch,
            long minMem42, long maxMem42, long minMem1, long maxMem1)
            : base("post")
        {
            FieldValidation.ValidateUIntParameter(minMem42, nameof(minMem42));
            FieldValidation.ValidateUIntParameter(maxMem42, nameof(maxMem42));
            FieldValidation.ValidateUIntParameter(minMem1, nameof(minMem1));
            FieldValidation.ValidateUIntParameter(maxMem1, nameof(maxMem1));

            Version = version;
            ItalicAngle = italicAngle;
            UnderlinePosition = underlinePos;
            UnderlineThickness = underlineThickness;
            IsFixedPitch = isFixedPitch;
            MinMemoryType42 = minMem42;
            MaxMemoryType42 = maxMem42;
            MinMemoryType1 = minMem1;
            MaxMemoryType1 = maxMem1;
        }

        /// <summary>
        /// Constructor for table versions 2 and 2.5.
        /// </summary>
        /// <param name="version"></param>
        /// <param name="italicAngle"></param>
        /// <param name="underlinePos"></param>
        /// <param name="underlineThickness"></param>
        /// <param name="isFixedPitch"></param>
        /// <param name="minMem42"></param>
        /// <param name="maxMem42"></param>
        /// <param name="minMem1"></param>
        /// <param name="maxMem1"></param>
        /// <param name="glyphNames"></param>
        public PostScriptTable(PostScriptTableVersion version, decimal italicAngle, short underlinePos, short underlineThickness, bool isFixedPitch,
            long minMem42, long maxMem42, long minMem1, long maxMem1, IEnumerable<KeyValuePair<string, int>> glyphNames)
            : this(version, italicAngle, underlinePos, underlineThickness, isFixedPitch, minMem42, maxMem42, minMem1, maxMem1)
        {
            if (glyphNames is null)
            {
                throw new ArgumentNullException(nameof(glyphNames));
            }
            try
            {
                foreach (KeyValuePair<string, int> kvp in glyphNames)
                {
                    _overriddenGlyphsByName.Add(kvp);
                }
            }
            catch (ArgumentException ex)
            {
                throw new OpenTypeFormatException(Resources.PostScriptTable_DuplicateGlyphNameError, ex);
            }
        }

        /// <summary>
        /// Return the glyph ID of the glyph with the given PostScript name if one exists, or <c>null</c> if there is no glyph with that name.
        /// </summary>
        /// <param name="glyph">The name of a glyph to return.</param>
        /// <returns>The glyph ID of the named glyph.</returns>
        public int? GetGlyphByName(string glyph)
        {
            if (Version == PostScriptTableVersion.Two || Version == PostScriptTableVersion.TwoPointFive)
            {
                if (_overriddenGlyphsByName.ContainsKey(glyph))
                {
                    return _overriddenGlyphsByName[glyph];
                }
            }
            else if (_standardGlyphsByName.ContainsKey(glyph))
            {
                return _standardGlyphsByName[glyph];
            }
            return null;
        }

        /// <summary>
        /// Dump the content of this table to a <see cref="TextWriter" />.  Ignored if the parameter is <c>null</c>.
        /// </summary>
        /// <param name="writer">The <see cref="TextWriter" /> to send output to.</param>
        public override void Dump(TextWriter writer)
        {
            if (writer is null)
            {
                return;
            }
            writer.WriteLine("post table content:");
            writer.WriteLine("Field              | Value");
            writer.WriteLine("-------------------|--------------------------");
            writer.WriteLine($"Version            | {Version}");
            writer.WriteLine($"ItalicAngle        | {ItalicAngle}");
            writer.WriteLine($"UnderlinePosition  | {UnderlinePosition}");
            writer.WriteLine($"UnderlineThickness | {UnderlineThickness}");
            writer.WriteLine($"IsFixedPitch       | {IsFixedPitch}");
            writer.WriteLine($"MinMemoryType42    | {MinMemoryType42}");
            writer.WriteLine($"MaxMemoryType42    | {MaxMemoryType42}");
            writer.WriteLine($"MinMemoryType1     | {MinMemoryType1}");
            writer.WriteLine($"MaxMemoryType1     | {MaxMemoryType1}");
            if (Version == PostScriptTableVersion.Two || Version == PostScriptTableVersion.TwoPointFive)
            {
                int longestName = _overriddenGlyphsByName.Keys.Max(n => n.Length);
                string breakline = new string('-', longestName);
                writer.WriteLine("This font uses a custom glyph name table.");
                writer.WriteLine("Name             |  Glyph");
                writer.WriteLine($"{breakline}-|-------");
                foreach (KeyValuePair<string, int> pair in _overriddenGlyphsByName.OrderBy(p => p.Value))
                {
                    writer.WriteLine($"{pair.Key.PadRight(longestName)} | {pair.Value,6}");
                }
            }
        }

        /// <summary>
        /// Load a <see cref="PostScriptTable" /> from an array of bytes.
        /// </summary>
        /// <param name="arr">The array to load data from.</param>
        /// <param name="offset">The array index at which the PostScript table data starts.</param>
        /// <param name="len">The length of the data making up the table.</param>
        /// <returns></returns>
        public static PostScriptTable FromBytes(byte[] arr, int offset, int len)
        {
            if (arr is null)
            {
                throw new ArgumentNullException(nameof(arr));
            }
            FieldValidation.ValidateNonNegativeIntegerParameter(len, nameof(len));
            int rawVersion = arr.ToInt(offset);
            decimal italicAngle = arr.ToFixed(offset + 4);
            short underlinePos = arr.ToShort(offset + 8);
            short underlineThickness = arr.ToShort(offset + 10);
            bool isFixedPitch = arr.ToUInt(offset + 12) != 0;
            uint minMem42 = arr.ToUInt(offset + 16);
            uint maxMem42 = arr.ToUInt(offset + 20);
            uint minMem1 = arr.ToUInt(offset + 24);
            uint maxMem1 = arr.ToUInt(offset + 28);
            PostScriptTableVersion version = GetTableVersion(rawVersion);
            if (version != PostScriptTableVersion.Two && version != PostScriptTableVersion.TwoPointFive)
            {
                return new PostScriptTable(version, italicAngle, underlinePos, underlineThickness, isFixedPitch, minMem42, maxMem42, minMem1, maxMem1);
            }
            long maxOffset = offset + len;
            offset += 32; 
            ushort glyphCount = arr.ToUShort(offset);
            List<KeyValuePair<string, int>> map = new List<KeyValuePair<string, int>>(glyphCount);
            if (version == PostScriptTableVersion.Two)
            {
                ushort[] nameIdx = new ushort[glyphCount];
                for (int i = 0; i < glyphCount; ++i)
                {
                    nameIdx[i] = arr.ToUShort(offset + 2 * (i + 1));
                }
                List<string> stringTbl = new List<string>();
                offset += 2 * (glyphCount + 1);
                while (offset < maxOffset)
                {
                    int strlen = arr[offset];
                    stringTbl.Add(Encoding.ASCII.GetString(arr, offset + 1, strlen));
                    offset += strlen + 1;
                }
                for (int i = 0; i < glyphCount; ++i)
                {
                    if (nameIdx[i] < 258)
                    {
                        map.Add(new KeyValuePair<string, int>(_standardGlyphsByIndex[nameIdx[i]], i));
                    }
                    else
                    {
                        map.Add(new KeyValuePair<string, int>(stringTbl[nameIdx[i] - 258], i));
                    }
                }
            }
            else
            {
                for (int i = 0; i < glyphCount; ++i)
                {
                    map.Add(new KeyValuePair<string, int>(_standardGlyphsByIndex[i + unchecked((sbyte)arr[offset + 2 + i])], i));
                }
            }
            return new PostScriptTable(version, italicAngle, underlinePos, underlineThickness, isFixedPitch, minMem42, maxMem42, minMem1, maxMem1, map);
        }

        private static PostScriptTableVersion GetTableVersion(int rawVersion)
        {
            switch (rawVersion)
            {
                case 0x10000:
                    return PostScriptTableVersion.One;
                case 0x20000:
                    return PostScriptTableVersion.Two;
                case 0x25000:
                    return PostScriptTableVersion.TwoPointFive;
                case 0x30000:
                    return PostScriptTableVersion.Three;
                case 0x40000:
                    return PostScriptTableVersion.Four;
                default:
                    throw new OpenTypeFormatException(string.Format(CultureInfo.CurrentCulture, "Unrecognised 'post' table version number {0}", rawVersion));
            }
        }
    }
}
