using Calculator.BusinessLogic.Operations.Binary;
using NUnit.Framework;

namespace Calculator.BusinessLogic.UnitTests.Operations.Binary
{
    [TestFixture]
    public class PercentTests
    {
        [Test]
        [TestCase(4, 25)]
        [TestCase(0, 25)]
        [TestCase(-4, 25)]
        [TestCase(4, 0)]
        [TestCase(4, -25)]
        public void GetExecutableInfo_WhenAnyValues_ThenCanExecute(double value1, double value2)
        {
            //Arrange
            var percent = new Percent();

            //Act
            var executableInfo = percent.GetExecutableInfo(value1, value2);

            //Assert
            Assert.That(executableInfo.CanBeExecuted, Is.True);
        }

        [Test]
        [TestCase(4, 25, ExpectedResult = 1)]
        [TestCase(0, 25, ExpectedResult = 0)]
        [TestCase(-4, 25, ExpectedResult = -1)]
        [TestCase(4, 0, ExpectedResult = 0)]
        [TestCase(4, -25, ExpectedResult = -1)]
        public double Execute_WhenAnyValues_ThenReturnPercent(double value1, double value2)
        {
            //Arrange
            var percent = new Percent();

            //Act
            var result = percent.Execute(value1, value2);

            //Assert
            return result;
        }
    }
}
