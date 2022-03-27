namespace Unicorn.Images.Jpeg
{
    internal class ExifTag
    {
        internal object Value { get; }

        internal ExifTagId Id { get; }

        public ExifTag(object value, ExifTagId id)
        {
            Value = value;
            Id = id;
        }
    }
}
