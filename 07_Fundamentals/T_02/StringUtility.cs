// <copyright file="StringUtility.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace U07_Fundamentals.T_02
{
    using System;
    using System.Linq;
    using System.Text;

    public static class StringUtility
    {
        public static void TitleCase(ref string input, string? exceptions = null)
        {
            var inputArray = input.ToLower().Split(' ');
            if (exceptions != null)
            {
                var exceptionsArray = exceptions.ToLower().Split(' ');
                for (var i = 0; i < inputArray.Length; i++)
                {
                    if (i == 0)
                    {
                        inputArray[i] = ToTitleCase(inputArray[i]);
                    }
                    else if (exceptionsArray.Any(s => s.Equals(inputArray[i])))
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

            input = string.Join(" ", inputArray);
        }

        private static string ToTitleCase(string input)
        {
            return char.ToUpper(input[0]) + input.Substring(1, input.Length - 1);
        }
    }
}