using System;
using System.Diagnostics.CodeAnalysis;

namespace Tests.Utility.Providers
{
    /// <summary>
    /// A static class to avoid unnecessary creation of <see cref="Random" /> instances by providing a singleton.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class RandomProvider
    {
        private static readonly Lazy<Random> _underlying = new Lazy<Random>();

        /// <summary>
        /// The default <see cref="Random" /> instance.
        /// </summary>
        public static Random Default => _underlying.Value;
    }
}
