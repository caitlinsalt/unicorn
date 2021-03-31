using System;

namespace Unicorn.FontTools.Afm
{
    public struct InitialLigatureSet : IEquatable<InitialLigatureSet>
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

        public static bool operator ==(InitialLigatureSet a, InitialLigatureSet b) => a.Second == b.Second && a.Ligature == b.Ligature;

        public static bool operator !=(InitialLigatureSet a, InitialLigatureSet b) => a.Second != b.Second || a.Ligature != b.Ligature;

        public bool Equals(InitialLigatureSet other) => this == other;

        public override bool Equals(object obj) => (obj is InitialLigatureSet ils) && this == ils;

        public override int GetHashCode() => Second.GetHashCode() ^ Ligature.GetHashCode();
    }
}
