// <copyright file="BinarySearchHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace U10_GenericCollections.Source.T_01
{
    using System;
    using System.Collections.Generic;

    public static class BinarySearchHelper
    {
        // Should return an Enumerator to the generic collection of T
        public static int BinarySearch<T>(IList<T> collection, T search, int left, int right)
            where T : IComparable
        {
            if (left > right)
            {
                return -1;
            }

            var middle = left + ((right - left) / 2);

            if (collection[middle].Equals(search))
            {
                return middle;
            }

            if (collection[middle].CompareTo(search) > 0)
            {
                return BinarySearch(collection, search, left, middle - 1);
            }

            return BinarySearch(collection, search, middle + 1, right);
        }
    }
}