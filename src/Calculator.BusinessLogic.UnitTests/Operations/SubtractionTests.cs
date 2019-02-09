using Calculator.BusinessLogic.Operations;
using NUnit.Framework;

namespace Calculator.BusinessLogic.UnitTests.Operations
{
	[TestFixture]
	public class SubtractionTests
    {
		[Test]
		public void CanExecute_WhenAnyValues_ThenCanExecute()
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
