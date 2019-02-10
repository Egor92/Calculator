using Calculator.BusinessLogic.Operations.Binary;
using NUnit.Framework;

namespace Calculator.BusinessLogic.UnitTests.Operations.Binary
{
    [TestFixture]
    public class SubtractionTests
    {
        [Test]
        public void GetExecutableInfo_WhenAnyValues_ThenCanExecute()
        {
            //Arrange
            var subtraction = new Subtraction();

            //Act
            var executableInfo = subtraction.GetExecutableInfo(10, 20);

            //Assert
            Assert.That(executableInfo.CanBeExecuted, Is.True);
        }

        [Test]
        public void Execute_WhenAnyValues_ThenReturnSubtraction()
        {
            //Arrange
            var subtraction = new Subtraction();

            //Act
            var result = subtraction.Execute(10, 20);

            //Assert
            Assert.That(result, Is.EqualTo(-10));
        }
    }
}
