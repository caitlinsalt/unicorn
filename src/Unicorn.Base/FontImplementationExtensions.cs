    namespace Unicorn.Base
{
    /// <summary>
    /// Extension methods for the <see cref="FontImplementation" /> enum.
    /// </summary>
    public static class FontImplementationExtensions
    {
        /// <summary>
        /// Convert a <see cref="FontImplementation" /> value to the string used as the /Subtype value name in a PDF font dictionary (without the leading slash).
        /// </summary>
        /// <param name="value">A <see cref="FontImplementation" /> value.</param>
        /// <returns>The matching /Subtype name for the value, or <c>null</c> for <see cref="FontImplementation.Other" /> or any invalid value.</returns>
        public static string ToSubtypeName(this FontImplementation value)
        {
            switch (value)
            {
                case FontImplementation.Type1:
                case FontImplementation.StandardType1:
                    return "Type1";
                case FontImplementation.OpenType:
                    return "TrueType";
                case FontImplementation.Other:
                default:
                    return null;
            }
        }

        /// <summary>
        /// Detect if a <see cref="FontImplementation" /> is a standard font, which a PDF viewer should be expected to implement without most of the font's data being
        /// given inside the PDF file.
        /// </summary>
        /// <param name="value">A <see cref="FontImplementation" /> value.</param>
        /// <returns><c>true</c> if the implementation type represents a standard font, <c>false</c> otherwise.</returns>
        public static bool IsStandardFont(this FontImplementation value) => value == FontImplementation.StandardType1;
    }
}
