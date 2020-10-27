namespace U10_GenericsCollections_Tests.T_01
{
    using NUnit.Framework;
    using System.Collections.ObjectModel;
    using U10_GenericsCollections.T_01;

    [TestFixture]
    public class BinarySearchTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void BinarySearch_Test_Strings()
        {
            var expected = 3;
            var array = new[] { "stringa", "stringa", "stringb", "stringc", "stringd", "stringx" };
            var search = "stringc";
            Assert.AreEqual(expected, BinarySearchHelper.BinarySearch<string>(array, search, 0, array.Length - 1));
        }

        [Test]
        public void BinarySearch_Test_Ints()
        {
            var expected = 2;
            var array = new[] { 1, 2, 3, 4 };
            var search = 3;
            Assert.AreEqual(expected, BinarySearchHelper.BinarySearch<int>(array, search, 0, array.Length - 1));
        }

        [Test]
        public void BinarySearch_Test_NoElements()
        {
            var expected = -1;
            var array = new[] { "stringa", "stringa", "stringd", "stringx", "stringc", "stringb" };
            var search = "stringaas";
            Assert.AreEqual(expected, BinarySearchHelper.BinarySearch<string>(array, search, 0, array.Length - 1));
        }
    }
}