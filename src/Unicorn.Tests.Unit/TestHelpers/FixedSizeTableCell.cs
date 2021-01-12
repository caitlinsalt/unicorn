using System;
using System.Collections.Generic;
using Tests.Utility.Providers;
using Unicorn.CoreTypes;

namespace Unicorn.Tests.Unit.TestHelpers
{
    internal class FixedSizeTableCell : TableCell
    {
        private static readonly Random _rnd = RandomProvider.Default;

        internal double Width { get; private set; }

        internal double Height { get; private set; }

        internal int ColumnIndex { get; set; }

        internal int RowIndex { get; set; }

        internal List<Tuple<IGraphicsContext, double, double>> DrawContentsAtCalls { get; } = new List<Tuple<IGraphicsContext, double, double>>();

        internal FixedSizeTableCell(double width, double height)
        {
            Width = width;
            Height = height;
            MeasureSize(null);
        }

        public override void DrawContentsAt(IGraphicsContext context, double x, double y)
        {
            DrawContentsAtCalls.Add(new Tuple<IGraphicsContext, double, double>(context, x, y));
        }

        public override void MeasureSize(IGraphicsContext context)
        {
            ContentWidth = Width;
            ContentAscent = Height / 2;
            ContentDescent = Height / 2;
        }

#pragma warning disable CA5394 // Do not use insecure randomness

        internal static List<TableCell> GetCellList()
        {
            int count = _rnd.Next(32);
            return GetCellList(count);
        }

        internal static List<TableCell> GetCellList(int count)
        {
            List<TableCell> output = new List<TableCell>(count);
            for (int i = 0; i < count; ++i)
            {
                FixedSizeTableCell testCell = new FixedSizeTableCell(_rnd.NextDouble() * 20, _rnd.NextDouble() * 20);
                output.Add(testCell);
            }
            return output;
        }

#pragma warning restore CA5394 // Do not use insecure randomness

    }
}
