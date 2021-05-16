using System.Text;
using System.Text.RegularExpressions;

namespace Utility
{
    public static class Validation
    {
        public static void AppendError(this StringBuilder errors, bool condition, string message)
        {
            if (condition && (message.Length != 0))
                errors.AppendLine(message);
        }

        public static void ErrorCheck(this StringBuilder errors)
        {
            if (errors.Length != 0)
                throw new SystemException(errors.ToString());
        }

        public static bool IsRegexMatch(this string input, string pattern)
        {
            return Regex.IsMatch(input, pattern);
        }
    }
}
