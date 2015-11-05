using System;
using SimplePatternMatching.Specification;

namespace SimplePatternMatching
{
    public sealed class NullFuncRule<TArg, TResult> : FuncRule<TArg, TResult>
    {
        private readonly PatternMatchSpecification specification;

        public NullFuncRule(PatternMatchSpecification specification)
        {
            if (specification == null)
            {
                throw new ArgumentNullException(nameof(specification));
            }
            this.specification = specification;
        }

        public bool IsSatisfiedByPattern(TArg against)
        {
            return specification.IsSatisfiedBy(against);
        }

        public TResult Invoke(TArg arg)
        {
            return default(TResult);
        }
    }
}