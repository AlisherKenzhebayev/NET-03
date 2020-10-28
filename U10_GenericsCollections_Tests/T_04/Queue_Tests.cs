using System;

namespace U10_GenericsCollections_Tests.T_04
{
    using NUnit.Framework;
    using U10_GenericsCollections.T_04;
    
    [TestFixture]
    public class Queue_Tests
    {
        [SetUp]
        public void SetUp()
        {
        }

        [TestCase(5)]
        public void CollectionQueueTests(int length)
        {
            var a = new CollectionQueue<int>();
            for (var i = 0; i < length; i++)
            {
                a.Enqueue(10 * (i+1));
            }

            Assert.AreEqual(length, a.Count);
            var current = 0;
            
            foreach (var i in a)
            {
                Assert.AreEqual(10*(current + 1), i);
                current++;
            }
            
            for (var i = 0; i < length; i++)
            {
                Assert.AreEqual(10*(i+1), a.Dequeue());
            }
            
            Assert.AreEqual(true, a.IsEmpty());
        }
    }
}