using Microsoft.VisualStudio.TestTools.UnitTesting;
using static NumbersExtension.NumbersExtension;
using System;

namespace NumbersExtension.MSTests
{
    [TestClass]
    public class NumbersExtensionMSTests
    {
        [TestMethod]
        public void InsertNumberIntoAnother_WithValidParameters_Result1600()
        {
            int numberSource=0;
            int numberIn=1480;
            int i=3;
            int j=10;
            int expectedResult = 1600;

            int functionResult = InsertNumberIntoAnother(numberSource, numberIn, i, j);

            Assert.AreEqual(expectedResult, functionResult);
        }

        [TestMethod]
        public void InsertNumberIntoAnother_WithValidParameters_Result554203816()
        {
            int numberSource = 554216104;
            int numberIn = 4460559;
            int i = 11;
            int j = 18;
            int expectedResult = 554203816;

            int functionResult = InsertNumberIntoAnother(numberSource, numberIn, i, j);

            Assert.AreEqual(expectedResult, functionResult);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertNumberIntoAnother_JIsOutOfRange_ThrowArgumentOutOfRangeException() =>
            InsertNumberIntoAnother(24, 15, 2, 33);

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertNumberIntoAnother_IIsOutOfRange_ThrowArgumentOutOfRangeException() =>
           InsertNumberIntoAnother(256, 968, -2, 16);

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertNumberIntoAnother_IIsHigherThanJ_ThrowArgumentException() =>
            InsertNumberIntoAnother(165, 248, 25, 3);
    }
}
