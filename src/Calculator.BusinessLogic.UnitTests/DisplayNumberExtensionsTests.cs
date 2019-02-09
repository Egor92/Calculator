using NUnit.Framework;

namespace Calculator.BusinessLogic.UnitTests
{
	[TestFixture]
	public class DisplayNumberExtensionsTests
	{
		[Test]
		[TestCase("0", ExpectedResult = "0")]
		[TestCase("1", ExpectedResult = "0")]
		[TestCase("12", ExpectedResult = "1")]
		[TestCase("-12", ExpectedResult = "-1")]
		[TestCase("-1", ExpectedResult = "0")]
		[TestCase("0,", ExpectedResult = "0")]
		[TestCase("1,", ExpectedResult = "1")]
		[TestCase("0,0", ExpectedResult = "0,")]
		[TestCase("1,0", ExpectedResult = "1,")]
		[TestCase("1,23", ExpectedResult = "1,2")]
		[TestCase("-1,23", ExpectedResult = "-1,2")]
		public string TestClearLastSymbol(string displayValue)
		{
			//Arrange
			var displayNumber = DisplayNumberFactory.Create(displayValue);

			//Act
			displayNumber.ClearLastSymbol();

			//Assert
			return displayNumber.ToString();
		}
	}
}
