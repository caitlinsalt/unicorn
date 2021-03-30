using System;
using System.Diagnostics.CodeAnalysis;

namespace Tests.Utility.Providers
{
    [ExcludeFromCodeCoverage]
    public static class RandomProvider
    {
        private static readonly Lazy<Random> _underlying = new Lazy<Random>();

        public static Random Default => _underlying.Value;
    }
}
