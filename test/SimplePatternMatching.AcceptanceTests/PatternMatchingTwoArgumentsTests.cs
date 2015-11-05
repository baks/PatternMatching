using System;
using Xunit;

namespace SimplePatternMatching.AcceptanceTests
{
    public class PatternMatchingTwoArgumentsTests
    {
        private const string NotChangedByTest = "Not changed by test";
        private const string DefaultInvocation = "Default invocation";
        private const string PatternAAnd3Invocation = "Invocation from pattern 'a' and 3";
        private const string PatternASecondInvocation = "Second invocation from pattern 'a'";
        private const string PatternBAnd5Invocation = "Invocation from pattern 'b' and 5";
        private const string PatternCAnd7Invocation = "Invocation from pattern 'c' and 7";
        private const string PredicatePatternInvocation = "Invocation from predicate";
        private const string NullPatternInvocation = "Null pattern invocation";

        private string state = NotChangedByTest;

        [Fact]
        public void ShouldCallProperActionWhenPatternMatches()
        {
            var action = new MatchAction<string, int>
            {
                {"a", 3, (s, i) => state = PatternAAnd3Invocation},
                {"b", 5, (s, i) => state = PatternBAnd5Invocation},
                {"c", 7, (s, i) => state = PatternCAnd7Invocation}
            }.Action;

            action("a", 3);

            AssertStateIs(PatternAAnd3Invocation);
        }

        [Fact]
        public void ShouldNotCallAnyActionWhenPatternDoesNotMatch()
        {
            var action = new MatchAction<string, int>
            {
                {"a", 3, (s, i) => state = PatternAAnd3Invocation},
                {"b", 5, (s, i) => state = PatternBAnd5Invocation}
            }.Action;

            action("c", 12);

            AssertStateIs(NotChangedByTest);
        }

        [Fact]
        public void ShouldCallDefaultActionWhenPatternDoesNotMatchAndDefaultIsSpecified()
        {
            var action = new MatchAction<string, int>
            {
                {"a", 3, (s, i) => state = PatternAAnd3Invocation},
                {"b", 5, (s, i) => state = PatternBAnd5Invocation},
                { Match.Default, (s, i) => state = DefaultInvocation }
            }.Action;

            action("c", 7);

            AssertStateIs(DefaultInvocation);
        }

        [Fact]
        public void ShouldEvaluatePredicatesForAllArgumentsWhenMatchingPatterns()
        {
            var action = new MatchAction<string, int>
            {
                {"a", 3, (s, i) => state = PatternAAnd3Invocation},
                {s => s.StartsWith("d"), i => i > 10 && i < 15, (s, i) => state = PredicatePatternInvocation},
                { Match.Default, (s, i) => state = DefaultInvocation }
            }.Action;

            action("dcx", 12);

            AssertStateIs(PredicatePatternInvocation);
        }

        [Fact]
        public void ShouldEvaluatePredicateForFirstArgumentWhenMatchingPatterns()
        {
            var action = new MatchAction<string, int>
            {
                {"a", 3, (s, i) => state = PatternAAnd3Invocation},
                {s => s.StartsWith("d"), 21, (s, i) => state = PredicatePatternInvocation},
                { Match.Default, (s, i) => state = DefaultInvocation }
            }.Action;

            action("dcx", 21);

            AssertStateIs(PredicatePatternInvocation);
        }

        [Fact]
        public void ShouldHandleNullPattern()
        {
            var action = new MatchAction<string, int?>
            {
                {"a", 3, (s, i) => state = PatternAAnd3Invocation},
                {Match.Null, (s, i) => state = NullPatternInvocation}
            }.Action;

            action(null, null);

            AssertStateIs(NullPatternInvocation);
        }

        private void AssertStateIs(string expectedState)
        {
            Assert.Equal(expectedState, state);
        }
    }
}
