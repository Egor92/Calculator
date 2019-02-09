using NUnit.Framework;

namespace Calculator.BusinessLogic.UnitTests
{
	[TestFixture]
	public class CalculatorTests
	{
		private Calculator _calculator;

		[Test]
		public void DisplayValue_InitialDefaultValueIsZero()
		{
			//Arrange
			_calculator = new Calculator();

			//Assert
			Assert.That(_calculator.DisplayValue, Is.EqualTo("0"));
		}

		[Test]
		[TestCase(0, "0", false, ExpectedResult = "0")]
		[TestCase(0, "1", false, ExpectedResult = "10")]
		[TestCase(0, "-1", false, ExpectedResult = "-10")]
		[TestCase(0, "0,1", false, ExpectedResult = "0,10")]
		[TestCase(0, "0,", false, ExpectedResult = "0,0")]
		[TestCase(999, "999", true, ExpectedResult = "0")]
		public string TestApplyZero(double previousValue, string displayValue, bool wasEqualsSet)
		{
			//Arrange
			var displayNumber = DisplayNumberFactory.Create(displayValue);
			var calculatorState = new CalculatorState.Builder().PreviousValue(previousValue)
			                                                   .DisplayNumber(displayNumber)
			                                                   .WasEqualsSet(wasEqualsSet)
			                                                   .Build();
			_calculator = new Calculator(calculatorState);

			//Act
			_calculator.ApplyZero();

			//Assert
			return _calculator.DisplayValue;
		}

		[Test]
		[TestCase(0, "0", false, ExpectedResult = "1")]
		[TestCase(0, "1", false, ExpectedResult = "11")]
		[TestCase(0, "-1", false, ExpectedResult = "-11")]
		[TestCase(0, "0,1", false, ExpectedResult = "0,11")]
		[TestCase(0, "0,", false, ExpectedResult = "0,1")]
		[TestCase(999, "999", true, ExpectedResult = "1")]
		public string TestApplyOne(double previousValue, string displayValue, bool wasEqualsSet)
		{
			//Arrange
			var displayNumber = DisplayNumberFactory.Create(displayValue);
			var calculatorState = new CalculatorState.Builder().PreviousValue(previousValue)
			                                                   .DisplayNumber(displayNumber)
			                                                   .WasEqualsSet(wasEqualsSet)
			                                                   .Build();
			_calculator = new Calculator(calculatorState);

			//Act
			_calculator.ApplyOne();

			//Assert
			return _calculator.DisplayValue;
		}

		[Test]
		[TestCase(0, "0", false, ExpectedResult = "2")]
		[TestCase(0, "1", false, ExpectedResult = "12")]
		[TestCase(0, "-1", false, ExpectedResult = "-12")]
		[TestCase(0, "0,1", false, ExpectedResult = "0,12")]
		[TestCase(0, "0,", false, ExpectedResult = "0,2")]
		[TestCase(999, "999", true, ExpectedResult = "2")]
		public string TestApplyTwo(double previousValue, string displayValue, bool wasEqualsSet)
		{
			//Arrange
			var displayNumber = DisplayNumberFactory.Create(displayValue);
			var calculatorState = new CalculatorState.Builder().PreviousValue(previousValue)
			                                                   .DisplayNumber(displayNumber)
			                                                   .WasEqualsSet(wasEqualsSet)
			                                                   .Build();
			_calculator = new Calculator(calculatorState);

			//Act
			_calculator.ApplyTwo();

			//Assert
			return _calculator.DisplayValue;
		}

		[Test]
		[TestCase(0, "0", false, ExpectedResult = "3")]
		[TestCase(0, "1", false, ExpectedResult = "13")]
		[TestCase(0, "-1", false, ExpectedResult = "-13")]
		[TestCase(0, "0,1", false, ExpectedResult = "0,13")]
		[TestCase(0, "0,", false, ExpectedResult = "0,3")]
		[TestCase(999, "999", true, ExpectedResult = "3")]
		public string TestApplyThree(double previousValue, string displayValue, bool wasEqualsSet)
		{
			//Arrange
			var displayNumber = DisplayNumberFactory.Create(displayValue);
			var calculatorState = new CalculatorState.Builder().PreviousValue(previousValue)
			                                                   .DisplayNumber(displayNumber)
			                                                   .WasEqualsSet(wasEqualsSet)
			                                                   .Build();
			_calculator = new Calculator(calculatorState);

			//Act
			_calculator.ApplyThree();

			//Assert
			return _calculator.DisplayValue;
		}

