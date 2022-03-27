using Unicorn.Base;

namespace Unicorn.TextConvert
{
    public interface IFontFinder
    {
        IFontDescriptor FindFont(string name, double size);
    }
}
