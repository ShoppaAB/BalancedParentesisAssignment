using Xunit;

namespace TagEditorValidators
{
    public class BalancedParentesisValidatorTests
    {
        [Theory]
        [InlineData("", true)]
        [InlineData("NOP", true)]
        [InlineData("{[()]}", true)]
        [InlineData("calc(1+3)", true)]
        [InlineData("repeat[sentence_count, calc(2*word_count{sentence})]", true)]
        [InlineData("calc(1+3)*mean(1..1000)", true)]
        [InlineData("[", false)]
        [InlineData("()()]", false)]
        [InlineData("({[(]}))", false)]
        public void Passes_presented_tests(string input, bool expected)
        {
            ITagValidator sut = new BalancedParentesisValidator();

            var actual = sut.Validate(input);

            Assert.Equal(expected, actual);
        }
    }
}