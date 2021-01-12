using System;

namespace Unicorn.FontTools.Afm2Cs.Extensions
{
    internal static class StringExtensions
    {
        internal static string ToCode(this string str)
        {
            if (str is null)
            {
                return " (string)null ";
            }

            if (!str.Contains('"', StringComparison.InvariantCulture))
            {
                return $" @\"{str}\" ";
            }
            return $" @\"{str.Replace(@"""", @"""""", StringComparison.InvariantCulture)}\" ";
        }
    }
}
