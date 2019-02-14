using System;
using Calculator.BusinessLogic.Constants;
using NUnit.Framework;

namespace Calculator.BusinessLogic.UnitTests
{
    [TestFixture]
    public class CalculatorTests
    {
        #region DisplayValue

        [Test]
        public void DisplayValue_InitialDefaultValueIsZero()
        {
            //Arrange
            var calculator = new Calculator();

            //Assert
            Assert.That(calculator.DisplayValue, Is.EqualTo("0"));
        }

        #endregion

        #region DisplayValueChanged

        [Test]
        public void DisplayValueChanged_WhenDisplayValueIsChanged_ThenDisplayValueChangedShouldBeRaised()
        {
            //Arrange
            var calculator = new Calculator();
            bool isRaised = false;
            calculator.DisplayValueChanged.Subscribe(x =>
            {
                isRaised = true;
            });

            //Act
            calculator.ApplyTwo();

            //Assert
            Assert.That(isRaised, Is.True);
        }

        [Test]
        public void DisplayValueChanged_WhenDisplayValueIsChanged_ThenPassedValueShouldBeEqualDisplayValue()
        {
            //Arrange
            var calculator = new Calculator();
            string displayValue = null;
            calculator.DisplayValueChanged.Subscribe(x =>
            {
                displayValue = x;
            });

            //Act
            calculator.ApplyTwo();

            //Assert
            Assert.That(displayValue, Is.EqualTo(calculator.DisplayValue));
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
            var calculator = new Calculator(calculatorState);

            //Act
            calculator.ApplyZero();

            //Assert
            return calculator.DisplayValue;
        }

        [Test]
        public void ApplyZero_WhenApplyTwoNumbersAfterOperation_ThenDisplayValueConsistOfTheTwoNumbers()
        {
            //Arrange
            var calculator = new Calculator();

            calculator.ApplyFour();
            calculator.ApplyAddition();

            //Act
            calculator.ApplyZero();
            calculator.ApplyZero();

            //Assert
            Assert.That(calculator.DisplayValue, Is.EqualTo("0"));
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
            var calculator = new Calculator(calculatorState);

            //Act
            calculator.ApplyOne();

            //Assert
            return calculator.DisplayValue;
        }

        [Test]
        public void ApplyOne_WhenApplyTwoNumbersAfterOperation_ThenDisplayValueConsistOfTheTwoNumbers()
        {
            //Arrange
            var calculator = new Calculator();

            calculator.ApplyFour();
            calculator.ApplyAddition();

            //Act
            calculator.ApplyOne();
            calculator.ApplyZero();

            //Assert
            Assert.That(calculator.DisplayValue, Is.EqualTo("10"));
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
            var calculator = new Calculator(calculatorState);

            //Act
            calculator.ApplyTwo();

            //Assert
            return calculator.DisplayValue;
        }

        [Test]
        public void ApplyTwo_WhenApplyTwoNumbersAfterOperation_ThenDisplayValueConsistOfTheTwoNumbers()
        {
            //Arrange
            var calculator = new Calculator();

            calculator.ApplyFour();
            calculator.ApplyAddition();

            //Act
            calculator.ApplyTwo();
            calculator.ApplyZero();

            //Assert
            Assert.That(calculator.DisplayValue, Is.EqualTo("20"));
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
            var calculator = new Calculator(calculatorState);

            //Act
            calculator.ApplyThree();

            //Assert
            return calculator.DisplayValue;
        }

        [Test]
        public void ApplyThree_WhenApplyTwoNumbersAfterOperation_ThenDisplayValueConsistOfTheTwoNumbers()
        {
            //Arrange
            var calculator = new Calculator();

            calculator.ApplyFour();
            calculator.ApplyAddition();

            //Act
            calculator.ApplyThree();
            calculator.ApplyZero();

            //Assert
            Assert.That(calculator.DisplayValue, Is.EqualTo("30"));
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
            var calculator = new Calculator(calculatorState);

            //Act
            calculator.ApplyFour();

            //Assert
            return calculator.DisplayValue;
        }

