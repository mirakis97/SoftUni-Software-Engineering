namespace Problem04.BalancedParentheses
{
    using System;
    using System.Collections.Generic;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            if (string.IsNullOrEmpty(parentheses) || parentheses.Length % 2 == 1)
            {
                return false;
            }

            Stack<char> breckets = new Stack<char>(parentheses.Length / 2);

            foreach (char currBrecket in parentheses)
            {
                char expectedBrecket = default;
                switch (currBrecket)
                {
                    case ')':
                        expectedBrecket = '(';
                        break;
                    case ']':
                        expectedBrecket = '[';
                        break;
                    case '}':
                        expectedBrecket = '{';
                        break;
                    default:
                        breckets.Push(currBrecket);
                        break;
                }
                if (expectedBrecket != default && breckets.Pop() != expectedBrecket)
                {
                    return false;
                }
               
            }
            return breckets.Count == 0;
        }
    }

}
