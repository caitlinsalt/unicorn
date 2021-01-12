using System.Collections.Generic;
using System.Linq;
using Unicorn.CoreTypes;

namespace Unicorn
{
    /// <summary>
    /// A line of words.
    /// </summary>
    public class Line : IDrawable
    {
        /// <summary>
        /// The words making up this line.
        /// </summary>
        public IList<Word> Content { get; } = new List<Word>();

        /// <summary>
        /// The minimum width of this line.
        /// </summary>
        public double MinWidth => Content.Take(Content.Count - 1).Sum(w => w.MinWidth) + Content.Last().ContentWidth;

        /// <summary>
        /// The ascent of the line.
        /// </summary>
        public double ContentAscent => Content.Max(w => w.ContentAscent);

        /// <summary>
        /// The descent of the line.
        /// </summary>
        public double ContentDescent => Content.Max(w => w.ContentDescent);

        /// <summary>
        /// The total height of the line.
        /// </summary>
        public double ContentHeight => ContentAscent + ContentDescent;

        /// <summary>
        /// The distance from the baseline to the top of the line, equal to the ascent.
        /// </summary>
        public double ComputedBaseline => ContentAscent;

        /// <summary>
        /// A flag that indicates if this line has been flagged as potentially too wide for its container.
        /// </summary>
        public bool OverspillWidth { get; private set; }
        
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Line()
        {
            
        }

        /// <summary>
        /// Constructor with line content.
        /// </summary>
        /// <param name="words">The words which make up the initial content of the line.</param>
        public Line(IEnumerable<Word> words)
        {
            Content = words.ToList();
        }

        /// <summary>
        /// Take a sequence of words and assemble them into a sequence of lines which are, hopefully, shorter than a given maximum length.
        /// </summary>
        /// <param name="words">The <see cref="Word" />s to assemble into a line.</param>
        /// <param name="idealMaxLineWidth">The maximum width of the line.  This may be exceeded if and only if it is shorter than the length of any given word that has to be fitted.</param>
        /// <returns>An enumeration of <see cref="Line" />s.</returns>
        public static IEnumerable<Line> MakeLines(IEnumerable<Word> words, double idealMaxLineWidth)
        {
            List<Line> lines = new List<Line>();
            if (words == null)
            {
                return lines;
            }
            Word[] wordsArr = words.ToArray();
            if (wordsArr.Length == 0)
            {
                return lines;
            }
            Line curLine = new Line();
            for (int i = 0; i < wordsArr.Length; ++i)
            {
                curLine.Content.Add(wordsArr[i]);
                if (curLine.MinWidth > idealMaxLineWidth || 
                    (i + 1 < wordsArr.Length && curLine.Content.Sum(w => w.MinWidth) + wordsArr[i + 1].ContentWidth > idealMaxLineWidth))
                {
                    if (curLine.MinWidth > idealMaxLineWidth)
                    {
                        curLine.OverspillWidth = true;
                    }
                    lines.Add(curLine);
                    curLine = new Line();
                }
            }
            if (curLine.Content.Count > 0)
            {
                lines.Add(curLine);
            }

            return lines;
        }

        /// <summary>
        /// Draw this line.
        /// </summary>
        /// <param name="context">The context to use for drawing.</param>
        /// <param name="x">The X-coordinate of the top left corner of the line.</param>
        /// <param name="y">The Y-coordinate of the top left corner of the line.</param>
        public void DrawAt(IGraphicsContext context, double x, double y)
        {
            foreach (Word word in Content)
            {
                word.DrawAt(context, x, y + ContentAscent - word.ContentAscent);
                x += word.MinWidth;
            }
        }
    }
}
