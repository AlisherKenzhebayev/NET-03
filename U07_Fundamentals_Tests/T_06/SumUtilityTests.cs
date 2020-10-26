// <copyright file="SumUtilityTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace U07_Fundamentals_Tests.T_06
{
    using NUnit.Framework;
    using U07_Fundamentals.T_06;

    [TestFixture]
    public class SumUtilityTests
    {
        [SetUp]
        public void SetUp()
        {
        }

        [TestCase("123123123123", "1111111111", "124234234234")]
        [TestCase("999999", "1111111111", "1112111110")]
        public void SumTwoBigOnesAndPositive_Test_Only_Positives(string a, string b, string exp)
        {
            Assert.AreEqual(exp, SumUtility.SumTwoBigOnesAndPositive(a, b));
        }
    }
}