// <copyright file="WordsUtility.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace U07_Fundamentals.T_05
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class WordsUtility
    {
        public static void ReverseWords(ref string input)
        {
            var enums = input.Split(' ').ToList<string>();
            var numer = enums.GetEnumerator();
            var temp = ReverseHelper(numer);
            input = temp.Substring(0, temp.Length - 1);
        }

        private static string ReverseHelper(IEnumerator<string> enums)
        {
            var retval = string.Empty;
            var current = enums.Current;
            if (enums.MoveNext())
            {
                retval += ReverseHelper(enums);
            }
            else
            {
                return current;
            }

            retval += " " + current;
            return retval;
        }
    }
}
