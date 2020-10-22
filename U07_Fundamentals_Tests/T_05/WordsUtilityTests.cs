// <copyright file="WordsUtilityTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace U07_Fundamentals_Tests.T_05
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using NUnit.Framework;
    using U07_Fundamentals.T_05;

    [TestFixture]
    public class WordsUtilityTests
    {
        [SetUp]
        public void SetUp()
        {
        }

        [TestCase("The greatest victory is that which requires no battle", "battle no requires which that is victory greatest The")]
        [TestCase("Me. no longer wait", "wait longer no Me.")]
        public void UniqueInOrder_Tests_Equal_strings(string input, string expected)
        {
            WordsUtility.ReverseWords(ref input);
            Assert.AreEqual(expected, input);
        }
    }
}
