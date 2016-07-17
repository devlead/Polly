#if SUPPORTS_ASYNC

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Polly.Shared.Utilities
{
    /// <summary>
    /// Task .
    /// </summary>
    public static class TaskHelper
    {
        /// <summary>
        /// Defines a completed Task for use as a completed, empty asynchronous delegate.
        /// </summary>
#if SUPPORTS_ASYNC_40
        public static Task EmptyTask = TaskEx.FromResult(true);
#else
        public static Task EmptyTask = Task.FromResult(true);
#endif

    }
}

#endif