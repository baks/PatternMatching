namespace SimplePatternMatching.Specification
{
    public class MatchNullSpecification : PatternMatchSpecification
    {
        public bool IsSatisfiedBy(object arg) => arg == null;
    }

    public class MatchNullSpecification<T1, T2> : PatternMatchSpecification<T1, T2>
    {
        public bool IsSatisfiedBy(T1 arg1, T2 arg2) => arg1 == null && arg2 == null;
    }
}