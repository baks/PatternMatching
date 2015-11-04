namespace SimplePatternMatching.Specification
{
    public class FalseSpecification : PatternMatchSpecification
    {
        public bool IsSatisfiedBy(object arg) => false;
    }

    public class FalseSpecification<T1,T2> : PatternMatchSpecification<T1,T2>
    {
        public bool IsSatisfiedBy(T1 arg1, T2 arg2) => false;
    }
}
