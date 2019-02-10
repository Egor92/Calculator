using System;
using Calculator.BusinessLogic.Constants;

namespace Calculator.BusinessLogic.Operations.Unary
{
    public class SquareRoot : IUnaryOperation
    {
        public ExecutableInfo GetExecutableInfo(double value)
        {
            if (value < 0)
            {
                return ExecutableInfo.CreateNotExecutable(ErrorMessages.InvalidInput);
            }

            return ExecutableInfo.CreateExecutable();
        }

        public double Execute(double value)
        {
            return Math.Sqrt(value);
        }
    }
}