        [Test]
        public void ApplyFour_WhenApplyTwoNumbersAfterOperation_ThenDisplayValueConsistOfTheTwoNumbers()
        {
            //Arrange
            var calculator = new Calculator();

            calculator.ApplyFour();
            calculator.ApplyAddition();

            //Act
            calculator.ApplyFour();
            calculator.ApplyZero();

            //Assert
            Assert.That(calculator.DisplayValue, Is.EqualTo("40"));
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
            var calculator = new Calculator(calculatorState);

            //Act
            calculator.ApplyFive();

            //Assert
            return calculator.DisplayValue;
        }

        [Test]
        public void ApplyFive_WhenApplyTwoNumbersAfterOperation_ThenDisplayValueConsistOfTheTwoNumbers()
        {
            //Arrange
            var calculator = new Calculator();

            calculator.ApplyFour();
            calculator.ApplyAddition();

            //Act
            calculator.ApplyFive();
            calculator.ApplyZero();

            //Assert
            Assert.That(calculator.DisplayValue, Is.EqualTo("50"));
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
            var calculator = new Calculator(calculatorState);

            //Act
            calculator.ApplySix();

            //Assert
            return calculator.DisplayValue;
        }

        [Test]
        public void ApplySix_WhenApplyTwoNumbersAfterOperation_ThenDisplayValueConsistOfTheTwoNumbers()
        {
            //Arrange
            var calculator = new Calculator();

            calculator.ApplyFour();
            calculator.ApplyAddition();

            //Act
            calculator.ApplySix();
            calculator.ApplyZero();

            //Assert
            Assert.That(calculator.DisplayValue, Is.EqualTo("60"));
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
            var calculator = new Calculator(calculatorState);

            //Act
            calculator.ApplySeven();

            //Assert
            return calculator.DisplayValue;
        }

        [Test]
        public void ApplySeven_WhenApplyTwoNumbersAfterOperation_ThenDisplayValueConsistOfTheTwoNumbers()
        {
            //Arrange
            var calculator = new Calculator();

            calculator.ApplyFour();
            calculator.ApplyAddition();

            //Act
            calculator.ApplySeven();
            calculator.ApplyZero();

            //Assert
            Assert.That(calculator.DisplayValue, Is.EqualTo("70"));
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
            var calculator = new Calculator(calculatorState);

            //Act
            calculator.ApplyEight();

            //Assert
            return calculator.DisplayValue;
        }

        [Test]
        public void ApplyEight_WhenApplyTwoNumbersAfterOperation_ThenDisplayValueConsistOfTheTwoNumbers()
        {
            //Arrange
            var calculator = new Calculator();

            calculator.ApplyFour();
            calculator.ApplyAddition();

            //Act
            calculator.ApplyEight();
            calculator.ApplyZero();

            //Assert
            Assert.That(calculator.DisplayValue, Is.EqualTo("80"));
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
            var calculator = new Calculator(calculatorState);

            //Act
            calculator.ApplyNine();

            //Assert
            return calculator.DisplayValue;
        }

        [Test]
        public void ApplyNine_WhenApplyTwoNumbersAfterOperation_ThenDisplayValueConsistOfTheTwoNumbers()
        {
            //Arrange
            var calculator = new Calculator();

            calculator.ApplyFour();
            calculator.ApplyAddition();

            //Act
            calculator.ApplyNine();
            calculator.ApplyZero();

            //Assert
            Assert.That(calculator.DisplayValue, Is.EqualTo("90"));
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
            var calculator = new Calculator(calculatorState);

            //Act
            calculator.ApplyComma();

            //Assert
            return calculator.DisplayValue;
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
            var calculator = new Calculator(calculatorState);

            //Act
            calculator.Clear();

            //Assert
            Assert.That(calculator.DisplayValue, Is.EqualTo("0"));
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
            var calculator = new Calculator(calculatorState);

            //Act
            calculator.ClearLastSymbol();

            //Assert
            return calculator.DisplayValue;
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
            var calculator = new Calculator(calculatorState);

            //Act
            calculator.ApplyNegation();

            //Assert
            return calculator.DisplayValue;
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
            var calculator = new Calculator(calculatorState);

            //Act
            calculator.Cancel();

            //Assert
            Assert.That(calculator.DisplayValue, Is.EqualTo("0"));
        }

