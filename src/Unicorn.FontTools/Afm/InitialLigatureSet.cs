using System;

namespace Unicorn.FontTools.Afm
{
    public struct InitialLigatureSet
    {
        public string Second { get; private set; }

        public string Ligature { get; private set; }

        public InitialLigatureSet(string second, string resultingLigature)
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
