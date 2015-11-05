using System;
using System.Collections;
using SimplePatternMatching.Specification;

namespace SimplePatternMatching
{
    public sealed class MatchAction<T> : IEnumerable
    {
        private readonly PatternActionMatcher<T> actionMatcher = new PatternActionMatcher<T>(); 

        public Action<T> Action
        {
            get
            {
                return arg =>
                {
                    actionMatcher.Invoke(arg);
                };
            }
        }

        public void Add(T pattern, Action<T> action)
        {
            actionMatcher.Add(new PatternActionRule<T>(action, new EqualsSpecification<T>(pattern)));
        }

        public void Add(Predicate<T> predicate, Action<T> action)
        {
            actionMatcher.Add(new PatternActionRule<T>(action, new PredicateSpecification<T>(predicate)));
        }

        public void Add(Default @default, Action<T> action)
        {
            actionMatcher.DefaultRule(action);
        }

        public void Add(Null @null, Action<T> action)
        {
            actionMatcher.NullRule(action);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public sealed class MatchAction<T1, T2> : IEnumerable
    {
        private readonly PatternActionMatcher<T1, T2> actionMatcher = new PatternActionMatcher<T1, T2>();

        public Action<T1, T2> Action
        {
            get
            {
                return (arg1, arg2) =>
                {
                    actionMatcher.Invoke(arg1, arg2);
                };
            }
        }

        public void Add(T1 firstPattern, T2 secondPattern, Action<T1, T2> action)
        {
            actionMatcher.Add(new PatternActionRule<T1, T2>(action, new EqualsSpecification<T1, T2>(firstPattern, secondPattern)));
        }

        public void Add(Predicate<T1> firstPredicate, Predicate<T2> secondPredicate, Action<T1, T2> action)
        {
            actionMatcher.Add(new PatternActionRule<T1, T2>(action, new PredicateSpecification<T1, T2>(firstPredicate, secondPredicate)));
        }

        public void Add(Predicate<T1> firstPredicate, T2 secondPattern, Action<T1, T2> action)
        {
            actionMatcher.Add(new PatternActionRule<T1, T2>(action,
                new CombinedSpecification<T1, T2>(new PredicateSpecification<T1>(firstPredicate),
                    new EqualsSpecification<T2>(secondPattern))));
        }

        public void Add(T1 firstPattern, Predicate<T2> secondPredicate, Action<T1, T2> action)
        {
            actionMatcher.Add(new PatternActionRule<T1, T2>(action,
                new CombinedSpecification<T1, T2>(new EqualsSpecification<T1>(firstPattern),
                    new PredicateSpecification<T2>(secondPredicate))));
        }

        public void Add(Default @default, Action<T1, T2> action)
        {
            actionMatcher.DefaultRule(action);
        }

        public void Add(Null @null, Action<T1, T2> action)
        {
            actionMatcher.NullRule(action);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public sealed class Default
    {
    }

    public sealed class Null { }

    public static class Match
    {
        public static readonly Default Default = new Default();
        public static readonly Null Null = new Null();
    }
}
