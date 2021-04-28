using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Tests.Utility.Extensions
{

#pragma warning disable CA5394 // Do not use insecure randomness

    /// <summary>
    /// Extension methods for generating random data.  As these are extensions to <see cref="System.Random" />, they are not suitable for cryptographic purposes.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class RandomExtensions
    {
        /// <summary>
        /// A helper string containing unaccented alphanumeric characters.
        /// </summary>
        public const string AlphanumericCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        /// <summary>
        /// A helper string containing unaccented alphabetical characters.
        /// </summary>
        public const string AlphabeticalCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        /// <summary>
        /// A helper string containing unaccented alphabetical characters that are not hex digits, to enable the caller to generate a string which will not be 
        /// accidentally accepted as a hexadecimal number.
        /// </summary>
        public const string NonHexAlphabeticalCharacters = "ghijklmnopqrstuvwyxzGHIJKLMNOPQRSTUVWXYZ";

        /// <summary>
        /// A helper string containing valid hexadecimal characters.
        /// </summary>
        public const string HexadecimalCharacters = "abcdef0123456789";

        /// <summary>
        /// A helper string containing various white space characters.
        /// </summary>
        public const string WhiteSpaceCharacters = " \x0\t\r\n\f";

        /// <summary>
        /// A helper string containing the characters that, in the PDF specification, are classified as "delimiters" and therefore cannot appear in certain places such
        /// as names or unescaped strings.
        /// </summary>
        public const string DelimiterCharacters = "()<>[]{}/%"; // These are the characters classed as "delimiters" in PDF documents.

        /// <summary>
        /// Generate a random string.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <param name="len">The length of the string to generate.</param>
        /// <returns>A string of random characters, of the given length.</returns>
        /// <exception cref="ArgumentNullException"><c>random</c> is <c>null</c>.</exception>
        public static string NextString(this Random random, int len) => random.NextString(AlphanumericCharacters, len);

        /// <summary>
        /// Generate a set of strings of equal length containing no duplicates.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <param name="characters">The source of characters for the generated string.</param>
        /// <param name="len">The length of every generated string.</param>
        /// <param name="count">The number of strings to generate.</param>
        /// <returns>An enumeration of randomly-generated strings, each guaranteed to be unique within the set.</returns>
        /// <remarks>It is possible to call this method with parameters that set requirements that are impossible to fulfil, such as a large number of short strings
        /// generated from a very small number of characters.  If this occurs, or if the time taken to find a valid non-duplicate string appears to be becoming 
        /// excessive, the routine may return an enumerator which will not provide <c>count</c> strings.  It is the caller's responsibility to handle this.</remarks>
        /// <exception cref="ArgumentNullException"><c>random</c> is <c>null</c> or <c>characters</c> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><c>len</c> is negative or <c>count</c> is negative.</exception>
        public static IEnumerable<string> NextStringSet(this Random random, string characters, int len, int count) => random.NextStringSet(characters, () => len, count);

        /// <summary>
        /// Generate a set of alphanumeric strings containing no duplicates.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <param name="lenFunction">A function that will be called each time a string is about to be generated, and should return the length of string to generate.</param>
        /// <param name="count">The number of strings to generate.</param>
        /// <returns>An enumeration of randomly-generated strings, each guaranteed to be unique within the set.</returns>
        /// <remarks>It is possible to call this method with parameters that set requirements that are impossible to fulfil, such as a large number of very short strings.  
        /// If this occurs, or if the time taken to find a valid non-duplicate string appears to be becoming excessive, the routine may return an enumerator which 
        /// will not provide <c>count</c> strings.  It is the caller's responsibility to handle this.</remarks>
        /// <exception cref="ArgumentNullException"><c>random</c> is <c>null</c> or <c>lenFunction</c> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><c>count</c> is negative.</exception>
        /// <exception cref="InvalidOperationException"><c>lenFunction</c> returns a negative result when called.</exception>
        public static IEnumerable<string> NextStringSet(this Random random, Func<int> lenFunction, int count) 
            => random.NextStringSet(AlphanumericCharacters, lenFunction, count);

        /// <summary>
        /// Generate a set of alphanumeric strings of equal length containing no duplicates.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <param name="len">The length of every generated string.</param>
        /// <param name="count">The number of strings to generate.</param>
        /// <returns>An enumeration of randomly-generated strings, each guaranteed to be unique within the set.</returns>
        /// <remarks>It is possible to call this method with parameters that set requirements that are impossible to fulfil, such as a large number of very short strings.  
        /// If this occurs, or if the time taken to find a valid non-duplicate string appears to be becoming excessive, the routine may return an enumerator which 
        /// will not provide <c>count</c> strings.  It is the caller's responsibility to handle this.</remarks>
        /// <exception cref="ArgumentNullException"><c>random</c> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><c>count</c> is negative or <c>len</c> is negative.</exception>
        public static IEnumerable<string> NextStringSet(this Random random, int len, int count) => random.NextStringSet(AlphanumericCharacters, () => len, count);

        /// <summary>
        /// Generates a random string of alphabetical characters.
        /// </summary>
        /// <param name="random">The random generator</param>
        /// <param name="len">The length of string to generate.</param>
        /// <returns>A string of random alphabetical characters, of the given length.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <c>random</c> parameter is <c>null</c>.</exception>
        public static string NextAlphabeticalString(this Random random, int len) => random.NextString(AlphabeticalCharacters, len);

        /// <summary>
        /// Generates a random string of hexadecimal characters.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <param name="len">The length of string to generate.</param>
        /// <returns>A string of random hexadecimal digit characters, of the given length.</returns>
        /// <exception cref="ArgumentNullException"><c>random</c> is <c>null</c>.</exception>
        public static string NextHexString(this Random random, int len) => random.NextString(HexadecimalCharacters, len);

        /// <summary>
        /// Generates a random string using characters that are present in the given string.  The characters selected are uniformly distributed, so the character
        /// distribution can be varied by repeating characters.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <param name="characters">The source of characters for the generated string.</param>
        /// <param name="len">The length of string to generate.</param>
        /// <returns>A random string consisting solely of characters present in the <c>characters</c> parameter, of the given length.</returns>
        /// <exception cref="ArgumentNullException"> <c>random</c> is <c>null</c> or <c>characters</c> is <c>null</c>.</exception>
        public static string NextString(this Random random, string characters, int len)
        {
            if (random == null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            if (characters == null)
            {
                throw new ArgumentNullException(nameof(characters));
            }
            if (characters.Length == 0)
            {
                throw new ArgumentException(Resources.RandomExtensions_NextString_Error_NoCharactersToSelectFrom, nameof(characters));
            }
            if (len < 0)
            {
                throw new ArgumentException(Resources.RandomExtensions_NextString_Error_NegativeLength, nameof(len));
            }

            if (len == 0)
            {
                return string.Empty;
            }
            if (len == 1)
            {
                return new string(SelectCharacter(random, characters), 1);
            }
            StringBuilder sb = new StringBuilder(len);
            for (int i = 0; i < len; ++i)
            {
                sb.Append(SelectCharacter(random, characters));
            }
            return sb.ToString();
        }

        /// <summary>
        /// Generate a set of strings containing no duplicates.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <param name="characters">The source set of characters to use to generate the strings.</param>
        /// <param name="lenFunction">A function which will be called when a string is about to be generated, which should return the length of string to generate.</param>
        /// <param name="count">The number of strings to generate.</param>
        /// <remarks>It is possible to call this method with parameters that set requirements that are impossible to fulfil, such as a large number of short strings
        /// generated from a very small number of characters.  If this occurs, or if the time taken to find a valid non-duplicate string appears to be becoming 
        /// excessive, the routine may return an enumerator which will not provide <c>count</c> strings.  It is the caller's responsibility to handle this.</remarks>
        /// <exception cref="ArgumentNullException"><c>random</c> is <c>null</c>, or <c>characters</c> is <c>null</c>, or <c>lenFunction</c> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><c>count</c> is negative.</exception>
        /// <exception cref="InvalidOperationException"><c>lenFunction</c> returns a negative result when called.</exception>
        public static IEnumerable<string> NextStringSet(this Random random, string characters, Func<int> lenFunction, int count)
        {
            if (lenFunction is null)
            {
                throw new ArgumentNullException(nameof(lenFunction), Resources.RandomExtensions_NextStringSet_Error_NullLengthGenerator);
            }
            if (count < 0)
            {
                throw new ArgumentException(Resources.RandomExtensions_NextStringSet_Error_NegativeCount, nameof(count));
            }
            if (count == 0)
            {
                yield break;
            }
            Dictionary<string, string> stringRecord = new Dictionary<string, string>(count);
            int limitCount = (count > (int.MaxValue >> 4)) ? count : count << 4;
            for (int i = 0; i < count; ++i)
            {
                string val;
                int length = lenFunction();
                int iterations = 0;
                if (length < 0)
                {
                    throw new InvalidOperationException(Resources.RandomExtensions_NextString_Error_NegativeLength);
                }
                do
                {
                    val = NextString(random, characters, length);
                    if (iterations++ > limitCount)
                    {
                        yield break;
                    }
                } while (stringRecord.ContainsKey(val));
                stringRecord.Add(val, val);
                yield return val;
            }
        }

        private static char SelectCharacter(Random random, string characters) => characters[random.Next(characters.Length)];

        /// <summary>
        /// Return a random true or false value.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <returns>Either <c>true</c> or <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException"><c>random</c> is <c>null</c>.</exception>
        public static bool NextBoolean(this Random random) => random is null ? throw new ArgumentNullException(nameof(random)) : (random.Next(2) == 0);

        /// <summary>
        /// Returns a random true, false or null value, distributed equally across the three.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <returns>Either <c>true</c>, <c>false</c> or <c>null</c>.</returns>
        /// <exception cref="ArgumentNullException"><c>random</c> is <c>null</c>.</exception>
        public static bool? NextNullableBoolean(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            bool?[] values = { true, false, null };
            return values[random.Next(values.Length)];
        }

        /// <summary>
        /// Returns a random <see cref="double"/> value, with a 1-in-10 chance of being <c>null</c>, scaled by a factor.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <param name="scale">The largest possible value this method will return.</param>
        /// <returns>A random floating-point value, or <c>null</c> approximately one time in ten.</returns>
        /// <exception cref="ArgumentNullException"><c>random</c> is <c>null</c>.</exception>
        public static double? NextNullableDouble(this Random random, double scale)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            if (random.Next(10) == 0)
            {
                return null;
            }
            return random.NextDouble() * scale;
        }

        /// <summary>
        /// Returns a random <see cref="double" /> value between 0.0 and 1.0, with a 1-in-10 chance of being <c>null</c>.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <returns>A random floating point value between 0.0 and 1.0, or <c>null</c> approximately one time in ten.</returns>
        public static double? NextNullableDouble(this Random random) => NextNullableDouble(random, 1.0);

        /// <summary>
        /// Returns a random <see cref="float" /> value between 0.0 and 1.0, with a 1-in-10 chance of being <c>null</c>/
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <returns>A random floating point value between 0.0 and 1.0, or <c>null</c> approximately one time in ten.</returns>
        public static float? NextNullableFloat(this Random random) => (float?)NextNullableDouble(random);

        /// <summary>
        /// Returns a random <see cref="float"/> value, with a 1-in-10 chance of being <c>null</c>, scaled by a factor.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <param name="scale">The largest possible value this method will return.</param>
        /// <returns>A random floating-point value, or <c>null</c> approximately one time in ten.</returns>
        /// <exception cref="ArgumentNullException"><c>random</c> is <c>null</c>.</exception>
        public static float? NextNullableFloat(this Random random, float scale) => (float?)NextNullableDouble(random, scale);

        /// <summary>
        /// Returns a random <see cref="DateTime" /> value.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <returns>A random timestamp.</returns>
        /// <exception cref="ArgumentNullException"><c>random</c> is <c>null</c>.</exception>
        public static DateTime NextDateTime(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            long ticks = NextLong(random, DateTime.MaxValue.Ticks);
            return new DateTime().AddTicks(ticks);
        }

        /// <summary>
        /// Returns a random string.  80% of the time, the string will be a member of a set of valid values.  20% of the time, the string will not be a member of 
        /// that set.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <param name="validValues">A set of "valid values"</param>
        /// <returns>Approximately 4 times out of 5, a random member of the <c>validValues</c> set.  The remainder of the time, a randomly-generated 
        /// string that is not a member of the set.</returns>
        /// <exception cref="ArgumentNullException"><c>random</c> is <c>null</c> or <c>validValues</c> is <c>null</c>.</exception>
        public static string NextPotentiallyValidString(this Random random, string[] validValues)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            if (validValues is null)
            {
                throw new ArgumentNullException(nameof(validValues));
            }

            if (random.Next(5) == 0)
            {
                return NextDefinitelyInvalidString(random, validValues);
            }
            else
            {
                return validValues[random.Next(validValues.Length)];
            }
        }

        /// <summary>
        /// Returns a randomly-generated string that is not a member of a set of "valid strings".
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <param name="validValues">A set of string values that the method will never return.</param>
        /// <returns>A randomly-generated string that is not a member of the <c>validValues</c> set.</returns>
        /// <exception cref="ArgumentNullException"><c>random</c> is <c>null</c> or <c>validValues</c> is <c>null</c>.</exception>
        public static string NextDefinitelyInvalidString(this Random random, string[] validValues)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            if (validValues is null)
            {
                throw new ArgumentNullException(nameof(validValues));
            }

            string rval;
            do
            {
                rval = random.NextAlphabeticalString(random.Next(10));
            } while (validValues.Contains(rval));
            return rval;
        }

        /// <summary>
        /// Returns a random <see cref="decimal" /> value between -1000 and +1000.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <returns>A randomly-generated decimal value.</returns>
        /// <exception cref="ArgumentNullException"><c>random</c> is <c>null</c>.</exception>
        public static decimal NextDecimal(this Random random) 
            => random is null ? throw new ArgumentNullException(nameof(random)) : (decimal)random.NextDouble() * 2000m - 1000m;

        /// <summary>
        /// Returns a random <see cref="decimal" /> value between -1000 and +1000, or <c>null</c> about 1 time in 10.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <returns>A randomly-generated decimal value, or <c>null</c> about 1 time in 10.</returns>
        /// <exception cref="ArgumentNullException"><c>random</c> is <c>null</c>.</exception>
        public static decimal? NextNullableDecimal(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            if (random.Next(10) == 0)
            {
                return null;
            }
            return NextDecimal(random);
        }

        /// <summary>
        /// Returns a random <see cref="short" /> value.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <returns>A random non-negative<see cref="short" /> integer.</returns>
        /// <exception cref="ArgumentNullException"><c>random</c> is <c>null</c>.</exception>
        public static short NextShort(this Random random) 
            => random is null ? throw new ArgumentNullException(nameof(random)) : (short)random.Next(short.MaxValue + 1);

        /// <summary>
        /// Returns a random <see cref="short" /> value, or <c>null</c>.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <returns>A random non-negative <see cref="short" /> integer, or <c>null</c> approximately one time in ten.</returns>
        /// <exception cref="ArgumentNullException"><c>random</c> is <c>null</c>.</exception>
        public static short? NextNullableShort(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            if (random.Next(10) == 0)
            {
                return null;
            }
            return NextShort(random);
        }

        /// <summary>
        /// Returns a random <see cref="int" />, or sometimes <c>null</c>.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <returns>A random non-negative <see cref="int" />, or <c>null</c> about one time in ten.</returns>
        public static int? NextNullableInt(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            if (random.Next(10) == 0)
            {
                return null;
            }
            return random.Next();
        }

        /// <summary>
        /// Returns a random <see cref="ushort" /> value.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <returns>A random <see cref="ushort" /> value.</returns>
        /// <exception cref="ArgumentNullException"><c>random</c> is <c>null</c>.</exception>
        [CLSCompliant(false)]
        public static ushort NextUShort(this Random random) => NextUShort(random, ushort.MaxValue);

        /// <summary>
        /// Returns a random <see cref="ushort" /> value.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <param name="maxValue">The exclusive upper boun on the value returned.</param>
        /// <returns>A random <see cref="ushort" /> value.</returns>
        /// <exception cref="ArgumentNullException"><c>random</c> is <c>null</c>.</exception>
        [CLSCompliant(false)]
        public static ushort NextUShort(this Random random, ushort maxValue)
            => random is null ? throw new ArgumentNullException(nameof(random)) : (ushort)random.Next(maxValue);

        /// <summary>
        /// Returns a random <see cref="uint" /> value.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <returns>A random <see cref="uint" /> value.</returns>
        /// <exception cref="ArgumentNullException"><c>random</c> is <c>null</c>.</exception>
        [CLSCompliant(false)]
        public static uint NextUInt(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            if (random.Next(2) == 0)
            {
                return (uint)random.Next();
            }
            return int.MaxValue + (uint)random.Next();
        }

        /// <summary>
        /// Returns a random <see cref="uint" /> value that is less than a certain bound.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <param name="max">The upper exclusive bound of the generated random number</param>
        /// <returns>A random number that is less that the <c>max</c> parameter.</returns>
        /// <exception cref="ArgumentNullException"><c>random</c> is <c>null</c>.</exception>
        [CLSCompliant(false)]
        public static uint NextUInt(this Random random, uint max)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            if (max < int.MaxValue)
            {
                return (uint)random.Next((int)max);
            }
            return unchecked((uint)random.Next((int)(max >> 1)) << 1) | (uint)random.Next(2);
        }

        /// <summary>
        /// Returns a random <see cref="ulong" /> value.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <returns>A random <see cref="ulong"/> value.</returns>
        /// <exception cref="ArgumentNullException"><c>random</c> is <c>null</c>.</exception>
        [CLSCompliant(false)]
        public static ulong NextULong(this Random random) => random.NextUInt() | ((ulong)random.NextUInt() << 32);

        /// <summary>
        /// Return a random <see cref="long" /> value.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <returns>A non-negative <see cref="long"/>integer.</returns>
        /// <exception cref="ArgumentNullException"><c>random</c> is <c>null</c>.</exception>
        public static long NextLong(this Random random) => NextUInt(random) | ((long)random.Next() << 32);

        /// <summary>
        /// Return a random <see cref="long" /> value less than a given value.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <param name="max">The upper exclusive bound of the returned number.</param>
        /// <returns>A random non-negative number that is less than the upper bound parameter.</returns>
        /// <exception cref="ArgumentNullException"><c>random</c> is <c>null</c>.</exception>
        public static long NextLong(this Random random, long max)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            if (max < uint.MaxValue)
            {
                return random.NextUInt((uint)max);
            }
            return random.NextUInt() | (long)random.Next((int)(max >> 32)) << 32;
        }

        /// <summary>
        /// Returns a random <see cref="uint" /> value, or <c>null</c>.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <returns>A random <see cref="uint" /> value, or <c>null</c> about one time in ten.</returns>
        /// <exception cref="ArgumentNullException"><c>random</c> is <c>null</c>.</exception>
        [CLSCompliant(false)]
        public static uint? NextNullableUInt(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            if (random.Next(10) == 0)
            {
                return null;
            }
            return NextUInt(random);
        }

        /// <summary>
        /// Returns a random byte.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <returns>A random byte value.</returns>
        /// <exception cref="ArgumentNullException"><c>random</c> is <c>null</c>.</exception>
        public static byte NextByte(this Random random) => NextByte(random, byte.MaxValue + 1);

        /// <summary>
        /// Returns a random byte that is lower than a given value.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <param name="max">The upper exclusive bound of the returned value.</param>
        /// <returns>A random byte value that is less than the upper bound parameter.</returns>
        /// <exception cref="ArgumentNullException"><c>random</c> is <c>null</c>.</exception>
        public static byte NextByte(this Random random, int max) => random is null ? throw new ArgumentNullException(nameof(random)) : (byte)random.Next(max);

        /// <summary>
        /// Returns a random byte that is within a given range.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <param name="min">The lower inclusive bound of the returned value.</param>
        /// <param name="max">The upper exclusive bound of the returned value.</param>
        /// <returns>A random byte value that is greater than or equal to the lower bound and less than the upper bound.</returns>
        /// <exception cref="ArgumentNullException"><c>random</c> is <c>null</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">The upper bound is equal to or less than the lower bound.</exception>
        public static byte NextByte(this Random random, int min, int max)
            => random is null ? throw new ArgumentNullException(nameof(random)) : (byte)random.Next(min, max);
    }

#pragma warning restore CA5394 // Do not use insecure randomness

}
