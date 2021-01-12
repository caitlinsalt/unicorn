using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Unicorn.FontTools.Afm
{
    /// <summary>
    /// Data on the kerning between a pair of characters.
    /// </summary>
    public struct KerningPair : IEquatable<KerningPair>
    {
        /// <summary>
        /// The first character of the pair.
        /// </summary>
        public Character First { get; private set; }

        /// <summary>
        /// The second character of the pair.
        /// </summary>
        public Character Second { get; private set; }

        /// <summary>
        /// The kerning vector, describing how the position of the second character should be offset.
        /// </summary>
        public Vector KerningVector { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="first">The first character of the pair.</param>
        /// <param name="second">The second character of the pair.</param>
        /// <param name="kern">The kerning vector.</param>
        /// <exception cref="ArgumentNullException">Thrown if either <c>first</c> or <c>second</c> parameter is <c>null</c>.</exception>
        public KerningPair(Character first, Character second, Vector kern)
        {
            if (first is null)
            {
                throw new ArgumentNullException(nameof(first));
            }
            if (second is null)
            {
                throw new ArgumentNullException(nameof(second));
            }

            First = first;
            Second = second;
            KerningVector = kern;
        }

        /// <summary>
        /// Equality method.
        /// </summary>
        /// <param name="other">Another <see cref="KerningPair" /> value.</param>
        /// <returns><c>true</c> if the two values are equal, otherwise <c>false</c>.</returns>
        public bool Equals(KerningPair other)
        {
            return this == other;
        }

        /// <summary>
        /// Equality method.
        /// </summary>
        /// <param name="obj">Another object or value.</param>
        /// <returns><c>true</c> if the parameter is a <see cref="KerningPair" /> value equal to this one, <c>false</c> othewise.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is KerningPair kp))
            {
                return false;
            }
            return Equals(kp);
        }

        /// <summary>
        /// Hash method.
        /// </summary>
        /// <returns>A hash code for this value.</returns>
        public override int GetHashCode()
        {
            return First.GetHashCode() ^ Second.GetHashCode() ^ KerningVector.GetHashCode();
        }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="a">A <see cref="KerningPair" /> value.</param>
        /// <param name="b">A second <see cref="KerningPair" /> value.</param>
        /// <returns><c>true</c> if both operands are equal, <c>false</c> otherwise.</returns>
        public static bool operator ==(KerningPair a, KerningPair b)
        {
            return a.First == b.First && a.Second == b.Second && a.KerningVector == b.KerningVector;
        }

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="a">A <see cref="KerningPair"/> value.</param>
        /// <param name="b">Another <see cref="KerningPair"/> value.</param>
        /// <returns><c>true</c> if the two values are different, <c>false</c> if they are equal.</returns>
        public static bool operator !=(KerningPair a, KerningPair b)
        {
            return a.First != b.First || a.Second != b.Second || a.KerningVector != b.KerningVector;
        }

        /// <summary>
        /// Convert a kerning pair record into a <see cref="KerningPair" /> value.  A kerning pair record consists of a code starting <c>KP</c> specifying the record
        /// type, the names or codes of two characters, and a vector describing the kerning offset.  The latter can be a 2D vector, or a single number implying that the
        /// other component of the vector is zero.
        /// </summary>
        /// <param name="input">The text to convert.</param>
        /// <param name="charsByName">A dictionary of valid characters keyed by character name.</param>
        /// <param name="charsByIndex">A dictionary of valid characters keyed by character index.</param>
        /// <returns>A <see cref="KerningPair" /> value.</returns>
        /// <exception cref="ArgumentNullException">Thrown if any parameter is null.</exception>
        /// <exception cref="AfmFormatException">Thrown if the record does not start with <c>KP</c>, <c>KPH</c>, <c>KPX</c> or <c>KPY</c>; or if the record type is 
        /// <c>KPH</c> and the character codes do not exist in the <c>charsByIndex</c> dictionary; or the record type is one of the other three and the character
        /// names do not exist in the <c>charsByName</c> dictionary; or the rest of the record cannot be converted into a <see cref="Vector"/>.</exception>
        public static KerningPair FromString(string input, IDictionary<string, Character> charsByName, IDictionary<short, Character> charsByIndex)
        {
            if (input is null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            if (charsByName is null)
            {
                throw new ArgumentNullException(nameof(charsByName));
            }
            if (charsByIndex is null)
            {
                throw new ArgumentNullException(nameof(charsByIndex));
            }

            string[] parts = input.Split().Where(x => !string.IsNullOrEmpty(x)).ToArray();
            if (parts.Length < 4)
            {
                throw new AfmFormatException($"Not enough data in kerning pair {input}");
            }
            Character first = null;
            Character second = null;
            Vector kv = default;
            if (parts[0] == "KPH")
            {
                first = CharLookup(parts[1], charsByIndex);
                second = CharLookup(parts[2], charsByIndex);
            }
            else if (parts[0] == "KPX" || parts[0] == "KPY" || parts[0] == "KP")
            {
                first = CharLookup(parts[1], charsByName);
                second = CharLookup(parts[2], charsByName);
            }
            else
            {
                throw new AfmFormatException($"Could not understand kerning pair {input}");
            }
            if (parts[0] == "KP" || parts[0] == "KPH")
            {
                if (parts.Length < 5)
                {
                    throw new AfmFormatException($"Not enough data in kerning pair {input}.");
                }
                kv = Vector.FromStrings(parts[3], parts[4]);
            }
            else if (parts[0] == "KPX")
            {
                kv = Vector.FromXString(parts[3]);
            }
            else // parts[0] == "KPY"
            {
                kv = Vector.FromYString(parts[3]);
            }

            return new KerningPair(first, second, kv);
        }

        private static Character CharLookup(string name, IDictionary<string, Character> map)
        {
            if (!map.ContainsKey(name))
            {
                throw new AfmFormatException($"Could not find character {name} in font");
            }
            return map[name];
        }

        private static Character CharLookup(string hexCode, IDictionary<short, Character> map)
        {
            if (!(hexCode.StartsWith("<", StringComparison.InvariantCulture) && hexCode.EndsWith(">", StringComparison.InvariantCulture)))
            {
                throw new AfmFormatException($"Could not recognise {hexCode} as a character code.");
            }
            if (!short.TryParse(hexCode.Substring(1, hexCode.Length - 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out short code))
            {
                throw new AfmFormatException($"Could not recognise {hexCode} as a number.");
            }
            if (!map.ContainsKey(code))
            {
                throw new AfmFormatException($"Could not find character encoded as {code} in font.");
            }
            return map[code];
        }
    }
}
