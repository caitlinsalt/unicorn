using System.Globalization;
using Unicorn.FontTools.Afm;

namespace Unicorn.FontTools.Afm2Cs.Extensions
{
    internal static class NullableExtensions
    {
        internal static string ToCode(this int? i)
        {
            if (!i.HasValue)
            {
                return " (int?)null ";
            }
            return i.Value.ToCode();
        }

        internal static string ToCode(this bool? b)
        {
            if (!b.HasValue)
            {
                return " (bool?)null ";
            }
            return b.Value.ToCode();
        }

        internal static string ToCode(this decimal? d)
        {
            if (!d.HasValue)
            {
                return " (decimal?)null ";
            }
            return d.Value.ToCode();
        }

        internal static string ToCode(this short? s)
        {
            if (!s.HasValue)
            {
                return " (short?)null ";
            }
            return $" (short?){s.Value.ToString(CultureInfo.InvariantCulture)} ";
        }

        internal static string ToCode(this Vector? v)
        {
            if (!v.HasValue)
            {
                return " (Unicorn.FontTools.Afm.Vector?)null ";
            }
            return v.Value.ToCode();
        }

        internal static string ToCode(this DirectionMetrics? dm)
        {
            if (!dm.HasValue)
            {
                return " (Unicorn.FontTools.Afm.DirectionMetrics?)null ";
            }
            return dm.Value.ToCode();
        }

        internal static string ToCode(this BoundingBox? bb)
        {
            if (!bb.HasValue)
            {
                return " (Unicorn.FontTools.Afm.BoundingBox?)null ";
            }
            return bb.Value.ToCode();
        }
    }
}
