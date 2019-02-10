namespace Calculator.BusinessLogic
{
    internal class CalculatorState
    {
        internal double PreviousValue { get; private set; }

        internal DisplayNumber DisplayNumber { get; private set; }

        internal bool IsLastActionAnBinaryOperation { get; private set; }

        internal class Builder
        {
            private double _previousValue;
            private DisplayNumber _displayNumber;
            private bool _isLastActionAnBinaryOperation;

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

            internal Builder IsLastActionAnBinaryOperation(bool isLastActionAnBinaryOperation)
            {
                _isLastActionAnBinaryOperation = isLastActionAnBinaryOperation;
                return this;
            }

            internal CalculatorState Build()
            {
                return new CalculatorState
                {
                    PreviousValue = _previousValue,
                    DisplayNumber = _displayNumber,
                    IsLastActionAnBinaryOperation = _isLastActionAnBinaryOperation,
                };
            }
        }
    }
}
