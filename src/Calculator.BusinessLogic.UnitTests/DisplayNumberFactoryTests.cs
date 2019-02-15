using NUnit.Framework;

namespace Calculator.BusinessLogic.UnitTests
{
    [TestFixture]
    public class DisplayNumberFactoryTests
    {
        [Test]
        [TestCase(false, "123", false, "", "", "123")]
        [TestCase(false, "123", true, "", "", "123,")]
        [TestCase(false, "123", false, "", "", "123")]
        [TestCase(false, "123", true, "456", "", "123,456")]
        [TestCase(true, "123", false, "", "", "-123")]
        [TestCase(true, "123", true, "", "", "-123,")]
        [TestCase(true, "123", false, "", "", "-123")]
        [TestCase(true, "123", true, "456", "", "-123,456")]
        [TestCase(true, "1", false, "", "+3", "-1E+3")]
        [TestCase(true, "1", true, "23456789", "+5", "-1,23456789E+5")]
        [TestCase(true, "1", true, "234", "-5", "-1,234E-5")]
        public void TestCreate(bool isNegative, string integerPart, bool hasComma, string fractionalPart, string exponent, string displayValue)
        {
            //Act
            var displayNumber = DisplayNumberFactory.Create(displayValue);

            //Assert
            Assert.That(displayNumber.IsNegative, Is.EqualTo(isNegative));
            Assert.That(displayNumber.IntegerPart, Is.EqualTo(integerPart));
            Assert.That(displayNumber.HasComma, Is.EqualTo(hasComma));
            Assert.That(displayNumber.FractionalPart, Is.EqualTo(fractionalPart));
            Assert.That(displayNumber.Exponent, Is.EqualTo(exponent));
        }
    }
}