        [Test]
        public void Cancel_WhenAnyNumberAndOperationWereAppliedAndThenApplyEquality_ThenDisplayValueIsZero()
        {
            //Arrange
            var displayNumber = DisplayNumberFactory.Create("123");
            var calculatorState = new CalculatorState.Builder().PreviousValue(456)
                                                               .DisplayNumber(displayNumber)
                                                               .Build();
            var calculator = new Calculator(calculatorState);

            //Act
            calculator.Cancel();
            calculator.ApplyEquality();

            //Assert
            Assert.That(calculator.DisplayValue, Is.EqualTo("0"));
        }

        [Test]
        public void Cancel_WhenTwoNumbersAndOperationWereAppliedThenCancelAndApplyEquality_ThenDisplayValueShouldBeZero()
        {
            //Arrange
            var calculator = new Calculator();
            calculator.ApplyThree();
            calculator.ApplyAddition();
            calculator.ApplyTwo();

            //Act
            calculator.Cancel();
            calculator.ApplyEquality();

            //Assert
            Assert.That(calculator.DisplayValue, Is.EqualTo("0"));
        }

        [Test]
        public void Cancel_WhenTwoNumbersAndOperationWereAppliedThenApplyEqualityAndCancelAndApplyEqualityAgain_ThenDisplayValueShouldBeZero()
        {
            //Arrange
            var calculator = new Calculator();
            calculator.ApplyThree();
            calculator.ApplyAddition();
            calculator.ApplyTwo();

            //Act
            calculator.ApplyEquality();
            calculator.Cancel();
            calculator.ApplyEquality();

            //Assert
            Assert.That(calculator.DisplayValue, Is.EqualTo("0"));
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
            var calculator = new Calculator(calculatorState);
            var initialDisplayValue = calculator.DisplayValue;

            //Act
            calculator.ApplyAddition();

            //Assert
            Assert.That(calculator.DisplayValue, Is.EqualTo(initialDisplayValue));
        }

        [Test]
        public void ApplyAddition_WhenWasOperationBefore_ThenApplyEquation()
        {
            //Arrange
            var calculator = new Calculator();
            calculator.ApplyTwo();
            calculator.ApplyFive();
            calculator.ApplyAddition();
            calculator.ApplyFour();

            //Act
            calculator.ApplyAddition();

            //Assert
            Assert.That(calculator.DisplayValue, Is.EqualTo("29"));
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
            var calculator = new Calculator(calculatorState);
            var initialDisplayValue = calculator.DisplayValue;

            //Act
            calculator.ApplySubtraction();

            //Assert
            Assert.That(calculator.DisplayValue, Is.EqualTo(initialDisplayValue));
        }

        [Test]
        public void ApplySubtraction_WhenWasOperationBefore_ThenApplyEquation()
        {
            //Arrange
            var calculator = new Calculator();
            calculator.ApplyTwo();
            calculator.ApplyFive();
            calculator.ApplyAddition();
            calculator.ApplyFour();

            //Act
            calculator.ApplySubtraction();

            //Assert
            Assert.That(calculator.DisplayValue, Is.EqualTo("29"));
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
            var calculator = new Calculator(calculatorState);
            var initialDisplayValue = calculator.DisplayValue;

            //Act
            calculator.ApplyMultiplication();

            //Assert
            Assert.That(calculator.DisplayValue, Is.EqualTo(initialDisplayValue));
        }

        [Test]
        public void ApplyMultiplication_WhenWasOperationBefore_ThenApplyEquation()
        {
            //Arrange
            var calculator = new Calculator();
            calculator.ApplyTwo();
            calculator.ApplyFive();
            calculator.ApplyAddition();
            calculator.ApplyFour();

            //Act
            calculator.ApplyMultiplication();

            //Assert
            Assert.That(calculator.DisplayValue, Is.EqualTo("29"));
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
            var calculator = new Calculator(calculatorState);
            var initialDisplayValue = calculator.DisplayValue;

            //Act
            calculator.ApplyDivision();

            //Assert
            Assert.That(calculator.DisplayValue, Is.EqualTo(initialDisplayValue));
        }

        [Test]
        public void ApplyDivision_WhenWasOperationBefore_ThenApplyEquation()
        {
            //Arrange
            var calculator = new Calculator();
            calculator.ApplyTwo();
            calculator.ApplyFive();
            calculator.ApplyAddition();
            calculator.ApplyFour();

            //Act
            calculator.ApplyDivision();

            //Assert
            Assert.That(calculator.DisplayValue, Is.EqualTo("29"));
        }

