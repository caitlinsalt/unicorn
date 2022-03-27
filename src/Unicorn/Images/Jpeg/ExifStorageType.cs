namespace Unicorn.Images.Jpeg
{
    internal enum ExifStorageType
    {
        // These values are defined in the EXIF spec.
        Byte         = 1,     // Unsigned byte.
        Ascii        = 2,     // String.
        Short        = 3,     // Unsigned short.
        Long         = 4,     // Unsigned int.
        Rational     = 5,     // Fraction of two unsigned ints.
        Undefined    = 7,     // Unsigned byte
        Slong        = 9,     // Signed int
        Srational    = 10,    // Fraction of two signed ints.
        ReadFromFile = 255,   // This tag can vary in type depending on the writer.
    }
}
