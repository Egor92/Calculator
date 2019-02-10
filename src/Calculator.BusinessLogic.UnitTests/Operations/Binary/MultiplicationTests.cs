using Calculator.BusinessLogic.Operations.Binary;
using NUnit.Framework;

namespace Calculator.BusinessLogic.UnitTests.Operations.Binary
{
    [TestFixture]
    public class MultiplicationTests
    {
        [Test]
        public void GetExecutableInfo_WhenAnyValues_ThenCanExecute()
        {
            //Arrange
            var multiplication = new Multiplication();

            //Act
            var executableInfo = multiplication.GetExecutableInfo(10, 20);

            //Assert
            Assert.That(executableInfo.CanBeExecuted, Is.True);
        }

        [Test]
        public void Execute_WhenAnyValues_ThenReturnMult()
        {
            //Arrange
            var multiplication = new Multiplication();

            //Act
            var result = multiplication.Execute(10, 20);

            //Assert
            Assert.That(result, Is.EqualTo(200));
        }
    }
}
