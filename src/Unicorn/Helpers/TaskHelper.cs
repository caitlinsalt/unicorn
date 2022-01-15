using System;
using System.Threading.Tasks;

namespace Unicorn.Helpers
{
    /// <summary>
    /// Helper methods for async routines.
    /// </summary>
    public static class TaskHelper
    {
        /// <summary>
        /// Helper method for calling an async method (with one parameter) from a synchronous method and unwrapping any <see cref="AggregateException" />s thrown.
        /// </summary>
        /// <typeparam name="TP">Type of the async method's parameter.</typeparam>
        /// <typeparam name="TR">Return type of the async method (when awaited)</typeparam>
        /// <param name="f">The async method.</param>
        /// <param name="param1">The parameter to pass to the async method.</param>
        /// <returns>The result of the async method.</returns>
        public static TR UnwrapTask<TP, TR>(Func<TP, Task<TR>> f, TP param1)
        {
            if (f is null)
            {
                throw new ArgumentNullException(nameof(f));
            }
            try
            {
                return f(param1).Result;
            }
            catch (AggregateException ae)
            {
                foreach (var e in ae.Flatten().InnerExceptions)
                {
                    throw e;
                }
                throw;
            }
        }
    }
}
