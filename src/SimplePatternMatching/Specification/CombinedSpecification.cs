using System;

namespace SimplePatternMatching.Specification
{
    public class CombinedSpecification<T1, T2> : PatternMatchSpecification<T1, T2>
    {
        private readonly PatternMatchSpecification firstArgSpecification;
        private readonly PatternMatchSpecification secondArgSpecification;

        public CombinedSpecification(PatternMatchSpecification firstArgSpecification, PatternMatchSpecification secondArgSpecification)
        {
            if (firstArgSpecification == null)
            {
                throw new ArgumentNullException(nameof(firstArgSpecification));
            }
            if (secondArgSpecification == null)
            {
                throw new ArgumentNullException(nameof(secondArgSpecification));
            }
            this.firstArgSpecification = firstArgSpecification;
            this.secondArgSpecification = secondArgSpecification;
        }

        public bool IsSatisfiedBy(T1 arg1, T2 arg2)
            => firstArgSpecification.IsSatisfiedBy(arg1) && secondArgSpecification.IsSatisfiedBy(arg2);
    }
}