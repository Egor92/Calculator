using Calculator.BusinessLogic.Operations.Binary;
using NUnit.Framework;

namespace Calculator.BusinessLogic.UnitTests.Operations.Binary
{
    [TestFixture]
    public class AdditionTests
    {
        [Test]
        public void CanExecute_WhenAnyValues_ThenCanExecute()
        {
            //Arrange
            var addition = new Addition();

            //Act
            var executableInfo = addition.GetExecutableInfo(10, 20);

            //Assert
            Assert.That(executableInfo.CanBeExecuted, Is.True);
        }

        [Test]
        public void Execute_WhenAnyValues_ThenReturnSum()
        {
            //Arrange
            var addition = new Addition();

            //Act
            var result = addition.Execute(10, 20);

            //Assert
            Assert.That(result, Is.EqualTo(30));
        }
    }
}
