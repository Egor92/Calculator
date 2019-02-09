﻿using Calculator.BusinessLogic.Constants;
using Calculator.BusinessLogic.Operations;
using NUnit.Framework;

namespace Calculator.BusinessLogic.UnitTests.Operations
{
	[TestFixture]
	public class DivisionTests
	{
		[Test]
		public void CanExecute_WhenSecondValueIsNotZero_ThenCanExecute()
		{
			//Arrange
			var division = new Division();

			//Act
			var executableInfo = division.GetExecutableInfo(10, 20);

			//Assert
			Assert.That(executableInfo.CanBeExecuted, Is.True);
		}

		[Test]
		public void CanExecute_WhenSecondValueIsZero_ThenCannotExecuteAndReturnExecute()
		{
			//Arrange
			var division = new Division();

			//Act
			var executableInfo = division.GetExecutableInfo(10, 0);

			//Assert
			Assert.That(executableInfo.Message, Is.EqualTo(Messages.DivisionOnZero));
		}

		[Test]
		public void Execute_WhenAnyValues_ThenReturnDivision()
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