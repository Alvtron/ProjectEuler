using System.Numerics;

namespace ProjectEuler.Mathematics.Functions
{
    /// <summary>
    /// The greatest common divisor (GCD) of two or more integers is the largest positive integer that divides each of the integers.
    /// </summary>
    /// <remarks>
    /// The greatest common divisor is also called the greatest common factor (GCF), highest common factor (HCF), greatest common measure (GCM), or highest common divisor.
    /// </remarks>
    public class GreatestCommonDivisor
    {
        /// <summary>
        /// Finds and returns the greatest common divisor of the specified <paramref name="firstNumber"/> and <paramref name="secondNumber"/>.
        /// </summary>
        /// <typeparam name="TNumber">The type of number.</typeparam>
        /// <param name="firstNumber">The first number.</param>
        /// <param name="secondNumber">The second number.</param>
        /// <returns>The greatest common divisor of the specified <paramref name="firstNumber"/> and <paramref name="secondNumber"/>.</returns>
        public static TNumber Of<TNumber>(TNumber firstNumber, TNumber secondNumber) 
            where TNumber : INumber<TNumber>
        {
            if (firstNumber == secondNumber)
            {
                return firstNumber;
            }

            if (TNumber.IsZero(firstNumber))
            {
                return secondNumber;
            }

            if (secondNumber == firstNumber - TNumber.One)
            {
                return TNumber.One;
            }

            while (!TNumber.IsZero(secondNumber))
            {
                var temp = secondNumber;
                secondNumber = firstNumber % secondNumber;
                firstNumber = temp;
            }

            return TNumber.Abs(firstNumber);
        }
    }
}
