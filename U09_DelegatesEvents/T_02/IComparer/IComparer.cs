// <copyright file="IComparer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace U09_DelegatesEvents.T_02.IComparer
{
    public interface IComparer
    {
        void SortUsingBubble(int[][] data, SortDelegate delegator, Modes mode);
    }
}
