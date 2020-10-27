namespace U10_GenericsCollections_Tests.T_02
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using U10_GenericsCollections.T_02;

    [TestFixture]
    public class FrequencyFileTests
    {
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void Frequency_Test_WithFilePath() 
        {
            var filename = "InputTest.txt";
            var path = Environment.CurrentDirectory;
            FileStream fileStream = File.OpenRead(path + "../../../../T_02/" + filename);
            Dictionary<string, int> retVal = (Dictionary<string, int>)FrequencyHelper.Frequency(fileStream).Result;
            var compValue = 0;
            retVal.TryGetValue("Lorem", out compValue);
            Assert.AreEqual(3, compValue);
        }
    }
}