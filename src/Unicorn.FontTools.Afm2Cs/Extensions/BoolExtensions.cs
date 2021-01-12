namespace Unicorn.FontTools.Afm2Cs.Extensions
{
    internal static class BoolExtensions
    {
        internal static string ToCode(this bool b)
        {
            return b ? " true " : " false ";
        }
    }
}
