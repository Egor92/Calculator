using System;

namespace Calculator.BusinessLogic
{
	public class Calculator : ICalculator
	{
		#region Fields

		private double _previousValue = 0;
		private bool _isEqualsSet = false;
		private readonly DisplayNumber _displayNumber = new DisplayNumber();

		#endregion

		#region Ctor

		public Calculator()
		{
		}

		internal Calculator(CalculatorState state)
		{
			_previousValue = state.PreviousValue;
			_isEqualsSet = state.WasEqualsSet;
			_displayNumber = state.DisplayNumber;
		}

		#endregion

		#region Implementation of ICalculator

		public string DisplayValue
		{
			get { return _displayNumber.ToString(); }
		}

		public void ApplyZero()
		{
			ApplyNumber('0');
		}

		public void ApplyOne()
		{
			ApplyNumber('1');
		}

		public void ApplyTwo()
		{
			ApplyNumber('2');
		}

		public void ApplyThree()
		{
			ApplyNumber('3');
		}

		public void ApplyFour()
		{
			ApplyNumber('4');
		}

		public void ApplyFive()
		{
			ApplyNumber('5');
		}

		public void ApplySix()
		{
			ApplyNumber('6');
		}

		public void ApplySeven()
		{
			ApplyNumber('7');
		}

		public void ApplyEight()
		{
			ApplyNumber('8');
		}

		public void ApplyNine()
		{
			ApplyNumber('9');
		}

		private void ApplyNumber(char symbol)
		{
			if (_displayNumber.IsDefault())
			{
				_displayNumber.IntegerPart = string.Empty;
			}

			if (_isEqualsSet)
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

		public void ApplyAddition()
		{
			throw new NotImplementedException();
		}

		public void ApplySubtraction()
		{
			throw new NotImplementedException();
		}

		public void ApplyMultiplication()
		{
			throw new NotImplementedException();
		}

		public void ApplyDivision()
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

		public void Clear()
		{
			throw new NotImplementedException();
		}

		public void ClearLastSymbol()
		{
			throw new NotImplementedException();
		}

		public void Cancel()
		{
			throw new NotImplementedException();
		}

		public void ApplyNegation()
		{
			if (_displayNumber.IsDefault())
				return;

			_displayNumber.IsNegative = !_displayNumber.IsNegative;
		}

		public void ApplyDot()
		{
			throw new NotImplementedException();
		}

		public void ApplyEquality()
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
