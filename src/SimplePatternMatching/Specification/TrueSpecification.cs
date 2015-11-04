namespace SimplePatternMatching.Specification
{
    public class TrueSpecification : PatternMatchSpecification
    {
        public bool IsSatisfiedBy(object arg) => true;
    }

    public class TrueSpecification<T1, T2> : PatternMatchSpecification<T1, T2>
    {
        public bool IsSatisfiedBy(T1 arg1, T2 arg2) => true;
    }
}
