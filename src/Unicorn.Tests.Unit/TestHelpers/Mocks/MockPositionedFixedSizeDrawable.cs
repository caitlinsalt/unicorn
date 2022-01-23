using Unicorn.Base;

namespace Unicorn.Tests.Unit.TestHelpers.Mocks
{
    internal class MockPositionedFixedSizeDrawable : IPositionedFixedSizeDrawable
    {
        public double X { get; set; }

        public double Y { get; set; }

        public double Width { get; private set; }

        public double Height { get; private set; }

        public double ContentHeight => Height;

        public MockPositionedFixedSizeDrawable(double x, double y, double width, double height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public void Draw(IGraphicsContext context)
        {
            
        }

        public void DrawAt(IGraphicsContext context, double x, double y)
        {
            
        }
    }
}
