﻿using System;
using System.Globalization;
using Calculator.BusinessLogic.Operations.Binary;
using Calculator.BusinessLogic.Operations.Unary;

namespace Calculator.BusinessLogic
{
    public class Calculator : ICalculator
    {
        #region Fields

        private readonly CultureInfo _cultureInfo;
        private DisplayNumber _displayNumber = new DisplayNumber();
        private IBinaryOperation _selectedBinaryOperation;
        private bool _isLastActionAnBinaryOperation;

        private double? _lastOperand1;
        private double _lastOperand2;
        private IBinaryOperation _lastBinaryOperation;
        private double _lastResult;

        #endregion

        #region Ctor

        public Calculator()
        {
            var cultureInfo = (CultureInfo) CultureInfo.InvariantCulture.Clone();
            cultureInfo.NumberFormat.NumberDecimalSeparator = ",";
            _cultureInfo = cultureInfo;

            DisplayValue = _displayNumber.ToString();
        }

        internal Calculator(CalculatorState state)
            : this()
        {
            _lastOperand1 = state.PreviousValue;
            _displayNumber = state.DisplayNumber;
            _isLastActionAnBinaryOperation = state.IsLastActionAnBinaryOperation;
            DisplayValue = _displayNumber.ToString();
        }

        #endregion

        #region Implementation of ICalculator

        public string DisplayValue { get; private set; }

        public void ApplyZero()
        {
            ChangeDisplayNumber(() =>
            {
                ApplyNumber('0');
            });
        }

        public void ApplyOne()
        {
            ChangeDisplayNumber(() =>
            {
                ApplyNumber('1');
            });
        }

        public void ApplyTwo()
        {
            ChangeDisplayNumber(() =>
            {
                ApplyNumber('2');
            });
        }

        public void ApplyThree()
        {
            ChangeDisplayNumber(() =>
            {
                ApplyNumber('3');
            });
        }

        public void ApplyFour()
        {
            ChangeDisplayNumber(() =>
            {
                ApplyNumber('4');
            });
        }

        public void ApplyFive()
        {
            ChangeDisplayNumber(() =>
            {
                ApplyNumber('5');
            });
        }

        public void ApplySix()
        {
            ChangeDisplayNumber(() =>
            {
                ApplyNumber('6');
            });
        }

        public void ApplySeven()
        {
            ChangeDisplayNumber(() =>
            {
                ApplyNumber('7');
            });
        }

        public void ApplyEight()
        {
            ChangeDisplayNumber(() =>
            {
                ApplyNumber('8');
            });
        }

        public void ApplyNine()
        {
            ChangeDisplayNumber(() =>
            {
                ApplyNumber('9');
            });
        }

        private void ApplyNumber(char symbol)
        {
            if (_displayNumber.IsDefault())
            {
                _displayNumber.IntegerPart = string.Empty;
            }

            if (_isLastActionAnBinaryOperation)
            {
                _displayNumber.IntegerPart = string.Empty;
            }

            if (!_displayNumber.HasComma)
            {
                _displayNumber.IntegerPart += symbol;
            }
            else
            {
                _displayNumber.FractionalPart += symbol;
            }
        }

        public void ApplyNegation()
        {
            ChangeDisplayNumber(() =>
            {
                if (_displayNumber.IsDefault())
                    return;

                _displayNumber.IsNegative = !_displayNumber.IsNegative;
            });
        }

        public void ApplyComma()
        {
            ChangeDisplayNumber(() =>
            {
                if (_isLastActionAnBinaryOperation)
                {
                    _displayNumber.Reset();
                }

                _displayNumber.HasComma = true;
            });
        }

        public void Clear()
        {
            ChangeDisplayNumber(() =>
            {
                _displayNumber.Reset();
            });
        }

        public void ClearLastSymbol()
        {
            if (_isLastActionAnBinaryOperation)
                return;

            ChangeDisplayNumber(() =>
            {
                _displayNumber.ClearLastSymbol();
            });
        }

        public void Cancel()
        {
            ChangeDisplayNumber(() =>
            {
                _displayNumber.Reset();
            });
        }

        public void ApplyAddition()
        {
            ApplyBinaryOperation(BinaryOperations.Addition);
        }

        public void ApplySubtraction()
        {
            ApplyBinaryOperation(BinaryOperations.Subtraction);
        }

