using Unicorn.FontTools.Afm;

namespace Unicorn.FontTools.Afm2Cs.Extensions
{
    internal static class WidthSetExtensions
    {
        internal static string ToCode(this WidthSet ws)
        {
            return $" new Unicorn.FontTools.Afm.WidthSet({ws.General.ToCode()}, {ws.Direction0.ToCode()}, {ws.Direction1.ToCode()})";
        }
    }
}
