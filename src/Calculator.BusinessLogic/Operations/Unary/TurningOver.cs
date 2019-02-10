using Calculator.BusinessLogic.Constants;

namespace Calculator.BusinessLogic.Operations.Unary
{
    public class TurningOver : IUnaryOperation
    {
        public ExecutableInfo GetExecutableInfo(double value)
        {
            if (value == 0.0)
            {
                return ExecutableInfo.CreateNotExecutable(ErrorMessages.DivisionOnZero);
            }

            return ExecutableInfo.CreateExecutable();
        }

        public double Execute(double value)
        {
            return 1.0 / value;
        }
    }
}
