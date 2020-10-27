namespace U10_GenericsCollections_Tests.T_03
{
    using NUnit;
    using NUnit.Compatibility;
    using NUnit.Framework;
    using System;
    using U10_GenericsCollections.T_03;

    [TestFixture]
    public class Fibonacci_Tests
    {
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void Fibonacci_Generation_Test() {
            var v1 = 1;
            var v2 = 1;
            foreach (var i in FibonacciHelper.Fibonacci(10))
            {
                Assert.AreEqual(v1, i);
                var t = v2;
                v2 += v1;
                v1 = t;
            }
        }
    }
}
