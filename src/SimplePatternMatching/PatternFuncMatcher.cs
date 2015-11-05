using System;
using System.Collections.Generic;
using System.Linq;
using SimplePatternMatching.Specification;

namespace SimplePatternMatching
{
    public sealed class PatternFuncMatcher<TArg, TResult>
    {
        private readonly List<FuncRule<TArg, TResult>> rules = new List<FuncRule<TArg, TResult>>();

        private FuncRule<TArg, TResult> defaultRule = new NullFuncRule<TArg, TResult>(new TrueSpecification());

        public void Add(FuncRule<TArg, TResult> rule)
        {
            rules.Add(rule);
        }

        public void DefaultRule(Func<TArg, TResult> func)
        {
            defaultRule = new PatternFuncRule<TArg, TResult>(func, new TrueSpecification());
        }

        public void NullRule(Func<TArg, TResult> func)
        {
            rules.Add(new PatternFuncRule<TArg, TResult>(func, new MatchNullSpecification()));
        }

        public Maybe<TResult> Invoke(TArg arg)
        {
            var result = RulesWithDefaultRuleAtTheEnd().FirstOrDefault(rule => rule.IsSatisfiedByPattern(arg)).Invoke(arg);
            return result == null ? Maybe.Nothing<TResult>() : Maybe.With(result);
        }

        private IEnumerable<FuncRule<TArg, TResult>> RulesWithDefaultRuleAtTheEnd()
        {
            return rules.Union(new[] { defaultRule });
        }
    }
}