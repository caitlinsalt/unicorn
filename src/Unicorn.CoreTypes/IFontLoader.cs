using System;

namespace Unicorn.CoreTypes
{
    /// <summary>
    /// 
    /// </summary>
    public interface IFontLoader : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="pointSize"></param>
        /// <returns></returns>
        IFontDescriptor LoadFont(string path, double pointSize);
    }
}
