namespace Calculator.BusinessLogic
{
	internal class CalculatorState
	{
		public CalculatorState(double previousValue, DisplayNumber displayNumber, bool wasEqualsSet)
		{
			PreviousValue = previousValue;
			DisplayNumber = displayNumber;
			WasEqualsSet = wasEqualsSet;
		}

		public double PreviousValue { get; set; }

		public DisplayNumber DisplayNumber { get; set; }

		public bool WasEqualsSet { get; set; }
	}
}
