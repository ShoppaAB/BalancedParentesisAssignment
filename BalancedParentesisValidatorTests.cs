using Xunit;

namespace TagEditorValidators
{
    public class BalancedParentesisValidatorTests
    {
        [Fact]
        public void works()
        {
            ITagValidator sut = new BalancedParentesisValidator();

            var actual = sut.Validate("");

            Assert.True(actual);
        }
    }
}