using System;

namespace Unicorn.CoreTypes
{
    /// <summary>
    /// Extension methods for the <see cref="PhysicalPageSize" /> type.
    /// </summary>
    public static class PhysicalPageSizeExtensions
    {
        private static readonly Lazy<UniSize> _a1Portrait = new Lazy<UniSize>(() => new UniSize(1683d, 2383));
        private static readonly Lazy<UniSize> _a2Portrait = new Lazy<UniSize>(() => new UniSize(1190d, 1683));
        private static readonly Lazy<UniSize> _a3Portrait = new Lazy<UniSize>(() => new UniSize(841d, 1190));
        private static readonly Lazy<UniSize> _a4Portrait = new Lazy<UniSize>(() => new UniSize(595d, 841));
        private static readonly Lazy<UniSize> _a5Portrait = new Lazy<UniSize>(() => new UniSize(419d, 595));
        private static readonly Lazy<UniSize> _a6Portrait = new Lazy<UniSize>(() => new UniSize(297d, 419));
        private static readonly Lazy<UniSize> _a1Landscape = new Lazy<UniSize>(() => new UniSize(2383d, 1683));
        private static readonly Lazy<UniSize> _a2Landscape = new Lazy<UniSize>(() => new UniSize(1683d, 1190));
        private static readonly Lazy<UniSize> _a3Landscape = new Lazy<UniSize>(() => new UniSize(1190d, 841));
        private static readonly Lazy<UniSize> _a4Landscape = new Lazy<UniSize>(() => new UniSize(841d, 595));
        private static readonly Lazy<UniSize> _a5Landscape = new Lazy<UniSize>(() => new UniSize(595d, 419));
        private static readonly Lazy<UniSize> _a6Landscape = new Lazy<UniSize>(() => new UniSize(419d, 297));

        /// <summary>
        /// Convert a standard page size to its dimensions, in portrait orientation.
        /// </summary>
        /// <param name="pageSize">The physical page size to convert.</param>
        /// <returns>A <see cref="UniSize"/> instance representing the physical dimensions of the paper size, in points.</returns>
        public static UniSize ToUniSize(this PhysicalPageSize pageSize)
        {
            switch (pageSize)
            {
                case PhysicalPageSize.A1:
                    return _a1Portrait.Value;
                case PhysicalPageSize.A2:
                    return _a2Portrait.Value;
                case PhysicalPageSize.A3:
                    return _a3Portrait.Value;
                case PhysicalPageSize.A4:
                    return _a4Portrait.Value;
                case PhysicalPageSize.A5:
                    return _a5Portrait.Value;
                case PhysicalPageSize.A6:
                    return _a6Portrait.Value;
                default:
                    throw new ArgumentOutOfRangeException(nameof(pageSize));
            }
        }

        /// <summary>
        /// Convert a standard page size to its dimensions.
        /// </summary>
        /// <param name="pageSize">The physical page size to convert.</param>
        /// <param name="orientation">The orientation of the page.  "Arbitrary" orientation returns the same dimensions as portrait orientation.</param>
        /// <returns>A <see cref="UniSize" /> instance representing the physical dimensions of the paper size, in points.</returns>
        public static UniSize ToUniSize(this PhysicalPageSize pageSize, PageOrientation orientation)
        {
            if (orientation != PageOrientation.Landscape)
            {
                return pageSize.ToUniSize();
            }
            switch (pageSize)
            {
                case PhysicalPageSize.A1:
                    return _a1Landscape.Value;
                case PhysicalPageSize.A2:
                    return _a2Landscape.Value;
                case PhysicalPageSize.A3:
                    return _a3Landscape.Value;
                case PhysicalPageSize.A4:
                    return _a4Landscape.Value;
                case PhysicalPageSize.A5:
                    return _a5Landscape.Value;
                case PhysicalPageSize.A6:
                    return _a6Landscape.Value;
                default:
                    throw new ArgumentOutOfRangeException(nameof(pageSize));
            }
        }
    }
}
