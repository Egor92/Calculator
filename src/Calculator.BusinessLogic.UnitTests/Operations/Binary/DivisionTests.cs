using Calculator.BusinessLogic.Constants;
using Calculator.BusinessLogic.Operations.Binary;
using NUnit.Framework;

namespace Calculator.BusinessLogic.UnitTests.Operations.Binary
{
    [TestFixture]
    public class DivisionTests
    {
        [Test]
        public void GetExecutableInfo_WhenSecondValueIsNotZero_ThenCanExecute()
        {
            //Arrange
            var division = new Division();

            //Act
            var executableInfo = division.GetExecutableInfo(10, 20);

            //Assert
            Assert.That(executableInfo.CanBeExecuted, Is.True);
        }

        [Test]
        public void GetExecutableInfo_WhenSecondValueIsZero_ThenCannotExecuteAndReturnErrorMessage()
        {
            //Arrange
            var division = new Division();

            //Act
            var executableInfo = division.GetExecutableInfo(10, 0);

            //Assert
            Assert.That(executableInfo.Message, Is.EqualTo(ErrorMessages.DivisionOnZero));
        }

        [Test]
        public void Execute_WhenSecondValueIsNotZero_ThenReturnDivision()
        {
            //Arrange
            var division = new Division();

            //Act
            var result = division.Execute(10, 20);

            //Assert
            Assert.That(result, Is.EqualTo(0.5));
        }
    }
}
