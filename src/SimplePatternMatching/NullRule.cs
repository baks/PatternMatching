using System;
using SimplePatternMatching.Specification;

namespace SimplePatternMatching
{
    public class NullRule<T> : Rule<T>
    {
        private readonly PatternMatchSpecification specification;

        public NullRule(PatternMatchSpecification specification)
        {
            if (specification == null)
            {
                throw new ArgumentNullException(nameof(specification));
            }
            this.specification = specification;
        }

        public bool IsSatisfiedByPattern(T against)
        {
            return specification.IsSatisfiedBy(against);
        }

        public void Invoke(T arg)
        {
        }
    }

    public class NullRule<T1, T2> : Rule<T1, T2>
    {
        private readonly PatternMatchSpecification<T1, T2> specification;

        public NullRule(PatternMatchSpecification<T1,T2> specification)
        {
            if (specification == null)
            {
                throw new ArgumentNullException(nameof(specification));
            }
            this.specification = specification;
        }

        public bool IsSatisfiedByPattern(T1 againstArg1, T2 againstArg2)
        {
            return specification.IsSatisfiedBy(againstArg1, againstArg2);
        }

        public void Invoke(T1 arg1, T2 arg2)
        {
        }
    }
}