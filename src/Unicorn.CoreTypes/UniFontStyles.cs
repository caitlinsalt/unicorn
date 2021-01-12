using System;

namespace Unicorn.CoreTypes
{

#pragma warning disable CA1008 // This rule suggests an enum should have a zero-value called 'None', but we need it to have a different name.

    /// <summary>
    /// A flags enumeration which describes the style of a font.
    /// </summary>
    [Flags]
    public enum UniFontStyles
    {
        /// <summary>
        /// Regular roman face
        /// </summary>
        Regular = 0,

        /// <summary>
        /// Bold face
        /// </summary>
        Bold = 1,

        /// <summary>
        /// Italic face
        /// </summary>
        Italic = 2,

        /// <summary>
        /// Underlined face
        /// </summary>
        Underline = 4,

        /// <summary>
        /// Stricken-through face
        /// </summary>
        Strikethrough = 8
    }

#pragma warning restore CA1008 // Enums should have zero value

}