		[Test]
		[TestCase(0, "0", false, ExpectedResult = "4")]
		[TestCase(0, "1", false, ExpectedResult = "14")]
		[TestCase(0, "-1", false, ExpectedResult = "-14")]
		[TestCase(0, "0,1", false, ExpectedResult = "0,14")]
		[TestCase(0, "0,", false, ExpectedResult = "0,4")]
		[TestCase(999, "999", true, ExpectedResult = "4")]
		public string TestApplyFour(double previousValue, string displayValue, bool wasEqualsSet)
		{
			//Arrange
			var displayNumber = DisplayNumberFactory.Create(displayValue);
			var calculatorState = new CalculatorState.Builder().PreviousValue(previousValue)
			                                                   .DisplayNumber(displayNumber)
			                                                   .WasEqualsSet(wasEqualsSet)
			                                                   .Build();
			_calculator = new Calculator(calculatorState);

			//Act
			_calculator.ApplyFour();

			//Assert
			return _calculator.DisplayValue;
		}

		[Test]
		[TestCase(0, "0", false, ExpectedResult = "5")]
		[TestCase(0, "1", false, ExpectedResult = "15")]
		[TestCase(0, "-1", false, ExpectedResult = "-15")]
		[TestCase(0, "0,1", false, ExpectedResult = "0,15")]
		[TestCase(0, "0,", false, ExpectedResult = "0,5")]
		[TestCase(999, "999", true, ExpectedResult = "5")]
		public string TestApplyFive(double previousValue, string displayValue, bool wasEqualsSet)
		{
			//Arrange
			var displayNumber = DisplayNumberFactory.Create(displayValue);
			var calculatorState = new CalculatorState.Builder().PreviousValue(previousValue)
			                                                   .DisplayNumber(displayNumber)
			                                                   .WasEqualsSet(wasEqualsSet)
			                                                   .Build();
			_calculator = new Calculator(calculatorState);

			//Act
			_calculator.ApplyFive();

			//Assert
			return _calculator.DisplayValue;
		}

		[Test]
		[TestCase(0, "0", false, ExpectedResult = "6")]
		[TestCase(0, "1", false, ExpectedResult = "16")]
		[TestCase(0, "-1", false, ExpectedResult = "-16")]
		[TestCase(0, "0,1", false, ExpectedResult = "0,16")]
		[TestCase(0, "0,", false, ExpectedResult = "0,6")]
		[TestCase(999, "999", true, ExpectedResult = "6")]
		public string TestApplySix(double previousValue, string displayValue, bool wasEqualsSet)
		{
			//Arrange
			var displayNumber = DisplayNumberFactory.Create(displayValue);
			var calculatorState = new CalculatorState.Builder().PreviousValue(previousValue)
			                                                   .DisplayNumber(displayNumber)
			                                                   .WasEqualsSet(wasEqualsSet)
			                                                   .Build();
			_calculator = new Calculator(calculatorState);

			//Act
			_calculator.ApplySix();

			//Assert
			return _calculator.DisplayValue;
		}

		[Test]
		[TestCase(0, "0", false, ExpectedResult = "7")]
		[TestCase(0, "1", false, ExpectedResult = "17")]
		[TestCase(0, "-1", false, ExpectedResult = "-17")]
		[TestCase(0, "0,1", false, ExpectedResult = "0,17")]
		[TestCase(0, "0,", false, ExpectedResult = "0,7")]
		[TestCase(999, "999", true, ExpectedResult = "7")]
		public string TestApplySeven(double previousValue, string displayValue, bool wasEqualsSet)
		{
			//Arrange
			var displayNumber = DisplayNumberFactory.Create(displayValue);
			var calculatorState = new CalculatorState.Builder().PreviousValue(previousValue)
			                                                   .DisplayNumber(displayNumber)
			                                                   .WasEqualsSet(wasEqualsSet)
			                                                   .Build();
			_calculator = new Calculator(calculatorState);

			//Act
			_calculator.ApplySeven();

			//Assert
			return _calculator.DisplayValue;
		}

