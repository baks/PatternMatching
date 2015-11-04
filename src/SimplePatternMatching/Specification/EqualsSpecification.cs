using System;

namespace SimplePatternMatching.Specification
{
    public class EqualsSpecification<T> : PatternMatchSpecification
    {
        private readonly T pattern;

        public EqualsSpecification(T pattern)
        {
            if (pattern == null)
            {
                throw new ArgumentNullException(nameof(pattern));
            }
            this.pattern = pattern;
        }

        public bool IsSatisfiedBy(object arg) => pattern.Equals(arg);
    }

    public class EqualsSpecification<T1, T2> : PatternMatchSpecification<T1, T2>
    {
        private readonly T1 firstPattern;
        private readonly T2 secondPattern;

        public EqualsSpecification(T1 firstPattern, T2 secondPattern)
        {
            if (firstPattern == null)
            {
                throw new ArgumentNullException(nameof(firstPattern));
            }
            if (secondPattern == null)
            {
                throw new ArgumentNullException(nameof(secondPattern));
            }
            this.firstPattern = firstPattern;
            this.secondPattern = secondPattern;
        }

        public bool IsSatisfiedBy(T1 arg1, T2 arg2) => firstPattern.Equals(arg1) && secondPattern.Equals(arg2);
    }
}