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

    public interface FuncRule<TResult>
    {
        TResult Invoke();

        bool IsSatisfiedByPattern<T>(T against);
    }

    public interface FuncRule<TArg, TResult>
    {
        TResult Invoke(TArg arg);

        bool IsSatisfiedByPattern(TArg against);
    }
}