using System;

namespace Unicorn.Tests.Unit.TestHelpers
{
    internal static class RandomExtensions
    {
        private static TableRuleStyle[] _validTableRuleStyles =
        {
            TableRuleStyle.None,
            TableRuleStyle.LinesMeet,
            TableRuleStyle.SolidColumnsBrokenRows,
            TableRuleStyle.SolidRowsBrokenColumns,
        };

#pragma warning disable CA5394 // Do not use insecure randomness

        internal static TableRuleStyle NextTableRuleStyle(this Random rnd)
        {
            if (rnd is null)
            {
                throw new ArgumentNullException(nameof(rnd));
            }
            return _validTableRuleStyles[rnd.Next(_validTableRuleStyles.Length)];
        }

        internal static FixedSizeTableCell NextFixedSizeTableCell(this Random rnd)
        {
            if (rnd is null)
            {
                throw new ArgumentNullException(nameof(rnd));
            }
            return new FixedSizeTableCell(rnd.NextDouble() * 100, rnd.NextDouble() * 100);
        }

#pragma warning restore CA5394 // Do not use insecure randomness

    }
}
