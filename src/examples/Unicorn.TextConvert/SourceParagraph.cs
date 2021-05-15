using Unicorn.Base;

namespace Unicorn.TextConvert
{
    public class SourceParagraph
    {
        public HorizontalAlignment Alignment { get; private set; }

        public string Content { get; private set; }

        public SourceParagraph(HorizontalAlignment alignment, string content)
        {
            Alignment = alignment;
            Content = content;
        }

        public SourceParagraph(string content) : this(HorizontalAlignment.Left, content) { }
    }
}
