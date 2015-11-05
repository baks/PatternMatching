using System;
using System.Collections.Generic;
using System.Linq;
using SimplePatternMatching.Specification;

namespace SimplePatternMatching
{
    public class PatternActionMatcher<T>
    {
        private readonly List<Rule<T>> rules = new List<Rule<T>>();

        private Rule<T> defaultRule = new NullRule<T>(new TrueSpecification());

        public void Add(Rule<T> rule)
        {
            rules.Add(rule);
        }

        public void DefaultRule(Action<T> action)
        {
            defaultRule = new PatternActionRule<T>(action, new TrueSpecification());
        }

        public void NullRule(Action<T> action)
        {
            rules.Add(new PatternActionRule<T>(action, new MatchNullSpecification()));
        }

        public void Invoke(T arg)
        {
            RulesWithDefaultRuleAtTheEnd().FirstOrDefault(rule => rule.IsSatisfiedByPattern(arg))?.Invoke(arg);
        }

        private IEnumerable<Rule<T>> RulesWithDefaultRuleAtTheEnd()
        {
            return rules.Union(new[] {defaultRule});
        }
    }

    public class PatternActionMatcher<T1, T2>
    {
        private readonly List<Rule<T1, T2>> rules = new List<Rule<T1, T2>>();

        private Rule<T1, T2> defaultRule = new NullRule<T1, T2>(new TrueSpecification<T1, T2>());

        public void Add(Rule<T1, T2> rule)
        {
            rules.Add(rule);
        }

        public void DefaultRule(Action<T1,T2> action)
        {
            defaultRule = new PatternActionRule<T1, T2>(action, new TrueSpecification<T1, T2>());
        }

        public void NullRule(Action<T1, T2> action)
        {
            rules.Add(new PatternActionRule<T1, T2>(action, new MatchNullSpecification<T1, T2>()));
        }

        public void Invoke(T1 arg1, T2 arg2)
        {
            RulesWithDefaultRuleAtTheEnd().FirstOrDefault(rule => rule.IsSatisfiedByPattern(arg1, arg2))?.Invoke(arg1, arg2);
        }

        private IEnumerable<Rule<T1, T2>> RulesWithDefaultRuleAtTheEnd()
        {
            return rules.Union(new[] { defaultRule });
        }
    }
}