using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Tests.Utility.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class RandomExtensions
    {
        public const string AlphanumericCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        public const string AlphabeticalCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public const string HexadecimalCharacters = "abcdef0123456789";
        public const string WhiteSpaceCharacters = " \x0\t\r\n\f";
        public const string DelimiterCharacters = "()<>[]{}/%"; // These are the characters classed as "delimiters" in PDF documents.

        public static string NextString(this Random random, int len)
        {
            return random.NextString(AlphanumericCharacters, len);
        }

        public static string NextAlphabeticalString(this Random random, int len)
        {
            return random.NextString(AlphabeticalCharacters, len);
        }

        public static string NextHexString(this Random random, int len)
        {
            return random.NextString(HexadecimalCharacters, len);
        }

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

        private static char SelectCharacter(Random random, string characters)
        {
            return characters[random.Next(characters.Length)];
        }

        public static bool NextBoolean(this Random random)
        {
            if (random == null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            return random.Next(2) == 0;
        }

        public static bool? NextNullableBoolean(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            bool?[] values = { true, false, null };
            return values[random.Next(values.Length)];
        }

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

        public static double? NextNullableDouble(this Random random)
        {
            return NextNullableDouble(random, 1.0);
        }

        public static float? NextNullableFloat(this Random random)
        {
            return (float?)NextNullableDouble(random);
        }

        public static float? NextNullableFloat(this Random random, float scale)
        {
            return (float?)NextNullableDouble(random, scale);
        }

        public static DateTime NextDateTime(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            long ticks = NextLong(random, DateTime.MaxValue.Ticks);
            return new DateTime().AddTicks(ticks);
        }

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

        public static string NextDefinitelyInvalidString(this Random random, string[] validValues)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }

            string rval;
            do
            {
                rval = random.NextAlphabeticalString(random.Next(10));
            } while (validValues.Contains(rval));
            return rval;
        }

        public static decimal NextDecimal(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            return (decimal)random.NextDouble() * 2000m - 1000m;
        }

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

        public static short NextShort(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            return (short)random.Next(short.MaxValue + 1);
        }

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

        [CLSCompliant(false)]
        public static ushort NextUShort(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            return (ushort)random.Next(ushort.MaxValue + 1);
        }

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

        [CLSCompliant(false)]
        public static ulong NextULong(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            if (random.Next(2) == 0)
            {
                return random.NextUInt();
            }
            return uint.MaxValue + (ulong)random.NextUInt();
        }

        public static long NextLong(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            if (random.Next(63) < 32)
            {
                return NextUInt(random);
            }
            return NextUInt(random) | ((long)random.Next() << 32);
        }

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

        public static byte NextByte(this Random random)
        {
            return NextByte(random, byte.MaxValue + 1);
        }

        public static byte NextByte(this Random random, int max)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            return (byte)random.Next(max);
        }
    }
}
