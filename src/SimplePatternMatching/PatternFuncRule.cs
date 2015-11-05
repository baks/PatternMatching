using System;
using SimplePatternMatching.Specification;

namespace SimplePatternMatching
{
    public sealed class PatternFuncRule<TResult> : FuncRule<TResult>
    {
        private readonly Func<TResult> func;
        private readonly PatternMatchSpecification specification;

        public PatternFuncRule(Func<TResult> func, PatternMatchSpecification specification)
        {
            if (func == null)
            {
                throw new ArgumentNullException(nameof(func));
            }
            if (specification == null)
            {
                throw new ArgumentNullException(nameof(specification));
            }
            this.func = func;
            this.specification = specification;
        }

        public TResult Invoke()
        {
            return func();
        }

        public bool IsSatisfiedByPattern<T>(T against)
        {
            return specification.IsSatisfiedBy(against);
        }
    }

    public sealed class PatternFuncRule<TArg, TResult> : FuncRule<TArg, TResult>
    {
        private readonly Func<TArg, TResult> func;
        private readonly PatternMatchSpecification specification;

        public PatternFuncRule(Func<TArg, TResult> func, PatternMatchSpecification specification)
        {
            if (func == null)
            {
                throw new ArgumentNullException(nameof(func));
            }
            if (specification == null)
            {
                throw new ArgumentNullException(nameof(specification));
            }
            this.func = func;
            this.specification = specification;
        }

        public TResult Invoke(TArg arg)
        {
            return func(arg);
        }

        public bool IsSatisfiedByPattern(TArg against)
        {
            return specification.IsSatisfiedBy(against);
        }
    }
}