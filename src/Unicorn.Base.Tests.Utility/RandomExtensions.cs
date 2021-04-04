using System;
using System.Diagnostics.CodeAnalysis;

namespace Unicorn.Base.Tests.Utility
{

#pragma warning disable CA5394 // Do not use insecure randomness

    /// <summary>
    /// Extension methods for <see cref="System.Random" /> to generate random values of <c>Unicorn.Base</c> types.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class RandomExtensions
    {
        private static readonly UniDashStyle[] _dashStyles = 
            new[] { UniDashStyle.Solid, UniDashStyle.Dash, UniDashStyle.Dot, UniDashStyle.DashDot, UniDashStyle.DashDotDot };

        /// <summary>
        /// Return a random <see cref="UniDashStyle" /> value.
        /// </summary>
        /// <param name="rnd">The random generator.</param>
        /// <returns>A valid <see cref="UniDashStyle" /> value.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <c>rnd</c> parameter is <c>null</c>.</exception>
        public static UniDashStyle NextUniDashStyle(this Random rnd) 
            => rnd is null ? throw new ArgumentNullException(nameof(rnd)) : _dashStyles[rnd.Next(_dashStyles.Length)];

        /// <summary>
        /// Return a random <see cref="UniFontStyles" /> value.
        /// </summary>
        /// <param name="rnd">The random generator.</param>
        /// <returns>A valid <see cref="UniFontStyles" /> value.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <c>rnd</c> parameter is <c>null</c>.</exception>
        public static UniFontStyles NextUniFontStyles(this Random rnd) => rnd is null ? throw new ArgumentNullException(nameof(rnd)) : (UniFontStyles)rnd.Next(16);

        /// <summary>
        /// Return a random <see cref="UniSize" /> value with dimensions between 0 and 1000.
        /// </summary>
        /// <param name="rnd">The random generator.</param>
        /// <returns>A <see cref="UniSize" /> value.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <c>rnd</c> parameter is <c>null</c>.</exception>
        public static UniSize NextUniSize(this Random rnd) 
            => rnd is null ? throw new ArgumentNullException(nameof(rnd)) : new UniSize(rnd.NextDouble() * 1000, rnd.NextDouble() * 1000);

        /// <summary>
        /// Return a random <see cref="UniTextSize" /> value with dimensions between 0 and 500.
        /// </summary>
        /// <param name="rnd">The random generator.</param>
        /// <returns>A <see cref="UniTextSize" /> value.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <c>rnd</c> parameter is <c>null</c>.</exception>
        public static UniTextSize NextUniTextSize(this Random rnd)
        {
            if (rnd is null)
            {
                throw new ArgumentNullException(nameof(rnd));
            }
            return new UniTextSize(rnd.NextDouble() * 500, rnd.NextDouble() * 500, rnd.NextDouble() * 500, rnd.NextDouble() * 500, rnd.NextDouble() * 500);
        }

        private static readonly PhysicalPageSize[] _physicalPageSizes 
            = new[] { PhysicalPageSize.A1, PhysicalPageSize.A2, PhysicalPageSize.A3, PhysicalPageSize.A4, PhysicalPageSize.A5, PhysicalPageSize.A6 };

        /// <summary>
        /// Returns a random <see cref="PhysicalPageSize" /> value.
        /// </summary>
        /// <param name="rnd">The random generator.</param>
        /// <returns>A valid <see cref="PhysicalPageSize" /> value.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <c>rnd</c> parameter is <c>null</c>.</exception>
        public static PhysicalPageSize NextPhysicalPageSize(this Random rnd) 
            => rnd is null ? throw new ArgumentNullException(nameof(rnd)) : _physicalPageSizes[rnd.Next(_physicalPageSizes.Length)];

        private static readonly PageOrientation[] _pageOrientations = new[] { PageOrientation.Portrait, PageOrientation.Landscape, PageOrientation.Arbitrary };

        /// <summary>
        /// Returns a random <see cref="PageOrientation" /> value.
        /// </summary>
        /// <param name="rnd">The random generator.</param>
        /// <returns>A valid <see cref="PageOrientation" /> value.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <c>rnd</c> parameter is <c>null</c>.</exception>
        public static PageOrientation NextPageOrientation(this Random rnd) 
            => rnd is null ? throw new ArgumentNullException(nameof(rnd)) : _pageOrientations[rnd.Next(_pageOrientations.Length)];

        /// <summary>
        /// Returns a random <see cref="UniPoint" /> value with coordinates between 0 and 1000.
        /// </summary>
        /// <param name="rnd">The random generator.</param>
        /// <returns>A random <see cref="UniPoint" /> value.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <c>rnd</c> parameter is <c>null</c>.</exception>
        public static UniPoint NextUniPoint(this Random rnd) 
            => rnd is null ? throw new ArgumentNullException(nameof(rnd)) : new UniPoint(rnd.NextDouble() * 1000, rnd.NextDouble() * 1000);

        /// <summary>
        /// Returns a random <see cref="UniMatrix" /> value with valus between 0 and 100.
        /// </summary>
        /// <param name="rnd">The random generator.</param>
        /// <returns>A random <see cref="UniMatrix" /> value.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <c>rnd</c> parameter is <c>null</c>.</exception>
        public static UniMatrix NextUniMatrix(this Random rnd) 
            => rnd is null ? 
                throw new ArgumentNullException(nameof(rnd)) : 
                new UniMatrix(rnd.NextDouble() * 100, rnd.NextDouble() * 100, rnd.NextDouble() * 100, rnd.NextDouble() * 100, rnd.NextDouble() * 100, 
                    rnd.NextDouble() * 100);

        private static readonly FlateCompressionLevel[] _compressionLevels = 
            new[] { FlateCompressionLevel.None, FlateCompressionLevel.Fastest, FlateCompressionLevel.Default, FlateCompressionLevel.Best };

        /// <summary>
        /// Return a random <see cref="FlateCompressionLevel" /> value.
        /// </summary>
        /// <param name="rnd">The random generator.</param>
        /// <returns>A random valid <see cref="FlateCompressionLevel" /> value.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <c>rnd</c> parameter is <c>null</c>.</exception>
        public static FlateCompressionLevel NextFlateCompressionLevel(this Random rnd) 
            => rnd is null ? throw new ArgumentNullException(nameof(rnd)) : _compressionLevels[rnd.Next(_compressionLevels.Length)];
    }

#pragma warning restore CA5394 // Do not use insecure randomness

}
