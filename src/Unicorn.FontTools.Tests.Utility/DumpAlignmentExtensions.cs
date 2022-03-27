using System.Diagnostics.CodeAnalysis;
using Unicorn.FontTools.OpenType.Utility;

namespace Unicorn.FontTools.Tests.Utility
{
    /// <summary>
    /// Extension methods for the <see cref="DumpAlignment" /> enumeration.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class DumpAlignmentExtensions
    {
        /// <summary>
        /// Return the opposite value.  For left, return right, and vice-versa.
        /// </summary>
        /// <param name="val">A <see cref="DumpAlignment" /> value.</param>
        /// <returns><see cref="DumpAlignment.Left"/> if the parameter was <see cref="DumpAlignment.Right" />  and vice-versa.</returns>
        public static DumpAlignment Opposite(this DumpAlignment val) => val == DumpAlignment.Left ? DumpAlignment.Right : DumpAlignment.Left;
    }
}
