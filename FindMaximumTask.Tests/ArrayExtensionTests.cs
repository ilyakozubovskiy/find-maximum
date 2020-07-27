﻿using System;
using System.Linq;
using NUnit.Framework;
using static FindMaximumTask.ArrayExtension;

#pragma warning disable CA1707

namespace FindMaximumTask.Tests
{
    public class ArrayExtensionTests
    {
        private int[] array;
        private int max;

        [SetUp]
        public void Setup()
        {
            this.max = 10_000_000;
            this.array = Enumerable.Range(1, this.max).ToArray();
        }

        [Order(2)]
        [TestCase(new int[] { 0, 50 }, ExpectedResult = 50)]
        [TestCase(new int[] { 100 }, ExpectedResult = 100)]
        [TestCase(new int[] { int.MaxValue, int.MaxValue, int.MinValue, 50 }, ExpectedResult = int.MaxValue)]
        [TestCase(new int[] { 50, int.MinValue, 25, 25 }, ExpectedResult = 50)]
        [TestCase(new int[] { 25, 25, 10, 25, 25, 100 }, ExpectedResult = 100)]
        [TestCase(new int[] { -50, -25, -20, -5, 500, -100 }, ExpectedResult = 500)]
        [TestCase(new int[] { -50, -25, -20, -5, -500, -100 }, ExpectedResult = -5)]
        [TestCase(new int[] { -50, -25, -20, 0, -500, -100 }, ExpectedResult = 0)]
        [TestCase(new int[] { 0, 0, 0, 0, 0, 0 }, ExpectedResult = 0)]
        [TestCase(new int[] { 0, 1, 0, 0, 0, 0 }, ExpectedResult = 1)]
        public int FindMaximumItem_ReturnMaximumElement(int[] source) => FindMaximum(source);

        [Test]
        public void FindMaximum_ArrayIsNull_ThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => FindMaximum(null), message: "source cannot be null.");

        [Test]
        public void FindMaximum_ArrayIsEmpty_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => FindMaximum(Array.Empty<int>()), message: "source cannot be empty.");

        [Test]
        [Order(0)]
        [Timeout(5_000)]
        public void FindMaximum_TestForLargeArray()
        {
            int expected = this.max;
            int actual = FindMaximum(this.array);
            Assert.AreEqual(expected, actual);
        }

        [Order(3)]
        [TestCase(new int[] { 0, 50 }, ExpectedResult = 50)]
        [TestCase(new int[] { 100 }, ExpectedResult = 100)]
        [TestCase(new int[] { int.MaxValue, int.MaxValue, int.MinValue, 50 }, ExpectedResult = int.MaxValue)]
        [TestCase(new int[] { 50, int.MinValue, 25, 25 }, ExpectedResult = 50)]
        [TestCase(new int[] { 25, 25, 10, 25, 25, 100 }, ExpectedResult = 100)]
        [TestCase(new int[] { -50, -25, -20, -5, 500, -100 }, ExpectedResult = 500)]
        [TestCase(new int[] { -50, -25, -20, -5, -500, -100 }, ExpectedResult = -5)]
        [TestCase(new int[] { -50, -25, -20, 0, -500, -100 }, ExpectedResult = 0)]
        [TestCase(new int[] { 0, 0, 0, 0, 0, 0 }, ExpectedResult = 0)]
        [TestCase(new int[] { 0, 1, 0, 0, 0, 0 }, ExpectedResult = 1)]
        public int FindMaximumRecursively_ReturnMaximumElement(int[] source) => FindMaximum(source);

        [Test]
        public void FindMaximumRecursively_ArrayIsNull_ThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => FindMaximumRecursively(null), message: "source cannot be null.");

        [Test]
        public void FindMaximumRecursively_ArrayIsEmpty_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => FindMaximumRecursively(Array.Empty<int>()), message: "source cannot be empty.");

        [Test]
        [Order(1)]
        [Timeout(5_000)]
        public void FindMaximumRecursively_TestForLargeArray()
        {
            int expected = this.max;
            int actual = FindMaximumRecursively(this.array);
            Assert.AreEqual(expected, actual);
        }
    }
}