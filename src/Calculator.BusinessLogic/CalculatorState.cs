namespace Calculator.BusinessLogic
{
    internal class CalculatorState
    {
        internal double PreviousValue { get; private set; }

        internal DisplayNumber DisplayNumber { get; private set; }

        internal bool IsLastActionAnOperation { get; private set; }

        internal class Builder
        {
            private double _previousValue;
            private DisplayNumber _displayNumber;
            private bool _isLastActionAnOperation;

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

            internal Builder IsLastActionAnOperation(bool isLastActionAnOperation)
            {
                _isLastActionAnOperation = isLastActionAnOperation;
                return this;
            }

            internal CalculatorState Build()
            {
                return new CalculatorState
                {
                    PreviousValue = _previousValue,
                    DisplayNumber = _displayNumber,
                    IsLastActionAnOperation = _isLastActionAnOperation,
                };
            }
        }
    }
}
