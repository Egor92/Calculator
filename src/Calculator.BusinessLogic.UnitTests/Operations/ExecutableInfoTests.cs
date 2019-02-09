using Calculator.BusinessLogic.Operations;
using NUnit.Framework;

namespace Calculator.BusinessLogic.UnitTests.Operations
{
    [TestFixture]
    public class ExecutableInfoTests
    {
        [Test]
        public void CreateExecutable_WhenInvoke_ThenCanBeExecutableIsTrue()
        {
            //Act
            var operationInfo = ExecutableInfo.CreateExecutable();

            //Assert
            Assert.That(operationInfo.CanBeExecuted, Is.True);
        }

        [Test]
        public void CreateExecutable_WhenInvoke_ThenMessageIsNull()
        {
            //Act
            var operationInfo = ExecutableInfo.CreateExecutable();

            //Assert
            Assert.That(operationInfo.Message, Is.Null);
        }

        [Test]
        public void CreateExecutable_WhenInvoke_ThenCanBeExecutableIsFalse()
        {
            //Act
            var operationInfo = ExecutableInfo.CreateExecutable();

            //Assert
            Assert.That(operationInfo.CanBeExecuted, Is.True);
        }

        [Test]
        public void CreateNotExecutable_WhenPassMessage_ThenMessageIsTheSame()
        {
            //Arrange
            const string message = "Some message";

            //Act
            var operationInfo = ExecutableInfo.CreateNotExecutable(message);

            //Assert
            Assert.That(operationInfo.CanBeExecuted, Is.False);
        }
    }
}
