// <copyright file="GcdFinder.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace U09_DelegatesEvents.T_01
{
    using System;

    public class GcdFinder
    {
        private delegate int DelegateGCD(int a, int b);

        public int EuclidGcd(int x, int y)
        {
            var arr = new[] { x, y };
            return this.EuclidGcd(arr);
        }

        public int EuclidGcd(int x, int y, int z)
        {
            var arr = new[] { x, y, z };
            return this.EuclidGcd(arr);
        }

        public int EuclidGcd(int[] arr)
        {
            if (arr.Length < 1)
            {
                throw new ArgumentException("Array too short");
            }

            var retval = arr[0];
            foreach (var t in arr)
            {
                retval = this.CalculateGCD(retval, t, this.CalculateEuclidGCD);
            }

            return retval;
        }

        public int BinaryGcd(int x, int y)
        {
            var arr = new[] { x, y };
            return this.BinaryGcd(arr);
        }

        public int BinaryGcd(int x, int y, int z)
        {
            var arr = new[] { x, y, z };
            return this.BinaryGcd(arr);
        }

        public int BinaryGcd(int[] arr)
        {
            if (arr.Length < 1)
            {
                throw new ArgumentException("Array too short");
            }

            var retval = arr[0];
            foreach (var t in arr)
            {
                retval = this.CalculateGCD(retval, t, this.CalculateBinaryGcd);
            }

            return retval;
        }

        private int CalculateGCD(int x, int y, DelegateGCD d)
        {
            return d.Invoke(x, y);
        }

        private int CalculateEuclidGCD(int x, int y)
        {
            x = (x < 0) ? -x : x;
            y = (y < 0) ? -y : y;

            if (y == 0)
            {
                return x;
            }

            if (x < y)
            {
                var t = x;
                x = y;
                y = t;
            }

            return this.CalculateEuclidGCD(y, x % y);
        }

        private int CalculateBinaryGcd(int u, int v)
        {
            u = (u < 0) ? -u : u;
            v = (v < 0) ? -v : v;

            if (u == v)
            {
                return u;
            }

            if (u == 0)
            {
                return v;
            }

            if (v == 0)
            {
                return u;
            }

            if (u % 2 == 0)
            {
                if (v % 2 == 1)
                {
                    return this.CalculateBinaryGcd(u >> 1, v);
                }
                else
                {
                    return this.CalculateBinaryGcd(u >> 1, v >> 1) << 1;
                }
            }

            if (v % 2 == 0)
            {
                return this.CalculateBinaryGcd(u, v >> 1);
            }

            if (u > v)
            {
                return this.CalculateBinaryGcd(u - v, v);
            }

            return this.CalculateBinaryGcd(v, u % v);
        }
    }
}
