// <copyright file="UnitTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace U09_DelegatesEvents_Tests.T_02
{
    using NUnit.Framework;
    using U09_DelegatesEvents.T_02;
    using U09_DelegatesEvents.T_02.IComparer;

    // TODO: jagged Array
    [TestFixture]
    public class BubbleSortRowsTests
    {
        private RowsComparer comparer;

        [SetUp]
        public void SetUp()
        {
            this.comparer = new RowsComparer();
        }

        [TestCase]
        public void TestMaxElementsAsc()
        {
            int[][] array =
            {
                new[] { 7, 8, 9 },
                new[] { 4, 5, 6 },
                new[] { 1, 2, 3 },
            };

            int[][] expected =
            {
                new[] { 1, 2, 3 },
                new[] { 4, 5, 6 },
                new[] { 7, 8, 9 },
            };

            this.comparer.SortUsingBubble(array, new SortDelegate(Helpers.HelperMaxElements), Modes.Ascending);

            Assert.AreEqual(expected, array);
        }

        [TestCase]
        public void TestMaxElementsDes()
        {
            int[][] array =
            {
                new[] { 1, 2, 3 },
                new[] { 4, 5, 6 },
                new[] { 7, 8, 9 },
            };

            int[][] expected =
            {
                new[] { 7, 8, 9 },
                new[] { 4, 5, 6 },
                new[] { 1, 2, 3 },
            };

            this.comparer.SortUsingBubble(array, new SortDelegate(Helpers.HelperMaxElements), Modes.Descending);

            Assert.AreEqual(expected, array);
        }

        [TestCase]
        public void TestMinElementsAsc()
        {
            int[][] array =
            {
                new[] { 7, 8, 9 },
                new[] { 4, 5, 6 },
                new[] { 1, 2, 3 },
            };

            int[][] expected =
            {
                new[] { 1, 2, 3 },
                new[] { 4, 5, 6 },
                new[] { 7, 8, 9 },
            };

            this.comparer.SortUsingBubble(array, new SortDelegate(Helpers.HelperMinElements), Modes.Ascending);

            Assert.AreEqual(expected, array);
        }

        [TestCase]
        public void TestMinElementsDes()
        {
            int[][] array =
            {
                new[] { 1, 2, 3 },
                new[] { 4, 5, 6 },
                new[] { 7, 8, 9 },
            };

            int[][] expected =
            {
                new[] { 7, 8, 9 },
                new[] { 4, 5, 6 },
                new[] { 1, 2, 3 },
            };

            this.comparer.SortUsingBubble(array, new SortDelegate(Helpers.HelperMinElements), Modes.Descending);

            Assert.AreEqual(expected, array);
        }


        [TestCase]
        public void TestSumElementsAsc()
        {
            int[][] array =
            {
                new[] { 7, 8, 9 },
                new[] { 4, 5, 6 },
                new[] { 1, 2, 3 },
            };

            int[][] expected =
            {
                new[] { 1, 2, 3 },
                new[] { 4, 5, 6 },
                new[] { 7, 8, 9 },
            };

            this.comparer.SortUsingBubble(array, new SortDelegate(Helpers.HelperSumElements), Modes.Ascending);

            Assert.AreEqual(expected, array);
        }

        [TestCase]
        public void TestSumElementsDes()
        {
            int[][] array =
            {
                new[] { 1, 2, 3 },
                new[] { 4, 5, 6, 10 },
                new[] { 7, 8, 9 },
            };

            int[][] expected =
            {
                new[] { 4, 5, 6, 10 },
                new[] { 7, 8, 9 },
                new[] { 1, 2, 3 },
            };

            this.comparer.SortUsingBubble(array, (Helpers.HelperSumElements), Modes.Descending);

            Assert.AreEqual(expected, array);
        }
    }
}
