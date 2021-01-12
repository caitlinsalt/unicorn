using System;

namespace Unicorn.FontTools.Afm
{
    internal struct InitialLigatureSet
    {
        internal string Second { get; private set; }

        internal string Ligature { get; private set; }

        internal InitialLigatureSet(string second, string resultingLigature)
        {
            if (second is null)
            {
                throw new ArgumentNullException(nameof(second));
            }
            if (resultingLigature is null)
            {
                throw new ArgumentNullException(nameof(resultingLigature));
            }

            Second = second;
            Ligature = resultingLigature;
        }
    }
}
