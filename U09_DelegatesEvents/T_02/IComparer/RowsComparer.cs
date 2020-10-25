// <copyright file="RowsComparer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace U09_DelegatesEvents.T_02.IComparer
{
    public class RowsComparer : IComparer
    {
        public RowsComparer()
        {
        }

        public void SortUsingBubble(int[][] data, SortDelegate delegator, Modes mode = Modes.Ascending)
        {
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data.Length - i - 1; j++)
                {
                    if (delegator(data[j], data[j + 1], mode))
                    {
                        var t = data[j];
                        data[j] = data[j + 1];
                        data[j + 1] = t;
                    }
                }
            }
        }
    }
}
