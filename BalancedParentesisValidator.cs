namespace TagEditorValidators
{
    public class BalancedParentesisValidator : ITagValidator
    {
        static readonly Dictionary<char, char> PARENTESIS_PAIRS = new() { { '{', '}' }, { '[', ']' }, { '(', ')' } };
        static readonly HashSet<char> CLOSING_PARENTESIS = new() { '}', ']', ')' };

        public bool Validate(string input)
        {
            Stack<char> stack = new();

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
                    //Consider logging failure reason
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