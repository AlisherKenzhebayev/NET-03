using NUnit.Framework;
using U10_GenericsCollections.T_08;

namespace U10_GenericsCollections_Tests.T_08
{
    [TestFixture]
    public class PolishReverse_Tests
    {
        [SetUp]
        public void SetUp()
        {
        }

        [TestCase("5 1 2 + 4 * + 3 - ", 14)]
        [TestCase("5 1 2 + 4 * + 3 -", 14)]
        [TestCase("1 3 -", -2)]
        public void ReversePolishCalculator_Test(string expression, int expected)
        {
            var t = new PolishCalculator(expression).Evaluate();
            Assert.AreEqual(expected, t);
        }
    }
}