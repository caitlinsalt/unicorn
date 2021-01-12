using NLog;
using System;
using System.Collections.Generic;
using Unicorn.CoreTypes;

namespace Unicorn
{
    /// <summary>
    /// Represents a word - a block of characters that must not be separated.
    /// </summary>
    public class Word : IDrawable
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The textual content of this word.
        /// </summary>
        public string Content { get; private set; }

        /// <summary>
        /// The font to be used to render the word.
        /// </summary>
        public IFontDescriptor Font { get; private set; }

        /// <summary>
        /// The width of the text of this word, without any additional spacing.
        /// </summary>
        public double ContentWidth { get; private set; }

        /// <summary>
        /// The ascent metric of the word.
        /// </summary>
        public double ContentAscent { get; set; }

        /// <summary>
        /// The descent metric of the word.
        /// </summary>
        public double ContentDescent { get; set; }

        /// <summary>
        /// The distance between the top line and baseline of the word, equal to the ascent.
        /// </summary>
        public double ComputedBaseline { get { return ContentAscent; } }

        /// <summary>
        /// The minimum amount of space to add after the word.  This space may be skipped at the end of a line.
        /// </summary>
        public double PostWordSpace { get; private set; }

        /// <summary>
        /// The minimum width of the word and any necessary space after it.
        /// </summary>
        public double MinWidth
        {
            get
            {
                return ContentWidth + PostWordSpace;
            }
        }

        /// <summary>
        /// The height of this word.
        /// </summary>
        public double MinHeight { get { return ContentAscent + ContentDescent; } }

        /// <summary>
        /// Construct a <see cref="Word" /> instance. 
        /// </summary>
        /// <param name="content">The textual content of the word.</param>
        /// <param name="font">The font to use for display.</param>
        /// <param name="graphicsContext">The graphics context for providing metrics.</param>
        /// <param name="postWordSpace">The minimum amount of space to add after the word if it is not at the end of a line.</param>
        public Word(string content, IFontDescriptor font, IGraphicsContext graphicsContext, double postWordSpace)
        {
            if (font is null)
            {
                throw new ArgumentNullException(nameof(font));
            }
            Content = content;
            Font = font;
            PostWordSpace = postWordSpace;
            if (string.IsNullOrEmpty(Content) || graphicsContext == null)
            {
                ContentWidth = 0;
                ContentAscent = 0;
                ContentDescent = 0;
            }
            else
            {
                UniTextSize measure = graphicsContext.MeasureString(Content, Font);
                ContentWidth = measure.Width;
                ContentAscent = measure.HeightAboveBaseline;
                ContentDescent = measure.HeightBelowBaseline;
            }
        }

        /// <summary>
        /// Draw the word at a particular location in a given context.
        /// </summary>
        /// <param name="context">The context to use to draw the word.</param>
        /// <param name="x">The x-coordinate of the top left corner of the word.</param>
        /// <param name="y">The y-coordinate of the top left corner of the word.</param>
        public void DrawAt(IGraphicsContext context, double x, double y)
        {
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            double computedY = y + ComputedBaseline;
            Log.Trace("Drawing '{0}' at {1}, {2}", Content, x, computedY);
            context.DrawString(Content, Font, x, computedY);
        }

        /// <summary>
        /// Convert a text string into zero or more <see cref="Word" /> instances by splitting it up on white space.
        /// </summary>
        /// <param name="text">The text to use to create the words.</param>
        /// <param name="font">The font to display the text in.</param>
        /// <param name="graphicsContext">The graphics context to use for rendering the words and providing metrics.</param>
        /// <returns>An enumeration of <see cref="Word" /> instances, each consisting of a single word from the input text.</returns>
        public static IEnumerable<Word> MakeWords(string text, IFontDescriptor font, IGraphicsContext graphicsContext)
        {
            if (text is null)
            {
                yield break;
            }
            if (font is null)
            {
                throw new ArgumentNullException(nameof(font));
            }
            double wordSpace = font.GetNormalSpaceWidth(graphicsContext);
            string[] words = text.Split(null);
            Log.Trace("Split text '{0}' into {1} words.", text, words.Length);
            foreach (string word in words)
            {
                if (string.IsNullOrEmpty(word))
                {
                    continue;
                }
                yield return new Word(word, font, graphicsContext, wordSpace);
            }
        }
    }
}
