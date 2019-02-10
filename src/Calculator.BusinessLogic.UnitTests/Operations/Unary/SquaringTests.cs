using Calculator.BusinessLogic.Operations.Unary;
using NUnit.Framework;

namespace Calculator.BusinessLogic.UnitTests.Operations.Unary
{
    [TestFixture]
    public class SquaringTests
    {
        [Test]
        [TestCase(-2)]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void CanExecute_WhenValueIsAny_ThenCanExecute(double value)
        {
            //Arrange
            var squaring = new Squaring();

            //Act
            var executableInfo = squaring.GetExecutableInfo(value);

            //Assert
            Assert.That(executableInfo.CanBeExecuted, Is.True);
        }

        [Test]
        [TestCase(-2, ExpectedResult = 4)]
        [TestCase(0, ExpectedResult = 0)]
        [TestCase(1, ExpectedResult = 1)]
        [TestCase(1.2, ExpectedResult = 1.44)]
        [TestCase(5, ExpectedResult = 25)]
        public double Execute_WhenValueIsNotNegative_ThenReturnSquareRoot(double value)
        {
            //Arrange
            var squaring = new Squaring();

            //Act
            var result = squaring.Execute(value);

            //Assert
            return result;
        }
    }
}
