using Unicorn.Base;

namespace Unicorn
{
    /// <summary>
    /// Represents a word: a block of characters, written in a single font, that should not be separated.
    /// </summary>
    public interface IWord : IDrawable
    {
        /// <summary>
        /// The width of the text of this word, without any additional spacing.
        /// </summary>
        double ContentWidth { get; }

        /// <summary>
        /// The ascent metric of the word.
        /// </summary>
        double ContentAscent { get; }

        /// <summary>
        /// The descent metric of the word.
        /// </summary>
        double ContentDescent { get; }

        /// <summary>
        /// The minimum width of the word and any necessary space after it.
        /// </summary>
        double MinWidth { get; }
    }
}
