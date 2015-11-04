namespace SimplePatternMatching
{
    public interface Rule<T>
    {
        void Invoke(T arg);

        bool IsSatisfiedByPattern(T against);
    }

    public interface Rule<T1, T2>
    {
        void Invoke(T1 arg1, T2 arg2);

        bool IsSatisfiedByPattern(T1 againstArg1, T2 againstArg2);
    }
}