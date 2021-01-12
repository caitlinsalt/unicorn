using System;
using System.Linq;

namespace Unicorn.FontTools.Afm
{
    internal static class LoadingHelpers
    {
        internal static decimal LoadKeyedDecimal(string input, string key)
        {
            string trimmedInput = GetTrimmedInput(input, key);
            if (!decimal.TryParse(trimmedInput, out decimal val))
            {
                throw new AfmFormatException($"Could not parse input data {trimmedInput}");
            }
            return val;
        }

        internal static int LoadKeyedInt(string input, string key)
        {
            string trimmedInput = GetTrimmedInput(input, key);
            if (!int.TryParse(trimmedInput, out int val))
            {
                throw new AfmFormatException($"Could not parse input data {trimmedInput}");
            }
            return val;
        }

        internal static string LoadKeyedString(string input, string key)
        {
            return GetTrimmedInput(input, key);
        }

        internal static Vector LoadKeyedVector(string input, string key)
        {
            string trimmedInput = GetTrimmedInput(input, key);
            string[] parts = trimmedInput.Split().Where(s => !string.IsNullOrEmpty(s)).ToArray();
            if (parts.Length < 2)
            {
                throw new AfmFormatException($"Insufficient data to parse vector in {input}.");
            }
            return Vector.FromStrings(parts[0], parts[1]);
        }

        internal static BoundingBox LoadKeyedBoundingBox(string input, string key)
        {
            string trimmedInput = GetTrimmedInput(input, key);
            string[] parts = trimmedInput.Split().Where(s => !string.IsNullOrEmpty(s)).ToArray();
            if (parts.Length < 4)
            {
                throw new AfmFormatException($"Insufficient data to parse bounding box in {input}.");
            }
            return BoundingBox.FromStrings(parts[0], parts[1], parts[2], parts[3]);
        }

        internal static bool LoadKeyedBool(string input, string key)
        {
            string trimmedInput = GetTrimmedInput(input, key);
            if (trimmedInput.StartsWith("true", StringComparison.InvariantCulture))
            {
                return true;
            }
            if (trimmedInput.StartsWith("false", StringComparison.InvariantCulture))
            {
                return false;
            }
            throw new AfmFormatException($"Could not understand boolean value {trimmedInput}");
        }

        private static string GetTrimmedInput(string input, string key)
        {
            if (input is null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            if (key is null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (key.Length >= input.Length)
            {
                throw new AfmFormatException($"Input line {input} does not appear to contain data.");
            }
            string trimmedInput = input.Substring(key.Length).TrimStart();
            if (trimmedInput.Length == 0)
            {
                throw new AfmFormatException($"Input line {input} does not appear to contain data.");
            }
            return trimmedInput;
        }
    }
}
