namespace Unicorn.Writer.Primitives
{
    /// <summary>
    /// Class representing a number.  This is a convenience class that both <see cref="PdfInteger" /> and <see cref="PdfReal" /> inherit from, to make it easier
    /// to check the operand type of operators which can take either of those types as operands.
    /// </summary>
    public abstract class PdfNumber : PdfSimpleObject
    {
    }
}
