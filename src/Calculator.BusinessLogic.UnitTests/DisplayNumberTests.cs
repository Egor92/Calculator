using NUnit.Framework;

namespace Calculator.BusinessLogic.UnitTests
{
    [TestFixture]
    public class DisplayNumberTests
    {
        [Test]
        [TestCase(false, "123", false, null, null, ExpectedResult = "123")]
        [TestCase(false, "123", true, null, null, ExpectedResult = "123,")]
        [TestCase(false, "123", false, "456", null, ExpectedResult = "123")]
        [TestCase(false, "123", true, "456", null, ExpectedResult = "123,456")]
        [TestCase(true, "123", false, null, null, ExpectedResult = "-123")]
        [TestCase(true, "123", true, null, null, ExpectedResult = "-123,")]
        [TestCase(true, "123", false, "456", null, ExpectedResult = "-123")]
        [TestCase(true, "123", true, "456", null, ExpectedResult = "-123,456")]
        [TestCase(true, "1", false, "", "+3", ExpectedResult = "-1E+3")]
        [TestCase(true, "1", true, "23456789", "+5", ExpectedResult = "-1,23456789E+5")]
        [TestCase(true, "1", true, "234", "-5", ExpectedResult = "-1,234E-5")]
        public string TestToString(bool isNegative, string integerPart, bool hasComma, string fractionalPart, string exponent)
        {
            //Arrange
            var displayNumber = new DisplayNumber
            {
                IsNegative = isNegative,
                IntegerPart = integerPart,
                HasComma = hasComma,
                FractionalPart = fractionalPart,
                Exponent = exponent,
            };

            //Act
            var stringRepresentation = displayNumber.ToString();

            //Assert
            return stringRepresentation;
        }

        [Test]
        [TestCase(false, "123", false, null, null, ExpectedResult = 123)]
        [TestCase(false, "123", true, null, null, ExpectedResult = 123)]
        [TestCase(false, "123", false, "456", null, ExpectedResult = 123)]
        [TestCase(false, "123", true, "456", null, ExpectedResult = 123.456)]
        [TestCase(true, "123", false, null, null, ExpectedResult = -123)]
        [TestCase(true, "123", true, null, null, ExpectedResult = -123)]
        [TestCase(true, "123", false, "456", null, ExpectedResult = -123)]
        [TestCase(true, "123", true, "456", null, ExpectedResult = -123.456)]
        [TestCase(true, "1", false, "", "+3", ExpectedResult = -1000)]
        [TestCase(true, "1", true, "23456789", "+5", ExpectedResult = -123456.789)]
        [TestCase(true, "1", true, "234", "-5", ExpectedResult = -0.00001234)]
        public double TestToDouble(bool isNegative, string integerPart, bool hasComma, string fractionalPart, string exponent)
        {
            //Arrange
            var displayNumber = new DisplayNumber
            {
                IsNegative = isNegative,
                IntegerPart = integerPart,
                HasComma = hasComma,
                FractionalPart = fractionalPart,
                Exponent = exponent,
            };

            //Act
            var value = displayNumber.ToDouble();

            //Assert
            return value;
        }
    }
}
