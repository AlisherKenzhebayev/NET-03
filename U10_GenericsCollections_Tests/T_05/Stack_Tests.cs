namespace U10_GenericsCollections_Tests.T_05
{
    using NUnit.Framework;
    using U10_GenericsCollections.T_05;
    
    [TestFixture]
    public class Stack_Tests
    {
        [SetUp]
        public void SetUp()
        {
        }

        [TestCase(5)]
        public void CollectionQueueTests(int length)
        {
            var a = new CollectionStack<int>();
            for (var i = 0; i < length; i++)
            {
                a.Push(10 * (i+1));
            }

            Assert.AreEqual(length, a.Count);
            var current = 0;
            
            foreach (var i in a)
            {
                Assert.AreEqual(10*(current + 1), i);
                current++;
            }
            
            for (var i = length - 1; i >= 0; i--)
            {
                Assert.AreEqual(10*(i+1), a.Pop());
            }
            
            Assert.AreEqual(true, a.IsEmpty());
        }
    }
}