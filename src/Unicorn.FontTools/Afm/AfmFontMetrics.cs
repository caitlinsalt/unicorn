using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Unicorn.FontTools.Afm
{
    /// <summary>
    /// The contents of an AFM file.
    /// </summary>
    public class AfmFontMetrics
    {
        /// <summary>
        /// Name of the font.
        /// </summary>
        public string FontName { get; private set; }

        /// <summary>
        /// Name of the typeface family that the font is a member of.
        /// </summary>
        public string FamilyName { get; private set; }

        /// <summary>
        /// Full text name of the font.
        /// </summary>
        public string FullName { get; private set; }

        /// <summary>
        /// Description of the weight of the font.
        /// </summary>
        public string Weight { get; private set; }

        /// <summary>
        /// Bounding box of the font.
        /// </summary>
        public BoundingBox FontBoundingBox { get; private set; }

        /// <summary>
        /// Font version identifier text.
        /// </summary>
        public string Version { get; private set; }

        /// <summary>
        /// Font trademark or copyright notice.
        /// </summary>
        public string Notice { get; private set; }

        /// <summary>
        /// Default encoding of this font.
        /// </summary>
        public string EncodingScheme { get; private set; }

        /// <summary>
        /// Font mapping scheme code.
        /// </summary>
        public int? MappingScheme { get; private set; }

        /// <summary>
        /// Font escape character.  Required to be set if <see cref="MappingScheme" /> is equal to 3.
        /// </summary>
        public int? EscapeCharacter { get; private set; }

        /// <summary>
        /// Character set description string.
        /// </summary>
        public string CharacterSet { get; private set; }

        /// <summary>
        /// Number of characters in this font.  Not required to be set.
        /// </summary>
        public int? CharacterCount { get; private set; }

        /// <summary>
        /// Is this font a base font?
        /// </summary>
        public bool IsBaseFont { get; private set; }

        /// <summary>
        /// Vector which transforms between the origins of characters in writing direction 0 and the origins of characters in writing direction 1.
        /// </summary>
        public Vector? VVector { get; private set; }

        /// <summary>
        /// If <c>true</c>, the <see cref="VVector" /> property of this object applies to every character in the font.  If <c>false</c>, individual 
        /// <see cref="Character.VVector"/> properties apply.
        /// </summary>
        public bool? IsFixedV { get; private set; }

        /// <summary>
        /// Specifies whether or not this font is CID-keyed.
        /// </summary>
        public bool IsCIDFont { get; private set; }

        /// <summary>
        /// The Y-coordinate of the top of the 'H' character.
        /// </summary>
        public decimal? CapHeight { get; private set; }

        /// <summary>
        /// The Y-coordinate of the top of the 'x' character.
        /// </summary>
        public decimal? XHeight { get; private set; }

        /// <summary>
        /// The Y-coordinate of the top of the 'd' character.
        /// </summary>
        public decimal? Ascender { get; private set; }

        /// <summary>
        /// The Y-coordinate of the bottom of the 'p' character.
        /// </summary>
        public decimal? Descender { get; private set; }

        /// <summary>
        /// The predominant width of horizontal stems in this font.
        /// </summary>
        public decimal? StdHW { get; private set; }

        /// <summary>
        /// The predominant width of vertical stems in this font.
        /// </summary>
        public decimal? StdVW { get; private set; }

        /// <summary>
        /// Direction metrics for writing direction 0, if provided.
        /// </summary>
        public DirectionMetrics? Direction0Metrics { get; private set; }

        /// <summary>
        /// Direction metrics for writing direction 1, if provided.
        /// </summary>
        public DirectionMetrics? Direction1Metrics { get; private set; }

        /// <summary>
        /// Characters in this font, indexed by character name.
        /// </summary>
        public IDictionary<string, Character> CharactersByName { get; } = new Dictionary<string, Character>();

        /// <summary>
        /// Characters in this font, indexed by character encoding.
        /// </summary>
        public IDictionary<short, Character> CharactersByCode { get; } = new Dictionary<short, Character>();

        /// <summary>
        /// All characters in this font, in arbitrary order.
        /// </summary>
        public IList<Character> Characters { get; } = new List<Character>();

        internal AfmFontMetrics(string name, string fullName, string familyName, string weight, BoundingBox boundingBox, string version, string notice, 
            string encoding, int? mapping, int? escapeChar, string charSet, int? charCount, bool? isBaseFont, Vector? vvector, bool? isFixedVV, bool? isCid,
            decimal? capHeight, decimal? xHeight, decimal? ascender, decimal? descender, decimal? stdHw, decimal? stdVw, DirectionMetrics? direction0Metrics,
            DirectionMetrics? direction1Metrics)
        {
            FontName = name;
            FullName = fullName;
            FamilyName = familyName;
            Weight = weight;
            FontBoundingBox = boundingBox;
            Version = version;
            Notice = notice;
            EncodingScheme = encoding;
            MappingScheme = mapping;
            EscapeCharacter = escapeChar;
            CharacterSet = charSet;
            CharacterCount = charCount;
            IsBaseFont = isBaseFont ?? true;
            VVector = vvector;
            IsFixedV = isFixedVV;
            IsCIDFont = isCid ?? false;
            CapHeight = capHeight;
            XHeight = xHeight;
            Ascender = ascender;
            Descender = descender;
            StdHW = stdHw;
            StdVW = stdVw;
            Direction0Metrics = direction0Metrics;
            Direction1Metrics = direction1Metrics;
        }

        private AfmFontMetrics()
        {
            IsBaseFont = true;
        }

        /// <summary>
        /// Generate an <see cref="AfmFontMetrics" /> instance from data read in from a <see cref="TextReader" />.
        /// </summary>
        /// <param name="reader">A <see cref="TextReader" /> implementation.</param>
        /// <returns>An <see cref="AfmFontMetrics" /> instance built from data returned by the reader.</returns>
        /// <exception cref="IOException">Thrown if the <c>TextReader</c> encounters an IO problem.</exception>
        /// <exception cref="AfmFormatException">Thrown if the reader does not provide well-formed AFM data.</exception>
        public static AfmFontMetrics FromReader(TextReader reader)
        {
            if (reader is null)
            {
                throw new ArgumentNullException(nameof(reader));
            }
            return FromLines(ReadHelper(reader));
        }

        private static IEnumerable<string> ReadHelper(TextReader reader)
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
        }

        /// <summary>
        /// Generate an <see cref="AfmFontMetrics" /> instance from string data.
        /// </summary>
        /// <param name="lines">A sequence of lines to interpret as AFM data.</param>
        /// <returns>An <see cref="AfmFontMetrics" /> instance.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <c>lines</c> parameter is null.</exception>
        /// <exception cref="AfmFormatException">Thrown if the content in the parameter is not well-formed AFM data.</exception>
        public static AfmFontMetrics FromLines(IEnumerable<string> lines)
        {
            if (lines is null)
            {
                throw new ArgumentNullException(nameof(lines));
            }

            const string startKey = "StartFontMetrics";
            const string endKey = "EndFontMetrics";
            const string startDirectionMetricsKey = "StartDirection";
            const string endDirectionMetricsKey = "EndDirection";
            const string startCharMetricsKey = "StartCharMetrics";
            const string endCharMetricsKey = "EndCharMetrics";
            const string startKerningKey = "StartKernData";
            const string endKerningKey = "EndKernData";
            const string startKerningPairsKey = "StartKernPairs";
            const string endKerningPairsKey = "EndKernPairs";
            const string metricsSetsKey = "MetricsSets";
            const string fontNameKey = "FontName";
            const string fullNameKey = "FullName";
            const string familyNameKey = "FamilyName";
            const string weightKey = "Weight";
            const string boundingBoxKey = "FontBBox";
            const string versionKey = "Version";
            const string noticeKey = "Notice";
            const string encodingKey = "EncodingScheme";
            const string mappingKey = "MappingScheme";
            const string escapeCharKey = "EscChar";
            const string charsetKey = "CharacterSet";
            const string charCountKey = "Characters";
            const string isBaseFontKey = "IsBaseFont";
            const string vvectorKey = "VVector";
            const string isFixedVKey = "IsFixedV";
            const string isCidFontKey = "IsCIDFont";
            const string capHeightKey = "CapHeight";
            const string xHeightKey = "XHeight";
            const string ascenderKey = "Ascender";
            const string descenderKey = "Descender";
            const string stdHwKey = "StdHW";
            const string stdVwKey = "StdVW";
            const string directionUnderlinePosKey = "UnderlinePosition";
            const string directionUnderlineWidthKey = "UnderlineThickness";
            const string directionItalicAngleKey = "ItalicAngle";
            const string directionCharWidthKey = "CharWidth";
            const string directionFixedPitchKey = "IsFixedPitch";

            bool expectDirection0Metrics = true;
            bool expectDirection1Metrics = false;

            decimal? direction0UnderlinePos = null;
            decimal? direction0UnderlineThickness = null;
            decimal? direction0ItalicAngle = null;
            Vector? direction0CharWidth = null;
            bool? direction0IsFixedPitch = null;

            AfmFontMetrics inProgress = new AfmFontMetrics();

            IEnumerator<string> enumerator = lines.GetEnumerator();
            MoveNextHelper(enumerator);
            if (!enumerator.Current.StartsWith(startKey, StringComparison.InvariantCulture))
            {
                throw new AfmFormatException(string.Format(CultureInfo.InvariantCulture, Resources.AfmFontMetrics_FromLines_IncorrectStart, startKey));
            }
            MoveNextHelper(enumerator);
            while (!enumerator.Current.StartsWith(startDirectionMetricsKey, StringComparison.InvariantCulture) && 
                !enumerator.Current.StartsWith(startCharMetricsKey, StringComparison.InvariantCulture) && enumerator.Current != startKerningKey && 
                enumerator.Current != endKey)
            {
                if (enumerator.Current.StartsWith(metricsSetsKey, StringComparison.InvariantCulture))
                {
                    int expectedSets = LoadingHelpers.LoadKeyedInt(enumerator.Current, metricsSetsKey);
                    if (expectedSets == 2)
                    {
                        expectDirection1Metrics = true;
                    }
                    else if (expectedSets == 1)
                    {
                        expectDirection0Metrics = false;
                        expectDirection1Metrics = true;
                    }
                    else if (expectedSets < 0 || expectedSets > 2)
                    {
                        throw new AfmFormatException($"Invalid value for MetricsSets in input line {enumerator.Current}");
                    }
                }
                else if (enumerator.Current.StartsWith(fontNameKey, StringComparison.InvariantCulture))
                {
                    inProgress.FontName = LoadingHelpers.LoadKeyedString(enumerator.Current, fontNameKey);
                }
                else if (enumerator.Current.StartsWith(fullNameKey, StringComparison.InvariantCulture))
                {
                    inProgress.FullName = LoadingHelpers.LoadKeyedString(enumerator.Current, fullNameKey);
                }
                else if (enumerator.Current.StartsWith(familyNameKey, StringComparison.InvariantCulture))
                {
                    inProgress.FamilyName = LoadingHelpers.LoadKeyedString(enumerator.Current, familyNameKey);
                }
                else if (enumerator.Current.StartsWith(weightKey, StringComparison.InvariantCulture))
                {
                    inProgress.Weight = LoadingHelpers.LoadKeyedString(enumerator.Current, weightKey);
                }
                else if (enumerator.Current.StartsWith(boundingBoxKey, StringComparison.InvariantCulture))
                {
                    inProgress.FontBoundingBox = LoadingHelpers.LoadKeyedBoundingBox(enumerator.Current, boundingBoxKey);
                }
                else if (enumerator.Current.StartsWith(versionKey, StringComparison.InvariantCulture))
                {
                    inProgress.Version = LoadingHelpers.LoadKeyedString(enumerator.Current, versionKey);
                }
                else if (enumerator.Current.StartsWith(noticeKey, StringComparison.InvariantCulture))
                {
                    inProgress.Notice = LoadingHelpers.LoadKeyedString(enumerator.Current, noticeKey);
                }
                else if (enumerator.Current.StartsWith(encodingKey, StringComparison.InvariantCulture))
                {
                    inProgress.EncodingScheme = LoadingHelpers.LoadKeyedString(enumerator.Current, encodingKey);
                }
                else if (enumerator.Current.StartsWith(mappingKey, StringComparison.InvariantCulture))
                {
                    inProgress.MappingScheme = LoadingHelpers.LoadKeyedInt(enumerator.Current, mappingKey);
                }
                else if (enumerator.Current.StartsWith(escapeCharKey, StringComparison.InvariantCulture))
                {
                    inProgress.EscapeCharacter = LoadingHelpers.LoadKeyedInt(enumerator.Current, escapeCharKey);
                }
                else if (enumerator.Current.StartsWith(charsetKey, StringComparison.InvariantCulture))
                {
                    inProgress.CharacterSet = LoadingHelpers.LoadKeyedString(enumerator.Current, charsetKey);
                }
                else if (enumerator.Current.StartsWith(charCountKey, StringComparison.InvariantCulture))
                {
                    inProgress.CharacterCount = LoadingHelpers.LoadKeyedInt(enumerator.Current, charCountKey);
                }
                else if (enumerator.Current.StartsWith(isBaseFontKey, StringComparison.InvariantCulture))
                {
                    inProgress.IsBaseFont = LoadingHelpers.LoadKeyedBool(enumerator.Current, isBaseFontKey);
                }
                else if (enumerator.Current.StartsWith(vvectorKey, StringComparison.InvariantCulture))
                {
                    inProgress.VVector = LoadingHelpers.LoadKeyedVector(enumerator.Current, vvectorKey);
                }
                else if (enumerator.Current.StartsWith(isFixedVKey, StringComparison.InvariantCulture))
                {
                    inProgress.IsFixedV = LoadingHelpers.LoadKeyedBool(enumerator.Current, isFixedVKey);
                }
                else if (enumerator.Current.StartsWith(isCidFontKey, StringComparison.InvariantCulture))
                {
                    inProgress.IsCIDFont = LoadingHelpers.LoadKeyedBool(enumerator.Current, isCidFontKey);
                }
                else if (enumerator.Current.StartsWith(capHeightKey, StringComparison.InvariantCulture))
                {
                    inProgress.CapHeight = LoadingHelpers.LoadKeyedDecimal(enumerator.Current, capHeightKey);
                }
                else if (enumerator.Current.StartsWith(xHeightKey, StringComparison.InvariantCulture))
                {
                    inProgress.XHeight = LoadingHelpers.LoadKeyedDecimal(enumerator.Current, xHeightKey);
                }
                else if (enumerator.Current.StartsWith(ascenderKey, StringComparison.InvariantCulture))
                {
                    inProgress.Ascender = LoadingHelpers.LoadKeyedDecimal(enumerator.Current, ascenderKey);
                }
                else if (enumerator.Current.StartsWith(descenderKey, StringComparison.InvariantCulture))
                {
                    inProgress.Descender = LoadingHelpers.LoadKeyedDecimal(enumerator.Current, descenderKey);
                }
                else if (enumerator.Current.StartsWith(stdHwKey, StringComparison.InvariantCulture))
                {
                    inProgress.StdHW = LoadingHelpers.LoadKeyedDecimal(enumerator.Current, stdHwKey);
                }
                else if (enumerator.Current.StartsWith(stdVwKey, StringComparison.InvariantCulture))
                {
                    inProgress.StdVW = LoadingHelpers.LoadKeyedDecimal(enumerator.Current, stdVwKey);
                }
                else if (enumerator.Current.StartsWith(directionUnderlinePosKey, StringComparison.InvariantCulture))
                {
                    direction0UnderlinePos = LoadingHelpers.LoadKeyedDecimal(enumerator.Current, directionUnderlinePosKey);
                }
                else if (enumerator.Current.StartsWith(directionUnderlineWidthKey, StringComparison.InvariantCulture))
                {
                    direction0UnderlineThickness = LoadingHelpers.LoadKeyedDecimal(enumerator.Current, directionUnderlineWidthKey);
                }
                else if (enumerator.Current.StartsWith(directionItalicAngleKey, StringComparison.InvariantCulture))
                {
                    direction0ItalicAngle = LoadingHelpers.LoadKeyedDecimal(enumerator.Current, directionItalicAngleKey);
                }
                else if (enumerator.Current.StartsWith(directionCharWidthKey, StringComparison.InvariantCulture))
                {
                    direction0CharWidth = LoadingHelpers.LoadKeyedVector(enumerator.Current, directionCharWidthKey);
                }
                else if (enumerator.Current.StartsWith(directionFixedPitchKey, StringComparison.InvariantCulture))
                {
                    direction0IsFixedPitch = LoadingHelpers.LoadKeyedBool(enumerator.Current, directionFixedPitchKey);
                }
                MoveNextHelper(enumerator);
            }

            while (enumerator.Current != endKey)
            {
                while (!enumerator.Current.StartsWith(startDirectionMetricsKey, StringComparison.InvariantCulture) && 
                    !enumerator.Current.StartsWith(startCharMetricsKey, StringComparison.InvariantCulture) && enumerator.Current != startKerningKey 
                    && enumerator.Current != endKey)
                {
                    MoveNextHelper(enumerator);
                }
                if (enumerator.Current.StartsWith(startDirectionMetricsKey, StringComparison.InvariantCulture))
                {
                    int forDirection = LoadingHelpers.LoadKeyedInt(enumerator.Current, startDirectionMetricsKey);
                    if ((forDirection == 0 && !expectDirection0Metrics) || (forDirection == 1 && !expectDirection1Metrics))
                    {
                        throw new AfmFormatException($"Direction metrics found for unexpected direction {forDirection.ToString(CultureInfo.InvariantCulture)}");
                    }
                    if (forDirection < 0 || forDirection > 1)
                    {
                        throw new AfmFormatException($"Direction metrics found for unknown direction {forDirection.ToString(CultureInfo.InvariantCulture)}");
                    }
                    List<string> directionData = new List<string>();
                    MoveNextHelper(enumerator);
                    while (enumerator.Current != endDirectionMetricsKey)
                    {
                        directionData.Add(enumerator.Current);
                        MoveNextHelper(enumerator);
                    }
                    DirectionMetrics metrics = DirectionMetrics.FromLines(directionData);
                    if (forDirection == 0)
                    {
                        inProgress.Direction0Metrics = metrics;
                    }
                    else
                    {
                        inProgress.Direction1Metrics = metrics;
                    }
                    MoveNextHelper(enumerator);
                }
                else if (enumerator.Current.StartsWith(startCharMetricsKey, StringComparison.InvariantCulture))
                {
                    int charCount = LoadingHelpers.LoadKeyedInt(enumerator.Current, startCharMetricsKey);
                    for (int i = 0; i < charCount; ++i)
                    {
                        MoveNextHelper(enumerator);
                        inProgress.AddChar(Character.FromString(enumerator.Current));
                    }
                    MoveNextHelper(enumerator);
                    if (!enumerator.Current.StartsWith(endCharMetricsKey, StringComparison.InvariantCulture))
                    {
                        throw new AfmFormatException($"Unexpected data {enumerator.Current} in character metrics data");
                    }
                }
                else if (enumerator.Current == startKerningKey)
                {
                    while (!enumerator.Current.StartsWith(startKerningPairsKey, StringComparison.InvariantCulture))
                    {
                        MoveNextHelper(enumerator);
                    }
                    int kerningPairCount = LoadingHelpers.LoadKeyedInt(enumerator.Current, startKerningPairsKey);
                    for (int i = 0; i < kerningPairCount; ++i)
                    {
                        MoveNextHelper(enumerator);
                        inProgress.AddKerningPair(KerningPair.FromString(enumerator.Current, inProgress.CharactersByName, inProgress.CharactersByCode));
                    }
                    while (enumerator.Current != endKerningPairsKey)
                    {
                        MoveNextHelper(enumerator);
                    }
                    while (enumerator.Current != endKerningKey)
                    {
                        MoveNextHelper(enumerator);
                    }
                }
            }

            if (expectDirection0Metrics && !inProgress.Direction0Metrics.HasValue)
            {
                inProgress.Direction0Metrics = new DirectionMetrics(direction0UnderlinePos, direction0UnderlineThickness, direction0ItalicAngle, direction0CharWidth,
                    direction0IsFixedPitch);
            }
            inProgress.ProcessLigatures();
            return inProgress;
        }

        private static void MoveNextHelper(IEnumerator<string> enumerator)
        {
            if (!enumerator.MoveNext())
            {
                throw new AfmFormatException(Resources.AfmFontMetrics_MoveNextHelper_UnexpectedEnd);
            }
        }

        /// <summary>
        /// Measure the width of an ASCII string, in font units.
        /// </summary>
        /// <param name="str">The string to be measured.</param>
        /// <returns>The width of the string, in font units.</returns>
        public decimal MeasureStringWidth(string str)
        {
            return MeasureStringWidth(Encoding.ASCII.GetBytes(str));
        }

        /// <summary>
        /// Measures the width of a sequence of bytes that represent an encoded string, in font units.
        /// </summary>
        /// <param name="encodedString">The sequence of character codes to be measured.</param>
        /// <returns>The width of the string, in font units.</returns>
        public decimal MeasureStringWidth(IList<byte> encodedString)
        {
            return MeasureStringWidth(encodedString.Select(b => (short)b).ToArray());
        }

        /// <summary>
        /// Measures the width of a sequence of 16-bit code points that represent an encoded string, in font units.
        /// </summary>
        /// <param name="encodedString">The sequence of character codes to be measured.</param>
        /// <returns>The width of the string, in font units.</returns>
        public decimal MeasureStringWidth(IList<short> encodedString)
        {
            if (encodedString is null || encodedString.Count == 0)
            {
                return 0m;
            }
            IList<Character> characters = LigaturiseString(encodedString);
            IList<Vector> kerningAdjustments = GetKerningAdjustments(characters);
            return characters.Sum(c => c.XWidth.General.Value) + kerningAdjustments.Sum(k => k.X);
        }

        private IList<Character> LigaturiseString(IList<short> encodedString)
        {
            List<Character> output = new List<Character>(encodedString.Count);
            for (int i = 0; i < encodedString.Count; ++i)
            {
                if (!CharactersByCode.TryGetValue(encodedString[i], out Character current))
                {
                    continue;
                }
                if (i < encodedString.Count - 1 && current.Ligatures != null && current.Ligatures.Count > 0)
                {
                    LigatureSet set = current.Ligatures.FirstOrDefault(x => x.Second.Code == encodedString[i + 1]);
                    if (set != default)
                    {
                        current = set.Ligature;
                        i++;
                    }
                }
                output.Add(current);
            }
            return output;
        }

        private static IList<Vector> GetKerningAdjustments(IList<Character> characters)
        {
            List<Vector> output = new List<Vector>();
            for (int i = 1; i < characters.Count; ++i)
            {
                KerningPair kp = characters[i - 1].KerningPairs.FirstOrDefault(p => p.Second == characters[i]);
                if (kp != default)
                {
                    output.Add(kp.KerningVector);
                }
            }
            return output;
        }

        internal void AddChar(Character c)
        {
            Characters.Add(c);
            if (c.Code.HasValue)
            {
                CharactersByCode.Add(c.Code.Value, c);
            }
            if (!string.IsNullOrWhiteSpace(c.Name))
            {
                CharactersByName.Add(c.Name, c);
            }
        }

        internal void ProcessLigatures()
        {
            foreach (Character c in Characters)
            {
                c.ProcessLigatures(CharactersByName);
            }
        }

        internal void AddKerningPair(KerningPair kp)
        {
            CharactersByName[kp.First.Name].KerningPairs.Add(kp);
        }
    }
}
