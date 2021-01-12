using System;

namespace Unicorn.FontTools.OpenType
{
    /// <summary>
    /// Flags set in the font header.
    /// </summary>
    [Flags]
    public enum FontProperties
    {
        /// <summary>
        /// The font baseline's y-coordinate is zero.
        /// </summary>
        BaselineZero = 1,

        /// <summary>
        /// The font's left sidebearing for all characters is at x-coordinate zero.
        /// </summary>
        LeftSidebearingZero = 2,

        /// <summary>
        /// Instructions may depend on point size.
        /// </summary>
        PointSizeDependentInstructions = 4,

        /// <summary>
        /// In calculations, all ppem values should be truncated to integers.
        /// </summary>
        IntegerPpemValues = 8,

        /// <summary>
        /// Instructions may alter the advance widths, so the advance width metrics may not scale linearly with point size.
        /// </summary>
        NonLinearAdvanceWidth = 16,

        /// <summary>
        /// Font data has been losslessly transformed in ways that may have invalidated any DSIG table present.
        /// </summary>
        LosslessData = 2048,

        /// <summary>
        /// Font has been converted but should produce compatible metrics.
        /// </summary>
        FontConverted = 4096,

        /// <summary>
        /// Font optimised for ClearType.
        /// </summary>
        ClearTypeOptimised = 8192,

        /// <summary>
        /// This is a font of last resort.  Glyphs for some code points may be generic symbols (such as the square box) rather than meaningful glyphs. 
        /// </summary>
        LastResortFont = 16384
    }
}
