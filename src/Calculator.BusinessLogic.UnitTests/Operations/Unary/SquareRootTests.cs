using Calculator.BusinessLogic.Constants;
using Calculator.BusinessLogic.Operations.Unary;
using NUnit.Framework;

namespace Calculator.BusinessLogic.UnitTests.Operations.Unary
{
    [TestFixture]
    public class SquareRootTests
    {
        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void GetExecutableInfo_WhenValueIsNotNegative_ThenCanExecute(double value)
        {
            //Arrange
            var squareRoot = new SquareRoot();

            //Act
            var executableInfo = squareRoot.GetExecutableInfo(value);

            //Assert
            Assert.That(executableInfo.CanBeExecuted, Is.True);
        }

        [Test]
        public void GetExecutableInfo_WhenValueIsNegative_ThenCannotExecuteAndReturnErrorMessage()
        {
            //Arrange
            var squareRoot = new SquareRoot();

            //Act
            var executableInfo = squareRoot.GetExecutableInfo(-1);

            //Assert
            Assert.That(executableInfo.Message, Is.EqualTo(ErrorMessages.InvalidInput));
        }

        [Test]
        [TestCase(0, ExpectedResult = 0)]
        [TestCase(1, ExpectedResult = 1)]
        [TestCase(1.44, ExpectedResult = 1.2)]
        [TestCase(25, ExpectedResult = 5)]
        public double Execute_WhenValueIsNotNegative_ThenReturnSquareRoot(double value)
        {
            //Arrange
            var squareRoot = new SquareRoot();

            //Act
            var result = squareRoot.Execute(value);

            //Assert
            return result;
        }
    }
}
