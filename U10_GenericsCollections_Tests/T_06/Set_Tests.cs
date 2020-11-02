namespace U10_GenericsCollections_Tests.T_06
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using U10_GenericsCollections.T_06;

    [TestFixture]
    public class Set_Tests
    {
        [SetUp]
        public void SetUp()
        {
        }

        [TestCase(5)]
        public void CollectionSetTests(int length)
        {
            var a = new CollectionSet<int>();
            for (var i = 0; i < length; i++)
            {
                a.Add(10 * (i + 1));
            }
            a.Add(10);

            Assert.AreEqual(length, a.Count);
            var current = 0;

            foreach (var i in a)
            {
                Assert.AreEqual(10 * (current + 1), i);
                current++;
            }

            Assert.AreEqual(true, a.Contains(50));

            for (var i = length - 1; i >= 0; i--)
            {
                Assert.AreEqual(true, a.Remove(10 * (i + 1)));            
                Assert.AreEqual(false, a.Contains(10 * (i + 1)));
            }
        }
    }
}
