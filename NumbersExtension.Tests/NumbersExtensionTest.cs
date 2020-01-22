using System;
using NUnit.Framework;
using static NumbersExtension.NumbersExtension;

namespace NumbersExtension.Tests
{
    public class NumbersExtensionTests
    {
        [TestCase(2728, 655, 3, 8, ExpectedResult = 2680)]
        [TestCase(554216104, 15, 0, 31, ExpectedResult = 15)]
        [TestCase(-55465467, 345346, 0, 31, ExpectedResult = 345346)]
        [TestCase(554216104, 4460559, 11, 18, ExpectedResult = 554203816)]
        [TestCase(-1, 0, 31, 31, ExpectedResult = 2147483647)]
        [TestCase(-2147483648, 2147483647, 0, 30, ExpectedResult = -1)]
        [TestCase(-2223, 5440, 18, 23, ExpectedResult = -16517295)]
        [TestCase(2147481425, 5440, 18, 23, ExpectedResult = 2130966353)]
        [TestCase(0,1480,3,10,ExpectedResult = 1600)]
        [TestCase(15976,0,5,8,ExpectedResult =15880)]
        [TestCase(4,31,0,0,ExpectedResult =5)]
        [TestCase(63,63,0,0,ExpectedResult =63)]
        public int InsertNumberIntoAnother_WithAllValidParameters(int numberSource, int numberIn, int i, int j) =>
            InsertNumberIntoAnother(numberSource, numberIn, i, j);

        [Test]
        public void InsertNumberIntoAnother_I_GreaterThan_J_ThrowArgumentException() =>
            Assert.Throws<ArgumentException>(() => InsertNumberIntoAnother(256798, 190, 16, 8), "i is greater than j.");

        [Test]
        public void InsertNumberIntoAnother_J_OutOfRange_ThrowArgumentOutOfRangeException() =>
            Assert.Throws<ArgumentOutOfRangeException>(() => InsertNumberIntoAnother(67, 56, 0, 32));
        [Test]
        public void InsertNumberIntoAnother_I_OutOfRange_ThrowArgumentOutOfRangeException() =>
            Assert.Throws<ArgumentOutOfRangeException>(() => InsertNumberIntoAnother(67, 56, 32, 32));
    }
}