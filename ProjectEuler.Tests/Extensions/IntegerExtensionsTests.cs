using NUnit.Framework;
using ProjectEuler.Extensions;

namespace ProjectEuler.Tests.Extensions
{
    public class IntegerExtensionsTests
    {
        [Test]
        public void Length_PositiveNumber_ReturnsCorrectLength()
        {
            // ARRANGE
            const int number = 1234;
            const int actualLength = 4;

            // ACT
            var length = number.Length();

            // ASSERT
            Assert.That(length, Is.EqualTo(actualLength));
        }

        [Test]
        public void Length_NegativeNumber_ReturnsCorrectLength()
        {
            // ARRANGE
            const int number = -12345;
            const int actualLength = 5;

            // ACT
            var length = number.Length();

            // ASSERT
            Assert.That(length, Is.EqualTo(actualLength));
        }

        [Test]
        public void FirstDigits_PositiveNumber_ReturnsCorrectLength()
        {
            // ARRANGE
            const int number = 123456789;
            const int numberOfDigits = 3;
            const int actualDigits = 123;

            // ACT
            var digits = number.FirstDigits(numberOfDigits);

            // ASSERT
            Assert.That(digits, Is.EqualTo(actualDigits));
        }

        [Test]
        public void FirstDigits_NegativeNumber_ReturnsCorrectLength()
        {
            // ARRANGE
            const int number = -123456789;
            const int numberOfDigits = 4;
            const int actualDigits = -1234;

            // ACT
            var digits = number.FirstDigits(numberOfDigits);

            // ASSERT
            Assert.That(digits, Is.EqualTo(actualDigits));
        }

        [Test]
        public void LastDigits_PositiveNumber_ReturnsCorrectLength()
        {
            // ARRANGE
            const int number = 123456789;
            const int numberOfDigits = 5;
            const int actualDigits = 56789;

            // ACT
            var digits = number.LastDigits(numberOfDigits);

            // ASSERT
            Assert.That(digits, Is.EqualTo(actualDigits));
        }

        [Test]
        public void LastDigits_NegativeNumber_ReturnsCorrectLength()
        {
            // ARRANGE
            const int number = -123456789;
            const int numberOfDigits = 6;
            const int actualDigits = -456789;

            // ACT
            var digits = number.LastDigits(numberOfDigits);

            // ASSERT
            Assert.That(digits, Is.EqualTo(actualDigits));
        }
    }
}
