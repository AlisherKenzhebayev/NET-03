namespace U07_Fundamentals_Tests.T_02
{
    using NUnit.Framework;
    using U07_Fundamentals;
    using U07_Fundamentals.T_02;

    [TestFixture]
    public class StringToTitleTests
    {
        [SetUp]
        public void SetUp()
        {
        }


        [TestCase("THE WIND IN THE WILLOWS", "The In", "The Wind in the Willows")]
        [TestCase("a clash of KINGS", "a an the of", "A Clash of Kings")]
        public void StringToTitleCase_Test_Full_Correct(string input, string exception, string expected)
        {
            StringUtility.TitleCase(ref input, exception);
            Assert.AreEqual(expected, input);
        }

        [TestCase("the quick brown fox", "The Quick Brown Fox")]
        public void StringToTitleCase_Test_Not_Full_Correct(string input, string expected)
        {
            StringUtility.TitleCase(ref input);
            Assert.AreEqual(expected, input);
        }
    }
}