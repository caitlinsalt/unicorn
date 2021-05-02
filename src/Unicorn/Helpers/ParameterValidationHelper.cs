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
    }
}
