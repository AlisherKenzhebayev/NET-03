namespace U10_GenericsCollections_Tests.T_07
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using U10_GenericsCollections.T_07;

    [TestFixture]
    class BstTests
    {
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void BstCreating_Test_Transverse() {
            var bst = new SimpleBst<int>(6);
            for (int i = 0; i < 10; i++)
            {
                bst.Add(i);
            }

            var counter = 0;
            var str = "0 1 2 3 4 5 6 6 7 8 9".Split(" ");
            foreach (var item in bst)
            {
                Assert.AreEqual(str[counter], item.ToString());
                counter++;
            }
            for (int i = 7; i < 10; i++)
            {
                bst.Remove(i);
            }
            Assert.AreEqual("0 1 2 3 4 5 6 6 ", bst.ToString());
        }

        [Test]
        public void BstCreating_Test_Direct()
        {
            var bst = new SimpleBst<int>(6);
            bst.Enumerator = bst.DirectOrder;
            for (int i = 0; i < 10; i++)
            {
                bst.Add(i);
            }

            Assert.AreEqual("6 0 1 2 3 4 5 6 7 8 9 ", bst.ToString());
        }

        [Test]
        public void BstCreating_Test_Reverse()
        {
            var bst = new SimpleBst<int>(6);
            bst.Enumerator = bst.ReverseOrder;
            for (int i = 0; i < 10; i++)
            {
                bst.Add(i);
            }

            Assert.AreEqual("6 7 8 9 6 0 1 2 3 4 5 ", bst.ToString());
        }
    }
}
