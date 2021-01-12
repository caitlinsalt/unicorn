using Unicorn.FontTools.Afm;

namespace Unicorn.FontTools.Afm2Cs.Extensions
{
    internal static class VectorExtensions
    {
        internal static string ToCode(this Vector v)
        {
            return $" new Unicorn.FontTools.Afm.Vector({v.X.ToCode()}, {v.Y.ToCode()})";
        }
    }
}
