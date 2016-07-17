using System;
using System.Collections.Generic;
using Polly.Utilities;

namespace Polly.Fallback
{
    /// <summary>
    /// A fallback policy that can be applied to delegates.
    /// </summary>
    public partial class FallbackPolicy : ContextualPolicy
    {
        internal FallbackPolicy(Action<Action, Context> exceptionPolicy, IEnumerable<ExceptionPredicate> exceptionPredicates)
            : base(exceptionPolicy, exceptionPredicates)
        {
        }
    }

    /// <summary>
    /// A fallback policy that can be applied to delegates returning a value of type <typeparam name="TResult"/>.
    /// </summary>
    public partial class FallbackPolicy<TResult> : ContextualPolicy<TResult>
    {
        internal FallbackPolicy(
            Func<Func<TResult>, Context, TResult> executionPolicy,
            IEnumerable<ExceptionPredicate> exceptionPredicates,
            IEnumerable<ResultPredicate<TResult>> resultPredicates
            ) : base(executionPolicy, exceptionPredicates, resultPredicates)
        {
        }
    }
}