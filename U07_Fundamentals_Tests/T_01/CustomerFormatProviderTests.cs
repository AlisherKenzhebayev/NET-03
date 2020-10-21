// <copyright file="CustomerFormatProviderTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace U07_Fundamentals_Tests
{
    using System;
    using NUnit.Framework;
    using U07_Fundamentals;

    [TestFixture]
    public class CustomerFormatProviderTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("NFC", "Customer record: Jeffrey Richter, 1,000,000.00, +1 (425) 555-0100")]
        [TestCase("C", "Customer record: +1 (425) 555-0100")]
        [TestCase("NF", "Customer record: Jeffrey Richter, 1,000,000.00")]
        [TestCase("N", "Customer record: Jeffrey Richter")]
        [TestCase("R", "Customer record: 1000000")]
        public void CustomerFormatProvider_Test_Format(string f, string expected)
        {
            var n = new Customer("Jeffrey Richter", "1000000", "+1 (425) 555-0100");
            IFormatProvider fp = new CustomerFormatProvider();
            Assert.AreEqual(expected, string.Format(fp, "{0:" + f + "}", n));
        }
    }
}