namespace SimplePatternMatching.Specification
{
    public interface PatternMatchSpecification
    {
        bool IsSatisfiedBy(object arg);
    }

    public interface PatternMatchSpecification<T1, T2>
    {
        bool IsSatisfiedBy(T1 arg1, T2 arg2);
    }
}