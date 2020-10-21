using System;
using System.Linq;
using System.Text;

#nullable enable
namespace U07_Fundamentals.T_02
{
    public static class StringUtility
    {
        public static void TitleCase(ref string input, string? exceptions = null)
        {
            var inputArray = input.ToLower().Split(' ');
            if (exceptions != null)
            {
                var exceptionsArray = exceptions.ToLower().Split(' ');
                for (var i = 0; i < input.Length; i++)
                {
                    if (exceptionsArray.Any(s => s.Equals(inputArray[i])))
                    {
                        // Do nothing
                    }
                    else
                    {
                        inputArray[i] = ToTitleCase(inputArray[i]);
                    }
                }
            }
            else
            {
                for (var i = 0; i < inputArray.Length; i++)
                {
                    inputArray[i] = ToTitleCase(inputArray[i]);
                }
            }

            input = string.Join(" ", input);
        }

        private static string ToTitleCase(string input)
        {
            return char.ToUpper(input[0]) + input.Substring(1, input.Length - 1);
        }
    }
}