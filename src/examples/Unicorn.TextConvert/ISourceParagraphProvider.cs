using System.Collections.Generic;

namespace Unicorn.TextConvert
{
    public interface ISourceParagraphProvider
    {
        IAsyncEnumerable<SourceParagraph> GetParagraphsAsync();
    }
}
