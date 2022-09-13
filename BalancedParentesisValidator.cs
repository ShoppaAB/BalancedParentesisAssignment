using Microsoft.Extensions.Logging;

namespace TagEditorValidators
{
    public class BalancedParentesisValidator : ITagValidator
    {
        static readonly Dictionary<char, char> PARENTESIS_PAIRS = new() { { '{', '}' }, { '[', ']' }, { '(', ')' } };
        static readonly HashSet<char> CLOSING_PARENTESIS = new() { '}', ']', ')' };

        private readonly ILogger<BalancedParentesisValidator> logger;

        public BalancedParentesisValidator(ILogger<BalancedParentesisValidator> logger)
        {
            this.logger = logger;
        }

        public bool Validate(string input)
        {
            Stack<char> stack = new();

            var position = 0;
            foreach (var letter in input)
            {
                if (stack.TryPeek(out var currentStackItem) && currentStackItem == letter)
                {
                    stack.Pop();
                }
                else if (PARENTESIS_PAIRS.TryGetValue(letter, out var otherParentesis))
                {
                    stack.Push(otherParentesis);
                }
                else if (CLOSING_PARENTESIS.Contains(letter))
                {
                    logger.LogDebug("Found excess parentesis {letter} in position {index}.", letter, position);
                    return false;
                }
                else
                {
                    //The letter is not one of the tracked parentesis, so we just ignore it
                }
            }

            return !stack.Any();
        }
    }
}