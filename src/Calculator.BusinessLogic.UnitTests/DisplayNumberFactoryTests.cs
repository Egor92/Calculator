using NUnit.Framework;

namespace Calculator.BusinessLogic.UnitTests
{
	[TestFixture]
	public class DisplayNumberFactoryTests
	{
		[Test]
		[TestCase(false, "123", false, "", "123")]
		[TestCase(false, "123", true, "", "123,")]
		[TestCase(false, "123", false, "", "123")]
		[TestCase(false, "123", true, "456", "123,456")]
		[TestCase(true, "123", false, "", "-123")]
		[TestCase(true, "123", true, "", "-123,")]
		[TestCase(true, "123", false, "", "-123")]
		[TestCase(true, "123", true, "456", "-123,456")]
		public void TestCreate(bool isNegative, string integerPart, bool hasComma, string fractionalPart, string displayValue)
		{
			//Act
			var displayNumber = DisplayNumberFactory.Create(displayValue);

			//Assert
			Assert.That(displayNumber.IsNegative, Is.EqualTo(isNegative));
			Assert.That(displayNumber.IntegerPart, Is.EqualTo(integerPart));
			Assert.That(displayNumber.HasComma, Is.EqualTo(hasComma));
			Assert.That(displayNumber.FractionalPart, Is.EqualTo(fractionalPart));
		}
	}
}
