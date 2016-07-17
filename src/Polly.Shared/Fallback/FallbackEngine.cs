using System;
using System.Collections.Generic;
using System.Linq;

namespace Polly.Fallback
{
    internal static partial class FallbackEngine
    {
        internal static TResult Implementation<TResult>(
            Func<TResult> action,
            Context context,
            IEnumerable<ExceptionPredicate> shouldHandleExceptionPredicates,
            IEnumerable<ResultPredicate<TResult>> shouldHandleResultPredicates,
            Action<DelegateResult<TResult>, Context> onFallback,
            Func<TResult> fallbackAction)
        {
            DelegateResult<TResult> delegateOutcome;

            try
            {
                delegateOutcome = new DelegateResult<TResult>(action());

                if (!shouldHandleResultPredicates.Any(predicate => predicate(delegateOutcome.Result)))
                {
                    return delegateOutcome.Result;
                }
            }
            catch (Exception ex)
            {
                if (!shouldHandleExceptionPredicates.Any(predicate => predicate(ex)))
                {
                    throw;
                }

                delegateOutcome = new DelegateResult<TResult>(ex);
            }

            onFallback(delegateOutcome, context);
            return fallbackAction();
        }
    }
}
