using System;
using System.Collections;
using SimplePatternMatching.Specification;

namespace SimplePatternMatching
{
    public sealed class MatchFunc<T, TResult> : IEnumerable
    {
        private readonly PatternFuncMatcher<T, TResult> funcMatcher = new PatternFuncMatcher<T, TResult>();

        public Func<T, Maybe<TResult>> Func
        {
            get { return arg => funcMatcher.Invoke(arg); }
        }

        public void Add(T pattern, Func<T, TResult> func)
        {
            funcMatcher.Add(new PatternFuncRule<T, TResult>(func, new EqualsSpecification<T>(pattern)));
        }

        public void Add(Predicate<T> predicate, Func<T, TResult> func)
        {
            funcMatcher.Add(new PatternFuncRule<T, TResult>(func, new PredicateSpecification<T>(predicate)));
        }

        public void Add(Default @default, Func<T, TResult> func)
        {
            funcMatcher.DefaultRule(func);
        }

        public void Add(Null @null, Func<T, TResult> func)
        {
            funcMatcher.NullRule(func);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