        #endregion

        #region ApplyEquality

        [Test]
        public void ApplyEquality_WhenWasNotAnyOperation_ThenDisplayValueWillNotChanged()
        {
            //Arrange
            var calculator = new Calculator();

            calculator.ApplyThree();

            //Act
            calculator.ApplyEquality();

            //Assert
            Assert.That(calculator.DisplayValue, Is.EqualTo("3"));
        }

        [Test]
        public void ApplyEquality_WhenAdditionWasApplied_ThenSumNumbers()
        {
            //Arrange
            var calculator = new Calculator();

            calculator.ApplyTwo();
            calculator.ApplyAddition();
            calculator.ApplyThree();

            //Act
            calculator.ApplyEquality();

            //Assert
            Assert.That(calculator.DisplayValue, Is.EqualTo("5"));
        }

        [Test]
        public void ApplyEquality_WhenSubtractionWasApplied_ThenSubtractNumbers()
        {
            //Arrange
            var calculator = new Calculator();

            calculator.ApplyTwo();
            calculator.ApplySubtraction();
            calculator.ApplyThree();

            //Act
            calculator.ApplyEquality();

            //Assert
            Assert.That(calculator.DisplayValue, Is.EqualTo("-1"));
        }

        [Test]
        public void ApplyEquality_WhenMultiplicationWasApplied_ThenMultNumbers()
        {
            //Arrange
            var calculator = new Calculator();

            calculator.ApplyTwo();
            calculator.ApplyMultiplication();
            calculator.ApplyThree();

            //Act
            calculator.ApplyEquality();

            //Assert
            Assert.That(calculator.DisplayValue, Is.EqualTo("6"));
        }

        [Test]
        public void ApplyEquality_WhenDivisionWasApplied_ThenDivideNumbers()
        {
            //Arrange
            var calculator = new Calculator();

            calculator.ApplyTwo();
            calculator.ApplyDivision();
            calculator.ApplyFour();

            //Act
            calculator.ApplyEquality();

            //Assert
            Assert.That(calculator.DisplayValue, Is.EqualTo("0,5"));
        }

        [Test]
        public void ApplyEquality_WhenOperationIsDivisionAndValueIsZero_ThenDisplayValueShouldBeCannotDivideByZero()
        {
            //Arrange
            var calculator = new Calculator();

            calculator.ApplyTwo();
            calculator.ApplyDivision();
            calculator.ApplyZero();

            //Act
            calculator.ApplyEquality();

            //Assert
            Assert.That(calculator.DisplayValue, Is.EqualTo(ErrorMessages.DivisionOnZero));
        }

        [Test]
        public void ApplyEquality_WhenApplyAdditionAndSetAnyValue_ThenDisplayValueShouldBeTheValue()
        {
            //Arrange
            var calculator = new Calculator();

            calculator.ApplyAddition();
            calculator.ApplyThree();

            //Act
            calculator.ApplyEquality();

            //Assert
            Assert.That(calculator.DisplayValue, Is.EqualTo("3"));
        }

        [Test]
        public void ApplyEquation_WhenEquationWasAppliedAndAnotherNumberWasSetAndThenApplyEquation_ThenApplyBinaryOperationToTheNewNumber()
        {
            //Arrange
            var calculator = new Calculator();

            calculator.ApplyThree();
            calculator.ApplyMultiplication();
            calculator.ApplyTwo();
            calculator.ApplyEquality();
            calculator.ApplyFive();

            //Act
            calculator.ApplyEquality();

            //Assert
            Assert.That(calculator.DisplayValue, Is.EqualTo("10"));
        }

        #endregion

        #region ApplyPercent

        [Test]
        public void ApplyPercent_WhenOperationAndTwoNumbersAppliedAndApplyEquationSeveralTimes_ThenTheOperationShouldBeApplied()
        {
            //Arrange
            var calculator = new Calculator();

            calculator.ApplyFour();
            calculator.ApplyAddition();
            calculator.ApplyTwo();
            calculator.ApplyFive();
            calculator.ApplyPercent();

            //Act & Assert
            calculator.ApplyEquality();
            Assert.That(calculator.DisplayValue, Is.EqualTo("5"));

            calculator.ApplyEquality();
            Assert.That(calculator.DisplayValue, Is.EqualTo("6"));
        }

