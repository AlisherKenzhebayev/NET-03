namespace U07_Fundamentals_Tests.T_03
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using NUnit.Framework;
    using U07_Fundamentals.T_03;

    [TestFixture]
    class UrlFixKeyValues
    {
        [SetUp]
        public void SetUp()
        {
        }

        [TestCase("www.example.com", "key=value", "www.example.com?key=value")]
        [TestCase("www.example.com?key=value", "key2=value2", "www.example.com?key=value&key2=value2")]
        [TestCase("www.example.com?key=oldValue", "key=newValue", "www.example.com?key=newValue")]
        public void AddOrChangeUrlParameter_Test(string initUrl, string addPair, string expected)
        {
            Assert.AreEqual(expected, UrlUtility.AddOrChangeUrlParameter(initUrl, addPair));
        }
    }
}
