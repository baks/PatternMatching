using Xunit;

namespace SimplePatternMatching.AcceptanceTests
{
    public class PatternMatchingTests
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
        public void ShouldCallProperActionWhenPatternMatches()
        {
            var action = new Match<string>
            {
                {"a", s => state = PatternAInvocation},
                {"b", s => state = PatternBInvocation},
                {"c", s => state = PatternCInvocation}
            }.Action;

            action("a");

            AssertStateIs(PatternAInvocation);
        }

        [Fact]
        public void ShouldNotCallAnyActionWhenPatternDoesNotMatch()
        {
            var action = new Match<string>
            {
                {"a", s => state = PatternAInvocation},
                {"b", s => state = PatternBInvocation}
            }.Action;

            action("c");

            AssertStateIs(NotChangedByTest);
        }

        [Fact]
        public void ShouldCallDefaultActionWhenPatternDoesNotMatchAndDefaultIsSpecified()
        {
            var action = new Match<string>
            {
                {"a", s => state = PatternAInvocation},
                {"b", s => state = PatternBInvocation},
                { Match.Default, s => state = DefaultInvocation }
            }.Action;

            action("c");

            AssertStateIs(DefaultInvocation);
        }

        [Fact]
        public void ShouldInvokeOnlyFirstMatch()
        {
            var action = new Match<string>
            {
                {"a", s => state = PatternAInvocation},
                {"a", s => state = PatternASecondInvocation},
                { Match.Default, s => state = DefaultInvocation }
            }.Action;

            action("a");

            AssertStateIs(PatternAInvocation);
        }

        [Fact]
        public void ShouldEvaluatePredicateWhenMatchingPatterns()
        {
            var action = new Match<string>
            {
                {"a", s => state = PatternAInvocation},
                {s => s.StartsWith("d"), s => state = PredicatePatternInvocation},
                { Match.Default, s => state = DefaultInvocation }
            }.Action;

            action("dcx");

            AssertStateIs(PredicatePatternInvocation);
        }

        [Fact]
        public void ShouldHandleNullPattern()
        {
            var action = new Match<string>
            {
                {"a", s => state = PatternAInvocation},
                {Match.Null, s => state = NullPatternInvocation}
            }.Action;

            action(null);

            AssertStateIs(NullPatternInvocation);
        }

        private void AssertStateIs(string expectedState)
        {
            Assert.Equal(expectedState, state);
        }
    }
}
