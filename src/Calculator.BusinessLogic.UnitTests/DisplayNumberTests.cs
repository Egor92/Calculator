using NUnit.Framework;

namespace Calculator.BusinessLogic.UnitTests
{
	[TestFixture]
	public class DisplayNumberTests
	{
		[Test]
		[TestCase(false, "123", false, null, ExpectedResult = "123")]
		[TestCase(false, "123", true, null, ExpectedResult = "123,")]
		[TestCase(false, "123", false, "456", ExpectedResult = "123")]
		[TestCase(false, "123", true, "456", ExpectedResult = "123,456")]
		[TestCase(true, "123", false, null, ExpectedResult = "-123")]
		[TestCase(true, "123", true, null, ExpectedResult = "-123,")]
		[TestCase(true, "123", false, "456", ExpectedResult = "-123")]
		[TestCase(true, "123", true, "456", ExpectedResult = "-123,456")]
		public string TestToString(bool isNegative, string integerPart, bool hasComma, string fractionalPart)
		{
			//Arrange
			var displayNumber = new DisplayNumber
			{
				IsNegative = isNegative,
				IntegerPart = integerPart,
				HasComma = hasComma,
				FractionalPart = fractionalPart,
			};

			//Act
			var stringRepresentation = displayNumber.ToString();

			//Assert
			return stringRepresentation;
		}

		[Test]
		[TestCase(false, "123", false, null, ExpectedResult = 123)]
		[TestCase(false, "123", true, null, ExpectedResult = 123)]
		[TestCase(false, "123", false, "456", ExpectedResult = 123)]
		[TestCase(false, "123", true, "456", ExpectedResult = 123.456)]
		[TestCase(true, "123", false, null, ExpectedResult = -123)]
		[TestCase(true, "123", true, null, ExpectedResult = -123)]
		[TestCase(true, "123", false, "456", ExpectedResult = -123)]
		[TestCase(true, "123", true, "456", ExpectedResult = -123.456)]
		public double TestToDouble(bool isNegative, string integerPart, bool hasComma, string fractionalPart)
		{
			//Arrange
			var displayNumber = new DisplayNumber
			{
				IsNegative = isNegative,
				IntegerPart = integerPart,
				HasComma = hasComma,
				FractionalPart = fractionalPart,
			};

			//Act
			var value = displayNumber.ToDouble();

			//Assert
			return value;
		}
	}
}
