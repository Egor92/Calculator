using System;
using System.Globalization;

namespace Calculator.BusinessLogic
{
	public class Calculator : ICalculator
	{
		#region Fields

		private readonly CultureInfo _cultureInfo;
		private double _previousValue = 0;
		private bool _isEqualitySet = false;
		private readonly DisplayNumber _displayNumber = new DisplayNumber();

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
			_isEqualitySet = state.WasEqualsSet;
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

			if (_isEqualitySet)
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
				if (_isEqualitySet)
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
			if (_isEqualitySet)
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
			throw new NotImplementedException();
		}

		public void ApplyAddition()
		{
			return;

			ApplyOperation(() =>
			{
				_previousValue += _displayNumber.ToDouble();
			});
		}

		public void ApplySubtraction()
		{
			return;

			ApplyOperation(() =>
			{
				_previousValue -= _displayNumber.ToDouble();
			});
		}

		public void ApplyMultiplication()
		{
		}

		public void ApplyDivision()
		{
		}

		public void ApplyEquality()
		{
			throw new NotImplementedException();
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

		private void ApplyOperation(Action action)
		{
			action();
			DisplayValue = _previousValue.ToString(_cultureInfo);
		}
	}
}
