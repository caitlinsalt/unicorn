namespace Unicorn.Writer.Interfaces
{
    public interface IPdfReference : IPdfPrimitiveObject
    {
        int ObjectId { get; }

        int Generation { get; }
    }
}