		[Test]
		[TestCase(0, "0", false, ExpectedResult = "8")]
		[TestCase(0, "1", false, ExpectedResult = "18")]
		[TestCase(0, "-1", false, ExpectedResult = "-18")]
		[TestCase(0, "0,1", false, ExpectedResult = "0,18")]
		[TestCase(0, "0,", false, ExpectedResult = "0,8")]
		[TestCase(999, "999", true, ExpectedResult = "8")]
		public string TestApplyEight(double previousValue, string displayValue, bool wasEqualsSet)
		{
			//Arrange
			var displayNumber = DisplayNumberFactory.Create(displayValue);
			var calculatorState = new CalculatorState.Builder().PreviousValue(previousValue)
			                                                   .DisplayNumber(displayNumber)
			                                                   .WasEqualsSet(wasEqualsSet)
			                                                   .Build();
			_calculator = new Calculator(calculatorState);

			//Act
			_calculator.ApplyEight();

			//Assert
			return _calculator.DisplayValue;
		}

		[Test]
		[TestCase(0, "0", false, ExpectedResult = "9")]
		[TestCase(0, "1", false, ExpectedResult = "19")]
		[TestCase(0, "-1", false, ExpectedResult = "-19")]
		[TestCase(0, "0,1", false, ExpectedResult = "0,19")]
		[TestCase(0, "0,", false, ExpectedResult = "0,9")]
		[TestCase(999, "999", true, ExpectedResult = "9")]
		public string TestApplyNine(double previousValue, string displayValue, bool wasEqualsSet)
		{
			//Arrange
			var displayNumber = DisplayNumberFactory.Create(displayValue);
			var calculatorState = new CalculatorState.Builder().PreviousValue(previousValue)
			                                                   .DisplayNumber(displayNumber)
			                                                   .WasEqualsSet(wasEqualsSet)
			                                                   .Build();
			_calculator = new Calculator(calculatorState);

			//Act
			_calculator.ApplyNine();

			//Assert
			return _calculator.DisplayValue;
		}

		[Test]
		[TestCase(0, "0", false, ExpectedResult = "0,")]
		[TestCase(0, "1", false, ExpectedResult = "1,")]
		[TestCase(0, "0,", false, ExpectedResult = "0,")]
		[TestCase(0, "-1,", false, ExpectedResult = "-1,")]
		[TestCase(0, "1,234", false, ExpectedResult = "1,234")]
		[TestCase(0, "123", true, ExpectedResult = "0,")]
		public string TestApplyComma(double previousValue, string displayValue, bool wasEqualsSet)
		{
			//Arrange
			var displayNumber = DisplayNumberFactory.Create(displayValue);
			var calculatorState = new CalculatorState.Builder().PreviousValue(previousValue)
			                                                   .DisplayNumber(displayNumber)
			                                                   .WasEqualsSet(wasEqualsSet)
			                                                   .Build();
			_calculator = new Calculator(calculatorState);

			//Act
			_calculator.ApplyComma();

			//Assert
			return _calculator.DisplayValue;
		}

		[Test]
		[TestCase("0")]
		[TestCase("0,")]
		[TestCase("1,234")]
		[TestCase("-1,234")]
		public void ApplyClear_WhenAnyDisplayValue_ThenDisplayValueWillBeReset(string displayValue)
		{
			//Arrange
			var displayNumber = DisplayNumberFactory.Create(displayValue);
			var calculatorState = new CalculatorState.Builder().DisplayNumber(displayNumber)
			                                                   .Build();
			_calculator = new Calculator(calculatorState);

			//Act
			_calculator.Clear();

			//Assert
			Assert.That(_calculator.DisplayValue, Is.EqualTo("0"));
		}

		[Test]
		[TestCase("0", false, ExpectedResult = "0")]
		[TestCase("1", false, ExpectedResult = "0")]
		[TestCase("12", false, ExpectedResult = "1")]
		[TestCase("-12", false, ExpectedResult = "-1")]
		[TestCase("-1", false, ExpectedResult = "0")]
		[TestCase("0,", false, ExpectedResult = "0")]
		[TestCase("1,", false, ExpectedResult = "1")]
		[TestCase("0,0", false, ExpectedResult = "0,")]
		[TestCase("1,0", false, ExpectedResult = "1,")]
		[TestCase("1,23", false, ExpectedResult = "1,2")]
		[TestCase("-1,23", false, ExpectedResult = "-1,2")]
		[TestCase("-1,23", true, ExpectedResult = "-1,23")]
		public string TestClearLastSymbol(string displayValue, bool wasEqualsSet)
		{
			//Arrange
			var displayNumber = DisplayNumberFactory.Create(displayValue);
			var calculatorState = new CalculatorState.Builder().DisplayNumber(displayNumber)
			                                                   .WasEqualsSet(wasEqualsSet)
			                                                   .Build();
			_calculator = new Calculator(calculatorState);

			//Act
			_calculator.ClearLastSymbol();

			//Assert
			return _calculator.DisplayValue;
		}

