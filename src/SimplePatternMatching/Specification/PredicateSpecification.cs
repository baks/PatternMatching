using System;

namespace SimplePatternMatching.Specification
{
    public class PredicateSpecification<T> : PatternMatchSpecification
    {
        private readonly Predicate<T> predicate;

        public PredicateSpecification(Predicate<T> predicate)
        {
            if (predicate == null)
            {
                throw new ArgumentNullException(nameof(predicate));
            }
            this.predicate = predicate;
        }

        public bool IsSatisfiedBy(object arg) => predicate((T)arg);
    }

    public class PredicateSpecification<T1, T2> : PatternMatchSpecification<T1, T2>
    {
        private readonly Predicate<T1> firstPredicate;
        private readonly Predicate<T2> secondPredicate; 

        public PredicateSpecification(Predicate<T1> firstPredicate, Predicate<T2> secondPredicate)
        {
            if (firstPredicate == null)
            {
                throw new ArgumentNullException(nameof(firstPredicate));
            }
            if (secondPredicate == null)
            {
                throw new ArgumentNullException(nameof(secondPredicate));
            }
            this.firstPredicate = firstPredicate;
            this.secondPredicate = secondPredicate;
        }

        public bool IsSatisfiedBy(T1 arg1, T2 arg2) => firstPredicate(arg1) && secondPredicate(arg2);
    }
}