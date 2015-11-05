using System;
using SimplePatternMatching.Specification;

namespace SimplePatternMatching
{
    public class PatternActionRule<T> : Rule<T>
    {
        private readonly Action<T> action;
        private readonly PatternMatchSpecification specification; 

        public PatternActionRule(Action<T> action, PatternMatchSpecification specification)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }
            if (specification == null)
            {
                throw new ArgumentNullException(nameof(specification));
            }
            this.action = action;
            this.specification = specification;
        }

        public void Invoke(T arg)
        {
            action(arg);
        }

        public bool IsSatisfiedByPattern(T arg)
        {
            return specification.IsSatisfiedBy(arg);
        }
    }

    public class PatternActionRule<T1, T2> : Rule<T1, T2>
    {
        private readonly Action<T1, T2> action;
        private readonly PatternMatchSpecification<T1, T2> specification;

        public PatternActionRule(Action<T1, T2> action, PatternMatchSpecification<T1,T2> specification)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }
            if (specification == null)
            {
                throw new ArgumentNullException(nameof(specification));
            }
            this.action = action;
            this.specification = specification;
        }

        public void Invoke(T1 arg1, T2 arg2)
        {
            action(arg1, arg2);
        }

        public bool IsSatisfiedByPattern(T1 againstArg1, T2 againstArg2)
        {
            return specification.IsSatisfiedBy(againstArg1, againstArg2);
        }
    }
}