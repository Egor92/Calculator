using Calculator.BusinessLogic.Constants;
using NUnit.Framework;

namespace Calculator.BusinessLogic.UnitTests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator _calculator;

        #region DisplayValue

        [Test]
        public void DisplayValue_InitialDefaultValueIsZero()
        {
            //Arrange
            _calculator = new Calculator();

            //Assert
            Assert.That(_calculator.DisplayValue, Is.EqualTo("0"));
        }

        #endregion

        #region ApplyZero

        [Test]
        [TestCase(0, "0", false, ExpectedResult = "0")]
        [TestCase(0, "1", false, ExpectedResult = "10")]
        [TestCase(0, "-1", false, ExpectedResult = "-10")]
        [TestCase(0, "0,1", false, ExpectedResult = "0,10")]
        [TestCase(0, "0,", false, ExpectedResult = "0,0")]
        [TestCase(999, "999", true, ExpectedResult = "0")]
        public string TestApplyZero(double previousValue, string displayValue, bool isLastActionAnBinaryOperation)
        {
            //Arrange
            var displayNumber = DisplayNumberFactory.Create(displayValue);
            var calculatorState = new CalculatorState.Builder().PreviousValue(previousValue)
                                                               .DisplayNumber(displayNumber)
                                                               .IsLastActionAnBinaryOperation(isLastActionAnBinaryOperation)
                                                               .Build();
            _calculator = new Calculator(calculatorState);

            //Act
            _calculator.ApplyZero();

            //Assert
            return _calculator.DisplayValue;
        }

        [Test]
        public void ApplyZero_WhenApplyTwoNumbersAfterOperation_ThenDisplayValueConsistOfTheTwoNumbers()
        {
            //Arrange
            _calculator = new Calculator();

            _calculator.ApplyFour();
            _calculator.ApplyAddition();

            //Act
            _calculator.ApplyZero();
            _calculator.ApplyZero();

            //Assert
            Assert.That(_calculator.DisplayValue, Is.EqualTo("0"));
        }

        #endregion

        #region ApplyOne

        [Test]
        [TestCase(0, "0", false, ExpectedResult = "1")]
        [TestCase(0, "1", false, ExpectedResult = "11")]
        [TestCase(0, "-1", false, ExpectedResult = "-11")]
        [TestCase(0, "0,1", false, ExpectedResult = "0,11")]
        [TestCase(0, "0,", false, ExpectedResult = "0,1")]
        [TestCase(999, "999", true, ExpectedResult = "1")]
        public string TestApplyOne(double previousValue, string displayValue, bool isLastActionAnBinaryOperation)
        {
            //Arrange
            var displayNumber = DisplayNumberFactory.Create(displayValue);
            var calculatorState = new CalculatorState.Builder().PreviousValue(previousValue)
                                                               .DisplayNumber(displayNumber)
                                                               .IsLastActionAnBinaryOperation(isLastActionAnBinaryOperation)
                                                               .Build();
            _calculator = new Calculator(calculatorState);

            //Act
            _calculator.ApplyOne();

            //Assert
            return _calculator.DisplayValue;
        }

        [Test]
        public void ApplyOne_WhenApplyTwoNumbersAfterOperation_ThenDisplayValueConsistOfTheTwoNumbers()
        {
            //Arrange
            _calculator = new Calculator();

            _calculator.ApplyFour();
            _calculator.ApplyAddition();

            //Act
            _calculator.ApplyOne();
            _calculator.ApplyZero();

            //Assert
            Assert.That(_calculator.DisplayValue, Is.EqualTo("10"));
        }

        #endregion

        #region ApplyTwo

        [Test]
        [TestCase(0, "0", false, ExpectedResult = "2")]
        [TestCase(0, "1", false, ExpectedResult = "12")]
        [TestCase(0, "-1", false, ExpectedResult = "-12")]
        [TestCase(0, "0,1", false, ExpectedResult = "0,12")]
        [TestCase(0, "0,", false, ExpectedResult = "0,2")]
        [TestCase(999, "999", true, ExpectedResult = "2")]
        public string TestApplyTwo(double previousValue, string displayValue, bool isLastActionAnBinaryOperation)
        {
            //Arrange
            var displayNumber = DisplayNumberFactory.Create(displayValue);
            var calculatorState = new CalculatorState.Builder().PreviousValue(previousValue)
                                                               .DisplayNumber(displayNumber)
                                                               .IsLastActionAnBinaryOperation(isLastActionAnBinaryOperation)
                                                               .Build();
            _calculator = new Calculator(calculatorState);

            //Act
            _calculator.ApplyTwo();

            //Assert
            return _calculator.DisplayValue;
        }

        [Test]
        public void ApplyTwo_WhenApplyTwoNumbersAfterOperation_ThenDisplayValueConsistOfTheTwoNumbers()
        {
            //Arrange
            _calculator = new Calculator();

            _calculator.ApplyFour();
            _calculator.ApplyAddition();

            //Act
            _calculator.ApplyTwo();
            _calculator.ApplyZero();

            //Assert
            Assert.That(_calculator.DisplayValue, Is.EqualTo("20"));
        }

        #endregion

        #region ApplyThree

        [Test]
        [TestCase(0, "0", false, ExpectedResult = "3")]
        [TestCase(0, "1", false, ExpectedResult = "13")]
        [TestCase(0, "-1", false, ExpectedResult = "-13")]
        [TestCase(0, "0,1", false, ExpectedResult = "0,13")]
        [TestCase(0, "0,", false, ExpectedResult = "0,3")]
        [TestCase(999, "999", true, ExpectedResult = "3")]
        public string TestApplyThree(double previousValue, string displayValue, bool isLastActionAnBinaryOperation)
        {
            //Arrange
            var displayNumber = DisplayNumberFactory.Create(displayValue);
            var calculatorState = new CalculatorState.Builder().PreviousValue(previousValue)
                                                               .DisplayNumber(displayNumber)
                                                               .IsLastActionAnBinaryOperation(isLastActionAnBinaryOperation)
                                                               .Build();
            _calculator = new Calculator(calculatorState);

            //Act
            _calculator.ApplyThree();

            //Assert
            return _calculator.DisplayValue;
        }

        [Test]
        public void ApplyThree_WhenApplyTwoNumbersAfterOperation_ThenDisplayValueConsistOfTheTwoNumbers()
        {
            //Arrange
            _calculator = new Calculator();

            _calculator.ApplyFour();
            _calculator.ApplyAddition();

            //Act
            _calculator.ApplyThree();
            _calculator.ApplyZero();

            //Assert
            Assert.That(_calculator.DisplayValue, Is.EqualTo("30"));
        }

        #endregion

        #region ApplyFour

        [Test]
        [TestCase(0, "0", false, ExpectedResult = "4")]
        [TestCase(0, "1", false, ExpectedResult = "14")]
        [TestCase(0, "-1", false, ExpectedResult = "-14")]
        [TestCase(0, "0,1", false, ExpectedResult = "0,14")]
        [TestCase(0, "0,", false, ExpectedResult = "0,4")]
        [TestCase(999, "999", true, ExpectedResult = "4")]
        public string TestApplyFour(double previousValue, string displayValue, bool isLastActionAnBinaryOperation)
        {
            //Arrange
            var displayNumber = DisplayNumberFactory.Create(displayValue);
            var calculatorState = new CalculatorState.Builder().PreviousValue(previousValue)
                                                               .DisplayNumber(displayNumber)
                                                               .IsLastActionAnBinaryOperation(isLastActionAnBinaryOperation)
                                                               .Build();
            _calculator = new Calculator(calculatorState);

            //Act
            _calculator.ApplyFour();

            //Assert
            return _calculator.DisplayValue;
        }

        [Test]
        public void ApplyFour_WhenApplyTwoNumbersAfterOperation_ThenDisplayValueConsistOfTheTwoNumbers()
        {
            //Arrange
            _calculator = new Calculator();

            _calculator.ApplyFour();
            _calculator.ApplyAddition();

            //Act
            _calculator.ApplyFour();
            _calculator.ApplyZero();

            //Assert
            Assert.That(_calculator.DisplayValue, Is.EqualTo("40"));
        }

        #endregion

        #region ApplyFive

        [Test]
        [TestCase(0, "0", false, ExpectedResult = "5")]
        [TestCase(0, "1", false, ExpectedResult = "15")]
        [TestCase(0, "-1", false, ExpectedResult = "-15")]
        [TestCase(0, "0,1", false, ExpectedResult = "0,15")]
        [TestCase(0, "0,", false, ExpectedResult = "0,5")]
        [TestCase(999, "999", true, ExpectedResult = "5")]
        public string TestApplyFive(double previousValue, string displayValue, bool isLastActionAnBinaryOperation)
        {
            //Arrange
            var displayNumber = DisplayNumberFactory.Create(displayValue);
            var calculatorState = new CalculatorState.Builder().PreviousValue(previousValue)
                                                               .DisplayNumber(displayNumber)
                                                               .IsLastActionAnBinaryOperation(isLastActionAnBinaryOperation)
                                                               .Build();
            _calculator = new Calculator(calculatorState);

            //Act
            _calculator.ApplyFive();

            //Assert
            return _calculator.DisplayValue;
        }

        [Test]
        public void ApplyFive_WhenApplyTwoNumbersAfterOperation_ThenDisplayValueConsistOfTheTwoNumbers()
        {
            //Arrange
            _calculator = new Calculator();

            _calculator.ApplyFour();
            _calculator.ApplyAddition();

            //Act
            _calculator.ApplyFive();
            _calculator.ApplyZero();

            //Assert
            Assert.That(_calculator.DisplayValue, Is.EqualTo("50"));
        }

        #endregion

        #region ApplySix

        [Test]
        [TestCase(0, "0", false, ExpectedResult = "6")]
        [TestCase(0, "1", false, ExpectedResult = "16")]
        [TestCase(0, "-1", false, ExpectedResult = "-16")]
        [TestCase(0, "0,1", false, ExpectedResult = "0,16")]
        [TestCase(0, "0,", false, ExpectedResult = "0,6")]
        [TestCase(999, "999", true, ExpectedResult = "6")]
        public string TestApplySix(double previousValue, string displayValue, bool isLastActionAnBinaryOperation)
        {
            //Arrange
            var displayNumber = DisplayNumberFactory.Create(displayValue);
            var calculatorState = new CalculatorState.Builder().PreviousValue(previousValue)
                                                               .DisplayNumber(displayNumber)
                                                               .IsLastActionAnBinaryOperation(isLastActionAnBinaryOperation)
                                                               .Build();
            _calculator = new Calculator(calculatorState);

            //Act
            _calculator.ApplySix();

            //Assert
            return _calculator.DisplayValue;
        }

        [Test]
        public void ApplySix_WhenApplyTwoNumbersAfterOperation_ThenDisplayValueConsistOfTheTwoNumbers()
        {
            //Arrange
            _calculator = new Calculator();

            _calculator.ApplyFour();
            _calculator.ApplyAddition();

            //Act
            _calculator.ApplySix();
            _calculator.ApplyZero();

            //Assert
            Assert.That(_calculator.DisplayValue, Is.EqualTo("60"));
        }

        #endregion

        #region ApplySeven

        [Test]
        [TestCase(0, "0", false, ExpectedResult = "7")]
        [TestCase(0, "1", false, ExpectedResult = "17")]
        [TestCase(0, "-1", false, ExpectedResult = "-17")]
        [TestCase(0, "0,1", false, ExpectedResult = "0,17")]
        [TestCase(0, "0,", false, ExpectedResult = "0,7")]
        [TestCase(999, "999", true, ExpectedResult = "7")]
        public string TestApplySeven(double previousValue, string displayValue, bool isLastActionAnBinaryOperation)
        {
            //Arrange
            var displayNumber = DisplayNumberFactory.Create(displayValue);
            var calculatorState = new CalculatorState.Builder().PreviousValue(previousValue)
                                                               .DisplayNumber(displayNumber)
                                                               .IsLastActionAnBinaryOperation(isLastActionAnBinaryOperation)
                                                               .Build();
            _calculator = new Calculator(calculatorState);

            //Act
            _calculator.ApplySeven();

            //Assert
            return _calculator.DisplayValue;
        }

        [Test]
        public void ApplySeven_WhenApplyTwoNumbersAfterOperation_ThenDisplayValueConsistOfTheTwoNumbers()
        {
            //Arrange
            _calculator = new Calculator();

            _calculator.ApplyFour();
            _calculator.ApplyAddition();

            //Act
            _calculator.ApplySeven();
            _calculator.ApplyZero();

            //Assert
            Assert.That(_calculator.DisplayValue, Is.EqualTo("70"));
        }

        #endregion

        #region ApplyEight

        [Test]
        [TestCase(0, "0", false, ExpectedResult = "8")]
        [TestCase(0, "1", false, ExpectedResult = "18")]
        [TestCase(0, "-1", false, ExpectedResult = "-18")]
        [TestCase(0, "0,1", false, ExpectedResult = "0,18")]
        [TestCase(0, "0,", false, ExpectedResult = "0,8")]
        [TestCase(999, "999", true, ExpectedResult = "8")]
        public string TestApplyEight(double previousValue, string displayValue, bool isLastActionAnBinaryOperation)
        {
            //Arrange
            var displayNumber = DisplayNumberFactory.Create(displayValue);
            var calculatorState = new CalculatorState.Builder().PreviousValue(previousValue)
                                                               .DisplayNumber(displayNumber)
                                                               .IsLastActionAnBinaryOperation(isLastActionAnBinaryOperation)
                                                               .Build();
            _calculator = new Calculator(calculatorState);

            //Act
            _calculator.ApplyEight();

            //Assert
            return _calculator.DisplayValue;
        }

        [Test]
        public void ApplyEight_WhenApplyTwoNumbersAfterOperation_ThenDisplayValueConsistOfTheTwoNumbers()
        {
            //Arrange
            _calculator = new Calculator();

            _calculator.ApplyFour();
            _calculator.ApplyAddition();

            //Act
            _calculator.ApplyEight();
            _calculator.ApplyZero();

            //Assert
            Assert.That(_calculator.DisplayValue, Is.EqualTo("80"));
        }

        #endregion

        #region ApplyNine

        [Test]
        [TestCase(0, "0", false, ExpectedResult = "9")]
        [TestCase(0, "1", false, ExpectedResult = "19")]
        [TestCase(0, "-1", false, ExpectedResult = "-19")]
        [TestCase(0, "0,1", false, ExpectedResult = "0,19")]
        [TestCase(0, "0,", false, ExpectedResult = "0,9")]
        [TestCase(999, "999", true, ExpectedResult = "9")]
        public string TestApplyNine(double previousValue, string displayValue, bool isLastActionAnBinaryOperation)
        {
            //Arrange
            var displayNumber = DisplayNumberFactory.Create(displayValue);
            var calculatorState = new CalculatorState.Builder().PreviousValue(previousValue)
                                                               .DisplayNumber(displayNumber)
                                                               .IsLastActionAnBinaryOperation(isLastActionAnBinaryOperation)
                                                               .Build();
            _calculator = new Calculator(calculatorState);

            //Act
            _calculator.ApplyNine();

            //Assert
            return _calculator.DisplayValue;
        }

        [Test]
        public void ApplyNine_WhenApplyTwoNumbersAfterOperation_ThenDisplayValueConsistOfTheTwoNumbers()
        {
            //Arrange
            _calculator = new Calculator();

            _calculator.ApplyFour();
            _calculator.ApplyAddition();

            //Act
            _calculator.ApplyNine();
            _calculator.ApplyZero();

            //Assert
            Assert.That(_calculator.DisplayValue, Is.EqualTo("90"));
        }

        #endregion

        #region ApplyComma

        [Test]
        [TestCase(0, "0", false, ExpectedResult = "0,")]
        [TestCase(0, "1", false, ExpectedResult = "1,")]
        [TestCase(0, "0,", false, ExpectedResult = "0,")]
        [TestCase(0, "-1,", false, ExpectedResult = "-1,")]
        [TestCase(0, "1,234", false, ExpectedResult = "1,234")]
        [TestCase(0, "123", true, ExpectedResult = "0,")]
        public string TestApplyComma(double previousValue, string displayValue, bool isLastActionAnBinaryOperation)
        {
            //Arrange
            var displayNumber = DisplayNumberFactory.Create(displayValue);
            var calculatorState = new CalculatorState.Builder().PreviousValue(previousValue)
                                                               .DisplayNumber(displayNumber)
                                                               .IsLastActionAnBinaryOperation(isLastActionAnBinaryOperation)
                                                               .Build();
            _calculator = new Calculator(calculatorState);

            //Act
            _calculator.ApplyComma();

            //Assert
            return _calculator.DisplayValue;
        }

        #endregion

        #region Clear

        [Test]
        [TestCase("0")]
        [TestCase("0,")]
        [TestCase("1,234")]
        [TestCase("-1,234")]
        public void Clear_WhenAnyDisplayValue_ThenDisplayValueWillBeReset(string displayValue)
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

        #endregion

        #region ClearLastSymbol

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
        public string TestClearLastSymbol(string displayValue, bool isLastActionAnBinaryOperation)
        {
            //Arrange
            var displayNumber = DisplayNumberFactory.Create(displayValue);
            var calculatorState = new CalculatorState.Builder().DisplayNumber(displayNumber)
                                                               .IsLastActionAnBinaryOperation(isLastActionAnBinaryOperation)
                                                               .Build();
            _calculator = new Calculator(calculatorState);

            //Act
            _calculator.ClearLastSymbol();

            //Assert
            return _calculator.DisplayValue;
        }

        #endregion

        #region ApplyNegation

        [Test]
        [TestCase(0, "0", false, ExpectedResult = "0")]
        [TestCase(0, "1", false, ExpectedResult = "-1")]
        [TestCase(0, "-1", false, ExpectedResult = "1")]
        [TestCase(0, "0,1", false, ExpectedResult = "-0,1")]
        [TestCase(0, "0,", false, ExpectedResult = "-0,")]
        [TestCase(0, "0,0", false, ExpectedResult = "-0,0")]
        [TestCase(999, "999", true, ExpectedResult = "-999")]
        public string TestApplyNegation(double previousValue, string displayValue, bool isLastActionAnBinaryOperation)
        {
            //Arrange
            var displayNumber = DisplayNumberFactory.Create(displayValue);
            var calculatorState = new CalculatorState.Builder().PreviousValue(previousValue)
                                                               .DisplayNumber(displayNumber)
                                                               .IsLastActionAnBinaryOperation(isLastActionAnBinaryOperation)
                                                               .Build();
            _calculator = new Calculator(calculatorState);

            //Act
            _calculator.ApplyNegation();

            //Assert
            return _calculator.DisplayValue;
        }

        #endregion

        #region Cancel

        [Test]
        public void Cancel_WhenCancel_ThenDisplayValueIsZero()
        {
            //Arrange
            var displayNumber = DisplayNumberFactory.Create("123");
            var calculatorState = new CalculatorState.Builder().DisplayNumber(displayNumber)
                                                               .Build();
            _calculator = new Calculator(calculatorState);

            //Act
            _calculator.Cancel();

            //Assert
            Assert.That(_calculator.DisplayValue, Is.EqualTo("0"));
        }

        #endregion

        #region Cancel

        [Test]
        public void Cancel_WhenAnyNumberAndOperationWereAppliedAndThenApplyEquality_ThenDisplayValueIsZero()
        {
            //Arrange
            var displayNumber = DisplayNumberFactory.Create("123");
            var calculatorState = new CalculatorState.Builder().PreviousValue(456)
                                                               .DisplayNumber(displayNumber)
                                                               .Build();
            _calculator = new Calculator(calculatorState);

            //Act
            _calculator.Cancel();
            _calculator.ApplyEquality();

            //Assert
            Assert.That(_calculator.DisplayValue, Is.EqualTo("0"));
        }

        #endregion

        #region ApplyAddition

        [Test]
        [TestCase(50, "-10")]
        [TestCase(50, "0")]
        [TestCase(50, "10")]
        [TestCase(50, "1,123")]
        public void ApplyAddition_WhenWasNotAnyOperationBefore_ThenDisplayValueWillNotBeChanged(double previousValue, string displayValue)
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
        public void ApplyAddition_WhenWasOperationBefore_ThenApplyEquation()
        {
            //Arrange
            _calculator = new Calculator();
            _calculator.ApplyTwo();
            _calculator.ApplyFive();
            _calculator.ApplyAddition();
            _calculator.ApplyFour();

            //Act
            _calculator.ApplyAddition();

            //Assert
            Assert.That(_calculator.DisplayValue, Is.EqualTo("29"));
        }

        #endregion

        #region ApplySubtraction

        [Test]
        [TestCase(50, "-10")]
        [TestCase(50, "0")]
        [TestCase(50, "10")]
        [TestCase(50, "1,123")]
        public void ApplySubtraction_WhenWasNotAnyOperationBefore_ThenDisplayValueWillNotBeChanged(double previousValue, string displayValue)
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
        public void ApplySubtraction_WhenWasOperationBefore_ThenApplyEquation()
        {
            //Arrange
            _calculator = new Calculator();
            _calculator.ApplyTwo();
            _calculator.ApplyFive();
            _calculator.ApplyAddition();
            _calculator.ApplyFour();

            //Act
            _calculator.ApplySubtraction();

            //Assert
            Assert.That(_calculator.DisplayValue, Is.EqualTo("29"));
        }

        #endregion

        #region ApplyMultiplication

        [Test]
        [TestCase(50, "-10")]
        [TestCase(50, "0")]
        [TestCase(50, "10")]
        [TestCase(50, "1,123")]
        public void ApplyMultiplication_WhenWasNotAnyOperationBefore_ThenDisplayValueWillNotBeChanged(double previousValue, string displayValue)
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
        public void ApplyMultiplication_WhenWasOperationBefore_ThenApplyEquation()
        {
            //Arrange
            _calculator = new Calculator();
            _calculator.ApplyTwo();
            _calculator.ApplyFive();
            _calculator.ApplyAddition();
            _calculator.ApplyFour();

            //Act
            _calculator.ApplyMultiplication();

            //Assert
            Assert.That(_calculator.DisplayValue, Is.EqualTo("29"));
        }

        #endregion

        #region ApplyDivision

        [Test]
        [TestCase(50, "-10")]
        [TestCase(50, "0")]
        [TestCase(50, "10")]
        [TestCase(50, "1,123")]
        public void ApplyDivision_WhenWasNotAnyOperationBefore_ThenDisplayValueWillNotBeChanged(double previousValue, string displayValue)
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

        [Test]
        public void ApplyDivision_WhenWasOperationBefore_ThenApplyEquation()
        {
            //Arrange
            _calculator = new Calculator();
            _calculator.ApplyTwo();
            _calculator.ApplyFive();
            _calculator.ApplyAddition();
            _calculator.ApplyFour();

            //Act
            _calculator.ApplyDivision();

            //Assert
            Assert.That(_calculator.DisplayValue, Is.EqualTo("29"));
        }

        #endregion

        #region ApplyEquality

        [Test]
        public void ApplyEquality_WhenWasNotAnyOperation_ThenDisplayValueWillNotChanged()
        {
            //Arrange
            _calculator = new Calculator();

            _calculator.ApplyThree();

            //Act
            _calculator.ApplyEquality();

            //Assert
            Assert.That(_calculator.DisplayValue, Is.EqualTo("3"));
        }

        [Test]
        public void ApplyEquality_WhenAdditionWasApplied_ThenSumNumbers()
        {
            //Arrange
            _calculator = new Calculator();

            _calculator.ApplyTwo();
            _calculator.ApplyAddition();
            _calculator.ApplyThree();

            //Act
            _calculator.ApplyEquality();

            //Assert
            Assert.That(_calculator.DisplayValue, Is.EqualTo("5"));
        }

        [Test]
        public void ApplyEquality_WhenSubtractionWasApplied_ThenSubtractNumbers()
        {
            //Arrange
            _calculator = new Calculator();

            _calculator.ApplyTwo();
            _calculator.ApplySubtraction();
            _calculator.ApplyThree();

            //Act
            _calculator.ApplyEquality();

            //Assert
            Assert.That(_calculator.DisplayValue, Is.EqualTo("-1"));
        }

        [Test]
        public void ApplyEquality_WhenMultiplicationWasApplied_ThenMultNumbers()
        {
            //Arrange
            _calculator = new Calculator();

            _calculator.ApplyTwo();
            _calculator.ApplyMultiplication();
            _calculator.ApplyThree();

            //Act
            _calculator.ApplyEquality();

            //Assert
            Assert.That(_calculator.DisplayValue, Is.EqualTo("6"));
        }

        [Test]
        public void ApplyEquality_WhenDivisionWasApplied_ThenDivideNumbers()
        {
            //Arrange
            _calculator = new Calculator();

            _calculator.ApplyTwo();
            _calculator.ApplyDivision();
            _calculator.ApplyFour();

            //Act
            _calculator.ApplyEquality();

            //Assert
            Assert.That(_calculator.DisplayValue, Is.EqualTo("0,5"));
        }

        [Test]
        public void ApplyEquality_WhenOperationIsDivisionAndValueIsZero_ThenDisplayValueShouldBeCannotDivideByZero()
        {
            //Arrange
            _calculator = new Calculator();

            _calculator.ApplyTwo();
            _calculator.ApplyDivision();
            _calculator.ApplyZero();

            //Act
            _calculator.ApplyEquality();

            //Assert
            Assert.That(_calculator.DisplayValue, Is.EqualTo(ErrorMessages.DivisionOnZero));
        }

        [Test]
        public void ApplyEquality_WhenApplyAdditionAndSetAnyValue_ThenDisplayValueShouldBeTheValue()
        {
            //Arrange
            _calculator = new Calculator();

            _calculator.ApplyAddition();
            _calculator.ApplyThree();

            //Act
            _calculator.ApplyEquality();

            //Assert
            Assert.That(_calculator.DisplayValue, Is.EqualTo("3"));
        }

        [Test]
        public void ApplyEquation_WhenEquationWasAppliedAndAnotherNumberWasSetAndThenApplyEquation_ThenApplyBinaryOperationToTheNewNumber()
        {
            //Arrange
            _calculator = new Calculator();

            _calculator.ApplyThree();
            _calculator.ApplyMultiplication();
            _calculator.ApplyTwo();
            _calculator.ApplyEquality();
            _calculator.ApplyFive();

            //Act
            _calculator.ApplyEquality();

            //Assert
            Assert.That(_calculator.DisplayValue, Is.EqualTo("10"));
        }

        #endregion

        #region ApplyPercent

        [Test]
        public void ApplyPercent_WhenOperationAndTwoNumbersAppliedAndApplyEquationSeveralTimes_ThenTheOperationShouldBeApplied()
        {
            //Arrange
            _calculator = new Calculator();

            _calculator.ApplyFour();
            _calculator.ApplyAddition();
            _calculator.ApplyTwo();
            _calculator.ApplyFive();
            _calculator.ApplyPercent();

            //Act & Assert
            _calculator.ApplyEquality();
            Assert.That(_calculator.DisplayValue, Is.EqualTo("5"));

            _calculator.ApplyEquality();
            Assert.That(_calculator.DisplayValue, Is.EqualTo("6"));
        }

        [Test]
        public void ApplyPercent_WhenOperationAndTwoNumbersApplied_ThenInvokeOperationWithSecondOperandAsPercent()
        {
            //Arrange
            _calculator = new Calculator();

            _calculator.ApplyFour();
            _calculator.ApplyAddition();
            _calculator.ApplyTwo();
            _calculator.ApplyFive();

            //Act
            _calculator.ApplyPercent();

            //Assert
            Assert.That(_calculator.DisplayValue, Is.EqualTo("1"));
        }

        #endregion

        #region ApplySquareRoot

        [Test]
        public void ApplySquareRoot_WhenApplyEquationSeveralTimes_ThenDisplayValueShouldNotChange()
        {
            //Arrange
            _calculator = new Calculator();

            _calculator.ApplyFour();
            _calculator.ApplySquareRoot();

            //Act & Assert
            _calculator.ApplyEquality();
            Assert.That(_calculator.DisplayValue, Is.EqualTo("2"));

            _calculator.ApplyEquality();
            Assert.That(_calculator.DisplayValue, Is.EqualTo("2"));

            _calculator.ApplyEquality();
            Assert.That(_calculator.DisplayValue, Is.EqualTo("2"));
        }

        [Test]
        public void ApplySquareRoot_WhenNumberIsNotNegative_ThenDisplaySquaringResult()
        {
            //Arrange
            _calculator = new Calculator();

            _calculator.ApplyFour();

            //Act
            _calculator.ApplySquareRoot();

            //Assert
            Assert.That(_calculator.DisplayValue, Is.EqualTo("2"));
        }

        [Test]
        public void ApplySquareRoot_WhenNumberIsNegative_ThenDisplayInvalidInput()
        {
            //Arrange
            _calculator = new Calculator();

            _calculator.ApplyTwo();
            _calculator.ApplyNegation();

            //Act
            _calculator.ApplySquareRoot();

            //Assert
            Assert.That(_calculator.DisplayValue, Is.EqualTo(ErrorMessages.InvalidInput));
        }

        [Test]
        public void ApplySquareRoot_WhenApplySquaringSeveralTimes_ThenApplySquaringTheSameTimes()
        {
            //Arrange
            _calculator = new Calculator();

            _calculator.ApplyTwo();
            _calculator.ApplyFive();
            _calculator.ApplySix();

            //Act & Assert
            _calculator.ApplySquareRoot();
            Assert.That(_calculator.DisplayValue, Is.EqualTo("16"));

            _calculator.ApplySquareRoot();
            Assert.That(_calculator.DisplayValue, Is.EqualTo("4"));

            _calculator.ApplySquareRoot();
            Assert.That(_calculator.DisplayValue, Is.EqualTo("2"));
        }

        #endregion

        #region ApplySquaring

        [Test]
        public void ApplySquaring_WhenApplyEquationSeveralTimes_ThenDisplayValueShouldNotChange()
        {
            //Arrange
            _calculator = new Calculator();

            _calculator.ApplyFour();
            _calculator.ApplySquaring();

            //Act & Assert
            _calculator.ApplyEquality();
            Assert.That(_calculator.DisplayValue, Is.EqualTo("16"));

            _calculator.ApplyEquality();
            Assert.That(_calculator.DisplayValue, Is.EqualTo("16"));

            _calculator.ApplyEquality();
            Assert.That(_calculator.DisplayValue, Is.EqualTo("16"));
        }

        [Test]
        public void ApplySquaring_WhenAnyNumber_ThenDisplaySquaringResult()
        {
            //Arrange
            _calculator = new Calculator();

            _calculator.ApplyFour();

            //Act
            _calculator.ApplySquaring();

            //Assert
            Assert.That(_calculator.DisplayValue, Is.EqualTo("16"));
        }

        [Test]
        public void ApplySquaring_WhenApplySquaringSeveralTimes_ThenApplySquaringTheSameTimes()
        {
            //Arrange
            _calculator = new Calculator();

            _calculator.ApplyTwo();

            //Act & Assert
            _calculator.ApplySquaring();
            Assert.That(_calculator.DisplayValue, Is.EqualTo("4"));

            _calculator.ApplySquaring();
            Assert.That(_calculator.DisplayValue, Is.EqualTo("16"));

            _calculator.ApplySquaring();
            Assert.That(_calculator.DisplayValue, Is.EqualTo("256"));
        }

        #endregion

        #region ApplyTurningOver

        [Test]
        public void ApplyTurningOver_WhenApplyEquationSeveralTimes_ThenDisplayValueShouldNotChange()
        {
            //Arrange
            _calculator = new Calculator();

            _calculator.ApplyFive();
            _calculator.ApplyTurningOver();

            //Act & Assert
            _calculator.ApplyEquality();
            Assert.That(_calculator.DisplayValue, Is.EqualTo("0,2"));

            _calculator.ApplyEquality();
            Assert.That(_calculator.DisplayValue, Is.EqualTo("0,2"));

            _calculator.ApplyEquality();
            Assert.That(_calculator.DisplayValue, Is.EqualTo("0,2"));
        }

        [Test]
        public void ApplyTurningOver_WhenNumberIsNotZero_ThenDisplayTurningOver()
        {
            //Arrange
            _calculator = new Calculator();

            _calculator.ApplyFive();

            //Act
            _calculator.ApplyTurningOver();

            //Assert
            Assert.That(_calculator.DisplayValue, Is.EqualTo("0,2"));
        }

        [Test]
        public void ApplyTurningOver_WhenNumberIsZero_ThenDisplayDivisionOnZero()
        {
            //Arrange
            _calculator = new Calculator();

            _calculator.ApplyZero();

            //Act
            _calculator.ApplyTurningOver();

            //Assert
            Assert.That(_calculator.DisplayValue, Is.EqualTo(ErrorMessages.DivisionOnZero));
        }

        [Test]
        public void ApplyTurningOver_WhenApplyTurningOverTimes_ThenTurningOverShouldBeAppliedTheSameTimes()
        {
            //Arrange
            _calculator = new Calculator();

            _calculator.ApplyFive();

            //Act & Assert
            _calculator.ApplyTurningOver();
            Assert.That(_calculator.DisplayValue, Is.EqualTo("0,2"));

            _calculator.ApplyTurningOver();
            Assert.That(_calculator.DisplayValue, Is.EqualTo("5"));

            _calculator.ApplyTurningOver();
            Assert.That(_calculator.DisplayValue, Is.EqualTo("0,2"));
        }

        #endregion
    }
}
