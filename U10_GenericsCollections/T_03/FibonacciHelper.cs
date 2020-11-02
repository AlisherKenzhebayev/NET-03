// <copyright file="FibonacciHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace U10_GenericsCollections.T_03
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public static class FibonacciHelper
    {
        public static IEnumerable<int> Fibonacci(int n)
        {
            var v1 = 1;
            var v2 = 1;
            while (true)
            {
                if (v1 > n)
                {
                    yield break;
                }

                yield return v1;
                var t = v2;
                v2 += v1;
                v1 = t;
            }
        }
    }
}
