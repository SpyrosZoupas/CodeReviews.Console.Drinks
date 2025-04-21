namespace Drinks.SpyrosZoupas
{
    public class Validator
    {
        internal static bool IsStringValid(string stringInput)
        {
            if (string.IsNullOrEmpty(stringInput))
                return false;

            return stringInput.All(c => char.IsLetter(c) || c == '/' || c == ' ');
        }

        internal static bool IsIdValid(string stringInput)
        {
            if (string.IsNullOrEmpty(stringInput))
                return false;

            return stringInput.All(char.IsDigit);
        }
    }
}
