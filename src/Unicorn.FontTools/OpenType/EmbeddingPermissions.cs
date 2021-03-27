using System;

namespace Unicorn.FontTools.OpenType
{

#pragma warning disable CA1008 // This rule suggests an enum should have a zero-value called 'None', but we need it to have a different name.

    /// <summary>
    /// Flags that describe the font embedding usage permissions that apply to this font's licence.  The first four bits are mutually exclusive of each other,
    /// but may be used in combination with either of the others.
    /// </summary>
    [Flags]
    public enum EmbeddingPermissions
    {
        /// <summary>
        /// Font may be be embedded in documents and installed on remote systems and/or by other users.
        /// </summary>
        Installable = 0,

        /// <summary>
        /// Font may not be embedded without explicit permission of the owner.
        /// </summary>
        Restricted = 2,

        /// <summary>
        /// Font may be embedded in documents in order to view or print them, but not for other purposes.  Such documents must be read-only.
        /// </summary>
        Printing = 4,

        /// <summary>
        /// Font may be embedded in documents in order to view or print them.  The documents may be edited and additions to the document may use the font.
        /// </summary>
        Editable = 8,

        /// <summary>
        /// Font may only be embedded complete (if embedding is permitted) and may not be subsetted prior to embedding.
        /// </summary>
        NoSubsetting = 256,

        /// <summary>
        /// Only bitmap data from the font may be embedded, not outline data.  If the font contains no bitmaps it is not embeddable.
        /// </summary>
        BitmapOnly = 512,
    }

#pragma warning restore CA1008 // Enums should have zero value

}
