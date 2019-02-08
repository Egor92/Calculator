using NUnit.Framework;

namespace Calculator.BusinessLogic.UnitTests
{
	[TestFixture]
	public class CalculatorTests
	{
		private Calculator _calculator;

		[Test]
		[TestCase(0, "0", false, ExpectedResult = "0")]
		[TestCase(0, "1", false, ExpectedResult = "10")]
		[TestCase(0, "-1", false, ExpectedResult = "-10")]
		[TestCase(0, "0,1", false, ExpectedResult = "0,10")]
		[TestCase(0, "0,", false, ExpectedResult = "0,0")]
		[TestCase(999, "999", true, ExpectedResult = "0")]
		public string ApplyZero_WhenHasDisplayValue_ThenResultIsBecomeExpected(double previousValue, string displayValue, bool wasEqualsSet)
		{
			//Arrange
			var displayNumber = DisplayNumberFactory.Create(displayValue);
			var calculatorState = new CalculatorState(previousValue, displayNumber, wasEqualsSet);
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
		public string ApplyOne_WhenHasDisplayValue_ThenResultIsBecomeExpected(double previousValue, string displayValue, bool wasEqualsSet)
		{
            //Arrange
			var displayNumber = DisplayNumberFactory.Create(displayValue);
			var calculatorState = new CalculatorState(previousValue, displayNumber, wasEqualsSet);
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
		public string ApplyTwo_WhenHasDisplayValue_ThenResultIsBecomeExpected(double previousValue, string displayValue, bool wasEqualsSet)
		{
            //Arrange
			var displayNumber = DisplayNumberFactory.Create(displayValue);
			var calculatorState = new CalculatorState(previousValue, displayNumber, wasEqualsSet);
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
		public string ApplyThree_WhenHasDisplayValue_ThenResultIsBecomeExpected(double previousValue, string displayValue, bool wasEqualsSet)
		{
            //Arrange
			var displayNumber = DisplayNumberFactory.Create(displayValue);
			var calculatorState = new CalculatorState(previousValue, displayNumber, wasEqualsSet);
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
		public string ApplyFour_WhenHasDisplayValue_ThenResultIsBecomeExpected(double previousValue, string displayValue, bool wasEqualsSet)
		{
            //Arrange
			var displayNumber = DisplayNumberFactory.Create(displayValue);
			var calculatorState = new CalculatorState(previousValue, displayNumber, wasEqualsSet);
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
		public string ApplyFive_WhenHasDisplayValue_ThenResultIsBecomeExpected(double previousValue, string displayValue, bool wasEqualsSet)
		{
            //Arrange
			var displayNumber = DisplayNumberFactory.Create(displayValue);
			var calculatorState = new CalculatorState(previousValue, displayNumber, wasEqualsSet);
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
		public string ApplySix_WhenHasDisplayValue_ThenResultIsBecomeExpected(double previousValue, string displayValue, bool wasEqualsSet)
		{
            //Arrange
			var displayNumber = DisplayNumberFactory.Create(displayValue);
			var calculatorState = new CalculatorState(previousValue, displayNumber, wasEqualsSet);
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
		public string ApplySeven_WhenHasDisplayValue_ThenResultIsBecomeExpected(double previousValue, string displayValue, bool wasEqualsSet)
		{
            //Arrange
			var displayNumber = DisplayNumberFactory.Create(displayValue);
			var calculatorState = new CalculatorState(previousValue, displayNumber, wasEqualsSet);
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
		public string ApplyEight_WhenHasDisplayValue_ThenResultIsBecomeExpected(double previousValue, string displayValue, bool wasEqualsSet)
		{
            //Arrange
			var displayNumber = DisplayNumberFactory.Create(displayValue);
			var calculatorState = new CalculatorState(previousValue, displayNumber, wasEqualsSet);
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
		public string ApplyNine_WhenHasDisplayValue_ThenResultIsBecomeExpected(double previousValue, string displayValue, bool wasEqualsSet)
		{
            //Arrange
			var displayNumber = DisplayNumberFactory.Create(displayValue);
			var calculatorState = new CalculatorState(previousValue, displayNumber, wasEqualsSet);
			_calculator = new Calculator(calculatorState);

			//Act
			_calculator.ApplyNine();

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
		public string ApplyNegation_WhenHasDisplayValue_ThenResultIsBecomeExpected(double previousValue, string displayValue, bool wasEqualsSet)
		{
            //Arrange
			var displayNumber = DisplayNumberFactory.Create(displayValue);
			var calculatorState = new CalculatorState(previousValue, displayNumber, wasEqualsSet);
			_calculator = new Calculator(calculatorState);

            //Act
            _calculator.ApplyNegation();

            //Assert
			return _calculator.DisplayValue;
		}
    }
}
