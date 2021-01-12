using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Unicorn.FontTools.Afm
{
    /// <summary>
    /// A class represting an AFM character metric record.
    /// </summary>
    public class Character
    {
        /// <summary>
        /// The encoding of the character (or null if not encoded, represented by -1 in an AFM file).
        /// </summary>
        public short? Code { get; private set; }

        /// <summary>
        /// The PostScript character name (null if not present, but must be present to use the character with ligatures or kerning).
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// The widths given for the X axis.  If no widths are given then this will have the value <c>default(WidthSet)</c>.
        /// </summary>
        public WidthSet XWidth { get; private set; }

        /// <summary>
        /// The widths given for the Y axis.  If no widths are given then this will have the value <c>default(Width)</c>.
        /// </summary>
        public WidthSet YWidth { get; private set; }

        /// <summary>
        /// The character's VVector property, if given.  This describes the difference between coordinate origin points for the character for different
        /// writing directions.
        /// </summary>
        public Vector? VVector { get; private set; }

        /// <summary>
        /// The character bounding box, or <c>null</c> if not given.
        /// </summary>
        public BoundingBox? BoundingBox { get; private set; }

        /// <summary>
        /// Ligatures in which this character is the first of the pair of source characters.  Not populated unless 
        /// <see cref="Character.ProcessLigatures(IDictionary{string, Character})" /> has been called.
        /// </summary>
        public LigatureSetCollection Ligatures { get; private set; }

        /// <summary>
        /// Kerning pairs in which this character is the first character of the pair.
        /// </summary>
        public KerningPairCollection KerningPairs { get; } = new KerningPairCollection();

        /// <summary>
        /// This property is used to store ligature information whilst a file is being loaded.  Not populated after 
        /// <see cref="Character.ProcessLigatures(IDictionary{string, Character})" /> has been called.
        /// </summary>
        private List<InitialLigatureSet> InitialLigatures { get; set; }

        /// <summary>
        /// Internal-only property-setting constructor.
        /// </summary>
        /// <param name="code">The character's encoded value.</param>
        /// <param name="name">The character name.</param>
        /// <param name="xWidth">X-axis width information.</param>
        /// <param name="yWidth">Y-axis width information.</param>
        /// <param name="vvector">VVector property value.</param>
        /// <param name="boundingBox">Character bounding box.</param>
        /// <param name="ligatures">Initial ligature information.</param>
        internal Character(short? code, string name, WidthSet xWidth, WidthSet yWidth, Vector? vvector, BoundingBox? boundingBox, 
            IEnumerable<InitialLigatureSet> ligatures)
        {
            Code = code;
            Name = name;
            XWidth = xWidth;
            YWidth = yWidth;
            VVector = vvector;
            BoundingBox = boundingBox;
            Ligatures = null;
            InitialLigatures = ligatures?.ToList();
        }

        /// <summary>
        /// Populate the <see cref="Character.Ligatures" /> property, converting the character names given in the AFM file to references to the <see cref="Character" />
        /// objects loaded from the font.
        /// </summary>
        /// <param name="charmap">A dictionary of characters loaded in this AFM file, indexed by <see cref="Character.Name" />.</param>
        /// <exception cref="AfmFormatException">Thrown if the character's ligature information refers by name to characters that are not known to exist.</exception>
        public void ProcessLigatures(IDictionary<string, Character> charmap)
        {
            if (charmap is null)
            {
                throw new ArgumentNullException(nameof(charmap));
            }

            if (InitialLigatures is null || InitialLigatures.Count == 0)
            {
                if (Ligatures is null)
                {
                    Ligatures = new LigatureSetCollection(null);
                }
                return;
            }

            List<LigatureSet> processedLigatures = new List<LigatureSet>(InitialLigatures.Count);
            foreach (InitialLigatureSet rawLigature in InitialLigatures)
            {
                if (!charmap.TryGetValue(rawLigature.Second, out Character second))
                {
                    throw new AfmFormatException($"Character {rawLigature.Second} not found in font.");
                }
                if (!charmap.TryGetValue(rawLigature.Ligature, out Character ligature))
                {
                    throw new AfmFormatException($"Character {rawLigature.Ligature} not found in font.");
                }
                processedLigatures.Add(new LigatureSet(this, second, ligature));
            }

            Ligatures = new LigatureSetCollection(processedLigatures);
        }

        /// <summary>
        /// Convert a character metrics line from an AFM file into a <see cref="Character" /> object.  A character metrics line looks something like 
        /// <c>C 102 ; WX 333 ; N f ; B 20 0 383 683 ; L i fi ; L l fl ;</c>
        /// </summary>
        /// <param name="input">The input line to be processed.</param>
        /// <returns></returns>
        public static Character FromString(string input)
        {
            if (input is null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            short? code = null;
            string name = null;
            WidthSet xWidth = new WidthSet();
            WidthSet yWidth = new WidthSet();
            Vector? vv = null;
            BoundingBox? bb = null;
            List<InitialLigatureSet> ligatures = new List<InitialLigatureSet>();

            string[] parts = input.Split(';');
            foreach (string part in parts)
            {
                string trimmedPart = part.Trim();
                if (trimmedPart.StartsWith("C", StringComparison.InvariantCulture))
                {
                    code = LoadCharacterCode(trimmedPart);
                }
                else if (trimmedPart.StartsWith("N", StringComparison.InvariantCulture))
                {
                    name = LoadName(trimmedPart);
                }
                else if (trimmedPart.StartsWith("W", StringComparison.InvariantCulture))
                {
                    if (trimmedPart.Contains('X'))
                    {
                        xWidth = LoadWidth(trimmedPart, xWidth);
                    }
                    else if (trimmedPart.Contains('Y'))
                    {
                        yWidth = LoadWidth(trimmedPart, yWidth);
                    }
                    else
                    {
                        LoadWidthVector(trimmedPart, ref xWidth, ref yWidth);
                    }
                }
                else if (trimmedPart.StartsWith("VV", StringComparison.InvariantCulture))
                {
                    vv = LoadVVector(trimmedPart);
                }
                else if (trimmedPart.StartsWith("B", StringComparison.InvariantCulture))
                {
                    bb = LoadBoundingBox(trimmedPart);
                }
                else if (trimmedPart.StartsWith("L", StringComparison.InvariantCulture))
                {
                    ligatures.Add(LoadInitialLigatureSet(trimmedPart));
                }
                else if (!string.IsNullOrEmpty(trimmedPart))
                {
                    throw new AfmFormatException($"Unrecognised character metrics section {trimmedPart}");
                }
            }

            return new Character(code, name, xWidth, yWidth, vv, bb, ligatures);
        }

        private static short? LoadCharacterCode(string input)
        {
            short? output = null;
            string[] parts = input.Split().Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
            if (parts.Length < 2)
            {
                throw new AfmFormatException($"Character code not found in {input}");
            }
            if (parts[0] == "C")
            {
                if (!short.TryParse(parts[1], out short val))
                {
                    throw new AfmFormatException($"Could not convert {parts[1]} to a string.");
                }
                if (val != -1)
                {
                    output = val;
                }
            }
            else if (parts[0] == "CH")
            {
                if (!parts[1].StartsWith(">", StringComparison.InvariantCulture) || !parts[1].EndsWith(">", StringComparison.InvariantCulture))
                {
                    throw new AfmFormatException($"Expected hex character code {parts[1]} in incorrect format.");
                }
                if (!short.TryParse(parts[1].Substring(1, parts[1].Length - 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out short val))
                {
                    throw new AfmFormatException($"Expected hex character code {parts[1]} in incorrect format.");
                }
                if (val != -1)
                {
                    output = val;
                }
            }

            return output;
        }

        private static string LoadName(string input)
        {
            string[] parts = input.Split().Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
            if (parts.Length < 2)
            {
                throw new AfmFormatException($"Name not found in {input}");
            }
            return parts[1];
        }

        private static WidthSet LoadWidth(string input, WidthSet existing)
        {
            string[] parts = input.Split().Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
            if (parts.Length < 2)
            {
                throw new AfmFormatException($"Width not found in {input}");
            }
            if (!decimal.TryParse(parts[1], out decimal val))
            {
                throw new AfmFormatException($"Could not parse {parts[1]} as a number.");
            }
            if (parts[0].StartsWith("W0", StringComparison.InvariantCulture))
            {
                return new WidthSet(existing.General, val, existing.Direction1);
            }
            if (parts[0].StartsWith("W1", StringComparison.InvariantCulture))
            {
                return new WidthSet(existing.General, existing.Direction0, val);
            }
            return new WidthSet(val, existing.Direction0, existing.Direction1);
        }

        private static void LoadWidthVector(string input, ref WidthSet x, ref WidthSet y)
        {
            string[] parts = input.Split().Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
            if (parts.Length < 3)
            {
                throw new AfmFormatException($"Width not found in {input}");
            }
            if (!decimal.TryParse(parts[1], out decimal valx))
            {
                throw new AfmFormatException($"Could not parse {parts[1]} as a number.");
            }
            if (!decimal.TryParse(parts[2], out decimal valy))
            {
                throw new AfmFormatException($"Could not parse {parts[2]} as a number.");
            }
            if (parts[0] == "W0")
            {
                x = new WidthSet(x.General, valx, x.Direction1);
                y = new WidthSet(y.General, valy, y.Direction1);
            }
            else if (parts[0] == "W1")
            {
                x = new WidthSet(x.General, x.Direction0, valx);
                y = new WidthSet(y.General, y.Direction0, valy);
            }
            else
            {
                x = new WidthSet(valx, x.Direction0, x.Direction1);
                y = new WidthSet(valy, y.Direction0, y.Direction1);
            }
        }

        private static Vector LoadVVector(string input)
        {
            string[] parts = input.Split().Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
            if (parts.Length < 3)
            {
                throw new AfmFormatException($"Vector not found in {input}");
            }
            return Vector.FromStrings(parts[1], parts[2]);
        }

        private static BoundingBox LoadBoundingBox(string input)
        {
            string[] parts = input.Split().Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
            if (parts.Length < 5)
            {
                throw new AfmFormatException($"Bounding box vector not found in {input}");
            }
            return Afm.BoundingBox.FromStrings(parts[1], parts[2], parts[3], parts[4]);
        }

        private static InitialLigatureSet LoadInitialLigatureSet(string input)
        {
            string[] parts = input.Split().Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
            if (parts.Length < 3)
            {
                throw new AfmFormatException($"Sufficient character names not found in {input}");
            }
            return new InitialLigatureSet(parts[1], parts[2]);
        }
    }
}