        [Test]
        public void ApplyPercent_WhenOperationAndTwoNumbersApplied_ThenInvokeOperationWithSecondOperandAsPercent()
        {
            //Arrange
            var calculator = new Calculator();

            calculator.ApplyFour();
            calculator.ApplyAddition();
            calculator.ApplyTwo();
            calculator.ApplyFive();

            //Act
            calculator.ApplyPercent();

            //Assert
            Assert.That(calculator.DisplayValue, Is.EqualTo("1"));
        }

        #endregion

        #region ApplySquareRoot

        [Test]
        public void ApplySquareRoot_WhenApplyEquationSeveralTimes_ThenDisplayValueShouldNotChange()
        {
            //Arrange
            var calculator = new Calculator();

            calculator.ApplyFour();
            calculator.ApplySquareRoot();

            //Act & Assert
            calculator.ApplyEquality();
            Assert.That(calculator.DisplayValue, Is.EqualTo("2"));

            calculator.ApplyEquality();
            Assert.That(calculator.DisplayValue, Is.EqualTo("2"));

            calculator.ApplyEquality();
            Assert.That(calculator.DisplayValue, Is.EqualTo("2"));
        }

        [Test]
        public void ApplySquareRoot_WhenNumberIsNotNegative_ThenDisplaySquaringResult()
        {
            //Arrange
            var calculator = new Calculator();

            calculator.ApplyFour();

            //Act
            calculator.ApplySquareRoot();

            //Assert
            Assert.That(calculator.DisplayValue, Is.EqualTo("2"));
        }

        [Test]
        public void ApplySquareRoot_WhenNumberIsNegative_ThenDisplayInvalidInput()
        {
            //Arrange
            var calculator = new Calculator();

            calculator.ApplyTwo();
            calculator.ApplyNegation();

            //Act
            calculator.ApplySquareRoot();

            //Assert
            Assert.That(calculator.DisplayValue, Is.EqualTo(ErrorMessages.InvalidInput));
        }

        [Test]
        public void ApplySquareRoot_WhenApplySquaringSeveralTimes_ThenApplySquaringTheSameTimes()
        {
            //Arrange
            var calculator = new Calculator();

            calculator.ApplyTwo();
            calculator.ApplyFive();
            calculator.ApplySix();

            //Act & Assert
            calculator.ApplySquareRoot();
            Assert.That(calculator.DisplayValue, Is.EqualTo("16"));

            calculator.ApplySquareRoot();
            Assert.That(calculator.DisplayValue, Is.EqualTo("4"));

            calculator.ApplySquareRoot();
            Assert.That(calculator.DisplayValue, Is.EqualTo("2"));
        }

        #endregion

        #region ApplySquaring

        [Test]
        public void ApplySquaring_WhenApplyEquationSeveralTimes_ThenDisplayValueShouldNotChange()
        {
            //Arrange
            var calculator = new Calculator();

            calculator.ApplyFour();
            calculator.ApplySquaring();

            //Act & Assert
            calculator.ApplyEquality();
            Assert.That(calculator.DisplayValue, Is.EqualTo("16"));

            calculator.ApplyEquality();
            Assert.That(calculator.DisplayValue, Is.EqualTo("16"));

            calculator.ApplyEquality();
            Assert.That(calculator.DisplayValue, Is.EqualTo("16"));
        }

        [Test]
        public void ApplySquaring_WhenAnyNumber_ThenDisplaySquaringResult()
        {
            //Arrange
            var calculator = new Calculator();

            calculator.ApplyFour();

            //Act
            calculator.ApplySquaring();

            //Assert
            Assert.That(calculator.DisplayValue, Is.EqualTo("16"));
        }

        [Test]
        public void ApplySquaring_WhenApplySquaringSeveralTimes_ThenApplySquaringTheSameTimes()
        {
            //Arrange
            var calculator = new Calculator();

            calculator.ApplyTwo();

            //Act & Assert
            calculator.ApplySquaring();
            Assert.That(calculator.DisplayValue, Is.EqualTo("4"));

            calculator.ApplySquaring();
            Assert.That(calculator.DisplayValue, Is.EqualTo("16"));

            calculator.ApplySquaring();
            Assert.That(calculator.DisplayValue, Is.EqualTo("256"));
        }

