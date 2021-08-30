using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicorn.Base;

namespace Unicorn.Tests.Unit.TestHelpers.Mocks
{
    public class MockWord : IWord
    {
        public double ContentWidth { get; set; }

        public double ContentAscent { get; set; }

        public double ContentDescent { get; set; }

        public double MinWidth { get; set; }

        public void DrawAt(IGraphicsContext context, double x, double y)
        {
            throw new NotImplementedException();
        }

        public MockWord()
        { }

        public MockWord(double contentWidth, double minWidth, double ascent, double descent)
        {
            ContentWidth = contentWidth;
            MinWidth = minWidth;
            ContentAscent = ascent;
            ContentDescent = descent;
        }
    }
}