		[Test]
		[TestCase(0, "0", false, ExpectedResult = "0")]
		[TestCase(0, "1", false, ExpectedResult = "-1")]
		[TestCase(0, "-1", false, ExpectedResult = "1")]
		[TestCase(0, "0,1", false, ExpectedResult = "-0,1")]
		[TestCase(0, "0,", false, ExpectedResult = "-0,")]
		[TestCase(0, "0,0", false, ExpectedResult = "-0,0")]
		[TestCase(999, "999", true, ExpectedResult = "-999")]
		public string TestApplyNegation(double previousValue, string displayValue, bool wasEqualsSet)
		{
			//Arrange
			var displayNumber = DisplayNumberFactory.Create(displayValue);
			var calculatorState = new CalculatorState.Builder().PreviousValue(previousValue)
			                                                   .DisplayNumber(displayNumber)
			                                                   .WasEqualsSet(wasEqualsSet)
			                                                   .Build();
			_calculator = new Calculator(calculatorState);

			//Act
			_calculator.ApplyNegation();

			//Assert
			return _calculator.DisplayValue;
		}

		[Test]
		[TestCase(50, "-10")]
		[TestCase(50, "0")]
		[TestCase(50, "10")]
		[TestCase(50, "1,123")]
		public void ApplyAddition_DisplayValueDoesNotChange(double previousValue, string displayValue)
		{
			//Arrange
			var displayNumber = DisplayNumberFactory.Create(displayValue);
			var calculatorState = new CalculatorState.Builder().PreviousValue(previousValue)
			                                                   .DisplayNumber(displayNumber)
			                                                   .Build();
			_calculator = new Calculator(calculatorState);
			var initialDisplayValue = _calculator.DisplayValue;

			//Act
			_calculator.ApplyAddition();

			//Assert
			Assert.That(_calculator.DisplayValue, Is.EqualTo(initialDisplayValue));
		}

		[Test]
		[TestCase(50, "-10")]
		[TestCase(50, "0")]
		[TestCase(50, "10")]
		[TestCase(50, "1,123")]
		public void ApplySubtraction_DisplayValueDoesNotChange(double previousValue, string displayValue)
		{
			//Arrange
			var displayNumber = DisplayNumberFactory.Create(displayValue);
			var calculatorState = new CalculatorState.Builder().PreviousValue(previousValue)
			                                                   .DisplayNumber(displayNumber)
			                                                   .Build();
			_calculator = new Calculator(calculatorState);
			var initialDisplayValue = _calculator.DisplayValue;

			//Act
			_calculator.ApplySubtraction();

			//Assert
			Assert.That(_calculator.DisplayValue, Is.EqualTo(initialDisplayValue));
		}

		[Test]
		[TestCase(50, "-10")]
		[TestCase(50, "0")]
		[TestCase(50, "10")]
		[TestCase(50, "1,123")]
		public void ApplyMultiplication_DisplayValueDoesNotChange(double previousValue, string displayValue)
		{
			//Arrange
			var displayNumber = DisplayNumberFactory.Create(displayValue);
			var calculatorState = new CalculatorState.Builder().PreviousValue(previousValue)
			                                                   .DisplayNumber(displayNumber)
			                                                   .Build();
			_calculator = new Calculator(calculatorState);
			var initialDisplayValue = _calculator.DisplayValue;

			//Act
			_calculator.ApplyMultiplication();

			//Assert
			Assert.That(_calculator.DisplayValue, Is.EqualTo(initialDisplayValue));
		}

		[Test]
		[TestCase(50, "-10")]
		[TestCase(50, "0")]
		[TestCase(50, "10")]
		[TestCase(50, "1,123")]
		public void ApplyDivision_DisplayValueDoesNotChange(double previousValue, string displayValue)
		{
			//Arrange
			var displayNumber = DisplayNumberFactory.Create(displayValue);
			var calculatorState = new CalculatorState.Builder().PreviousValue(previousValue)
			                                                   .DisplayNumber(displayNumber)
			                                                   .Build();
			_calculator = new Calculator(calculatorState);
			var initialDisplayValue = _calculator.DisplayValue;

			//Act
			_calculator.ApplyDivision();

			//Assert
			Assert.That(_calculator.DisplayValue, Is.EqualTo(initialDisplayValue));
		}
	}
}
