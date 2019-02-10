using Calculator.BusinessLogic.Constants;
using Calculator.BusinessLogic.Operations.Unary;
using NUnit.Framework;

namespace Calculator.BusinessLogic.UnitTests.Operations.Unary
{
    [TestFixture]
    public class TurningOverTests
    {
        [Test]
        [TestCase(-1)]
        [TestCase(1)]
        public void GetExecutableInfo_WhenValueIsNotZero_ThenCanExecute(double value)
        {
            //Arrange
            var turningOver = new TurningOver();

            //Act
            var executableInfo = turningOver.GetExecutableInfo(value);

            //Assert
            Assert.That(executableInfo.CanBeExecuted, Is.True);
        }

        [Test]
        public void GetExecutableInfo_WhenValueIsZero_ThenCannotExecuteAndReturnErrorMessage()
        {
            //Arrange
            var turningOver = new TurningOver();

            //Act
            var executableInfo = turningOver.GetExecutableInfo(0);

            //Assert
            Assert.That(executableInfo.Message, Is.EqualTo(ErrorMessages.DivisionOnZero));
        }

        [Test]
        [TestCase(1, ExpectedResult = 1)]
        [TestCase(2, ExpectedResult = 0.5)]
        [TestCase(0.2, ExpectedResult = 5)]
        public double Execute_WhenValueIsNotNegative_ThenReturnSquareRoot(double value)
        {
            //Arrange
            var turningOver = new TurningOver();

            //Act
            var result = turningOver.Execute(value);

            //Assert
            return result;
        }
    }
}
