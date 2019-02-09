using System;
using System.Globalization;
using Calculator.BusinessLogic.Operations;

namespace Calculator.BusinessLogic
{
    public class Calculator : ICalculator
    {
        #region Fields

        private readonly CultureInfo _cultureInfo;
        private double? _previousValue1;
        private double? _previousValue2;
        private readonly DisplayNumber _displayNumber = new DisplayNumber();
        private IBinaryOperation _selectedBinaryOperation;
        private IBinaryOperation _lastBinaryOperation;

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
            _previousValue1 = state.PreviousValue;
            _displayNumber = state.DisplayNumber;
            _selectedBinaryOperation = state.SelectedBinaryOperation;
            DisplayValue = _displayNumber.ToString();
        }

        #endregion

        #region Implementation of ICalculator

        public string DisplayValue { get; private set; }

        public void ApplyZero()
        {
            UpdateDisplayNumber(() =>
            {
                ApplyNumber('0');
            });
        }

        public void ApplyOne()
        {
            UpdateDisplayNumber(() =>
            {
                ApplyNumber('1');
            });
        }

        public void ApplyTwo()
        {
            UpdateDisplayNumber(() =>
            {
                ApplyNumber('2');
            });
        }

        public void ApplyThree()
        {
            UpdateDisplayNumber(() =>
            {
                ApplyNumber('3');
            });
        }

        public void ApplyFour()
        {
            UpdateDisplayNumber(() =>
            {
                ApplyNumber('4');
            });
        }

        public void ApplyFive()
        {
            UpdateDisplayNumber(() =>
            {
                ApplyNumber('5');
            });
        }

        public void ApplySix()
        {
            UpdateDisplayNumber(() =>
            {
                ApplyNumber('6');
            });
        }

        public void ApplySeven()
        {
            UpdateDisplayNumber(() =>
            {
                ApplyNumber('7');
            });
        }

        public void ApplyEight()
        {
            UpdateDisplayNumber(() =>
            {
                ApplyNumber('8');
            });
        }

        public void ApplyNine()
        {
            UpdateDisplayNumber(() =>
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

            if (_selectedBinaryOperation != null)
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
            UpdateDisplayNumber(() =>
            {
                if (_displayNumber.IsDefault())
                    return;

                _displayNumber.IsNegative = !_displayNumber.IsNegative;
            });
        }

        public void ApplyComma()
        {
            UpdateDisplayNumber(() =>
            {
                if (_selectedBinaryOperation != null)
                {
                    _displayNumber.Reset();
                }

                _displayNumber.HasComma = true;
            });
        }

        public void Clear()
        {
            UpdateDisplayNumber(() =>
            {
                _displayNumber.Reset();
            });
        }

        public void ClearLastSymbol()
        {
            if (_selectedBinaryOperation != null)
                return;

            UpdateDisplayNumber(() =>
            {
                _displayNumber.ClearLastSymbol();
            });
        }

        public void Cancel()
        {
            UpdateDisplayNumber(() =>
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
            if (_previousValue1 != null)
            {
                ApplyEquality();
            }

            _selectedBinaryOperation = binaryOperation;
            _previousValue1 = _displayNumber.ToDouble();
        }

        public void ApplyEquality()
        {
            if (_previousValue1 == null)
            {
                var newValue = _displayNumber.ToDouble();
                DisplayValue = newValue.ToString(_cultureInfo);
                _previousValue1 = newValue;
                return;
            }

            if (_selectedBinaryOperation == null && _lastBinaryOperation != null && _previousValue2 != null)
            {
                var value1 = _displayNumber.ToDouble();
                var value2 = _previousValue2.Value;
                var newValue = _lastBinaryOperation.Execute(value1, value2);
                DisplayValue = newValue.ToString(_cultureInfo);
                _previousValue1 = newValue;
            }
            else if (_selectedBinaryOperation != null)
            {
                var value1 = _previousValue1.Value;
                var value2 = _displayNumber.ToDouble();
                var executableInfo = _selectedBinaryOperation.GetExecutableInfo(value1, value2);
                if (executableInfo.CanBeExecuted)
                {
                    var newValue = _selectedBinaryOperation.Execute(value1, value2);
                    DisplayValue = newValue.ToString(_cultureInfo);
                    _previousValue1 = newValue;
                    _previousValue2 = value2;
                    _lastBinaryOperation = _selectedBinaryOperation;
                }
                else
                {
                    DisplayValue = executableInfo.Message;
                }

                _selectedBinaryOperation = null;
                _displayNumber.Reset();
            }
        }

        public void ApplyPercent()
        {
            throw new NotImplementedException();
        }

        public void ApplySquareRoot()
        {
            throw new NotImplementedException();
        }

        public void ApplySquaring()
        {
            throw new NotImplementedException();
        }

        public void ApplyTurningOver()
        {
            throw new NotImplementedException();
        }

        #endregion

        private void UpdateDisplayNumber(Action action)
        {
            action();
            DisplayValue = _displayNumber.ToString();
        }
    }
}
