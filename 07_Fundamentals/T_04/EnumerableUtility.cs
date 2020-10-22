// <copyright file="EnumerableUtility.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace U07_Fundamentals.T_04
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;

    public static class EnumerableUtility
    {
        public static IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> input)
        {
            var retval = new List<T>();
            T previous = default(T);

            var item = input.GetEnumerator();
            var move = true;
            while (move)
            {
                move = item.MoveNext();
                if (!move)
                {
                    break;
                }

                // Compare and decide on writing
                if (!item.Current.Equals(previous))
                {
                    retval.Add(item.Current);
                }

                previous = item.Current;
            }

            return retval;
        }
    }
}
