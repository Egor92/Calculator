namespace Calculator.BusinessLogic
{
	internal class CalculatorState
	{
		internal double PreviousValue { get; set; }

		internal DisplayNumber DisplayNumber { get; set; }

		internal bool WasEqualsSet { get; set; }

		internal class Builder
		{
			private double _previousValue;
			private DisplayNumber _displayNumber;
			private bool _wasEqualsSet;

			internal Builder PreviousValue(double previousValue)
			{
				_previousValue = previousValue;
				return this;
			}

			internal Builder DisplayNumber(DisplayNumber displayNumber)
			{
				_displayNumber = displayNumber;
				return this;
			}

			internal Builder WasEqualsSet(bool wasEqualsSet)
			{
				_wasEqualsSet = wasEqualsSet;
				return this;
			}

			internal CalculatorState Build()
			{
				return new CalculatorState
				{
					PreviousValue = _previousValue,
					DisplayNumber = _displayNumber,
					WasEqualsSet = _wasEqualsSet,
				};
			}
		}
	}
}
