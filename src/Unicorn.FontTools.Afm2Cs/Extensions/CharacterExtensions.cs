using System.Linq;
using Unicorn.FontTools.Afm;

namespace Unicorn.FontTools.Afm2Cs.Extensions
{
    internal static class CharacterExtensions
    {
        internal static string ToCode(this Character c)
        {
            if (c is null)
            {
                return " (Unicorn.FontTools.Afm.Character)null ";
            }
            string ligaturePart;
            if (c.Ligatures.Count == 0)
            {
                ligaturePart = " System.Array.Empty<InitialLigatureSet>()";
            }
            else
            {
                ligaturePart = "new Unicorn.FontTools.Afm.InitialLigatureSet[] { " +
                    string.Join(", ", c.Ligatures.Select(g => $"new InitialLigatureSet({g.Second.Name.ToCode()}, {g.Ligature.Name.ToCode()})")) + "}";
            }
            return $" new Unicorn.FontTools.Afm.Character({c.Code.ToCode()}, {c.Name.ToCode()}, {c.XWidth.ToCode()}, {c.YWidth.ToCode()}, {c.VVector.ToCode()}, " +
                $" {c.BoundingBox.ToCode()}, {ligaturePart})";
        }
    }
}
