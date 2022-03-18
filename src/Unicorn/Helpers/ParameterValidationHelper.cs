using System;

namespace Unicorn.Helpers
{
    internal static class ParameterValidationHelper
    {
        internal static void CheckDoubleValueBetweenZeroAndOne(double val, string name, string exceptionMessage)
        {
            if (val < 0 || val > 1)
            {
                throw new ArgumentOutOfRangeException(name, exceptionMessage);
            }
        }

        internal static void CheckBitCountIsValid(int count, string name, string exceptionMessage)
        {
            if (!(count == 1 || count == 2 || count == 4 || count == 8))
            {
                throw new ArgumentOutOfRangeException(name, exceptionMessage);
            }
        }
    }
}
