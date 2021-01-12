using Unicorn.FontTools.Afm;

namespace Unicorn.FontTools.Afm2Cs.Extensions
{
    internal static class BoundingBoxExtensions
    {
        internal static string ToCode(this BoundingBox bb)
        {
            return $" new Unicorn.FontTools.Afm.BoundingBox({bb.Left.ToCode()}, {bb.Bottom.ToCode()}, {bb.Right.ToCode()}, {bb.Top.ToCode()})";
        }
    }
}
