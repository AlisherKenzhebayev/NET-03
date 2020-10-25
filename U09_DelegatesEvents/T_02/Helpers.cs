// <copyright file="Helpers.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace U09_DelegatesEvents.T_02
{
    using System.Linq;

    public static class Helpers
    {
        public static bool HelperSumElements(int[] f, int[] s, Modes mode)
        {
            if (mode == Modes.Ascending)
            {
                return f.Sum() > s.Sum();
            }
            else
            {
                return f.Sum() < s.Sum();
            }
        }

        public static bool HelperMinElements(int[] f, int[] s, Modes mode)
        {
            if (mode == Modes.Ascending)
            {
                return f.Min() > s.Min();
            }
            else
            {
                return f.Min() < s.Min();
            }
        }

        public static bool HelperMaxElements(int[] f, int[] s, Modes mode)
        {
            if (mode == Modes.Ascending)
            {
                return f.Max() > s.Max();
            }
            else
            {
                return f.Max() < s.Max();
            }
        }
    }
}