        #endregion

        #region ApplyTurningOver

        [Test]
        public void ApplyTurningOver_WhenApplyEquationSeveralTimes_ThenDisplayValueShouldNotChange()
        {
            //Arrange
            var calculator = new Calculator();

            calculator.ApplyFive();
            calculator.ApplyTurningOver();

            //Act & Assert
            calculator.ApplyEquality();
            Assert.That(calculator.DisplayValue, Is.EqualTo("0,2"));

            calculator.ApplyEquality();
            Assert.That(calculator.DisplayValue, Is.EqualTo("0,2"));

            calculator.ApplyEquality();
            Assert.That(calculator.DisplayValue, Is.EqualTo("0,2"));
        }

        [Test]
        public void ApplyTurningOver_WhenNumberIsNotZero_ThenDisplayTurningOver()
        {
            //Arrange
            var calculator = new Calculator();

            calculator.ApplyFive();

            //Act
            calculator.ApplyTurningOver();

            //Assert
            Assert.That(calculator.DisplayValue, Is.EqualTo("0,2"));
        }

        [Test]
        public void ApplyTurningOver_WhenNumberIsZero_ThenDisplayDivisionOnZero()
        {
            //Arrange
            var calculator = new Calculator();

            calculator.ApplyZero();

            //Act
            calculator.ApplyTurningOver();

            //Assert
            Assert.That(calculator.DisplayValue, Is.EqualTo(ErrorMessages.DivisionOnZero));
        }

        [Test]
        public void ApplyTurningOver_WhenApplyTurningOverTimes_ThenTurningOverShouldBeAppliedTheSameTimes()
        {
            //Arrange
            var calculator = new Calculator();

            calculator.ApplyFive();

            //Act & Assert
            calculator.ApplyTurningOver();
            Assert.That(calculator.DisplayValue, Is.EqualTo("0,2"));

            calculator.ApplyTurningOver();
            Assert.That(calculator.DisplayValue, Is.EqualTo("5"));

            calculator.ApplyTurningOver();
            Assert.That(calculator.DisplayValue, Is.EqualTo("0,2"));
        }

        #endregion

        #region Scenarios

        [Test]
        public void WhenOperationAndTwoNumbersAppliedAndApplyEquationSeveralTimes_ThenApplyTheOperationTheSameTimes()
        {
            //Arrange
            var calculator = new Calculator();

            calculator.ApplyThree();
            calculator.ApplyAddition();
            calculator.ApplyTwo();

            //Act & Assert
            for (int i = 1; i < 10; i++)
            {
                calculator.ApplyEquality();
                var expectedValue = 3 + 2 * i;
                Assert.That(calculator.DisplayValue, Is.EqualTo(expectedValue.ToString()));
            }
        }

        [Test]
        public void WhenOperationAndTwoNumbersAppliedAndApplyAnyBinaryOpartion_ThenApplyTheOperationSingleTime()
        {
            //Arrange
            var calculator = new Calculator();

            calculator.ApplyThree();
            calculator.ApplyAddition();
            calculator.ApplyTwo();

            //Act
            calculator.ApplyAddition();
            calculator.ApplyAddition();
            calculator.ApplyAddition();
            calculator.ApplyAddition();
            calculator.ApplyAddition();
            calculator.ApplyAddition();
            calculator.ApplyAddition();

            //Assert
            Assert.That(calculator.DisplayValue, Is.EqualTo("5"));
        }

        [Test]
        public void WhenApplyOperationAfterNegativeNumberAndTypeAnotherNumber_ThenTheLastNumberShouldBeTheTypedNumber()
        {
            //Arrange
            var calculator = new Calculator();

            //Act
            calculator.ApplySeven();
            calculator.ApplyNegation();
            calculator.ApplyMultiplication();
            calculator.ApplyThree();
            calculator.ApplyComma();
            calculator.ApplyFour();

            //Assert
            Assert.That(calculator.DisplayValue, Is.EqualTo("3,4"));
        }

        #endregion
    }
}
