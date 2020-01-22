namespace NumbersExtension
{
    using System;

    /// <summary>
    /// An application entry point.
    /// </summary>
    public static class NumbersExtension
    {
        /// <summary>Inserts the number into another.</summary>
        /// <param name="numberSource">The number source.</param>
        /// <param name="numberIn">The number in.</param>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <returns>numberSource with inserted numberIn.</returns>
        /// <exception cref="ArgumentOutOfRangeException">i - i is less than zero
        /// or
        /// j - j is less than zero
        /// or
        /// i - i is higher than number of bits in int
        /// or
        /// j - j is higher than number of bits in int.</exception>
        /// <exception cref="ArgumentException">i is higher than j.</exception>
        public static int InsertNumberIntoAnother(int numberSource, int numberIn, int i, int j)
        {
            if (i < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(i), "i is less than zero");
            }

            if (j < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(j), "j is less than zero");
            }

            if (i > 31)
            {
                throw new ArgumentOutOfRangeException(nameof(i), "i is greater than number of bits in int");
            }

            if (j > 31)
            {
                throw new ArgumentOutOfRangeException(nameof(j), "j is greater than number of bits in int");
            }

            if (i > j)
            {
                throw new ArgumentException("i is higher than j");
            }

            if (i == 0 && j == 31)
            {
                return numberIn;
            }

            if (j == 31)
            {
                numberSource &= int.MaxValue;
            }

            int bitMaskForNumberIn, bitMaskForNumberSource;
            bitMaskForNumberIn = ~(int.MaxValue << CheckSubstraction(j + 1, i)) & int.MaxValue;
            int insertValue = (numberIn & bitMaskForNumberIn) << i;
            if (numberSource >= 0)
            {
                bitMaskForNumberSource = (int.MaxValue >> (31 - i)) | ((int.MaxValue << CheckSubstraction(j, -1)) & int.MaxValue);
            }
            else
            {
                bitMaskForNumberSource = (int.MaxValue >> (31 - i)) | (((int.MaxValue << CheckSubstraction(j, -1)) & int.MaxValue) | (int.MaxValue << 30));
            }

            int putOutValue = numberSource & bitMaskForNumberSource;
            putOutValue |= insertValue;
            return putOutValue;
        }

        /// <summary>Checks the substraction.</summary>
        /// <param name="x">The reduced value.</param>
        /// <param name="y">The substracted value.</param>
        /// <returns>The substraction of two values that doesn't exceed 31.</returns>
        public static int CheckSubstraction(int x, int y)
        {
            if (x - y > 31)
            {
                return 31;
            }
            else
            {
                return x - y;
            }
        }
    }
}