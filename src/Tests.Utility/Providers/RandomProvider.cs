using System;
using System.Diagnostics.CodeAnalysis;

namespace Tests.Utility.Providers
{
    [ExcludeFromCodeCoverage]
    public static class RandomProvider
    {
        public static Random Default { get; } = new Random();
    }
}