        public void ApplyMultiplication()
        {
            ApplyBinaryOperation(BinaryOperations.Multiplication);
        }

        public void ApplyDivision()
        {
            ApplyBinaryOperation(BinaryOperations.Division);
        }

        private void ApplyBinaryOperation(IBinaryOperation binaryOperation)
        {
            ApplyEquality();

            _selectedBinaryOperation = binaryOperation;
            _lastOperand1 = _displayNumber.ToDouble();
            _isLastActionAnBinaryOperation = true;
        }

        public void ApplyEquality()
        {
            try
            {
                if (_lastOperand1 == null)
                {
                    var newValue = _displayNumber.ToDouble();
                    DisplayValue = newValue.ToString(_cultureInfo);

                    _lastOperand1 = newValue;
                    _lastResult = newValue;
                    return;
                }

                var binaryOperationInfo = GetBinaryOperationInfo();
                if (binaryOperationInfo == null)
                    return;

                var value1 = binaryOperationInfo.Value1;
                var value2 = binaryOperationInfo.Value2;
                var binaryOperation = binaryOperationInfo.BinaryOperation;

                var executableInfo = binaryOperation.GetExecutableInfo(value1, value2);
                if (executableInfo.CanBeExecuted)
                {
                    var result = binaryOperation.Execute(value1, value2);

                    var displayValue = result.ToString(_cultureInfo);
                    _displayNumber = DisplayNumberFactory.Create(displayValue);
                    DisplayValue = displayValue;

                    _lastOperand1 = value1;
                    _lastOperand2 = value2;
                    _lastResult = result;
                    _lastBinaryOperation = _selectedBinaryOperation;
                }
                else
                {
                    DisplayValue = executableInfo.Message;
                }

                _selectedBinaryOperation = null;
            }
            finally
            {
                _isLastActionAnBinaryOperation = true;
            }
        }

        private BinaryOperationInfo GetBinaryOperationInfo()
        {
            if (_selectedBinaryOperation != null)
            {
                return new BinaryOperationInfo
                {
                    Value1 = _lastResult,
                    Value2 = _displayNumber.ToDouble(),
                    BinaryOperation = _selectedBinaryOperation,
                };
            }

            if (_lastBinaryOperation != null)
            {
                return new BinaryOperationInfo
                {
                    Value1 = _displayNumber.ToDouble(),
                    Value2 = _lastOperand2,
                    BinaryOperation = _lastBinaryOperation,
                };
            }

            return null;
        }

        public void ApplyPercent()
        {
            var value1 = _lastOperand1.GetValueOrDefault();
            var value2 = _displayNumber.ToDouble();
            var operation = BinaryOperations.Percent;
            var executableInfo = operation.GetExecutableInfo(value1, value2);
            if (!executableInfo.CanBeExecuted)
            {
                DisplayValue = executableInfo.Message;
                return;
            }

            var result = operation.Execute(value1, value2);
            var displayValue = result.ToString(_cultureInfo);
            _displayNumber = DisplayNumberFactory.Create(displayValue);
            DisplayValue = displayValue;
        }

        public void ApplySquareRoot()
        {
            var value = _displayNumber.ToDouble();
            var operation = UnaryOperations.SquareRoot;
            var executableInfo = operation.GetExecutableInfo(value);
            if (!executableInfo.CanBeExecuted)
            {
                DisplayValue = executableInfo.Message;
                return;
            }

            var result = operation.Execute(value);
            var displayValue = result.ToString(_cultureInfo);
            _displayNumber = DisplayNumberFactory.Create(displayValue);
            DisplayValue = displayValue;
        }

        public void ApplySquaring()
        {
            var value = _displayNumber.ToDouble();
            var operation = UnaryOperations.Squaring;
            var executableInfo = operation.GetExecutableInfo(value);
            if (!executableInfo.CanBeExecuted)
            {
                DisplayValue = executableInfo.Message;
                return;
            }

            var result = operation.Execute(value);
            var displayValue = result.ToString(_cultureInfo);
            _displayNumber = DisplayNumberFactory.Create(displayValue);
            DisplayValue = displayValue;
        }

        public void ApplyTurningOver()
        {
            throw new NotImplementedException();
        }

        #endregion

        private void ChangeDisplayNumber(Action action)
        {
            action();
            _isLastActionAnBinaryOperation = false;
            DisplayValue = _displayNumber.ToString();
        }
    }
}
