// <copyright file="EnumerableUtilityTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace U07_Fundamentals_Tests.T_04
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using NUnit.Framework;
    using U07_Fundamentals.T_04;

    [TestFixture]
    public class EnumerableUtilityTests
    {
        [SetUp]
        public void SetUp()
        {
        }

        [TestCase("AAAABBBCCDAABBB", "ABCDAB")]
        [TestCase("12233", "123")]
        [TestCase("ABBCcAD", "ABCcAD")]
        public void UniqueInOrder_Tests_Equal_strings(IEnumerable<char> input, IEnumerable<char> expected)
        {
            Assert.AreEqual(expected, EnumerableUtility.UniqueInOrder<char>(input));
        }

        [TestCase]
        public void UniqueInOrder_Tests_Equal_Lists()
        {
            var t = new List<double> { 1.1, 2.2, 2.2, 3.3 };
            var e = new List<double> { 1.1, 2.2, 3.3 };
            Assert.AreEqual(e, EnumerableUtility.UniqueInOrder<double>(t));
        }
    }
}
