using System.Linq;
using Xunit;

namespace SimplePatternMatching.AcceptanceTests
{
    public class PatternMatchingFuncTests
    {
        private const string NotChangedByTest = "Not changed by test";
        private const string DefaultInvocation = "Default invocation";
        private const string PatternAInvocation = "Invocation from pattern 'a'";
        private const string PatternASecondInvocation = "Second invocation from pattern 'a'";
        private const string PatternBInvocation = "Invocation from pattern 'b'";
        private const string PatternCInvocation = "Invocation from pattern 'c'";
        private const string PredicatePatternInvocation = "Invocation from predicate";
        private const string NullPatternInvocation = "Null pattern invocation";

        private string state = NotChangedByTest;

        [Fact]
        public void ShouldCallProperFuncWhenPatternMatches()
        {
            var func = new MatchFunc<string, string>
            {
                {"a", s => PatternAInvocation},
                {"b", s => PatternBInvocation},
                {"c", s => PatternCInvocation}
            }.Func;

            state = func("a").Single();

            AssertStateIs(PatternAInvocation);
        }


        [Fact]
        public void ShouldNotCallAnyFuncWhenPatternDoesNotMatch()
        {
            var func = new MatchFunc<string, string>
            {
                {"a", s => PatternAInvocation},
                {"b", s => PatternBInvocation}
            }.Func;

            var result = func("c");
            if (result.Any())
            {
                state = result.Single();
            }

            AssertStateIs(NotChangedByTest);
        }

        [Fact]
        public void ShouldCallDefaultFuncWhenPatternDoesNotMatchAndDefaultIsSpecified()
        {
            var func = new MatchFunc<string, string>
            {
                {"a", s => PatternAInvocation},
                {"b", s => PatternBInvocation},
                { Match.Default, s => DefaultInvocation }
            }.Func;

            state = func("c").Single();

            AssertStateIs(DefaultInvocation);
        }

        [Fact]
        public void ShouldInvokeOnlyFirstMatch()
        {
            var func = new MatchFunc<string, string>
            {
                {"a", s => PatternAInvocation},
                {"a", s => PatternASecondInvocation},
                { Match.Default, s => DefaultInvocation }
            }.Func;

            state = func("a").Single();

            AssertStateIs(PatternAInvocation);
        }

        [Fact]
        public void ShouldEvaluatePredicateWhenMatchingPatterns()
        {
            var func = new MatchFunc<string, string>
            {
                {"a", s => PatternAInvocation},
                {s => s.StartsWith("d"), s => PredicatePatternInvocation},
                { Match.Default, s => DefaultInvocation }
            }.Func;

            state = func("dcx").Single();

            AssertStateIs(PredicatePatternInvocation);
        }

        [Fact]
        public void ShouldHandleNullPattern()
        {
            var func = new MatchFunc<string, string>
            {
                {"a", s => PatternAInvocation},
                {Match.Null, s => NullPatternInvocation}
            }.Func;

            state = func(null).Single();

            AssertStateIs(NullPatternInvocation);
        }

        private void AssertStateIs(string expectedState)
        {
            Assert.Equal(expectedState, state);
        }
    }
}
