using Calculator.BusinessLogic.Operations;

namespace Calculator.BusinessLogic
{
    internal class CalculatorState
    {
        internal double PreviousValue { get; private set; }

        internal DisplayNumber DisplayNumber { get; private set; }

        internal IBinaryOperation SelectedBinaryOperation { get; private set; }

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
                    SelectedBinaryOperation = _wasEqualsSet
                        ? BinaryOperations.Addition
                        : null,
                };
            }
        }
    }
}
