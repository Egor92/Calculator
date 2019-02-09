﻿using System;
using System.Globalization;
using Calculator.BusinessLogic.Operations;

namespace Calculator.BusinessLogic
{
	public class Calculator : ICalculator
	{
		#region Fields

		private readonly CultureInfo _cultureInfo;
		private double _previousValue = 0;
		private bool _wasOperationApplied = false;
		private readonly DisplayNumber _displayNumber = new DisplayNumber();
		private IBinaryOperation _selectedBinaryOperation;

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
			_previousValue = state.PreviousValue;
			_wasOperationApplied = state.WasEqualsSet;
			_displayNumber = state.DisplayNumber;
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

			if (_wasOperationApplied)
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
				if (_wasOperationApplied)
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
			if (_wasOperationApplied)
				return;

			UpdateDisplayNumber(() =>
			{
				if (_displayNumber.HasComma)
				{
					if (!string.IsNullOrEmpty(_displayNumber.FractionalPart))
					{
						_displayNumber.FractionalPart = _displayNumber.FractionalPart.Substring(0, _displayNumber.FractionalPart.Length - 1);
					}
					else
					{
						_displayNumber.HasComma = false;
					}
				}
				else
				{
					var integerPartLength = _displayNumber.IntegerPart.Length;
					if (integerPartLength > 1)
					{
						_displayNumber.IntegerPart = _displayNumber.IntegerPart.Substring(0, integerPartLength - 1);
					}
					else
					{
						_displayNumber.Reset();
					}
				}
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
			ApplyOperation(() =>
			{
				_selectedBinaryOperation = Operations.Operations.Addition;
			});
		}

		public void ApplySubtraction()
		{
			ApplyOperation(() =>
			{
				_selectedBinaryOperation = Operations.Operations.Subtraction;
			});
		}

		public void ApplyMultiplication()
		{
			ApplyOperation(() =>
			{
				_selectedBinaryOperation = Operations.Operations.Multiplication;
			});
		}

		public void ApplyDivision()
		{
			ApplyOperation(() =>
			{
				_selectedBinaryOperation = Operations.Operations.Division;
			});
		}

		private void ApplyOperation(Action action)
		{
			action();
			_wasOperationApplied = true;
			_previousValue = _displayNumber.ToDouble();
		}

		public void ApplyEquality()
		{
			if (_selectedBinaryOperation == null)
				return;

			var value1 = _previousValue;
			var value2 = _displayNumber.ToDouble();
			var executableInfo = _selectedBinaryOperation.GetExecutableInfo(value1, value2);
			if (executableInfo.CanBeExecuted)
			{
				_previousValue = _selectedBinaryOperation.Execute(value1, value2);
				DisplayValue = _previousValue.ToString(_cultureInfo);
			}
			else
			{
				DisplayValue = executableInfo.Message;
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
